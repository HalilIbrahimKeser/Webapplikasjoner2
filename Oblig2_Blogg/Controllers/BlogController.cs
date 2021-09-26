using System;
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
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IRepository repository;
        //private UserManager<IdentityUser> manager;
        IAuthorizationService _authorizationService;

        //CONSTRUCTOR
        public BlogController(IRepository repository, IAuthorizationService authorizationService)
        {
            this.repository = repository;
            //this.manager = manager;
            _authorizationService = authorizationService;
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repository.GetAllBlogs());
        }

        //VIEW
        [AllowAnonymous]
        public ActionResult ReadBlog(int id)
        {
            var blog = repository.GetBlog(id);
            var posts = repository.GetAllPosts(id);

            var blogViewModel = new BlogViewModel()
            {
                BlogId = id, Name = blog.Name, 
                Description = blog.Description,
                Created = blog.Created,
                Modified = blog.Modified,
                Closed = blog.Closed,
                Owner = blog.Owner,
                Posts = posts.ToList()
            };
            return View(blogViewModel);
        }
        //VIEW
        [AllowAnonymous]
        public ActionResult ReadPost(int id)
        {
            var postViewModel = repository.GetPostViewModel(id);

            return View(postViewModel);
        }

        // GET
        // Blog/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST
        // Blog/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, Description, Created, Closed, Owner")] CreateBlogViewModel blogViewModel) 
        { 
            try 
            {
                if (ModelState.IsValid)
                {
                    var blog = new Blog()
                    {
                        Name = blogViewModel.Name,
                        Description = blogViewModel.Description,
                        Created = blogViewModel.Created,
                        Closed = blogViewModel.Closed,
                        Owner = blogViewModel.Owner
                    };

                    repository.SaveBlog(blog, User).Wait();
                    TempData["message"] = string.Format("{0} har blitt opprettet", blog.Name);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
            return View();
        }

        // GET:
        // Post/Edit/5
        public async Task<ActionResult> EditPost(int id)
        {
            var postToEdit = repository.GetPost(id);

            var isAutorized = await _authorizationService.AuthorizeAsync(User, postToEdit, BlogOperations.Update);
            if (!isAutorized.Succeeded)
            {
                return View("Ingen tilgang");
            }

            return View(postToEdit);
        }

        // POST:
        // Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? BlogId, [Bind("PostId, PostText, Modified, BlogId, Owner")]Post post)
        {
            if (BlogId == null)
            {
                return NotFound();
            }

            try {
                if (ModelState.IsValid) {
                    post.Modified = DateTime.Now;
                    var owner = User;

                    repository.UpdatePost(post, User);

                    TempData["message"] = $"{post.PostText} has been updated";

                    return RedirectToAction(nameof(ReadPost));
                } else return new ChallengeResult();
            } catch {
                return View(post);
            }
        }

        // GET:
        // BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST:
        // BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET post
        [Authorize]
        [HttpGet]
        public ActionResult CreatePost(int BlogId)
        {
            return View();
        }

        //POST post: Blog/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(int BlogId,/*[Bind("Title, Content, Created, Modified, NumberOfComments")]*/ Post newPost)
        {
            try
            {
                if (!ModelState.IsValid) { return View(); }

                newPost.BlogId = BlogId;
                newPost.Created = DateTime.Now;

                repository.SavePost(newPost, User);

                TempData["message"] = $"{newPost.PostId} har blitt opprettet";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
