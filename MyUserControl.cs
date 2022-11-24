using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Final
{
    /// <summary>
    /// Código del control personalizado
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        /// <summary>
        /// Instancia del control personalizado
        /// </summary>
        public MyUserControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// atributos o valores del control personalizado, correspondientes a las columnas de la tabla de la base de datos
        /// </summary>
        private string _fabricante;
        private string _modelo;
        private string _matricula;
        private decimal _precio;
        private decimal _velocidad;
        private int _alcance;
        private string _pais;
        private string _tipo;
        private Image _icon;

        /// <summary>
        /// Métodos setter y getter del atributo Fabricante
        /// </summary>
        [Category("Aviones")]

        public string Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; lblFabricante.Text = value; }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Modelo
        /// </summary>
        [Category("Aviones")]
        
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; lblModelo.Text = value; }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Matrícula (clave primaria)
        /// </summary>
        [Category("Aviones")]

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; lblMatricula.Text = value; }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Precio
        /// </summary>
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; lblPrecio.Text = value.ToString(); }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Velocidad
        /// </summary>
        public decimal Velocidad
        {
            get { return _velocidad; }
            set { _velocidad = value; lblVelocidad.Text = value.ToString(); }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Alcance
        /// </summary>
        public int Alcance
        {
            get { return _alcance; }
            set { _alcance = value; lblAlcance.Text = value.ToString(); }
        }
        /// <summary>
        /// Métodos setter y getter del atributo País
        /// </summary>
        public string Pais
        {
            get { return _pais; }
            set { _pais = value; lblPais.Text = value; }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Tipo
        /// </summary>
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; lblTipo.Text = value; }
        }
        /// <summary>
        /// Métodos setter y getter del atributo Icono
        /// </summary>
        [Category("Aviones")]

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictAvion.Image = value; }
        }
        /// <summary>
        /// Evento de ratón mediante el que el fondo del control personalizado cambia de color cuando el puntero se sitúa encima suyo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(96, 231, 249);
        }
        /// <summary>
        /// Evento de ratón mediante el que el fondo del control personalizado cambia de color cuando el puntero sale de su posición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyUserControl_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }
        /// <summary>
        /// Evento de ratón mediante el que el fondo del control personalizado cambia de color cuando el puntero clica sobre el control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyUserControl_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(40, 255, 255);
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
    }
}
