using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using VentaProductos.Models;
using Microsoft.Extensions.Configuration;

namespace VentaProductos.Controllers
{
    public class FamiliaProductoHandler : Controller
    {
        private readonly string connectionString;

        public FamiliaProductoHandler()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool AgregarFamiliaProducto(FamiliaProducto familiaProducto)
        {
            bool result = false;
            string query = "INSERT INTO IN05 (NombreFamilia, UsuarioIngreso, Estado)"
                + " VALUES(@NombreFamilia,@UsuarioIngreso,@Estado);";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@NombreFamilia", familiaProducto.NombreFamilia);
                command.Parameters.AddWithValue("@UsuarioIngreso", familiaProducto.UsuarioIngreso);
                command.Parameters.AddWithValue("@Estado", familiaProducto.Estado);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }

            return result;
        }

        public List<FamiliaProducto> ObtenerFamiliasProductos()
        {
            string query = "SELECT * FROM IN05;";

            List<FamiliaProducto> familiasProductos = new();

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();

                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            familiasProductos.Add(new FamiliaProducto
                            {
                                IDFamilia = Convert.ToInt32(sdr["IDFamilia"]),
                                NombreFamilia = sdr["NombreFamilia"].ToString(),
                                UsuarioIngreso = sdr["UsuarioIngreso"].ToString(),
                                Estado = Convert.ToInt32(sdr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return familiasProductos;
        }

        public bool BorrarFamiliaProducto(int idFamiliaProducto)
        {
            bool result = false;
            string query = "DELETE FROM IN05 WHERE IDFamilia = @IDFamilia;";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@IDFamilia", idFamiliaProducto);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return result;
        }

        public FamiliaProducto ObtenerFamiliaProducto(int idFamiliaProducto)
        {
            string query = "SELECT * FROM IN05 WHERE IDFamilia = @IDFamilia;";
            FamiliaProducto familiaProducto = new();

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@IDFamilia", idFamiliaProducto);
                try
                {
                    connection.Open();

                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            familiaProducto = new FamiliaProducto
                            {
                                IDFamilia = Convert.ToInt32(sdr["IDFamilia"]),
                                NombreFamilia = sdr["NombreFamilia"].ToString(),
                                UsuarioIngreso = sdr["UsuarioIngreso"].ToString(),
                                Estado = Convert.ToInt32(sdr["Estado"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return familiaProducto;
        }

        public bool EditarFamiliaProducto(FamiliaProducto familiaProducto)
        {
            bool result = false;
            string query = "UPDATE IN05 SET NombreFamilia = @NombreFamilia, UsuarioIngreso = @UsuarioIngreso, Estado = @Estado"
                + " WHERE IDFamilia = @IDFamilia;";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@NombreFamilia", familiaProducto.NombreFamilia);
                command.Parameters.AddWithValue("@UsuarioIngreso", familiaProducto.UsuarioIngreso);
                command.Parameters.AddWithValue("@Estado", familiaProducto.Estado);
                command.Parameters.AddWithValue("@IDFamilia", familiaProducto.IDFamilia);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }

            return result;
        }
    }
}
