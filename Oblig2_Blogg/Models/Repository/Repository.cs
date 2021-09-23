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
using Oblig2_Blogg.Data;

namespace Oblig2_Blogg.Models.Repository
{
    public class Repository : IRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;

        public Repository(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.db = db;
            this.manager = userManager;
        }

        //GETTERS
        public IEnumerable<Blog> GetAllBlogs()
        {
            IEnumerable<Blog> blogs = db.Blogs; 
            return blogs;
        }
        public Blog GetBlog(int blogIdToGet)
        {
            IEnumerable<Blog> blogs = db.Blogs;
            var singleBlogQuery = from blog in blogs
                                  where blog.BlogId == blogIdToGet
                                  select blog;
            return singleBlogQuery.FirstOrDefault();
        }

        public IEnumerable<Post> GetAllPosts(int blogIdToGet)
        {
            IEnumerable<Post> posts = db.Posts;
            var postQuery = from post in posts
                                        where post.BlogId == blogIdToGet
                                        orderby post.Created descending
                                        select post; 
            return postQuery;
        }
        public Post GetPost(int postIdToGet)
        {
            IEnumerable<Post> posts = db.Posts;
            var singlePostQuery = from post in posts
                            where post.PostId == postIdToGet
                            select post;
            return singlePostQuery.FirstOrDefault();
        }

     
        public IEnumerable<Comment> GetAllComments(int postIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments;
            var commentsQuery = from comment in comments
                                            where comment.PostId == postIdToGet
                                            orderby comment.Created descending 
                                            select comment;
            return commentsQuery;
        }

        public Comment GetComment(int commentIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments;
            var singleCommentQuery = from comment in comments
                                  where comment.PostId == commentIdToGet
                                  select comment;
            return singleCommentQuery.FirstOrDefault();
        }


        //EDIT / SAVE 

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

        [Authorize]
        public async void UpdateBlog(Blog blog, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            var blogToEdit = new Blog();
            blogToEdit.Name = blog.Name;
            blogToEdit.Description = blog.Description;
            blogToEdit.Created = blog.Created;
            blogToEdit.Modified = DateTime.Now;   //<----NB modified
            blogToEdit.Closed = blog.Closed;
            blogToEdit.Owner = currentUser.Result;

            db.Update(blogToEdit);
            db.SaveChanges();
        }


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


        //TODO update post

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

        //TODO update comment


    }
}
