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
    public class ConnectionVoters
    {
        public MySqlConnectionStringBuilder builder;
        public MySqlConnection connV;
        /// <summary>
        /// Instancia de la conexión, establecida como usuario root sin contraseña de autenticación, para conectar de forma rápida y automática.
        /// </summary>
        /// <exception cref="MySqlException">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public ConnectionVoters()
        {
            try
            {
                builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "aviones";

                connV = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = connV.CreateCommand();
                cmd.CommandText = "select * from votantes";
                connV.Open();
                cmd.ExecuteNonQuery();
                connV.Close();
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
