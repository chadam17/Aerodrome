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
    public partial class FormAlumnos : Form
    {
        public FormAlumnos()
        {
            InitializeComponent();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void FormAlumnos_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormAlumnos_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormAlumnos_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
