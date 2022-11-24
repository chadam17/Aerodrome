using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class FormMiembro : Form
    {
        public BasicLogic bll = new BasicLogic();
        public FormMiembro()
        {
            InitializeComponent();
        }

        private void btnCancelarMiembro_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictFotoM_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.RestoreDirectory = true;
            opendlg.Filter = "All picture files (*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(opendlg.FileName);
                pictFotoM.Image = image;
            }
        }

        private void btnAgregarM_Click(object sender, EventArgs e)
        {
            try
            {
                if ((String.IsNullOrEmpty(txtNombreM.Text)) || (String.IsNullOrEmpty(numCodigoM.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadM.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateM.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesM.Text)) || (String.IsNullOrEmpty(numMiembroM.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesM.Text)))
                {
                    DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                    bll.DeleteUsers(UserControlPortada.txtEmail.Text);
                    Close();
                }
                else
                {
                    string corr = UserControlPortada.txtEmail.Text;
                    string pass = UserControlPortada.txtPass.Text;
                    string nom = txtNombreM.Text;
                    int cod = (int)numCodigoM.Value;
                    string nac = comboNacionalidadM.SelectedItem.ToString();
                    string birth = birthdateM.Value.ToString();
                    string prop = txtPropiedadesM.Text;
                    List<string> licencias = new List<string>();
                    for (int i = 0; i < checkedListBoxLicenciasM.CheckedItems.Count; i++)
                    {
                        licencias.Add(checkedListBoxLicenciasM.CheckedItems[i].ToString());
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
                    int mdes = (int)numMiembroM.Value;
                    string dist = txtDistincionesM.Text;
                    UserControlPortada.emails.Add(corr);
                    UserControlPortada.passwords.Add(pass);
                    if (bll.SaveEmails(UserControlPortada.txtEmail.Text, UserControlPortada.txtPass.Text))
                    {
                        UserControlPortada.lbSuscribete.Visible = true;
                    }
                    if (bll.SaveMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, pictFotoM.Image))
                    {
                        MessageBox.Show("Registrado correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No hemos podido registrar tus datos");
                        bll.DeleteUsers(UserControlPortada.txtEmail.Text);
                    }
                }
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show("Debes rellenar todos los campos");
                bll.DeleteUsers(UserControlPortada.txtEmail.Text);
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

        private void btnCancelarMiembro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }

        private void btnAgregarM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if ((String.IsNullOrEmpty(txtNombreM.Text)) || (String.IsNullOrEmpty(numCodigoM.Value.ToString())) || (String.IsNullOrEmpty(comboNacionalidadM.SelectedItem.ToString())) || (String.IsNullOrEmpty(birthdateM.Value.ToString())) || (String.IsNullOrEmpty(txtPropiedadesM.Text)) || (String.IsNullOrEmpty(numMiembroM.Value.ToString())) || (String.IsNullOrEmpty(txtDistincionesM.Text)))
                    {
                        DialogResult dt = MessageBox.Show("Debes rellenar todos los campos");
                        bll.DeleteUsers(UserControlPortada.txtEmail.Text);
                        Close();
                    }
                    else
                    {
                        string corr = UserControlPortada.txtEmail.Text;
                        string pass = UserControlPortada.txtPass.Text;
                        string nom = txtNombreM.Text;
                        int cod = (int)numCodigoM.Value;
                        string nac = comboNacionalidadM.SelectedItem.ToString();
                        string birth = birthdateM.Value.ToString();
                        string prop = txtPropiedadesM.Text;
                        List<string> licencias = new List<string>();
                        for (int i = 0; i < checkedListBoxLicenciasM.CheckedItems.Count; i++)
                        {
                            licencias.Add(checkedListBoxLicenciasM.CheckedItems[i].ToString());
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
                        int mdes = (int)numMiembroM.Value;
                        string dist = txtDistincionesM.Text;
                        if (bll.SaveEmails(UserControlPortada.txtEmail.Text, UserControlPortada.txtPass.Text))
                        {
                            UserControlPortada.lbSuscribete.Visible = true;
                        }
                        if (bll.SaveMembers(corr, pass, nom, cod, nac, birth, prop, listado, mdes, dist, pictFotoM.Image))
                        {
                            MessageBox.Show("Registrado correctamente");
                            UserControlPortada.emails = bll.GetEmails();
                            UserControlPortada.passwords = bll.GetPasswords();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No hemos podido registrar tus datos");
                            bll.DeleteUsers(UserControlPortada.txtEmail.Text);
                        }
                    }
                }
                catch (NullReferenceException nex)
                {
                    MessageBox.Show("Debes rellenar todos los campos");
                    bll.DeleteUsers(UserControlPortada.txtEmail.Text);
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
        private void FormMiembro_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormMiembro_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormMiembro_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
