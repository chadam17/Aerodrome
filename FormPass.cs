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
    public partial class FormPass : Form
    {
        BasicLogic bll = new BasicLogic();
        char[] specialChars = new char[8];
        public FormPass()
        {
            InitializeComponent();
        }

        private void FormPass_Load(object sender, EventArgs e)
        {
            
        }

        private bool mouseDown;
        private Point lastLocation;

        private void FormPass_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormPass_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormPass_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void txtOldPass_Enter(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "Contraseña actual")
            {
                txtOldPass.Text = "";
                txtOldPass.ForeColor = Color.Black;
                txtOldPass.UseSystemPasswordChar = true;
            }
        }

        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            if (lbOldPass.Text == "")
            {
                txtOldPass.Text = "Contraseña actual";
                txtOldPass.ForeColor = Color.Silver;
                txtOldPass.UseSystemPasswordChar = false;
            }
        }

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(txtOldPass.Text) || (txtOldPass.Text == "Contraseña actual")))
            {
                lbOldPass.Visible = false;
            }
            else
            {
                if (txtOldPass.Text == bll.GetPassword())
                {
                    lbOldPass.Text = "✔";
                    lbOldPass.ForeColor = Color.Lime;
                    lbOldPass.Visible = true;
                }
                else
                {
                    lbOldPass.Text = "❌";
                    lbOldPass.ForeColor = Color.Red;
                    lbOldPass.Visible = true;
                }
            }
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "Nueva contraseña")
            {
                txtNewPass.Text = "";
                txtNewPass.ForeColor = Color.Black;
                txtNewPass.UseSystemPasswordChar = true;
            }
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (lbNewPass.Text == "")
            {
                txtNewPass.Text = "Nueva contraseña";
                txtNewPass.ForeColor = Color.Silver;
                txtNewPass.UseSystemPasswordChar = false;
            }
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            txtNewPassConfirm.Text = "";
            txtNewPassConfirm.ForeColor = Color.Black;
            txtNewPassConfirm.UseSystemPasswordChar = true;
            lbNewPassConfirm.Visible = false;
            if ((String.IsNullOrEmpty(txtNewPass.Text) || (txtNewPass.Text == "Nueva contraseña")))
            {
                lbNewPass.Visible = false;
                lbNewPassAdvice.Visible = false;               
            }
            else
            {
                if (txtNewPass.Text == bll.GetPassword())
                {
                    lbNewPass.Text = "❌";
                    lbNewPass.ForeColor = Color.Red;
                    lbNewPass.Visible = true;
                    lbNewPassAdvice.Text = "La nueva contraseña debe ser distinta a la actual";
                    lbNewPassAdvice.ForeColor = Color.Red;
                    lbNewPassAdvice.Visible = true;                   
                }
                else
                {
                    if (txtNewPass.Text.Contains(" "))
                    {
                        lbNewPass.Text = "⚠";
                        lbNewPass.ForeColor = Color.Orange;
                        lbNewPass.Visible = true;
                        lbNewPassAdvice.Text = "No se permiten espacios en blanco...";
                        lbNewPassAdvice.ForeColor = Color.Orange;
                        lbNewPassAdvice.Visible = true;
                    }
                    else
                    {
                        if ((txtNewPass.Text.Length >= 8) && (txtNewPass.Text.Contains("0") || txtNewPass.Text.Contains("1") || txtNewPass.Text.Contains("2") || txtNewPass.Text.Contains("3") || txtNewPass.Text.Contains("4") || txtNewPass.Text.Contains("5") || txtNewPass.Text.Contains("6") || txtNewPass.Text.Contains("7") || txtNewPass.Text.Contains("8") || txtNewPass.Text.Contains("9")) && (txtNewPass.Text.Contains("A") || txtNewPass.Text.Contains("B") || txtNewPass.Text.Contains("C") || txtNewPass.Text.Contains("D") || txtNewPass.Text.Contains("E") || txtNewPass.Text.Contains("F") || txtNewPass.Text.Contains("G") || txtNewPass.Text.Contains("H") || txtNewPass.Text.Contains("I") || txtNewPass.Text.Contains("J") || txtNewPass.Text.Contains("K") || txtNewPass.Text.Contains("L") || txtNewPass.Text.Contains("M") || txtNewPass.Text.Contains("N") || txtNewPass.Text.Contains("O") || txtNewPass.Text.Contains("P") || txtNewPass.Text.Contains("Q") || txtNewPass.Text.Contains("R") || txtNewPass.Text.Contains("S") || txtNewPass.Text.Contains("T") || txtNewPass.Text.Contains("U") || txtNewPass.Text.Contains("V") || txtNewPass.Text.Contains("W") || txtNewPass.Text.Contains("X") || txtNewPass.Text.Contains("Y") || txtNewPass.Text.Contains("Z")) && ((txtNewPass.Text.Contains("@")) || (txtNewPass.Text.Contains("#")) || (txtNewPass.Text.Contains("$")) || (txtNewPass.Text.Contains("%")) || (txtNewPass.Text.Contains("^")) || (txtNewPass.Text.Contains("&")) || (txtNewPass.Text.Contains("+")) || (txtNewPass.Text.Contains("="))))
                        {
                            lbNewPass.Text = "✔";
                            lbNewPass.ForeColor = Color.Lime;
                            lbNewPass.Visible = true;
                            lbNewPassAdvice.Text = "Contraseña segura";
                            lbNewPassAdvice.ForeColor = Color.Lime;
                            lbNewPassAdvice.Visible = true;
                        }
                        else
                        {
                            lbNewPass.Text = "⚠";
                            lbNewPass.ForeColor = Color.Orange;
                            lbNewPass.Visible = true;
                            lbNewPassAdvice.Text = "Contraseña débil";
                            lbNewPassAdvice.ForeColor = Color.Orange;
                            lbNewPassAdvice.Visible = true;
                        }
                    }
                }
            }
        }

        private void txtNewPassConfirm_Enter(object sender, EventArgs e)
        {
            if (txtNewPassConfirm.Text == "Nueva contraseña")
            {
                txtNewPassConfirm.Text = "";
                txtNewPassConfirm.ForeColor = Color.Black;
                txtNewPassConfirm.UseSystemPasswordChar = true;
            }
        }

        private void txtNewPassConfirm_Leave(object sender, EventArgs e)
        {
            if (lbNewPassConfirm.Text == "")
            {
                txtNewPassConfirm.Text = "Nueva contraseña";
                txtNewPassConfirm.ForeColor = Color.Silver;
                txtNewPassConfirm.UseSystemPasswordChar = false;
            }
        }

        private void txtNewPassConfirm_TextChanged(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(txtNewPassConfirm.Text) || (txtNewPassConfirm.Text == "Nueva contraseña")))
            {
                lbNewPassConfirm.Visible = false;
            }
            else
            {
                if (txtNewPassConfirm.Text == txtNewPass.Text)
                {
                    lbNewPassConfirm.Text = "✔";
                    lbNewPassConfirm.ForeColor = Color.Lime;
                    lbNewPassConfirm.Visible = true;
                }
                else
                {
                    lbNewPassConfirm.Text = "❌";
                    lbNewPassConfirm.ForeColor = Color.Red;
                    lbNewPassConfirm.Visible = true;
                }
            }
        }

        private void btHelpPass_Click(object sender, EventArgs e)
        {  
            MessageBox.Show("Si decides cambiar de contraseña, puedes hacerlo a través de este formulario o bien contactando con el administrador de la plataforma enviando un correo electrónico a\n\nadmin@nimboaircraft.com\n\nAsegúrate de elegir una contraseña segura. Para ser considerada segura, la contraseña debe reunir las siguientes condiciones:\n\n• Contener mínimo 8 caracteres\n\n• Mínimo una letra en máyuscula (A-Z)\n\n• Mínimo un número (0-9)\n\n• Contener al menos un caracter especial ('@', '#', '$', '%', '^', '&', '+', '=')\n\nNo obstante, podrás guardar la nueva contraseña siempre que sea distinta de la actual y la confirmes correctamente. Recibirás un mensaje de aviso antes de guardar la nueva contraseña en caso de que ésta no sea considerada como segura.\n\nEquipo de Nimbo Aircraft.", "AYUDA PARA EL CAMBIO DE CONTRASEÑA");          
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if ((txtOldPass.Text.Contains(" ") || (txtNewPass.Text.Contains(" ") || (txtNewPassConfirm.Text.Contains(" ")))))
            {
                MessageBox.Show("La contraseña no admite espacios en blanco");
                return;
            }
            if ((txtOldPass.Text == bll.GetPassword()) && (txtOldPass.Text != txtNewPass.Text) && (txtNewPass.Text == txtNewPassConfirm.Text) && (!String.IsNullOrEmpty(txtNewPass.Text) && (txtNewPass.Text != "Nueva contraseña")) && (!String.IsNullOrEmpty(txtNewPassConfirm.Text) && (txtNewPassConfirm.Text != "Nueva contraseña")))
            {
                if ((txtNewPass.Text.Length >= 8) && (txtNewPass.Text.Contains("0") || txtNewPass.Text.Contains("1") || txtNewPass.Text.Contains("2") || txtNewPass.Text.Contains("3") || txtNewPass.Text.Contains("4") || txtNewPass.Text.Contains("5") || txtNewPass.Text.Contains("6") || txtNewPass.Text.Contains("7") || txtNewPass.Text.Contains("8") || txtNewPass.Text.Contains("9")) && (txtNewPass.Text.Contains("A") || txtNewPass.Text.Contains("B") || txtNewPass.Text.Contains("C") || txtNewPass.Text.Contains("D") || txtNewPass.Text.Contains("E") || txtNewPass.Text.Contains("F") || txtNewPass.Text.Contains("G") || txtNewPass.Text.Contains("H") || txtNewPass.Text.Contains("I") || txtNewPass.Text.Contains("J") || txtNewPass.Text.Contains("K") || txtNewPass.Text.Contains("L") || txtNewPass.Text.Contains("M") || txtNewPass.Text.Contains("N") || txtNewPass.Text.Contains("O") || txtNewPass.Text.Contains("P") || txtNewPass.Text.Contains("Q") || txtNewPass.Text.Contains("R") || txtNewPass.Text.Contains("S") || txtNewPass.Text.Contains("T") || txtNewPass.Text.Contains("U") || txtNewPass.Text.Contains("V") || txtNewPass.Text.Contains("W") || txtNewPass.Text.Contains("X") || txtNewPass.Text.Contains("Y") || txtNewPass.Text.Contains("Z")) && ((txtNewPass.Text.Contains("@")) || (txtNewPass.Text.Contains("#")) || (txtNewPass.Text.Contains("$")) || (txtNewPass.Text.Contains("%")) || (txtNewPass.Text.Contains("^")) || (txtNewPass.Text.Contains("&")) || (txtNewPass.Text.Contains("+")) || (txtNewPass.Text.Contains("="))))
                {
                    if (bll.ChangePasswordUsers(txtNewPassConfirm.Text) && bll.ChangePasswordMembers(txtNewPassConfirm.Text))
                    {
                        UserControlPortada.passwords = bll.GetPasswords();
                        UserControlPortada.txtPassLogin.Text = txtNewPassConfirm.Text;
                        MessageBox.Show("Contraseña modificada correctamente");
                        Close();
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Tu nueva contraseña no es segura. ¿Seguro que deseas guardarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if (bll.ChangePasswordUsers(txtNewPassConfirm.Text) && bll.ChangePasswordMembers(txtNewPassConfirm.Text))
                        {
                            UserControlPortada.passwords = bll.GetPasswords();
                            UserControlPortada.txtPassLogin.Text = txtNewPassConfirm.Text;
                            MessageBox.Show("Contraseña modificada correctamente");
                            Close();
                        }                       
                    }
                }
            }
            else
            {
                MessageBox.Show("No hemos podido guardar la nueva contraseña");
                return;
            }
        }

        private void btEyeOldPass_Click(object sender, EventArgs e)
        {
            btEyeOldPass.Visible = false;
            btEyeClosedOldPass.Location = new Point(264, 105);
            btEyeClosedOldPass.Visible = true;
            txtOldPass.UseSystemPasswordChar = false;
        }

        private void btEyeClosedOldPass_Click(object sender, EventArgs e)
        {
            btEyeClosedOldPass.Visible = false;
            btEyeOldPass.Visible = true;
            txtOldPass.UseSystemPasswordChar = true;
        }

        private void btEyeNewPass_Click(object sender, EventArgs e)
        {
            btEyeNewPass.Visible = false;
            btEyeClosedNewPass.Location = new Point(264, 206);
            btEyeClosedNewPass.Visible = true;
            txtNewPass.UseSystemPasswordChar = false;
        }

        private void btEyeClosedNewPass_Click(object sender, EventArgs e)
        {
            btEyeClosedNewPass.Visible = false;
            btEyeNewPass.Visible = true;
            txtNewPass.UseSystemPasswordChar = true;
        }

        private void btEyeNewPassConfirm_Click(object sender, EventArgs e)
        {
            btEyeNewPassConfirm.Visible = false;
            btEyeClosedNewPassConfirm.Location = new Point(264, 307);
            btEyeClosedNewPassConfirm.Visible = true;
            txtNewPassConfirm.UseSystemPasswordChar = false;
        }

        private void btEyeClosedNewPassConfirm_Click(object sender, EventArgs e)
        {
            btEyeClosedNewPassConfirm.Visible = false;
            btEyeNewPassConfirm.Visible = true;
            txtNewPassConfirm.UseSystemPasswordChar = true;
        }
    }
}
