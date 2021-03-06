﻿using CI.DAC;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CI.Fisico
{
    public partial class frmPrintBoletasInv : Form
    {
        public enum typAccion {
            PrintBoletas,
            PrintDifBoletas,
			PrintFormatoCaptacion
        }

        private typAccion Accion;

        public frmPrintBoletasInv(typAccion pAccion)
        {
            InitializeComponent();
            this.Accion = pAccion;
        }

        private void frmPrintBoletasInv_Load(object sender, EventArgs e)
        {
			if (Accion == typAccion.PrintFormatoCaptacion)
			{
				this.slkupProveedor.Visible = true;
				this.lblProveedor.Visible = true;
				DataTable DTProveedor = clsProductoDAC.GetlstProvedores(-1, "*", -1).Tables[0];
				Util.Util.ConfigLookupEdit(this.slkupProveedor, DTProveedor, "Nombre", "IDProveedor", 400, 300);
				Util.Util.ConfigLookupEditSetViewColumns(this.slkupProveedor, "[{'ColumnCaption':'IDProveedor','ColumnField':'IDProveedor','width':20},{'ColumnCaption':'Nombre','ColumnField':'Nombre','width':90}]");
				this.slkupProveedor.Properties.ShowClearButton = true;
				this.slkupProveedor.Properties.View.OptionsView.ShowAutoFilterRow = true;
			}
			else
			{
				this.slkupProveedor.Visible = false;
				this.lblProveedor.Visible = false;
			}

			DataTable DTProducto = clsProductoDAC.GetData(-1, "*", "*", -1, -1, -1, -1, -1, -1, "*", 0, -1, -1).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupProducto, DTProducto, "Descr", "IDProducto", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupProducto, "[{'ColumnCaption':'IDProducto','ColumnField':'IDProducto','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupProducto.Properties.ShowClearButton = true;
			this.slkupProducto.Properties.View.OptionsView.ShowAutoFilterRow = true;

            DataTable DTBodega = clsBodegaDAC.GetData(-1, "*", -1, 0).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupBodega, DTBodega, "Descr", "IDBodega", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodega, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupBodega.Properties.ShowClearButton = true;
			this.slkupBodega.Properties.View.OptionsView.ShowAutoFilterRow = true;

            DataTable DTClasif1 = clsClasificacionDAC.GetData(-1,1,"*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupClasif1, DTClasif1, "Descr", "IDClasificacion", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif1, "[{'ColumnCaption':'ID','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupClasif1.Properties.ShowClearButton = true;
			this.slkupClasif1.Properties.View.OptionsView.ShowAutoFilterRow = true;

            DataTable DTClasif2 = clsClasificacionDAC.GetData(-1, 2, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupClasif2, DTClasif2, "Descr", "IDClasificacion", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif2, "[{'ColumnCaption':'ID','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupClasif2.Properties.ShowClearButton = true;
			this.slkupClasif2.Properties.View.OptionsView.ShowAutoFilterRow = true;
            
            DataTable DTClasif3 = clsClasificacionDAC.GetData(-1, 3, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupClasif3, DTClasif3, "Descr", "IDClasificacion", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif3, "[{'ColumnCaption':'ID','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupClasif3.Properties.ShowClearButton = true;
			this.slkupClasif3.Properties.View.OptionsView.ShowAutoFilterRow = true;

            DataTable DTClasif4 = clsClasificacionDAC.GetData(-1, 4, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupClasif4, DTClasif4, "Descr", "IDClasificacion", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif4, "[{'ColumnCaption':'ID','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupClasif4.Properties.ShowClearButton = true;
			this.slkupClasif4.Properties.View.OptionsView.ShowAutoFilterRow = true;

            DataTable DTClasif5 = clsClasificacionDAC.GetData(-1, 5, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupClasif5, DTClasif5, "Descr", "IDClasificacion", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif5, "[{'ColumnCaption':'ID','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupClasif5.Properties.ShowClearButton = true;
			this.slkupClasif5.Properties.View.OptionsView.ShowAutoFilterRow = true;

            DataTable DTClasif6 = clsClasificacionDAC.GetData(-1, 6, "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupClasif6, DTClasif6, "Descr", "IDClasificacion", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif6, "[{'ColumnCaption':'ID','ColumnField':'IDClasificacion','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
            this.slkupClasif6.Properties.ShowClearButton = true;
			this.slkupClasif6.Properties.View.OptionsView.ShowAutoFilterRow = true;
			
			CargarDescripcionesClasificaciones();

        }

		private void CargarDescripcionesClasificaciones()
		{
			DataTable DT = clsGrupoClasificacionDAC.GetAllData().Tables[0];

			this.lblClasif1.Text = DT.Rows[0]["Descr"].ToString() + ":";
			this.slkupClasif1.Visible = Convert.ToBoolean(DT.Rows[0]["Activo"]);
			this.lblClasif1.Visible = Convert.ToBoolean(DT.Rows[0]["Activo"]);

			this.lblClasif2.Text = DT.Rows[1]["Descr"].ToString() + ":";
			this.slkupClasif2.Visible = Convert.ToBoolean(DT.Rows[1]["Activo"]);
			this.lblClasif2.Visible = Convert.ToBoolean(DT.Rows[1]["Activo"]);

			this.lblClasif3.Text = DT.Rows[2]["Descr"].ToString() + ":";
			this.slkupClasif3.Visible = Convert.ToBoolean(DT.Rows[2]["Activo"]);
			this.lblClasif3.Visible = Convert.ToBoolean(DT.Rows[2]["Activo"]);

			this.lblClasif4.Text = DT.Rows[3]["Descr"].ToString() + ":";
			this.slkupClasif4.Visible = Convert.ToBoolean(DT.Rows[3]["Activo"]);
			this.lblClasif4.Visible = Convert.ToBoolean(DT.Rows[3]["Activo"]);

			this.lblClasif5.Text = DT.Rows[4]["Descr"].ToString() + ":";
			this.slkupClasif5.Visible = Convert.ToBoolean(DT.Rows[4]["Activo"]);
			this.lblClasif5.Visible = Convert.ToBoolean(DT.Rows[4]["Activo"]);

			this.lblClasif6.Text = DT.Rows[5]["Descr"].ToString() + ":";
			this.slkupClasif6.Visible = Convert.ToBoolean(DT.Rows[5]["Activo"]);
			this.lblClasif6.Visible = Convert.ToBoolean(DT.Rows[5]["Activo"]);

		}

        private void ImprimirBoletasdeInventario()
        {
            DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptBoletasInv.repx", true);

            SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

            SqlDataSource ds = report.DataSource as SqlDataSource;
            ds.ConnectionName = "sqlDataSource1";
            String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
            ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

            // Obtain a parameter, and set its value.
            report.Parameters["IDBodega"].Value = Convert.ToInt32(GetDefaultValue(this.slkupBodega));
            report.Parameters["IDProducto"].Value = Convert.ToInt32(GetDefaultValue(this.slkupProducto));
            report.Parameters["Clasif1"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif1));
            report.Parameters["Clasif2"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif2));
            report.Parameters["Clasif3"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif3));
            report.Parameters["Clasif4"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif4));
            report.Parameters["Clasif5"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif5));
            report.Parameters["Clasif6"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif6));
            report.Parameters["ConsolidaByProducto"].Value = Convert.ToBoolean(swichtAgrupa.EditValue);


            // Show the report's print preview.
            DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

            tool.ShowPreview();
        }


        private void ImprimirDiferenciasBoletasdeInventario()
        {
            DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptDiferenciasBoletasInv.repx", true);

            SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

            SqlDataSource ds = report.DataSource as SqlDataSource;
            ds.ConnectionName = "sqlDataSource1";
            String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
            ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

            // Obtain a parameter, and set its value.
            report.Parameters["IDBodega"].Value = Convert.ToInt32(GetDefaultValue(this.slkupBodega));
            report.Parameters["IDProducto"].Value = Convert.ToInt32(GetDefaultValue(this.slkupProducto));
            report.Parameters["Clasif1"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif1));
            report.Parameters["Clasif2"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif2));
            report.Parameters["Clasif3"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif3));
            report.Parameters["Clasif4"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif4));
            report.Parameters["Clasif5"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif5));
            report.Parameters["Clasif6"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif6));
            report.Parameters["ConsolidaByProducto"].Value = Convert.ToBoolean(swichtAgrupa.EditValue);


            // Show the report's print preview.
            DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

            tool.ShowPreview();
        }

		private void ImprimirFormatoCaptacion() {
			DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptFormatoBoletas.repx", true);

			SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

			SqlDataSource ds = report.DataSource as SqlDataSource;
			ds.ConnectionName = "sqlDataSource1";
			String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
			System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
			ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

			// Obtain a parameter, and set its value.
			report.Parameters["IDProveedor"].Value = Convert.ToInt32(GetDefaultValue(this.slkupProveedor));
			report.Parameters["IDBodega"].Value = Convert.ToInt32(GetDefaultValue(this.slkupBodega));
			report.Parameters["IDProducto"].Value = Convert.ToInt32(GetDefaultValue(this.slkupProducto));
			report.Parameters["Clasif1"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif1));
			report.Parameters["Clasif2"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif2));
			report.Parameters["Clasif3"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif3));
			report.Parameters["Clasif4"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif4));
			report.Parameters["Clasif5"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif5));
			report.Parameters["Clasif6"].Value = Convert.ToInt32(GetDefaultValue(this.slkupClasif6));


			// Show the report's print preview.
			DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

			tool.ShowPreview();
		}


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Accion == typAccion.PrintBoletas)
                ImprimirBoletasdeInventario();
            else
                ImprimirDiferenciasBoletasdeInventario();
        }

        private int GetDefaultValue(SearchLookUpEdit crt) { 
              return (this.slkupClasif1.EditValue==null) ? -1: Convert.ToInt32(this.slkupClasif1.EditValue);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
