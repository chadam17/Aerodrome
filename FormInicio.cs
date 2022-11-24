using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Final.BasicLogicLayer;

namespace Final
{
    /// <summary>
    /// Formulario principal de la aplicación
    /// </summary>

    public partial class FormInicio : Form
    {
        /// <summary>
        /// Declaraciones estáticas para generar el array de UserControl
        /// </summary>
        public static BasicLogic bll = new BasicLogic();
        public static DataTable dt2 = bll.GetItems();
        public static MyUserControl[] listItems = new MyUserControl[dt2.Rows.Count];
        /// <summary>
        /// Instancia del formulario de adición, para poder utilizar sus componentes desde FormInicio
        /// </summary>
        public FormAdd fa = new FormAdd();
        /// <summary>
        /// Instanciamos el formulario principal de la aplicación, llamando a su vez a una función que aumenta el tamaño máximo de las imágenes automáticamente a 4GB.
        /// </summary>
        public FormInicio()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Size = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            bll.IncreaseData();
            bll.IncreaseDataUsers();
            bll.IncreaseDataMembers();
            bll.IncreaseDataNews();
            bll.IncreaseDataLicense();
            btHelp.Enabled = false;
        }
        /// <summary>
        /// Método que se asegura de que al cargar por primera vez el formulario inicial, las etiquetas del UserControl no sean visibles (hasta que se muestren los datos en el FlowLayoutPanel)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInicio_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Gestión del evento del botón de ayuda al usuario. Muestra un mensaje descriptivo con el funcionamiento básico de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btHelp_Click(object sender, EventArgs e)
        {
            SetActivePanel(UCHelp);
            btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
            btLicencias.BackColor = Color.FromArgb(3, 23, 46);
            btMembresia.BackColor = Color.FromArgb(3, 23, 46);
            btSoporte.BackColor = Color.FromArgb(3, 23, 46);
            btHelp.BackColor = Color.DarkCyan;
            btExit.BackColor = Color.FromArgb(3, 23, 46);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
            btLicencias.BackColor = Color.FromArgb(3, 23, 46);
            btMembresia.BackColor = Color.FromArgb(3, 23, 46);
            btSoporte.BackColor = Color.FromArgb(3, 23, 46);
            btHelp.BackColor = Color.FromArgb(3, 23, 46);
            btExit.BackColor = Color.DarkCyan;
            DialogResult dr = MessageBox.Show("La aplicación se cerrará. ¿Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
                Close();
        }

        public static void SetActivePanel(UserControl control)
        {
            UCAeronaves.Visible = false;
            UCLicencias.Visible = false;
            UCMembresia.Visible = false;
            UCSoporte.Visible = false;
            UCPortada.Visible = false;
            UCHelp.Visible = false;
            control.Visible = true;
        }

        private void btAeronaves_Click(object sender, EventArgs e)
        {
            SetActivePanel(UCAeronaves);
            btAeronaves.BackColor = Color.DarkCyan;
            btLicencias.BackColor = Color.FromArgb(3, 23, 46);
            btMembresia.BackColor = Color.FromArgb(3, 23, 46);
            btSoporte.BackColor = Color.FromArgb(3, 23, 46);
            btHelp.BackColor = Color.FromArgb(3, 23, 46);
            btExit.BackColor = Color.FromArgb(3, 23, 46);
        }

        private void btLicencias_Click(object sender, EventArgs e)
        {
            SetActivePanel(UCLicencias);
            btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
            btLicencias.BackColor = Color.DarkCyan;
            btMembresia.BackColor = Color.FromArgb(3, 23, 46);
            btSoporte.BackColor = Color.FromArgb(3, 23, 46);
            btHelp.BackColor = Color.FromArgb(3, 23, 46);
            btExit.BackColor = Color.FromArgb(3, 23, 46);
        }

        private void btMembresia_Click(object sender, EventArgs e)
        {
            SetActivePanel(UCMembresia);
            btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
            btLicencias.BackColor = Color.FromArgb(3, 23, 46);
            btMembresia.BackColor = Color.DarkCyan;
            btSoporte.BackColor = Color.FromArgb(3, 23, 46);
            btHelp.BackColor = Color.FromArgb(3, 23, 46);
            btExit.BackColor = Color.FromArgb(3, 23, 46);
            //UserControlMembresia.flowM.BackColor = Color.FromArgb(128, 128, 128, 128);
            //UserControlMembresia.panelBtMod.BackColor = Color.FromArgb(128, 128, 128, 128);
        }

        private void btSoporte_Click(object sender, EventArgs e)
        {
            SetActivePanel(UCSoporte);
            btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
            btLicencias.BackColor = Color.FromArgb(3, 23, 46);
            btMembresia.BackColor = Color.FromArgb(3, 23, 46);
            btSoporte.BackColor = Color.DarkCyan;
            btHelp.BackColor = Color.FromArgb(3, 23, 46);
            btExit.BackColor = Color.FromArgb(3, 23, 46);               
        }

        private void pictLogoNimbo_Click(object sender, EventArgs e)
        {
            SetActivePanel(UCPortada);
            btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
            btLicencias.BackColor = Color.FromArgb(3, 23, 46);
            btMembresia.BackColor = Color.FromArgb(3, 23, 46);
            btSoporte.BackColor = Color.FromArgb(3, 23, 46);
            btHelp.BackColor = Color.FromArgb(3, 23, 46);
            btExit.BackColor = Color.FromArgb(3, 23, 46);
        }

        private void btAeronaves_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetActivePanel(UCAeronaves);
                btAeronaves.BackColor = Color.DarkCyan;
                btLicencias.BackColor = Color.FromArgb(3, 23, 46);
                btMembresia.BackColor = Color.FromArgb(3, 23, 46);
                btSoporte.BackColor = Color.FromArgb(3, 23, 46);
                btHelp.BackColor = Color.FromArgb(3, 23, 46);
                btExit.BackColor = Color.FromArgb(3, 23, 46);
            }
        }

        private void btLicencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetActivePanel(UCLicencias);
                btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
                btLicencias.BackColor = Color.DarkCyan;
                btMembresia.BackColor = Color.FromArgb(3, 23, 46);
                btSoporte.BackColor = Color.FromArgb(3, 23, 46);
                btHelp.BackColor = Color.FromArgb(3, 23, 46);
                btExit.BackColor = Color.FromArgb(3, 23, 46);
            }
        }

        private void btMembresia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetActivePanel(UCMembresia);
                btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
                btLicencias.BackColor = Color.FromArgb(3, 23, 46);
                btMembresia.BackColor = Color.DarkCyan;
                btSoporte.BackColor = Color.FromArgb(3, 23, 46);
                btHelp.BackColor = Color.FromArgb(3, 23, 46);
                btExit.BackColor = Color.FromArgb(3, 23, 46);
            }
        }

        private void btSoporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetActivePanel(UCSoporte);
                btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
                btLicencias.BackColor = Color.FromArgb(3, 23, 46);
                btMembresia.BackColor = Color.FromArgb(3, 23, 46);
                btSoporte.BackColor = Color.DarkCyan;
                btHelp.BackColor = Color.FromArgb(3, 23, 46);
                btExit.BackColor = Color.FromArgb(3, 23, 46);
            }
        }

        private void btHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetActivePanel(UCHelp); 
                btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
                btLicencias.BackColor = Color.FromArgb(3, 23, 46);
                btMembresia.BackColor = Color.FromArgb(3, 23, 46);
                btSoporte.BackColor = Color.FromArgb(3, 23, 46);
                btHelp.BackColor = Color.DarkCyan;
                btExit.BackColor = Color.FromArgb(3, 23, 46);
            }
        }

        private void btExit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAeronaves.BackColor = Color.FromArgb(3, 23, 46);
                btLicencias.BackColor = Color.FromArgb(3, 23, 46);
                btMembresia.BackColor = Color.FromArgb(3, 23, 46);
                btSoporte.BackColor = Color.FromArgb(3, 23, 46);
                btHelp.BackColor = Color.FromArgb(3, 23, 46);
                btExit.BackColor = Color.DarkCyan;
                DialogResult dr = MessageBox.Show("La aplicación se cerrará. ¿Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    Close();
            }
        }
        public static void desbloqueo()
        {
            if (UserControlPortada.isClicked && (UserControlPortada.login == true))
            {
                SetActivePanel(UCAeronaves);
                btAeronaves.Enabled = true;
                btLicencias.Enabled = true;
                btMembresia.Enabled = true;
                btSoporte.Enabled = true;
                btHelp.Enabled = true;
            }
            else
            {
                SetActivePanel(UCPortada);
                UCAeronaves.flow.Controls.Clear();
                UCMembresia.flowM.Controls.Clear();
                UCLicencias.flowL.Controls.Clear();
                UserControlHelp.txtHelpAeronaves.Visible = false;
                UserControlHelp.txtHelpLicencias.Visible = false;
                UserControlHelp.txtHelpMembresia.Visible = false;
                UCAeronaves.panelInicio.Visible = false;
                btAeronaves.Enabled = false;
                btLicencias.Enabled = false;
                btMembresia.Enabled = false;
                btSoporte.Enabled = false;
                btHelp.Enabled = false;
            }
        }
    }
}
