using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOilerplate.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential networkCredential);
        void Add(UserModel model);
        void Update(UserModel model);
        void Remove(int Id);
        UserModel GetById(int ID);
        UserModel GetUserByName(string name);
        List<UserModel> GetAll();
    }
}
