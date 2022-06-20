using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class AddFriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public AddFriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }        

        public void AddFriend(AddFriendData addFriendData)
        {
            if (String.IsNullOrEmpty(addFriendData.FriendEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(addFriendData.FriendEmail))
                throw new ArgumentNullException();

            var findFriendEntity = userRepository.FindByEmail(addFriendData.FriendEmail);
            if (findFriendEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity();
            friendEntity.friend_id = findFriendEntity.id;
            friendEntity.user_id = addFriendData.SenderId;

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
