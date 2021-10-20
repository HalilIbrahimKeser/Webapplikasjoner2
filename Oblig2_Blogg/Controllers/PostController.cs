using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;
using Oblig2_Blogg.Authorization;

namespace Oblig2_Blogg.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository repository;
        private UserManager<ApplicationUser> userManager;
        IAuthorizationService authorizationService;

        public PostController(IRepository repository, UserManager<ApplicationUser> userManager1 = null, IAuthorizationService authorizationService1 = null)
        {
            this.repository = repository;
            this.authorizationService = authorizationService1;
            this.userManager = userManager1;
        }
        public IActionResult Index(int id)
        {
            return View(repository.GetPost(id));
        }


        //POST CRUD OPERATIONS------------------------------------------------------------------------

        // Post/Create
        [HttpGet]
        public async Task<ActionResult> CreatePost(int blogId)
        {
            var blog = repository.GetBlog(blogId);
            
            if (blog.Closed) {
                TempData["Feedback"] = "Blog steng for innlegg" + blog.BlogId;
                return RedirectToAction("ReadBlog", "Blog", new { id = blog.BlogId });
            }

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, blog, BlogOperations.Create);

            //Kun eier av blog kan legge inn poster. Resten kan kun kommentere
            if (!isAuthorized.Succeeded && User.Identity == null && blog.Owner.Id != userManager.GetUserId(User)) {
                TempData["Feedback"] = "Ingen tilgang";
                return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                //return Forbid();
            }
            return View();
        }

        // Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(int blogId, [Bind("PostText, Created, BlogId, Owner")] PostViewModel newPostViewModel)
        {
            try {
                if (ModelState.IsValid) {
                    var blog = repository.GetBlog(blogId);
                    
                    if (!blog.Closed) {
                        var post = new Post()
                        {
                            PostText = newPostViewModel.PostText,
                            Created = DateTime.Now,
                            BlogId = blogId,
                            
                        };
                        repository.SavePost(post, User).Wait();

                        TempData["Feedback"] = $"{post.PostId} har blitt opprettet";
                        return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                    } else {
                        TempData["Feedback"] = "Låst for endringer";
                        return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                TempData["Feedback"] = e;
                return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
            }
            TempData["Feedback"] = "Fikk ikke opprettet ny post";
            return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
        }

        // Post/Edit/#
        [HttpGet]
        public async Task<ActionResult> EditPost(int id)
        {
            if (id == 0)
            {
                return NotFound("Bad parameter");
            }
            var postToEdit = repository.GetPost(id);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, postToEdit, BlogOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang til post " + postToEdit.PostId;
                return Forbid();
            }

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
            if (!blog.Closed)
            {
                try {
                    if (ModelState.IsValid)
                    {
                        post.Modified = DateTime.Now;
                        post.Created = created;

                        var result = await repository.UpdatePost(post, User);
                        if (result != null)
                        {
                            TempData["Feedback"] = string.Format("{0} is updated", post.PostText);
                            return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                        }

                        repository.UpdatePost(post, User).Wait();

                        TempData["Feedback"] = $"{post.PostText} has been updated";
                        return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                    }
                    else return new ChallengeResult();
                } catch {
                    return ViewBag("Kan ikke redigere post");
                }
            }
            else
            {
                TempData["Feedback"] = "Kan ikke redigere post, den er låst";
                return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
            }
        }

        // Post/Delete/#
        public async Task<ActionResult> DeletePost(int id)
        {
            var postToDelete = repository.GetPost(id);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, postToDelete, BlogOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang";
                return Forbid();
            }
            return View(postToDelete);
        }

        // Post/Delete/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, IFormCollection collection)
        {
            var postToDelete = repository.GetPost(id);
            var blogId = postToDelete.BlogId;

            try
            {
                if (ModelState.IsValid)
                {
                    var blog = repository.GetBlog(blogId);
                    if (!blog.Closed)
                    {
                        repository.DeletePost(postToDelete, User).Wait();

                        TempData["Feedback"] = $"{postToDelete.PostText} has been updated";

                        return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                    }
                    else
                    {
                        TempData["Feedback"] = "Kan ikke slette";
                        return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
                    }
                }
                else return new ChallengeResult();
            }
            catch (Exception e)
            {
                TempData["Feedback"] = e;
                return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
            }
        }

        //TAGS CRUD OPERATIONS and VIEW------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult FindPostsWithTag(int tagId, int blogId)
        {
            var blog = new Blog();
            blog = repository.GetBlog(blogId);
            
            var blogViewModel = new BlogViewModel();
            List<Post> posts = repository.GetAllPostsInThisBlogWithThisTag(tagId, blogId).ToList();

            blogViewModel.Posts = posts;

            return RedirectToAction("ReadBlog", "Blog", new { id = blogId });
        }

        
        //COMMENT CRUD OPERATIONS------------------------------------------------------------------------

        // Comment/Create
        [HttpGet]
        public ActionResult CreateComment(int PostId)
        {
            var post = repository.GetPost(PostId);
            var blog = repository.GetBlog(post.BlogId);
            if (blog.Closed)
            {
                TempData["Feedback"] = "Blog steng for kommentarer: " + blog.BlogId;
                return RedirectToAction("ReadBlog", "Blog", new { id = blog.BlogId });
            }
            return View();
        }

        // Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(int PostId, [Bind("CommentId, CommentText, Created, PostId, Owner")] CommentViewModel newCommentViewModel)
        {
            try {
                if (ModelState.IsValid) 
                {
                    var comment = new Comment()
                    {
                        CommentText = newCommentViewModel.CommentText,
                        Created = DateTime.Now,
                        PostId = PostId,
                    };
                    repository.SaveComment(comment, User).Wait();

                    TempData["Feedback"] = $"{comment.PostId} har blitt opprettet";
                    return RedirectToAction("ReadPost", "Blog", new { id = PostId });
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                TempData["Feedback"] = "Feil kan ikke legge inn kommentar" + e;
                return RedirectToAction("ReadPost", "Blog", new { id = PostId });
            }
            return View();
        }


        // Comment/Edit/#
        [HttpGet]
        public async Task<ActionResult> EditComment(int id)
        {
            var commentToEdit = repository.GetComment(id);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, commentToEdit, BlogOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang";
                return Forbid();
            }
            return View(commentToEdit);
        }

        // Comment/Edit/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(int? id, [Bind("CommentId, CommentText, Created, Modified, PostId, Post")] Comment comment)
        {
            if (id == null) { return NotFound(); }

            var postId = comment.PostId;
            var created = comment.Created;
            try {
                if (ModelState.IsValid) {
                    comment.Modified = DateTime.Now;
                    comment.Created = created;

                    repository.UpdateComment(comment, User).Wait();

                    TempData["Feedback"] = $"{comment.CommentText} has been updated";
                    return RedirectToAction("ReadPost", "Blog", new { id = postId });
                }
                else return new ChallengeResult();
            } catch {
                TempData["Feedback"] = "Fikk ikke endret kommentar";
                return RedirectToAction("ReadPost", "Blog", new { id = postId });
            }
        }

        // Comment/Delete/#
        public async Task<ActionResult> DeleteComment(int id)
        {
            var commentToDelete = repository.GetComment(id);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, commentToDelete, BlogOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang";
                return Forbid();
            }
            return View(commentToDelete);
        }

        // Comment/Delete/#
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id, IFormCollection collection)
        {
            var commentToDelete = repository.GetComment(id);
            var postId = commentToDelete.PostId;

            try {
                if (ModelState.IsValid) {
                    repository.DeleteComment(commentToDelete, User).Wait();

                    TempData["Feedback"] = $"{commentToDelete.CommentText} has been updated";
                    return RedirectToAction("ReadPost", "Blog", new { id = postId });
                }
                else return new ChallengeResult();
            } catch (Exception e) {
                TempData["Feedback"] = $"Comment has been updated" + e;
                return RedirectToAction("ReadPost", "Blog", new { id = postId });
            }
        }
    }
}
