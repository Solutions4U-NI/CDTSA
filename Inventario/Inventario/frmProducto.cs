﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Security;
using CI.DAC;
using CG.DAC;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;




namespace CI
{
    public partial class frmProducto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable _dtProducto;
        private DataSet _dsProducto;
        private DataTable _dtSecurity;
        
        private DataRow _currentRow;
        private String _tituloVentana = "Producto";


        private String Accion = "NEW";
        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";

        public frmProducto()
        {
            InitializeComponent();
            this.SetStyle(
           ControlStyles.AllPaintingInWmPaint |
           ControlStyles.UserPaint |
           ControlStyles.DoubleBuffer,
           true);
            InicializaNuevoElemento();
        }

        private void InicializaNuevoElemento() {
             Accion = "New";
            _dsProducto = clsProductoDAC.GetDataEmpty();
            _dtProducto = _dsProducto.Tables[0];
            _currentRow = null;
            InicializarNuevoElemento();
        }

        public frmProducto(int Codigo, String Accion) {
            this.Accion = Accion;
            InitializeComponent();
            cargarProducto(Codigo);
        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(300, sUsuario);
            _dtSecurity = DS.Tables[0];

        }


        private void AplicarPrivilegios()
        {

			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.AgregarProductos, _dtSecurity))
				this.btnAgregar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.EditarProductos, _dtSecurity))
				this.btnEditar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.EliminarProductos, _dtSecurity))
				this.btnEliminar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosInventarioType.ExportarProductos, _dtSecurity))
				this.btnExportar.Enabled = false;
           

        }


        private void InicializarNuevoElemento()
        {

            DataSet DS = new DataSet();
            //Cargar el tipo de cambio por defecto

            _currentRow = _dtProducto.NewRow();
            _currentRow["IDProducto"] = -1;
            _currentRow["Descr"] = "";
            _currentRow["Alias"] = "";
						_currentRow["Generico"] = "";
            _currentRow["Clasif1"] = -1;
            _currentRow["Clasif2"] = -1;
            _currentRow["Clasif3"] = -1;
            _currentRow["Clasif4"] = -1;
            _currentRow["Clasif5"] = -1;
            _currentRow["Clasif6"] = -1;
            _currentRow["IDProveedor"] = -1;
            _currentRow["CodigoBarra"] = "";
            _currentRow["IDCuentaContable"] = -1;
            _currentRow["IDUnidad"] = -1;
            _currentRow["FactorEmpaque"] = 1;
            _currentRow["TipoImpuesto"] = 0;
            _currentRow["EsMuestra"] = false;
            _currentRow["EsControlado"] = false;
            _currentRow["EsEtico"] = false;
			_currentRow["EsGenerico"] = false;
            _currentRow["Activo"] = true;
            _currentRow["Bonifica"] = false;
			_currentRow["NumRegSanitario"] = "";
			_currentRow["FechaVencimientoRegistro"] = DateTime.Now;
            _currentRow["UserInsert"] = sUsuario;
            _currentRow["UserUpdate"] = DateTime.Now;
            _currentRow["UpdateDate"] = DateTime.Now;
            _currentRow["CostoUltLocal"]= 0;
            _currentRow["CostoUltDolar"] = 0;
            _currentRow["CostoPromLocal"] = 0;
            _currentRow["CostoPromDolar"] = 0;
			_currentRow["PrecioCIF"] = 0;
			_currentRow["PrecioFOB"] = 0;
			_currentRow["TipoPrecio"] = "CIF";


        }

        public void cargarProducto(int Codigo) {
            _dsProducto = clsProductoDAC.GetData(Codigo, "*", "*", -1, -1, -1, -1, -1, -1, "*",-1,-1,-1);
            _dtProducto = _dsProducto.Tables[0];
            _currentRow = _dtProducto.Rows[0];

        }


        public void UpdateControlsFromDataRow(DataRow row)
        {
            //_currentRow = _dtAsiento.NewRow();
            this.txtIDProducto.EditValue = _currentRow["IDProducto"].ToString();
            this.txtDescr.EditValue = _currentRow["Descr"].ToString();
            this.txtAlias.EditValue = _currentRow["Alias"].ToString();
						this.txtGenerico.EditValue = _currentRow["Generico"].ToString();
            this.txtCodigoBarra.Text = _currentRow["CodigoBarra"].ToString(); 
            this.slkupUnidadMedida.EditValue = _currentRow["IDUnidad"];
            //this.dtpFecha.Text = Convert.ToDateTime(_currentRow["Fecha"]).ToShortDateString();
            this.slkupTipoImpuesto.EditValue = _currentRow["TipoImpuesto"].ToString();
            this.chkActivo.EditValue = _currentRow["Activo"];
            this.chkBonifica.EditValue = _currentRow["Bonifica"];
            this.chkEsMuestra.EditValue = _currentRow["EsMuestra"];
            this.chkEsControlado.EditValue = _currentRow["EsControlado"];
            this.chkEsEtico.EditValue = _currentRow["EsEtico"];
			this.chkEsGenerico.EditValue = _currentRow["EsGenerico"];
            
            //TODO Actualizar los Costos
            this.txtCostoPromDolar.EditValue = ((Decimal)_currentRow["CostoPromDolar"]).ToString("N" + Util.Util.DecimalLenght);
            this.txtCostoPromLocal.EditValue = ((Decimal)_currentRow["CostoPromLocal"]).ToString("N" + Util.Util.DecimalLenght);
            this.txtUltimoCostoDolar.EditValue = ((Decimal)_currentRow["CostoUltDolar"]).ToString("N" + Util.Util.DecimalLenght);
            this.txtUltimoCostoLocal.EditValue = ((Decimal)_currentRow["CostoUltLocal"]).ToString("N" + Util.Util.DecimalLenght);
			this.txtPrecioCIF.EditValue = ((Decimal)_currentRow["PrecioCIF"]).ToString("N" + Util.Util.DecimalLenght);
			this.txtPrecioFOB.EditValue = ((Decimal)_currentRow["PrecioFOB"]).ToString("N" + Util.Util.DecimalLenght);
			this.cmbPrecioActivo.EditValue = _currentRow["TipoPrecio"].ToString();

            this.slkupClasif1.EditValue = _currentRow["Clasif1"];
            this.slkupClasif2.EditValue = _currentRow["Clasif2"];
            this.slkupClasif3.EditValue = _currentRow["Clasif3"];
            this.slkupClasif4.EditValue = _currentRow["Clasif4"];
            this.slkupClasif5.EditValue = _currentRow["Clasif5"];
            this.slkupClasif6.EditValue = _currentRow["Clasif6"];
            this.slkupProveedor.EditValue = _currentRow["IDProveedor"];
            this.slkupCuentaArticulo.EditValue = _currentRow["IDCuentaContable"];
            


            //Pagina de auditoria
            this.txtUsuarioCreacion.Text = _currentRow["UserInsert"].ToString();
            this.txtFechaCreacion.Text = _currentRow["CreateDate"].ToString();
            this.txtUsuarioModificacion.Text = _currentRow["UserUpdate"].ToString();
            this.txtFechaModificacion.Text = _currentRow["UpdateDate"].ToString();
            

			//Datos de RegistroSanitario
			this.txtNumRegistroSanitario.EditValue = _currentRow["NumRegSanitario"].ToString();
			this.dtpFechaCaducidadRegistro.EditValue =_currentRow["FechaVencimientoRegistro"];
            
        }



        private void HabilitarControles(bool Activo)
        {

            this.txtIDProducto.ReadOnly = !Activo;
            this.txtDescr.ReadOnly = !Activo;
            this.txtAlias.ReadOnly = !Activo;
						this.txtGenerico.ReadOnly = !Activo;
            this.txtCodigoBarra.ReadOnly = !Activo;
            this.slkupUnidadMedida.ReadOnly = !Activo;
            //this.dtpFecha.Text = Convert.ToDateTime(_currentRow["Fecha"]).ToShortDateString();
            this.slkupTipoImpuesto.ReadOnly = !Activo;
            this.chkActivo.ReadOnly = !Activo;
            //this.chkBonifica.ReadOnly = !Activo;
            this.chkEsControlado.ReadOnly = !Activo;
            this.chkEsEtico.ReadOnly = !Activo;
            this.chkEsMuestra.ReadOnly = !Activo;
			this.chkEsGenerico.ReadOnly = !Activo;

			this.txtPrecioCIF.ReadOnly = !Activo;
			this.txtPrecioFOB.ReadOnly = !Activo;
			this.cmbPrecioActivo.ReadOnly = !Activo;
            
            this.slkupClasif1.ReadOnly = !Activo;
            this.slkupClasif2.ReadOnly = !Activo;
            this.slkupClasif3.ReadOnly = !Activo;
            this.slkupClasif4.ReadOnly = !Activo;
            this.slkupClasif5.ReadOnly = !Activo;
            this.slkupClasif6.ReadOnly = !Activo;
            this.slkupProveedor.ReadOnly = !Activo;
            this.slkupCuentaArticulo.ReadOnly = !Activo;

			this.txtNumRegistroSanitario.ReadOnly = !Activo;
			this.dtpFechaCaducidadRegistro.ReadOnly = !Activo;


            //Pagina de auditoria

            if (Accion == "New")
            {
                this.btnEditar.Enabled = false;
                this.btnAgregar.Enabled = false;
                
            }
            else if (Accion == "View")
            {
                this.btnEditar.Enabled = true;
                this.btnAgregar.Enabled = true;

            }
            else if (Accion == "Edit") {
                this.btnAgregar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
                
            this.btnGuardar.Enabled = Activo;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = !Activo;
        }


        private void EnlazarEventos()
        {
            //    this.btnAgregar.ItemClick += btnAgregar_ItemClick;
            this.btnEditar.ItemClick += btnEditar_ItemClick;
            this.btnEliminar.ItemClick += btnEliminar_ItemClick;
            this.btnGuardar.ItemClick += btnGuardar_ItemClick;
            this.btnCancelar.ItemClick += btnCancelar_ItemClick;
            //this.btnImprimir.ItemClick += BtnImprimir_ItemClick;
            //this.btnCuadreTemporal.ItemClick += BtnCuadreTemporal_ItemClick;
        }

        void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentRow != null)
            {

                if (MessageBox.Show("Esta seguro que desea eliminar el elemento: " + _currentRow["IdProducto"].ToString(), _tituloVentana, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataSet _dsProductotmp = new DataSet();
                    DataTable _dtProductotmp = new DataTable();


                    //Validar las dependendicas
                    //ToDo Validar dependencias de los prodcutos
                    _currentRow.Delete();
                    try
                    {

                        clsProductoDAC.oAdaptador.Update(_dsProducto, "Data");
                        _dsProducto.AcceptChanges();


                        // PopulateGrid();
                        //lblStatus.Text = "El elemento se ha eliminado";
                        //MessageBox.Show("El asiento se ha eliminado correctamente.");
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsProducto.RejectChanges();
                        MessageBox.Show("Han ocurrido errores al momento de eliminar el producto, por favor verifique: \n\r" + ex.Message);
                    }

                    this.Close();

                }

            }
        }


        private bool ValidaDatos()
        {
            bool result = true;
            String sMensaje = "";

            if (this.txtIDProducto.EditValue == null || this.txtIDProducto.Text.Trim() =="")
                sMensaje = sMensaje + "     • Ingrese el Código del Producto. \n\r";
            if (this.txtDescr.EditValue == null)
                sMensaje = sMensaje + "     • Ingrese la descripción del Producto. \n\r";
            if (this.slkupProveedor.EditValue == null || this.slkupProveedor.EditValue.ToString() =="")
                sMensaje = sMensaje + "     • Ingrese el Proveedor del Producto. \n\r";
            if (this.slkupUnidadMedida.EditValue == null || this.slkupUnidadMedida.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Ingrese la unidad de Medida del Producto. \n\r";
            if (this.slkupTipoImpuesto.EditValue == null || this.slkupTipoImpuesto.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Ingrese el Tipo de Impuesto del Producto. \n\r";
            if (this.slkupCuentaArticulo.EditValue == null || this.slkupCuentaArticulo.EditValue.ToString() == "")
                sMensaje = sMensaje + "     • Ingrese la Cuenta contable del Producto. \n\r";
			if (this.cmbPrecioActivo.EditValue == null || this.cmbPrecioActivo.EditValue.ToString() == "")
				sMensaje = sMensaje + "		• Ingrese el tipo de Precio que se aplicara al producto. \n\r";
         

            if (sMensaje != "")
            {
                MessageBox.Show("Estimado usuario, favor revise los siguientes errores: \n\r" + sMensaje);
                result = false;
            }
            return result;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GuardarProducto();
        }


        private void GuardarProducto()
        {
         
                if (!ValidaDatos()) return;

                //Validar si la fecha del asiento contable corresponde a una fecha valida
                

                //Obtener los datos


                //if (_currentRow != null)
                if (Accion != "New")
                {
                    Application.DoEvents();
                    _currentRow.BeginEdit();

                    //_dsProducto.Tables[0].Rows.Add(_currentRow);
                    _currentRow["IDProducto"] = Convert.ToInt64(this.txtIDProducto.Text.Trim());
                    _currentRow["Descr"] = this.txtDescr.Text.Trim();
                    _currentRow["Alias"] = this.txtAlias.Text.Trim();
					_currentRow["Generico"] = this.txtGenerico.Text.Trim();
                    _currentRow["Clasif1"] = (this.slkupClasif1.EditValue == null) ? 1 : Convert.ToInt32(this.slkupClasif1.EditValue);
                    _currentRow["Clasif2"] = (this.slkupClasif2.EditValue == null) ? 2 : Convert.ToInt32(this.slkupClasif2.EditValue);
                    _currentRow["Clasif3"] = (this.slkupClasif3.EditValue == null) ? 3 : Convert.ToInt32(this.slkupClasif3.EditValue);
                    _currentRow["Clasif4"] = (this.slkupClasif4.EditValue == null) ? 4 : Convert.ToInt32(this.slkupClasif4.EditValue);
                    _currentRow["Clasif5"] = (this.slkupClasif5.EditValue == null) ? 5 : Convert.ToInt32(this.slkupClasif5.EditValue);
                    _currentRow["Clasif6"] = (this.slkupClasif6.EditValue == null) ? 6: Convert.ToInt32(this.slkupClasif6.EditValue);
                    _currentRow["IDProveedor"] = Convert.ToInt32(this.slkupProveedor.EditValue);
                    _currentRow["IDCuentaContable"] = Convert.ToInt32(this.slkupCuentaArticulo.EditValue);
                    _currentRow["CodigoBarra"] = this.txtCodigoBarra.EditValue;
                    _currentRow["IDUnidad"] = this.slkupUnidadMedida.EditValue;
                    _currentRow["FactorEmpaque"] = 1;
                    _currentRow["TipoImpuesto"] = this.slkupTipoImpuesto.EditValue;
                    _currentRow["EsMuestra"] = this.chkEsMuestra.EditValue;
                    _currentRow["EsControlado"] = this.chkEsControlado.EditValue;
                    _currentRow["EsEtico"] = this.chkEsEtico.EditValue;
					_currentRow["EsGenerico"] = this.chkEsGenerico.EditValue;
                    _currentRow["Activo"] = this.chkActivo.EditValue;
                    _currentRow["Bonifica"] = this.chkBonifica.EditValue;
					_currentRow["NumRegSanitario"] = this.txtNumRegistroSanitario.EditValue.ToString().Trim();
					_currentRow["FechaVencimientoRegistro"] =this.dtpFechaCaducidadRegistro.EditValue;
					_currentRow["PrecioCIF"] = Convert.ToDecimal(this.txtPrecioCIF.EditValue);
					_currentRow["PrecioFOB"] = Convert.ToDecimal(this.txtPrecioFOB.EditValue);
					_currentRow["TipoPrecio"] = this.cmbPrecioActivo.EditValue.ToString();
                    _currentRow["UserInsert"] = sUsuario;
                    _currentRow["UserUpdate"] = sUsuario;
                    _currentRow["UpdateDate"] = DateTime.Now;
                    _currentRow.EndEdit();

                    DataSet _dsChanged = _dsProducto.GetChanges(DataRowState.Modified);

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
                                    msg = msg + dr["IdProducto"].ToString();
                                }
                            }
                        }

                        lblStatus.Caption = msg;
                    }

                    //Si no hay errores

                    if (okFlag)
                    {
                        clsProductoDAC.oAdaptador.Update(_dsChanged, "Data");
                        lblStatus.Caption = "Actualizado " + _currentRow["Descr"].ToString();
                        Application.DoEvents();

                        _dsProducto.AcceptChanges();
                        HabilitarControles(false);
                        Accion = "View";
                        this.btnEditar.Enabled = true;
                        this.btnAgregar.Enabled = true;
                        AplicarPrivilegios();
                    }
                    else
                    {
                        _dsProducto.RejectChanges();

                    }


                }
                else {

                    _currentRow = _dtProducto.NewRow();
                    _currentRow["IDProducto"] = Convert.ToInt64(this.txtIDProducto.Text.Trim());
                    _currentRow["Descr"] = this.txtDescr.Text.Trim();
                    _currentRow["Alias"] = this.txtAlias.Text.Trim();
					_currentRow["Generico"] = this.txtGenerico.Text.Trim();
                    _currentRow["Clasif1"] = (this.slkupClasif1.EditValue == null) ? 1 : Convert.ToInt32(this.slkupClasif1.EditValue);
                    _currentRow["Clasif2"] = (this.slkupClasif2.EditValue == null) ? 2 : Convert.ToInt32(this.slkupClasif2.EditValue);
                    _currentRow["Clasif3"] = (this.slkupClasif3.EditValue == null) ? 3 : Convert.ToInt32(this.slkupClasif3.EditValue);
                    _currentRow["Clasif4"] = (this.slkupClasif4.EditValue == null) ? 4 : Convert.ToInt32(this.slkupClasif4.EditValue);
                    _currentRow["Clasif5"] = (this.slkupClasif5.EditValue == null) ? 5 : Convert.ToInt32(this.slkupClasif5.EditValue);
                    _currentRow["Clasif6"] = (this.slkupClasif6.EditValue == null) ? 6 : Convert.ToInt32(this.slkupClasif6.EditValue);
                    _currentRow["IDProveedor"] = Convert.ToInt32(this.slkupProveedor.EditValue);
                    _currentRow["IDCuentaContable"] = Convert.ToInt32(this.slkupCuentaArticulo.EditValue);
                    _currentRow["CodigoBarra"] = this.txtCodigoBarra.EditValue;
                    _currentRow["IDUnidad"] = this.slkupUnidadMedida.EditValue;
                    _currentRow["FactorEmpaque"] = 1;
                    _currentRow["TipoImpuesto"] = this.slkupTipoImpuesto.EditValue;
                    _currentRow["EsMuestra"] = this.chkEsMuestra.EditValue;
                    _currentRow["EsControlado"] = this.chkEsControlado.EditValue;
                    _currentRow["EsEtico"] = this.chkEsEtico.EditValue;
					_currentRow["EsGenerico"] = this.chkEsGenerico.EditValue;
                    _currentRow["Activo"] = this.chkActivo.EditValue; 
                    _currentRow["Bonifica"] = this.chkBonifica.EditValue;
					_currentRow["NumRegSanitario"] = this.txtNumRegistroSanitario.EditValue.ToString().Trim();
					_currentRow["FechaVencimientoRegistro"] = Convert.ToDateTime(this.dtpFechaCaducidadRegistro.EditValue);
					_currentRow["PrecioCIF"] = Convert.ToDecimal(this.txtPrecioCIF.EditValue);
					_currentRow["PrecioFOB"] = Convert.ToDecimal(this.txtPrecioFOB.EditValue);
					_currentRow["TipoPrecio"] = this.cmbPrecioActivo.EditValue.ToString();
                    _currentRow["UserInsert"] = sUsuario;
                    _currentRow["UserUpdate"] = sUsuario;
                    _currentRow["UpdateDate"] = DateTime.Now;

                    _dtProducto.Rows.Add(_currentRow);

                    try
                    {
                        clsProductoDAC.oAdaptador.Update(_dsProducto, "Data");
                        _dsProducto.AcceptChanges();

                        this.txtIDProducto.EditValue = clsProductoDAC.oAdaptador.InsertCommand.Parameters["@IDProducto"].Value.ToString();
                        lblStatus.Caption = "Se ha ingresado un nuevo registro";
                        Application.DoEvents();
                        
                        HabilitarControles(false);
                        Accion = "View";
                        this.btnEditar.Enabled = true;
                        this.btnAgregar.Enabled = true;
                        AplicarPrivilegios();
                        
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        _dsProducto.RejectChanges();
                        //_currentRow = null;
                        MessageBox.Show(ex.Message);
                    }
                
                }
              
        }


        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_currentRow == null)
            {
                return;
            }
           
                Accion = "Edit";
                HabilitarControles(true);
                AplicarPrivilegios();
                
            

        }


        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Accion == "Edit" )
            {
                HabilitarControles(false);
                AplicarPrivilegios();
                //CargarAsiento(_currentRow["Asiento"].ToString());
                UpdateControlsFromDataRow(_currentRow);
                Accion = "View";
                this.btnEditar.Enabled = true;
                this.btnAgregar.Enabled = true;
            }
            else
                this.Close();

        }


        private void ClearControls() {
            this.txtIDProducto.EditValue = "";
            this.txtDescr.EditValue = "";
            this.txtAlias.EditValue = "";
						this.txtGenerico.EditValue = "";
            this.txtCodigoBarra.EditValue = "";
            this.slkupUnidadMedida.EditValue = null;
            this.slkupTipoImpuesto.EditValue = null;
            this.chkActivo.EditValue = true;
            this.chkBonifica.EditValue = false;
            this.chkEsControlado.EditValue = false;
            this.chkEsMuestra.EditValue = false;
            this.chkEsEtico.EditValue = false;
			this.chkEsGenerico.EditValue = false;
            
            this.txtCostoPromLocal.EditValue = "";
            this.txtCostoPromDolar.EditValue = "";
            this.txtUltimoCostoDolar.EditValue = "";
            this.txtUltimoCostoLocal.EditValue = "";
			this.txtPrecioCIF.EditValue = "";
			this.txtPrecioFOB.EditValue = "";
			this.cmbPrecioActivo.SelectedIndex = -1;

            this.slkupClasif1.EditValue = null;
            this.slkupClasif2.EditValue = null;
            this.slkupClasif3.EditValue = null;
            this.slkupClasif4.EditValue = null;
            this.slkupClasif5.EditValue = null;
            this.slkupClasif6.EditValue = null;
            this.slkupProveedor.EditValue = null;
            this.slkupCuentaArticulo.EditValue = null;

            this.txtUsuarioCreacion.EditValue = "";
            this.txtFechaCreacion.EditValue = "";
            this.txtUsuarioModificacion.EditValue = "";
            this.txtFechaModificacion.EditValue = "";

			this.txtNumRegistroSanitario.EditValue = "";
			this.dtpFechaCaducidadRegistro.EditValue = null;

        }

        private void CargarDescripcionesClasificaciones() {
            DataTable DT = clsGrupoClasificacionDAC.GetAllData().Tables[0];

            this.lyClasif1.Text = DT.Rows[0]["Descr"].ToString() + ":";
            this.lyClasif1.Visibility = ( Convert.ToBoolean(DT.Rows[0]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.lyClasif2.Text = DT.Rows[1]["Descr"].ToString() + ":";
			this.lyClasif2.Visibility = ( Convert.ToBoolean(DT.Rows[1]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.lyClasif3.Text = DT.Rows[2]["Descr"].ToString() + ":";
			this.lyClasif3.Visibility = ( Convert.ToBoolean(DT.Rows[2]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.lyClasif4.Text = DT.Rows[3]["Descr"].ToString() + ":";
			this.lyClasif4.Visibility = ( Convert.ToBoolean(DT.Rows[3]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.lyClasif5.Text = DT.Rows[4]["Descr"].ToString() + ":";
			this.lyClasif5.Visibility = ( Convert.ToBoolean(DT.Rows[4]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.lyClasif6.Text = DT.Rows[5]["Descr"].ToString() + ":";
			this.lyClasif6.Visibility = (Convert.ToBoolean(DT.Rows[5]["Activo"])) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                
                HabilitarControles(false);
                
                CargarPrivilegios();
                EnlazarEventos();

                CargarDescripcionesClasificaciones();

                Util.Util.SetDefaultBehaviorControls(this.gridView1, true, null, _tituloVentana, this);

                //Configurar searchLookUp

                Util.Util.ConfigLookupEdit(this.slkupClasif1, clsClasificacionDAC.GetData(-1,1,"*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif1, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif2, clsClasificacionDAC.GetData(-1, 2, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif2, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif3, clsClasificacionDAC.GetData(-1, 3, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif3, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif4, clsClasificacionDAC.GetData(-1, 4, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif4, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif5, clsClasificacionDAC.GetData(-1, 5, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif5, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                Util.Util.ConfigLookupEdit(this.slkupClasif6, clsClasificacionDAC.GetData(-1, 6, "*").Tables[0], "Descr", "IDClasificacion");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupClasif6, "[{'ColumnCaption':'Clasificacion','ColumnField':'IDClasificacion','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupProveedor,CI.DAC.clsProductoDAC.GetlstProvedores(-1, "*",-1).Tables[0], "Nombre", "IDProveedor",400,300);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupProveedor, "[{'ColumnCaption':'ID Proveedor','ColumnField':'IDProveedor','width':30},{'ColumnCaption':'Nombre','ColumnField':'Nombre','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupCuentaArticulo, CI.DAC.clsInvCuentaInventarioDAC.GetData(-1,"*").Tables[0] , "Descr", "IDCuenta",400,300);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaArticulo, "[{'ColumnCaption':'IDCuenta','ColumnField':'IDCuenta','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");
                
                
                Util.Util.ConfigLookupEdit(this.slkupUnidadMedida, clsUnidadMedidaDAC.GetData(-1,"*").Tables[0], "Descr", "IDUnidad");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupUnidadMedida, "[{'ColumnCaption':'ID Unidad','ColumnField':'IDUnidad','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                Util.Util.ConfigLookupEdit(this.slkupTipoImpuesto, globalTipoImpuestoDAC.GetData(-1, "*").Tables[0], "Descr", "IDImpuesto");
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoImpuesto, "[{'ColumnCaption':'ID Impuesto','ColumnField':'IDImpuesto','width':30},{'ColumnCaption':'Descripcion','ColumnField':'Descr','width':70}]");

                //Setting default decimals
                Util.Util.SetFormatTextEdit(txtUltimoCostoDolar, Util.Util.FormatType.Numerico);
                Util.Util.SetFormatTextEdit(txtUltimoCostoLocal, Util.Util.FormatType.Numerico);
                Util.Util.SetFormatTextEdit(txtCostoPromDolar, Util.Util.FormatType.Numerico);
                Util.Util.SetFormatTextEdit(txtCostoPromLocal, Util.Util.FormatType.Numerico);
				Util.Util.SetFormatTextEdit(txtPrecioCIF, Util.Util.FormatType.Numerico);
				Util.Util.SetFormatTextEdit(txtPrecioFOB, Util.Util.FormatType.Numerico);

                
                
                UpdateControlsFromDataRow(_currentRow);
                if (Accion == "New")
                {
                    HabilitarControles(true);
                    ClearControls();
                    this.tabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    this.ValidateChildren();
                    this.txtDescr.Focus();
                } else if (Accion == "Edit"){
                     HabilitarControles(true);
                    AplicarPrivilegios();
                    this.txtDescr.Focus();
                }
                else 
                {
                    Accion = "View";
                    HabilitarControles(false);
                    
                } 

                //if (_Estado == "PndtGuardar")
                //{
                //    btnEditar_ItemClick(this, null);
                //    this.btnCancelar.Enabled = false;
                //}
                AplicarPrivilegios();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_ItemClick(object sender, ItemClickEventArgs e)
        {
            InicializaNuevoElemento();
            HabilitarControles(true);
            ClearControls();
            this.tabAuditoria.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ValidateChildren();
            this.txtDescr.Focus();
        }

        private void textEdit_Enter(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
            BeginInvoke(new Action(() => edit.SelectAll()));
        }

        private void btnExportar_ItemClick(object sender, ItemClickEventArgs e)
        {
                DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile("./Reportes/rptFichaProducto.repx", true);


                SqlDataSource sqlDataSource = report.DataSource as SqlDataSource;

                SqlDataSource ds = report.DataSource as SqlDataSource;
                ds.ConnectionName = "sqlDataSource1";
                String sNameConexion = (Security.Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString);
                ds.ConnectionParameters = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters(builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, MsSqlAuthorizationType.SqlServer);

                // Obtain a parameter, and set its value.
                report.Parameters["IDProducto"].Value = Convert.ToInt32(this.txtIDProducto.Text);
                report.Parameters["Descr"].Value = "*";

                // Show the report's print preview.
                DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                tool.ShowPreview();
            }

        private void txtIDProducto_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtIDProducto.Text != "")
            {
                //Validar si el codigo ingresado existe en la base de datos.
                DataSet dsProd = DAC.clsProductoDAC.GetProductoByID(Convert.ToInt32(this.txtIDProducto.Text.Trim()), "*");
                if (dsProd.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("El código de producto ya existe en la base de datos");
                    this.txtIDProducto.ErrorText = "El produducto ya existe en la base de datos";
                    e.Cancel = true;
                }
                else
                {
                    this.txtIDProducto.ErrorText = "";
                }
            }
        }

        private void btnAddProveedor_Click(object sender, EventArgs e)
        {
            
        }

        private void slkupProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Accion == "Edit" || this.Accion=="New") {
                DataRowView dr = this.slkupProveedor.GetSelectedDataRow() as DataRowView;

            }
        }

       
        }
        
 
}