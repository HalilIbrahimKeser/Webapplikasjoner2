using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oblig2_Blogg.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepository repository;
        private UserManager<ApplicationUser> userManager;
        private IAuthorizationService authService;

        //CONSTRUCTOR-----------------------------------------------
        
        public BlogController(IRepository repository, UserManager<ApplicationUser> userManager1 = null, IAuthorizationService authorizationService1 = null)
        {
            this.repository = repository;
            this.userManager = userManager1;
            this.authService = authorizationService1;
        }
        
        //VIEWS---------------------------------------------------

        //VIEW
        [AllowAnonymous]
        public ActionResult Index()
        {
            var blogs = repository.GetAllBlogs();
            var posts = repository.GetAllPostsWhitBlog();
            var tags = repository.GetAllTags();
            var comments = repository.GetAllComments();

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Blogs = blogs,
                Posts = posts,
                Tags = tags,
                Comments = comments
            };

            return View(indexViewModel);
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadBlogPosts(int? tagId, int id)
        {
            List<Post> posts = new List<Post>();
            if (tagId != null)
            {
                posts = repository.GetAllPostsInThisBlogWithThisTag((int)tagId, id).ToList();
            }
            else
            {
                posts = repository.GetAllPostsInBlog(id).ToList();
            }
           
            Blog blog = repository.GetBlog(id);
            List<Tag> tagsForThisBlog = repository.GetAllTagsForBlog(blog.BlogId).ToList();

            if (ModelState.IsValid)
            {
                BlogViewModel blogViewModel = new BlogViewModel()
                {
                    BlogId = id,
                    Name = blog.Name,
                    Description = blog.Description,
                    Created = blog.Created,
                    Modified = blog.Modified,
                    Closed = blog.Closed,
                    Owner = blog.Owner,
                    Posts = posts.ToList(),
                    Tags = tagsForThisBlog
                };
                return View(blogViewModel);
            }
            else
            {
                return View();
            }
        }


        //VIEW
        [AllowAnonymous]
        public ActionResult ReadPostComments(int PostId)
        {
            TempData["chosenId"] = PostId;
            var postViewModel = repository.GetPostViewModel(PostId);

            return View(postViewModel);
        }

        //BLOG CRUD OPERATIONS------------------------------------------------------------------------
        
        // Blog/Create
        [HttpGet]
        public ActionResult Create() { return View(); }

        // Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, Description, Created, Closed, Owner")] CreateBlogViewModel blogViewModel) 
        { 
            try {
                if (ModelState.IsValid) {
                    var blog = new Blog() {
                        Name = blogViewModel.Name,
                        Description = blogViewModel.Description,
                        Created = DateTime.Now,
                        Closed = blogViewModel.Closed,
                    };
                    repository.SaveBlog(blog, User).Wait();
                    TempData["Feedback"] = string.Format("{0} har blitt opprettet", blog.Name);
                    return RedirectToAction("Index", "Blog"); ;
                }
            } catch (Exception e)
            { Console.WriteLine(e);
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult SubscribeToBlog(int id)
        {
            var user =  userManager.GetUserAsync(User).Result;
            Blog blog = repository.GetBlog(id);

            BlogApplicationUser blogApplicationUser1 = new BlogApplicationUser();
            blogApplicationUser1.Owner = user;
            blogApplicationUser1.OwnerId = user.Id;
            blogApplicationUser1.Blog = blog;
            blogApplicationUser1.BlogId = blog.BlogId;

            repository.SubscribeToBlog(blogApplicationUser1);
            TempData["Feedback"] = string.Format("Bruker \"{0}\" er abonnert på blogg id: \"{1}\"", user.FirstName, blog.BlogId);
            
            return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        public ActionResult UnSubscribeToBlog(int id)
        {
            var user = userManager.GetUserAsync(User).Result;
            Blog blog1 = repository.GetBlog(id);
            BlogApplicationUser blogApplicationUser1 = repository.GetBlogApplicationUser(blog1, user);

            repository.UnSubscribeToBlog(blogApplicationUser1);
            TempData["Feedback"] = string.Format("Bruker \"{0}\" er ikke lenger abonnert på blogg id: \"{1}\"", user.FirstName, blog1.BlogId);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
