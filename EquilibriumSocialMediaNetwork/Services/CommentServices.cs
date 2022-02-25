using Data;
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
    }
}
