﻿using Data;
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

        public List<PostServiceModel> GetAllPosts()
        {
            List<PostServiceModel> posts = db.Posts
                .Include(u => u.User)
                .Select(p => p.ToPostServiceModel())
                .ToList();

            foreach (PostServiceModel post in posts)
            {
                List <CommentServiceModel> comments = GetPostComments(post.Id);

                foreach (CommentServiceModel comment in comments)
                {
                    if (post.Comments.FirstOrDefault(c => c.Id == comment.Id) == null)
                    {
                        post.Comments.Add(comment);
                    }
                }
            }

            return posts;
        }

        public List<CommentServiceModel> GetPostComments(string postId)
        {
            List<CommentServiceModel> comments = db.Comments
                .Include(u => u.User)
                .Where(c => c.PostId == postId)
                .Select(c => c.ToCommentServiceModel())
                .ToList();

            return comments;
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

        public List<PostServiceModel> GetUserPosts(string userId)
        {
            List<PostServiceModel> posts = GetAllPosts()
                .Where(p => p.UserId == userId)
                .ToList();

            return posts;
        }
    }
}
