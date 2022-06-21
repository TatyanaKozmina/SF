using NUnit.Framework;
using Moq;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class AddFriendServiceTests
    {        
        [Test]
        public void AddFriend_UserNotFoundException()
        {
            // Готовим тестовые данные 
            var mockUserRepository = CreateMockUserRepository();                     

            AddFriendData addFriendData = new AddFriendData();
            addFriendData.FriendEmail = "notexists@mail.ru";
            addFriendData.SenderId = 2;  

            // Запускаем тест
            AddFriendService service = new AddFriendService(mockUserRepository.Object);

            // Проверяем
            Assert.Throws<UserNotFoundException>(() => service.AddFriend(addFriendData));            
        }

        [Test]
        public void AddFriend_Success()
        {
            // Готовим тестовые данные 
            var mockUserRepository = CreateMockUserRepository();            

            AddFriendData addFriendData = new AddFriendData();
            addFriendData.FriendEmail = "ivan@mail.ru";
            addFriendData.SenderId = 2;

            // Запускаем тест
            AddFriendService service = new AddFriendService(mockUserRepository.Object);

            // Проверяем
            Assert.DoesNotThrow(() => service.AddFriend(addFriendData));
        }        

        private Mock<IUserRepository> CreateMockUserRepository()
        {
            UserEntity ueIvan = CreateUserEntity(1, "Иван", "ivan@mail.ru");
            UserEntity ueEgor = CreateUserEntity(2, "Егор", "egor@mail.ru");
            UserEntity ueOlga = CreateUserEntity(3, "Ольга", "olga@mail.ru");

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.FindByEmail("ivan@mail.ru")).Returns(ueIvan);
            mockUserRepository.Setup(x => x.FindByEmail("egor@mail.ru")).Returns(ueEgor);
            mockUserRepository.Setup(x => x.FindByEmail("olga@mail.ru")).Returns(ueOlga);

            return mockUserRepository;
        }

        private UserEntity CreateUserEntity(int id, string name, string email)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.id = id;
            userEntity.firstname = name;
            userEntity.email = email;
            return userEntity;
        }
    }    
}