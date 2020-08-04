﻿using CG;
using DevExpress.XtraGrid.Views.Base;
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
using CI.DAC;

namespace CI
{
    public partial class frmInvCuentaContable : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private DataTable _dtCuentasContables;
        private DataTable _dtCentrosCosto;

        private DataTable _dtCuenta;
        private DataSet _dsCuenta;
        private DataTable _dtSecurity;

        DataRow currentRow;
        string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        const String _tituloVentana = "Listado de Cuentas Contables de Inventario";
        private bool isEdition = false;

        public frmInvCuentaContable()
        {
            InitializeComponent();
            this.SetStyle(
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.UserPaint |
          ControlStyles.DoubleBuffer,
          true);
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, _sUsuario);
            _dtSecurity = DS.Tables[0];

            AplicarPrivilegios();
        }

        private void AplicarPrivilegios()
        {
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AgregarCentroCosto, _dtSecurity))
                this.btnAgregar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarCentroCosto, _dtSecurity))
                this.btnEditar.Enabled = false;
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarCentroCosto, _dtSecurity))
                this.btnEliminar.Enabled = false;
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
            this.gridViewDetalle.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateGrid();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            String FileName = System.IO.Path.Combine(tempPath, "lstCuentasContablesInventario.xlsx");
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
            {
                SheetName = "Listado Cuentas Contables"
            };


            this.gridViewDetalle.ExportToXlsx(FileName, options);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void frmInvCuentaContable_Load(object sender, EventArgs e)
        {
            try
            {
                
                HabilitarControles(false);

                Util.Util.SetDefaultBehaviorControls(this.gridViewDetalle, false, this.dtgDetalle, _tituloVentana, this);

                EnlazarEventos();

                _dtCuentasContables = CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", "*", -1, 0, 1, 1, -1, -1).Tables[0];
                _dtCentrosCosto = CentroCostoDAC.GetData(-1, "*", "*", "*", "*","*", -1).Tables[0];

                PopulateGrid();
                PopulateData();
                CargarPrivilegios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateData()
        {

            //Cuentas contables
            Util.Util.ConfigLookupEdit(this.slkuCtaDevVentas, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkuCtaDevVentas, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkuCtaVentas, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkuCtaVentas, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaComisionCobros, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaComisionCobros, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaComisionVenta, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaComisionVenta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaCompras, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaCompras, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaCostoVenta, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaCostoVenta, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaDesBonificacion, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaDesBonificacion, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaDesc, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaDesc, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaDescPorLinea, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaDescPorLinea, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaDescVentas, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaDescVentas, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaFaltanteInventario, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaFaltanteInventario, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaInventario, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaInventario, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaSobranteInventario, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaSobranteInventario, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaVariacionCosto, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaVariacionCosto, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaVencimiento, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaVencimiento, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtaConsumo, _dtCuentasContables, "Descr", "IDCuenta");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtaConsumo, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            //Centros de Costos
            Util.Util.ConfigLookupEdit(this.slkupCtrComisionCobros, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrComisionCobros, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrComisionVenta, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrComisionVenta, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrCompras, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrCompras, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrCostoVenta, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrCostoVenta, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrDesc, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrDesc, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrDescBonificacion, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrDescBonificacion, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrDescPorLinea, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrDescPorLinea, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrDescVentas, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrDescVentas, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrFaltanteInv, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrFaltanteInv, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrInventario, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrInventario, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrSobranteInventario, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrSobranteInventario, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrVariacionCosto, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrVariacionCosto, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrVencimiento, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrVencimiento, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtrVentas, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtrVentas, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkuCtrDevVentas, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkuCtrDevVentas, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupCtroConsumo, _dtCentrosCosto, "Descr", "IDCentro");
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCtroConsumo, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

        }

        private void PopulateGrid()
        {
            _dsCuenta = clsInvCuentaInventarioDAC.GetData(-1, "*");

            _dtCuenta = _dsCuenta.Tables[0];
            this.dtgDetalle.DataSource = null;
            this.dtgDetalle.DataSource = _dtCuenta;

            

        }

        private void ClearControls()
        {
            this.txtIdCuenta.Text = "";
            this.txtDescr.Text = "";
            this.slkuCtaDevVentas.EditValue = null;
            this.slkuCtaVentas.EditValue = null;
            this.slkuCtrDevVentas.EditValue = null;
            this.slkupCtaComisionCobros.EditValue = null;
            this.slkupCtaComisionVenta.EditValue = null;
            this.slkupCtaCompras.EditValue = null;
            this.slkupCtaCostoVenta.EditValue = null;
            this.slkupCtaDesBonificacion.EditValue = null;
            this.slkupCtaDesc.EditValue = null;
            this.slkupCtaDescPorLinea.EditValue = null;
            this.slkupCtaDescVentas.EditValue = null;
            this.slkupCtaFaltanteInventario.EditValue = null;
            this.slkupCtaInventario.EditValue = null;
            this.slkupCtaSobranteInventario.EditValue = null;
            this.slkupCtaVariacionCosto.EditValue = null;
            this.slkupCtaVencimiento.EditValue = null;
            this.slkupCtaConsumo.EditValue = null;
            this.slkupCtrComisionCobros.EditValue = null;
            this.slkupCtrComisionVenta.EditValue = null;
            this.slkupCtrCompras.EditValue = null;
            this.slkupCtrCostoVenta.EditValue = null;
            this.slkupCtrDesc.EditValue = null;
            this.slkupCtrDescBonificacion.EditValue = null;
            this.slkupCtrDescPorLinea.EditValue = null;
            this.slkupCtrDescVentas.EditValue = null;
            this.slkupCtrFaltanteInv.EditValue = null;
            this.slkupCtrInventario.EditValue = null;
            this.slkupCtrSobranteInventario.EditValue = null;
            this.slkupCtrVariacionCosto.EditValue = null;
            this.slkupCtrVencimiento.EditValue = null;
            this.slkupCtrVentas.EditValue = null;
            this.slkupCtroConsumo.EditValue = null;

        }

        private void HabilitarControles(bool Activo)
        {
            this.txtDescr.ReadOnly = !Activo;
            this.slkuCtaDevVentas.ReadOnly = !Activo;
            this.slkuCtaVentas.ReadOnly = !Activo;
            this.slkuCtrDevVentas.ReadOnly = !Activo;
            this.slkupCtaComisionCobros.ReadOnly = !Activo;
            this.slkupCtaComisionVenta.ReadOnly = !Activo;
            this.slkupCtaCompras.ReadOnly = !Activo;
            this.slkupCtaCostoVenta.ReadOnly = !Activo;
            this.slkupCtaDesBonificacion.ReadOnly = !Activo;
            this.slkupCtaDesc.ReadOnly = !Activo;
            this.slkupCtaDescPorLinea.ReadOnly = !Activo;
            this.slkupCtaDescVentas.ReadOnly = !Activo;
            this.slkupCtaFaltanteInventario.ReadOnly = !Activo;
            this.slkupCtaInventario.ReadOnly = !Activo;
            this.slkupCtaSobranteInventario.ReadOnly = !Activo;
            this.slkupCtaVariacionCosto.ReadOnly = !Activo;
            this.slkupCtaVencimiento.ReadOnly = !Activo;
            this.slkupCtaConsumo.ReadOnly = !Activo;
            this.slkupCtrComisionCobros.ReadOnly = !Activo;
            this.slkupCtrComisionVenta.ReadOnly = !Activo;
            this.slkupCtrCompras.ReadOnly = !Activo;
            this.slkupCtrCostoVenta.ReadOnly = !Activo;
            this.slkupCtrDesc.ReadOnly = !Activo;
            this.slkupCtrDescBonificacion.ReadOnly = !Activo;
            this.slkupCtrDescPorLinea.ReadOnly = !Activo;
            this.slkupCtrDescVentas.ReadOnly = !Activo;
            this.slkupCtrFaltanteInv.ReadOnly = !Activo;
            this.slkupCtrInventario.ReadOnly = !Activo;
            this.slkupCtrSobranteInventario.ReadOnly = !Activo;
            this.slkupCtrVariacionCosto.ReadOnly = !Activo;
            this.slkupCtrVencimiento.ReadOnly = !Activo;
            this.slkupCtrVentas.ReadOnly = !Activo;
            this.slkupCtroConsumo.ReadOnly = !Activo;

            this.dtgDetalle.Enabled = !Activo;

            this.btnAgregar.Enabled = !Activo;
            this.btnEditar.Enabled = !Activo;
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = Activo;
            this.btnEliminar.Enabled = !Activo;
            this.btnExportar.Enabled = !Activo;
            this.btnRefrescar.Enabled = !Activo;

        }

        private void SetCurrentRow()
        {
            int index = (int)this.gridViewDetalle.FocusedRowHandle;
            if (index > -1)
            {
                currentRow = gridViewDetalle.GetDataRow(index);
                UpdateControlsFromCurrentRow(currentRow);
            }
        }
                
	           
        private void UpdateControlsFromCurrentRow(DataRow Row)
        {
            this.txtIdCuenta.Text = Row["IDCuenta"].ToString();
            this.txtDescr.Text = Row["Descr"].ToString();
            this.slkuCtaDevVentas.EditValue = Row["CtaDevVentas"].ToString();
            this.slkuCtaVentas.EditValue = Row["CtaVenta"].ToString();
            this.slkuCtrDevVentas.EditValue = Row["CtrDevVentas"].ToString();
            this.slkupCtaComisionCobros.EditValue = Row["CtaComisionCobro"].ToString();
            this.slkupCtaComisionVenta.EditValue = Row["CtaComisionVenta"].ToString();
            this.slkupCtaCompras.EditValue = Row["CtaCompra"].ToString();
            this.slkupCtaCostoVenta.EditValue = Row["CtaCostoVenta"].ToString();
            this.slkupCtaDesBonificacion.EditValue = Row["CtaDescBonificacion"].ToString();
            this.slkupCtaDesc.EditValue = Row["CtaCostoDesc"].ToString();
            this.slkupCtaDescPorLinea.EditValue = Row["CtaDescLinea"].ToString();
            this.slkupCtaDescVentas.EditValue = Row["CtaDescVenta"].ToString();
            this.slkupCtaFaltanteInventario.EditValue = Row["CtaFaltanteInvFisico"].ToString();
            this.slkupCtaInventario.EditValue = Row["CtaInventario"].ToString();
            this.slkupCtaSobranteInventario.EditValue = Row["CtaSobranteInvFisico"].ToString();
            this.slkupCtaVariacionCosto.EditValue = Row["CtaVariacionCosto"].ToString();
            this.slkupCtaVencimiento.EditValue = Row["CtaVencimiento"].ToString();
            this.slkupCtaConsumo.EditValue = Row["CtaConsumo"].ToString();

            this.slkupCtrComisionCobros.EditValue = Row["CtrComisionCobro"].ToString();
            this.slkupCtrComisionVenta.EditValue = Row["CtrComisionVenta"].ToString();
            this.slkupCtrCompras.EditValue = Row["CtrCompra"].ToString();
            this.slkupCtrCostoVenta.EditValue = Row["CtrCostoVenta"].ToString();
            this.slkupCtrDesc.EditValue = Row["CtrCostoDesc"].ToString();
            this.slkupCtrDescBonificacion.EditValue = Row["CtrDescBonificacion"].ToString();
            this.slkupCtrDescPorLinea.EditValue = Row["CtrDescLinea"].ToString();
            this.slkupCtrDescVentas.EditValue = Row["CtrDescVenta"].ToString();
            this.slkupCtrFaltanteInv.EditValue = Row["CtrFaltanteInvFisico"].ToString();
            this.slkupCtrInventario.EditValue = Row["CtrInventario"].ToString();
            this.slkupCtrSobranteInventario.EditValue = Row["CtrSobranteInvFisico"].ToString();
            this.slkupCtrVariacionCosto.EditValue = Row["CtrVariacionCosto"].ToString();
            this.slkupCtrVencimiento.EditValue = Row["CtrVencimiento"].ToString();
            this.slkupCtrVentas.EditValue =   Row["CtrVenta"].ToString();
            this.slkupCtroConsumo.EditValue = Row["CtrConsumo"].ToString();

            
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

            //Agregar  los consecutivos

            int iProximoConsecutivo = CentroCostoDAC.GetNextConsecutivo(-1, 0, 0,0);
            //iProximoConsecutivo++;

          
            this.txtDescr.Focus();
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SetCurrentRow();
            if (currentRow == null)
            {
                lblStatus.Caption = "Por favor seleccione un elemento de la Lista";
                return;
            }
            else
                lblStatus.Caption = "";
            isEdition = true;
            HabilitarControles(true);
            
            lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
            this.txtDescr.Focus();
        }

        private bool ValidarDatos()
        {
            bool result = true;
            String sMensaje = "";
            
            
            if (this.txtDescr.Text == "")
                sMensaje = sMensaje + "     • Descripción de la cuenta. \n\r";
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


                    currentRow["Descr"] = (this.txtDescr.Text == "") ? "0" : this.txtDescr.Text;
                    currentRow["CtaDevVentas"] = (this.slkuCtaDevVentas.EditValue.ToString()=="") ?  DBNull.Value :this.slkuCtaDevVentas.EditValue;
                    currentRow["CtaVenta"] = (this.slkuCtaVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkuCtaVentas.EditValue;
                    currentRow["CtrDevVentas"] = (this.slkuCtrDevVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkuCtrDevVentas.EditValue;
                    currentRow["CtaDescVenta"] = (this.slkupCtaDescVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaDescVentas.EditValue;
                    currentRow["CtaComisionCobro"] = (this.slkupCtaComisionCobros.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaComisionCobros.EditValue;
                    currentRow["CtaComisionVenta"] = (this.slkupCtaComisionVenta.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaComisionVenta.EditValue;
                    currentRow["CtaCompra"] = (this.slkupCtaCompras.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaCompras.EditValue;
                    currentRow["CtaCostoVenta"] = this.slkupCtaCostoVenta.EditValue.ToString() =="" ? DBNull.Value: this.slkupCtaCostoVenta.EditValue;
                    currentRow["CtaDescBonificacion"] = this.slkupCtaDesBonificacion.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaDesBonificacion.EditValue;
                    currentRow["CtaCostoDesc"] = this.slkupCtaDesc.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaDesc.EditValue;
                    currentRow["CtaDescLinea"] = this.slkupCtaDescPorLinea.EditValue.ToString() =="" ? DBNull.Value:this.slkupCtaDescPorLinea.EditValue;
                    currentRow["CtaFaltanteInvFisico"] = this.slkupCtaFaltanteInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaFaltanteInventario.EditValue;
                    currentRow["CtrCostoDesc"] = this.slkupCtrDesc.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDesc.EditValue;
                    currentRow["CtaInventario"] = this.slkupCtaInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaInventario.EditValue;
                    currentRow["CtaSobranteInvFisico"] = this.slkupCtaSobranteInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaSobranteInventario.EditValue;
                    currentRow["CtaVariacionCosto"] = this.slkupCtaVariacionCosto.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaVariacionCosto.EditValue;
                    currentRow["CtaVencimiento"] = this.slkupCtaVencimiento.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaVencimiento.EditValue;
                    currentRow["CtaConsumo"] = this.slkupCtaConsumo.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaConsumo.EditValue;

                    currentRow["CtrComisionCobro"] = this.slkupCtrComisionCobros.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrComisionCobros.EditValue;
                    currentRow["CtrComisionVenta"] = this.slkupCtrComisionVenta.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrComisionVenta.EditValue;
                    currentRow["CtrCompra"] = this.slkupCtrCompras.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrCompras.EditValue;
                    currentRow["CtrCostoVenta"] = this.slkupCtrCostoVenta.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrCostoVenta.EditValue;
                    currentRow["CtrCostoDesc"] = this.slkupCtrDesc.EditValue.ToString() ==""? DBNull.Value:this.slkupCtrDesc.EditValue;
                    currentRow["CtrDescBonificacion"] = this.slkupCtrDescBonificacion.EditValue.ToString()=="" ? DBNull.Value : this.slkupCtrDescBonificacion.EditValue;
                    currentRow["CtrDescLinea"] = this.slkupCtrDescPorLinea.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDescPorLinea.EditValue;
                    currentRow["CtrDescVenta"] = this.slkupCtrDescVentas.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDescVentas.EditValue;
                    currentRow["CtrFaltanteInvFisico"] = this.slkupCtrFaltanteInv.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrFaltanteInv.EditValue;
                    currentRow["CtrInventario"] = this.slkupCtrInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrInventario.EditValue;
                    currentRow["CtrSobranteInvFisico"] = this.slkupCtrSobranteInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrSobranteInventario.EditValue;
                    currentRow["CtrVariacionCosto"] = this.slkupCtrVariacionCosto.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrVariacionCosto.EditValue;
                    currentRow["CtrVencimiento"] = this.slkupCtrVencimiento.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrVencimiento.EditValue;
                    currentRow["CtrVenta"] = this.slkupCtrVentas.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrVentas.EditValue;
                    currentRow["CtrConsumo"] = this.slkupCtroConsumo.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtroConsumo.EditValue;
                    

                    currentRow.EndEdit();

                    DataSet _dsChanged = _dsCuenta.GetChanges(DataRowState.Modified);

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

                        clsInvCuentaInventarioDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + currentRow["Descr"].ToString();
                        Application.DoEvents();
                        isEdition = false;
                        _dsCuenta.AcceptChanges();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsCuenta.RejectChanges();

                    }
                }
                else
                {
                    //nuevo registro
                    currentRow = _dtCuenta.NewRow();


                    currentRow["IDCuenta"] = -1;
                    currentRow["Descr"] = (this.txtDescr.Text == "") ? "0" : this.txtDescr.Text;
                    currentRow["CtaDevVentas"] = (this.slkuCtaDevVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkuCtaDevVentas.EditValue;
                    currentRow["CtaVenta"] = (this.slkuCtaVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkuCtaVentas.EditValue;
                    currentRow["CtrDevVentas"] = (this.slkuCtrDevVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkuCtrDevVentas.EditValue;
                    currentRow["CtaDescVenta"] = (this.slkupCtaDescVentas.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaDescVentas.EditValue;
                    currentRow["CtaComisionCobro"] = (this.slkupCtaComisionCobros.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaComisionCobros.EditValue;
                    currentRow["CtaComisionVenta"] = (this.slkupCtaComisionVenta.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaComisionVenta.EditValue;
                    currentRow["CtaCompra"] = (this.slkupCtaCompras.EditValue.ToString() == "") ? DBNull.Value : this.slkupCtaCompras.EditValue;
                    currentRow["CtaCostoVenta"] = this.slkupCtaCostoVenta.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaCostoVenta.EditValue;
                    currentRow["CtaDescBonificacion"] = this.slkupCtaDesBonificacion.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaDesBonificacion.EditValue;
                    currentRow["CtaCostoDesc"] = this.slkupCtaDesc.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaDesc.EditValue;
                    currentRow["CtaDescLinea"] = this.slkupCtaDescPorLinea.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaDescPorLinea.EditValue;
                    currentRow["CtaFaltanteInvFisico"] = this.slkupCtaFaltanteInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaFaltanteInventario.EditValue;
                    currentRow["CtrCostoDesc"] = this.slkupCtrDesc.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDesc.EditValue;
                    currentRow["CtaInventario"] = this.slkupCtaInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaInventario.EditValue;
                    currentRow["CtaSobranteInvFisico"] = this.slkupCtaSobranteInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaSobranteInventario.EditValue;
                    currentRow["CtaVariacionCosto"] = this.slkupCtaVariacionCosto.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaVariacionCosto.EditValue;
                    currentRow["CtaVencimiento"] = this.slkupCtaVencimiento.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaVencimiento.EditValue;
                    currentRow["CtaConsumo"] = this.slkupCtaConsumo.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtaConsumo.EditValue;

                    currentRow["CtrComisionCobro"] = this.slkupCtrComisionCobros.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrComisionCobros.EditValue;
                    currentRow["CtrComisionVenta"] = this.slkupCtrComisionVenta.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrComisionVenta.EditValue;
                    currentRow["CtrCompra"] = this.slkupCtrCompras.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrCompras.EditValue;
                    currentRow["CtrCostoVenta"] = this.slkupCtrCostoVenta.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrCostoVenta.EditValue;
                    currentRow["CtrCostoDesc"] = this.slkupCtrDesc.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDesc.EditValue;
                    currentRow["CtrDescBonificacion"] = this.slkupCtrDescBonificacion.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDescBonificacion.EditValue;
                    currentRow["CtrDescLinea"] = this.slkupCtrDescPorLinea.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDescPorLinea.EditValue;
                    currentRow["CtrDescVenta"] = this.slkupCtrDescVentas.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrDescVentas.EditValue;
                    currentRow["CtrFaltanteInvFisico"] = this.slkupCtrFaltanteInv.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrFaltanteInv.EditValue;
                    currentRow["CtrInventario"] = this.slkupCtrInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrInventario.EditValue;
                    currentRow["CtrSobranteInvFisico"] = this.slkupCtrSobranteInventario.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrSobranteInventario.EditValue;
                    currentRow["CtrVariacionCosto"] = this.slkupCtrVariacionCosto.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrVariacionCosto.EditValue;
                    currentRow["CtrVencimiento"] = this.slkupCtrVencimiento.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrVencimiento.EditValue;
                    currentRow["CtrVenta"] = this.slkupCtrVentas.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtrVentas.EditValue;
                    currentRow["CtrConsumo"] = this.slkupCtroConsumo.EditValue.ToString() == "" ? DBNull.Value : this.slkupCtroConsumo.EditValue;
                    
                    _dtCuenta.Rows.Add(currentRow);
                    try
                    {
                        clsInvCuentaInventarioDAC.oAdaptador.Update(_dsCuenta, "Data");
                        _dtCuenta.AcceptChanges();
                        isEdition = false;
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        PopulateGrid();
                        SetCurrentRow();
                        HabilitarControles(false);
                        AplicarPrivilegios();
                        ColumnView view = this.gridViewDetalle;
                        view.MoveLast();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsCuenta.RejectChanges();
                        currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _dsCuenta.RejectChanges();
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

                        clsInvCuentaInventarioDAC.oAdaptador.Update(_dsCuenta, "Data");
                        _dsCuenta.AcceptChanges();

                        PopulateGrid();
                        lblStatus.Caption = msg;
                        Application.DoEvents();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsCuenta.RejectChanges();
                        lblStatus.Caption = "";
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        


    }
}
