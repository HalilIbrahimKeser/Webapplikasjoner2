using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Models;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Oblig2_Blogg.Models.Repository;

namespace Oblig2_Blogg.Controllers
{
    public class CommentController : Controller
    {
        private readonly IRepository _repository;
        readonly IAuthorizationService _authorizationService;

        public CommentController(IRepository repository, IAuthorizationService authorizationService = null)
        {
            _repository = repository;
            _authorizationService = authorizationService;
        }

        //For å teste https://localhost:44375/Comment/ShowComments
        public ActionResult ShowComments()
        {
            return View();
        }


        //----------------Comment/CreateComment------------------------------------------------------------

        // COMMENT CRUD OPERATIONS
        
        // GET: Comment/CreateComment/5
        [HttpGet]
        public async Task<ActionResult> CreateComment(int PostId)
        {
            var post = _repository.GetPost(PostId);
            post.Blog = _repository.GetBlog(post.BlogId);

            var isAuthorized = await _authorizationService.AuthorizeAsync(
                User, post, BlogOperations.Create);


            if (post.Blog.Closed)
            {
                TempData["Feedback"] = "Blog steng for kommentarer: " + post.Blog.BlogId;
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = post.Blog.BlogId });
            }

            CommentViewModel commentViewModel = new()
            {
                Post = post,
                PostId = post.PostId
            };
            return View(commentViewModel);
        }

        // POST: Comment/CreateComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(int PostId, [Bind("CommentId, CommentText, Created, PostId")] CommentViewModel newCommentViewModel)
        {
            try
            {
                var post = _repository.GetPost(PostId);

                if (ModelState.IsValid)
                {
                    var comment = new Comment()
                    {
                        CommentText = newCommentViewModel.CommentText,
                        Created = DateTime.Now,
                        PostId = newCommentViewModel.PostId,
                        Post = post
                    };
                    _repository.SaveComment(comment, User).Wait();

                    TempData["Feedback"] = $"{comment.PostId} har blitt opprettet";
                    return RedirectToAction("ReadPostComments", "Blog", new { PostId = comment.PostId });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["Feedback"] = "Feil kan ikke legge inn kommentar" + e;
                return RedirectToAction("ReadPostComments", "Blog", new { PostId = newCommentViewModel.PostId });
            }
            return View();
        }

        //----------------Comment/EditComment-------------------------------------------

        // GET:
        // Post/Comment/EditComment/5
        [HttpGet]
        public async Task<ActionResult> EditComment(int CommentId)
        {
            var commentToEdit = _repository.GetComment(CommentId);

            var isAuthorized = await _authorizationService.AuthorizeAsync(
                User, commentToEdit, BlogOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingen tilgang";
                return Unauthorized();
            }
            return View(commentToEdit);
        }

        // POST:
        // Post/Comment/EditComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(int? CommentId, [Bind("CommentId, CommentText, Created, Modified, PostId, Post, Owner")] Comment comment)
        {
            if (CommentId == null)
            {
                return NotFound();
            }
            var commentToUpdate = _repository.GetComment(comment.CommentId);
            var postId = commentToUpdate.PostId;

            try
            {
                if (ModelState.IsValid)
                {
                    commentToUpdate.Modified = DateTime.Now;
                    commentToUpdate.CommentText = comment.CommentText;

                    _repository.UpdateComment(commentToUpdate, User).Wait();

                    TempData["Feedback"] = $"{commentToUpdate.CommentText} has been updated";
                    return RedirectToAction("ReadPostComments", "Blog", new { PostId = postId});
                } 
                else { return new ChallengeResult();}
            } 
            catch (Exception e) { 
                Console.WriteLine(e.ToString());
                TempData["Feedback"] = "Fikk ikke endret kommentar, Feil: \n" + e;
                return RedirectToAction("ReadPostComments", "Blog", new { PostId = postId});
            }
        }

        //----------------Comment/DeleteComment-------------------------------------------
        // GET:
        // Post/Comment/DeleteComment/5
        [HttpGet]
        public async Task<ActionResult> DeleteComment(int CommentId)
        {
            var commentToDelete = _repository.GetComment(CommentId);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, commentToDelete, BlogOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingentilgang";
                return Unauthorized();
            }

            return View(commentToDelete);
        }

        // POST:
        // Post/Comment/DeleteComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteComment(int CommentId, IFormCollection collection)
        {

            var commentToDelete = _repository.GetComment(CommentId);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, commentToDelete, BlogOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                TempData["Feedback"] = "Ingentilgang";
                return Unauthorized();
            }

            try {
                if (!ModelState.IsValid) return new ChallengeResult();
                
                var postId = commentToDelete.PostId;

                //TODO User?
                _repository.DeleteComment(commentToDelete, User).Wait();
                TempData["Feedback"] = "Kommentaren er slettet";

                return RedirectToAction("ReadPostComments", "Blog", new { PostId = postId });

            } 
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                TempData["Feedback"] = "Feil: " + e;
                return ViewBag("Fikk ikke slettet kommentar");
            }
        }
    }
}