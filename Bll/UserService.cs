using DAL;

namespace Bll
{
    public class UserService : IService
    {
        private IRepository _userRepository;
        public UserService(IRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _userRepository.GetUsers().Select(x => x.DalToBll());
        }
        public void RegisterUser(string lastName, string firstName, string nickname, string email, string psswd)
        {
            _userRepository.RegisterUser(lastName, firstName, nickname, email, psswd);
        }
        public UserModel LoginUser(string email, string psswd)
        {
            return _userRepository.LoginUser(email, psswd).DalToBll();
        }
        public void SetRole(int userId, int roleId)
        {
            _userRepository.SetRole(userId, roleId);
        }
    }
}