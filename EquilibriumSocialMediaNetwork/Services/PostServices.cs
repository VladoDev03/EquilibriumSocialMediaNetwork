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
    public class PostServices : IPostServices
    {
        private EquilibriumDbContext db;

        public PostServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public PostServiceModel AddPost(PostServiceModel post)
        {
            throw new NotImplementedException();
        }

        public List<PostServiceModel> GetAllPosts(PostServiceModel post)
        {
            List<PostServiceModel> posts = db.Posts
                .Select(p => p.ToPostServiceModel())
                .ToList();

            return posts;
        }

        public PostServiceModel GetPostById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
