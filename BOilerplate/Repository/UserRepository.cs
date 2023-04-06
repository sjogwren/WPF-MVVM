using BOilerplate.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace BOilerplate.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel model)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential networkCredential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from User where username=@username and password=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value=networkCredential.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = networkCredential.Password;
                validUser = command.ExecuteScalar() == null ? false : true; 

            }
            return validUser;
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
