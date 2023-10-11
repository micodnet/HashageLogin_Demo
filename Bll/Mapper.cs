using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll
{
    public static class Mapper
    {
        internal static UserEntity BllToDal(this UserModel model)
        {
            return new UserEntity()
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                NickName = model.Nickname,
                Email = model.Email,
                Psswd = model.Psswd,
                RoleId = model.RoleId,
                
            };
        }

        internal static UserModel DalToBll(this UserEntity entity)
        {
            if (entity is null) return null;
            return new UserModel()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Nickname = entity.NickName,
                Email = entity.Email,
                Psswd = entity.Psswd,
                RoleId = entity.RoleId
            };
        }
    }
}
