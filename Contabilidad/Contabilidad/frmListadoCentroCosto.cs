﻿using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace CG
{
    public partial class frmListadoCentroCosto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtCentro;
        private DataTable _lstCentroAcumuladores;
        private DataSet _dsCentro;
        DataRow currentRow;
        const String _tituloVentana = "Listado de Centros de Costos";
        private bool isEdition = false;
        public frmListadoCentroCosto()
        {
            InitializeComponent();
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.chkReadSystemOnly.Enabled = false;
        }



        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void frmListadoCentroCosto_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.dtg, _tituloVentana, this);

                PopulateGrid();

                EnlazarEventos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateData()
        {
            _lstCentroAcumuladores = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 1).Tables["Data"];
            Util.Util.ConfigLookupEdit(this.slkupCentroAcumulador, _lstCentroAcumuladores, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroAcumulador, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCentroAnterior, _dtCentro, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroAnterior, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");
        }

        private void PopulateGrid()
        {
            _dsCentro = CentroCostoDAC.GetData(-1, "*", "*", "*", "*", -1);

            _dtCentro = _dsCentro.Tables[0];
            this.dtg.DataSource = _dtCentro;

            PopulateData();

        }

        private void ClearControls()
        {
            this.txtNivel1.Text = "";
            this.txtNivel2.Text = "";
            this.txtNivel3.Text = "";
            this.txtCentro.Text = "";
            this.txtDescripcion.Text = "";
            this.chkActivo.EditValue = true;
            this.chkAcumulador.EditValue = false;
            this.slkupCentroAnterior.EditValue = null;
            this.slkupCentroAcumulador.EditValue = null;

        }

        private void HabilitarControles(bool Activo)
        {
            this.txtNivel1.ReadOnly = !Activo;
            this.txtNivel2.ReadOnly = !Activo;
            this.txtNivel3.ReadOnly = !Activo;
            this.txtDescripcion.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            this.chkAcumulador.ReadOnly = !Activo;
            this.slkupCentroAnterior.ReadOnly = !Activo;
            this.slkupCentroAcumulador.ReadOnly = !Activo;

            this.dtg.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;

        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView.GetDataRow(index);
                UpdateControlsFromCurrentRow(currentRow);
            }
        }

        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
            this.txtNivel1.Text = Row["Nivel1"].ToString();
            this.txtNivel2.Text = Row["Nivel2"].ToString();
            this.txtNivel3.Text = Row["Nivel3"].ToString();
            this.txtCentro.Text = Row["Centro"].ToString();
            this.txtDescripcion.Text = Row["Descr"].ToString();
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);
            this.chkAcumulador.EditValue = Convert.ToBoolean(Row["Acumulador"]);
            this.slkupCentroAnterior.EditValue = Row["IDCentroAnterior"].ToString();
            this.slkupCentroAcumulador.EditValue = Row["IDCentroAcumulador"].ToString();
            this.chkReadSystemOnly.EditValue = Row["ReadOnlySys"];

        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetCurrentRow();
        }




        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = true;
            HabilitarControles(true);
            ClearControls();
            currentRow = null;
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow == null)
            {
                lblStatus.Caption = "Por favor seleccione un elemento de la Lista";
                return;
            }
            else
                lblStatus.Caption = "";
            if (Convert.ToBoolean(currentRow["ReadOnlySys"]) == true)
            {
                lblStatus.Caption = "No se puede modificar un elemento de Sistema";
                return;
            }
            isEdition = true;
            HabilitarControles(true);
            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            //Este solo vale para el primer elemento
            if (_dtCentro.Rows.Count > 1)
                if (this.slkupCentroAnterior.EditValue == null)
                    sMensaje = sMensaje + "     • Centro de Costo Anterior. \n\r";
            if (this.txtNivel1.Text == "")
                sMensaje = sMensaje + "     • Nivel 1. \n\r";
            if (this.txtDescripcion.Text == "")
                sMensaje = sMensaje + "     • Descripción del Centro de Costo. \n\r";
            if (Convert.ToBoolean(this.chkAcumulador.EditValue) == false)
                if (this.slkupCentroAcumulador.EditValue == null)
                    sMensaje = sMensaje + "     • Centro Acumulador. \n\r";
            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ValidarDatos
            if (!ValidarDatos())
                return;

            if (currentRow != null)
            {
                lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                Application.DoEvents();
                currentRow.BeginEdit();

                currentRow["Nivel1"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
                currentRow["Nivel2"] = (this.txtNivel2.Text == "") ? "0" : this.txtNivel2.Text;
                currentRow["Nivel3"] = (this.txtNivel3.Text == "") ? "0" : this.txtNivel3.Text;
                currentRow["Centro"] = this.txtCentro.Text;
                currentRow["Descr"] = this.txtDescripcion.Text;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["Acumulador"] = this.chkAcumulador.EditValue;
                currentRow["IDCentroAnterior"] = this.slkupCentroAnterior.EditValue;
                currentRow["IDCentroAcumulador"] = this.slkupCentroAcumulador.EditValue;
                currentRow["ReadOnlySys"] = this.chkReadSystemOnly.EditValue;

                currentRow.EndEdit();

                DataSet _dsChanged = _dsCentro.GetChanges(DataRowState.Modified);

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

                    lblStatus.Caption = msg;
                }

                //Si no hay errores

                if (okFlag)
                {
                    CentroCostoDAC.oAdaptador.Update(_dsChanged, "Data");
                    lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                    Application.DoEvents();
                    isEdition = false;
                    _dsCentro.AcceptChanges();
                    PopulateGrid();
                    HabilitarControles(false);
                }
                else
                {
                    _dsCentro.RejectChanges();

                }
            }
            else
            {
                //nuevo registro
                currentRow = _dtCentro.NewRow();

                currentRow["Nivel1"] = (this.txtNivel1.Text == "") ? "0" : this.txtNivel1.Text;
                currentRow["Nivel2"] = (this.txtNivel2.Text == "") ? "0" : this.txtNivel2.Text;
                currentRow["Nivel3"] = (this.txtNivel3.Text == "") ? "0" : this.txtNivel3.Text;
                currentRow["Centro"] = this.txtCentro.Text;
                currentRow["Descr"] = this.txtDescripcion.Text;
                currentRow["Activo"] = this.chkActivo.EditValue;
                currentRow["Acumulador"] = this.chkAcumulador.EditValue;
                currentRow["IDCentroAnterior"] = this.slkupCentroAnterior.EditValue;
                currentRow["IDCentroAcumulador"] = (this.slkupCentroAcumulador.EditValue == null) ? 0 : this.slkupCentroAcumulador.EditValue;
                currentRow["ReadOnlySys"] = this.chkReadSystemOnly.EditValue;
                _dtCentro.Rows.Add(currentRow);
                try
                {
                    CentroCostoDAC.oAdaptador.Update(_dsCentro, "Data");
                    _dsCentro.AcceptChanges();
                    isEdition = false;
                    lblStatus.Caption = "Se ha ingresado un nuevo registro";
                    Application.DoEvents();
                    PopulateGrid();
                    ClearControls();
                    HabilitarControles(false);
                    ColumnView view = this.gridView;
                    view.MoveLast();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    _dsCentro.RejectChanges();
                    currentRow = null;
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = false;
            HabilitarControles(false);
            SetCurrentRow();
            lblStatus.Caption = "";
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currentRow != null)
            {
                string msg = currentRow["Descr"] + " eliminado..";
                if (Convert.ToBoolean(currentRow["ReadOnlySys"]) == true)
                {
                    lblStatus.Caption = "No se puede eliminar un elemento de Sistema";
                    return;
                }

                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + currentRow["Descr"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    currentRow.Delete();

                    try
                    {

                        CentroCostoDAC.oAdaptador.Update(_dsCentro, "Data");
                        _dsCentro.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsCentro.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void chkAcumulador_CheckStateChanged(object sender, EventArgs e)
        {
            if ((bool)this.chkAcumulador.EditValue == true)
                this.slkupCentroAcumulador.Enabled = false;
            else
                this.slkupCentroAcumulador.Enabled = true;
        }

        private void slkupCentroAnterior_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (!isEdition)
                    return;

                if (this.slkupCentroAnterior.EditValue != null && this.slkupCentroAnterior.EditValue.ToString() != "")
                {
                    DataView dv = new DataView();
                    dv.Table = _dtCentro;
                    dv.RowFilter = "IDCentro='" + this.slkupCentroAnterior.EditValue.ToString() + "'";
                    this.txtNivel1.Text = dv[0].Row["Nivel1"].ToString();

                    DataTable dt = dv.ToTable();
                    int i = -1;
                    if (dt.Rows[0]["Nivel3"].ToString() != "0")
                    {
                        i = Convert.ToInt32(dt.Rows[0]["Nivel3"]);
                        i++;
                        this.txtNivel3.Text = i.ToString();
                        this.txtNivel2.Text = dt.Rows[0]["Nivel2"].ToString();


                    }
                    else if (dt.Rows[0]["Nivel2"].ToString() != "0")
                    {
                        i = Convert.ToInt32(dt.Rows[0]["Nivel2"]);
                        i++;
                        this.txtNivel2.Text = i.ToString();
                        this.txtNivel3.Text = "0";
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}