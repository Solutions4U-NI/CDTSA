﻿namespace ControlBancario
{
    partial class frmTipoCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCuenta));
			this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
			this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
			this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
			this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
			this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
			this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
			this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
			this.btnRefrescar = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.chkActivo = new DevExpress.XtraEditors.CheckEdit();
			this.txtDescr = new DevExpress.XtraEditors.TextEdit();
			this.dtgTipoCuenta = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgTipoCuenta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbonControl
			// 
			this.ribbonControl.ExpandCollapseItem.Id = 0;
			this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btnAgregar,
            this.btnEditar,
            this.btnGuardar,
            this.btnCancelar,
            this.btnEliminar,
            this.lblStatus,
            this.btnExportar,
            this.btnRefrescar});
			this.ribbonControl.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl.MaxItemId = 4;
			this.ribbonControl.Name = "ribbonControl";
			this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
			this.ribbonControl.Size = new System.Drawing.Size(599, 143);
			// 
			// btnAgregar
			// 
			this.btnAgregar.Caption = "Agregar";
			this.btnAgregar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Glyph")));
			this.btnAgregar.Id = 1;
			this.btnAgregar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.LargeGlyph")));
			this.btnAgregar.Name = "btnAgregar";
			// 
			// btnEditar
			// 
			this.btnEditar.Caption = "Editar";
			this.btnEditar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.Glyph")));
			this.btnEditar.Id = 2;
			this.btnEditar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.LargeGlyph")));
			this.btnEditar.Name = "btnEditar";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Caption = "Guardar";
			this.btnGuardar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Glyph")));
			this.btnGuardar.Id = 3;
			this.btnGuardar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.LargeGlyph")));
			this.btnGuardar.Name = "btnGuardar";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Caption = "Cancelar";
			this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
			this.btnCancelar.Id = 4;
			this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
			this.btnCancelar.Name = "btnCancelar";
			// 
			// btnEliminar
			// 
			this.btnEliminar.Caption = "Eliminar";
			this.btnEliminar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Glyph")));
			this.btnEliminar.Id = 5;
			this.btnEliminar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEliminar.LargeGlyph")));
			this.btnEliminar.Name = "btnEliminar";
			// 
			// lblStatus
			// 
			this.lblStatus.Id = 1;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// btnExportar
			// 
			this.btnExportar.Caption = "Exportar";
			this.btnExportar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.Glyph")));
			this.btnExportar.Id = 2;
			this.btnExportar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportar.LargeGlyph")));
			this.btnExportar.Name = "btnExportar";
			// 
			// btnRefrescar
			// 
			this.btnRefrescar.Caption = "Refrescar";
			this.btnRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Glyph")));
			this.btnRefrescar.Id = 3;
			this.btnRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.LargeGlyph")));
			this.btnRefrescar.Name = "btnRefrescar";
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Operaciones Tipo Cuenta";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.btnAgregar);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnEditar);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnGuardar);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnCancelar);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnExportar);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnRefrescar);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.Text = "Acciones";
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.chkActivo);
			this.layoutControl1.Controls.Add(this.txtDescr);
			this.layoutControl1.Controls.Add(this.dtgTipoCuenta);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 143);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(599, 367);
			this.layoutControl1.TabIndex = 1;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// chkActivo
			// 
			this.chkActivo.Location = new System.Drawing.Point(24, 99);
			this.chkActivo.MenuManager = this.ribbonControl;
			this.chkActivo.Name = "chkActivo";
			this.chkActivo.Properties.Caption = "Activo";
			this.chkActivo.Size = new System.Drawing.Size(551, 19);
			this.chkActivo.StyleController = this.layoutControl1;
			this.chkActivo.TabIndex = 6;
			// 
			// txtDescr
			// 
			this.txtDescr.Location = new System.Drawing.Point(85, 75);
			this.txtDescr.MenuManager = this.ribbonControl;
			this.txtDescr.Name = "txtDescr";
			this.txtDescr.Size = new System.Drawing.Size(490, 20);
			this.txtDescr.StyleController = this.layoutControl1;
			this.txtDescr.TabIndex = 5;
			// 
			// dtgTipoCuenta
			// 
			this.dtgTipoCuenta.Location = new System.Drawing.Point(12, 153);
			this.dtgTipoCuenta.MainView = this.gridView1;
			this.dtgTipoCuenta.MenuManager = this.ribbonControl;
			this.dtgTipoCuenta.Name = "dtgTipoCuenta";
			this.dtgTipoCuenta.Size = new System.Drawing.Size(575, 202);
			this.dtgTipoCuenta.TabIndex = 4;
			this.dtgTipoCuenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.dtgTipoCuenta;
			this.gridView1.Name = "gridView1";
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.emptySpaceItem2});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(599, 367);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.dtgTipoCuenta;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 141);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(579, 206);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.emptySpaceItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
			this.emptySpaceItem1.AppearanceItemCaption.Options.UseFont = true;
			this.emptySpaceItem1.AppearanceItemCaption.Options.UseForeColor = true;
			this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
			this.emptySpaceItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 33);
			this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 33);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(579, 33);
			this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem1.Text = "Listado de Tipo Cuenta";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(58, 0);
			this.emptySpaceItem1.TextVisible = true;
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 33);
			this.layoutControlGroup2.Name = "layoutControlGroup2";
			this.layoutControlGroup2.Size = new System.Drawing.Size(579, 89);
			this.layoutControlGroup2.Text = "Datos  de  Tipo Cuenta";
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.txtDescr;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(555, 24);
			this.layoutControlItem2.Text = "Descripción:";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 13);
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.chkActivo;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(555, 23);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 122);
			this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 19);
			this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 19);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(579, 19);
			this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmTipoCuenta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 510);
			this.Controls.Add(this.layoutControl1);
			this.Controls.Add(this.ribbonControl);
			this.Name = "frmTipoCuenta";
			this.Ribbon = this.ribbonControl;
			this.Text = "Listado de Tipo Cuenta";
			this.Load += new System.EventHandler(this.frmListadoBanco_Load);
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgTipoCuenta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnRefrescar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl dtgTipoCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.TextEdit txtDescr;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}