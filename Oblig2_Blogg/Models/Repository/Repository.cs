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
            //SeedManyToMany_OnlyOneTime(); //kjøres kun en gang
        }

        // For å seede mange til mange relasjonen mellom Tag og Post. Kjøres kun en gang ved ny database.
        private void SeedManyToMany_OnlyOneTime()
        { 
            var post1 = new Post
            {
                PostText = "Sydney hadde kjempefin natur rundt byen og fine fjell. Vi tok oss en gåtur.",
                Created = DateTime.Now,
                BlogId = 1,
            };
            var post2 = new Post
            {
                PostText = "Melbourne på vei til Adelaide var et kjempefint sted. Vi kjørte gjennom ørkenen. Litt farglig vei",
                Created = DateTime.Now,
                BlogId = 1,
            };
            var post3 = new Post
            {
                PostText = "Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig. Vi måtte løpe.",
                Created = DateTime.Now,
                BlogId = 2,
            };
            var post4 = new Post
            {
                PostText = "Barna ble litt lei hotellet i Phuket. Da tok vi oss en båttur til Ko Khao Khat",
                Created = DateTime.Now,
                BlogId = 3,
            };

            List<Post> post = new List<Post>();
            db.AddRange(
                
                new Tag
                {
                    TagLabel = "Natur",
                    Created = DateTime.Now,
                    Posts = new List<Post> { post1 }
                },

                new Tag
                {
                    TagLabel = "Fjell",
                    Created = DateTime.Now,
                    Posts = new List<Post> { post1 }
                },
                new Tag
                {
                    TagLabel = "Ørken",
                    Created = DateTime.Now,
                    Posts = new List<Post> { post2 }
                },

                new Tag
                {
                    TagLabel = "Farlig",
                    Created = DateTime.Now,
                    Posts = new List<Post> { post2 }
                },
                
                new Tag
                 {
                     TagLabel = "Løping",
                     Created = DateTime.Now,
                     Posts = new List<Post> { post3 }
                 },

                new Tag
                 {
                     TagLabel = "Sykling",
                     Created = DateTime.Now,
                     Posts = new List<Post> { post3 }
                 },

                new Tag
                 {
                     TagLabel = "Gåtur",
                     Created = DateTime.Now,
                     Posts = new List<Post> { post1 }
                 });

            db.SaveChanges();
        }


        //GET BLOGS
        public IEnumerable<Entities.Blog> GetAllBlogs() 
        {
           IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner);
           return blogs;
        }


        //GET BLOG
        public Blog GetBlog(int blogIdToGet)
        {
            IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner).Include(b=>b.Posts);
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
            var postQuery = (from post in db.Posts
                where post.PostId == postIdToGet
                select post).Include(o => o.Owner).Include(o => o.Tags).Include(o => o.Comments);
            return postQuery.FirstOrDefault();
        }


        //GET POSTVIEWMODEL
        public PostViewModel GetPostViewModel(int? id)
        {
            List<Comment> comments = new();
            List<Tag> tags = new();
            if (id != null) {
                comments = GetAllComments(id).ToList();
                tags = GetTagsForPost(id).ToList();
            }
           
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
                            Comments = comments,
                            Tags = tags,
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

        
        public IEnumerable<Tag> GetTagsForPost(int? PostId) 
        {
            if (PostId == null) {
                return null;
            }
            IEnumerable<Post> posts = db.Posts.Include(p => p.Tags).Where(p => p.PostId == PostId);

            List<Tag> tagsForPost = new();

            foreach (var post in posts)
            {
                foreach (var tag in post.Tags)
                {
                    tagsForPost.Add(tag);
                } 
            }
            return tagsForPost;
        }

        public IEnumerable<Tag> GetAllTagsForBlog(int BlogId)
        {
            //IEnumerable<Blog> blogs = db.Blogs;
           // IEnumerable<Post> posts = db.Posts.Include(p => p.Tags);

            List<Tag> tagsToShow = new List<Tag>();
            foreach (var tag in db.Tags.Distinct().Include(a => a.Posts)) //Henter alle tags
            {
                foreach (var tagPost in tag.Posts.Distinct())  //Går gjennom alle post inne i hver tag
                {
                    if (tagPost.BlogId == BlogId) //Legger i lista de som tilhører denne blogggen
                    {
                        if (!tagsToShow.Contains(tag)) //Legg inn hver tag kun en gang
                        {
                            tagsToShow.Add(tag);
                        }
                    }
                }
            }
            return tagsToShow;
        }


        public IEnumerable<Tag> GetAllTags()
        {
            List<Tag> tags = db.Tags.Include(t => t.Posts).ToList();
            return tags;
        }

        public Tag GetTag(int tagIdToGet)
        {
            var tagQuery = (from tag in db.Tags
                                        where tag.TagId == tagIdToGet
                                        select tag).Include(o => o.Posts);
            return tagQuery.FirstOrDefault();
        }

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
                        if (!postsToShow.Contains(post)) //Legg inn hver post kun en gang
                        {
                            postsToShow.Add(post);
                        }
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

            if (currentUser.Id == post.Owner.Id)
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


        //SUBSCRIBE TO BLOG
        public async Task SubscribeToBlog(Blog blogToSubscribe, ApplicationUser userSubscriber)
        {
            Blog blog = blogToSubscribe;

            userSubscriber.SubscribedBlogs.Add(blog);

            db.Users.Update(userSubscriber);
            await db.SaveChangesAsync();
        }


        //UPDATE POST
        public async Task<Post> UpdatePost(Post post, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);

            if (user.Id == post.Owner.Id)
            {
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
            return post;
        }

        //UPDATE COMMENT
        public async Task UpdateComment(Comment comment, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);

            if (user == comment.Owner)
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


        //WEB API Functions---------------------------------
        public async Task<IEnumerable<Comment>> GetAllCommentsOnPost(int postIdToGet)
        {
            var post = await db.Posts.Include(c => c.Comments)
                .Include(p => p.Tags)
                .Include(p => p.Owner)
                .OrderByDescending(p => p.Created)
                .FirstAsync(p => p.PostId == postIdToGet);
            return post.Comments;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            IEnumerable<Comment> comments = await db.Comments.ToListAsync(); ;
            return comments;  
            //https://www.c-sharpcorner.com/UploadFile/ff2f08/entity-framework-and-asnotracking/
        }

        public async Task UpdateComment(Comment comment)
        {

            db.Entry(comment).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<bool> SaveComment(Comment comment)
        {
            db.Comments.Add(comment);
            return (await db.SaveChangesAsync() > 0);
        }


    }
}
