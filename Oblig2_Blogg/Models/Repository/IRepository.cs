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
        /*Task<IEnumerable<Blog>> GetAllBlogs();*/
        Blog GetBlog(int blogIdToGet);
        Task SaveBlog(Blog blog, IPrincipal principal);


        IEnumerable<Post> GetAllPostsWhitBlog();
        IEnumerable<Post> GetAllPosts(int blogIdToGet);
        PostViewModel GetPostViewModel(int? id);
        Post GetPost(int postIdToGet);
        Task SavePost(Post post, IPrincipal principal);
        Task<Post> UpdatePost(Post post, IPrincipal principal);
        Task DeletePost(Post post, IPrincipal principal);


        IEnumerable<Comment> GetAllComments(int? postIdToGet);
        Comment GetComment(int commentIdToGet);
        Task SaveComment(Comment comment, IPrincipal principal);
        Task UpdateComment(Comment comment, IPrincipal principal);
        Task DeleteComment(Comment comment, IPrincipal principal);
    }
}
