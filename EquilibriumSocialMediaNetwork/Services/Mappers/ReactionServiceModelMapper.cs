using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class ReactionServiceModelMapper
    {
        public static ReactionServiceModel ToReactionServiceModel(this Reaction reaction)
        {
            ReactionServiceModel result = new ReactionServiceModel()
            {
                Name = reaction.Name,
                User = reaction.User,
                UserId = reaction.UserId
            };

            return result;
        }

        public static Reaction ToReaction(this ReactionServiceModel reaction)
        {
            Reaction result = new Reaction()
            {
                Name = reaction.Name,
                User = reaction.User,
                UserId = reaction.UserId
            };

            return result;
        }
    }
}
