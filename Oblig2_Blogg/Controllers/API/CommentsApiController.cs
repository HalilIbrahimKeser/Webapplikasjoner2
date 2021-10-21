using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repo;


        public CommentsApiController(ApplicationDbContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/CommentsApi------------------------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _repo.GetAllComments();
        }

        [Produces(typeof(IEnumerable<Comment>))]
        [HttpGet("{postId:int}")]
        [AllowAnonymous]
        public async Task<IEnumerable<Comment>> GetComments([FromRoute] int postId)  //preferrably it should be IHttpActionResult....
        {
            var commentsOnPost = await _repo.GetAllCommentsOnPost(postId);
            return commentsOnPost; //....so it could return Ok(commentsOnPost)...also simplifies unit testing.
        }

        // GET: api/CommentsApi/5------------------------------------------------------------------------
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Comment>> GetComment(int id)
        //{
        //    var comment = await _context.Comments.FindAsync(id);

        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return comment;
        //}

        // PUT: api/CommentsApi/5------------------------------------------------------------------------
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromBody] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            //_context.Entry(comment).State = EntityState.Modified;


            try
            {
                await _repo.UpdateComment(comment)/*.Wait()*/;
                //await _context.SaveChangesAsync();
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

            return NoContent(); //StatusCode 204
        }

        // POST: api/CommentsApi------------------------------------------------------------------------
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous] //must be removed. User must be logged in
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Comment>> PostComment([FromBody] Comment comment)
        {
            // Create new comment object containing required fields, ref createmethod mvc.
            var newComment = new Comment
            {
                CommentText = comment.CommentText,
                PostId = comment.PostId,
                Created = DateTime.Now,
            };

            await _repo.SaveComment(newComment); //must include User later

            //return StatusCode(201);
            return CreatedAtAction(nameof(GetComments), new { id = newComment.CommentId });
            //return CreatedAtAction(nameof(GetSingleComment), new {id = newComment.CommentId} ,newComment); //with route specified

            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio#prevent-over-posting-1
        }



        // DELETE: api/CommentsApi/5------------------------------------------------------------------------
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
}
