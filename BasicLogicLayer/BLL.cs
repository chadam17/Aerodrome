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
    public class BLL
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
        public bool SaveItems(string fabricante,string modelo, string matricula, decimal precio, decimal velocidad, int alcance, string pais, string tipo, Image img)
        {
            try
            {
                DataAccess objdal = new DataAccess();
                return objdal.AddItemsToTable(fabricante,modelo,matricula,precio,velocidad,alcance,pais,tipo,img);
            } catch (Exception ex)
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
                DataAccess objdal = new DataAccess();
                return objdal.UpdateItemsToTable(fabricante, modelo, matricula, precio, velocidad, alcance, pais, tipo, img);
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
                DataAccess objdal = new DataAccess();
                return objdal.DeleteFromTable(matricula);
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
                DataAccess objdal = new DataAccess();
                return objdal.ReadItemsTable();
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
                DataAccess objdal = new DataAccess();
                objdal.AllowBigDataTable();
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
                DataAccess objdal = new DataAccess();
                return objdal.AddItemsToTableUsers(correo, password);
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
                DataAccess objdal = new DataAccess();
                return objdal.ReadEmails();
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
                DataAccess objdal = new DataAccess();
                return objdal.ReadPasswords();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
    }
}
