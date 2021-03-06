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
        public Repository(ApplicationDbContext db, UserManager<ApplicationUser> userManager1 = null)
        {
            this.db = db;
            this.manager = userManager1;
            //SeedManyToMany_OnlyOneTime(); //kjøres kun en gang
        }

       
        private void SeedManyToMany_OnlyOneTime()
        {
            // For å seede mange til mange relasjonen mellom Tag og Post. Kjøres kun en gang ved ny database.
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

        //GET----------------------------------------------------------------------------------------------------------------------------------------

        public IndexViewModel GetIndexViewModell()
        {
            //For bruk i test metode
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Blogs = new List<Blog>{new() {BlogId = 1, Name = "Australia", Closed = false}},
                Posts = new List<Post>{ new() {PostId = 1, BlogId = 1, PostText = "Fint tur"}},
                Tags = new List<Tag>{new() {TagId = 1, TagLabel = "Natur"}},
                Comments = new List<Comment>{new() {CommentId = 1, PostId = 1, CommentText = "Så fint"}}
            };

            return indexViewModel;
        }

        //GET BLOGS
        public IEnumerable<Blog> GetAllBlogs() 
        {
           IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner).Include(o => o.BlogApplicationUsers);
           return blogs;
        }

        public IEnumerable<Blog> GetAllLastBlogs()
        {
            IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner).Include(o => o.BlogApplicationUsers)
                .Take(10).OrderByDescending(p=>p.Modified);
            return blogs;
        }

        public IEnumerable<Blog> GetAllSubscribedBlogs(ApplicationUser userSubscriber)
        {
            var currentUser = userSubscriber;
            IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner).Include(o => o.BlogApplicationUsers)
                .OrderByDescending(p => p.Modified);

            List<Blog> blogList = new List<Blog>();
            
            foreach (var blog in blogs)
            {
                foreach (var applicationUser in blog.BlogApplicationUsers)
                {
                    if (applicationUser.OwnerId == currentUser.Id)
                    {
                        blogList.Add(blog);
                    }
                }
            }
            return blogList;
        }

        //GET BLOG
        public Blog GetBlog(int blogIdToGet)
        {
            IEnumerable<Blog> blogs = db.Blogs.Include(o => o.Owner).Include(b => b.Posts)
                .Include(b => b.BlogApplicationUsers);
            var singleBlogQuery = blogs.Where(blog => blog.BlogId == blogIdToGet);
            return singleBlogQuery.FirstOrDefault();
        }


        //SUBSCRIBE TO BLOG
        public BlogApplicationUser GetBlogApplicationUser(Blog blogToSubscribe, ApplicationUser userSubscriber)
        {
            var blogApplicationUser = db.BlogApplicationUser
                .Include(b => b.Owner)
                .Include(b => b.Blog)
                .Where(bu => bu.Owner == userSubscriber).Where(bu => bu.Blog == blogToSubscribe);
            return blogApplicationUser.FirstOrDefault();
        }
        public async Task SubscribeToBlog(BlogApplicationUser userSubscriber1)
        {
            db.BlogApplicationUser.AddRange(userSubscriber1);
            await db.SaveChangesAsync();
        }
        public async Task UnSubscribeToBlog(BlogApplicationUser userSubscriber1)
        {
            db.BlogApplicationUser.RemoveRange(userSubscriber1);
            await db.SaveChangesAsync();
            return;
        }
        

        //GET POSTS
        public IEnumerable<Post> GetAllPostsInBlog(int blogIdToGet)
        {
            IEnumerable<Post> posts = db.Posts.Include(o => o.Owner);
            var postQuery = posts.Where(post => post.BlogId == blogIdToGet).OrderByDescending(post => post.Created); 
            return postQuery;
        }

        public IEnumerable<Post> GetAllPostsWhitBlog()
        {
            return db.Posts.Include(p => p.Blog).Include(p => p.Owner);
        }
        
        public IEnumerable<Post> GetAllLastPostsWhitBlog()
        {
            return db.Posts.Include(p => p.Blog).Include(p => p.Owner)
                .Take(10).OrderByDescending(p => p.Created); 
        }

        //GET POST
        public Post GetPost(int postIdToGet)
        {
            var postQuery = (db.Posts.Where(post => post.PostId == postIdToGet)).Include(o => o.Owner)
                .Include(o => o.Tags).Include(o => o.Comments);
            return postQuery.FirstOrDefault();
        }


        //GET POSTVIEWMODEL
        public PostViewModel GetPostViewModel(int? id)
        {
            List<Comment> comments = new();
            List<Tag> tags = new();
            if (id != null)
            {
                comments = GetAllPostComments(id).ToList();
                tags = GetTagsForPost(id).ToList();
            }

            PostViewModel p;
            if (id == null)
            {
                p = new PostViewModel();
            }
            else
            {
                p = (db.Posts.Include(o => o.Comments).Include(o => o.Owner).Include(o => o.Tags)
                    .Where(o => o.PostId == id).Select(o => new PostViewModel()
                    {
                        PostId = o.PostId,
                        PostText = o.PostText,
                        Created = o.Created,
                        Modified = o.Modified,
                        BlogId = o.BlogId,
                        Comments = comments,
                        Tags = tags,
                        Owner = o.Owner
                    }).FirstOrDefault());
            }

            return p;
        }


        //GET COMMENTS
        public IEnumerable<Comment> GetAllComments()
        {
            IEnumerable<Comment> comments = db.Comments.Include(o => o.Owner)
                .OrderByDescending(comment => comment.Created);
            return comments;
        }

        //GET COMMENTS WITH POST ID
        public IEnumerable<Comment> GetAllPostComments(int? postIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments.Include(o => o.Owner)
                .Where(comment => comment.PostId == postIdToGet)
                .OrderByDescending(comment => comment.Created);
            return comments;
        }

        //GET COMMENT
        public Comment GetComment(int commentIdToGet)
        {
            IEnumerable<Comment> comments = db.Comments.Include(o => o.Owner);
            var singleCommentQuery = comments.Where(comment => comment.CommentId == commentIdToGet);
            return singleCommentQuery.FirstOrDefault();
        }

        //GET TAGS

        public IEnumerable<Tag> GetTagsForPost(int? PostId) 
        {
            if (PostId == null)
            {
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

        //GET ALL TAGS FOR BLOG
        public IEnumerable<Tag> GetAllTagsForBlog(int BlogId)
        {
            List<Tag> tagsToShow = new List<Tag>();
            foreach (var tag in db.Tags.Distinct().Include(a => a.Posts)) //Henter alle tags
            {
                foreach (var tagPost in tag.Posts.Distinct()) //Går gjennom alle post inne i hver tag
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

        //GET ALL TAGS
        public IEnumerable<Tag> GetAllTags()
        {
            List<Tag> tags = db.Tags.Include(t => t.Posts).ToList();
            return tags;
        }

        //GET TAG
        public Tag GetTag(int tagIdToGet)
        {
            var tagQuery = (db.Tags.Where(tag => tag.TagId == tagIdToGet)).Include(o => o.Posts);
            return tagQuery.FirstOrDefault();
        }

        //GET ALL POST FOR THIS BLOG WITH THIS TAG
        public IEnumerable<Post> GetAllPostsInThisBlogWithThisTag(int tagId, int blogId)
        {
            List<Post> posts = (from p in db.Posts.Include(p => p.Tags) where p.BlogId == blogId select p).ToList();
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

        //SAVE------------------------------------------------------------------------------------------------------------------------

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
            //if (currentUser.Id == post.Owner.Id)
            //{
                db.Posts.Add(post);
                await db.SaveChangesAsync();
            //}
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

        //DELETE--------------------------------------------------------------------------------------------------

        //DELETE POST
        public async Task DeletePost(Post post, IPrincipal principal)
        {
            var user = await manager.FindByEmailAsync(principal.Identity.Name);
            Post post1 = (from p in db.Posts where p.PostId == post.PostId select p).FirstOrDefault();
            Blog blog = (from b in db.Blogs where b.BlogId == post1.BlogId select b).FirstOrDefault();
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
            var post = await db.Posts.Include(c => c.Comments).Include(p => p.Tags).Include(p => p.Owner)
                .OrderByDescending(p => p.Created).FirstAsync(p => p.PostId == postIdToGet);
            return post.Comments.OrderByDescending(p => p.Created).ToList();
        }

        public async Task<IEnumerable<Comment>> GetAllPostComments()
        {
            IEnumerable<Comment> comments = await db.Comments.Include(p => p.Owner).ToListAsync();
            ;
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
