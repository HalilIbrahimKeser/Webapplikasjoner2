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

        //Just for testing purposes https://localhost:44366/Comment/ShowComments
        public ActionResult ShowComments()
        {
            return View();
        }

        // GET: Comment/CreateComment/5
        [HttpGet]
        public ActionResult CreateComment(int PostId)
        {
            return View();
        }

        // POST: Comment/CreateComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(int PostId, [Bind("CommentId, Text, Created, PostId, Owner")] CommentViewModel newCommentViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                var comment = new Comment()
                {
                    CommentText = newCommentViewModel.CommentText,
                    Created = DateTime.Now,
                    PostId = PostId,
                };

                //fordi at det går an å kommentere på andre sine poster må man oppdatere PostViewModel som brukes i ReadPost

                _repository.SaveComment(comment, User).Wait();

                TempData["message"] = $"kommentaren har blitt opprettet";
                TempData["username"] = comment.Owner.UserName; //just for testing purposes. Used in ReadPost action methon in PostController.
                return RedirectToAction("ReadPostComments", "Blog", new { id = PostId });
            }
            catch
            {
                return View();
            }
        }

        // GET:
        // Post/Comment/EditComment/5
        [HttpGet]
        public async Task<ActionResult> EditComment(int CommentId)
        {
            var commentToEdit = _repository.GetComment(CommentId);

            var isAutorized = await _authorizationService.AuthorizeAsync(User, commentToEdit, BlogOperations.Update);
            if (!isAutorized.Succeeded)
            {
                return View("Ingentilgang");
            }

            return View(commentToEdit);
        }

        // POST:
        // Post/Comment/EditComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(int? CommentId, int PostId, [Bind("CommentId, Text, Created, Modified, PostId, Post, Owner")] Comment comment)
        {
            if (CommentId == null)
            {
                return NotFound();
            }
            //var postId = comment.PostId;
            try
            {
                if (!ModelState.IsValid) return new ChallengeResult();

                comment.Modified = DateTime.Now;
                _repository.UpdateComment(comment).Wait();
                TempData["message"] = $"{comment.CommentText} has been updated";

                return RedirectToAction("ReadPostComments", "Blog", new { id = PostId });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // GET:
        // Post/Comment/DeleteComment/5
        [HttpGet]
        public async Task<ActionResult> DeleteComment(int CommentId)
        {
            var commentToDelete = _repository.GetComment(CommentId);

            var isAutorized = await _authorizationService.AuthorizeAsync(User, commentToDelete, BlogOperations.Update);
            if (!isAutorized.Succeeded)
            {
                return View("Ingentilgang");
            }

            return View(commentToDelete);
        }
        // POST:
        // Post/Comment/DeleteComment/5
        [HttpPost/*, ActionName("DeleteComment")*/]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteComment(int CommentId, IFormCollection collection)
        {

            var commentToDelete = _repository.GetComment(CommentId);

            var isAutorized = await _authorizationService.AuthorizeAsync(User, commentToDelete, BlogOperations.Update);
            if (!isAutorized.Succeeded)
            {
                return View("Ingentilgang");
            }

            try
            {
                if (!ModelState.IsValid) return new ChallengeResult();
                //var owner = User;
                //var commentToDelete = _repository.GetComment(CommentId);
                var postId = commentToDelete.PostId;

                _repository.DeleteComment(commentToDelete).Wait();
                TempData["message"] = "Kommentaren er slettet";

                return RedirectToAction("ReadPostComments", "Blog", new { id = postId });

            }
            catch
            {
                return ViewBag("Fikk ikke slettet kommentar");
            }
        }
    }
}