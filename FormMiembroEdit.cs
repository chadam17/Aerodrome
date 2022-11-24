using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class FormMiembroEdit : Form
    {
        public FormMiembroEdit()
        {
            InitializeComponent();
        }

        private void btnCancelarMiembroEdit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModM_Click(object sender, EventArgs e)
        {
            BasicLogic bll = new BasicLogic();
            try
            {
                if ((String.IsNullOrEmpty(txtNombreMEdit.Text)) || (String.IsNullOrEmpty(numCodigoMEdit.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadMEdit.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateMEdit.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesMEdit.Text)) || (String.IsNullOrEmpty(numMiembroMEdit.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesMEdit.Text)))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    Close();
                }
                else
                {
                    string corr = UserControlPortada.txtEmailLogin.Text;
                    string pass = UserControlPortada.txtPassLogin.Text;
                    string nom = txtNombreMEdit.Text;
                    int cod = (int)numCodigoMEdit.Value;
                    string nac = comboNacionalidadMEdit.SelectedItem.ToString();
                    string birth = birthdateMEdit.Value.ToString();
                    string prop = txtPropiedadesMEdit.Text;
                    List<string> licencias = new List<string>();
                    for (int i = 0; i < checkedListBoxLicenciasMEdit.CheckedItems.Count; i++)
                    {
                        licencias.Add(checkedListBoxLicenciasMEdit.CheckedItems[i].ToString());
                    }
                    string lista = "";
                    for (int i = 0; i < licencias.Count; i++)
                    {
                        if (licencias.Count == 1)
                        {
                            lista += licencias.ElementAt(0);
                            break;
                        }
                        lista += (licencias.ElementAt(i) + "; ");
                        if (i == licencias.Count - 2)
                        {
                            i++;
                            lista += licencias.ElementAt(i);
                        }
                    }
                    string listado = lista.Replace(" ;", ";");
                    int mdes = (int)numMiembroMEdit.Value;
                    string dist = txtDistincionesMEdit.Text;
                    Image img = pictFotoMEdit.Image;
                    if (bll.UpdateMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, img))
                    {
                        UserControlMembresia.lbNombre.Text = bll.GetNombre().ElementAt(0);
                        UserControlMembresia.lbCodigo.Text = bll.GetCodigo().ElementAt(0);
                        UserControlMembresia.lbNacionalidad.Text = bll.GetNacionalidad().ElementAt(0);
                        string[] bdate = new string[10];
                        char[] date = bll.GetBirthdate().ElementAt(0).ToCharArray();
                        for (int i=0; i < 10; i++)
                        {
                            bdate[i] = date[i].ToString();
                        }
                        UserControlMembresia.lbFechaNac.Text = bdate[0] + bdate[1] + bdate[2] + bdate[3] + bdate[4] + bdate[5] + bdate[6] + bdate[7] + bdate[8] + bdate[9];
                        UserControlMembresia.lbPropiedades.Text = bll.GetPropiedades().ElementAt(0);
                        UserControlMembresia.lbLicencias.Text = bll.GetLicencias().ElementAt(0);
                        UserControlMembresia.lbMiembro.Text = bll.GetMiembrodesde().ElementAt(0);
                        UserControlMembresia.lbDistinciones.Text = bll.GetDistinciones().ElementAt(0);
                        UserControlMembresia.pictIconM.Image = bll.GetFoto();
                        MessageBox.Show("Modificado correctamente");
                        Close();                      
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

        private void pictFotoMEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pictFotoMEdit.Image = image;
            }
        }
        private bool mouseDown;
        private Point lastLocation;
        private void FormMiembroEdit_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormMiembroEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormMiembroEdit_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
