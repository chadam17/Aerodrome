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
    public partial class MyUserControlLicencias : UserControl
    {
        public BasicLogic bll = new BasicLogic();
        public static List<string> nombresLicencias = new List<string>();
        public static List<string> nombresAlumnos = new List<string>();
        public static string alumnosPPL;
        public static string alumnosULM;
        public static string alumnosRPAS;
        public static string alumnosHPL;
        public static string alumnosAFL;
        public static string alumnosCPL;
        public static string alumnosATPL;
        public static string alumnosBPL;
        public static string alumnosSPL;
        public static string alumnosFI;
        public static List<string> votantes = new List<string>();
        public MyUserControlLicencias()
        {
            InitializeComponent();
        }

        private string _titulo;
        private string _descripcion;
        private string _lugar;
        private int _precio;
        private decimal _puntuacion;
        private string _alumnos;
        private Image _icon;

        /// <summary>
        /// Métodos setter y getter del atributo Titulo
        /// </summary>
        [Category("Licencias")]

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; lbTituloLicencia.Text = value; }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Descripcion
        /// </summary>
        [Category("Licencias")]

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; txtDescripcion.Text = value; }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Lugar
        /// </summary>
        [Category("Licencias")]

        public string Lugar
        {
            get { return _lugar; }
            set { _lugar = value; lbLugar.Text = value; }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Precio
        /// </summary>
        [Category("Licencias")]

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; lbPrecioLicencia.Text = value.ToString(); }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Puntuacion
        /// </summary>
        [Category("Licencias")]

        public decimal Puntuacion
        {
            get { return _puntuacion; }
            set { _puntuacion = value; lbPuntuacionActual.Text = value.ToString(); }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Alumnos
        /// </summary>
        [Category("Licencias")]

        public string Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value;  lbAlumnos.Text = value; }
        }

        [Category("Licencias")]

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictFotoLicencia.Image = value; }
        }
        /// <summary>
        /// Método para determinar si el control ha sido clicado por el usuario
        /// </summary>

        bool isClicked = false;
        public bool IsClicked
        {
            get
            {
                return isClicked;
            }
            set
            {
                isClicked = value;
            }
        }

        private void MyUserControlLicencias_Load(object sender, EventArgs e)
        {
            nombresLicencias = bll.GetLicenciasNames();
            alumnosPPL = bll.GetAlumnosPPL();
            alumnosULM = bll.GetAlumnosULM();
            alumnosRPAS = bll.GetAlumnosRPAS();
            alumnosHPL = bll.GetAlumnosHPL();
            alumnosAFL = bll.GetAlumnosAFL();
            alumnosCPL = bll.GetAlumnosCPL();
            alumnosATPL = bll.GetAlumnosATPL();
            alumnosBPL = bll.GetAlumnosBPL();
            alumnosSPL = bll.GetAlumnosSPL();
            alumnosFI = bll.GetAlumnosFI();
            
            if (UserControlPortada.txtEmailLogin.Text == "admin@nimboaircraft.com")
            {
                panelPuntuacion.Location = new Point(460, 395);
                btEditarLicencias.Visible = true;
                btAlumnos.Visible = true;
            }
            else
            {
                panelPuntuacion.Location = new Point(14, 460);
                btEditarLicencias.Visible = false;
                btAlumnos.Visible = false;
            }
        }
        private void MyUserControlLicencias_Click(object sender, EventArgs e)
        {

        }

        private void btAlumnos_Click(object sender, EventArgs e)
        {
            FormAlumnos fa = new FormAlumnos();
            string alumnos = "";
            string students = "";
            fa.lbNombreLicencia.Text = lbTituloLicencia.Text;
            switch(lbTituloLicencia.Text)
            {
                case "Piloto Privado (PPL)":
                    alumnos = bll.GetAlumnosPPL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto de Ultraligero (ULM)":
                    alumnos = bll.GetAlumnosULM();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Vehículo Aéreo No Tripulado (RPAS)":
                    alumnos = bll.GetAlumnosRPAS();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto de Helicópteros (HPL)":
                    alumnos = bll.GetAlumnosHPL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto de Combate Aéreo (AFL)":
                    alumnos = bll.GetAlumnosAFL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto Comercial (CPL)":
                    alumnos = bll.GetAlumnosCPL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto de Transporte de Línea Aérea (ATPL)":
                    alumnos = bll.GetAlumnosATPL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto de Globo Aerostático (BPL)":
                    alumnos = bll.GetAlumnosBPL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Piloto de Planeador (SPL)":
                    alumnos = bll.GetAlumnosSPL();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
                case "Instructor de Vuelo (FI)":
                    alumnos = bll.GetAlumnosFI();
                    students = alumnos.Replace("@nimboaircraft.com", "@nimboaircraft.com\r");
                    fa.txtAlumnos.Text = students;
                    break;
            }
            
            fa.ShowDialog();
        }

        private void btMatricularse_Click(object sender, EventArgs e)
        {
            string licencias = bll.GetLicencias().ElementAt(0);
            switch(lbTituloLicencia.Text)
            {
                case "Piloto Privado (PPL)": 
                    alumnosPPL = bll.GetAlumnosPPL();
                    if (!licencias.Contains("PPL"))
                    {
                        if ((!alumnosPPL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsPPL(alumnosPPL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto de Ultraligero (ULM)":
                    alumnosULM = bll.GetAlumnosULM();
                    if (!licencias.Contains("ULM"))
                    {
                        if ((!alumnosULM.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsULM(alumnosULM + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Vehículo Aéreo No Tripulado (RPAS)":
                    alumnosRPAS = bll.GetAlumnosRPAS();
                    if (!licencias.Contains("RPAS"))
                    {
                        if ((!alumnosRPAS.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsRPAS(alumnosRPAS + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto de Helicópteros (HPL)":
                    alumnosHPL = bll.GetAlumnosHPL();
                    if (!licencias.Contains("HPL"))
                    {
                        if ((!alumnosHPL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsHPL(alumnosHPL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto de Combate Aéreo (AFL)":
                    alumnosAFL = bll.GetAlumnosAFL();
                    if (!licencias.Contains("AFL"))
                    {
                        if ((!alumnosAFL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsAFL(alumnosAFL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto Comercial (CPL)":
                    alumnosCPL = bll.GetAlumnosCPL();
                    if (!licencias.Contains("CPL"))
                    {
                        if ((!alumnosCPL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsCPL(alumnosCPL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto de Transporte de Línea Aérea (ATPL)":
                    alumnosATPL = bll.GetAlumnosATPL();
                    if (!licencias.Contains("ATPL"))
                    {
                        if ((!alumnosATPL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsATPL(alumnosATPL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto de Globo Aerostático (BPL)":
                    alumnosBPL = bll.GetAlumnosBPL();
                    if (!licencias.Contains("BPL"))
                    {
                        if ((!alumnosBPL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsBPL(alumnosBPL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Piloto de Planeador (SPL)":
                    alumnosSPL = bll.GetAlumnosSPL();
                    if (!licencias.Contains("SPL"))
                    {
                        if ((!alumnosSPL.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsSPL(alumnosSPL + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                case "Instructor de Vuelo (FI)":
                    alumnosFI = bll.GetAlumnosFI();
                    if (!licencias.Contains("FI"))
                    {
                        if ((!alumnosFI.Contains(UserControlPortada.txtEmailLogin.Text)) && (bll.UpdateStudentsFI(alumnosFI + "\n" + UserControlPortada.txtEmailLogin.Text)))
                        {
                            btMatricularse.Visible = false;
                            btCancelarMat.Location = new Point(524, 512);
                            btCancelarMat.Visible = true;
                        }
                    }
                    else
                        MessageBox.Show("Ya eres titular de la licencia. Por falta de plazas suficientes solo pueden matricularse usuarios que no hayan acreditado el título.");
                    break;
                default:
                    btMatricularse.Visible = false;
                    btCancelarMat.Location = new Point(524, 512);
                    btCancelarMat.Visible = true; 
                    break;
            }          
        }
        private void btCancelarMat_Click(object sender, EventArgs e)
        {
            switch (lbTituloLicencia.Text)
            {
                case "Piloto Privado (PPL)": 
                    alumnosPPL = bll.GetAlumnosPPL(); 
                    string studentsPPL = alumnosPPL.Replace(UserControlPortada.txtEmailLogin.Text,"");
                    if (bll.UpdateStudentsPPL(studentsPPL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto de Ultraligero (ULM)":
                    alumnosULM = bll.GetAlumnosULM();
                    string studentsULM = alumnosULM.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsULM(studentsULM))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Vehículo Aéreo No Tripulado (RPAS)":
                    alumnosRPAS = bll.GetAlumnosRPAS();
                    string studentsRPAS = alumnosRPAS.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsRPAS(studentsRPAS))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto de Helicópteros (HPL)":
                    alumnosHPL = bll.GetAlumnosHPL();
                    string studentsHPL = alumnosHPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsHPL(studentsHPL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto de Combate Aéreo (AFL)":
                    alumnosAFL = bll.GetAlumnosAFL();
                    string studentsAFL = alumnosAFL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsAFL(studentsAFL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto Comercial (CPL)":
                    alumnosCPL = bll.GetAlumnosCPL();
                    string studentsCPL = alumnosCPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsCPL(studentsCPL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto de Transporte de Línea Aérea (ATPL)":
                    alumnosATPL = bll.GetAlumnosATPL();
                    string studentsATPL = alumnosATPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsATPL(studentsATPL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto de Globo Aerostático (BPL)":
                    alumnosBPL = bll.GetAlumnosBPL();
                    string studentsBPL = alumnosBPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsBPL(studentsBPL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Piloto de Planeador (SPL)":
                    alumnosSPL = bll.GetAlumnosSPL();
                    string studentsSPL = alumnosSPL.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsSPL(studentsSPL))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                case "Instructor de Vuelo (FI)":
                    alumnosFI = bll.GetAlumnosFI();
                    string studentsFI = alumnosFI.Replace(UserControlPortada.txtEmailLogin.Text, "");
                    if (bll.UpdateStudentsFI(studentsFI))
                    {
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                    }
                    break;
                default:
                        btCancelarMat.Visible = false;
                        btMatricularse.Visible = true;
                        break;
            }          
        }
        private void btEditarLicencias_Click(object sender, EventArgs e)
        {
            FormEditLicencia fel = new FormEditLicencia();
            FormEditLicencia.lbNombreLicenciaEdit.Text = lbTituloLicencia.Text;
            fel.txtDescripcionEdit.Text = txtDescripcion.Text;
            fel.txtLugarEditLicencia.Text = lbLugar.Text;
            fel.numPrecioEditLicencia.Value = Convert.ToInt64(lbPrecioLicencia.Text);
            fel.pbLicenciaEdit.Image = pictFotoLicencia.Image;
            fel.ShowDialog();
        }

        private void btSendVal_Click(object sender, EventArgs e)
        {
            votantes = bll.GetVoters();
            if (!votantes.Contains(UserControlPortada.txtEmailLogin.Text))
            {
                bll.SaveVoters(UserControlPortada.txtEmailLogin.Text);
            }
            
            switch (lbTituloLicencia.Text)
            {
                case "Piloto Privado (PPL)":
                    alumnosPPL = bll.GetAlumnosPPL();
                    int notaPPL;
                    if (bll.GetNotaPPL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaPPL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaPPL(notaPPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaPPL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaPPL(notaPPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaPPL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaPPL(notaPPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaPPL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaPPL(notaPPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaPPL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaPPL(notaPPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaPPL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaPPL(notaPPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaPPL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaPPL(notaPPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaPPL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaPPL(notaPPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaPPL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaPPL(notaPPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaPPL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaPPL(notaPPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto de Ultraligero (ULM)":
                    alumnosULM = bll.GetAlumnosULM();
                    int notaULM;
                    if (bll.GetNotaULM() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaULM = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaULM(notaULM))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaULM = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaULM(notaULM))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaULM = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaULM(notaULM))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaULM = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaULM(notaULM))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaULM = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaULM(notaULM))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaULM = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaULM(notaULM))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaULM = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaULM(notaULM))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaULM = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaULM(notaULM))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaULM = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaULM(notaULM))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaULM = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaULM(notaULM))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Vehículo Aéreo No Tripulado (RPAS)":
                    alumnosRPAS = bll.GetAlumnosRPAS();
                    int notaRPAS;
                    if (bll.GetNotaRPAS() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaRPAS = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaRPAS(notaRPAS))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaRPAS = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaRPAS(notaRPAS))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaRPAS = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaRPAS(notaRPAS))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaRPAS = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaRPAS(notaRPAS))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaRPAS = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaRPAS(notaRPAS))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaRPAS = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaRPAS(notaRPAS))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaRPAS = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaRPAS(notaRPAS))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaRPAS = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaRPAS(notaRPAS))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaRPAS = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaRPAS(notaRPAS))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaRPAS = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaRPAS(notaRPAS))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto de Helicópteros (HPL)":
                    alumnosHPL = bll.GetAlumnosHPL();
                    int notaHPL;
                    if (bll.GetNotaHPL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaHPL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaHPL(notaHPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaHPL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaHPL(notaHPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaHPL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaHPL(notaHPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaHPL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaHPL(notaHPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaHPL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaHPL(notaHPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaHPL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaHPL(notaHPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaHPL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaHPL(notaHPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaHPL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaHPL(notaHPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaHPL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaHPL(notaHPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaHPL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaHPL(notaHPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto de Combate Aéreo (AFL)":
                    alumnosAFL = bll.GetAlumnosAFL();
                    int notaAFL;
                    if (bll.GetNotaAFL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaAFL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaAFL(notaAFL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaAFL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaAFL(notaAFL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaAFL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaAFL(notaAFL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaAFL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaAFL(notaAFL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaAFL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaAFL(notaAFL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaAFL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaAFL(notaAFL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaAFL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaAFL(notaAFL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaAFL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaAFL(notaAFL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaAFL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaAFL(notaAFL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaAFL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaAFL(notaAFL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto Comercial (CPL)":
                    alumnosCPL = bll.GetAlumnosCPL();
                    int notaCPL;
                    if (bll.GetNotaCPL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaCPL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaCPL(notaCPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaCPL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaCPL(notaCPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaCPL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaCPL(notaCPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaCPL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaCPL(notaCPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaCPL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaCPL(notaCPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaCPL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaCPL(notaCPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaCPL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaCPL(notaCPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaCPL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaCPL(notaCPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaCPL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaCPL(notaCPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaCPL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaCPL(notaCPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto de Transporte de Línea Aérea (ATPL)":
                    alumnosATPL = bll.GetAlumnosATPL();
                    int notaATPL;
                    if (bll.GetNotaATPL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaATPL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaATPL(notaATPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaATPL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaATPL(notaATPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaATPL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaATPL(notaATPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaATPL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaATPL(notaATPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaATPL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaATPL(notaATPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaATPL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaATPL(notaATPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaATPL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaATPL(notaATPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaATPL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaATPL(notaATPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaATPL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaATPL(notaATPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaATPL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaATPL(notaATPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto de Globo Aerostático (BPL)":
                    alumnosBPL = bll.GetAlumnosBPL();
                    int notaBPL;
                    if (bll.GetNotaBPL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaBPL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaBPL(notaBPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaBPL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaBPL(notaBPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaBPL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaBPL(notaBPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaBPL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaBPL(notaBPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaBPL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaBPL(notaBPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaBPL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaBPL(notaBPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaBPL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaBPL(notaBPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaBPL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaBPL(notaBPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaBPL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaBPL(notaBPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaBPL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaBPL(notaBPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Piloto de Planeador (SPL)":
                    alumnosSPL = bll.GetAlumnosSPL();
                    int notaSPL;
                    if (bll.GetNotaSPL() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaSPL = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaSPL(notaSPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaSPL = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaSPL(notaSPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaSPL = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaSPL(notaSPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaSPL = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaSPL(notaSPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaSPL = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaSPL(notaSPL))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaSPL = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaSPL(notaSPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaSPL = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaSPL(notaSPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaSPL = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaSPL(notaSPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaSPL = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaSPL(notaSPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaSPL = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaSPL(notaSPL))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
                case "Instructor de Vuelo (FI)":
                    alumnosFI = bll.GetAlumnosFI();
                    int notaFI;
                    if (bll.GetNotaFI() == 0)
                    {
                        if (rb1.Checked)
                        {
                            notaFI = Convert.ToInt32(rb1.Text);
                            if (bll.ChangeNotaFI(notaFI))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb2.Checked)
                        {
                            notaFI = Convert.ToInt32(rb2.Text);
                            if (bll.ChangeNotaFI(notaFI))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb3.Checked)
                        {
                            notaFI = Convert.ToInt32(rb3.Text);
                            if (bll.ChangeNotaFI(notaFI))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb4.Checked)
                        {
                            notaFI = Convert.ToInt32(rb4.Text);
                            if (bll.ChangeNotaFI(notaFI))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                        if (rb5.Checked)
                        {
                            notaFI = Convert.ToInt32(rb5.Text);
                            if (bll.ChangeNotaFI(notaFI))
                            {
                                MessageBox.Show("Puntuación guardada");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Ya tienes una valoración previa del curso. ¿Quieres modificarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (rb1.Checked)
                            {
                                notaFI = Convert.ToInt32(rb1.Text);
                                if (bll.ChangeNotaFI(notaFI))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb2.Checked)
                            {
                                notaFI = Convert.ToInt32(rb2.Text);
                                if (bll.ChangeNotaFI(notaFI))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb3.Checked)
                            {
                                notaFI = Convert.ToInt32(rb3.Text);
                                if (bll.ChangeNotaFI(notaFI))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb4.Checked)
                            {
                                notaFI = Convert.ToInt32(rb4.Text);
                                if (bll.ChangeNotaFI(notaFI))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                            if (rb5.Checked)
                            {
                                notaFI = Convert.ToInt32(rb5.Text);
                                if (bll.ChangeNotaFI(notaFI))
                                {
                                    MessageBox.Show("Puntuación modificada");
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
