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
        //private UserManager<IdentityUser> manager;
        IAuthorizationService _authorizationService;

        //CONSTRUCTOR
        public BlogController(IRepository repository, IAuthorizationService authorizationService = null)
        {
            this.repository = repository;
            //this.manager = manager;
            _authorizationService = authorizationService;
        }

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

            var blogViewModel = new BlogViewModel()
            {
                BlogId = id, Name = blog.Name, 
                Description = blog.Description,
                Created = blog.Created,
                Modified = blog.Modified,
                Closed = blog.Closed,
                Owner = blog.Owner,
                Posts = posts.ToList()
            };
            return View(blogViewModel);
        }
        //VIEW
        [AllowAnonymous]
        public ActionResult ReadPost(int id)
        {
            var postViewModel = repository.GetPostViewModel(id);

            return View(postViewModel);
        }

        // GET
        // Blog/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create() { return View(); }

        // POST
        // Blog/Create
        [Authorize]
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
                        Owner = blogViewModel.Owner
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

        //GET post
        //Blog/Post/Create
        [Authorize]
        [HttpGet]
        public ActionResult CreatePost(int blogId) { return View(); }

        //POST post:
        //Blog/Post/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(int blogId, [Bind("PostText, Created, BlogId, Owner")] PostViewModel newPostViewModel) 
        {
            try {
                if (ModelState.IsValid) {
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
            } catch (Exception e) 
            { Console.WriteLine(e); 
                return View();
            }
            return View();
        }
        //GET post
        //Blog/Comment/Create
        [Authorize]
        [HttpGet]
        public ActionResult CreateComment(int PostId) { return View(); }

        //POST post:
        //Blog/Comment/Create
        [HttpPost]
        [Authorize]
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
                return View();
            }
            return View();
        }

        // GET:
        // Post/Edit/5
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> EditPost(int id)
        {
            var postToEdit = repository.GetPost(id);

            //var isAutorized = await _authorizationService.AuthorizeAsync(User, postToEdit, BlogOperations.Update);
            //if (!isAutorized.Succeeded)
            //{
                //return View("Ingen tilgang");
            //}

            return View(postToEdit);
        }

        // POST:
        // Post/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? id, [Bind("PostId, PostText, Modified, BlogId, Owner")]Post post)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogId = post.BlogId;

            try {
                if (ModelState.IsValid) {
                    post.Modified = DateTime.Now;
                    var owner = User;

                    repository.UpdatePost(post, User).Wait();

                    TempData["message"] = $"{post.PostText} has been updated";

                    return RedirectToAction("ReadBlog", new { id = blogId });
                } else return new ChallengeResult();
            } catch {
                return View(post);
            }
        }

        // GET:
        // Post/Delete/5
        public ActionResult DeletePost(int id)
        {
            var postToDelete = repository.GetPost(id);
            return View(postToDelete);
        }

        // POST:
        // Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var owner = User;
                    var postToDelete = repository.GetPost(id);
                    var blogId = postToDelete.BlogId;

                    repository.DeletePost(postToDelete, User).Wait();
                    TempData["message"] = $"{postToDelete.PostText} has been updated";

                    return RedirectToAction("ReadBlog", new { id = blogId });
                }
                else return new ChallengeResult();
            }
            catch
            {
                return View("Exception thrown");
            }
        }

    }
}
