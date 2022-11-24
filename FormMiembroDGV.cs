using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class FormMiembroDGV : Form
    {
        public BasicLogic bll = new BasicLogic();
        public FormMiembroDGV()
        {
            InitializeComponent();
        }

        private void FormMiembroDGV_Load(object sender, EventArgs e)
        {
            txtPassDGV.UseSystemPasswordChar = true;
        }

        private void btnCancelarMiembroDGV_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictFotoMDGV_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pictFotoMDGV.Image = image;
            }
        }

        private void btnAgregarMDGV_Click(object sender, EventArgs e)
        {
            try
            {
                if ((String.IsNullOrEmpty(txtCorreoDGV.Text)) || (String.IsNullOrEmpty(txtPassDGV.Text)) || (String.IsNullOrEmpty(txtNombreMDGV.Text)) || (String.IsNullOrEmpty(numCodigoMDGV.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadMDGV.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateMDGV.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesMDGV.Text)) || (String.IsNullOrEmpty(numMiembroMDGV.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesMDGV.Text)))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    Close();
                }
                else
                {
                    if (!txtCorreoDGV.Text.Contains("@nimboaircraft.com"))
                    {
                        MessageBox.Show("El correo electrónico suministrado no pertenece a la plataforma");
                        Close();
                    }
                    else
                    {
                        if (txtPassDGV.Text.Contains(" "))
                        {
                            MessageBox.Show("La contraseña no puede contener espacios en blanco");
                            Close();
                        }
                        else
                        {
                            string corr = txtCorreoDGV.Text;
                            string pass = txtPassDGV.Text;
                            string nom = txtNombreMDGV.Text;
                            int cod = (int)numCodigoMDGV.Value;
                            string nac = comboNacionalidadMDGV.SelectedItem.ToString();
                            string birth = birthdateMDGV.Value.ToString();
                            string prop = txtPropiedadesMDGV.Text;
                            List<string> licencias = new List<string>();
                            for (int i = 0; i < checkedListBoxLicenciasMDGV.CheckedItems.Count; i++)
                            {
                                licencias.Add(checkedListBoxLicenciasMDGV.CheckedItems[i].ToString());
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
                            int mdes = (int)numMiembroMDGV.Value;
                            string dist = txtDistincionesMDGV.Text;
                            if (bll.SaveEmails(txtCorreoDGV.Text, txtPassDGV.Text))
                            {

                            }
                            if (bll.SaveMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, pictFotoMDGV.Image))
                            {
                                MessageBox.Show("Registrado correctamente");
                                UserControlPortada.emails = bll.GetEmails();
                                UserControlPortada.passwords = bll.GetPasswords();
                                FormDGV.refreshDGV();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No hemos podido registrar tus datos");
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
            catch (OverflowException oex)
            {
                MessageBox.Show("Límite superado");
                Close();
            }
            catch (DuplicateKeyException sqle)
            {
                MessageBox.Show("Este correo electrónico ya está registrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelarMiembroDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }

        private void btnAgregarMDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if ((!txtCorreoDGV.Text.EndsWith("@nimboaircraft.com")) || (txtCorreoDGV.Text.Contains(" ")) || (String.IsNullOrEmpty(txtCorreoDGV.Text)) || (String.IsNullOrEmpty(txtPassDGV.Text)) || (String.IsNullOrEmpty(txtNombreMDGV.Text)) || (String.IsNullOrEmpty(numCodigoMDGV.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadMDGV.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateMDGV.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesMDGV.Text)) || (String.IsNullOrEmpty(numMiembroMDGV.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesMDGV.Text)))
                    {
                        DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                        Close();
                    }
                    else
                    {
                        string corr = txtCorreoDGV.Text;
                        string pass = txtPassDGV.Text;
                        string nom = txtNombreMDGV.Text;
                        int cod = (int)numCodigoMDGV.Value;
                        string nac = comboNacionalidadMDGV.SelectedItem.ToString();
                        string birth = birthdateMDGV.Value.ToString();
                        string prop = txtPropiedadesMDGV.Text;
                        List<string> licencias = new List<string>();
                        for (int i = 0; i < checkedListBoxLicenciasMDGV.CheckedItems.Count; i++)
                        {
                            licencias.Add(checkedListBoxLicenciasMDGV.CheckedItems[i].ToString());
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
                        int mdes = (int)numMiembroMDGV.Value;
                        string dist = txtDistincionesMDGV.Text;
                        if (bll.SaveEmails(txtCorreoDGV.Text, txtPassDGV.Text))
                        {
                            
                        }
                        if (bll.SaveMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, pictFotoMDGV.Image))
                        {
                            MessageBox.Show("Registrado correctamente");
                            UserControlPortada.emails = bll.GetEmails();
                            UserControlPortada.passwords = bll.GetPasswords();
                            FormDGV.refreshDGV();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No hemos podido registrar tus datos");
                        }
                    }
                }
                catch (NullReferenceException nex)
                {
                    MessageBox.Show("Debes rellenar todos los campos");
                }
                catch (OverflowException oex)
                {
                    MessageBox.Show("Límite superado");
                    Close();
                }
                catch (DuplicateKeyException sqle)
                {
                    MessageBox.Show("Este correo electrónico ya está registrado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private bool mouseDown;
        private Point lastLocation;
        private void FormMiembroDGV_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormMiembroDGV_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormMiembroDGV_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btEyeFormMiembroDGV_Click(object sender, EventArgs e)
        {
            btEyeFormMiembroDGV.Visible = false;
            btEyeClosedFormMiembroDGV.Location = new Point(889, 81);
            btEyeClosedFormMiembroDGV.Visible = true;
            txtPassDGV.UseSystemPasswordChar = false;
        }

        private void btEyeClosedFormMiembroDGV_Click(object sender, EventArgs e)
        {
            btEyeClosedFormMiembroDGV.Visible = false;
            btEyeFormMiembroDGV.Visible = true;
            txtPassDGV.UseSystemPasswordChar = true;
        }
    }
}
