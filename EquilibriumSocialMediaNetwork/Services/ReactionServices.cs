using Data;
using Microsoft.EntityFrameworkCore;
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
    public class ReactionServices : IReactionServices
    {
        private EquilibriumDbContext db;

        public ReactionServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public ReactionServiceModel AddReaction(ReactionServiceModel reaction)
        {
            db.Reactions.Add(reaction.ToReaction());

            db.SaveChanges();

            return reaction;
        }

        public List<ReactionServiceModel> GetPostReactions(string postId)
        {
            List<ReactionServiceModel> reactions = db.Reactions
                .Include(r => r.Post)
                .Include(r => r.User)
                .Where(r => r.PostId == postId)
                .Select(r => r.ToReactionServiceModel())
                .ToList();

            return reactions;
        }
    }
}
