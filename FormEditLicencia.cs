using Final.BasicLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class FormEditLicencia : Form
    {
        public FormEditLicencia()
        {
            InitializeComponent();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void FormEditLicencia_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormEditLicencia_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormEditLicencia_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnCancelarEditLicencia_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModEditLicencia_Click(object sender, EventArgs e)
        {
            BasicLogic bll = new BasicLogic();
            try
            {
                if ((String.IsNullOrEmpty(txtLugarEditLicencia.Text)) || (String.IsNullOrEmpty(txtDescripcionEdit.Text)) || (String.IsNullOrEmpty(numPrecioEditLicencia.Value.ToString())))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    Close();
                }
                else
                {
                    string lugar = txtLugarEditLicencia.Text;
                    int precio = (int)numPrecioEditLicencia.Value;
                    string descripcion = txtDescripcionEdit.Text;
                    Image pict = pbLicenciaEdit.Image;
                    if (bll.UpdateLicencias(lugar,precio,descripcion,pict))
                    {
                        MessageBox.Show("Modificada correctamente");
                        Close();
                        FormInicio.SetActivePanel(FormInicio.UCLicencias);
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

        private void pbLicenciaEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pbLicenciaEdit.Image = image;
            }
        }
    }
}
