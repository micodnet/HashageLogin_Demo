namespace DAL
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Psswd { get; set; }
        public int RoleId { get; set; }
    }
}