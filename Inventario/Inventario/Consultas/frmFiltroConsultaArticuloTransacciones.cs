﻿using CI.DAC;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CI.Consultas
{
    public partial class frmFiltroConsultaArticuloTransacciones : Form
    {
        DataTable DTLote = new DataTable();
        DataTable DTBodega = new DataTable();
        DataTable DTPaquete = new DataTable();
        DataTable DTTransaccion = new DataTable();

        string sLote, sBodega,sPaquete,sTransaccion,sAplicacion,sReferencia;
        int IDProducto = 0;

        List<object> valuesLote = new List<object>();
        List<object> valuesBodega = new List<object>();
        List<object> valuesPaquete = new List<object>();
        List<object> valuesTransaccion = new List<object>();

        DateTime FechaInicial;
        DateTime FechaFinal;



        public  frmFiltroConsultaArticuloTransacciones(int IdProducto,string sLote,string sBodega, string sPaquete,string sTransaccion, string sAplicacion,string sReferencia, DateTime FechaInicial,DateTime FechaFinal)
        {
            InitializeComponent();
            this.sLote = sLote;
            this.sBodega = sBodega;
            this.sPaquete = sPaquete;
            this.sTransaccion = sTransaccion;
            this.sAplicacion = sAplicacion;
            this.sReferencia = sReferencia;
            this.FechaInicial = FechaInicial;
            this.FechaFinal = FechaFinal;
            this.IDProducto = IdProducto;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmFiltroConsultaArticuloTransacciones_Load(object sender, EventArgs e)
        {
            DTLote = clsLoteDAC.GetData(-1,IDProducto, "*", "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupLote, DTLote, "LoteProveedor", "IDLote", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupLote, "[{'ColumnCaption':'IDLote','ColumnField':'IDLote','width':20},{'ColumnCaption':'Lote Proveedor','ColumnField':'LoteProveedor','width':90}]");
			this.slkupLote.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.slkupLote.Properties.View.OptionsSelection.MultiSelect = true;
            this.slkupLote.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.slkupLote.Popup += slkLote_Popup;          
            
            DTBodega = clsBodegaDAC.GetData(-1, "*", -1, 0).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupBodega, DTBodega, "Descr", "IDBodega", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodega, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':20},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':90}]");
			this.slkupBodega.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.slkupBodega.Properties.View.OptionsSelection.MultiSelect = true;
            this.slkupBodega.Properties.View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.slkupBodega.Popup += slkBodega_Popup;          
            
            DTTransaccion = clsGlobalTipoTransaccionDAC.Get(-1, "*", "*", "*").Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupTransaccion, DTTransaccion, "Descr", "IDTipoTran", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTransaccion, "[{'ColumnCaption':'Transaccion','ColumnField':'Transaccion','width':10},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
			this.slkupTransaccion.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.slkupTransaccion.Properties.View.GridControl.DataSource = slkupTransaccion.Properties.DataSource;
            this.slkupTransaccion.Properties.View.GridControl.ForceInitialize();
            this.slkupTransaccion.Properties.View.GridControl.BindingContext = new System.Windows.Forms.BindingContext();
            this.slkupTransaccion.Popup += slkTransaccion_Popup;          

            DTPaquete = clsPaqueteDAC.GetData(-1, "*", "*", -1, "*", 1).Tables[0];
            Util.Util.ConfigLookupEdit(this.slkupPaquete, DTPaquete, "Descr", "IDPaquete", 400,300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupPaquete, "[{'ColumnCaption':'Paquete','ColumnField':'PAQUETE','width':10},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':100}]");
			this.slkupPaquete.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.slkupPaquete.Popup += slkPaquete_Popup;          
            
            
            this.txtAplicacion.Text = (sAplicacion == "*") ? "" : sAplicacion;
            this.txtReferencia.Text = (sReferencia == "*") ? "" : sReferencia;
            this.dtpFechaInicial.Value = FechaInicial;
            this.dtpFechaFinal.Value = FechaFinal;
            
        }

        void slkLote_Popup(object sender, EventArgs e)
        {
            var edit = (SearchLookUpEdit)sender;
            //edit.Properties.View.SelectRow(0);
            setItemSelected(sLote, edit);

        }

        void slkBodega_Popup(object sender, EventArgs e)
        {
            var edit = (SearchLookUpEdit)sender;
            //edit.Properties.View.SelectRow(0);
            setItemSelected(sBodega, edit);

        }

        void slkTransaccion_Popup(object sender, EventArgs e)
        {
            var edit = (SearchLookUpEdit)sender;
            //edit.Properties.View.SelectRow(0);
            setItemSelected(sTransaccion, edit);

        }

        void slkPaquete_Popup(object sender, EventArgs e)
        {
            var edit = (SearchLookUpEdit)sender;
            //edit.Properties.View.SelectRow(0);
            setItemSelected(sPaquete, edit);

        }


        private void SetSelection(string[] values, string fieldName, GridView view)
        {
            foreach (string val in values)
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, fieldName).ToString() == val)
                        view.SelectRow(i);
                }
            }
  
        }


        private String GetFieldFind(string Nombre)
        {
            if (Nombre == "slkupLote")
                return "IDLote";
            else if (Nombre == "slkupBodega")
                return "IDBodega";
            else if (Nombre == "slkupTransaccion")
                return "IDTipoTran";
            else if (Nombre == "slkupPaquete")
                return "IDPaquete";
            else
                return "";

        }

        public String getLstFiltro(string sCampo)
        {
            String Result = "";
            switch (sCampo)
            {
                case "Lote":
                    Result = String.Join(",", valuesLote);
                    if (Result == "")
                        Result = "*";
                    break;
                case "Bodega":
                    Result = String.Join(",", valuesBodega);
                    if (Result == "")
                        Result = "*";
                    break;

                case "Transaccion":
                    Result = String.Join(",", valuesTransaccion);
                    if (Result == "")
                        Result = "*";
                    break;
                case "Paquete":
                    Result = String.Join(",", valuesPaquete);
                    if (Result == "")
                        Result = "*";
                    break;
            }

            return Result;
        }


        public DateTime GetFechaInicial()
         {
            return (DateTime)this.dtpFechaInicial.Value;
        }

        public DateTime GetFechaFinal()
        {
            return (DateTime)this.dtpFechaFinal.Value;
        }

        public String GetAplicacion()
        {
            return (this.txtAplicacion.Text.Trim() == "") ? "*" : this.txtAplicacion.Text.Trim();
        }

        public String GetReferencia()
        {
            return (this.txtReferencia.Text.Trim() == "") ? "*" : this.txtReferencia.Text.Trim();
        }

        private void setItemSelected(string sLst, SearchLookUpEdit crt)
        {
            if (sLst != "*")
            {
                String[] valores = sLst.Split(',');
                GridView view = crt.Properties.View;
                SetSelection(valores, GetFieldFind(crt.Name), view);
               
            }
        }

      
        private void slkupLote_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1View_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Lote
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDLote");
            if (e.Action == CollectionChangeAction.Add)
                valuesLote.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesLote.Remove(Valor);
        }

        private void searchLookUpEdit2View_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Bodega

            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDBodega");
            if (e.Action == CollectionChangeAction.Add)
                valuesBodega.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesBodega.Remove(Valor);
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //IDTipoTran

            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDTipoTran");
            if (e.Action == CollectionChangeAction.Add)
                valuesTransaccion.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesTransaccion.Remove(Valor);
        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //PAquete
            GridView view = sender as GridView;
            object Valor;
            Valor = view.GetRowCellValue(e.ControllerRow, "IDPaquete");
            if (e.Action == CollectionChangeAction.Add)
                valuesPaquete.Add(Valor);
            else if (e.Action == CollectionChangeAction.Remove)
                valuesPaquete.Remove(Valor);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        
    }
}
