using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using static Final.DataAccessLayer.Connection;
using static Final.FormInicio;
using static Final.DataAccessLayer.ConnectionUser;
using static Final.DataAccessLayer.ConnectionMember;
using System.Collections;

namespace Final.DataAccessLayer
{
    /// <summary>
    /// Clase que implementa los métodos de acceso a la información contenida en la base de datos mediante consultas SQL.
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Método que acepta los campos del avión y los añade a la tabla de la base de datos
        /// </summary>
        /// <param name="fabricante"></param>
        /// <param name="modelo"></param>
        /// <param name="matricula"></param>
        /// <param name="precio"></param>
        /// <param name="velocidad"></param>
        /// <param name="alcance"></param>
        /// <param name="pais"></param>
        /// <param name="tipo"></param>
        /// <param name="img"></param>
        /// <returns>Devuelve true si el registro se ha añadido correctamente</returns>
        public bool AddItemsToTable(string fabricante, string modelo, string matricula, decimal precio, decimal velocidad, int alcance, string pais, string tipo, Image img)
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }

            string query = "insert into aircraft (fabricante,modelo,matricula,precio,velocidad,alcance,pais,tipo,foto) values (@Fabricante,@Modelo,@Matricula,@Precio,@Velocidad,@Alcance,@Pais,@Tipo,@Foto)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.conn))
                {
                    cmd.Parameters.AddWithValue("@Fabricante", fabricante.Trim());
                    cmd.Parameters.AddWithValue("@Modelo", modelo.Trim());
                    cmd.Parameters.AddWithValue("@Matricula", matricula.Trim());
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Velocidad", velocidad);
                    cmd.Parameters.AddWithValue("@Alcance", alcance);
                    cmd.Parameters.AddWithValue("@Pais", pais.Trim());
                    cmd.Parameters.AddWithValue("@Tipo", tipo.Trim());

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                    cmd.ExecuteNonQuery();
                    con.conn.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Método que obtiene los nuevos valores para actualizar el registro seleccionado
        /// </summary>
        /// <param name="fabricante"></param>
        /// <param name="modelo"></param>
        /// <param name="matricula"></param>
        /// <param name="precio"></param>
        /// <param name="velocidad"></param>
        /// <param name="alcance"></param>
        /// <param name="pais"></param>
        /// <param name="tipo"></param>
        /// <param name="img"></param>
        /// <returns>Devuelve true si el registro se ha modificado correctamente</returns>
        public bool UpdateItemsToTable(string fabricante, string modelo, string matricula, decimal precio, decimal velocidad, int alcance, string pais, string tipo, Image img)
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }

            string query = "update aircraft set fabricante=@Fabricante, modelo=@Modelo, matricula=@Matricula, precio=@Precio, velocidad=@Velocidad, alcance=@Alcance, pais=@Pais, tipo=@Tipo, foto=@Foto where matricula=@Matricula";
            
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.conn))
                {
                    cmd.Parameters.AddWithValue("@Fabricante", fabricante.Trim());
                    cmd.Parameters.AddWithValue("@Modelo", modelo.Trim());
                    cmd.Parameters.AddWithValue("@Matricula", matricula.Trim());
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Velocidad", velocidad);
                    cmd.Parameters.AddWithValue("@Alcance", alcance);
                    cmd.Parameters.AddWithValue("@Pais", pais.Trim());
                    cmd.Parameters.AddWithValue("@Tipo", tipo.Trim());

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                    cmd.ExecuteNonQuery();
                    con.conn.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Función que obtiene todos los registros almacenados en la base de datos y los guarda en un objeto tipo DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ReadItemsTable()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string query = "select * from aircraft order by modelo";

            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.conn.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Función para borrar todos los registros contenidos en la base de datos.
        /// </summary>
        public void ClearTable()
        {
            try
            {
                Connection con = new Connection();
                if (System.Data.ConnectionState.Closed == con.conn.State)
                {
                    con.conn.Open();
                }
                string query = "truncate table aircraft";

                MySqlCommand cmd = new MySqlCommand(query, con.conn);
                cmd.ExecuteNonQuery();
                con.conn.Close();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Función que lanza una query para incrementar el tamaño máximo permitido para un valor de la tabla, de modo que el usuario pueda guardar fotos de elevado tamaño sin necesidad de ejecutar manualmente la consulta cada vez que inicia la aplicación.
        /// </summary>
        public void AllowBigDataTable()
        {
            try
            {
                Connection con = new Connection();
                if (System.Data.ConnectionState.Closed == con.conn.State)
                {
                    con.conn.Open();
                }
                string query = "SET GLOBAL max_allowed_packet=4294967295";

                MySqlCommand cmd = new MySqlCommand(query, con.conn);
                cmd.ExecuteNonQuery();
                con.conn.Close();
            }
            catch
            {
                throw;
            }
        }
        public void AllowBigDataTableUser()
        {
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "SET GLOBAL max_allowed_packet=4294967295";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                cmd.ExecuteNonQuery();
                con.connUs.Close();
            }
            catch
            {
                throw;
            }
        }
        public void AllowBigDataTableMember()
        {
            try
            {
                ConnectionMember con = new ConnectionMember();
                if (System.Data.ConnectionState.Closed == con.connM.State)
                {
                    con.connM.Open();
                }
                string query = "SET GLOBAL max_allowed_packet=4294967295";

                MySqlCommand cmd = new MySqlCommand(query, con.connM);
                cmd.ExecuteNonQuery();
                con.connM.Close();
            }
            catch
            {
                throw;
            }
        }
        public void AllowBigDataTableNews()
        {
            try
            {
                ConnectionNews con = new ConnectionNews();
                if (System.Data.ConnectionState.Closed == con.connN.State)
                {
                    con.connN.Open();
                }
                string query = "SET GLOBAL max_allowed_packet=4294967295";

                MySqlCommand cmd = new MySqlCommand(query, con.connN);
                cmd.ExecuteNonQuery();
                con.connN.Close();
            }
            catch
            {
                throw;
            }
        }
        public void AllowBigDataTableLicense()
        {
            try
            {
                ConnectionLicense con = new ConnectionLicense();
                if (System.Data.ConnectionState.Closed == con.connL.State)
                {
                    con.connL.Open();
                }
                string query = "SET GLOBAL max_allowed_packet=4294967295";

                MySqlCommand cmd = new MySqlCommand(query, con.connL);
                cmd.ExecuteNonQuery();
                con.connL.Close();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Función que elimina un determinado registro tomando como referencia la clave primaria.
        /// </summary>
        /// <param name="matricula">Matrícula del avión</param>
        /// <returns>Devuelve true si el registro ha sido eliminado de la base de datos</returns>
        public bool DeleteFromTable(string matricula)
        {
            try
            {
                Connection con = new Connection();
                if (System.Data.ConnectionState.Closed == con.conn.State)
                {
                    con.conn.Open();
                }
                string query = "delete from aircraft where matricula=@Matricula";

                MySqlCommand cmd = new MySqlCommand(query, con.conn);
                cmd.Parameters.AddWithValue("@Matricula", matricula.Trim());
                cmd.ExecuteNonQuery();
                con.conn.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Función que relaciona la tabla aeronaves con la de países.
        /// </summary>
        /// <returns>Resultado en forma de tabla con el nombre del país del registro seleccionado</returns>
        public DataTable AsociarPais()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string query = "select nombre from aircraft,paises where aircraft.pais+1 = paises.indice";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.conn.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Función que relaciona la tabla aeronaves con la de tipos de aviones.
        /// </summary>
        /// <returns>Resultado en forma de tabla con el nombre del tipo del registro seleccionado</returns>
        public DataTable AsociarTipo()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string query = "select nombre from aircraft,tipos where aircraft.tipo+1 = tipos.indice";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.conn.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public bool AddItemsToTableUsers(string correo, string password)
        {
            ConnectionUser con = new ConnectionUser();
            if (System.Data.ConnectionState.Closed == con.connUs.State)
            {
                con.connUs.Open();
            }

            string query = "insert into usuarios (correo,password) values (@Correo,@Password)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connUs))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                    cmd.Parameters.AddWithValue("@Password", password.Trim());

                    cmd.ExecuteNonQuery();
                    con.connUs.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadEmails()
        {
            ConnectionUser con = new ConnectionUser();
            if (System.Data.ConnectionState.Closed == con.connUs.State)
            {
                con.connUs.Open();
            }
            string query = "select correo from usuarios";
            MySqlCommand cmd = new MySqlCommand(query, con.connUs);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connUs.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadPasswords()
        {
            ConnectionUser con = new ConnectionUser();
            if (System.Data.ConnectionState.Closed == con.connUs.State)
            {
                con.connUs.Open();
            }
            string query = "select password from usuarios";
            MySqlCommand cmd = new MySqlCommand(query, con.connUs);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connUs.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public bool AddItemsToTableMembers(string correo, string password, string nombre, int codigo, string nacionalidad, string birthdate, string propiedades, string licencias, int miembrodesde, string distinciones, Image img)
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }

            string query = "insert into miembros (correo,password,nombre,codigo,nacionalidad,birthdate,propiedades,licencias,miembrodesde,distinciones,foto) values (@Correo,@Password,@Nombre,@Codigo,@Nacionalidad,@Birthdate,@Propiedades,@Licencias,@Miembrodesde,@Distinciones,@Foto)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connM))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                    cmd.Parameters.AddWithValue("@Password", password.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", nombre.Trim());
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.Parameters.AddWithValue("@Nacionalidad", nacionalidad.Trim());
                    cmd.Parameters.AddWithValue("@Birthdate", birthdate.Trim());
                    cmd.Parameters.AddWithValue("@Propiedades", propiedades.Trim());
                    cmd.Parameters.AddWithValue("@Licencias", licencias.Trim());
                    cmd.Parameters.AddWithValue("@Miembrodesde", miembrodesde);
                    cmd.Parameters.AddWithValue("@Distinciones", distinciones.Trim());

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                    cmd.ExecuteNonQuery();
                    con.connM.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadCorreo()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string corr = UserControlPortada.txtEmailLogin.Text;
            string query = "select correo from miembros where correo = '" + corr + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadPass()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string pass = UserControlPortada.txtPassLogin.Text;
            string query = "select password from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadNombre()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select nombre from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadCodigo()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select codigo from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadNacionalidad()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select nacionalidad from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadBirthdate()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select birthdate from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadPropiedades()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select propiedades from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadLicencias()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select licencias from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadMiembrodesde()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select miembrodesde from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadDistinciones()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select distinciones from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public Image ReadFoto()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            Image img;
            string query = "select foto from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    MemoryStream ms = new MemoryStream((byte[])row["foto"]);
                    ms.Position = 0;
                    UserControlMembresia.pictIconM.Image = new Bitmap(ms);
                }

                con.connM.Close();
                return UserControlMembresia.pictIconM.Image;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableUsers(string correo)
        {
            correo = UserControlPortada.txtEmail.Text;
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "delete from usuarios where correo = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connUs.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMembersToTable(string correo, string password, string nombre, int codigo, string nacionalidad, string birthdate, string propiedades, string licencias, int miembrodesde, string distinciones, Image img)
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string query = "update miembros set correo=@Correo, password=@Password, nombre=@Nombre, codigo=@Codigo, nacionalidad=@Nacionalidad, birthdate=@Birthdate, propiedades=@Propiedades, licencias=@Licencias, miembrodesde=@Miembrodesde, distinciones=@Distinciones, foto=@Foto where correo = '" + correo + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connM))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                    cmd.Parameters.AddWithValue("@Password", password.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", nombre.Trim());
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.Parameters.AddWithValue("@Nacionalidad", nacionalidad.Trim());
                    cmd.Parameters.AddWithValue("@Birthdate", birthdate.Trim());
                    cmd.Parameters.AddWithValue("@Propiedades", propiedades.Trim());
                    cmd.Parameters.AddWithValue("@Licencias", licencias.Trim());
                    cmd.Parameters.AddWithValue("@Miembrodesde", miembrodesde);
                    cmd.Parameters.AddWithValue("@Distinciones", distinciones.Trim());

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                    cmd.ExecuteNonQuery();
                    con.connM.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableMembers(string correo)
        {
            correo = UserControlPortada.txtEmailLogin.Text;
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "delete from miembros where correo = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connUs.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableUsuarios(string correo)
        {
            correo = UserControlPortada.txtEmailLogin.Text;
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "delete from usuarios where correo = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connUs.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadLastCodigo()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select codigo from miembros order by codigo desc limit 1";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                int cod = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    cod = ((int)row["codigo"]);
                }
                con.connM.Close();
                return cod;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadItemsTableNews()
        {
            ConnectionNews con = new ConnectionNews();
            if (System.Data.ConnectionState.Closed == con.connN.State)
            {
                con.connN.Open();
            }
            string query = "select * from noticias order by fecha desc";

            MySqlCommand cmd = new MySqlCommand(query, con.connN);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.connN.Close();
                return dt;

            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadFabricante()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select fabricante from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadModelo()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select modelo from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadMatricula()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select matricula from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadTipo()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select tipo from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadPrecio()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select precio from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadPais()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select pais from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadVelocidad()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select velocidad from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadAlcance()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            string query = "select alcance from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public Image ReadFotoAvion()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = FormEdit.txtMatriculaEdit.Text;
            Image img;
            string query = "select foto from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    MemoryStream ms = new MemoryStream((byte[])row["foto"]);
                    ms.Position = 0;
                    UserControlAeronaves.pictIcon.Image = new Bitmap(ms);
                }

                con.conn.Close();
                return UserControlAeronaves.pictIcon.Image;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadMembers()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string query = "select * from miembros";

            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.connM.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadMembersByCode()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string query = "select * from miembros order by codigo";

            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.connM.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadMembersByEmail()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string query = "select * from miembros order by correo";

            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.connM.Close();
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public List<string> SearchCorreo()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string corr = FormDGV.dgvMembers.CurrentRow.Cells[0].Value.ToString();
            string query = "select correo from miembros where correo = '" + corr + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> SearchPass()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string pass = FormDGV.dgvMembers.CurrentRow.Cells[1].Value.ToString();
            string query = "select correo from miembros where correo = '" + pass + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableMembersDGV(string correo)
        {
            correo = FormDGV.dgvMembers.CurrentRow.Cells[0].Value.ToString();
            try
            {
                ConnectionMember con = new ConnectionMember();
                if (System.Data.ConnectionState.Closed == con.connM.State)
                {
                    con.connM.Open();
                }
                string query = "delete from miembros where correo = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connM);
                cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connM.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableUsuariosDGV(string correo)
        {
            correo = FormDGV.dgvMembers.CurrentRow.Cells[0].Value.ToString();
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "delete from usuarios where correo = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connUs.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public void ResetFromTableMembersDGV()
        {
            string correo = "admin@nimboaircraft.com";
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "delete from miembros where correo != '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                
                cmd.ExecuteNonQuery();
                con.connUs.Close();
            }
            catch
            {
                throw;
            }
        }
        public void ResetTableUsuariosDGV()
        {
            string correo = "admin@nimboaircraft.com";
            try
            {
                ConnectionUser con = new ConnectionUser();
                if (System.Data.ConnectionState.Closed == con.connUs.State)
                {
                    con.connUs.Open();
                }
                string query = "delete from usuarios where correo != '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connUs);
                
                cmd.ExecuteNonQuery();
                con.connUs.Close();
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadAdminPass()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = "admin@nimboaircraft.com";
            
            string query = "select password from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connM.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public Image ReadFotoDGV()
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = FormDGV.dgvMembers.CurrentRow.Cells[0].Value.ToString();
            Image img;
            string query = "select foto from miembros where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connM);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    MemoryStream ms = new MemoryStream((byte[])row["foto"]);
                    ms.Position = 0;
                    FormMiembroEditDGV.pictFotoMEditDGV.Image = new Bitmap(ms);
                }

                con.connM.Close();
                return FormMiembroEditDGV.pictFotoMEditDGV.Image;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateUsersToTable(string correo, string password)
        {
            ConnectionUser con = new ConnectionUser();
            if (System.Data.ConnectionState.Closed == con.connUs.State)
            {
                con.connUs.Open();
            }
            string query = "update usuarios set correo=@Correo, password=@Password where correo = '" + correo + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connUs))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                    cmd.Parameters.AddWithValue("@Password", password.Trim());
                    cmd.ExecuteNonQuery();
                    con.connUs.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public string ReadPassword()
        {
            ConnectionUser con = new ConnectionUser();
            if (System.Data.ConnectionState.Closed == con.connUs.State)
            {
                con.connUs.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select password from usuarios where correo = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connUs);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string password = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    password = ((string)row["password"]);
                }
                con.connUs.Close();
                return password;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdatePasswordUsers(string password)
        {
            ConnectionUser con = new ConnectionUser();
            if (System.Data.ConnectionState.Closed == con.connUs.State)
            {
                con.connUs.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update usuarios set password=@Password where correo = '" + correo + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connUs))
                {
                    cmd.Parameters.AddWithValue("@Password", password.Trim());
                    cmd.ExecuteNonQuery();
                    con.connUs.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdatePasswordMembers(string password)
        {
            ConnectionMember con = new ConnectionMember();
            if (System.Data.ConnectionState.Closed == con.connM.State)
            {
                con.connM.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update miembros set password=@Password where correo = '" + correo + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connM))
                {
                    cmd.Parameters.AddWithValue("@Password", password.Trim());
                    cmd.ExecuteNonQuery();
                    con.connM.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadItemsTableLicenses()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string query = "select * from licencias";

            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.connL.Close();
                return dt;

            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadLicenciasNames()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string query = "select nombre from licencias";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connL.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadAlumnos(string nombre)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            MyUserControlLicencias mucl = new MyUserControlLicencias();
            
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connL.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosPPL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto Privado (PPL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosULM()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Ultraligero (ULM)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosRPAS()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Vehículo Aéreo No Tripulado (RPAS)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosHPL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Helicópteros (HPL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosAFL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Combate Aéreo (AFL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosCPL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto Comercial (CPL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosATPL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Transporte de Línea Aérea (ATPL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosBPL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Globo Aerostático (BPL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosSPL()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Planeador (SPL)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public string ReadAlumnosFI()
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Instructor de Vuelo (FI)";
            string query = "select alumnos from licencias where nombre = '" + nombre + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connL);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                string alumnos = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    alumnos = ((string)row["alumnos"]);
                }
                con.connL.Close();
                return alumnos;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentPPL (string alumnosPPL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto Privado (PPL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosPPL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentULM(string alumnosULM)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Ultraligero (ULM)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosULM.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentRPAS(string alumnosRPAS)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Vehículo Aéreo No Tripulado (RPAS)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosRPAS.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentHPL(string alumnosHPL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Helicópteros (HPL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosHPL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentAFL(string alumnosAFL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Combate Aéreo (AFL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosAFL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentCPL(string alumnosCPL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto Comercial (CPL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosCPL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentATPL(string alumnosATPL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Transporte de Línea Aérea (ATPL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosATPL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentBPL(string alumnosBPL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Globo Aerostático (BPL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosBPL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentSPL(string alumnosSPL)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Piloto de Planeador (SPL)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosSPL.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddStudentFI(string alumnosFI)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = "Instructor de Vuelo (FI)";
            string query = "update licencias set alumnos=@Alumnos where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Alumnos", alumnosFI.Trim());

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public decimal ReadPrecioMillon()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string mat = UserControlAeronaves.lbMatricula.Text;
            string query = "select precio from aircraft where matricula = '" + mat + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                decimal precio = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    precio = ((decimal)row["precio"]);
                }
                con.conn.Close();
                return precio;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateLicenses(string lugar, int precio, string descripcion, Image img)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }
            string nombre = FormEditLicencia.lbNombreLicenciaEdit.Text;
            string query = "update licencias set lugar=@Lugar, descripcion=@Descripcion, precio=@Precio, foto=@Foto where nombre = '" + nombre + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Lugar", lugar.Trim());                   
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion.Trim());

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    cmd.Parameters.AddWithValue("@Foto", ms.ToArray());
                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool AddItemsToTableVoters(string correo)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            int notaPPL = 0;
            int notaULM = 0;
            int notaRPAS = 0;
            int notaHPL = 0;
            int notaAFL = 0;
            int notaCPL = 0;
            int notaATPL = 0;
            int notaBPL = 0;
            int notaSPL = 0;
            int notaFI = 0;
            string query = "insert into votantes (correos,notaPPL,notaULM,notaRPAS,notaHPL,notaAFL,notaCPL,notaATPL,notaBPL,notaSPL,notaFI) values (@Correos,@NotaPPL,@NotaULM,@NotaRPAS,@NotaHPL,@NotaAFL,@NotaCPL,@NotaATPL,@NotaBPL,@NotaSPL,@NotaFI)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@Correos", correo.Trim());
                    cmd.Parameters.AddWithValue("@NotaPPL", notaPPL);
                    cmd.Parameters.AddWithValue("@NotaULM", notaULM);
                    cmd.Parameters.AddWithValue("@NotaRPAS", notaRPAS);
                    cmd.Parameters.AddWithValue("@NotaHPL", notaHPL);
                    cmd.Parameters.AddWithValue("@NotaAFL", notaAFL);
                    cmd.Parameters.AddWithValue("@NotaCPL", notaCPL);
                    cmd.Parameters.AddWithValue("@NotaATPL", notaATPL);
                    cmd.Parameters.AddWithValue("@NotaBPL", notaBPL);
                    cmd.Parameters.AddWithValue("@NotaSPL", notaSPL);
                    cmd.Parameters.AddWithValue("@NotaFI", notaFI);
                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public List<string> ReadVoters()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select correos from votantes";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                List<string> lista = new List<string>(dt.Rows.Count);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(string.Join(";", row.ItemArray.Select(item => item.ToString())));
                }
                con.connV.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableVoters(string correo)
        {
            correo = UserControlPortada.txtEmailLogin.Text;
            try
            {
                ConnectionVoters con = new ConnectionVoters();
                if (System.Data.ConnectionState.Closed == con.connV.State)
                {
                    con.connV.Open();
                }
                string query = "delete from votantes where correos = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connV);
                cmd.Parameters.AddWithValue("@Correo", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connV.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteFromTableVotersDGV(string correo)
        {
            correo = FormDGV.dgvMembers.CurrentRow.Cells[0].Value.ToString();
            try
            {
                ConnectionVoters con = new ConnectionVoters();
                if (System.Data.ConnectionState.Closed == con.connV.State)
                {
                    con.connV.Open();
                }
                string query = "delete from votantes where correos = '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connV);
                cmd.Parameters.AddWithValue("@Correos", correo.Trim());
                cmd.ExecuteNonQuery();
                con.connV.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public void ResetTableVotersDGV()
        {
            string correo = "admin@nimboaircraft.com";
            try
            {
                ConnectionVoters con = new ConnectionVoters();
                if (System.Data.ConnectionState.Closed == con.connV.State)
                {
                    con.connV.Open();
                }
                string query = "delete from votantes where correos != '" + correo + "'";

                MySqlCommand cmd = new MySqlCommand(query, con.connV);

                cmd.ExecuteNonQuery();
                con.connV.Close();
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaPPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaPPL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaPPL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaPPL(int notaPPL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaPPL=@NotaPPL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaPPL", notaPPL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaULM()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaULM from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaULM"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaULM(int notaULM)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaULM=@NotaULM where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaULM", notaULM);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaRPAS()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaRPAS from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaRPAS"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaRPAS(int notaRPAS)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaRPAS=@NotaRPAS where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaRPAS", notaRPAS);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaHPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaHPL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaHPL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaHPL(int notaHPL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaHPL=@NotaHPL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaHPL", notaHPL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaAFL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaAFL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaAFL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaAFL(int notaAFL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaAFL=@NotaAFL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaAFL", notaAFL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaCPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaCPL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaCPL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaCPL(int notaCPL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaCPL=@NotaCPL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaCPL", notaCPL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaATPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaATPL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaATPL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaATPL(int notaATPL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaATPL=@NotaATPL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaATPL", notaATPL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaBPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaBPL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaBPL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaBPL(int notaBPL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaBPL=@NotaBPL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaBPL", notaBPL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaSPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaSPL from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaSPL"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaSPL(int notaSPL)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaSPL=@NotaSPL where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaSPL", notaSPL);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public int ReadNotaFI()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "select notaFI from votantes where correos = '" + correo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);

            try
            {
                DataTable dt = new DataTable();
                int nota = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    nota = ((int)row["notaFI"]);
                }
                con.connV.Close();
                return nota;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateNotaFI(int notaFI)
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string correo = UserControlPortada.txtEmailLogin.Text;
            string query = "update votantes set notaFI=@NotaFI where correos = '" + correo + "'";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connV))
                {
                    cmd.Parameters.AddWithValue("@NotaFI", notaFI);

                    cmd.ExecuteNonQuery();
                    con.connV.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumPPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto Privado (PPL)";
            string query = "select sum(notaPPL) from votantes where notaPPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);           
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountPPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto Privado (PPL)";
            string query = "select count(notaPPL) from votantes where notaPPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumULM()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Ultraligero (ULM)";
            string query = "select sum(notaULM) from votantes where notaULM != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountULM()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Ultraligero (ULM)";
            string query = "select count(notaULM) from votantes where notaULM != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumRPAS()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Vehículo Aéreo No Tripulado (RPAS)";
            string query = "select sum(notaRPAS) from votantes where notaRPAS != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountRPAS()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Vehículo Aéreo No Tripulado (RPAS)";
            string query = "select count(notaRPAS) from votantes where notaRPAS != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumHPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Helicópteros (HPL)";
            string query = "select sum(notaHPL) from votantes where notaHPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountHPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Helicópteros (HPL)";
            string query = "select count(notaHPL) from votantes where notaHPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumAFL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Combate Aéreo (AFL)";
            string query = "select sum(notaAFL) from votantes where notaAFL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountAFL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Combate Aéreo (AFL)";
            string query = "select count(notaAFL) from votantes where notaAFL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumCPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto Comercial (CPL)";
            string query = "select sum(notaCPL) from votantes where notaCPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountCPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto Comercial (CPL)";
            string query = "select count(notaCPL) from votantes where notaCPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumATPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Transporte de Línea Aérea (ATPL)";
            string query = "select sum(notaATPL) from votantes where notaATPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountATPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Transporte de Línea Aérea (ATPL)";
            string query = "select count(notaATPL) from votantes where notaATPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumBPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Globo Aerostático (BPL)";
            string query = "select sum(notaBPL) from votantes where notaBPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountBPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Globo Aerostático (BPL)";
            string query = "select count(notaBPL) from votantes where notaBPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumSPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Planeador (SPL)";
            string query = "select sum(notaSPL) from votantes where notaSPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountSPL()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Piloto de Planeador (SPL)";
            string query = "select count(notaSPL) from votantes where notaSPL != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarSumFI()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Instructor de Vuelo (FI)";
            string query = "select sum(notaFI) from votantes where notaFI != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public decimal StarCountFI()
        {
            ConnectionVoters con = new ConnectionVoters();
            if (System.Data.ConnectionState.Closed == con.connV.State)
            {
                con.connV.Open();
            }
            string nombre = "Instructor de Vuelo (FI)";
            string query = "select count(notaFI) from votantes where notaFI != 0";
            MySqlCommand cmd = new MySqlCommand(query, con.connV);
            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {
                    return 0;
                }
                else
                {
                    decimal sum = reader.GetDecimal(0);
                    dt.Load(reader);
                    con.connV.Close();
                    return sum;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkPPL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto Privado (PPL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";                     
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkULM(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto de Ultraligero (ULM)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkRPAS(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Vehículo Aéreo No Tripulado (RPAS)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkHPL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto de Helicópteros (HPL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkAFL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto de Combate Aéreo (AFL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkCPL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto Comercial (CPL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkATPL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto de Transporte de Línea Aérea (ATPL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkBPL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto de Globo Aerostático (BPL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkSPL(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Piloto de Planeador (SPL)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateMarkFI(decimal puntuacion)
        {
            ConnectionLicense con = new ConnectionLicense();
            if (System.Data.ConnectionState.Closed == con.connL.State)
            {
                con.connL.Open();
            }

            string nombre = "Instructor de Vuelo (FI)";
            string query = "update licencias set puntuacion=@Puntuacion where nombre = '" + nombre + "'";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con.connL))
                {
                    cmd.Parameters.AddWithValue("@Puntuacion", puntuacion);

                    cmd.ExecuteNonQuery();
                    con.connL.Close();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public string ReadModelos()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string query = "select modelo from aircraft";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                string lista = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((string)row["modelo"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public string ReadFabricanteSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select fabricante from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                string lista = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((string)row["fabricante"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public string ReadModeloSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select modelo from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                string lista = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((string)row["modelo"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public string ReadMatriculaSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select matricula from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                string lista = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((string)row["matricula"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public decimal ReadPrecioSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select precio from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                decimal lista = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((decimal)row["precio"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public decimal ReadVelocidadSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select velocidad from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                decimal lista = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((decimal)row["velocidad"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public int ReadAlcanceSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select alcance from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                int lista = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((int)row["alcance"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public string ReadPaisSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select pais from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                string lista = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((string)row["pais"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public string ReadTipoSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select tipo from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                string lista = "";
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    lista = ((string)row["tipo"]);
                }
                con.conn.Close();
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public Image ReadFotoSearch()
        {
            Connection con = new Connection();
            if (System.Data.ConnectionState.Closed == con.conn.State)
            {
                con.conn.Open();
            }
            string modelo = UserControlAeronaves.myc.Modelo;
            string query = "select foto from aircraft where modelo = '" + modelo + "'";
            MySqlCommand cmd = new MySqlCommand(query, con.conn);

            try
            {
                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    MemoryStream ms = new MemoryStream((byte[])row["foto"]);
                    ms.Position = 0;
                    UserControlAeronaves.myc.Icon = new Bitmap(ms);
                }

                con.conn.Close();
                return UserControlAeronaves.myc.Icon;
            }
            catch
            {
                throw;
            }
        }
    }
}
