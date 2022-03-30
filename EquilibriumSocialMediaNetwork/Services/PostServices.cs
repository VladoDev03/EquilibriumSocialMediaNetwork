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
    public class PostServices : IPostServices
    {
        private EquilibriumDbContext db;

        public PostServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public PostServiceModel AddPost(PostServiceModel post)
        {
            post.TimePosted = DateTime.Now;
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
                GetPostComments(post);
                GetPostReactions(post); 
            }

            posts = posts.OrderByDescending(p => p.TimePosted).ToList();

            return posts;
        }

        public List<CommentServiceModel> GetPostComments(PostServiceModel post)
        {
            List<CommentServiceModel> comments = db.Comments
                .Include(u => u.User)
                .Where(c => c.PostId == post.Id)
                .Select(c => c.ToCommentServiceModel())
                .ToList();

            foreach (CommentServiceModel comment in comments)
            {
                if (post.Comments.FirstOrDefault(c => c.Id == comment.Id) == null)
                {
                    post.Comments.Add(comment);
                }
            }

            comments = comments.OrderBy(c => c.TimeCommented).ToList();

            return comments;
        }

        public List<ReactionServiceModel> GetPostReactions(PostServiceModel post)
        {
            List<ReactionServiceModel> reactions = db.Reactions
                .Include(u => u.User)
                .Where(c => c.PostId == post.Id)
                .Select(c => c.ToReactionServiceModel())
                .ToList();

            foreach (ReactionServiceModel reaction in reactions)
            {
                if (post.Reactions.FirstOrDefault(r => r.Id == reaction.Id) == null)
                {
                    post.Reactions.Add(reaction);
                }
            }

            return reactions;
        }

        public PostServiceModel GetPostById(string id)
        {
            PostServiceModel post = db.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id)
                .ToPostServiceModel();

            return post;
        }

        public void DeletePost(string id)
        {
            DeletePostComments(id);

            //Post post = GetPostById(id).ToPost();

            Post post = db.Posts.FirstOrDefault(p => p.Id == id);

            db.Posts.Remove(post);

            db.SaveChanges();
        }

        public void DeletePostComments(string id)
        {
            //List<Comment> commentsToRemove = GetPostComments(id)
            //    .Select(c => c.ToComment());

            List<Comment> commentsToRemove = db.Comments
                .Where(c => c.PostId == id)
                .ToList();

            List<Reaction> reactionsToRemove = db.Reactions
                .Where(r => r.PostId == id)
                .ToList();

            db.Comments.RemoveRange(commentsToRemove);
            db.Reactions.RemoveRange(reactionsToRemove);

            db.SaveChanges();
        }

        public List<PostServiceModel> GetUserPosts(string userId)
        {
            List<PostServiceModel> posts = db.Posts
                .Where(p => p.UserId == userId)
                .Select(p => p.ToPostServiceModel())
                .ToList();

            return posts;
        }

        public PostServiceModel UpdatePost(PostServiceModel updatedPost)
        {
            Post post = db.Posts.FirstOrDefault(x => x.Id == updatedPost.Id);

            if (updatedPost.Content != null)
            {
                post.Content = updatedPost.Content;
                db.SaveChanges();
            }

            return post.ToPostServiceModel();
        }

        public List<PostServiceModel> GetPostsForUser(string userId)
        {
            string[] friendsIds = db.UsersFriends
                .Where(uf => uf.UserId == userId)
                .Select(uf => uf.FriendId)
                .ToArray();

            List<PostServiceModel> posts = GetAllPosts()
                .Where(p => friendsIds.Contains(p.UserId))
                .Where(p => p.Reactions.All(r => r.UserId != userId))
                .Where(p => p.Comments.Where(c => c.UserId == userId).Count() < 1)
                .ToList();

            return posts;
        }

        public void DeleteUserPosts(string userId)
        {
            db.Posts.RemoveRange(db.Posts.Where(p => p.UserId == userId));
            db.SaveChanges();
        }
    }
}
