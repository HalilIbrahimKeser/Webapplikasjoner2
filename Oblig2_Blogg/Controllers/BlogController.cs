using System;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IRepository repository;
        private UserManager<IdentityUser> userManager;
        IAuthorizationService authorizationService;


        //CONSTRUCTOR-----------------------------------------------
        public BlogController(IRepository repository, UserManager<IdentityUser> userManager = null, IAuthorizationService authorizationService = null)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.authorizationService = authorizationService;
        }

        //VIEWS---------------------------------------------------

        //VIEW
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.GetAllBlogs());
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadBlog(int id)
        {
            var blog = repository.GetBlog(id);
            var posts = repository.GetAllPosts(id);

            if (ModelState.IsValid)
            {
                var blogViewModel = new BlogViewModel()
                {
                    BlogId = id,
                    Name = blog.Name,
                    Description = blog.Description,
                    Created = blog.Created,
                    Modified = blog.Modified,
                    Closed = blog.Closed,
                    Owner = blog.Owner,
                    Posts = posts.ToList()
                };
                return View(blogViewModel);
            }
            else
            {
                return View();
            }
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadPost(int id)
        {
            var postViewModel = repository.GetPostViewModel(id);

            return View(postViewModel);
        }

        //BLOG CRUD OPERATIONS------------------------------------------------------------------------
        
        // Blog/Create
        [HttpGet]
        public ActionResult Create() { return View(); }

        // Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, Description, Created, Closed, Owner")] CreateBlogViewModel blogViewModel) 
        { 
            try {
                if (ModelState.IsValid) {
                    var blog = new Blog() {
                        Name = blogViewModel.Name,
                        Description = blogViewModel.Description,
                        Created = DateTime.Now,
                        Closed = blogViewModel.Closed,
                    };
                    repository.SaveBlog(blog, User).Wait();
                    TempData["message"] = string.Format("{0} har blitt opprettet", blog.Name);
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception e)
            { Console.WriteLine(e);
                return View();
            }
            return View();
        }

        //COMMENT CRUD OPERATIONS------------------------------------------------------------------------
        
        // Comment/Create
        [HttpGet]
        public ActionResult CreateComment(int PostId) { return View(); }

        // Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(int PostId, [Bind("CommentId, CommentText, Created, PostId, Owner")] CommentViewModel newCommentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var comment = new Comment()
                    {
                        CommentText = newCommentViewModel.CommentText,
                        Created = DateTime.Now,
                        PostId = PostId,
                    };
                    repository.SaveComment(comment, User).Wait();
                    TempData["message"] = $"{comment.PostId} har blitt opprettet";
                    return RedirectToAction("ReadPost", new { id = PostId });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return ViewBag("Feil kan ikke lage kommentar");
            }
            return View();
        }


        // Comment/Edit/#
        [HttpGet]
        public ActionResult EditComment(int id)
        {
            var commentToEdit = repository.GetComment(id);
            return View(commentToEdit);
        }

        // Comment/Edit/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditComment(int? id, [Bind("CommentId, CommentText, Created, Modified, PostId, Post")] Comment comment)
        {
            if (id == null)
            {
                return NotFound();
            }
            /*
            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, comment, BlogOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }*/

            var postId = comment.PostId;
            var created = comment.Created;
            try {
                if (ModelState.IsValid) {
                    comment.Modified = DateTime.Now;
                    comment.Created = created;

                    repository.UpdateComment(comment, User).Wait();
                    TempData["message"] = $"{comment.CommentText} has been updated";
                    return RedirectToAction("ReadPost", new { id = postId });
                } else return new ChallengeResult();
            } catch {
                return ViewBag("Fikk ikke endret commentar");
            }
        }

        // Comment/Delete/#
        public ActionResult DeleteComment(int id)
        {
            var commentToDelete = repository.GetComment(id);
            return View(commentToDelete);
        }

        // Comment/Delete/#
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id, IFormCollection collection)
        {
            try {
                if (ModelState.IsValid)
                {
                    var commentToDelete = repository.GetComment(id);
                    var postId = commentToDelete.PostId;

                    repository.DeleteComment(commentToDelete, User).Wait();
                    TempData["message"] = $"{commentToDelete.CommentText} has been updated";

                    return RedirectToAction("ReadPost", new { id = postId });
                }
                else return new ChallengeResult();
            } catch {
                return ViewBag("Fikk ikk slettett kommentar");
            }
        }


        //POST CRUD OPERATIONS------------------------------------------------------------------------

        // Post/Create
        [HttpGet]
        public ActionResult CreatePost(int blogId)
        {
            var blog = repository.GetBlog(blogId);
            /*
            if (User.Identity != null && blog.Owner.Id != userManager.GetUserId(User))
            {
                return View("Ingentilgang");
            }
            */
            if (!blog.Closed)
            {
                return View();
            }
            
            TempData["message"] = "Bloggen er stengt for kommentar og innlegg";

            return RedirectToAction("ReadBlog", new { id = blogId });
        }

        // Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(int blogId, [Bind("PostText, Created, BlogId, Owner")] PostViewModel newPostViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var blog = repository.GetBlog(blogId);
                    if (!blog.Closed)
                    {
                        var post = new Post()
                        {
                            PostText = newPostViewModel.PostText,
                            Created = DateTime.Now,
                            BlogId = blogId,
                        };
                        repository.SavePost(post, User).Wait();
                        TempData["message"] = $"{post.PostId} har blitt opprettet";
                        return RedirectToAction("ReadBlog", new { id = blogId });
                    }
                    else
                    {
                        return ViewBag("Låst for endringer");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
            TempData["message"] = "Fikk ikke opprettet ny post";
            return RedirectToAction("ReadBlog", new { id = blogId });
        }

        // Post/Edit/#
        [HttpGet]
        public async Task<ActionResult> EditPost(int id)
        {
            if (id == null)
            {
                return NotFound("Bad parameter");
            }
            var postToEdit = repository.GetPost(id);

            return View(postToEdit);
        }

        // Post/Edit/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? id, [Bind("PostId, PostText, Created, Modified, BlogId")] Post post)
        {
            if (id == null) { return NotFound(); }

            var blogId = post.BlogId;
            var created = post.Created;

            var blog = repository.GetBlog(blogId);
            if (!blog.Closed) {
                //try {
                    if (ModelState.IsValid) {
                        post.Modified = DateTime.Now;
                        post.Created = created;

                        var result = await repository.UpdatePost(post, User);
                        if (result != null)
                        {
                            TempData["message"] = string.Format("{0} is updated", post.PostText);
                            return RedirectToAction("ReadBlog", new { id = blogId });
                        }

                        repository.UpdatePost(post, User).Wait();

                        TempData["message"] = $"{post.PostText} has been updated";
                        return RedirectToAction("ReadBlog", new { id = blogId });
                    } 
                    else return new ChallengeResult();
                //} catch {
                    //return ViewBag("Kan ikke redigere post");
                //}
            } else
            { return ViewBag("Låst for endringer");
            }
        }


        // Post/Delete/#
        public ActionResult DeletePost(int id)
        {
            var postToDelete = repository.GetPost(id);
            return View(postToDelete);
        }

        // Post/Delete/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var postToDelete = repository.GetPost(id);
                    var blogId = postToDelete.BlogId;

                    var blog = repository.GetBlog(blogId);
                    if (!blog.Closed)
                    {
                        repository.DeletePost(postToDelete, User).Wait();
                        TempData["message"] = $"{postToDelete.PostText} has been updated";

                        return RedirectToAction("ReadBlog", new { id = blogId });
                    }
                    else
                    {
                        return ViewBag("Kan ikke slette");
                    }
                }
                else return new ChallengeResult();
            }
            catch
            {
                return ViewBag("Exception thrown");
            }
        }
    }
}
