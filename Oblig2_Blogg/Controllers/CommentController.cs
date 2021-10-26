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
        public ActionResult CreateComment(int PostId)
        {
            var post = _repository.GetPost(PostId);
            var blog = _repository.GetBlog(post.BlogId);
            if (blog.Closed)
            {
                TempData["Feedback"] = "Blog steng for kommentarer: " + blog.BlogId;
                return RedirectToAction("ReadBlogPosts", "Blog", new { id = blog.BlogId });
            }
            return View();
        }

        // POST: Comment/CreateComment/5
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
                    _repository.SaveComment(comment, User).Wait();

                    TempData["Feedback"] = $"{comment.PostId} har blitt opprettet";
                    return RedirectToAction("ReadPostComments", "Blog", new { id = PostId });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["Feedback"] = "Feil kan ikke legge inn kommentar" + e;
                return RedirectToAction("ReadPostComments", "Blog", new { id = PostId });
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
            var postId = comment.PostId;
            var created = comment.Created;

            try
            {
                if (ModelState.IsValid)
                {
                    comment.Modified = DateTime.Now;
                    comment.Created = created;

                    _repository.UpdateComment(comment, User).Wait();

                    TempData["Feedback"] = $"{comment.CommentText} has been updated";
                    return RedirectToAction("ReadPostComments", "Blog", new {id = postId});
                } 
                else { return new ChallengeResult();}
            } 
            catch (Exception e) { 
                Console.WriteLine(e.ToString());
                TempData["Feedback"] = "Fikk ikke endret kommentar, Feil: \n" + e;
                return RedirectToAction("ReadPostComments", "Blog", new {id = postId});
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

                return RedirectToAction("ReadPostComments", "Blog", new { id = postId });

            } 
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                TempData["Feedback"] = "Feil: " + e;
                return ViewBag("Fikk ikke slettet kommentar");
            }
        }
    }
}