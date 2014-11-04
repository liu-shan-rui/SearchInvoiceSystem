using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entitys;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class UserDA
    {
        private static String connectionString = ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

        public void AddUserModel(UserModel model)
        {
            String sql = "Insert into T_User(ID,username,password,name,Role,AccountCode,Telephone,Email,ParentID,IsDelete)values " +
                "(@ID,@username,@password,@name,@Role,@AccountCode,@Telephone,@Email,@ParentID,@IsDelete)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ID", model.ID));
                    cmd.Parameters.Add(new SqlParameter("@username", model.Username));
                    cmd.Parameters.Add(new SqlParameter("@password", model.Password));
                    cmd.Parameters.Add(new SqlParameter("@name", model.RealName));
                    cmd.Parameters.Add(new SqlParameter("@Role", model.Role));
                    cmd.Parameters.Add(new SqlParameter("@AccountCode", model.AccountCode));
                    cmd.Parameters.Add(new SqlParameter("@Telephone", model.Telephone));
                    cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                    cmd.Parameters.Add(new SqlParameter("@ParentID", model.ParentID));
                    cmd.Parameters.Add(new SqlParameter("@IsDelete", model.IsDelete));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UserModel VerificationAccountCode(String AccountCode)
        {
            UserModel model = new UserModel();
            String sql = "select * from T_User where AccountCode = @AccountCode";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AccountCode", AccountCode));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                        }
                    }
                }
            }
            return model;
        }


        public UserModel VerificationAccountCode(String AccountCode, Guid ID)
        {
            UserModel model = new UserModel();
            String sql = "select * from T_User where AccountCode = @AccountCode and ID <> @ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@AccountCode", AccountCode));
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                        }
                    }
                }
            }
            return model;
        }


        public UserModel VerificationUsername(String username)
        {
            UserModel model = new UserModel();
            String sql = "select * from T_User where username = @username";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                        }
                    }
                }
            }
            return model;
        }

        public UserModel VerificationUsername(String username, Guid ID)
        {
            UserModel model = new UserModel();
            String sql = "select * from T_User where username = @username and ID <> @ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                        }
                    }
                }
            }
            return model;
        }

        public UserModel GetUserModel(Guid ID)
        {
            UserModel model = new UserModel();
            String sql = "select * from T_User where ID = @ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                        }
                    }
                }
            }
            return model;
        }

        public DataSet GetUserModels(String username, String password, String realName,
            String role, String accountCode, String telephone, String email)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "proc_User";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300000;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@realName", realName));
                    cmd.Parameters.Add(new SqlParameter("@role", role));
                    cmd.Parameters.Add(new SqlParameter("@accountCode", accountCode));
                    cmd.Parameters.Add(new SqlParameter("@telephone", telephone));
                    cmd.Parameters.Add(new SqlParameter("@email", email));

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }

        public void changeUser(String username, String password, String realName, String role, String accountCode, String telephone, String email, Guid ID)
        {
            String sql = "update T_User set username = @username , password = @password , name = @realName , role = @role , accountCode = @accountCode," +
                "telephone = @telephone,email = @email where ID = @ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@realName", realName));
                    cmd.Parameters.Add(new SqlParameter("@role", role));
                    cmd.Parameters.Add(new SqlParameter("@accountCode", accountCode));
                    cmd.Parameters.Add(new SqlParameter("@telephone", telephone));
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void changeUser(Guid ID)
        {
            String sql = "update T_User set IsDelete = 1 where ID = @ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<UserModel> GetParentID(Guid ParentID, String username, String password, String accountCode, String realName, String email, String telephone)
        {
            List<UserModel> models = new List<UserModel>();
            String sql = "select * from T_User where ParentID = @ParentID and IsDelete = 0 and (username = @username or @username = '') " +
                "and (password = @password or @password = '') and (accountCode = @accountCode or @accountCode = '') " +
                "and (name = @realName or @realName = '') and (email = @email or @email = '') and (telephone = @telephone or @telephone = '') order by Role";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@ParentID", ParentID));
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@accountCode", accountCode));
                    cmd.Parameters.Add(new SqlParameter("@realName", realName));
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@telephone", telephone));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserModel model = new UserModel();
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                            models.Add(model);
                        }
                    }
                }
            }
            return models;
        }

        public UserModel Verification(String username, String password)
        {
            UserModel model = new UserModel();
            String sql = "select * from T_User where username = @username and password = @password";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ID = new Guid(reader["ID"].ToString());
                            model.Username = reader["username"].ToString();
                            model.Password = reader["password"].ToString();
                            model.RealName = reader["name"].ToString();
                            model.Role = reader["Role"].ToString();
                            model.AccountCode = reader["AccountCode"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Telephone = reader["Telephone"].ToString();
                            model.ParentID = new Guid(reader["ParentID"].ToString());
                        }
                    }
                }
            }
            return model;
        }
    }
}
