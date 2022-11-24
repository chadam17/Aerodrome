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
    public partial class UserControlHelp : UserControl
    {
        public UserControlHelp()
        {
            InitializeComponent();
        }

        private void btHelpAeronaves_Click(object sender, EventArgs e)
        {
            txtHelpLicencias.Visible = false;
            txtHelpMembresia.Visible = false;
            if (txtHelpAeronaves.Visible == false)
                txtHelpAeronaves.Visible = true;
            else
                txtHelpAeronaves.Visible = false;
        }

        private void btHelpAeronaves_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHelpLicencias.Visible = false;
                txtHelpMembresia.Visible = false;
                if (txtHelpAeronaves.Visible == false)
                    txtHelpAeronaves.Visible = true;
                else
                    txtHelpAeronaves.Visible = false;
            }
        }

        private void btHelpLicencias_Click(object sender, EventArgs e)
        {
            txtHelpAeronaves.Visible = false;
            txtHelpMembresia.Visible = false;
            if (txtHelpLicencias.Visible == false)
                txtHelpLicencias.Visible = true;
            else
                txtHelpLicencias.Visible = false;
        }

        private void btHelpLicencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHelpAeronaves.Visible = false;
                txtHelpMembresia.Visible = false;
                if (txtHelpLicencias.Visible == false)
                    txtHelpLicencias.Visible = true;
                else
                    txtHelpLicencias.Visible = false;
            }
        }

        private void btHelpMembresia_Click(object sender, EventArgs e)
        {
            txtHelpAeronaves.Visible = false;
            txtHelpLicencias.Visible = false;
            if (txtHelpMembresia.Visible == false)
                txtHelpMembresia.Visible = true;
            else
                txtHelpMembresia.Visible = false;
        }

        private void btHelpMembresia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHelpAeronaves.Visible = false;
                txtHelpLicencias.Visible = false;
                if (txtHelpMembresia.Visible == false)
                    txtHelpMembresia.Visible = true;
                else
                    txtHelpMembresia.Visible = false;
            }
        }
    }
}
