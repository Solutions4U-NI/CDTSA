﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CI.DAC;

namespace CI
{
    public partial class frmFiltroProducto : DevExpress.XtraEditors.XtraForm
    {
        public int IDProducto {get;set;}
        public String Descripcion {get;set;}
        public String Alias {get;set;}
        public String CodigoBarra { get; set; }
        public int iEsControlado {get;set;}
        public int iEsMuestra {get;set;}
        public int iEsEtico {get;set;}
        public int TipoImpuesto {get;set;}
        public int iClasificacion1 {get;set;}
        public int iClasificacion2 {get;set;}
        public int iClasificacion3 {get;set;}
        public int iClasificacion4 {get;set;}
        public int iClasificacion5 {get;set;}
        public int iClasificacion6 { get; set; }

        public DataTable dtTipoImpuesto;
        public DataTable dtClasif1, dtClasif2, dtClasif3, dtClasif4, dtClasif5, dtClasif6;


        public frmFiltroProducto()
        {
            InitializeComponent();
            this.SetStyle(
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.UserPaint |
          ControlStyles.DoubleBuffer,
          true);
            this.Load += frmFiltroProducto_Load;
        }

        public frmFiltroProducto(int IDProducto,String sDescripcion, String sAlias,String sCodigoBarra, int iEsControlado,int iEsMuestra,int iEsEstico,
                                 int iTipoImpuesto, int iClasificacion1,int iClasificacion2, int iClasificacion3,int iClasificacion4 , int iClasificacion5, int iClasificacion6)
        {
            InitializeComponent();
            this.IDProducto = IDProducto;
            this.Descripcion = sDescripcion;
            this.Alias = sAlias;
            this.CodigoBarra = sCodigoBarra;
            this.iEsControlado = iEsControlado;
            this.iEsEtico = iEsEstico;
            this.iEsMuestra = iEsMuestra;
            this.TipoImpuesto = iTipoImpuesto;
            this.iClasificacion1 = iClasificacion1;
            this.iClasificacion2 = iClasificacion2;
            this.iClasificacion3 = iClasificacion3;
            this.iClasificacion4 = iClasificacion4;
            this.iClasificacion5 = iClasificacion5;
            this.iClasificacion6 = iClasificacion6;
            this.Load +=frmFiltroProducto_Load;
        
        }


