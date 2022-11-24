using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Final.DataAccessLayer
{
    /// <summary>
    /// Clase destinada a la conexión de la aplicación a la base de datos en servidor MySQL.
    /// </summary>
    public class ConnectionNews
    {
        public MySqlConnectionStringBuilder builder;
        public MySqlConnection connN;
        /// <summary>
        /// Instancia de la conexión, establecida como usuario root sin contraseña de autenticación, para conectar de forma rápida y automática.
        /// </summary>
        /// <exception cref="MySqlException">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public ConnectionNews()
        {
            try
            {
                builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "aviones";

                connN = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = connN.CreateCommand();
                cmd.CommandText = "select * from noticias";
                connN.Open();
                cmd.ExecuteNonQuery();
                connN.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error en conexión a base de datos", "Fallo en conexión");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}

