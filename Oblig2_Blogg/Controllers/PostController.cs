using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language;
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
        private IRepository @object;
        private IAuthorizationService authService;

        //UserManager<ApplicationUser> userManager1 = null,
        public PostController(IRepository repository,  IAuthorizationService authorizationService1 = null)
        {
            this.repository = repository;
            this.authorizationService = authorizationService1;
            //this.userManager = userManager1;
        }

        ////TODO? pga testing
        //public PostController(IRepository @object, IAuthorizationService authService)
        //{
        //    this.@object = @object;
        //    this.authService = authService;
        //}

        //public PostController(IRepository @object, IAuthorizationService authService)
        //{
        //    this.@object = @object;
        //    this.authService = authService;
        //}

        public IActionResult Index(int id)
        {
            return View(repository.GetPost(id));
        }


        //POST CRUD OPERATIONS------------------------------------------------------------------------

        // Post/Create
        [HttpGet]
        public async Task<ActionResult> CreatePost(int blogId)
        {
            Blog blog = repository.GetBlog(blogId);
            
            if (blog.Closed) {
                TempData["Feedback"] = "Blog steng for innlegg" + blog.BlogId;
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
            }

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, blog, BlogOperations.Create);

            //Kun eier av blog kan legge inn poster. Resten kan kun kommentere
            if (!isAuthorized.Succeeded && User.Identity == null && blog.Owner.Id != userManager.GetUserId(User)) {
                TempData["Feedback"] = "Ingen tilgang";
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = blogId });
                //return Forbid();
                //return Unauthorized();
            }

            List<Tag> tags = repository.GetAllTags().ToList();
            List<Tag> emptyList = new List<Tag>();
            PostViewModel postViewModel = new PostViewModel()
            {
                Tags = tags,
                AvailableTags = tags
            };
            return View(postViewModel);
        }

        // Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(int blogId, [Bind("PostText, Created, BlogId, Tags, AvailableTags, SelectedTags, Owner")] PostViewModel newPostViewModel)
        {
            Blog blog = repository.GetBlog(blogId);
            
            try {
                if (ModelState.IsValid) {
                    if (!blog.Closed)
                    {
                        //https://stackoverflow.com/questions/37778489/how-to-make-check-box-list-in-asp-net-mvc/37779070
                        var tagsStrings = string.Join(",", newPostViewModel.SelectedTags);   //"12,13,14"
                       
                        char[] delimiterChars = { ',' };
                        var tagsIdNumbers = tagsStrings.Split(delimiterChars).ToList();
                        
                        List<Tag> tagsList = new List<Tag>();

                        foreach (var idNumber in tagsIdNumbers)
                        {
                            tagsList.Add(repository.GetTag(Int32.Parse(idNumber)));
                        }
                        
                        var post = new Post()
                        {
                            PostText = newPostViewModel.PostText,
                            Created = DateTime.Now,
                            BlogId = blogId,
                            Tags = tagsList
                        };
                        repository.SavePost(post, User).Wait();

                        TempData["Feedback"] = $"{post.PostId} har blitt opprettet";
                        return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
                    } else {
                        TempData["Feedback"] = "Låst for endringer";
                        return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                TempData["Feedback"] = e;
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
            }
            TempData["Feedback"] = "Fikk ikke opprettet ny post";
            return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
        }

        // Post/Edit/#
        [HttpGet]
        public async Task<ActionResult> EditPost(int PostId)
        {
            if (PostId == 0)
            {
                return NotFound("Bad parameter");
            }
            var postToEdit = repository.GetPost(PostId);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, postToEdit, BlogOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang til post " + postToEdit.PostId;
                return Unauthorized();
            }

            return View(postToEdit);
        }

        // Post/Edit/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? PostId, [Bind("PostId, PostText, Created, Modified, BlogId, Owner")] Post postToEdit)
        {
            if (PostId == null) { return NotFound(); }

            Post post = repository.GetPost(postToEdit.PostId);
            Blog blog = repository.GetBlog(post.BlogId);
            post.Blog = blog;

            var isAuthorized = await authorizationService.AuthorizeAsync(User, post, BlogOperations.Update);

            if (!post.Blog.Closed && isAuthorized.Succeeded)
            {
                try {
                    if (ModelState.IsValid)
                    {
                        post.Modified = DateTime.Now;
                        post.Created = postToEdit.Created; 
                        post.PostText = postToEdit.PostText;

                        var result = await repository.UpdatePost(post, User);
                        if (result != null)
                        {
                            TempData["Feedback"] = string.Format("{0} is updated", post.PostText);
                            return RedirectToAction("ReadBlogPosts", "Blog", new { id = post.BlogId });
                        }
                    }
                    else return new ChallengeResult();
                } catch (Exception e) {
                    Console.Write(e);
                    TempData["Feedback"] = $"Not updated\n" + e;
                }
            }
            else
            {
                TempData["Feedback"] = "Kan ikke redigere post, den er låst";
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = post.BlogId });
            }
            return RedirectToAction("ReadBlogPosts", "Blog", new { id = post.BlogId });
        }

        // Post/Delete/#
        public async Task<ActionResult> DeletePost(int PostId)
        {
            var postToDelete = repository.GetPost(PostId);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, postToDelete, BlogOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang";
                return Unauthorized();
            }
            return View(postToDelete);
        }

        // Post/Delete/#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int PostId, IFormCollection collection)
        {
            var postToDelete = repository.GetPost(PostId);
            var blogId = postToDelete.BlogId;

            try
            {
                if (ModelState.IsValid)
                {
                    var blog = repository.GetBlog(blogId);

                    var isAuthorized = await authorizationService.AuthorizeAsync(User, blog, BlogOperations.Update);

                    if (!blog.Closed && isAuthorized.Succeeded)
                    {
                        repository.DeletePost(postToDelete, User).Wait();

                        TempData["Feedback"] = $"{postToDelete.PostText} has been updated";

                        return RedirectToAction("ReadBlogPosts", "Blog", new { id = blogId });
                    }
                    else
                    {
                        TempData["Feedback"] = "Kan ikke slette";
                        return RedirectToAction("ReadBlogPosts", "Blog", new { id = blogId });
                    }
                }
                else return new ChallengeResult();
            }
            catch (Exception e)
            {
                TempData["Feedback"] = e;
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = blogId });
            }
        }

        //TAGS CRUD OPERATIONS and VIEW------------------------------------------------------------------------

        [AllowAnonymous]
        public ActionResult FindPostsWithTag(int tagId, int blogId)
        {
            Blog blog = repository.GetBlog(blogId);
            List<Post> posts = repository.GetAllPostsInThisBlogWithThisTag(tagId, blogId).ToList();
            List<Tag> tagsForThisBlog = repository.GetAllTagsForBlog(blog.BlogId).ToList();

            if (ModelState.IsValid)
            {
                BlogViewModel blogViewModel = new BlogViewModel()
                {
                    BlogId = blog.BlogId,
                    Name = blog.Name,
                    Description = blog.Description,
                    Created = blog.Created,
                    Modified = blog.Modified,
                    Closed = blog.Closed,
                    Owner = blog.Owner,
                    Posts = posts,
                    Tags = tagsForThisBlog
                };
                return View(blogViewModel);
            }
            else
            {
                TempData["Feedback"] = "Feil ved søk, feil i Model: " + blog.BlogId;
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
            }
        }

        
        ////TODO
        ////FJERN aLT nedover
        ////COMMENT CRUD OPERATIONS------------------------------------------------------------------------

        //// Comment/Create
        //[HttpGet]
        //public ActionResult CreateComment(int PostId)
        //{
        //    var post = repository.GetPost(PostId);
        //    var blog = repository.GetBlog(post.BlogId);
        //    if (blog.Closed)
        //    {
        //        TempData["Feedback"] = "Blog steng for kommentarer: " + blog.BlogId;
        //        return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
        //    }
        //    return View();
        //}

        //// Comment/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateComment(int PostId, [Bind("CommentId, CommentText, Created, PostId, Owner")] CommentViewModel newCommentViewModel)
        //{
        //    try {
        //        if (ModelState.IsValid) 
        //        {
        //            var comment = new Comment()
        //            {
        //                CommentText = newCommentViewModel.CommentText,
        //                Created = DateTime.Now,
        //                PostId = PostId,
        //            };
        //            repository.SaveComment(comment, User).Wait();

        //            TempData["Feedback"] = $"{comment.PostId} har blitt opprettet";
        //            return RedirectToAction("ReadPostComments", "Blog", new { id = PostId });
        //        }
        //    }
        //    catch (Exception e) {
        //        Console.WriteLine(e);
        //        TempData["Feedback"] = "Feil kan ikke legge inn kommentar" + e;
        //        return RedirectToAction("ReadPostComments", "Blog", new { id = PostId });
        //    }
        //    return View();
        //}


        //// Comment/Edit/#
        //[HttpGet]
        //public async Task<ActionResult> EditComment(int id)
        //{
        //    var commentToEdit = repository.GetComment(id);

        //    var isAuthorized = await authorizationService.AuthorizeAsync(
        //        User, commentToEdit, BlogOperations.Update);

        //    if (!isAuthorized.Succeeded)
        //    {
        //        TempData["Feedback"] = "Ingen tilgang";
        //        return Forbid();
        //    }
        //    return View(commentToEdit);
        //}

       
        //// Comment/Edit/#
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditComment(int? id, [Bind("CommentId, CommentText, Created, Modified, PostId, Post")] Comment comment)
        //{
        //    if (id == null) { return NotFound(); }

        //    var postId = comment.PostId;
        //    var created = comment.Created;
        //    try {
        //        if (ModelState.IsValid) {
        //            comment.Modified = DateTime.Now;
        //            comment.Created = created;

        //            repository.UpdateComment(comment, User).Wait();

        //            TempData["Feedback"] = $"{comment.CommentText} has been updated";
        //            return RedirectToAction("ReadPostComments", "Blog", new { id = postId });
        //        }
        //        else return new ChallengeResult();
        //    } catch (Exception e) {
        //        Console.WriteLine(e.ToString());
        //        TempData["Feedback"] = "Fikk ikke endret kommentar, Feil: \n" + e;
        //        return RedirectToAction("ReadPostComments", "Blog", new { id = postId });
        //    }
        //}

        //// Comment/Delete/#
        //public async Task<ActionResult> DeleteComment(int id)
        //{
        //    var commentToDelete = repository.GetComment(id);

        //    var isAuthorized = await authorizationService.AuthorizeAsync(
        //        User, commentToDelete, BlogOperations.Delete);

        //    if (!isAuthorized.Succeeded)
        //    {
        //        TempData["Feedback"] = "Ingen tilgang";
        //        return Forbid();
        //    }
        //    return View(commentToDelete);
        //}

        //// Comment/Delete/#
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteComment(int id, IFormCollection collection)
        //{
        //    var commentToDelete = repository.GetComment(id);
        //    var postId = commentToDelete.PostId;

        //    try {
        //        if (ModelState.IsValid) {
        //            repository.DeleteComment(commentToDelete, User).Wait();

        //            TempData["Feedback"] = $"{commentToDelete.CommentText} has been updated";
        //            return RedirectToAction("ReadPostComments", "Blog", new { id = postId });
        //        }
        //        else return new ChallengeResult();
        //    } catch (Exception e) {
        //        TempData["Feedback"] = $"Comment has been updated" + e;
        //        return RedirectToAction("ReadPostComments", "Blog", new { id = postId });
        //    }
        //}
    }
}
