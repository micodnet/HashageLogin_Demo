using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace DAL
{
    public class UserRepository: IRepository
    {
        private readonly IDbConnection _dbConnection;
        public UserRepository(IDbConnection dbConnection) 
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            _dbConnection.Open();
            string sql = "SELECT * FROM Users";
            return _dbConnection.Query<UserEntity>(sql);
        }

        public void RegisterUser(string lastName, string firstName, string nickname, string email, string psswd)
        {
            string pass = "Psswd";
            string PasswordHash = Hash.HashPassword(pass);
            string sql = "INSERT INTO Users (LastName, FirstName, NickName, Email, Psswd)" +
                " VALUES (@lastName, @firstName, @nickName, @email, @PasswordHash)";
            var param = new { lastName, firstName, nickname, email, PasswordHash };
            _dbConnection.Execute(sql, param);

        }

        public UserEntity LoginUser(string email, string psswd)
        {
            try
            {
                string MdpUser = "pass";
                string MdpDb = "PasswordHsh";

                bool motDePasseValide = Hash.VerifyPassword(MdpUser, MdpDb);

                if (motDePasseValide)
                {
                    string sql = "SELECT * FROM Users WHERE Email = @email AND " +
                    "Psswd = @psswd";
                    var param = new { email, psswd };
                    _dbConnection.QueryFirst<UserEntity>(sql, param);
                    
                   
                }
                return LoginUser(email, psswd);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Utilisateur inéxistant");
            }
        
        }

        public void SetRole(int userId, int roleId)
        {
            string sql = "UPDATE Users SET RoleId = @roleId WHERE Id = @userId";
            var param = new { userId, roleId };
            _dbConnection.Execute(sql, param);
        }

    }
}
