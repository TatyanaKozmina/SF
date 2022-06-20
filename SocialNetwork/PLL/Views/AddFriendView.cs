using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        AddFriendService addFriendService;
        public AddFriendView(AddFriendService addFriendService)
        {
            this.addFriendService = addFriendService;
        }

        public void Show(User user)
        {
            var addFriendData = new AddFriendData();

            Console.Write("Введите почтовый адрес друга: ");
            addFriendData.FriendEmail = Console.ReadLine();

            addFriendData.SenderId = user.Id;

            try
            {
                addFriendService.AddFriend(addFriendData);

                SuccessMessage.Show("Друг добавлен!");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга!");
            }

        }
    }
}

