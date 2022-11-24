using System;
using System.Drawing;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    /// <summary>
    /// Clase para el formulario modal de adición de aeronaves
    /// </summary>
    public partial class FormAdd : Form
    {
        /// <summary>
        /// Instancia del formulario de adición
        /// </summary>
        public FormAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Función que obtiene los valores de la base de datos al inicializar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAdd_Load(object sender, EventArgs e)
        {
            BasicLogic bll = new BasicLogic();
            bll.GetItems();
        }
        /// <summary>
        /// Evento del botón de agregado, que realiza la validación de la entrada de datos y los añade a la base de datos si se han introducido correctamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {           
            BasicLogic bll = new BasicLogic();
            try
            {
                if ((String.IsNullOrEmpty(txtFabricante.Text)) || (String.IsNullOrEmpty(txtModelo.Text)) || (String.IsNullOrEmpty(txtMatricula.Text)) || (String.IsNullOrEmpty(numPrecio.Value.ToString())) || (String.IsNullOrEmpty(numVelocidad.Value.ToString())) || (String.IsNullOrEmpty(numAlcance.Value.ToString())) || (String.IsNullOrEmpty(comboPais.SelectedItem.ToString())) || (String.IsNullOrEmpty(comboTipo.SelectedItem.ToString())))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    Close();
                }
                else
                {
                    string fab = txtFabricante.Text;
                    string mo = txtModelo.Text;
                    string ma = txtMatricula.Text;
                    decimal pr = (decimal)numPrecio.Value*1000000;
                    decimal vel = (decimal)numVelocidad.Value;
                    int alc = (int)numAlcance.Value;
                    string pa = comboPais.SelectedItem.ToString();
                    string t = comboTipo.SelectedItem.ToString();
                                    
                    if (bll.SaveItems(txtFabricante.Text, txtModelo.Text, txtMatricula.Text, pr, (decimal)numVelocidad.Value, (int)numAlcance.Value, comboPais.SelectedItem.ToString(), comboTipo.SelectedItem.ToString(), pictFoto.Image))
                    {
                        MessageBox.Show("Guardado correctamente"); 
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido guardar");
                    }
                }
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
            catch (OverflowException oex)
            {
                MessageBox.Show("Precio máximo superado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Evento del botón de cancelar la subida de un nuevo avión, que nos devuelve al formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Evento del PictureBox del formulario de adición. Abre un cuadro de diálogo para seleccionar una imagen del sistema de ficheros local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictFoto_Click(object sender, EventArgs e)
        {
            string FileName = null;
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pictFoto.Image = image;
            }
        }

        /// <summary>
        /// Gestión del evento de cambio de valor del NumericUpDown, para que acepte puntos y comas como separador decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numPrecio_ValueChanged(object sender, EventArgs e)
        {
                numPrecio.Text = numPrecio.Text.Replace(',', '.');
        }
        private bool mouseDown;
        private Point lastLocation;
        private void FormAdd_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormAdd_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
