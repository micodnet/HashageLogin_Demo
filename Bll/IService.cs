using DAL;

namespace Bll
{
    public interface IService
    {
        IEnumerable<UserModel> GetUsers();
        void RegisterUser(string lastName, string firstName, string nickname, string email, string psswd);
        UserModel LoginUser(string email, string psswd);
        void SetRole(int userId, int roleId);
    }
}