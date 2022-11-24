using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class UserControlPortada : UserControl
    {
        public static List<string> emails = new List<string>();
        public static List<string> passwords = new List<string>();
        public BasicLogic bll = new BasicLogic();
        public static bool isClicked = false;
        public static bool login = false;
        public FormMiembro fm = new FormMiembro();
        public static string truePass;
        public UserControlPortada()
        {
            InitializeComponent();
            bll.IncreaseDataUsers();
            bll.IncreaseDataMembers();
        }
        private void btSuscribir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text) || (txtEmail.Text == "Correo electrónico"))
            {
                lbFailed.Visible = false;
                lbSuscribete.Visible = false;
                lbPassword.Visible = false;
                lbAviso.Text = "No has introducido ningún email...";
                lbAviso.Visible = true;
            }
            if (String.IsNullOrEmpty(txtPass.Text))
            {
                lbPassword.Text = "No has introducido ninguna contraseña...";
                lbPassword.Visible = true;
            }
            if (txtPass.Text.Contains(" "))
            {
                MessageBox.Show("La contraseña no puede contener espacios en blanco");
            }
            else
            {
                if ((txtEmail.Text.EndsWith("@nimboaircraft.com")) && (!txtEmail.Text.Contains(" ")) && (!String.IsNullOrEmpty(txtPass.Text)) && (txtPass.Text != "Contraseña") && (!txtPass.Text.Contains(" ")))
                {
                    if (!emails.Contains(txtEmail.Text))
                    {
                        lbSuscribete.Visible = false;
                        lbAviso.Visible = false;
                        lbFailed.Visible = false;
                        fm.txtNombreM.Text = "";
                        int num = bll.GetLastCodigo();
                        fm.numCodigoM.Value = num + 1;
                        fm.comboNacionalidadM.SelectedItem = null;
                        fm.birthdateM.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
                        fm.txtPropiedadesM.Text = "";
                        UncheckAllItems();
                        fm.numMiembroM.Value = 1981;
                        fm.txtDistincionesM.Text = "";
                        fm.pictFotoM.Image = Properties.Resources.disquet;
                        fm.ShowDialog();
                    }
                    else
                    {
                        lbAviso.Visible = false;
                        lbAviso.Text = "";
                        lbSuscribete.Visible = false;
                        lbFailed.Visible = true;
                    }
                }
                else
                {
                    string[] correos = bll.GetEmails().ToArray();
                    if (correos.Length == 0)
                    {
                        if ((!txtEmail.Text.EndsWith("@nimboaircraft.com")) || (txtEmail.Text.Contains(" ")))
                        {
                            lbAviso.Text = "Introduce un email válido";
                            lbAviso.Visible = true;
                            lbSuscribete.Visible = false;
                            lbFailed.Visible = false;
                        }
                        if (String.IsNullOrEmpty(txtPass.Text) || (txtPass.Text == "Contraseña"))
                        {
                            lbPassword.Text = "No has introducido ninguna contraseña...";
                            lbPassword.Visible = true;
                        }
                        if ((txtEmail.Text.EndsWith("@nimboaircraft.com")) && (!txtEmail.Text.Contains(" ")) && ((String.IsNullOrEmpty(txtPass.Text) || (txtPass.Text == "Contraseña"))))
                        {
                            lbAviso.Visible = false;
                            lbPassword.Text = "No has introducido ninguna contraseña...";
                            lbPassword.Visible = true;
                        }
                    }
                    else
                    {
                        lbAviso.Visible = false;
                        for (int i = 0; i < correos.Length; i++)
                        {
                            if (correos[i] == txtEmail.Text)
                            {
                                lbAviso.Visible = false;
                                lbSuscribete.Visible = false;
                                lbFailed.Visible = true;
                            }
                            else
                            {
                                if ((correos[i] == txtEmail.Text) && ((String.IsNullOrEmpty(txtPass.Text)) || ((txtPass.Text == "Contraseña"))))
                                {
                                    lbAviso.Visible = false;
                                    lbSuscribete.Visible = false;
                                    lbFailed.Visible = true;
                                }
                                else
                                {
                                    if ((!txtEmail.Text.EndsWith("@nimboaircraft.com")) || (txtEmail.Text.Contains(" ")))
                                    {
                                        lbAviso.Text = "Introduce un email válido";
                                        lbAviso.Visible = true;
                                        lbSuscribete.Visible = false;
                                        lbFailed.Visible = false;
                                    }
                                    if ((txtEmail.Text.EndsWith("@nimboaircraft.com")) && (!txtEmail.Text.Contains(" ")) && ((String.IsNullOrEmpty(txtPass.Text) || (txtPass.Text == "Contraseña"))))
                                    {
                                        lbAviso.Visible = false;
                                        lbPassword.Text = "No has introducido ninguna contraseña...";
                                        lbPassword.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                lbFailed.Visible = false;
                lbSuscribete.Visible = false;
                lbAviso.Visible = false;
                lbPassword.Visible = false;
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
                btEyePortada.Visible = true;
                btEyeClosedPortada.Visible = false;
            }
        }
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Correo electrónico")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Correo electrónico";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
                btEyePortada.Visible = true;
                btEyeClosedPortada.Visible = false;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.Silver;
                txtPass.UseSystemPasswordChar = false;
                btEyePortada.Visible = false;
                btEyeClosedPortada.Visible = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            lbPassword.Visible = false;
        }

        private void UserControlPortada_Load(object sender, EventArgs e)
        {
            emails = bll.GetEmails();
            passwords = bll.GetPasswords(); 
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            panelSign.Visible = false;
            btSuscribir.Visible = false;
            lbAviso.Visible = false;
            lbFailed.Visible = false;
            lbPassword.Visible = false;
            lbRegistro.Visible = false;
            lbSuscribete.Visible = false;
            btLogin.Visible = false;
            panelLogin.Visible = true;
            btCuenta.Visible = true;
            btEyePortada.Visible = true;
            btEyeClosedPortada.Visible = false;
            txtPassLogin.UseSystemPasswordChar = true;
            if (!login)
            {
                btAcceder.Visible = true;
                btCuenta.Visible = true;
            }
            else
            {
                btLogout.Visible = true;
                btDeleteUser.Visible = true;
            }
        }

        private void btLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panelSign.Visible = false;
                btSuscribir.Visible = false;
                lbAviso.Visible = false;
                lbFailed.Visible = false;
                lbPassword.Visible = false;
                lbRegistro.Visible = false;
                lbSuscribete.Visible = false;
                btLogin.Visible = false;
                panelLogin.Visible = true;
                btCuenta.Visible = true;
                btEyePortada.Visible = true;
                btEyeClosedPortada.Visible = false;
                txtPassLogin.UseSystemPasswordChar = true;
                if (!login)
                {
                    btAcceder.Visible = true;
                    btCuenta.Visible = true;
                }
                else
                {
                    btLogout.Visible = true;
                    btDeleteUser.Visible = true;
                }
            }
        }

        private void btCuenta_Click(object sender, EventArgs e)
        {
            panelSign.Visible = true;
            btSuscribir.Visible = true;
            lbAviso.Visible = false;
            lbFailed.Visible = false;
            lbPassword.Visible = false;
            lbRegistro.Visible = true;
            lbSuscribete.Visible = false;
            btLogin.Visible = true;
            panelLogin.Visible = false;
            btCuenta.Visible = false;
            btAcceder.Visible = false;
            lbUserFailed.Visible = false;
            lbEmptyUser.Visible = false;
            lbPassFail.Visible = false;
            lbLoginSuccess.Visible = false;
            btLogout.Visible = false;
            btDeleteUser.Visible = false;
            btEyePortadaLogin.Visible = true;
            btEyeClosedPortadaLogin.Visible = false;
        }

        private void btCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panelSign.Visible = true;
                btSuscribir.Visible = true;
                lbAviso.Visible = false;
                lbFailed.Visible = false;
                lbPassword.Visible = false;
                lbRegistro.Visible = true;
                lbSuscribete.Visible = false;
                btLogin.Visible = true;
                panelLogin.Visible = false;
                btCuenta.Visible = false;
                btAcceder.Visible = false;
                lbUserFailed.Visible = false;
                lbEmptyUser.Visible = false;
                lbPassFail.Visible = false;
                lbLoginSuccess.Visible = false;
                btLogout.Visible = false;
                btDeleteUser.Visible = false;
                btEyePortadaLogin.Visible = true;
                btEyeClosedPortadaLogin.Visible = false;
            }
        }

        private void btAcceder_Click(object sender, EventArgs e)
        {
            emails = bll.GetEmails();
            passwords = bll.GetPasswords();
            isClicked = true;
            try
            {
                if (String.IsNullOrEmpty(txtEmailLogin.Text) || (txtEmailLogin.Text == "Correo electrónico"))
                {
                    lbPassFail.Visible = false;
                    lbLoginSuccess.Visible = false;
                    lbUserFailed.Visible = false;
                    lbEmptyUser.Visible = true;
                }
                else
                    if (!emails.Contains(txtEmailLogin.Text))
                {
                    lbPassFail.Visible = false;
                    lbLoginSuccess.Visible = false;
                    lbEmptyUser.Visible = false;
                    lbUserFailed.Visible = true;
                }
                else
                if (emails.Contains(txtEmailLogin.Text))
                {
                    for (int i = 0; i < emails.Count; i++)
                    {
                        if (emails[i] == txtEmailLogin.Text)
                        {
                            truePass = passwords[i];
                            if (txtPassLogin.Text == truePass)
                            {
                                login = true;
                                txtEmailLogin.ReadOnly = true;
                                txtPassLogin.ReadOnly = true;
                                lbUserFailed.Visible = false;
                                lbEmptyUser.Visible = false;
                                lbPassFail.Visible = false;
                                lbLoginSuccess.Visible = true;
                                UserControlAeronaves.txtSearch.Text = "";
                                FormInicio.UCAeronaves.flow.Controls.Clear();
                                MessageBox.Show("Login realizado con éxito");
                                if (txtEmailLogin.Text == "admin@nimboaircraft.com")
                                {
                                    UserControlAeronaves.btAddPlane.Enabled = true;
                                    UserControlAeronaves.btClear.Enabled = true;
                                    UserControlAeronaves.btEditar.Enabled = true;
                                    UserControlAeronaves.btDelete.Enabled = true;
                                    UserControlMembresia.btAdminUsers.Enabled = true;
                                    UserControlMembresia.btAdminUsers.Visible = true;
                                    UserControlMembresia.btChangePass.Enabled = false;
                                    UserControlMembresia.btChangePass.Visible = false;
                                }
                                else
                                {
                                    UserControlAeronaves.btAddPlane.Enabled = false;
                                    UserControlAeronaves.btClear.Enabled = false;
                                    UserControlAeronaves.btEditar.Enabled = false;
                                    UserControlAeronaves.btDelete.Enabled = false;
                                    UserControlMembresia.btAdminUsers.Enabled = false;
                                    UserControlMembresia.btAdminUsers.Visible = false;
                                    UserControlMembresia.btChangePass.Enabled = true;
                                    UserControlMembresia.btChangePass.Visible = true;
                                }
                                lbLoginSuccess.Visible = false;
                                //Thread.Sleep(3000);
                                FormInicio.desbloqueo();
                                btAcceder.Visible = false;
                                btCuenta.Visible = false;
                                btLogout.Location = new Point(1184, 462);
                                btLogout.Visible = true;
                                btDeleteUser.Location = new Point(1020, 462);
                                btDeleteUser.Visible = true;
                                UserControlMembresia.lbNombre.Text = bll.GetNombre().ElementAt(0);
                                UserControlMembresia.lbCodigo.Text = bll.GetCodigo().ElementAt(0);
                                UserControlMembresia.lbNacionalidad.Text = bll.GetNacionalidad().ElementAt(0);
                                string[] bdate = new string[10];
                                char[] date = bll.GetBirthdate().ElementAt(0).ToCharArray();
                                for (int n = 0; n < 10; n++)
                                {
                                    bdate[n] = date[n].ToString();
                                }
                                UserControlMembresia.lbFechaNac.Text = bdate[0] + bdate[1] + bdate[2] + bdate[3] + bdate[4] + bdate[5] + bdate[6] + bdate[7] + bdate[8] + bdate[9];
                                UserControlMembresia.lbPropiedades.Text = bll.GetPropiedades().ElementAt(0);
                                UserControlMembresia.lbLicencias.Text = bll.GetLicencias().ElementAt(0);
                                UserControlMembresia.lbMiembro.Text = bll.GetMiembrodesde().ElementAt(0);
                                UserControlMembresia.lbDistinciones.Text = bll.GetDistinciones().ElementAt(0);
                                UserControlMembresia.pictIconM.Image = bll.GetFoto();
                            }
                            else
                            {
                                lbUserFailed.Visible = false;
                                lbEmptyUser.Visible = false;
                                lbLoginSuccess.Visible = false;
                                lbPassFail.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException aor)
            {
                MessageBox.Show("El usuario indicado no ha registrado todos sus datos");
            }
        }

        private void txtEmailLogin_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmailLogin.Text))
            {
                lbEmptyUser.Visible = false;
                lbUserFailed.Visible = false;
                lbPassFail.Visible = false;
                lbLoginSuccess.Visible = false;
                txtPassLogin.Text = "";
                txtPassLogin.ForeColor = Color.Black;
                txtPassLogin.UseSystemPasswordChar = true;
                btEyePortadaLogin.Visible = true;
                btEyeClosedPortadaLogin.Visible = false;
            }
        }

        private void txtEmailLogin_Enter(object sender, EventArgs e)
        {
            if (txtEmailLogin.Text == "Correo electrónico")
            {
                txtEmailLogin.Text = "";
                txtEmailLogin.ForeColor = Color.Black;
            }
        }

        private void txtEmailLogin_Leave(object sender, EventArgs e)
        {
            if (txtEmailLogin.Text == "")
            {
                txtEmailLogin.Text = "Correo electrónico";
                txtEmailLogin.ForeColor = Color.Silver;
            }
        }

        private void txtPassLogin_Enter(object sender, EventArgs e)
        {
            if (txtPassLogin.Text == "Contraseña")
            {
                txtPassLogin.Text = "";
                txtPassLogin.ForeColor = Color.Black;
                txtPassLogin.UseSystemPasswordChar = true;
                btEyePortadaLogin.Visible = true;
                btEyeClosedPortadaLogin.Visible = false;
            }
        }

        private void txtPassLogin_Leave(object sender, EventArgs e)
        {
            if (txtPassLogin.Text == "")
            {
                txtPassLogin.Text = "Contraseña";
                txtPassLogin.ForeColor = Color.Silver;
                txtPassLogin.UseSystemPasswordChar = false;
                btEyePortadaLogin.Visible = false;
                btEyeClosedPortadaLogin.Visible = true;
            }
        }
        private void btLogout_Click(object sender, EventArgs e)
        {
            txtEmailLogin.ReadOnly = false;
            txtPassLogin.ReadOnly = false;
            login = false;
            isClicked = false;
            btAcceder.Visible = true;
            btCuenta.Visible = true;
            FormInicio.desbloqueo();
        }

        private void btLogout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmailLogin.ReadOnly = false;
                txtPassLogin.ReadOnly = false;
                login = false;
                isClicked = false;
                btAcceder.Visible = true;
                btCuenta.Visible = true;
                FormInicio.desbloqueo();
            }
        }

        private void btSuscribir_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtEmail.Text) || (txtEmail.Text == "Correo electrónico"))
                {
                    lbFailed.Visible = false;
                    lbSuscribete.Visible = false;
                    lbPassword.Visible = false;
                    lbAviso.Text = "No has introducido ningún email...";
                    lbAviso.Visible = true;
                }
                if (String.IsNullOrEmpty(txtPass.Text))
                {
                    lbPassword.Text = "No has introducido ninguna contraseña...";
                    lbPassword.Visible = true;
                }
                if (txtPass.Text.Contains(" "))
                {
                    MessageBox.Show("La contraseña no puede contener espacios en blanco");
                }
                else
                {
                    if ((txtEmail.Text.EndsWith("@nimboaircraft.com")) && (!txtEmail.Text.Contains(" ")) && (!String.IsNullOrEmpty(txtPass.Text)) && (txtPass.Text != "Contraseña") && (!txtPass.Text.Contains(" ")))
                    {
                        if (!emails.Contains(txtEmail.Text))
                        {
                            lbSuscribete.Visible = false;
                            lbAviso.Visible = false;
                            lbFailed.Visible = false;
                            fm.txtNombreM.Text = "";
                            int num = bll.GetLastCodigo();
                            fm.numCodigoM.Value = num + 1;
                            fm.comboNacionalidadM.SelectedItem = null;
                            fm.birthdateM.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
                            fm.txtPropiedadesM.Text = "";
                            UncheckAllItems();
                            fm.numMiembroM.Value = 1981;
                            fm.txtDistincionesM.Text = "";
                            fm.pictFotoM.Image = Properties.Resources.disquet;
                            fm.ShowDialog();
                        }
                        else
                        {
                            lbAviso.Visible = false;
                            lbAviso.Text = "";
                            lbSuscribete.Visible = false;
                            lbFailed.Visible = true;
                        }
                    }
                    else
                    {
                        string[] correos = bll.GetEmails().ToArray();
                        if (correos.Length == 0)
                        {
                            if ((!txtEmail.Text.EndsWith("@nimboaircraft.com")) || (txtEmail.Text.Contains(" ")))
                            {
                                lbAviso.Text = "Introduce un email válido";
                                lbAviso.Visible = true;
                                lbSuscribete.Visible = false;
                                lbFailed.Visible = false;
                            }
                            if (String.IsNullOrEmpty(txtPass.Text) || (txtPass.Text == "Contraseña"))
                            {
                                lbPassword.Text = "No has introducido ninguna contraseña...";
                                lbPassword.Visible = true;
                            }
                            if ((txtEmail.Text.EndsWith("@nimboaircraft.com")) && (!txtEmail.Text.Contains(" ")) && (String.IsNullOrEmpty(txtPass.Text) || (txtPass.Text == "Contraseña")))
                            {
                                lbAviso.Visible = false;
                                lbPassword.Text = "No has introducido ninguna contraseña...";
                                lbPassword.Visible = true;
                            }
                        }
                        else
                        {
                            lbAviso.Visible = false;
                            for (int i = 0; i < correos.Length; i++)
                            {
                                if (correos[i] == txtEmail.Text)
                                {
                                    lbAviso.Visible = false;
                                    lbSuscribete.Visible = false;
                                    lbFailed.Visible = true;
                                }
                                else
                                {
                                    if ((correos[i] == txtEmail.Text) && ((String.IsNullOrEmpty(txtPass.Text)) || ((txtPass.Text == "Contraseña"))))
                                    {
                                        lbAviso.Visible = false;
                                        lbSuscribete.Visible = false;
                                        lbFailed.Visible = true;
                                    }
                                    else
                                    {
                                        if ((!txtEmail.Text.EndsWith("@nimboaircraft.com")) || (txtEmail.Text.Contains(" ")))
                                        {
                                            lbAviso.Text = "Introduce un email válido";
                                            lbAviso.Visible = true;
                                            lbSuscribete.Visible = false;
                                            lbFailed.Visible = false;
                                        }
                                        if ((txtEmail.Text.EndsWith("@nimboaircraft.com")) && (!txtEmail.Text.Contains(" ")) && ((String.IsNullOrEmpty(txtPass.Text) || (txtPass.Text == "Contraseña"))))
                                        {
                                            lbAviso.Visible = false;
                                            lbPassword.Text = "No has introducido ninguna contraseña...";
                                            lbPassword.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btAcceder_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emails = bll.GetEmails();
                passwords = bll.GetPasswords();
                isClicked = true;
                try
                {
                    if (String.IsNullOrEmpty(txtEmailLogin.Text) || (txtEmailLogin.Text == "Correo electrónico"))
                    {
                        lbPassFail.Visible = false;
                        lbLoginSuccess.Visible = false;
                        lbUserFailed.Visible = false;
                        lbEmptyUser.Visible = true;
                    }
                    else
                        if (!emails.Contains(txtEmailLogin.Text))
                    {
                        lbPassFail.Visible = false;
                        lbLoginSuccess.Visible = false;
                        lbEmptyUser.Visible = false;
                        lbUserFailed.Visible = true;
                    }
                    else
                      if (emails.Contains(txtEmailLogin.Text))
                    {
                        for (int i = 0; i < emails.Count; i++)
                        {
                            if (emails[i] == txtEmailLogin.Text)
                            {
                                truePass = passwords[i];
                                if (txtPassLogin.Text == truePass)
                                {
                                    login = true;
                                    txtEmailLogin.ReadOnly = true;
                                    txtPassLogin.ReadOnly = true;
                                    lbUserFailed.Visible = false;
                                    lbEmptyUser.Visible = false;
                                    lbPassFail.Visible = false;
                                    lbLoginSuccess.Visible = true;
                                    UserControlAeronaves.txtSearch.Text = "";
                                    FormInicio.UCAeronaves.flow.Controls.Clear();
                                    MessageBox.Show("Login realizado con éxito");
                                    if (txtEmailLogin.Text == "admin@nimboaircraft.com")
                                    {
                                        UserControlAeronaves.btAddPlane.Enabled = true;
                                        UserControlAeronaves.btClear.Enabled = true;
                                        UserControlAeronaves.btEditar.Enabled = true;
                                        UserControlAeronaves.btDelete.Enabled = true;
                                        UserControlMembresia.btAdminUsers.Visible = true;
                                        UserControlMembresia.btChangePass.Enabled = false;
                                        UserControlMembresia.btChangePass.Visible = false;
                                    }
                                    else
                                    {
                                        UserControlAeronaves.btAddPlane.Enabled = false;
                                        UserControlAeronaves.btClear.Enabled = false;
                                        UserControlAeronaves.btEditar.Enabled = false;
                                        UserControlAeronaves.btDelete.Enabled = false;
                                        UserControlMembresia.btAdminUsers.Visible = false;
                                        UserControlMembresia.btChangePass.Enabled = true;
                                        UserControlMembresia.btChangePass.Visible = true;
                                    }
                                    lbLoginSuccess.Visible = false;
                                    //Thread.Sleep(3000);
                                    FormInicio.desbloqueo();
                                    btAcceder.Visible = false;
                                    btCuenta.Visible = false;
                                    btLogout.Location = new Point(1184, 462);
                                    btLogout.Visible = true;
                                    btDeleteUser.Location = new Point(1020, 462);
                                    btDeleteUser.Visible = true;
                                    UserControlMembresia.lbNombre.Text = bll.GetNombre().ElementAt(0);
                                    UserControlMembresia.lbCodigo.Text = bll.GetCodigo().ElementAt(0);
                                    UserControlMembresia.lbNacionalidad.Text = bll.GetNacionalidad().ElementAt(0);
                                    string[] bdate = new string[10];
                                    char[] date = bll.GetBirthdate().ElementAt(0).ToCharArray();
                                    for (int n = 0; n < 10; n++)
                                    {
                                        bdate[n] = date[n].ToString();
                                    }
                                    UserControlMembresia.lbFechaNac.Text = bdate[0] + bdate[1] + bdate[2] + bdate[3] + bdate[4] + bdate[5] + bdate[6] + bdate[7] + bdate[8] + bdate[9];
                                    UserControlMembresia.lbPropiedades.Text = bll.GetPropiedades().ElementAt(0);
                                    UserControlMembresia.lbLicencias.Text = bll.GetLicencias().ElementAt(0);
                                    UserControlMembresia.lbMiembro.Text = bll.GetMiembrodesde().ElementAt(0);
                                    UserControlMembresia.lbDistinciones.Text = bll.GetDistinciones().ElementAt(0);
                                    UserControlMembresia.pictIconM.Image = bll.GetFoto();
                                }
                                else
                                {
                                    lbUserFailed.Visible = false;
                                    lbEmptyUser.Visible = false;
                                    lbLoginSuccess.Visible = false;
                                    lbPassFail.Visible = true;
                                }
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException aor)
                {
                    MessageBox.Show("El usuario indicado no ha registrado todos sus datos");
                }
            }
        }

        private void btDeleteUser_Click(object sender, EventArgs e)
        {
            if (txtEmailLogin.Text == "admin@nimboaircraft.com")
            {
                MessageBox.Show("El administrador no puede ser eliminado desde la aplicación");
            }
            else
            {
                FormDelete fd = new FormDelete();
                fd.ShowDialog();
            }
        }
        private void UncheckAllItems()
        {
            while (fm.checkedListBoxLicenciasM.CheckedIndices.Count > 0)
                fm.checkedListBoxLicenciasM.SetItemChecked(fm.checkedListBoxLicenciasM.CheckedIndices[0], false);
        }

        private void btEyePortada_Click(object sender, EventArgs e)
        {
            btEyePortada.Visible = false;
            btEyeClosedPortada.Location = new Point(252, 130);
            btEyeClosedPortada.Visible = true;
            txtPass.UseSystemPasswordChar = false;
        }

        private void btEyeClosedPortada_Click(object sender, EventArgs e)
        {
            btEyeClosedPortada.Visible = false;
            btEyePortada.Visible = true;
            txtPass.UseSystemPasswordChar = true;
        }

        private void btEyePortadaLogin_Click(object sender, EventArgs e)
        {
            btEyePortadaLogin.Visible = false;
            btEyeClosedPortadaLogin.Location = new Point(252, 130);
            btEyeClosedPortadaLogin.Visible = true;
            txtPassLogin.UseSystemPasswordChar = false;
        }

        private void btEyeClosedPortadaLogin_Click(object sender, EventArgs e)
        {
            btEyeClosedPortadaLogin.Visible = false;
            btEyePortadaLogin.Visible = true;
            txtPassLogin.UseSystemPasswordChar = true;
        }

        private void btInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido a Nimbo Aircraft.\n\nEn nuestra aplicación podrás acceder a toda la información disponible de tu aeródromo.\n\nRegístrate si no tienes una cuenta en la plataforma. Puedes hacerlo introduciendo tu correo electrónico de la empresa (example@nimboaircraft.com) junto a tu contraseña, y después presiona el botón de <REGISTRARSE>. Inmediatamente se abrirá un formulario donde podrás introducir el resto de tus datos personales.\n\nUna vez hayas creado tu nuevo perfil, pulsa sobre el botón de <YA TENGO UN USUARIO>, y verás otro panel donde introducir de nuevo tu email y contraseña de Nimbo Aircraft. Pulsa en <ACCEDER> para iniciar sesión en tu cuenta.\n\n¡Enhorabuena! Ya estás dentro de la aplicación y puedes disfrutar de todos los servicios y ventajas que te ofrece. Te deseamos una divertida experiencia mientras descubres las nuevas funcionalidades. Recuerda que puedes ponerte en contacto con nosotros o con el administrador de la plataforma enviando un correo a <admin@nimboaircraft.com>\n\n\nEquipo de Nimbo Aircraft","MENSAJE DE BIENVENIDA");
        }
    }
}
