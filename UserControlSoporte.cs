using System.Threading;
using System.Windows.Forms;

namespace Final
{
    public partial class UserControlSoporte : UserControl
    {
        private int _startLeft = -200;  
        private int _endLeft = 969;      
        private int _stepSize = 10;
        public UserControlSoporte()
        {
            InitializeComponent();
        }

        private void UserControlSoporte_Load(object sender, System.EventArgs e)
        {

            timerSoporte.Enabled = true;
            panelDatos.Location = new System.Drawing.Point(-200, 99);
            /*
            for (int i=0; i < 255; i++)
            {
                panelDatos.BackColor = System.Drawing.Color.FromArgb(transparency,3, 23, 46);
                //Thread.Sleep(1000);
                transparency += 1;
            }
            */
        }

        private void timerSoporte_Tick(object sender, System.EventArgs e)
        {
            if (!panelDatos.Visible)
            {
                panelDatos.Left = _startLeft;
                panelDatos.Visible = true;
            }
          
            panelDatos.Left += _stepSize;
            
            if (panelDatos.Left > _endLeft) panelDatos.Left = _endLeft;
            
            if (panelDatos.Left == _endLeft)
            {
                timerSoporte.Enabled = false;
            }          
        }
    }
}
