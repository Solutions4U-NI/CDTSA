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
    public partial class frmParametrosContables : DevExpress.XtraEditors.XtraForm
    {
        DataSet _dsParametros = new DataSet();
        DataTable _dtParametros = new DataTable();
        DataTable _lstCuentasContable = new DataTable();
        DataRow _CurrentRow = null;

        public frmParametrosContables()
        {
            InitializeComponent();
            this.Load += FrmParametrosContables_Load;
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            this.btnGuardar.ItemClick += BtnGuardar_ItemClick;
            this.btnSalir.ItemClick += BtnSalir_ItemClick;
        }

        private void BtnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ObtenerDatos()
        {
            _CurrentRow["UsaSeparadorCta"]= this.chkUsaSeparadorCuenta.EditValue;
            _CurrentRow["SeparadorCta"] = this.txtSimboloSeparadorCuenta.EditValue;
            _CurrentRow["UsaPredecesor"]= this.chkUsaPredecesor.EditValue;
            _CurrentRow["charPredecesor"]= this.txtCaracterPredecesor.EditValue;
            _CurrentRow["CantCharNivel1"] = this.txtCantNivel1.EditValue;
            _CurrentRow["CantCharNivel2"]= this.txtCantNivel2.EditValue;
            _CurrentRow["CantCharNivel3"]= this.txtCantNivel3.EditValue;
            _CurrentRow["CantCharNivel4"]= this.txtCantNivel4.EditValue;
            _CurrentRow["CantCharNivel5"]= this.txtCantNivel5.EditValue;
            _CurrentRow["CantCharNivel6"] = this.txtCantNivel6.EditValue;
            _CurrentRow["IDCtaUtilidadAcumulada"]= this.slkupCuentaUtilidadAcumulada.EditValue;
            _CurrentRow["IDCtaUtilidadPeriodoIngresos"]= this.slkupCuentaUtilidadPeriodoIngresos.EditValue;
			_CurrentRow["IDCtaUtilidadPeriodoGastos"] = this.slkupCuentaUtilidadPeriodoGastos.EditValue;
			_CurrentRow["IDCtaUtilidadPeriodoCostos"] = this.slkupCuentaUtilidadPeriodoCostos.EditValue;
            _CurrentRow["MesInicioPeriodoFiscal"]= this.dtpMesInicioPeriodoFiscal.EditValue;
            _CurrentRow["MesFinalPeriodoFiscal"]= this.dtpMesFinPeriodoFiscal.EditValue;
            _CurrentRow["UsaSeparadorCentro"]= this.chkUsaSeparadorCentro.EditValue;
            _CurrentRow["SeparadorCentro"]= this.txtSeparadorCentro.EditValue;
            _CurrentRow["UsaPredecesorCentro"]= this.chkUsaPredecesorCentro.EditValue;
            _CurrentRow["charPredecesorCentro"]= this.txtPredecesorCentro.EditValue;
            _CurrentRow["LongAsiento"]= this.txtLogitudAsiento.EditValue;
            _CurrentRow["TipoCambio"] = this.slkupTipoCambio.EditValue;
        }

        private void BtnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_CurrentRow != null)
                {
                    Application.DoEvents();
                    _CurrentRow.BeginEdit();
                    ObtenerDatos();
                    _CurrentRow.EndEdit();


                    DataSet _dsChanged = _dsParametros.GetChanges(DataRowState.Modified);

                    bool okFlag = true;
                    if (_dsChanged.HasErrors)
                    {
                        okFlag = false;
                        string msg = "Error en la fila con el tipo Id";

                        foreach (DataTable tb in _dsChanged.Tables)
                        {
                            if (tb.HasErrors)
                            {
                                DataRow[] errosRow = tb.GetErrors();

                                foreach (DataRow dr in errosRow)
                                {
                                    msg = msg + dr["Centro"].ToString();
                                }
                            }
                        }


                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        ParametrosContabilidadDAC.oAdaptador.Update(_dsChanged, "Data");
                        // lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        // isEdition = false;
                        _dsParametros.AcceptChanges();
                        // PopulateGrid();
                        //HabilitarControles(false);
                        MessageBox.Show("Los Parámetros contables han sido Actualizados");
                    }
                    else
                    {
                        _dsParametros.RejectChanges();

                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        private void CargarParametros()
        {
            try
            {
                _dsParametros = ParametrosContabilidadDAC.GetData();
                _dtParametros = _dsParametros.Tables[0];
                _CurrentRow = _dsParametros.Tables[0].Rows[0];
                this.chkUsaSeparadorCuenta.EditValue = Convert.ToBoolean(_CurrentRow["UsaSeparadorCta"]);
                this.txtSimboloSeparadorCuenta.EditValue = _CurrentRow["SeparadorCta"].ToString();
                this.chkUsaPredecesor.EditValue = Convert.ToBoolean(_CurrentRow["UsaPredecesor"]);
                this.txtCaracterPredecesor.EditValue = _CurrentRow["charPredecesor"].ToString();
                this.txtCantNivel1.EditValue = _CurrentRow["CantCharNivel1"].ToString();
                this.txtCantNivel2.EditValue = _CurrentRow["CantCharNivel2"].ToString();
                this.txtCantNivel3.EditValue = _CurrentRow["CantCharNivel3"].ToString();
                this.txtCantNivel4.EditValue = _CurrentRow["CantCharNivel4"].ToString();
                this.txtCantNivel5.EditValue = _CurrentRow["CantCharNivel5"].ToString();
                this.txtCantNivel6.EditValue = _CurrentRow["CantCharNivel6"].ToString();
                this.slkupCuentaUtilidadAcumulada.EditValue = _CurrentRow["IDCtaUtilidadAcumulada"];
                this.slkupCuentaUtilidadPeriodoIngresos.EditValue = _CurrentRow["IDCtaUtilidadPeriodoIngresos"];
				this.slkupCuentaUtilidadPeriodoCostos.EditValue = _CurrentRow["IDCtaUtilidadPeriodoCostos"];
				this.slkupCuentaUtilidadPeriodoGastos.EditValue = _CurrentRow["IDCtaUtilidadPeriodoGastos"];
                this.dtpMesInicioPeriodoFiscal.EditValue = Convert.ToInt32(_CurrentRow["MesInicioPeriodoFiscal"]);
                this.dtpMesFinPeriodoFiscal.EditValue = Convert.ToInt32(_CurrentRow["MesFinalPeriodoFiscal"]);
                this.chkUsaSeparadorCentro.EditValue = Convert.ToBoolean(_CurrentRow["UsaSeparadorCentro"]);
                this.txtSeparadorCentro.EditValue = _CurrentRow["SeparadorCentro"].ToString();
                this.chkUsaPredecesorCentro.EditValue = Convert.ToBoolean(_CurrentRow["UsaPredecesorCentro"]);
                this.txtPredecesorCentro.EditValue =_CurrentRow["charPredecesorCentro"].ToString();
                this.txtLogitudAsiento.EditValue = Convert.ToInt32(_CurrentRow["LongAsiento"]);
                this.slkupTipoCambio.EditValue = _CurrentRow["TipoCambio"];
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmParametrosContables_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarParametros();
            //configurar los searchlokup
            _lstCuentasContable = CuentaContableDAC.GetData(-1,-1,-1,"*","*","*","*","*","*","*",-1,-1,1,1,-1,-1).Tables["Data"];
            Util.Util.ConfigLookupEdit(this.slkupCuentaUtilidadAcumulada, _lstCuentasContable, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaUtilidadAcumulada, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");


            Util.Util.ConfigLookupEdit(this.slkupCuentaUtilidadPeriodoIngresos, _lstCuentasContable, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaUtilidadPeriodoIngresos, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

			Util.Util.ConfigLookupEdit(this.slkupCuentaUtilidadPeriodoCostos, _lstCuentasContable, "Descr", "IDCuenta");
			Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaUtilidadPeriodoCostos, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

			Util.Util.ConfigLookupEdit(this.slkupCuentaUtilidadPeriodoGastos, _lstCuentasContable, "Descr", "IDCuenta");
			Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaUtilidadPeriodoGastos, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupTipoCambio, TipoCambioDAC.GetData("*").Tables[0], "Descr", "IDTipoCambio");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoCambio, "[{'ColumnCaption':'ID','ColumnField':'IDTipoCambio','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            this.slkupCuentaUtilidadAcumulada.Properties.ShowClearButton = true;
            this.slkupCuentaUtilidadPeriodoIngresos.Properties.ShowClearButton = true;

        }
    }
}