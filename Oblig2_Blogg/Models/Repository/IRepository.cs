using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Oblig2_Blogg.Models.Entities;

namespace Oblig2_Blogg.Models.Repository
{
    public interface IRepository
    {
        IEnumerable<Blog> GetAllBlogs();
        Blog GetBlog(int blogIdToGet);

        void SaveBlog(Blog blog, IPrincipal principal);


        IEnumerable<Post> GetAllPosts(int blogIdToGet);
        Post GetPost(int postIdToGet);

        void SavePost(Post post, Blog blog, IPrincipal principal);



        IEnumerable<Comment> GetAllComments(int postIdToGet);
        Comment GetComment(int commentIdToGet);

        void SaveComment(Comment comment, Post post, IPrincipal principal);
    }
}
