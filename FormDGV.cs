using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class FormDGV : Form
    {
        public static int index;
        private string targetUser;
        private string targetPass;
        public BasicLogic bll = new BasicLogic();
        private string correoAdmin = "admin@nimboaircraft.com";
        private string passAdmin;
        public FormMiembroDGV fmd = new FormMiembroDGV();
        public FormDGV()
        {
            InitializeComponent();
        }

        public static int GetIndex()
        {
            return index;
        }

        private void btReturnDGV_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool mouseDown;
        private Point lastLocation;

        private void FormDGV_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormDGV_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormDGV_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnRefreshDGV_Click(object sender, EventArgs e)
        {
            refreshDGV();
        }
        public static void refreshDGV()
        {
            index = 0;
            BasicLogic bll = new BasicLogic();
            dgvMembers.DataSource = bll.GetMembersByCode();
        }

        private void btnExportDGV_Click(object sender, EventArgs e)
        {
            if (dgvMembers.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "EXCEL FILE (*.xls)|*.xls";
                sfd.FileName = "Output.xls";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No se pudo guardar los datos" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dgvMembers.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dgvMembers.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvMembers.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgvMembers.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgvMembers.Rows[i - 1].Cells[j].Value + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Registros exportados correctamente", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay productos registrados", "Info");
            }
        }

        private void btnDeleteDGV_Click(object sender, EventArgs e)
        {
            string studentsPPL;
            string studentsULM;
            string studentsRPAS;
            string studentsHPL;
            string studentsAFL;
            string studentsCPL;
            string studentsATPL;
            string studentsBPL;
            string studentsSPL;
            string studentsFI;
            try
            {
                if (index != -1)
                {
                    targetUser = dgvMembers.CurrentRow.Cells[0].Value.ToString();
                    targetPass = dgvMembers.CurrentRow.Cells[1].Value.ToString();
                    if (targetUser == "admin@nimboaircraft.com")
                    {
                        MessageBox.Show("El administrador no puede ser eliminado desde la aplicación");
                        return;
                    }
                    else
                    {
                        if ((bll.DeleteUsersDGV(dgvMembers.CurrentRow.Cells[0].Value.ToString())) && (bll.DeleteVotersDGV(dgvMembers.CurrentRow.Cells[0].Value.ToString()) && (bll.DeleteMembersDGV(dgvMembers.CurrentRow.Cells[0].Value.ToString()))))
                        {
                            MyUserControlLicencias.alumnosPPL = bll.GetAlumnosPPL();
                            studentsPPL = MyUserControlLicencias.alumnosPPL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsPPL(studentsPPL);
                            MyUserControlLicencias.alumnosULM = bll.GetAlumnosULM();
                            studentsULM = MyUserControlLicencias.alumnosULM.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsULM(studentsULM);
                            MyUserControlLicencias.alumnosRPAS = bll.GetAlumnosRPAS();
                            studentsRPAS = MyUserControlLicencias.alumnosRPAS.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsRPAS(studentsRPAS);
                            MyUserControlLicencias.alumnosHPL = bll.GetAlumnosHPL();
                            studentsHPL = MyUserControlLicencias.alumnosHPL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsHPL(studentsHPL);
                            MyUserControlLicencias.alumnosAFL = bll.GetAlumnosAFL();
                            studentsAFL = MyUserControlLicencias.alumnosAFL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsAFL(studentsAFL);
                            MyUserControlLicencias.alumnosCPL = bll.GetAlumnosCPL();
                            studentsCPL = MyUserControlLicencias.alumnosCPL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsCPL(studentsCPL);
                            MyUserControlLicencias.alumnosATPL = bll.GetAlumnosATPL();
                            studentsATPL = MyUserControlLicencias.alumnosATPL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsATPL(studentsATPL);
                            MyUserControlLicencias.alumnosBPL = bll.GetAlumnosBPL();
                            studentsBPL = MyUserControlLicencias.alumnosBPL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsBPL(studentsBPL);
                            MyUserControlLicencias.alumnosSPL = bll.GetAlumnosSPL();
                            studentsSPL = MyUserControlLicencias.alumnosSPL.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsSPL(studentsSPL);
                            MyUserControlLicencias.alumnosFI = bll.GetAlumnosFI();
                            studentsFI = MyUserControlLicencias.alumnosFI.Replace(dgvMembers.CurrentRow.Cells[0].Value.ToString(), "");
                            bll.UpdateStudentsFI(studentsFI);
                            if (dgvMembers.Rows.Count == 0)
                            {
                                bll.ResetMembersDGV();
                                bll.ResetUsersDGV();
                                bll.ResetVotersDGV();
                                MyUserControlLicencias.alumnosPPL = bll.GetAlumnosPPL();
                                if (MyUserControlLicencias.alumnosPPL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsPPL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsPPL(studentsPPL);
                                }
                                else
                                {
                                    studentsPPL = "";
                                    bll.UpdateStudentsPPL(studentsPPL);
                                }
                                MyUserControlLicencias.alumnosULM = bll.GetAlumnosULM();
                                if (MyUserControlLicencias.alumnosULM.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsULM = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsULM(studentsULM);
                                }
                                else
                                {
                                    studentsULM = "";
                                    bll.UpdateStudentsULM(studentsULM);
                                }
                                MyUserControlLicencias.alumnosRPAS = bll.GetAlumnosRPAS();
                                if (MyUserControlLicencias.alumnosRPAS.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsRPAS = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsRPAS(studentsRPAS);
                                }
                                else
                                {
                                    studentsRPAS = "";
                                    bll.UpdateStudentsRPAS(studentsRPAS);
                                }
                                MyUserControlLicencias.alumnosHPL = bll.GetAlumnosHPL();
                                if (MyUserControlLicencias.alumnosHPL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsHPL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsHPL(studentsHPL);
                                }
                                else
                                {
                                    studentsHPL = "";
                                    bll.UpdateStudentsHPL(studentsHPL);
                                }
                                MyUserControlLicencias.alumnosAFL = bll.GetAlumnosAFL();
                                if (MyUserControlLicencias.alumnosAFL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsAFL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsAFL(studentsAFL);
                                }
                                else
                                {
                                    studentsAFL = "";
                                    bll.UpdateStudentsAFL(studentsAFL);
                                }
                                MyUserControlLicencias.alumnosCPL = bll.GetAlumnosCPL();
                                if (MyUserControlLicencias.alumnosCPL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsCPL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsCPL(studentsCPL);
                                }
                                else
                                {
                                    studentsCPL = "";
                                    bll.UpdateStudentsCPL(studentsCPL);
                                }
                                MyUserControlLicencias.alumnosATPL = bll.GetAlumnosATPL();
                                if (MyUserControlLicencias.alumnosATPL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsATPL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsATPL(studentsATPL);
                                }
                                else
                                {
                                    studentsATPL = "";
                                    bll.UpdateStudentsATPL(studentsATPL);
                                }
                                MyUserControlLicencias.alumnosBPL = bll.GetAlumnosBPL();
                                if (MyUserControlLicencias.alumnosBPL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsBPL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsBPL(studentsBPL);
                                }
                                else
                                {
                                    studentsBPL = "";
                                    bll.UpdateStudentsBPL(studentsBPL);
                                }
                                MyUserControlLicencias.alumnosSPL = bll.GetAlumnosSPL();
                                if (MyUserControlLicencias.alumnosSPL.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsSPL = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsSPL(studentsSPL);
                                }
                                else
                                {
                                    studentsSPL = "";
                                    bll.UpdateStudentsSPL(studentsSPL);
                                }
                                MyUserControlLicencias.alumnosFI = bll.GetAlumnosFI();
                                if (MyUserControlLicencias.alumnosFI.Contains("admin@nimboaircraft.com"))
                                {
                                    studentsFI = "admin@nimboaircraft.com";
                                    bll.UpdateStudentsFI(studentsFI);
                                }
                                else
                                {
                                    studentsFI = "";
                                    bll.UpdateStudentsFI(studentsFI);
                                }
                            }
                            UserControlPortada.emails = bll.GetEmails();
                            UserControlPortada.passwords = bll.GetPasswords();
                            dgvMembers.Rows.Remove(dgvMembers.CurrentRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " - " + ex.Source);
            }
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {              
                index = dgvMembers.CurrentRow.Index;
                if (index >= dgvMembers.RowCount)
                    index = 0;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " - " + ex.Source);
            }
        }

        private void btnModDGV_Click(object sender, EventArgs e)
        {
            try
            {
                FormMiembroEditDGV fmed = new FormMiembroEditDGV();
                try
                {
                    fmed.txtCorreoEditDGV.Text = dgvMembers.CurrentRow.Cells[0].Value.ToString();
                    fmed.txtPassEditDGV.Text = dgvMembers.CurrentRow.Cells[1].Value.ToString();
                    fmed.txtNombreMEditDGV.Text = dgvMembers.CurrentRow.Cells[2].Value.ToString();
                    fmed.numCodigoMEditDGV.Value = Convert.ToInt64(dgvMembers.CurrentRow.Cells[3].Value.ToString());
                    fmed.comboNacionalidadMEditDGV.SelectedItem = dgvMembers.CurrentRow.Cells[4].Value.ToString();
                    fmed.birthdateMEditDGV.Value = Convert.ToDateTime(dgvMembers.CurrentRow.Cells[5].Value.ToString());
                    fmed.txtPropiedadesMEditDGV.Text = dgvMembers.CurrentRow.Cells[6].Value.ToString();
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("PPL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(0, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("ULM"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(1, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("RPAS"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(2, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("HPL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(3, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("CPL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(4, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("AFL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(5, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("BPL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(6, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("ATPL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(7, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("SPL"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(8, true);
                    }
                    if (dgvMembers.CurrentRow.Cells[7].Value.ToString().Contains("FI"))
                    {
                        fmed.checkedListBoxLicenciasMEditDGV.SetItemChecked(9, true);
                    }
                    fmed.numMiembroMEditDGV.Value = Convert.ToInt64(dgvMembers.CurrentRow.Cells[8].Value.ToString());
                    fmed.txtDistincionesMEditDGV.Text = dgvMembers.CurrentRow.Cells[9].Value.ToString();
                    FormMiembroEditDGV.pictFotoMEditDGV.Image = bll.GetFotoDGV();                   
                }                                                           
                catch (FormatException fex)
                {
                    MessageBox.Show(fex.Message.ToString());
                }
                fmed.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No has seleccionado ningún usuario. ¿Has actualizado la lista de usuarios?");
            }
        }

        private void btnOrderByCode_Click(object sender, EventArgs e)
        {
            index = 0;
            dgvMembers.DataSource = bll.GetMembersByCode();
        }

        private void btnOrderByEmailDGV_Click(object sender, EventArgs e)
        {
            index = 0;
            dgvMembers.DataSource = bll.GetMembersByEmail();
        }

        private void btnCleanDGV_Click(object sender, EventArgs e)
        {
            string studentsPPL;
            string studentsULM;
            string studentsRPAS;
            string studentsHPL;
            string studentsAFL;
            string studentsCPL;
            string studentsATPL;
            string studentsBPL;
            string studentsSPL;
            string studentsFI;
            passAdmin = bll.GetAdminPass().ElementAt(0);
            try
            {
                DialogResult dr = MessageBox.Show("Estás a punto de borrar todos los usuarios (excepto el administrador). ¿Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    bll.ResetUsersDGV();
                    bll.ResetMembersDGV();
                    bll.ResetVotersDGV();
                    MyUserControlLicencias.alumnosPPL = bll.GetAlumnosPPL();
                    if (MyUserControlLicencias.alumnosPPL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsPPL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsPPL(studentsPPL);
                    }
                    else
                    {
                        studentsPPL = "";
                        bll.UpdateStudentsPPL(studentsPPL);
                    }
                    MyUserControlLicencias.alumnosULM = bll.GetAlumnosULM();
                    if (MyUserControlLicencias.alumnosULM.Contains("admin@nimboaircraft.com"))
                    {
                        studentsULM = "admin@nimboaircraft.com";
                        bll.UpdateStudentsULM(studentsULM);
                    }
                    else
                    {
                        studentsULM = "";
                        bll.UpdateStudentsULM(studentsULM);
                    }
                    MyUserControlLicencias.alumnosRPAS = bll.GetAlumnosRPAS();
                    if (MyUserControlLicencias.alumnosRPAS.Contains("admin@nimboaircraft.com"))
                    {
                        studentsRPAS = "admin@nimboaircraft.com";
                        bll.UpdateStudentsRPAS(studentsRPAS);
                    }
                    else
                    {
                        studentsRPAS = "";
                        bll.UpdateStudentsRPAS(studentsRPAS);
                    }
                    MyUserControlLicencias.alumnosHPL = bll.GetAlumnosHPL();
                    if (MyUserControlLicencias.alumnosHPL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsHPL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsHPL(studentsHPL);
                    }
                    else
                    {
                        studentsHPL = "";
                        bll.UpdateStudentsHPL(studentsHPL);
                    }
                    MyUserControlLicencias.alumnosAFL = bll.GetAlumnosAFL();
                    if (MyUserControlLicencias.alumnosAFL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsAFL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsAFL(studentsAFL);
                    }
                    else
                    {
                        studentsAFL = "";
                        bll.UpdateStudentsAFL(studentsAFL);
                    }
                    MyUserControlLicencias.alumnosCPL = bll.GetAlumnosCPL();
                    if (MyUserControlLicencias.alumnosCPL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsCPL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsCPL(studentsCPL);
                    }
                    else
                    {
                        studentsCPL = "";
                        bll.UpdateStudentsCPL(studentsCPL);
                    }
                    MyUserControlLicencias.alumnosATPL = bll.GetAlumnosATPL();
                    if (MyUserControlLicencias.alumnosATPL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsATPL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsATPL(studentsATPL);
                    }
                    else
                    {
                        studentsATPL = "";
                        bll.UpdateStudentsATPL(studentsATPL);
                    }
                    MyUserControlLicencias.alumnosBPL = bll.GetAlumnosBPL();
                    if (MyUserControlLicencias.alumnosBPL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsBPL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsBPL(studentsBPL);
                    }
                    else
                    {
                        studentsBPL = "";
                        bll.UpdateStudentsBPL(studentsBPL);
                    }
                    MyUserControlLicencias.alumnosSPL = bll.GetAlumnosSPL();
                    if (MyUserControlLicencias.alumnosSPL.Contains("admin@nimboaircraft.com"))
                    {
                        studentsSPL = "admin@nimboaircraft.com";
                        bll.UpdateStudentsSPL(studentsSPL);
                    }
                    else
                    {
                        studentsSPL = "";
                        bll.UpdateStudentsSPL(studentsSPL);
                    }
                    MyUserControlLicencias.alumnosFI = bll.GetAlumnosFI();
                    if (MyUserControlLicencias.alumnosFI.Contains("admin@nimboaircraft.com"))
                    {
                        studentsFI = "admin@nimboaircraft.com";
                        bll.UpdateStudentsFI(studentsFI);
                    }
                    else
                    {
                        studentsFI = "";
                        bll.UpdateStudentsFI(studentsFI);
                    }
                    UserControlPortada.emails = bll.GetEmails();
                    UserControlPortada.passwords = bll.GetPasswords();                   
                    index = 0;
                    dgvMembers.DataSource = bll.GetMembersByEmail();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " - " + ex.Source);
            }

        }
        private void btnAddDGV_Click(object sender, EventArgs e)
        {
            fmd.txtCorreoDGV.Text = "";
            fmd.txtPassDGV.Text = "";
            fmd.txtNombreMDGV.Text = "";
            int num = bll.GetLastCodigo();
            fmd.numCodigoMDGV.Value = num + 1;
            fmd.comboNacionalidadMDGV.SelectedItem = null;
            fmd.birthdateMDGV.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            fmd.txtPropiedadesMDGV.Text = "";
            UncheckAllItems();
            fmd.numMiembroMDGV.Value = 1981;
            fmd.txtDistincionesMDGV.Text = "";
            fmd.pictFotoMDGV.Image = Properties.Resources.disquet;
            fmd.btEyeFormMiembroDGV.Visible = true;
            fmd.txtPassDGV.UseSystemPasswordChar = true;
            fmd.btEyeClosedFormMiembroDGV.Visible = false;
            fmd.ShowDialog();
        }
        private void UncheckAllItems()
        {
            while (fmd.checkedListBoxLicenciasMDGV.CheckedIndices.Count > 0)
                fmd.checkedListBoxLicenciasMDGV.SetItemChecked(fmd.checkedListBoxLicenciasMDGV.CheckedIndices[0], false);
        }

        private void btnHelpDGV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desde esta ventana se puede gestionar la información de los usuarios de la plataforma.\n\nPuede añadir, modificar, eliminar y consultar registros que se corresponden con los datos de cada usuario. De este modo se pueden resolver incidencias. Puede ordenar el listado de miembros por código o por correo electrónico según su preferencia.\n\nEl usuario recibirá una notificación cada vez que sus datos hayan sido modificados.\n\nRecuerde que como administrador no puede borrarse a sí mismo desde la propia plataforma y tampoco se puede cambiar el email de cada usuario.\n\nSi desea generar un documento Excel con los resultados obtenidos de la base de datos, pulse el botón de Exportar Datos.\n\nPara más información, consulte con nuestro equipo técnico.\n\nEquipo de Nimbo Aircraft.", "INFORMACIÓN PARA EL ADMINISTRADOR");
        }
    }
}
