using BOilerplate.Model;
using BOilerplate.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace BOilerplate.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel model)
        {
            String query = "INSERT INTO [User] (username,password,name,lastname,email) VALUES (@username, @password, @name, @lastname, @email)";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                command.Parameters.Add("@username", SqlDbType.NChar).Value = model.username;

                command.Parameters.Add("@password", SqlDbType.NChar).Value = model.password;

                //a longer syntax for adding parameters
                command.Parameters.Add("@name", SqlDbType.NChar).Value = model.name;

                command.Parameters.Add("@lastname", SqlDbType.NChar).Value = model.lastname;

                command.Parameters.Add("@email", SqlDbType.NChar).Value  = model.email;

                //make sure you open and close(after executing) the connection
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool AuthenticateUser(NetworkCredential networkCredential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username and password=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value=networkCredential.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = networkCredential.Password;
                validUser = command.ExecuteScalar() == null ? false : true; 

            }
            return validUser;
        }

        public List<UserModel> GetAll()
        {
            List<UserModel> userList = new List<UserModel>();
            using (var connection = GetConnection())
            {
                const string sql = @"SELECT * FROM [USER]";
                using (SqlDataAdapter a = new SqlDataAdapter(sql, connection))
                {

                    DataTable t = new DataTable();
                    a.Fill(t);

                    try
                    {
                        for (int i = 0; i < t.Rows.Count; i++)
                        {
                            UserModel user = new UserModel();
                            user.Id = t.Rows[i]["Id"].ToString();
                            user.username = t.Rows[i]["username"].ToString();
                            user.password = t.Rows[i]["password"].ToString();
                            user.name = t.Rows[i]["name"].ToString();
                            user.lastname = t.Rows[i]["lastname"].ToString();
                            user.email = t.Rows[i]["email"].ToString();
                            userList.Add(user);
                        }
                    }
                    catch (Exception e)
                    {

                    }

                }

            }
            return userList;
        }

        public UserModel GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserByName(string name)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username";
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = name;
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            username = reader[1].ToString(),
                            password = reader[2].ToString(),
                            name = reader[3].ToString(),
                            lastname = reader[4].ToString(),
                            email = reader[5].ToString()
                        };
                    }
                }

            }
            return user;
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
