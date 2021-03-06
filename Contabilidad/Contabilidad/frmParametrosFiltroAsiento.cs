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

namespace CG
{
    public partial class frmParametrosFiltroAsiento : DevExpress.XtraEditors.XtraForm
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public String ModuloFuente { get; set; }
        public String TipoAsiento { get; set; }
        public bool Mayorizado { get; set; }
        public bool Anulado { get; set; }
        public String Asiento { get; set; }
        public bool CuadreTemporal { get; set; }
        bool showAsiento = false;

		public bool isFromMayor { get; set; }

        char sCaracterConcatenacion = '~';
		

        public frmParametrosFiltroAsiento()
        {
            InitializeComponent();
            this.Load += FrmParametrosFiltroAsiento_Load;
        }

        public frmParametrosFiltroAsiento(bool showAsiento,DateTime FechaInicial,DateTime FechaFinal,String ModuloFuente,String TipoAsiento,bool Mayorizado,bool Anulado, bool CuadreTemporal,String Asiento="")
        {
            InitializeComponent();
            this.Asiento = Asiento;
            this.FechaInicial = FechaInicial;
            this.FechaFinal = FechaFinal;
            this.ModuloFuente = ModuloFuente;
            this.TipoAsiento = TipoAsiento;
            this.Mayorizado = Mayorizado;
            this.Anulado = Anulado;
            this.CuadreTemporal = CuadreTemporal;
            this.showAsiento = showAsiento;            
            this.Load += FrmParametrosFiltroAsiento_Load;
        }

        private void ActualizarEstados()
        {
            this.dtpDesde.EditValue = this.FechaInicial;
            this.txtAsiento.EditValue = this.Asiento;
            this.dtpHasta.EditValue = this.FechaFinal;
            this.chkAnulado.EditValue = this.Anulado;
            this.chkCuadreTemporal.EditValue = this.CuadreTemporal;
            this.chkMayorizado.EditValue = this.Mayorizado;

            this.lstChkModuloFuente.UnCheckAll();
            this.lstchkTipoAsiento.UnCheckAll();

            String[] sModuloF = this.ModuloFuente.Split(sCaracterConcatenacion);
            foreach (string ele in sModuloF)
            {
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem  item in this.lstChkModuloFuente.Items)
                {
                    if (item.Value.ToString() == ele)
                        item.CheckState = CheckState.Checked;
                    
                }
            }


            String[] sTipoAsiento = this.TipoAsiento.Split(sCaracterConcatenacion);
            foreach (string ele in sTipoAsiento)
            {
                

                for (int i=0;i<= this.lstchkTipoAsiento.ItemCount-1; i++)
                {
                    if (((DataRowView)this.lstchkTipoAsiento.GetItem(i))["Tipo"].ToString() == ele)
                    {
                        this.lstchkTipoAsiento.SetItemChecked(i, true);
                    }
                }
                
            }
        }

        private void FrmParametrosFiltroAsiento_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Inicializar Fechas
            this.dtpDesde.EditValue = DateTime.Now.AddDays(-15);
            this.dtpHasta.EditValue = DateTime.Now;

            CargarTipoAsiento();

            ActualizarEstados();

            if (showAsiento)
            {
                this.chkMayorizado.EditValue = true;
                this.chkMayorizado.Enabled = false;
                this.chkCuadreTemporal.EditValue = false;
                this.chkCuadreTemporal.Enabled = false;
                this.layoutAsiento.Enabled = true;
            }

			if (isFromMayor)
			{
				this.chkMayorizado.Enabled = false;
				this.chkMayorizado.EditValue = true;
			}
			else
			{
				this.chkMayorizado.Enabled = false;
				this.chkMayorizado.EditValue = false;
			}

        }

        private void CargarTipoAsiento()
        {
            this.lstchkTipoAsiento.DataSource = TipoAsientoDAC.GetData().Tables[0];
            this.lstchkTipoAsiento.ValueMember = "Tipo";
            this.lstchkTipoAsiento.DisplayMember = "Descr";
        }

        private void CargarModuloFuente()
        {
            
        }

        private void chkMayorizado_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.chkMayorizado.EditValue) == true)
            {
                this.chkCuadreTemporal.EditValue = false;
                this.chkCuadreTemporal.Enabled = false;
            }
            else
            {
                this.chkCuadreTemporal.EditValue = false;
                this.chkCuadreTemporal.Enabled = true;
            }
        }


        private void ObtenerFiltro()
        {
            this.FechaInicial = (DateTime)this.dtpDesde.EditValue;
            this.FechaFinal = (DateTime)this.dtpHasta.EditValue;

            this.Anulado = (bool)this.chkAnulado.EditValue;
            this.CuadreTemporal = (bool)this.chkCuadreTemporal.EditValue;
            this.Mayorizado = (bool)this.chkMayorizado.EditValue;
            this.Asiento = this.txtAsiento.EditValue.ToString();

            String sTiposAsiento = "";
            String sModuloFuente = "";
            
            //Tratar los tipos de Asiento
            foreach (System.Data.DataRowView item in this.lstchkTipoAsiento.CheckedItems)
            {
                sTiposAsiento += (item["Tipo"].ToString() + sCaracterConcatenacion);
            }

            if (sTiposAsiento.Length > 0)
                sTiposAsiento = sTiposAsiento.Substring(0, sTiposAsiento.Length - 1);

            this.TipoAsiento = sTiposAsiento;


            //Tratar Modulo
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in this.lstChkModuloFuente.CheckedItems)
            {
                sModuloFuente += (item.Value.ToString() + sCaracterConcatenacion);
            }

            if (sModuloFuente.Length > 0)
                sModuloFuente = sModuloFuente.Substring(0, sModuloFuente.Length - 1);

            this.ModuloFuente = sModuloFuente;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ObtenerFiltro();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSeleccAllTipoAsiento_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSeleccAllTipoAsiento.Checked == true)
                this.lstchkTipoAsiento.CheckAll();
            else
                this.lstchkTipoAsiento.UnCheckAll();
            
        }

        private void chkSeleccAllFuente_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSeleccAllFuente.Checked == true)
                this.lstChkModuloFuente.CheckAll();
            else
                this.lstChkModuloFuente.UnCheckAll();

        }

		

        
    }
}