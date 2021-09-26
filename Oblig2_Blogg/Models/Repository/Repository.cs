using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Data;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Models.Repository
{
    public class Repository : IRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;

        //COSNTRUCTOR
        public Repository(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.db = db;
            this.manager = userManager;
        }

        //GET BLOGS
        public IEnumerable<Blog> GetAllBlogs()
        {
            IEnumerable<Blog> blogs = db.Blogs; 
            return blogs;
        }
        //GET BLOG
        public Blog GetBlog(int blogIdToGet)
        {
            IEnumerable<Blog> blogs = db.Blogs;
            var singleBlogQuery = from blog in blogs
                                  where blog.BlogId == blogIdToGet
                                  select blog;
            return singleBlogQuery.FirstOrDefault();
        }
        //GET POSTS
        public IEnumerable<Post> GetAllPosts(int blogIdToGet)
        {
            IEnumerable<Post> posts = db.Posts;
            var postQuery = from post in posts
                                        where post.BlogId == blogIdToGet
                                        orderby post.Created descending
                                        select post; 
            return postQuery;
        }
        //GET POST
        public Post GetPost(int postIdToGet)
        {
            IEnumerable<Post> posts = db.Posts;
            var singlePostQuery = from post in posts
                            where post.PostId == postIdToGet
                            select post;
            return singlePostQuery.FirstOrDefault();
        }
        public PostViewModel GetPostViewModel(int? id)
        {
            PostViewModel p;
            if (id == null)
            {
                p = new PostViewModel();
            }
            else
            {
                p = (db.Posts.Include(o => o.Comments)
                    .Where(o => o.PostId == id)
                    .Select(o => new PostViewModel()
                        {
                            PostId = o.PostId,
                            PostText = o.PostText,
                            Created = o.Created,
                            Modified = o.Modified,
                            BlogId = o.BlogId,
                            Comments = GetAllComments(id).ToList(),
                            Owner = o.Owner
                        }
                    ).FirstOrDefault());
            }
            return p;
        }
        //GET COMMENTS
        public IEnumerable<Comment> GetAllComments(int? postIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments;
            var commentsQuery = from comment in comments
                                            where comment.PostId == postIdToGet
                                            orderby comment.Created descending 
                                            select comment;
            return commentsQuery;
        }
        //GET COMMENT
        public Comment GetComment(int commentIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments;
            var singleCommentQuery = from comment in comments
                                  where comment.PostId == commentIdToGet
                                  select comment;
            return singleCommentQuery.FirstOrDefault();
        }

        //SAVE BLOG
        [Authorize]
        public async Task SaveBlog(Blog blog, ClaimsPrincipal user)
        {
            var currentUser = await manager.FindByNameAsync(user.Identity?.Name);

            blog.Owner = currentUser;

            db.Blogs.Add(blog);
            await db.SaveChangesAsync();
        }

        //SAVE POST
        [Authorize]
        public async Task SavePost(Post post, ClaimsPrincipal user)
        {
            var currentUser = await manager.FindByNameAsync(user.Identity?.Name);

            post.Owner = currentUser;

            db.Posts.Add(post);
            await db.SaveChangesAsync();
        }

        //SAVE COMMENT
        [Authorize]
        public async Task SaveComment(Comment comment, ClaimsPrincipal user)
        {
            var currentUser = await manager.FindByNameAsync(user.Identity?.Name);
            comment.Owner = currentUser;

            db.Comments.Add(comment);
            await db.SaveChangesAsync();
        }

        //UPDATE BLOG
        [Authorize]
        public async Task UpdateBlog(Blog blog, ClaimsPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            blog.Modified = DateTime.Now;   //<----NB modified
            blog.Owner = currentUser.Result;

            db.Entry(blog).State = EntityState.Modified;
            db.SaveChangesAsync();
        } 
        
        //UPDATE POST
        public async Task UpdatePost(Post post, ClaimsPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity?.Name);
            post.Modified = DateTime.Now;   //<----NB modified
            post.Owner = currentUser;

            db.Entry(post).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        //UPDATE COMMENT
        public async Task UpdateComment(Comment comment, ClaimsPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity?.Name);
            comment.Modified = DateTime.Now;   //<----NB modified
            comment.Owner = currentUser;

            db.Entry(comment).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }


        //DELETE BLOG
        public async Task DeleteBlog(Blog blog, ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        
        //DELETE POST
        public async Task DeletePost(Post post, ClaimsPrincipal principal)
        {
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
        }

    
        //DELETE COMMENT
        public async Task DeleteComment(Comment comment, ClaimsPrincipal principal)
        {
            db.Comments.Remove(comment);
            await db.SaveChangesAsync();

        }

    }
}
