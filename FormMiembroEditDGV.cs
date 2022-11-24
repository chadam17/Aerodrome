using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class FormMiembroEditDGV : Form
    {
        public BasicLogic bll = new BasicLogic();
        public FormMiembroEditDGV()
        {
            InitializeComponent();
        }

        private void FormMiembroEditDGV_Load(object sender, EventArgs e)
        {
            txtPassEditDGV.UseSystemPasswordChar = true;
        }

        private void btnCancelarMiembroEditDGV_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictFotoMEditDGV_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pictFotoMEditDGV.Image = image;
            }
        }

        private void btnCancelarMiembroEditDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }
        private bool mouseDown;
        private Point lastLocation;

        private void FormMiembroEditDGV_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormMiembroEditDGV_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormMiembroEditDGV_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnAgregarMEditDGV_Click(object sender, EventArgs e)
        {
            try
            {
                if ((String.IsNullOrEmpty(txtCorreoEditDGV.Text)) || (String.IsNullOrEmpty(txtPassEditDGV.Text)) || (String.IsNullOrEmpty(txtNombreMEditDGV.Text)) || (String.IsNullOrEmpty(numCodigoMEditDGV.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadMEditDGV.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateMEditDGV.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesMEditDGV.Text)) || (String.IsNullOrEmpty(numMiembroMEditDGV.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesMEditDGV.Text)))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    Close();
                }
                else
                {
                    if (!txtCorreoEditDGV.Text.Contains("@nimboaircraft.com"))
                    {
                        MessageBox.Show("El correo electrónico suministrado no pertenece a la plataforma");
                        Close();
                    }
                    else
                    {
                        if (txtPassEditDGV.Text.Contains(" "))
                        {
                            MessageBox.Show("La contraseña no puede contener espacios en blanco");
                            Close();
                        }
                        else
                        {
                            string corr = txtCorreoEditDGV.Text;
                            string pass = txtPassEditDGV.Text;
                            string nom = txtNombreMEditDGV.Text;
                            int cod = (int)numCodigoMEditDGV.Value;
                            string nac = comboNacionalidadMEditDGV.SelectedItem.ToString();
                            string birth = birthdateMEditDGV.Value.ToString();
                            string prop = txtPropiedadesMEditDGV.Text;
                            List<string> licencias = new List<string>();
                            for (int i = 0; i < checkedListBoxLicenciasMEditDGV.CheckedItems.Count; i++)
                            {
                                licencias.Add(checkedListBoxLicenciasMEditDGV.CheckedItems[i].ToString());
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
                            int mdes = (int)numMiembroMEditDGV.Value;
                            string dist = txtDistincionesMEditDGV.Text;
                            if (bll.UpdateUsers(txtCorreoEditDGV.Text, txtPassEditDGV.Text))
                            {

                            }
                            if (bll.UpdateMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, pictFotoMEditDGV.Image))
                            {
                                MessageBox.Show("Modificado correctamente");
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

        private void btnAgregarMEditDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if ((String.IsNullOrEmpty(txtCorreoEditDGV.Text)) || (String.IsNullOrEmpty(txtPassEditDGV.Text)) || (String.IsNullOrEmpty(txtNombreMEditDGV.Text)) || (String.IsNullOrEmpty(numCodigoMEditDGV.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadMEditDGV.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateMEditDGV.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesMEditDGV.Text)) || (String.IsNullOrEmpty(numMiembroMEditDGV.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesMEditDGV.Text)))
                    {
                        DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                        Close();
                    }
                    else
                    {
                        if (!txtCorreoEditDGV.Text.Contains("@nimboaircraft.com"))
                        {
                            MessageBox.Show("El correo electrónico suministrado no pertenece a la plataforma");
                            Close();
                        }
                        else
                        {
                            if (txtPassEditDGV.Text.Contains(" "))
                            {
                                MessageBox.Show("La contraseña no puede contener espacios en blanco");
                                Close();
                            }
                            else
                            {
                                string corr = txtCorreoEditDGV.Text;
                                string pass = txtPassEditDGV.Text;
                                string nom = txtNombreMEditDGV.Text;
                                int cod = (int)numCodigoMEditDGV.Value;
                                string nac = comboNacionalidadMEditDGV.SelectedItem.ToString();
                                string birth = birthdateMEditDGV.Value.ToString();
                                string prop = txtPropiedadesMEditDGV.Text;
                                List<string> licencias = new List<string>();
                                for (int i = 0; i < checkedListBoxLicenciasMEditDGV.CheckedItems.Count; i++)
                                {
                                    licencias.Add(checkedListBoxLicenciasMEditDGV.CheckedItems[i].ToString());
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
                                int mdes = (int)numMiembroMEditDGV.Value;
                                string dist = txtDistincionesMEditDGV.Text;
                                if (bll.UpdateUsers(txtCorreoEditDGV.Text, txtPassEditDGV.Text))
                                {

                                }
                                if (bll.UpdateMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, pictFotoMEditDGV.Image))
                                {
                                    MessageBox.Show("Modificado correctamente");
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
        }

        private void btEyeFormMiembroEditDGV_Click(object sender, EventArgs e)
        {
            btEyeFormMiembroEditDGV.Visible = false;
            btEyeClosedFormMiembroEditDGV.Location = new Point(889, 81);
            btEyeClosedFormMiembroEditDGV.Visible = true;
            txtPassEditDGV.UseSystemPasswordChar = false;
        }

        private void btEyeClosedFormMiembroEditDGV_Click(object sender, EventArgs e)
        {
            btEyeClosedFormMiembroEditDGV.Visible = false;
            btEyeFormMiembroEditDGV.Visible = true;
            txtPassEditDGV.UseSystemPasswordChar = true;
        }
    }
}
