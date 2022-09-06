using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {
            _userDal.Insert(user);
        }

        public void DeleteUser(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetListUser()
        {
            return _userDal.GetListAll();
        }

        public User GetUserById(int id)
        {
            return _userDal.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }
    }
}
