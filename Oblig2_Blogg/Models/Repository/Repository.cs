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
        private UserManager<ApplicationUser> manager;
        private readonly IAuthorizationService authorizationService;

        //COSNTRUCTOR
        public Repository(ApplicationDbContext db, UserManager<ApplicationUser> userManager1 = null, 
            IAuthorizationService authorizationService1 = null)
        {
            this.db = db;
            this.manager = userManager1;
            this.authorizationService = authorizationService1;
            //SeedManyToMany_OnlyOneTime();
        }

        private void SeedManyToMany_OnlyOneTime()
        {
            ////TODO
            //var post1 = db.Posts()
            //var postQuery = from post in posts
            //    where post.BlogId == blogIdToGet
            //    orderby post.Created descending
            //    select post;


            //var post2 = new Post
            //{
            //    Title = "Denne posten tilhører kun taggen 'kaffe' ",
            //    Content = "kobles sammen med 'kaffe' ",
            //    BlogId = 1
            //};

            //_db.AddRange(
            //    new Tag
            //    {
            //        TagLabel = "suppe",
            //        Created = DateTime.Now,
            //        Posts = new List<Post> { post1 }
            //    },

            //    new Tag
            //    {
            //        TagLabel = "kaffe",
            //        Created = DateTime.Now,
            //        Posts = new List<Post> { post1, post2 }
            //    });

            //_db.SaveChanges();
        }


        //GET BLOGS
        public IEnumerable<Blog> GetAllBlogs() 
        {
           IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner);

           return blogs;
        }


        //GET BLOG
        public Blog GetBlog(int blogIdToGet)
        {
            IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner);
            var singleBlogQuery = from blog in blogs
                                  where blog.BlogId == blogIdToGet
                                  select blog;
            return singleBlogQuery.FirstOrDefault();
        }

        //GET POSTS
        public IEnumerable<Post> GetAllPosts(int blogIdToGet)
        {
            IEnumerable<Post> posts = db.Posts.Include(o => o.Owner);
            var postQuery = from post in posts
                                        where post.BlogId == blogIdToGet
                                        orderby post.Created descending
                                        select post; 
            return postQuery;
        }

        public IEnumerable<Post> GetAllPostsWhitBlog()
        {
            return db.Posts.Include(p => p.Blog).Include(p => p.BlogId);
        }

        //GET POST
        public Post GetPost(int postIdToGet)
        {
            return ((from post in db.Posts
                where post.PostId == postIdToGet
                     select post)).Include(o => o.Owner).FirstOrDefault();
        }

        //GET POSTVIEWMODEL
        public PostViewModel GetPostViewModel(int? id)
        {
            PostViewModel p;
            if (id == null)
            {
                p = new PostViewModel();
            }
            else
            {
                p = (db.Posts.Include(o => o.Comments).Include(o => o.Owner)
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
            IEnumerable<Comment> comments = db.Comments.Include(o => o.Owner);
            var commentsQuery = from comment in comments
                                            where comment.PostId == postIdToGet
                                            orderby comment.Created descending 
                                            select comment;
            return commentsQuery;
        }
        //GET COMMENT
        public Comment GetComment(int commentIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments.Include(o => o.Owner);
            var singleCommentQuery = from comment in comments
                                  where comment.CommentId == commentIdToGet
                                  select comment;
            return singleCommentQuery.FirstOrDefault();
        }


        //GET TAGS
        public IEnumerable<Tag> GetAllTagsForBlog(int BlogId)
        {
            IEnumerable<Blog> blogs = db.Blogs;
            IEnumerable<Post> posts = db.Posts.Include(p => p.Tags);

            List<Tag> tagsToShow = new List<Tag>();
            foreach (var tag in db.Tags.Include(a => a.Posts)) //Henter alle tags
            {
                foreach (var tagPost in tag.Posts)  //Går gjennom alle post inne i hver tag
                {
                    if (tagPost.BlogId == BlogId) //Legger i lista de som tilhører denne blogggen
                    {
                        tagsToShow.Add(tag); 
                    }
                }
            }
            return tagsToShow;
        }

        //TODO om vi skal ha søk av tag på Blog/Index liste opp alle tag og søke, så vise tilhørende poster
        //public GetAllTags()
        //{
        //    var tags = db..ToList();
        //    return tags;
        //}

        public IEnumerable<Post> GetAllPostsInThisBlogWithThisTag(int tagId, int blogId)
        {
            List<Post> posts = (from p in db.Posts.Include(p=>p.Tags)
                where p.BlogId == blogId
                select p).ToList();

            List<Post> postsToShow = new();

            foreach (var post in posts)
            {
                foreach (var postTags in post.Tags)
                {
                    if (postTags.TagId == tagId)
                    {
                        postsToShow.Add(post);
                    }
                }
            }
            return postsToShow;
        }
    



        //SAVE-----------------------------------------------------------------------
        //SAVE BLOG
        public async Task SaveBlog(Blog blog, IPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity.Name);
            blog.Owner = currentUser;

            db.Blogs.Add(blog);
            await db.SaveChangesAsync();
        }

        //SAVE POST
        public async Task SavePost(Post post, IPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity.Name);
            post.Owner = currentUser;

            Blog blog = (from b in db.Blogs
                where b.BlogId == post.BlogId
                select b).FirstOrDefault();

            if (currentUser.Id == blog.Owner.Id)
            {
                db.Posts.Add(post);
                await db.SaveChangesAsync();
            }
        }

        //SAVE COMMENT
        public async Task SaveComment(Comment comment, IPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity?.Name);
            comment.Owner = currentUser;

            db.Comments.Add(comment);
            await db.SaveChangesAsync();
        }



        //UPDATE / EDIT-----------------------------------------------------------------------
        //UPDATE BLOG
        public async Task UpdateBlog(Blog blog, IPrincipal principal)
        {
            db.Entry(blog).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
         
        //UPDATE POST
        public async Task<Post> UpdatePost(Post post1, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);

            Post post = post1;

            Blog blog = (from b in db.Blogs
                where b.BlogId == post.BlogId
                select b).FirstOrDefault();
            
            if (user.Id == blog.Owner.Id)
            {
                //db.Entry(post).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                db.Posts.Update(post);
                var updated = await db.SaveChangesAsync();
                if (updated > 0)
                {
                    return post;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //UPDATE COMMENT
        public async Task UpdateComment(Comment comment, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);

            if (user.Id == comment.Owner.Id)
            {
                db.Entry(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }


        //DELETE-----------------------------------------------------------------------
        //DELETE POST
        public async Task DeletePost(Post post, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);
            Post post1 = (from p in db.Posts
                where p.PostId == post.PostId
                          select p).FirstOrDefault();
            Blog blog = (from b in db.Blogs
                where b.BlogId == post1.BlogId
                select b).FirstOrDefault();

            if (user.Id == blog.Owner.Id)
            {
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
            }
        }
        //DELETE COMMENT
        public async Task DeleteComment(Comment comment, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);
            if (comment.Owner == user)
            {
                db.Comments.Remove(comment);
                await db.SaveChangesAsync();
            }
        }

   
    }
}
