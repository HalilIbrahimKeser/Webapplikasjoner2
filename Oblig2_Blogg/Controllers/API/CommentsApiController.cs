using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Data;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;

namespace Oblig2_Blogg.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repository;
        private UserManager<ApplicationUser> userManager;

        public CommentsApiController(ApplicationDbContext context, IRepository repository, UserManager<ApplicationUser> userManager1 = null)
        {
            this.context = context;
            this.repository = repository;
            userManager = userManager1;
        }

        //---------------------------GetComments--------------------------------------------------------

        // GET: api/CommentsApi
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await repository.GetAllComments();
        }

        [Produces(typeof(IEnumerable<Comment>))]
        [HttpGet("{postId:int}")]
        public async Task<IEnumerable<Comment>> GetComments([FromRoute] int postId)
        {
            var commentsOnPost = await repository.GetAllCommentsOnPost(postId);
            return commentsOnPost;
        }

        #region PutComment
        //---------------------------PutComment------------------------------------------------------------
        // PUT: api/CommentsApi/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromBody] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }
            try
            {
                await repository.UpdateComment(comment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region PostComment
        //---------------------------PostComment------------------------------------------------------------
        // POST: api/CommentsApi------------------------------------------------------------------------
        [HttpPost]
        //[AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Comment>> PostComment([FromBody] Comment comment)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var newComment = new Comment
            {
                CommentText = comment.CommentText, PostId = comment.PostId, Created = DateTime.Now, Owner = user,
            };
            if (await repository.SaveComment(newComment))
            {
                return Ok(newComment);
            }
            else
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region DeleteComment
        //---------------------------DeleteComment------------------------------------------------------------
        // DELETE: api/CommentsApi/5------------------------------------------------------------------------
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return context.Comments.Any(e => e.CommentId == id);
        }
        #endregion
    }
}