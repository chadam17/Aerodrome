using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    /// <summary>
    /// Clase asociada al formulario de edición, que toma los valores del registro seleccionado y los muestra para poder ser modificados
    /// </summary>
    public partial class FormEdit : Form
    {
        /// <summary>
        /// Instancia del formulario de edición
        /// </summary>
        public FormEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento del botón de cancelar la edición, que sencillamente cierra el formulario de edición y devuelve al formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarEdit_Click(object sender, EventArgs e)
        {
            Close();
            FormInicio.SetActivePanel(FormInicio.UCAeronaves);
        }
        
        /// <summary>
        /// Evento del botón de modificar avión. Acepta los nuevos valores y realiza la actualización de los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMod_Click(object sender, EventArgs e)
        {
            BasicLogic bll = new BasicLogic();
            try
            {
                if ((String.IsNullOrEmpty(txtFabricanteEdit.Text)) || (String.IsNullOrEmpty(txtModeloEdit.Text)) || (String.IsNullOrEmpty(txtMatriculaEdit.Text)) || (String.IsNullOrEmpty(numPrecioEdit.Value.ToString())) || (String.IsNullOrEmpty(numVelocidadEdit.Value.ToString())) || (String.IsNullOrEmpty(numAlcanceEdit.Value.ToString())) || (String.IsNullOrEmpty(comboPaisEdit.SelectedItem.ToString())) || (String.IsNullOrEmpty(comboTipoEdit.SelectedItem.ToString())))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    Close();
                }
                else
                {
                    string fab = txtFabricanteEdit.Text;
                    string mo = txtModeloEdit.Text;
                    string ma = txtMatriculaEdit.Text;
                    decimal pr = (decimal)numPrecioEdit.Value*1000000;
                    decimal vel = (decimal)numVelocidadEdit.Value;
                    int alc = (int)numAlcanceEdit.Value;
                    string pa = comboPaisEdit.SelectedItem.ToString();
                    string t = comboTipoEdit.SelectedItem.ToString();
                    if (bll.UpdateItems(txtFabricanteEdit.Text, txtModeloEdit.Text, txtMatriculaEdit.Text, pr, (decimal)numVelocidadEdit.Value, (int)numAlcanceEdit.Value, comboPaisEdit.SelectedItem.ToString(), comboTipoEdit.SelectedItem.ToString(), pictFotoEdit.Image))
                    {
                        UserControlAeronaves.lbFabricante.Text = bll.GetFabricante().ElementAt(0);
                        UserControlAeronaves.lbModelo.Text = bll.GetModelo().ElementAt(0);
                        UserControlAeronaves.lbMatricula.Text = bll.GetMatricula().ElementAt(0);
                        UserControlAeronaves.lbTipo.Text = bll.GetTipo().ElementAt(0);
                        decimal millon = bll.GetPrecioMillon() / 1000000;
                        UserControlAeronaves.lbPrecio.Text = Convert.ToString(millon);                       
                        UserControlAeronaves.lbPais.Text = bll.GetPais().ElementAt(0);
                        UserControlAeronaves.lbVelocidad.Text = bll.GetVelocidad().ElementAt(0);
                        UserControlAeronaves.lbAlcance.Text = bll.GetAlcance().ElementAt(0);
                        UserControlAeronaves.pictIcon.Image = bll.GetFotoAvion();
                        MessageBox.Show("Modificado correctamente");
                        Close();
                        FormInicio.SetActivePanel(FormInicio.UCAeronaves);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar");
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
        /// Evento de ratón del PictureBox del formulario de edición. Abre un cuadro de diálogo para seleccionar una imagen del sistema de ficheros local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictFotoEdit_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pictFotoEdit.Image = image;
            }
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            BasicLogic bll = new BasicLogic();
            bll.GetItems();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void FormEdit_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormEdit_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
