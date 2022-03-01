﻿using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPostServices
    {
        List<PostServiceModel> GetAllPosts();

        List<CommentServiceModel> GetPostComments(string postId);

        PostServiceModel AddPost(PostServiceModel post);

        PostServiceModel GetPostById(string id);

        List<PostServiceModel> GetUserPosts(string userId);

        PostServiceModel UpdatePost(PostServiceModel updatedPost);

        void DeletePost(string id);
    }
}
