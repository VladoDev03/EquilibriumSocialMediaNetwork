using System;
using Data.Entities;

namespace Services
{
    public interface IUserServices
    {
        void CreatePost(Post post);

        void UpdatePost(Post updatePost);

        void DeletePost(int id);

        void AddDescription(Description description);

        void UpdateDescription(Description updateDescription);

        void DeleteDescription(int id);

        void AddComment(Comment comment);

        void UpdateComment(Comment updateComment);

        void DeleteComment(int id);
    }
}
