﻿using Data;
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
            db.Posts.Add(post.ToPost());

            db.SaveChanges();

            return post;
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
            PostServiceModel post = db.Posts.FirstOrDefault(p => p.Id == id)
                .ToPostServiceModel();

            return post;
        }

        public void DeletePost(string id)
        {
            PostServiceModel post = GetPostById(id);

            db.Posts.Remove(post.ToPost());

            db.SaveChanges();
        }
    }
}
