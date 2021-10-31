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
        //USER
        Task SubscribeToBlog(BlogApplicationUser subscriber); 
        Task UnSubscribeToBlog(BlogApplicationUser subscriber);
        BlogApplicationUser GetBlogApplicationUser(Blog blogToSubscribe, ApplicationUser userSubscriber);

         //BLOGS
        IEnumerable<Blog> GetAllBlogs();
        IEnumerable<Blog> GetAllLastBlogs();
        Blog GetBlog(int blogIdToGet);
        Task SaveBlog(Blog blog, IPrincipal principal);
        IEnumerable<Blog> GetAllSubscribedBlogs(ApplicationUser userSubscriber);
        IndexViewModel GetIndexViewModell();

        //POSTS
        IEnumerable<Post> GetAllPostsWhitBlog();
        IEnumerable<Post> GetAllLastPostsWhitBlog();
        IEnumerable<Post> GetAllPostsInBlog(int blogIdToGet);
        PostViewModel GetPostViewModel(int? id);
        Post GetPost(int postIdToGet);
        Task SavePost(Post post, IPrincipal principal);
        Task<Post> UpdatePost(Post post, IPrincipal principal);
        Task DeletePost(Post post, IPrincipal principal);

        //COMMENTS
        IEnumerable<Comment> GetAllPostComments(int? postIdToGet);
        IEnumerable<Comment> GetAllComments();
        Comment GetComment(int commentIdToGet);
        Task SaveComment(Comment comment, IPrincipal principal);
        Task UpdateComment(Comment comment, IPrincipal principal);
        Task DeleteComment(Comment comment, IPrincipal principal);

        //TAGS
        IEnumerable<Post> GetAllPostsInThisBlogWithThisTag(int tagId, int blogId);
        IEnumerable<Tag> GetAllTagsForBlog(int BlogId);
        IEnumerable<Tag> GetAllTags();
        IEnumerable<Tag> GetTagsForPost(int? PostId);
        Tag GetTag(int tagIdToGet);

        //WEB API
        Task<IEnumerable<Comment>> GetAllCommentsOnPost(int postIdToGet);
        Task<IEnumerable<Comment>> GetAllPostComments();
        Task UpdateComment(Comment comment);
        Task<bool> SaveComment(Comment comment);
    }
}
