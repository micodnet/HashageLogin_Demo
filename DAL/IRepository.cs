namespace DAL
{
    public interface IRepository
    {
        IEnumerable<UserEntity> GetUsers();
        void RegisterUser(string lastName, string firstName, string nickname, string email, string psswd);
        UserEntity LoginUser(string email, string psswd);
        void SetRole(int userId, int roleId);
    }
}