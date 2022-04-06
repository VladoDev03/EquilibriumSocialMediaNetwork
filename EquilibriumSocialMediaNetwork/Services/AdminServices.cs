using Data;
using Data.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminServices : IAdminServices
    {
        private EquilibriumDbContext db;
        private IPostServices postServices;
        private ICommentServices commentServices;
        private IQrCodeServices qrCodeServices;
        private IProfilePictureServices profilePictureServices;
        private IReactionServices reactionServices;
        private ICloudinaryServices cloudinaryServices;
        private IFriendRequestServices friendRequestServices;
        private IUserFriendServices userFriendServices;
        private IEmailServices emailServices;
        private IMessageServices messageServices;
        private IConversationServices conversationServices;

        public AdminServices(
            EquilibriumDbContext db,
            IPostServices postServices,
            ICommentServices commentServices,
            IQrCodeServices qrCodeServices,
            IProfilePictureServices profilePictureServices,
            IReactionServices reactionServices,
            ICloudinaryServices cloudinaryServices,
            IFriendRequestServices friendRequestServices,
            IUserFriendServices userFriendServices,
            IEmailServices emailServices,
            IMessageServices messageServices,
            IConversationServices conversationServices)
        {
            this.db = db;
            this.postServices = postServices;
            this.commentServices = commentServices;
            this.qrCodeServices = qrCodeServices;
            this.profilePictureServices = profilePictureServices;
            this.reactionServices = reactionServices;
            this.cloudinaryServices = cloudinaryServices;
            this.friendRequestServices = friendRequestServices;
            this.userFriendServices = userFriendServices;
            this.emailServices = emailServices;
            this.messageServices = messageServices;
            this.conversationServices = conversationServices;
        }
        public void DeleteUserProfile(string userId)
        {
            User userToRemove = db.Users.FirstOrDefault(u => u.Id == userId);

            postServices.GetAllPosts().ForEach(p => postServices.DeletePostComments(p.Id));
            postServices.GetAllPosts().ForEach(p => reactionServices.DeletePostReactions(p.Id));
            postServices.GetAllPosts().ForEach(p => cloudinaryServices.DeleteImage(p.ImagePublicId));

            postServices.DeleteUserPosts(userId);
            commentServices.DeleteUserComments(userId);
            reactionServices.DeleteUserReactions(userId);

            cloudinaryServices.DeleteImage(cloudinaryServices.FindQrCodePublicIdById(userToRemove.QrCodeId));
            qrCodeServices.DeleteQrCode(userToRemove.QrCodeId);

            cloudinaryServices.DeleteImage(cloudinaryServices.FindProfilePicturePublicIdById(userToRemove.ProfilePictureId));
            profilePictureServices.DeleteProfilePicture(userToRemove.ProfilePictureId);

            friendRequestServices.DeleteAllFriendRequestByReveiverId(userId);
            friendRequestServices.DeleteAllFriendRequestBySenderId(userId);

            userFriendServices.RemoveAllFriends(userId);

            emailServices.DeleteAllUserEmails(userId);
            messageServices.DeleteAllUserMessages(userId);
            conversationServices.DeleteAllUserConversations(userId);
        }
    }
}
