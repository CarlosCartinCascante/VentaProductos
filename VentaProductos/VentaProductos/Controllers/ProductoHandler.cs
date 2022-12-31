using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using VentaProductos.Models;

namespace VentaProductos.Controllers
{
    public class ProductoHandler : Controller
    {
        private readonly string connectionString;

        public ProductoHandler()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool AgregarProducto(Producto producto)
        {
            bool result = false;
            string query = "INSERT INTO IN04 (Descripcion, Precio, SaldoInventario,UsuarioIngreso,IDFamilia)"
                + " VALUES(@Descripcion,@Precio,@SaldoInventario,@UsuarioIngreso,@IDFamilia);";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@SaldoInventario", producto.SaldoInventario);
                command.Parameters.AddWithValue("@UsuarioIngreso", producto.UsuarioIngreso);
                command.Parameters.AddWithValue("@IDFamilia", producto.IDFamilia);
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

        public List<Producto> ObtenerProductos()
        {
            string query = "SELECT * FROM IN04;";

            List<Producto> productos = new();

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
                            productos.Add(new Producto
                            {
                                CodigoProducto = Convert.ToInt32(sdr["CodigoProducto"]),
                                Descripcion = sdr["Descripcion"].ToString(),
                                Precio = Convert.ToDouble(sdr["Precio"]),
                                SaldoInventario = Convert.ToDouble(sdr["SaldoInventario"]),
                                FechaIngreso = Convert.ToDateTime(sdr["FechaIngreso"]),
                                UsuarioIngreso = sdr["UsuarioIngreso"].ToString(),
                                IDFamilia = Convert.ToInt32(sdr["IDFamilia"])
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
            return productos;
        }

        public bool BorrarProducto(int codigoProducto)
        {

            bool result = false;
            string query = "DELETE FROM IN04 WHERE CodigoProducto = @CodigoProducto;";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CodigoProducto", codigoProducto);
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

        public Producto ObtenerProducto(int codigoProducto)
        {
            string query = "SELECT * FROM IN04 WHERE CodigoProducto = @CodigoProducto;";
            Producto producto = new();

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CodigoProducto", codigoProducto);
                try
                {
                    connection.Open();

                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            producto = new Producto
                            {
                                CodigoProducto = Convert.ToInt32(sdr["CodigoProducto"]),
                                Descripcion = sdr["Descripcion"].ToString(),
                                Precio = Convert.ToDouble(sdr["Precio"]),
                                SaldoInventario = Convert.ToDouble(sdr["SaldoInventario"]),
                                FechaIngreso = Convert.ToDateTime(sdr["FechaIngreso"]),
                                UsuarioIngreso = sdr["UsuarioIngreso"].ToString(),
                                IDFamilia = Convert.ToInt32(sdr["IDFamilia"])
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
            return producto;
        }

        public bool EditarProducto(Producto producto)
        {
            bool result = false;
            string query = "UPDATE IN04 SET Descripcion = @Descripcion, Precio = @Precio, SaldoInventario = @SaldoInventario, UsuarioIngreso = @UsuarioIngreso, IDFamilia = @IDFamilia"
                + " WHERE CodigoProducto = @CodigoProducto;";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@SaldoInventario", producto.SaldoInventario);
                command.Parameters.AddWithValue("@UsuarioIngreso", producto.UsuarioIngreso);
                command.Parameters.AddWithValue("@IDFamilia", producto.IDFamilia);
                command.Parameters.AddWithValue("@CodigoProducto", producto.CodigoProducto);
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
