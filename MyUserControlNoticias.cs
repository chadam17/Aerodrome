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
    public partial class MyUserControlNoticias : UserControl
    {
        public MyUserControlNoticias()
        {
            InitializeComponent();
        }
        private string _titulo;
        private string _fecha;
        private string _resumen;
        private string _cuerpo;
        private Image _icon;

        /// <summary>
        /// Métodos setter y getter del atributo Titulo
        /// </summary>
        [Category("Noticias")]

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; lbTituloNoticia.Text = value; }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Fecha
        /// </summary>
        [Category("Noticias")]

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; lbFechaNoticia.Text = value; }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Resumen
        /// </summary>
        [Category("Noticias")]

        public string Resumen
        {
            get { return _resumen; }
            set { _resumen = value; txtResumen.Text = value; }
        }

        /// <summary>
        /// Métodos setter y getter del atributo Cuerpo
        /// </summary>
        [Category("Noticias")]

        public string Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; lbCuerpo.Text = value; }
        }

        [Category("Noticias")]

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictFotoNoticia.Image = value; }
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

        private void btAmpliarNoticia_Click(object sender, EventArgs e)
        {
            FormNoticias fn = new FormNoticias();
            try
            {
                fn.lbTituloNoticia.Text = lbTituloNoticia.Text;
                string[] day = new string[10];
                char[] convertDate = lbFechaNoticia.Text.ToArray();
                for (int i=0; i < 10; i++)
                {
                    day[i] = convertDate[i].ToString();
                }
                fn.lbFechaNoticia.Text = day[0] + day[1] + day[2] + day[3] + day[4] + day[5] + day[6] + day[7] + day[8] + day[9];
                fn.txtCuerpo.Text = lbCuerpo.Text;
                fn.pictFotoNews.Image = pictFotoNoticia.Image;
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message.ToString());
            }
            fn.ShowDialog();
        }
    }
}
