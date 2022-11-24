using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Final.DataAccessLayer;
using Final.BasicLogicLayer;
using System.IO;
using System.Collections.Generic;

namespace Final
{
    public partial class UserControlAeronaves : UserControl
    {
        /// <summary>
        /// Declaraciones estáticas para generar el array de UserControl
        /// </summary>
        public static BasicLogic bll = new BasicLogic();
        public static DataTable dt2 = bll.GetItems();
        public static MyUserControl[] listItems = new MyUserControl[dt2.Rows.Count];
        public static MyUserControl myc = new MyUserControl();
        MyUserControl[] removedControls;
        public ControlCollection ctrl;
        List<MyUserControl> removed = new List<MyUserControl>();
        /// <summary>
        /// Instancia del formulario de adición, para poder utilizar sus componentes desde FormInicio
        /// </summary>
        public FormAdd fa = new FormAdd();
        /// <summary>
        /// Instanciamos el formulario principal de la aplicación, llamando a su vez a una función que aumenta el tamaño máximo de las imágenes automáticamente a 4GB.
        /// </summary>
        public UserControlAeronaves()
        {
            InitializeComponent();
            BasicLogic bll = new BasicLogic();
            bll.IncreaseData();
        }
        /// <summary>
        /// Método que se asegura de que al cargar por primera vez el formulario inicial, las etiquetas del UserControl no sean visibles (hasta que se muestren los datos en el FlowLayoutPanel)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControlAeronaves_Load(object sender, EventArgs e)
        {
            lbFabShow.Visible = false;
            lbModShow.Visible = false;
            lbMatShow.Visible = false;
            lbPreShow.Visible = false;
            lbVelShow.Visible = false;
            lbAlcaShow.Visible = false;
            lbPaisShow.Visible = false;
            lbTipoShow.Visible = false;
            labelEuro.Visible = false;
            labelKmH.Visible = false;
            labelKm.Visible = false;
            pictIcon.Visible = false;
            lbFabricante.Text = "";
            lbModelo.Text = "";
            lbMatricula.Text = "";
            lbPrecio.Text = "";
            lbVelocidad.Text = "";
            lbAlcance.Text = "";
            lbPais.Text = "";
            lbTipo.Text = "";
            pictIcon.Visible = false;
            btDelete.Visible = false;
            btEditar.Visible = false;
            lbRotulo.Visible = false;
            panelInicio.Show();
            /*  
            MyUserControl myucEmpty = new MyUserControl();
            myucEmpty.Modelo = "avion";
            removed.Add(myucEmpty);
            */
        }
        /// <summary>
        /// Gestión del evento de clic sobre el control personalizado. Las etiquetas inicialmente vacías recogen los datos del registro seleccionado por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyUserControl_Click(object sender, EventArgs e)
        {
            MyUserControl obj = (MyUserControl)sender;

            lbFabricante.Text = obj.Fabricante;
            lbModelo.Text = obj.Modelo;
            lbMatricula.Text = obj.Matricula;
            lbPrecio.Text = Convert.ToString(bll.GetPrecioMillon()/1000000);/*Convert.ToInt64((obj.Precio) * 1000000).ToString();*/
            lbVelocidad.Text = obj.Velocidad.ToString();
            lbAlcance.Text = obj.Alcance.ToString();
            lbPais.Text = obj.Pais;
            lbTipo.Text = obj.Tipo;
            pictIcon.Image = obj.Icon;

            lbFabShow.Visible = true;
            lbModShow.Visible = true;
            lbMatShow.Visible = true;
            lbPreShow.Visible = true;
            lbVelShow.Visible = true;
            lbAlcaShow.Visible = true;
            lbPaisShow.Visible = true;
            lbTipoShow.Visible = true;
            labelEuro.Visible = true;
            labelKmH.Visible = true;
            labelKm.Visible = true;
            pictIcon.Visible = true;
            btDelete.Visible = true;
            btEditar.Visible = true;
            lbRotulo.Visible = true;
            lbFabShow.Visible = true;
            lbVelShow.Visible = true;
            lbAlcaShow.Visible = true;
            panelFicha.Visible = true;
            panelFabRot.Visible = true;
            panelFabValue.Visible = true;
            panelModRot.Visible = true;
            panelModValue.Visible = true;
            panelMatRot.Visible = true;
            panelMatValue.Visible = true;
            panelTipoRot.Visible = true;
            panelTipoValue.Visible = true;
            panelTipoValue.Visible = true;
            panelPreRot.Visible = true;
            panelPreValue.Visible = true;
            panelPaisRot.Visible = true;
            panelPaisValue.Visible = true;
            panelVelRot.Visible = true;
            panelVelValue.Visible = true;
            panelAlcRot.Visible = true;
            panelAlcValue.Visible = true;
            BackColor = SystemColors.Control;
            panelInicio.BackColor = SystemColors.ControlDark;
            panelInicio.Show();
        }
        /// <summary>
        /// Método para mostrar los controles personalizados, siendo desplegados en el FlowLayoutPanel
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// </exception>
        private void GenerateDynamicUserControl()
        {
            try
            {
                flow.Controls.Clear();
                BasicLogic bll = new BasicLogic();
                DataTable dt = bll.GetItems();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        listItems = new MyUserControl[dt.Rows.Count];

                        for (int i = 0; i < 1; i++)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                listItems[i] = new MyUserControl();

                                listItems[i].Fabricante = row["fabricante"].ToString();
                                listItems[i].Modelo = row["modelo"].ToString();
                                listItems[i].Matricula = row["matricula"].ToString();
                                listItems[i].Precio = (decimal)row["precio"];
                                listItems[i].Velocidad = (decimal)row["velocidad"];
                                listItems[i].Alcance = (int)row["alcance"];
                                listItems[i].Pais = row["pais"].ToString();
                                listItems[i].Tipo = row["tipo"].ToString();

                                MemoryStream ms = new MemoryStream((byte[])row["foto"]); //Foto
                                ms.Position = 0;
                                listItems[i].Icon = new Bitmap(ms);

                                flow.Controls.Add(listItems[i]);

                                listItems[i].Click += new System.EventHandler(this.MyUserControl_Click);
                            }
                        }
                    }
                }
                //ctrl = flow.Controls;
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
        /// <summary>
        /// Gestión del evento del botón para añadir una nueva aeronave, el cual abre un nuevo formulario para dicho fin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btAddPlane_Click(object sender, EventArgs e)
        {
            FormAdd fa = new FormAdd();
            fa.ShowDialog();
        }
        /// <summary>
        /// Gestión del evento del botón para actualizar la base de datos. Anula la visibilidad de las etiquetas e iconos y llama al método de despliegue de información de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btRefresh_Click(object sender, EventArgs e)
        {
            lbFabShow.Visible = false;
            lbModShow.Visible = false;
            lbMatShow.Visible = false;
            lbPreShow.Visible = false;
            lbVelShow.Visible = false;
            lbAlcaShow.Visible = false;
            lbPaisShow.Visible = false;
            lbTipoShow.Visible = false;
            panelFicha.Visible = false;
            panelFabRot.Visible = false;
            panelFabValue.Visible = false;
            panelModRot.Visible = false;
            panelModValue.Visible = false;
            panelMatRot.Visible = false;
            panelMatValue.Visible = false;
            panelTipoRot.Visible = false;
            panelTipoValue.Visible = false;
            panelTipoValue.Visible = false;
            panelPreRot.Visible = false;
            panelPreValue.Visible = false;
            panelPaisRot.Visible = false;
            panelPaisValue.Visible = false;
            panelVelRot.Visible = false;
            panelVelValue.Visible = false;
            panelAlcRot.Visible = false;
            panelAlcValue.Visible = false;
            labelEuro.Visible = false;
            pictIcon.Visible = false;
            lbFabricante.Text = "";
            lbModelo.Text = "";
            lbMatricula.Text = "";
            lbPrecio.Text = "";
            lbVelocidad.Text = "";
            lbAlcance.Text = "";
            lbPais.Text = "";
            lbTipo.Text = "";
            pictIcon.Visible = false;
            btDelete.Visible = false;
            btEditar.Visible = false;
            lbRotulo.Visible = false;
            txtSearch.Visible = true;
            panelSearch.Visible = true;
            lbSearch.Visible = true;
            panelInicio.Visible = true;
            GenerateDynamicUserControl();
            //removedControls = new MyUserControl[flow.Controls.Count];
            foreach (MyUserControl c in flow.Controls)
            {
                removed.Add(c);
            }
            /*
            for (int i=0; i < flow.Controls.Count; i++)
            {
                removedControls[i] = (MyUserControl)flow.Controls[i];
            }*/
        }
        /// <summary>
        /// Gestión del evento del botón para vaciar o limpiar el contenido de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Estás a punto de borrar todas las aeronaves. ¿Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                bll.ClearDatabase();
                MessageBox.Show("Todas las aeronaves han sido eliminadas de la base de datos");
                lbFabShow.Visible = false;
                lbModShow.Visible = false;
                lbMatShow.Visible = false;
                lbPreShow.Visible = false;
                lbVelShow.Visible = false;
                lbAlcaShow.Visible = false;
                lbPaisShow.Visible = false;
                lbTipoShow.Visible = false;
                labelEuro.Visible = false;
                labelKmH.Visible = false;
                labelKm.Visible = false;
                lbRotulo.Visible = false;
                lbFabricante.Text = "";
                lbModelo.Text = "";
                lbMatricula.Text = "";
                lbPrecio.Text = "";
                lbVelocidad.Text = "";
                lbAlcance.Text = "";
                lbPais.Text = "";
                lbTipo.Text = "";
                pictIcon.Visible = false;
                btEditar.Visible = false;
                btDelete.Visible = false;
                
                panelInicio.Show();

                GenerateDynamicUserControl();
            }
        }
        /// <summary>
        /// Gestión del evento del botón para eliminar un avión de la base de datos, en base a la matrícula (clave primaria) del registro seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDelete_Click(object sender, EventArgs e)
        {
            BasicLogic bll = new BasicLogic();
            if (bll.DeleteItems(lbMatricula.Text))
            {
                MessageBox.Show("Borrado correctamente");
                lbFabShow.Visible = false;
                lbModShow.Visible = false;
                lbMatShow.Visible = false;
                lbPreShow.Visible = false;
                lbVelShow.Visible = false;
                lbAlcaShow.Visible = false;
                lbPaisShow.Visible = false;
                lbTipoShow.Visible = false;
                labelEuro.Visible = false;
                labelKmH.Visible = false;
                labelKm.Visible = false;
                lbRotulo.Visible = false;
                lbFabricante.Text = "";
                lbModelo.Text = "";
                lbMatricula.Text = "";
                lbPrecio.Text = "";
                lbVelocidad.Text = "";
                lbAlcance.Text = "";
                lbPais.Text = "";
                lbTipo.Text = "";
                pictIcon.Visible = false;
                btDelete.Visible = false;
                btEditar.Visible = false;
                
                panelInicio.Show();

                GenerateDynamicUserControl();
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar");
            }
        }
        /// <summary>
        /// Evento de ratón del control personalizado, que permite marcar como seleccionado un determinado registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void userControl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listItems.Length; i++) listItems[i].IsClicked = false;
            ((MyUserControl)sender).IsClicked = true;
        }
        /// <summary>
        /// Gestión del evento del botón de editar aeronaves. Abre un nuevo formulario de edición el cual toma los valores del registro seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="FormatException"></exception>
        private void btEditar_Click(object sender, EventArgs e)
        {
            FormEdit fe = new FormEdit();
            try
            {
                fe.txtFabricanteEdit.Text = lbFabricante.Text;
                fe.txtModeloEdit.Text = lbModelo.Text;
                FormEdit.txtMatriculaEdit.Text = lbMatricula.Text;
                fe.numPrecioEdit.Value = Convert.ToDecimal(lbPrecio.Text);
                fe.numVelocidadEdit.Value = Convert.ToDecimal(lbVelocidad.Text);
                fe.numAlcanceEdit.Value = Convert.ToInt64(lbAlcance.Text);
                fe.comboPaisEdit.SelectedItem = lbPais.Text;
                fe.comboTipoEdit.SelectedItem = lbTipo.Text;
                fe.pictFotoEdit.Image = pictIcon.Image;
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message.ToString());
            }
            fe.ShowDialog();
        }
       
        /// <summary>
        /// Gestión del evento de texto cambiado del recuadro de búsqueda por modelo. Si el texto introducido coincide con parte del modelo del avión buscado, éste se mostrará dentro del FlowLayoutPanel. De lo contrario no será mostrado hasta que se pulse de nuevo el botón REFRESCAR.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {          
            string modelos = bll.GetModelos();
            //MessageBox.Show(removedControls.Length.ToString());
            //MessageBox.Show(removed.Count.ToString());
            //MessageBox.Show(ctrl.Count.ToString());
            
            foreach (MyUserControl c in flow.Controls)
            {
                try
                {
                    if (!c.Modelo.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        flow.Controls.Remove(c);
                        if (!removed.Contains(c))
                            removed.Add(c);

                    }
                    foreach (MyUserControl k in removed)
                    {
                        if (k.Modelo.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            if (!flow.Controls.Contains(k))
                            {
                                flow.Controls.Add(k);
                                //removed.Remove(k);
                            }                          
                        }
                    }
                    
                    if (String.IsNullOrEmpty(txtSearch.Text))
                    {
                        //flow.Controls.Clear();
                        GenerateDynamicUserControl();
                        removed.Clear();
                    }
                }
                catch (NullReferenceException nex)
                {
                    MessageBox.Show(nex.ToString());
                }
            }            
            
            if (String.IsNullOrEmpty(txtSearch.Text) && (flow.Controls.Count == 0))
            {
                GenerateDynamicUserControl();
                removed.Clear();
            }
        }
    }
}