        private void PopulateDataSearchLookup()
        {
           
            
            Util.Util.ConfigLookupEdit(this.slkImpuesto, dtTipoImpuesto, "Descr", "IDImpuesto");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkImpuesto, "[{'ColumnCaption':'IDImpuesto','ColumnField':'IDImpuesto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClasificacion1, dtClasif1, "Descr", "IDClasificacion");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasificacion1, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClasificacion2, dtClasif2, "Descr", "IDClasificacion");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasificacion2, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClasificacion3, dtClasif3, "Descr", "IDClasificacion");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasificacion3, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClasificacion4, dtClasif4, "Descr", "IDClasificacion");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasificacion4, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClasificacion5, dtClasif5, "Descr", "IDClasificacion");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasificacion5, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClasificacion6, dtClasif6, "Descr", "IDClasificacion");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasificacion6, "[{'ColumnCaption':'IDClasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
        }


        private void ActualizarEstados()
        {
            this.txtIDProducto.EditValue = (this.IDProducto == -1) ? "" : this.IDProducto.ToString();
            this.txtDescripcion.EditValue = (this.Descripcion == "*") ? "" : this.Descripcion ;
            this.txtAlias.EditValue = (this.Alias == "*") ? "" : this.Alias;
            this.txtCodigoBarra.EditValue = (this.CodigoBarra=="*") ? "":this.CodigoBarra;
            this.chkEsControlado.EditValue = Convert.ToBoolean(this.iEsControlado);
            this.chkEsMuestra.EditValue = Convert.ToBoolean(this.iEsMuestra);
            this.chkEsEtico.EditValue = Convert.ToBoolean(this.iEsEtico);
            this.slkImpuesto.EditValue = Convert.ToInt32(this.TipoImpuesto);
            this.slkupClasificacion1.EditValue = Convert.ToInt32(this.iClasificacion1);
            this.slkupClasificacion2.EditValue = Convert.ToInt32(this.iClasificacion2);
            this.slkupClasificacion3.EditValue = Convert.ToInt32(this.iClasificacion3);
            this.slkupClasificacion4.EditValue = Convert.ToInt32(this.iClasificacion4);
            this.slkupClasificacion5.EditValue = Convert.ToInt32(this.iClasificacion5);
            this.slkupClasificacion6.EditValue = Convert.ToInt32(this.iClasificacion6);
            
        }

		private void CargarDescripcionesClasificaciones()
		{
			DataTable DT = clsGrupoClasificacionDAC.GetAllData().Tables[0];

			this.lyClasificacion1.Text = DT.Rows[0]["Descr"].ToString() + ":";
			this.lyClasificacion1.Visibility = (Convert.ToBoolean(DT.Rows[0]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

			this.lyClasificacion2.Text = DT.Rows[1]["Descr"].ToString() + ":";
			this.lyClasificacion2.Visibility = (Convert.ToBoolean(DT.Rows[1]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

			this.lyClasificacion3.Text = DT.Rows[2]["Descr"].ToString() + ":";
			this.lyClasificacion3.Visibility = (Convert.ToBoolean(DT.Rows[2]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

			this.lyClasificacion4.Text = DT.Rows[3]["Descr"].ToString() + ":";
			this.lyClasificacion4.Visibility = (Convert.ToBoolean(DT.Rows[3]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

			this.lyClasificacion5.Text = DT.Rows[4]["Descr"].ToString() + ":";
			this.lyClasificacion5.Visibility = (Convert.ToBoolean(DT.Rows[4]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
								 
			this.lyClasificacion6.Text = DT.Rows[5]["Descr"].ToString() + ":";
			this.lyClasificacion6.Visibility = (Convert.ToBoolean(DT.Rows[5]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

		}

        void frmFiltroProducto_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

             dtTipoImpuesto = globalTipoImpuestoDAC.GetData(-1,"*").Tables["Data"];
             dtClasif1 = clsClasificacionDAC.GetData(-1, 1, "*").Tables["Data"];
             dtClasif2 = clsClasificacionDAC.GetData(-1, 2, "*").Tables["Data"];
             dtClasif3 = clsClasificacionDAC.GetData(-1, 3, "*").Tables["Data"];
             dtClasif4 = clsClasificacionDAC.GetData(-1, 4, "*").Tables["Data"];
             dtClasif5 = clsClasificacionDAC.GetData(-1, 5, "*").Tables["Data"];
             dtClasif6 = clsClasificacionDAC.GetData(-1, 6, "*").Tables["Data"];

         
             PopulateDataSearchLookup();

             CargarDescripcionesClasificaciones();

            ActualizarEstados();
        }


        private void ObtenerFiltro()
        {
            this.IDProducto = (this.txtIDProducto.EditValue == null || this.txtIDProducto.EditValue.ToString() =="") ? -1 : Convert.ToInt32(this.txtIDProducto.EditValue);
            this.Descripcion = (this.txtDescripcion.EditValue== null || this.txtDescripcion.EditValue.ToString() =="") ? "*": this.txtDescripcion.EditValue.ToString();
            this.Alias = (this.txtAlias.EditValue == null || this.txtAlias.EditValue.ToString() =="") ? "*": this.txtAlias.EditValue.ToString();
            this.CodigoBarra =(this.txtCodigoBarra.EditValue == null || this.txtCodigoBarra.EditValue.ToString() =="") ? "*" : this.txtCodigoBarra.EditValue.ToString();
            this.iEsControlado = Convert.ToInt32(this.chkEsControlado.EditValue);
            this.iEsMuestra = Convert.ToInt32(this.chkEsMuestra.EditValue);
            this.iEsEtico = Convert.ToInt32(this.chkEsEtico.EditValue);
            this.TipoImpuesto = (this.slkImpuesto.EditValue==null) ? -1: Convert.ToInt32(this.slkImpuesto.EditValue);
            this.iClasificacion1 = (this.slkupClasificacion1.EditValue == null) ? -1 : Convert.ToInt32(this.slkupClasificacion1.EditValue);
            this.iClasificacion2 =(this.slkupClasificacion2.EditValue==null) ? -1: Convert.ToInt32(this.slkupClasificacion2.EditValue);
            this.iClasificacion3 = (this.slkupClasificacion3.EditValue == null) ? -1: Convert.ToInt32(this.slkupClasificacion3.EditValue);
            this.iClasificacion4 = (this.slkupClasificacion4.EditValue== null) ? -1: Convert.ToInt32(this.slkupClasificacion4.EditValue);
            this.iClasificacion5 = (this.slkupClasificacion5.EditValue == null) ? -1: Convert.ToInt32(this.slkupClasificacion5.EditValue);
            this.iClasificacion6 = (this.slkupClasificacion6.EditValue==null) ? -1: Convert.ToInt32(this.slkupClasificacion6.EditValue);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ObtenerFiltro();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            //limpiar filtros
            this.chkEsControlado.EditValue = true;
            this.chkEsEtico.EditValue = true;
            this.chkEsMuestra.EditValue = true;
            this.txtAlias.EditValue = "";
            this.txtDescripcion.EditValue = "";
            this.txtIDProducto.EditValue = "";
            this.txtCodigoBarra.EditValue = "";
            this.slkImpuesto.EditValue = null;
            this.slkupClasificacion1.EditValue = null;
            this.slkupClasificacion2.EditValue = null;
            this.slkupClasificacion3.EditValue = null;
            this.slkupClasificacion4.EditValue = null;
            this.slkupClasificacion5.EditValue = null;
            this.slkupClasificacion6.EditValue = null;
            ObtenerFiltro();
            this.Close();
        }

        private void frmFiltroProducto_Load_1(object sender, EventArgs e)
        {

        }
    }
}