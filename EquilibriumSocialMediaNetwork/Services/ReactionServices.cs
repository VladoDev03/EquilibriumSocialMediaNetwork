using Data;
using Data.Entities;
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
            Reaction oldReaction = db.Reactions
                .FirstOrDefault(r => r.UserId == reaction.UserId
                    && r.PostId == reaction.PostId
                    && r.Name != reaction.Name);

            if (oldReaction != null)
            {
                oldReaction.Name = reaction.Name;
            }
            else
            {
                db.Reactions.Add(reaction.ToReaction());
            }

            db.SaveChanges();

            return reaction;
        }

        public void DeletePostReactions(string postId)
        {
            List<Reaction> reactions = db.Reactions
                .Where(r => r.PostId == postId)
                .ToList();

            db.RemoveRange(reactions);
            db.SaveChanges();
        }

        public void DeleteUserReactions(string userId)
        {
            List<Reaction> reactions = db.Reactions
                   .Where(r => r.UserId == userId)
                   .ToList();

            db.RemoveRange(reactions);
            db.SaveChanges();
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
