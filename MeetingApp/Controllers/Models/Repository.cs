
namespace MeetingApp.Models

{
    public static class Repository
    {
        private static List<UserInfo> _users = new();


        static Repository(){
            _users.Add(new UserInfo() {Id=1 ,Name = "Ali" , Email = "kayancmuhammet2002@gmail" , Phone="55555", WillAttend=true});
            _users.Add(new UserInfo() {Id=2 ,Name = "meryem" , Email = "2002@gmail" , Phone="555568955", WillAttend=false});
            _users.Add(new UserInfo() {Id=3 ,Name = "beyza" , Email = "2@gmail" , Phone="5455555", WillAttend=true});
        }
        public static List<UserInfo> Users {

            get {
                return _users;
            }
        }
        public static void CreateUser(UserInfo user)
        {
            user.Id = Users.Count +1;
            _users.Add(user);
        }

        public static UserInfo? GetById ( int id){
            return _users.FirstOrDefault(user => user.Id ==id);
        }
    }
}