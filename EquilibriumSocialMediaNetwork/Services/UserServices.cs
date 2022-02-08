using System;
using System.Linq;
using Data;
using Data.Entities;

namespace Services
{
    public class UserServices : IUserServices
    {
        private EquilibriumDbContext database; 

        public UserServices(EquilibriumDbContext dbContext)
        {
            this.database = dbContext;
        }

        public void AddComment(Comment comment)
        {
            this.database.Add(comment);
            this.database.SaveChanges();
        }

        public void AddDescription(Description description)
        {
            this.database.Add(description);
            this.database.SaveChanges(); 
        }

        public void CreatePost(Post post)
        {
            this.database.Add(post);
            this.database.SaveChanges();
        }

        public void DeleteComment(string id)
        {
            Comment comment = this.database.Comments.FirstOrDefault(x => x.Id == id);
            this.database.Comments.Remove(comment);
            this.database.SaveChanges();
        }

        public void DeleteDescription(string id)
        {
            Description description = this.database.Descriptions.FirstOrDefault(x => x.Id == id);
            this.database.Remove(description);
            this.database.SaveChanges();
        }

        public void DeletePost(string id)
        {
            Post post = this.database.Posts.FirstOrDefault(x => x.Id == id);
            this.database.Remove(post);
            this.database.SaveChanges();
        }

        public void UpdateComment(Comment updateComment)
        {
            Comment comment = this.database.Comments.FirstOrDefault(x => x.Id == updateComment.Id);
            this.database.SaveChanges();
        }

        public void UpdateDescription(Description updateDescription)
        {
            Description description = this.database.Descriptions.FirstOrDefault(x => x.Id == updateDescription.Id);

            if (description == null)
            {
                description.Content = updateDescription.Content;
                this.database.SaveChanges();
            }
        }

        public void UpdatePost(Post updatePost)
        {
            Post post = this.database.Posts.FirstOrDefault(x => x.Id == updatePost.Id);

            if (post == null)
            {
                post.Content = updatePost.Content;
                this.database.SaveChanges();
            }
        }
    }
}
