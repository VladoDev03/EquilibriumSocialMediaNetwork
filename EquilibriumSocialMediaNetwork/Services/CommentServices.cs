using Data;
using Data.Entities;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentServices : ICommentServices
    {
        private EquilibriumDbContext db;

        public CommentServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public CommentServiceModel AddComment(PostServiceModel post, CommentServiceModel comment)
        {
            comment.TimeCommented = DateTime.Now;
            db.Comments.Add(comment.ToComment());

            db.SaveChanges();

            return comment;
        }

        public void DeleteComment(string id)
        {
            Comment comment = db.Comments.FirstOrDefault(x => x.Id == id);

            db.Comments.Remove(comment);

            db.SaveChanges();
        }

        public void DeleteUserComments(string id)
        {
            db.RemoveRange(GetUserComments(id));
            db.SaveChanges();
        }

        public List<CommentServiceModel> GetAllComments(string userId)
        {
            List<CommentServiceModel> comments = db.Comments
                .Select(c => c.ToCommentServiceModel())
                .ToList();

            return comments;
        }

        public List<CommentServiceModel> GetUserComments(string userId)
        {
            List<CommentServiceModel> comments = db.Comments
                   .Where(c => c.UserId == userId)
                   .Select(c => c.ToCommentServiceModel())
                   .ToList();

            return comments;
        }

        public CommentServiceModel UpdateComment(CommentServiceModel updatedComment)
        {
            Comment comment = db.Comments.FirstOrDefault(x => x.Id == updatedComment.Id);

            if (updatedComment.Content != null)
            {
                comment.Content = updatedComment.Content;
                db.SaveChanges();
            }

            return comment.ToCommentServiceModel();
        }
    }
}
