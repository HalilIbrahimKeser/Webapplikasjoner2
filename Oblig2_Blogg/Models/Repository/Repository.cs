using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Data;

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
        //GET COMMENTS
        public IEnumerable<Comment> GetAllComments(int postIdToGet)
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
        public async void SaveBlog(Blog blog, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            var blogToSave = new Blog();
            blogToSave.Name = blog.Name;
            blogToSave.Description = blog.Description;
            blogToSave.Created = DateTime.Now;  //<----NB created
            blogToSave.Closed = blog.Closed;
            blogToSave.Owner = currentUser.Result;

            db.Add(blogToSave);
            db.SaveChanges();
        }

        //UPDATE BLOG
        [Authorize]
        public async void UpdateBlog(Blog blog, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            blog.Modified = DateTime.Now;   //<----NB modified
            blog.Owner = currentUser.Result;

            db.Entry(blog).State = EntityState.Modified;
            db.SaveChanges();
        }

        //DELETE BLOG
        public void DeleteBlog(Blog blog, IPrincipal principal)
        {
            throw new NotImplementedException();
        }

        //SAVE POST
        [Authorize]
        public async void SavePost(Post post, Blog blog, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            var postToSave = new Post();
            postToSave.PostText = post.PostText;
            postToSave.Created = DateTime.Now;
            postToSave.BlogId = blog.BlogId;
            postToSave.Owner = currentUser.Result;

            db.Add(postToSave);
            db.SaveChanges();
        }

        //UPDATE POST
        public void UpdatePost(Post post, Blog blog, IPrincipal principal)
        {
            throw new NotImplementedException();
        }

        //DELETE POST
        public void DeletePost(Post post, Blog blog, IPrincipal principal)
        {
            throw new NotImplementedException();
        }


        //SAVE COMMENT
        [Authorize]
        public async void SaveComment(Comment comment, Post post, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            var commentToSave = new Comment();
            commentToSave.CommentText = comment.CommentText;
            commentToSave.Created = DateTime.Now;
            commentToSave.PostId = post.PostId;
            commentToSave.Owner = currentUser.Result;

            db.Add(commentToSave);
            db.SaveChanges();
        }

        //UPDATE COMMENT
        public void UpdateComment(Comment comment, Post post, IPrincipal principal)
        {
            throw new NotImplementedException();
        }

        //DELETE COMMENT
        public void DeleteComment(Comment comment, Post post, IPrincipal principal)
        {
            throw new NotImplementedException();

        }
    }
}
