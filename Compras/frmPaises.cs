﻿using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CO
{
	public partial class frmPaises : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private DataTable _dtPais;
		private DataTable _dtSecurity;
		DataRow currentRow;

		string _sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
		const String _tituloVentana = "Listado de Condiciones de Paises";
		private String _sAccion = "View";
		private int IDPais = -1;
		String Descr, Operacion;
		bool Activo;

		public frmPaises()
		{
			InitializeComponent();
			this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
			this.StartPosition = FormStartPosition.CenterScreen;
		}

			private void CargarPrivilegios()
		{
			DataSet DS = new DataSet();
			DS = UsuarioDAC.GetAccionModuloFromRole(400, _sUsuario);
			_dtSecurity = DS.Tables[0];

			AplicarPrivilegios();
		}

		private void AplicarPrivilegios()
		{
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosComprasType.AgregarPaises, _dtSecurity))
				this.btnAgregar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosComprasType.EditarPaises, _dtSecurity))
				this.btnEditar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosComprasType.EliminarPaises, _dtSecurity))
				this.btnEliminar.Enabled = false;
			if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosComprasType.ExportarPaises, _dtSecurity))
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
			this.gridView.FocusedRowChanged += gridView1_FocusedRowChanged;
		}

		void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			PopulateGrid();
		}

		private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			string tempPath = System.IO.Path.GetTempPath();
			String FileName = System.IO.Path.Combine(tempPath, "lstPaises.xlsx");
			DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions()
			{
				SheetName = "Listado de Paises"
			};


			this.gridView.ExportToXlsx(FileName, options);
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.StartInfo.FileName = FileName;
			process.StartInfo.Verb = "Open";
			process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
			process.Start();
		}


		
		private void PopulateGrid()
		{
			_dtPais = DAC.clsGlobalPaisDAC.Get(-1).Tables[0];
			this.dtgPais.DataSource = null;
			this.dtgPais.DataSource = _dtPais;
		}

		private void ClearControls()
		{
			this.txtPais.Text = "";
			this.chkActivo.Checked  = true;
		}

		private void HabilitarControles(bool Activo)
		{
			this.chkActivo.ReadOnly = !Activo;
			this.txtPais.ReadOnly = !Activo;
			this.dtgPais.Enabled = !Activo;

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
			int index = (int)this.gridView.FocusedRowHandle;
			if (index > -1)
			{
				currentRow = gridView.GetDataRow(index);
				UpdateControlsFromCurrentRow(currentRow);
			}
		}

		private void UpdateControlsFromCurrentRow(DataRow Row)
		{
			this.IDPais = Convert.ToInt32(Row["IDPais"]);
			this.txtPais.Text = Row["Descr"].ToString();
			this.chkActivo.EditValue = Convert.ToBoolean(Row["Activo"]);
			
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			SetCurrentRow();
		}

		private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_sAccion = "New";
			HabilitarControles(true);
			ClearControls();
			currentRow = null;

			this.txtPais.Focus();
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
			
			_sAccion = "Edit";
			HabilitarControles(true);
			SetCurrentRow();
			
			lblStatus.Caption = "Editando el registro : " + currentRow["Descr"].ToString();
			this.txtPais.Focus();
		}


		private bool ValidarDatos()
		{
			bool result = true;
			String sMensaje = "";
			//Este solo vale para el primer elemento
			if (this.txtPais.Text == "")
				sMensaje = sMensaje + "     • Descripción de la Condición de Pago \n\r";
			if (sMensaje != "")
			{
				result = false;
				MessageBox.Show("Por favor revise los siguientes campos: \n\r\n\r" + sMensaje);
			}
			return result;
		}


		private void ObtenerDatos()
		{
			Descr = this.txtPais.Text.Trim();
			Activo = Convert.ToBoolean(this.chkActivo.Checked);
		}


		private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (!ValidarDatos())
					return;

				ObtenerDatos();


				if (_sAccion == "New")
					Operacion = "I";
				else
					Operacion = "U";
				ConnectionManager.BeginTran();
				DAC.clsGlobalPaisDAC.InsertUpdate(Operacion, ref IDPais, Descr, Activo, ConnectionManager.Tran);
				ConnectionManager.CommitTran();

				PopulateGrid();
				ClearControls();
				HabilitarControles(false);
				_sAccion = "View";
				this.lblStatus.Caption = "";

			}
			catch (Exception ex) {
				ConnectionManager.RollBackTran();
				MessageBox.Show("Ha ocurrido un error al momento de guardar la condicion de Pago \n\r" + ex.Message);
			}
		}

		private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_sAccion = "View";
			HabilitarControles(false);
			AplicarPrivilegios();
			SetCurrentRow();
			lblStatus.Caption = "";
		}

		private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (this.currentRow != null && this.IDPais != -1)
				{
					ObtenerDatos();
					ConnectionManager.BeginTran();
					DAC.clsGlobalPaisDAC.InsertUpdate("D", ref IDPais, Descr, Activo, ConnectionManager.Tran);
					ConnectionManager.CommitTran();
					PopulateGrid();
					ClearControls();
					HabilitarControles(false);
					_sAccion = "View";
					this.lblStatus.Caption = "";
				}
			}
			catch (Exception ex) {
				ConnectionManager.RollBackTran();
				MessageBox.Show("Ha ocurrido un error trantado de eliminar la condición de Pago \n\r" + ex.Message);
			}
		}

		private void frmPaises_Load(object sender, EventArgs e)
		{
			try
			{
				HabilitarControles(false);

				Util.Util.SetDefaultBehaviorControls(this.gridView, false, this.dtgPais, _tituloVentana, this);

				EnlazarEventos();

				PopulateGrid();

				CargarPrivilegios();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}

}
