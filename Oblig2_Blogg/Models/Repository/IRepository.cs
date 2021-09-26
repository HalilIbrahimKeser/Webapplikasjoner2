using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Models.Repository
{
    public interface IRepository
    {
        IEnumerable<Blog> GetAllBlogs();
        Blog GetBlog(int blogIdToGet);
        Task SaveBlog(Blog blog, ClaimsPrincipal principal);
        Task UpdateBlog(Blog blog, ClaimsPrincipal principal);
        Task DeleteBlog(Blog blog, ClaimsPrincipal principal);


        IEnumerable<Post> GetAllPosts(int blogIdToGet);
        PostViewModel GetPostViewModel(int? id);
        Post GetPost(int postIdToGet);
        Task SavePost(Post post, ClaimsPrincipal principal);
        Task UpdatePost(Post post, ClaimsPrincipal principal);
        Task DeletePost(Post post, ClaimsPrincipal principal);


        IEnumerable<Comment> GetAllComments(int? postIdToGet);
        Comment GetComment(int commentIdToGet);
        Task SaveComment(Comment comment, ClaimsPrincipal principal);
        Task UpdateComment(Comment comment, ClaimsPrincipal principal);
        Task DeleteComment(Comment comment, ClaimsPrincipal principal);
    }
}
