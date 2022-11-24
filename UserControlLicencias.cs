using Final.BasicLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Final
{
    public partial class UserControlLicencias : UserControl
    {
        public static BasicLogic bll = new BasicLogic();
        public static DataTable dt2 = bll.GetItems();
        public static MyUserControlLicencias[] listItems = new MyUserControlLicencias[dt2.Rows.Count];
        public static List<string> alumnos;
        public UserControlLicencias()
        {
            InitializeComponent();
            bll.IncreaseDataLicense();
        }

        private void UserControlLicencias_Load(object sender, System.EventArgs e)
        {
            flowL.BackColor = Color.FromArgb(128, 128, 128, 128);
        }

        public void GenerateDynamicUserControl()
        {
            try
            {
                flowL.Controls.Clear();
                BasicLogic bll = new BasicLogic();
                DataTable dt = bll.GetLicenses();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        listItems = new MyUserControlLicencias[dt.Rows.Count];

                        for (int i = 0; i < 1; i++)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                listItems[i] = new MyUserControlLicencias();

                                listItems[i].Titulo = row["nombre"].ToString();
                                listItems[i].Descripcion = row["descripcion"].ToString();
                                listItems[i].Lugar = row["lugar"].ToString();
                                listItems[i].Precio = (int)row["precio"];
                                listItems[i].Puntuacion = (decimal)row["puntuacion"];
                                listItems[i].Alumnos = row["alumnos"].ToString();
                                
                                MemoryStream ms = new MemoryStream((byte[])row["foto"]); 
                                ms.Position = 0;
                                listItems[i].Icon = new Bitmap(ms);

                                decimal resultado;
                                if ((listItems[i].Titulo == "Piloto Privado (PPL)"))
                                {
                                    try
                                    { 
                                        resultado = Convert.ToDecimal(bll.SumPPL() / bll.CountPPL());
                                        resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                        bll.ChangeMarkPPL(resultado);
                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                        if ((resultado >= 1) && (resultado < 2))
                                        {
                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                        }
                                        else
                                        {
                                            if ((resultado >= 2) && (resultado < 3))
                                            {
                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                            }
                                            else
                                            {
                                                if ((resultado >= 3) && (resultado < 4))
                                                {
                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                }
                                                else
                                                {
                                                    if ((resultado >= 4) && (resultado <= 5))
                                                    {
                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                    }
                                                }
                                            }
                                        }
                                        if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                        {
                                            listItems[i].pictStar.Location = new Point(35, 126);
                                        }
                                        else
                                        {
                                            listItems[i].pictStar.Location = new Point(52, 126);
                                        }
                                    } catch (NullReferenceException nre)
                                    {
                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                    } catch (DivideByZeroException dbze)
                                    {
                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    if ((listItems[i].Titulo == "Piloto de Ultraligero (ULM)"))
                                    {
                                        try
                                        {
                                            resultado = Convert.ToDecimal(bll.SumULM() / bll.CountULM());
                                            resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                            bll.ChangeMarkULM(resultado);
                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                            if ((resultado >= 1) && (resultado < 2))
                                            {
                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                            }
                                            else
                                            {
                                                if ((resultado >= 2) && (resultado < 3))
                                                {
                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                }
                                                else
                                                {
                                                    if ((resultado >= 3) && (resultado < 4))
                                                    {
                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                    }
                                                    else
                                                    {
                                                        if ((resultado >= 4) && (resultado <= 5))
                                                        {
                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                        }
                                                    }
                                                }
                                            }
                                            if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                            {
                                                listItems[i].pictStar.Location = new Point(35, 126);
                                            }
                                            else
                                            {
                                                listItems[i].pictStar.Location = new Point(52, 126);
                                            }
                                        }
                                        catch (NullReferenceException nre)
                                        {
                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                        }
                                        catch (DivideByZeroException dbze)
                                        {
                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                        }
                                    }
                                    else
                                    {
                                        if ((listItems[i].Titulo == "Vehículo Aéreo No Tripulado (RPAS)"))
                                        {
                                            try
                                            {
                                                resultado = Convert.ToDecimal(bll.SumRPAS() / bll.CountRPAS());
                                                resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                bll.ChangeMarkRPAS(resultado);
                                                listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                if ((resultado >= 1) && (resultado < 2))
                                                {
                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                }
                                                else
                                                {
                                                    if ((resultado >= 2) && (resultado < 3))
                                                    {
                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                    }
                                                    else
                                                    {
                                                        if ((resultado >= 3) && (resultado < 4))
                                                        {
                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                        }
                                                        else
                                                        {
                                                            if ((resultado >= 4) && (resultado <= 5))
                                                            {
                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                {
                                                    listItems[i].pictStar.Location = new Point(35, 126);
                                                }
                                                else
                                                {
                                                    listItems[i].pictStar.Location = new Point(52, 126);
                                                }
                                            }
                                            catch (NullReferenceException nre)
                                            {
                                                listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                            }
                                            catch (DivideByZeroException dbze)
                                            {
                                                listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            if ((listItems[i].Titulo == "Piloto de Helicópteros (HPL)"))
                                            {
                                                try
                                                {
                                                    resultado = Convert.ToDecimal(bll.SumHPL() / bll.CountHPL());
                                                    resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                    bll.ChangeMarkHPL(resultado);
                                                    listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                    if ((resultado >= 1) && (resultado < 2))
                                                    {
                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                    }
                                                    else
                                                    {
                                                        if ((resultado >= 2) && (resultado < 3))
                                                        {
                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                        }
                                                        else
                                                        {
                                                            if ((resultado >= 3) && (resultado < 4))
                                                            {
                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                            }
                                                            else
                                                            {
                                                                if ((resultado >= 4) && (resultado <= 5))
                                                                {
                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                    {
                                                        listItems[i].pictStar.Location = new Point(35, 126);
                                                    }
                                                    else
                                                    {
                                                        listItems[i].pictStar.Location = new Point(52, 126);
                                                    }
                                                }
                                                catch (NullReferenceException nre)
                                                {
                                                    listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                }
                                                catch (DivideByZeroException dbze)
                                                {
                                                    listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                }
                                            }
                                            else
                                            {
                                                if ((listItems[i].Titulo == "Piloto de Combate Aéreo (AFL)"))
                                                {
                                                    try
                                                    {
                                                        resultado = Convert.ToDecimal(bll.SumAFL() / bll.CountAFL());
                                                        resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                        bll.ChangeMarkAFL(resultado);
                                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                        if ((resultado >= 1) && (resultado < 2))
                                                        {
                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                        }
                                                        else
                                                        {
                                                            if ((resultado >= 2) && (resultado < 3))
                                                            {
                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                            }
                                                            else
                                                            {
                                                                if ((resultado >= 3) && (resultado < 4))
                                                                {
                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                                }
                                                                else
                                                                {
                                                                    if ((resultado >= 4) && (resultado <= 5))
                                                                    {
                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                        {
                                                            listItems[i].pictStar.Location = new Point(35, 126);
                                                        }
                                                        else
                                                        {
                                                            listItems[i].pictStar.Location = new Point(52, 126);
                                                        }
                                                    }
                                                    catch (NullReferenceException nre)
                                                    {
                                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                    }
                                                    catch (DivideByZeroException dbze)
                                                    {
                                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                    }
                                                }
                                                else
                                                {
                                                    if ((listItems[i].Titulo == "Piloto Comercial (CPL)"))
                                                    {
                                                        try
                                                        {
                                                            resultado = Convert.ToDecimal(bll.SumCPL() / bll.CountCPL());
                                                            resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                            bll.ChangeMarkCPL(resultado);
                                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                            if ((resultado >= 1) && (resultado < 2))
                                                            {
                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                            }
                                                            else
                                                            {
                                                                if ((resultado >= 2) && (resultado < 3))
                                                                {
                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                                }
                                                                else
                                                                {
                                                                    if ((resultado >= 3) && (resultado < 4))
                                                                    {
                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                                    }
                                                                    else
                                                                    {
                                                                        if ((resultado >= 4) && (resultado <= 5))
                                                                        {
                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                            {
                                                                listItems[i].pictStar.Location = new Point(35, 126);
                                                            }
                                                            else
                                                            {
                                                                listItems[i].pictStar.Location = new Point(52, 126);
                                                            }
                                                        }
                                                        catch (NullReferenceException nre)
                                                        {
                                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                        }
                                                        catch (DivideByZeroException dbze)
                                                        {
                                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if ((listItems[i].Titulo == "Piloto de Transporte de Línea Aérea (ATPL)"))
                                                        {
                                                            try
                                                            {
                                                                resultado = Convert.ToDecimal(bll.SumATPL() / bll.CountATPL());
                                                                resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                                bll.ChangeMarkATPL(resultado);
                                                                listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                                if ((resultado >= 1) && (resultado < 2))
                                                                {
                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                }
                                                                else
                                                                {
                                                                    if ((resultado >= 2) && (resultado < 3))
                                                                    {
                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                                    }
                                                                    else
                                                                    {
                                                                        if ((resultado >= 3) && (resultado < 4))
                                                                        {
                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                                        }
                                                                        else
                                                                        {
                                                                            if ((resultado >= 4) && (resultado <= 5))
                                                                            {
                                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                                {
                                                                    listItems[i].pictStar.Location = new Point(35, 126);
                                                                }
                                                                else
                                                                {
                                                                    listItems[i].pictStar.Location = new Point(52, 126);
                                                                }
                                                            }
                                                            catch (NullReferenceException nre)
                                                            {
                                                                listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                            }
                                                            catch (DivideByZeroException dbze)
                                                            {
                                                                listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if ((listItems[i].Titulo == "Piloto de Globo Aerostático (BPL)"))
                                                            {
                                                                try
                                                                {
                                                                    resultado = Convert.ToDecimal(bll.SumBPL() / bll.CountBPL());
                                                                    resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                                    bll.ChangeMarkBPL(resultado);
                                                                    listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                                    if ((resultado >= 1) && (resultado < 2))
                                                                    {
                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                    }
                                                                    else
                                                                    {
                                                                        if ((resultado >= 2) && (resultado < 3))
                                                                        {
                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                                        }
                                                                        else
                                                                        {
                                                                            if ((resultado >= 3) && (resultado < 4))
                                                                            {
                                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                                            }
                                                                            else
                                                                            {
                                                                                if ((resultado >= 4) && (resultado <= 5))
                                                                                {
                                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                                    {
                                                                        listItems[i].pictStar.Location = new Point(35, 126);
                                                                    }
                                                                    else
                                                                    {
                                                                        listItems[i].pictStar.Location = new Point(52, 126);
                                                                    }
                                                                }
                                                                catch (NullReferenceException nre)
                                                                {
                                                                    listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                }
                                                                catch (DivideByZeroException dbze)
                                                                {
                                                                    listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if ((listItems[i].Titulo == "Piloto de Planeador (SPL)"))
                                                                {
                                                                    try
                                                                    {
                                                                        resultado = Convert.ToDecimal(bll.SumSPL() / bll.CountSPL());
                                                                        resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                                        bll.ChangeMarkSPL(resultado);
                                                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                                        if ((resultado >= 1) && (resultado < 2))
                                                                        {
                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                        }
                                                                        else
                                                                        {
                                                                            if ((resultado >= 2) && (resultado < 3))
                                                                            {
                                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                                            }
                                                                            else
                                                                            {
                                                                                if ((resultado >= 3) && (resultado < 4))
                                                                                {
                                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((resultado >= 4) && (resultado <= 5))
                                                                                    {
                                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                                        {
                                                                            listItems[i].pictStar.Location = new Point(35, 126);
                                                                        }
                                                                        else
                                                                        {
                                                                            listItems[i].pictStar.Location = new Point(52, 126);
                                                                        }
                                                                    }
                                                                    catch (NullReferenceException nre)
                                                                    {
                                                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                    }
                                                                    catch (DivideByZeroException dbze)
                                                                    {
                                                                        listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if ((listItems[i].Titulo == "Instructor de Vuelo (FI)"))
                                                                    {
                                                                        try
                                                                        {
                                                                            resultado = Convert.ToDecimal(bll.SumFI() / bll.CountFI());
                                                                            resultado = (decimal)System.Math.Round(resultado, 1, MidpointRounding.ToEven);
                                                                            bll.ChangeMarkFI(resultado);
                                                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(resultado);
                                                                            if ((resultado >= 1) && (resultado < 2))
                                                                            {
                                                                                listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                            }
                                                                            else
                                                                            {
                                                                                if ((resultado >= 2) && (resultado < 3))
                                                                                {
                                                                                    listItems[i].lbPuntuacionActual.ForeColor = Color.Orange;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((resultado >= 3) && (resultado < 4))
                                                                                    {
                                                                                        listItems[i].lbPuntuacionActual.ForeColor = Color.White;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if ((resultado >= 4) && (resultado <= 5))
                                                                                        {
                                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Lime;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            if (listItems[i].lbPuntuacionActual.Text.Length == 1)
                                                                            {
                                                                                listItems[i].pictStar.Location = new Point(35, 126);
                                                                            }
                                                                            else
                                                                            {
                                                                                listItems[i].pictStar.Location = new Point(52, 126);
                                                                            }
                                                                        }
                                                                        catch (NullReferenceException nre)
                                                                        {
                                                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                        }
                                                                        catch (DivideByZeroException dbze)
                                                                        {
                                                                            listItems[i].lbPuntuacionActual.Text = Convert.ToString(0);
                                                                            listItems[i].lbPuntuacionActual.ForeColor = Color.Red;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if ((MyUserControlLicencias.alumnosPPL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto Privado (PPL)")))
                                {
                                    listItems[i].btMatricularse.Visible = false;
                                    listItems[i].btCancelarMat.Location = new Point(524, 512);
                                    listItems[i].btCancelarMat.Visible = true;
                                }
                                else
                                {
                                    if ((MyUserControlLicencias.alumnosULM.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto de Ultraligero (ULM)")))
                                    {
                                        listItems[i].btMatricularse.Visible = false;
                                        listItems[i].btCancelarMat.Location = new Point(524, 512);
                                        listItems[i].btCancelarMat.Visible = true;
                                    }
                                    else
                                    {
                                        if ((MyUserControlLicencias.alumnosRPAS.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Vehículo Aéreo No Tripulado (RPAS)")))
                                        {
                                            listItems[i].btMatricularse.Visible = false;
                                            listItems[i].btCancelarMat.Location = new Point(524, 512);
                                            listItems[i].btCancelarMat.Visible = true;
                                        }
                                        else
                                        {
                                            if ((MyUserControlLicencias.alumnosHPL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto de Helicópteros (HPL)")))
                                            {
                                                listItems[i].btMatricularse.Visible = false;
                                                listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                listItems[i].btCancelarMat.Visible = true;
                                            }
                                            else
                                            {
                                                if ((MyUserControlLicencias.alumnosAFL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto de Combate Aéreo (AFL)")))
                                                {
                                                    listItems[i].btMatricularse.Visible = false;
                                                    listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                    listItems[i].btCancelarMat.Visible = true;
                                                }
                                                else
                                                {
                                                    if ((MyUserControlLicencias.alumnosCPL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto Comercial (CPL)")))
                                                    {
                                                        listItems[i].btMatricularse.Visible = false;
                                                        listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                        listItems[i].btCancelarMat.Visible = true;
                                                    }
                                                    else
                                                    {
                                                        if ((MyUserControlLicencias.alumnosATPL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto de Transporte de Línea Aérea (ATPL)")))
                                                        {
                                                            listItems[i].btMatricularse.Visible = false;
                                                            listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                            listItems[i].btCancelarMat.Visible = true;
                                                        }
                                                        else
                                                        {
                                                            if ((MyUserControlLicencias.alumnosBPL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto de Globo Aerostático (BPL)")))
                                                            {
                                                                listItems[i].btMatricularse.Visible = false;
                                                                listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                                listItems[i].btCancelarMat.Visible = true;
                                                            }
                                                            else
                                                            {
                                                                if ((MyUserControlLicencias.alumnosSPL.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Piloto de Planeador (SPL)")))
                                                                {
                                                                    listItems[i].btMatricularse.Visible = false;
                                                                    listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                                    listItems[i].btCancelarMat.Visible = true;
                                                                }
                                                                else
                                                                { 
                                                                    if ((MyUserControlLicencias.alumnosFI.Contains(UserControlPortada.txtEmailLogin.Text) && (listItems[i].Titulo == "Instructor de Vuelo (FI)")))
                                                                    {
                                                                        listItems[i].btMatricularse.Visible = false;
                                                                        listItems[i].btCancelarMat.Location = new Point(524, 512);
                                                                        listItems[i].btCancelarMat.Visible = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        listItems[i].btMatricularse.Visible = true;
                                                                        listItems[i].btCancelarMat.Visible = false;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }                    
                                }
                                if (UserControlPortada.txtEmailLogin.Text != "admin@nimboaircraft.com")
                                {
                                    listItems[i].lbPrecioRot.Location = new Point(500, listItems[i].lbPrecioRot.Location.Y);
                                    listItems[i].lbPrecioLicencia.Location = new Point(572, listItems[i].lbPrecioLicencia.Location.Y);
                                    listItems[i].labelEuroL.Location = new Point(652, listItems[i].labelEuroL.Location.Y);
                                }
                                listItems[i].labelEuroL.Location =  new Point(listItems[i].lbPrecioLicencia.Location.X+(listItems[i].lbPrecioLicencia.Text.Length*12), listItems[i].labelEuroL.Location.Y);
                                flowL.Controls.Add(listItems[i]);

                                listItems[i].Click += new System.EventHandler(this.MyUserControlLicencias_Click);
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
        void MyUserControlLicencias_Click(object sender, EventArgs e)
        {
            MyUserControlLicencias obj = (MyUserControlLicencias)sender;

        }

        private void btLicencias_Click(object sender, EventArgs e)
        {
            MyUserControlLicencias.nombresLicencias = bll.GetLicenciasNames();
            MyUserControlLicencias.alumnosPPL = bll.GetAlumnosPPL();
            MyUserControlLicencias.alumnosULM = bll.GetAlumnosULM();
            MyUserControlLicencias.alumnosRPAS = bll.GetAlumnosRPAS();
            MyUserControlLicencias.alumnosHPL = bll.GetAlumnosHPL();
            MyUserControlLicencias.alumnosAFL = bll.GetAlumnosAFL();
            MyUserControlLicencias.alumnosCPL = bll.GetAlumnosCPL();
            MyUserControlLicencias.alumnosATPL = bll.GetAlumnosATPL();
            MyUserControlLicencias.alumnosBPL = bll.GetAlumnosBPL();
            MyUserControlLicencias.alumnosSPL = bll.GetAlumnosSPL();
            MyUserControlLicencias.alumnosFI = bll.GetAlumnosFI();          
            GenerateDynamicUserControl();
        }
    }
}
