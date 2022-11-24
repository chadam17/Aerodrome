using System;
using System.Drawing;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class FormDelete : Form
    {
        public BasicLogic bll = new BasicLogic();
        public FormDelete()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            lbPasswordDelete.Visible = false;
            if (txtPassDelete.Text == UserControlPortada.txtPassLogin.Text)
            {
                if ((bll.DeleteUsuarios(UserControlPortada.txtEmailLogin.Text)) && (bll.DeleteVoters(UserControlPortada.txtEmailLogin.Text)) && (bll.DeleteMembers(UserControlPortada.txtEmailLogin.Text)))
                {
                    MyUserControlLicencias.alumnosPPL = bll.GetAlumnosPPL();
                    string studentsPPL = MyUserControlLicencias.alumnosPPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsPPL(studentsPPL);
                    MyUserControlLicencias.alumnosULM = bll.GetAlumnosULM();
                    string studentsULM = MyUserControlLicencias.alumnosULM.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsULM(studentsULM);
                    MyUserControlLicencias.alumnosRPAS = bll.GetAlumnosRPAS();
                    string studentsRPAS = MyUserControlLicencias.alumnosRPAS.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsRPAS(studentsRPAS);
                    MyUserControlLicencias.alumnosHPL = bll.GetAlumnosHPL();
                    string studentsHPL = MyUserControlLicencias.alumnosHPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsHPL(studentsHPL);
                    MyUserControlLicencias.alumnosAFL = bll.GetAlumnosAFL();
                    string studentsAFL = MyUserControlLicencias.alumnosAFL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsAFL(studentsAFL);
                    MyUserControlLicencias.alumnosCPL = bll.GetAlumnosCPL();
                    string studentsCPL = MyUserControlLicencias.alumnosCPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsCPL(studentsCPL);
                    MyUserControlLicencias.alumnosATPL = bll.GetAlumnosATPL();
                    string studentsATPL = MyUserControlLicencias.alumnosATPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsATPL(studentsATPL);
                    MyUserControlLicencias.alumnosBPL = bll.GetAlumnosBPL();
                    string studentsBPL = MyUserControlLicencias.alumnosBPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsBPL(studentsBPL);
                    MyUserControlLicencias.alumnosSPL = bll.GetAlumnosSPL();
                    string studentsSPL = MyUserControlLicencias.alumnosSPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsSPL(studentsSPL);
                    MyUserControlLicencias.alumnosFI = bll.GetAlumnosFI();
                    string studentsFI = MyUserControlLicencias.alumnosFI.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    bll.UpdateStudentsFI(studentsFI);
                    lbPasswordDelete.Text = "¡Esperamos verte de nuevo!";
                    lbPasswordDelete.Visible = true;
                    MessageBox.Show("Usuario eliminado");
                    UserControlPortada.txtEmailLogin.ReadOnly = false;
                    UserControlPortada.txtPassLogin.ReadOnly = false;
                    UserControlPortada.login = false;
                    UserControlPortada.isClicked = false;
                    UserControlPortada.btAcceder.Visible = true;
                    UserControlPortada.btCuenta.Visible = true;
                    lbPasswordDelete.Visible = false;
                    lbPasswordDelete.Text = "Contraseña incorrecta";
                    FormInicio.desbloqueo();
                    UserControlPortada.truePass = "";
                    UserControlPortada.emails = bll.GetEmails();
                    UserControlPortada.passwords = bll.GetPasswords();                   
                }
                Close();
            }
            else
            {
                if (String.IsNullOrEmpty(txtPassDelete.Text) || (txtPassDelete.Text == "Contraseña"))
                {
                    lbPasswordDelete.Text = "No has introducido nada";
                    lbPasswordDelete.Visible = true;
                }
                else
                {
                    lbPasswordDelete.Text = "Contraseña incorrecta";
                    lbPasswordDelete.Visible = true;
                }
            }
        }
        private bool mouseDown;
        private Point lastLocation;

        private void FormDelete_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormDelete_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormDelete_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void txtPassDelete_Enter(object sender, EventArgs e)
        {
            if (txtPassDelete.Text == "Contraseña")
            {
                txtPassDelete.Text = "";
                txtPassDelete.ForeColor = Color.Black;
                txtPassDelete.UseSystemPasswordChar = true;
            }
        }

        private void txtPassDelete_Leave(object sender, EventArgs e)
        {
            if (txtPassDelete.Text == "")
            {
                txtPassDelete.Text = "Contraseña";
                txtPassDelete.ForeColor = Color.Silver;
                txtPassDelete.UseSystemPasswordChar = false;
            }
        }

        private void txtPassDelete_TextChanged(object sender, EventArgs e)
        {
            lbPasswordDelete.Visible = false;
        }

        private void btCancelDelete_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCancelDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }

        private void btnEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbPasswordDelete.Visible = false;
                if (txtPassDelete.Text == UserControlPortada.txtPassLogin.Text)
                {
                    if ((bll.DeleteUsuarios(UserControlPortada.txtEmailLogin.Text)) && (bll.DeleteVoters(UserControlPortada.txtEmailLogin.Text)) && (bll.DeleteMembers(UserControlPortada.txtEmailLogin.Text)))
                    {
                        MyUserControlLicencias.alumnosPPL = bll.GetAlumnosPPL();
                        string studentsPPL = MyUserControlLicencias.alumnosPPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsPPL(studentsPPL);
                        MyUserControlLicencias.alumnosULM = bll.GetAlumnosULM();
                        string studentsULM = MyUserControlLicencias.alumnosULM.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsULM(studentsULM);
                        MyUserControlLicencias.alumnosRPAS = bll.GetAlumnosRPAS();
                        string studentsRPAS = MyUserControlLicencias.alumnosRPAS.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsRPAS(studentsRPAS);
                        MyUserControlLicencias.alumnosHPL = bll.GetAlumnosHPL();
                        string studentsHPL = MyUserControlLicencias.alumnosHPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsHPL(studentsHPL);
                        MyUserControlLicencias.alumnosAFL = bll.GetAlumnosAFL();
                        string studentsAFL = MyUserControlLicencias.alumnosAFL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsAFL(studentsAFL);
                        MyUserControlLicencias.alumnosCPL = bll.GetAlumnosCPL();
                        string studentsCPL = MyUserControlLicencias.alumnosCPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsCPL(studentsCPL);
                        MyUserControlLicencias.alumnosATPL = bll.GetAlumnosATPL();
                        string studentsATPL = MyUserControlLicencias.alumnosATPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsATPL(studentsATPL);
                        MyUserControlLicencias.alumnosBPL = bll.GetAlumnosBPL();
                        string studentsBPL = MyUserControlLicencias.alumnosBPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsBPL(studentsBPL);
                        MyUserControlLicencias.alumnosSPL = bll.GetAlumnosSPL();
                        string studentsSPL = MyUserControlLicencias.alumnosSPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsSPL(studentsSPL);
                        MyUserControlLicencias.alumnosFI = bll.GetAlumnosFI();
                        string studentsFI = MyUserControlLicencias.alumnosFI.Replace(UserControlPortada.txtEmailLogin.Text, "");
                        bll.UpdateStudentsFI(studentsFI);

                        lbPasswordDelete.Text = "¡Esperamos verte de nuevo!";
                        lbPasswordDelete.Visible = true;
                        MessageBox.Show("Usuario eliminado");
                        UserControlPortada.txtEmailLogin.ReadOnly = false;
                        UserControlPortada.txtPassLogin.ReadOnly = false;
                        UserControlPortada.login = false;
                        UserControlPortada.isClicked = false;
                        UserControlPortada.btAcceder.Visible = true;
                        UserControlPortada.btCuenta.Visible = true;
                        lbPasswordDelete.Visible = false;
                        lbPasswordDelete.Text = "Contraseña incorrecta";
                        FormInicio.desbloqueo();
                        UserControlPortada.truePass = "";
                        UserControlPortada.emails = bll.GetEmails();
                        UserControlPortada.passwords = bll.GetPasswords();
                    }
                    Close();
                }
                else
                {
                    if (String.IsNullOrEmpty(txtPassDelete.Text) || (txtPassDelete.Text == "Contraseña"))
                    {
                        lbPasswordDelete.Text = "No has introducido nada";
                        lbPasswordDelete.Visible = true;
                    }
                    else
                    {
                        lbPasswordDelete.Text = "Contraseña incorrecta";
                        lbPasswordDelete.Visible = true;
                    }
                }
            }
        }

        private void btEyeDelete_Click(object sender, EventArgs e)
        {
            btEyeDelete.Visible = false;
            btEyeClosedDelete.Location = new Point(297, 152);
            btEyeClosedDelete.Visible = true;
            txtPassDelete.UseSystemPasswordChar = false;
        }

        private void btEyeClosedDelete_Click(object sender, EventArgs e)
        {
            btEyeClosedDelete.Visible = false;
            btEyeDelete.Visible = true;
            txtPassDelete.UseSystemPasswordChar = true;
        }
    }
}
