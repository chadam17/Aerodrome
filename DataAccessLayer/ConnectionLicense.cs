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
    public class ConnectionLicense
    {
        public MySqlConnectionStringBuilder builder;
        public MySqlConnection connL;
        /// <summary>
        /// Instancia de la conexión, establecida como usuario root sin contraseña de autenticación, para conectar de forma rápida y automática.
        /// </summary>
        /// <exception cref="MySqlException">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public ConnectionLicense()
        {
            try
            {
                builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "aviones";

                connL = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = connL.CreateCommand();
                cmd.CommandText = "select * from licencias";
                connL.Open();
                cmd.ExecuteNonQuery();
                connL.Close();
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


