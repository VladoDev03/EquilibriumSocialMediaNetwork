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
