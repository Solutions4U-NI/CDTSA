﻿using DevExpress.XtraGrid.Views.Base;
using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CI
{
    public partial class frmUnidadMedida : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtUnidad;
        private DataSet _dsUnidad;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Unidad de Medidas de Productos";
        private bool isEdition = false;

        

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(300,_sUsuario );
            _dtSecurity = DS.Tables[0];

            AplicarPrivilegios();
        }

        public frmUnidadMedida()
        {
            InitializeComponent();
            this.SetStyle(
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.UserPaint |
          ControlStyles.DoubleBuffer,
          true);
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;
           // this.chkActivo.Enabled = false;
        }

        private void AplicarPrivilegios()
        {
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.AgregarPresentacionesdeProducto, _dtSecurity))
                this.btnAgregar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.EditarPresentacionesdeProducto, _dtSecurity))
                this.btnEditar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.EliminarPresentacionesdeProducto, _dtSecurity))
                this.btnEliminar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.ExportarPresentecionesdeProducto, _dtSecurity))
				this.btnExportar.Enabled = false;
        }

        private void EnlazarEventos()
        {
            this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            this.btnExportar.ItemClick += BtnExportar_ItemClick;
            this.btnRefrescar.ItemClick += btnRefrescar_ItemClick;
            this.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstUnidadesMedida.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Unidades de Medida"
            };


            this.gridView1.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmUnidadMedidad_Load(object sender, EventArgs e)
        {
            try
            {
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridView1, false, this.dtgUnidadMedida, _tituloVentana, this);

                EnlazarEventos();

                PopulateGrid();

                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        
        private void PopulateGrid()
        {
            _dsUnidad = CI.DAC.clsUnidadMedidaDAC.GetData(-1, "*");

            _dtUnidad = _dsUnidad.Tables[0];
            this.dtgUnidadMedida.DataSource = null;
            this.dtgUnidadMedida.DataSource = _dtUnidad;

        }


        private void ClearControls()
        {
            
            this.txtDescripcion.Text = "";
            this.chkActivo.EditValue = true;
            this.txtIDUnidadMedida.Text = "--";

        }

        private void HabilitarControles(bool Activo)
        {
          
            this.txtDescripcion.ReadOnly = !Activo;
            this.chkActivo.Enabled = Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.btnExportar.Enabled = !Activo;
            this.btnRefrescar.Enabled = !Activo;

            this.dtgUnidadMedida.Enabled = !Activo;

        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridView1.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridView1.GetDataRow(index);
                UpdateControlsFromCurrentRow(currentRow);
            }
        }

        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
            this.txtIDUnidadMedida.Text = Row["IDUnidad"].ToString();
            this.txtDescripcion.Text = Row["Descr"].ToString();
            this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);

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

            this.txtDescripcion.Focus();
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
            
            isEdition = true;
            HabilitarControles(true);
            this.txtIDUnidadMedida.ReadOnly = true;

            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtDescripcion.Focus();
        }


        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            if (this.txtDescripcion.Text == "")
                sMensaje = sMensaje + "     • Descripción de la Unidad de Medida. \n\r";
            if (sMensaje != "")
            {
                result = false;
                MessageBox.Show("Por favor revise los siguientes campos, puede que sean obligatorios: \n\r\n\r" + sMensaje);
            }
            return result;
        }


        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //ValidarDatos
                if (!ValidarDatos())
                    return;

                if (currentRow != null)
                {
                    lblStatus.Caption = "Actualizando : " + currentRow["Descr"].ToString();

                    Application.DoEvents();
                    currentRow.BeginEdit();

                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["Activo"] = this.chkActivo.EditValue;
                    currentRow["IDUnidad"] = this.txtIDUnidadMedida.EditValue;

                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsUnidad.GetChanges(DataRowState.Modified);

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
                                    msg = msg + dr["Descr"].ToString();
                                }
                            }
                        }

                        lblStatus.Caption = msg;
                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        CI.DAC.clsUnidadMedidaDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsUnidad.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsUnidad.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtUnidad.NewRow();

                    currentRow["Descr"] = this.txtDescripcion.Text;
                    currentRow["Activo"] = this.chkActivo.EditValue;
                    
                    _dtUnidad.Rows.Add(currentRow);
                    try
                    {
                        CI.DAC.clsUnidadMedidaDAC.oAdaptador.Update(_dsUnidad, "Data");
                        _dsUnidad.AcceptChanges();
                        isEdition = false;
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                        ColumnView view = this.gridView1;
                        view.MoveLast();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsUnidad.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _dsUnidad.RejectChanges();
                currentRow = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEdition = false;
            HabilitarControles(false);
            AplicarPrivilegios();
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

                        CI.DAC.clsUnidadMedidaDAC.oAdaptador.Update(_dsUnidad, "Data");
                        _dsUnidad.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsUnidad.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }





    }
}
