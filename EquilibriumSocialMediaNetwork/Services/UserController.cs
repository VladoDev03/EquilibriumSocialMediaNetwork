using System;
using Data.Entities;

namespace Services
{
    public class UserController
    {
        private UserServices userServices;

        private void CreatePost()
        {
            string content = Console.ReadLine();

            Post post = new Post();
            this.userServices.CreatePost(post);
        }

        private void UpdatePost()
        {
            string idPost = Console.ReadLine();

            Post post = new Post();
            this.userServices.UpdatePost(post);
        }

        private void DeletePost()
        {
            string idPost = Console.ReadLine();

            this.userServices.DeletePost(idPost);
        }

        private void AddDescription()
        {
            string content = Console.ReadLine();

            Description description = new Description();
            this.userServices.AddDescription(description);
        }
        
        private void UpdateDescription()
        {
            string idDescription = Console.ReadLine();

            Description description = new Description();
            this.userServices.UpdateDescription(description);
        }
        private void DeleteDescription()
        {
            string idDescription = Console.ReadLine();

            this.userServices.DeleteDescription(idDescription);
        }

        private void AddComment()
        {
            string content = Console.ReadLine();

            Comment comment = new Comment();
            this.userServices.AddComment(comment);
        }

        private void UpdateComment()
        {
            string idComment = Console.ReadLine();

            Comment comment = new Comment();
            this.userServices.UpdateComment(comment);
        }
        private void DeleteComment()
        {
            string idComment = Console.ReadLine();

            this.userServices.DeleteComment(idComment);
        }
    }
}
