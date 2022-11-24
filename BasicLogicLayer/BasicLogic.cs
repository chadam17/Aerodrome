using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Final.DataAccessLayer;
using System.Collections;

namespace Final.BasicLogicLayer
{
    /// <summary>
    /// Esta clase provee de funciones para enviar y obtener valores de la capa de acceso a datos (DataAccessLayer)
    /// </summary>
    public class BasicLogic
    {
        /// <summary>
        /// Función para guardar los registros en la base de datos
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
        /// <returns>Retorna true si se ha guardado correctamente</returns>
        public bool SaveItems(string fabricante, string modelo, string matricula, decimal precio, decimal velocidad, int alcance, string pais, string tipo, Image img)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddItemsToTable(fabricante, modelo, matricula, precio, velocidad, alcance, pais, tipo, img);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// Función para actualizar y modificar los registros de la base de datos
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
        /// <returns>Retorna true si se han modificado correctamente</returns>
        public bool UpdateItems(string fabricante, string modelo, string matricula, decimal precio, decimal velocidad, int alcance, string pais, string tipo, Image img)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateItemsToTable(fabricante, modelo, matricula, precio, velocidad, alcance, pais, tipo, img);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// Función para borrar o eliminar registros de la base de datos, con la ayuda de una función que toma como parámetro de entrada la clave primaria.
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>Retorna true si el registro seleccionado ha sido eliminado con éxito</returns>
        public bool DeleteItems(string matricula)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTable(matricula);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Función para obtener todos los valores de la tabla, empleando una función asociada de lectura de valores.
        /// </summary>
        /// <returns>Retorna un resultado con todos los registros recuperados de la base de datos</returns>
        public DataTable GetItems()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadItemsTable();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Función para aumentar el tamaño máximo permitido para las imágenes guardadas, mediante una función que lanza una consulta contra la base de datos.
        /// </summary>
        public void IncreaseData()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AllowBigDataTable();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void IncreaseDataUsers()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AllowBigDataTableUser();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void IncreaseDataMembers()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AllowBigDataTableMember();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void IncreaseDataNews()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AllowBigDataTableNews();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void IncreaseDataLicense()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AllowBigDataTableLicense();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ClearDatabase()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.ClearTable();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public bool SaveEmails(string correo, string password)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddItemsToTableUsers(correo, password);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        public List<string> GetEmails()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadEmails();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetPasswords()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPasswords();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public bool SaveMembers(string correo, string password, string nombre, int codigo, string nacionalidad, string birthdate, string propiedades, string licencias, int miembrodesde, string distinciones, Image img)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddItemsToTableMembers(correo, password, nombre, codigo, nacionalidad, birthdate, propiedades, licencias, miembrodesde, distinciones, img);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public List<string> GetCorreo()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadCorreo();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetPass()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPass();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetNombre()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNombre();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetCodigo()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadCodigo();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetNacionalidad()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNacionalidad();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetBirthdate()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadBirthdate();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetPropiedades()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPropiedades();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetLicencias()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadLicencias();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetMiembrodesde()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadMiembrodesde();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetDistinciones()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadDistinciones();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public Image GetFoto()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadFoto();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public bool DeleteUsers(string correo)
        {
            correo = UserControlPortada.txtEmail.Text;
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableUsers(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateMembers(string correo, string password, string nombre, int codigo, string nacionalidad, string birthdate, string propiedades, string licencias, int miembrodesde, string distinciones, Image img)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateMembersToTable(correo, password, nombre, codigo, nacionalidad, birthdate, propiedades, licencias, miembrodesde, distinciones, img);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateUsers(string correo, string password)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateUsersToTable(correo, password);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool DeleteUsuarios(string correo)
        {
            correo = UserControlPortada.txtEmailLogin.Text;
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableUsuarios(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool DeleteMembers(string correo)
        {
            correo = UserControlPortada.txtEmailLogin.Text;
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableMembers(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetLastCodigo()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadLastCodigo();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public DataTable GetNews()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadItemsTableNews();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetFabricante()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadFabricante();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetModelo()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadModelo();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetMatricula()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadMatricula();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetTipo()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadTipo();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetPrecio()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPrecio();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetPais()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPais();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetVelocidad()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadVelocidad();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetAlcance()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlcance();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public Image GetFotoAvion()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadFotoAvion();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public DataTable GetMembers()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadMembers();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public DataTable GetMembersByCode()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadMembersByCode();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public DataTable GetMembersByEmail()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadMembersByEmail();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public bool DeleteUsersDGV(string correo)
        {
            correo = FormDGV.dgvMembers.Rows[FormDGV.GetIndex()].Cells[0].Value.ToString();
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableUsuariosDGV(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool DeleteVotersDGV(string correo)
        {
            correo = FormDGV.dgvMembers.Rows[FormDGV.GetIndex()].Cells[0].Value.ToString();
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableVotersDGV(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool DeleteMembersDGV(string correo)
        {
            correo = FormDGV.dgvMembers.Rows[FormDGV.GetIndex()].Cells[0].Value.ToString();
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableMembersDGV(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public void ResetUsersDGV()
        {           
            try
            {
                DataAccess dal = new DataAccess();
                dal.ResetTableUsuariosDGV();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ResetMembersDGV()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.ResetFromTableMembersDGV();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ResetVotersDGV()
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.ResetTableVotersDGV();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public List<string> FindCorreo()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.SearchCorreo();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> FindPass()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.SearchPass();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetAdminPass()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAdminPass();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public Image GetFotoDGV()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadFotoDGV();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetPassword()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPassword();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public bool ChangePasswordMembers(string password)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdatePasswordMembers(password);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool ChangePasswordUsers(string password)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdatePasswordUsers(password);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public DataTable GetLicenses()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadItemsTableLicenses();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
      
        public List<string> GetLicenciasNames()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadLicenciasNames();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public List<string> GetAlumnos(string nombre)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnos(nombre);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosPPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosPPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosULM()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosULM();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosRPAS()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosRPAS();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosHPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosHPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosAFL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosAFL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosCPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosCPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosATPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosATPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosBPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosBPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosSPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosSPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetAlumnosFI()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlumnosFI();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public bool UpdateStudentsPPL(string alumnosPPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentPPL(alumnosPPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsULM(string alumnosULM)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentULM(alumnosULM);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsRPAS(string alumnosRPAS)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentRPAS(alumnosRPAS);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsHPL(string alumnosHPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentHPL(alumnosHPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsAFL(string alumnosAFL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentAFL(alumnosAFL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsCPL(string alumnosCPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentCPL(alumnosCPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsATPL(string alumnosATPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentATPL(alumnosATPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsBPL(string alumnosBPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentBPL(alumnosBPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsSPL(string alumnosSPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentSPL(alumnosSPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public bool UpdateStudentsFI(string alumnosFI)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.AddStudentFI(alumnosFI);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public decimal GetPrecioMillon()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPrecioMillon();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public bool UpdateLicencias(string lugar, int precio, string descripcion, Image img)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateLicenses(lugar, precio, descripcion, img);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public void SaveVoters(string correo)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AddItemsToTableVoters(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public List<string> GetVoters()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadVoters();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public bool DeleteVoters(string correo)
        {
            correo = UserControlPortada.txtEmailLogin.Text;
            try
            {
                DataAccess dal = new DataAccess();
                return dal.DeleteFromTableVoters(correo);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaPPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaPPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaPPL(int notaPPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaPPL(notaPPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaULM()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaULM();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaULM(int notaULM)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaULM(notaULM);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaRPAS()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaRPAS();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaRPAS(int notaRPAS)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaRPAS(notaRPAS);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaHPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaHPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaHPL(int notaHPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaHPL(notaHPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaAFL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaAFL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaAFL(int notaAFL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaAFL(notaAFL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaCPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaCPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaCPL(int notaCPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaCPL(notaCPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaATPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaATPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaATPL(int notaATPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaATPL(notaATPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaBPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaBPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaBPL(int notaBPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaBPL(notaBPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaSPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaSPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaSPL(int notaSPL)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaSPL(notaSPL);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public int GetNotaFI()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadNotaFI();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public bool ChangeNotaFI(int notaFI)
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.UpdateNotaFI(notaFI);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        public decimal SumPPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumPPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountPPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountPPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumULM()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumULM();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountULM()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountULM();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumRPAS()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumRPAS();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountRPAS()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountRPAS();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumHPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumHPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountHPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountHPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumAFL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumAFL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountAFL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountAFL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumCPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumCPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountCPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountCPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumATPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumATPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountATPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountATPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumBPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumBPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountBPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountBPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumSPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumSPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountSPL()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountSPL();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal SumFI()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarSumFI();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal CountFI()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.StarCountFI();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public void ChangeMarkPPL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkPPL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkULM(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkULM(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkRPAS(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkRPAS(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkHPL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkHPL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkAFL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkAFL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkCPL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkCPL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkATPL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkATPL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkBPL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkBPL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkSPL(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkSPL(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public void ChangeMarkFI(decimal puntuacion)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateMarkFI(puntuacion);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
            }
        }
        public string GetModelos()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadModelos();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetFabricanteSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadFabricanteSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetModeloSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadModeloSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetMatriculaSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadMatriculaSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public decimal GetPrecioSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPrecioSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public decimal GetVelocidadSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadVelocidadSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (decimal)result;
            }
        }
        public int GetAlcanceSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadAlcanceSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return (int)result;
            }
        }
        public string GetPaisSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadPaisSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public string GetTipoSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadTipoSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public Image GetFotoSearch()
        {
            try
            {
                DataAccess dal = new DataAccess();
                return dal.ReadFotoSearch();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
    }
}
