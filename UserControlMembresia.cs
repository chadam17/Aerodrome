using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    public partial class UserControlMembresia : UserControl
    {
        public static BasicLogic bll = new BasicLogic();
        public static DataTable dt2 = bll.GetItems();
        public static MyUserControlNoticias[] listItems = new MyUserControlNoticias[dt2.Rows.Count];
        public UserControlMembresia()
        {
            InitializeComponent();
            bll.IncreaseDataUsers();
            bll.IncreaseDataMembers();
            bll.IncreaseDataNews();
        }

        private void btEditarM_Click(object sender, EventArgs e)
        {
            FormMiembroEdit fme = new FormMiembroEdit();
            try
            {
                fme.txtNombreMEdit.Text = lbNombre.Text;
                fme.numCodigoMEdit.Value = Convert.ToInt64(lbCodigo.Text);
                fme.comboNacionalidadMEdit.SelectedItem = lbNacionalidad.Text;
                fme.birthdateMEdit.Value = Convert.ToDateTime(lbFechaNac.Text);
                fme.txtPropiedadesMEdit.Text = lbPropiedades.Text;
                if (lbLicencias.Text.Contains("PPL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(0, true);
                }
                if (lbLicencias.Text.Contains("ULM"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(1, true);
                }
                if (lbLicencias.Text.Contains("RPAS"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(2, true);
                }
                if (lbLicencias.Text.Contains("HPL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(3, true);
                }
                if (lbLicencias.Text.Contains("CPL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(4, true);
                }
                if (lbLicencias.Text.Contains("AFL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(5, true);
                }
                if (lbLicencias.Text.Contains("BPL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(6, true);
                }
                if (lbLicencias.Text.Contains("ATPL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(7, true);
                }
                if (lbLicencias.Text.Contains("SPL"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(8, true);
                }
                if (lbLicencias.Text.Contains("FI"))
                {
                    fme.checkedListBoxLicenciasMEdit.SetItemChecked(9, true);
                }
                fme.numMiembroMEdit.Value = Convert.ToInt64(lbMiembro.Text);
                fme.txtDistincionesMEdit.Text = lbDistinciones.Text;
                fme.pictFotoMEdit.Image = pictIconM.Image;
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message.ToString());
            }
            fme.ShowDialog();
        }
        void MyUserControlNoticias_Click(object sender, EventArgs e)
        {
            MyUserControlNoticias obj = (MyUserControlNoticias)sender;
            
        }
        private void GenerateDynamicUserControl()
        {
            try
            {
                flowM.Controls.Clear();
                BasicLogic bll = new BasicLogic();
                DataTable dt = bll.GetNews();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        listItems = new MyUserControlNoticias[dt.Rows.Count];

                        for (int i = 0; i < 1; i++)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                listItems[i] = new MyUserControlNoticias();

                                listItems[i].Titulo = row["titulo"].ToString();
                                listItems[i].Fecha = row["fecha"].ToString();                                                               
                                listItems[i].Resumen = row["resumen"].ToString();
                                listItems[i].Cuerpo = row["cuerpo"].ToString();

                                MemoryStream ms = new MemoryStream((byte[])row["foto"]); 
                                ms.Position = 0;
                                listItems[i].Icon = new Bitmap(ms);

                                flowM.Controls.Add(listItems[i]);

                                listItems[i].Click += new System.EventHandler(this.MyUserControlNoticias_Click);
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show(nex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btNoticias_Click(object sender, EventArgs e)
        {
            GenerateDynamicUserControl();
        }

        private void UserControlMembresia_Load(object sender, EventArgs e)
        {
            flowM.BackColor = Color.FromArgb(128, 128, 128, 128);
            btChangePass.Location = new Point(5, 2);
        }

        private void btAdminUsers_Click(object sender, EventArgs e)
        {
            FormDGV fd = new FormDGV();
            fd.ShowDialog();
        }

        private void btChangePass_Click(object sender, EventArgs e)
        {
            FormPass fp = new FormPass();
            fp.ShowDialog();
        }
    }
}
