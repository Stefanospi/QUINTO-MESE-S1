using PROGETTO_S1.Models;
using System.Data.SqlClient;

namespace PROGETTO_S1.Service
{
    public class AuthService : IAuthService
    {
        public readonly string _connectionString;
        private const string LOGIN_COMMAND = "SELECT Id,Username FROM Users WHERE Username = @Username AND Password = @Password";
        private const string ROLES_COMMAND = "SELECT ro.RoleName FROM Roles ro JOIN UserRoles ur ON ro.Id = ur.RoleId WHERE ur.Id = @Id";
        private const string REGISTER_COMMAND = "INSERT INTO Users (Username,Password) VALUES (@Username,@Password)";
        public AuthService(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("Authdb");
        }
        public Users Login(string username, string password)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(LOGIN_COMMAND, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new Users
                                {
                                    id = reader.GetInt32(0),
                                    username = reader.GetString(1),
                                    password = password
                                };
                                reader.Close();
                                return user;
                            }

                        }
                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Users Register(string username, string password)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(REGISTER_COMMAND, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new Users
                                {
                                    id = reader.GetInt32(0),
                                    username = reader.GetString(1),
                                    password = password
                                };
                                reader.Close();
                                return user;
                            }

                        }
                    }

                }
                return null;

            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
