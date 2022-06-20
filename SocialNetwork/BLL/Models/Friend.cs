namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Friend_id { get; set; }

        public Friend(int id, int user_id, int friend_id)
        {
            Id = id;
            User_id = user_id;
            Friend_id = friend_id;
        }

    }
}
