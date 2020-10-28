﻿namespace CI
{
    partial class frmConsecutivos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsecutivos));
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
			this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
			this.chkActivo = new DevExpress.XtraEditors.CheckEdit();
			this.txtDocumento = new DevExpress.XtraEditors.TextEdit();
			this.txtConsecutivo = new DevExpress.XtraEditors.TextEdit();
			this.txtPRefijo = new DevExpress.XtraEditors.TextEdit();
			this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
			this.gridControl = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colIDConsecutivo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDescr = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrefijo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colConsecutivo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDocumento.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtConsecutivo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPRefijo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
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
			this.ribbonControl.Size = new System.Drawing.Size(724, 143);
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
			this.ribbonPage1.Text = "Operaciones Concsecutivos";
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
			this.layoutControl1.Controls.Add(this.pictureEdit1);
			this.layoutControl1.Controls.Add(this.chkActivo);
			this.layoutControl1.Controls.Add(this.txtDocumento);
			this.layoutControl1.Controls.Add(this.txtConsecutivo);
			this.layoutControl1.Controls.Add(this.txtPRefijo);
			this.layoutControl1.Controls.Add(this.txtDescripcion);
			this.layoutControl1.Controls.Add(this.gridControl);
			this.layoutControl1.Controls.Add(this.labelControl1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 143);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1121, 212, 250, 350);
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(724, 355);
			this.layoutControl1.TabIndex = 1;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// pictureEdit1
			// 
			this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
			this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
			this.pictureEdit1.MenuManager = this.ribbonControl;
			this.pictureEdit1.Name = "pictureEdit1";
			this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
			this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
			this.pictureEdit1.Size = new System.Drawing.Size(41, 32);
			this.pictureEdit1.StyleController = this.layoutControl1;
			this.pictureEdit1.TabIndex = 12;
			// 
			// chkActivo
			// 
			this.chkActivo.Location = new System.Drawing.Point(612, 64);
			this.chkActivo.MenuManager = this.ribbonControl;
			this.chkActivo.Name = "chkActivo";
			this.chkActivo.Properties.Caption = "Activo";
			this.chkActivo.Size = new System.Drawing.Size(99, 19);
			this.chkActivo.StyleController = this.layoutControl1;
			this.chkActivo.TabIndex = 11;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(469, 90);
			this.txtDocumento.MenuManager = this.ribbonControl;
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Properties.ReadOnly = true;
			this.txtDocumento.Size = new System.Drawing.Size(242, 20);
			this.txtDocumento.StyleController = this.layoutControl1;
			this.txtDocumento.TabIndex = 10;
			// 
			// txtConsecutivo
			// 
			this.txtConsecutivo.Location = new System.Drawing.Point(240, 90);
			this.txtConsecutivo.MenuManager = this.ribbonControl;
			this.txtConsecutivo.Name = "txtConsecutivo";
			this.txtConsecutivo.Properties.Mask.EditMask = "n0";
			this.txtConsecutivo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtConsecutivo.Properties.ReadOnly = true;
			this.txtConsecutivo.Size = new System.Drawing.Size(157, 20);
			this.txtConsecutivo.StyleController = this.layoutControl1;
			this.txtConsecutivo.TabIndex = 8;
			// 
			// txtPRefijo
			// 
			this.txtPRefijo.Location = new System.Drawing.Point(79, 90);
			this.txtPRefijo.MenuManager = this.ribbonControl;
			this.txtPRefijo.Name = "txtPRefijo";
			this.txtPRefijo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
			this.txtPRefijo.Properties.Mask.EditMask = "\\p{Lu}\\p{Lu}\\p{Lu}";
			this.txtPRefijo.Properties.Mask.IgnoreMaskBlank = false;
			this.txtPRefijo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
			this.txtPRefijo.Properties.Mask.SaveLiteral = false;
			this.txtPRefijo.Properties.Mask.ShowPlaceHolders = false;
			this.txtPRefijo.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtPRefijo.Size = new System.Drawing.Size(89, 20);
			this.txtPRefijo.StyleController = this.layoutControl1;
			this.txtPRefijo.TabIndex = 7;
			this.txtPRefijo.EditValueChanged += new System.EventHandler(this.txtPRefijo_EditValueChanged);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(79, 64);
			this.txtDescripcion.MenuManager = this.ribbonControl;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(527, 20);
			this.txtDescripcion.StyleController = this.layoutControl1;
			this.txtDescripcion.TabIndex = 6;
			// 
			// gridControl
			// 
			this.gridControl.Location = new System.Drawing.Point(13, 116);
			this.gridControl.MainView = this.gridView1;
			this.gridControl.MenuManager = this.ribbonControl;
			this.gridControl.Name = "gridControl";
			this.gridControl.Size = new System.Drawing.Size(698, 226);
			this.gridControl.TabIndex = 5;
			this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.Ivory;
			this.gridView1.Appearance.Row.Options.UseBackColor = true;
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDConsecutivo,
            this.colDescr,
            this.colPrefijo,
            this.colConsecutivo,
            this.colDocumento,
            this.colActivo});
			this.gridView1.GridControl = this.gridControl;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsView.ShowAutoFilterRow = true;
			// 
			// colIDConsecutivo
			// 
			this.colIDConsecutivo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colIDConsecutivo.AppearanceHeader.Options.UseFont = true;
			this.colIDConsecutivo.Caption = "ID Consecutivo";
			this.colIDConsecutivo.FieldName = "IDConsecutivo";
			this.colIDConsecutivo.Name = "colIDConsecutivo";
			this.colIDConsecutivo.OptionsColumn.FixedWidth = true;
			this.colIDConsecutivo.Visible = true;
			this.colIDConsecutivo.VisibleIndex = 0;
			this.colIDConsecutivo.Width = 88;
			// 
			// colDescr
			// 
			this.colDescr.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colDescr.AppearanceHeader.Options.UseFont = true;
			this.colDescr.Caption = "Descripción";
			this.colDescr.FieldName = "Descr";
			this.colDescr.Name = "colDescr";
			this.colDescr.Visible = true;
			this.colDescr.VisibleIndex = 1;
			this.colDescr.Width = 225;
			// 
			// colPrefijo
			// 
			this.colPrefijo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colPrefijo.AppearanceHeader.Options.UseFont = true;
			this.colPrefijo.Caption = "Prefijo";
			this.colPrefijo.FieldName = "Prefijo";
			this.colPrefijo.Name = "colPrefijo";
			this.colPrefijo.OptionsColumn.FixedWidth = true;
			this.colPrefijo.Visible = true;
			this.colPrefijo.VisibleIndex = 2;
			this.colPrefijo.Width = 80;
			// 
			// colConsecutivo
			// 
			this.colConsecutivo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colConsecutivo.AppearanceHeader.Options.UseFont = true;
			this.colConsecutivo.Caption = "Consecutivo";
			this.colConsecutivo.FieldName = "Consecutivo";
			this.colConsecutivo.Name = "colConsecutivo";
			this.colConsecutivo.OptionsColumn.FixedWidth = true;
			this.colConsecutivo.Visible = true;
			this.colConsecutivo.VisibleIndex = 3;
			this.colConsecutivo.Width = 81;
			// 
			// colDocumento
			// 
			this.colDocumento.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colDocumento.AppearanceHeader.Options.UseFont = true;
			this.colDocumento.Caption = "Documento";
			this.colDocumento.FieldName = "Documento";
			this.colDocumento.Name = "colDocumento";
			this.colDocumento.OptionsColumn.FixedWidth = true;
			this.colDocumento.Visible = true;
			this.colDocumento.VisibleIndex = 4;
			this.colDocumento.Width = 70;
			// 
			// colActivo
			// 
			this.colActivo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colActivo.AppearanceHeader.Options.UseFont = true;
			this.colActivo.Caption = "Activo";
			this.colActivo.FieldName = "Activo";
			this.colActivo.Name = "colActivo";
			this.colActivo.OptionsColumn.FixedWidth = true;
			this.colActivo.Visible = true;
			this.colActivo.VisibleIndex = 5;
			this.colActivo.Width = 105;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
			this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
			this.labelControl1.Location = new System.Drawing.Point(58, 13);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(653, 30);
			this.labelControl1.StyleController = this.layoutControl1;
			this.labelControl1.TabIndex = 4;
			this.labelControl1.Text = "Listado de Consecutivos Globales";
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem2});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.Size = new System.Drawing.Size(724, 355);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.labelControl1;
			this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.layoutControlItem1.Location = new System.Drawing.Point(45, 0);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(276, 25);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem1.Size = new System.Drawing.Size(659, 36);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.Text = "Listado de Consecutivos Globales";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.gridControl;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 103);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem2.Size = new System.Drawing.Size(704, 232);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.txtDescripcion;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 51);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem3.Size = new System.Drawing.Size(599, 26);
			this.layoutControlItem3.Text = "Descricpción:";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(63, 13);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.txtPRefijo;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 77);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem4.Size = new System.Drawing.Size(161, 26);
			this.layoutControlItem4.Text = "Prefijo:";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(63, 13);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.txtConsecutivo;
			this.layoutControlItem5.Location = new System.Drawing.Point(161, 77);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem5.Size = new System.Drawing.Size(229, 26);
			this.layoutControlItem5.Text = "Consecutivo:";
			this.layoutControlItem5.TextSize = new System.Drawing.Size(63, 13);
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.txtDocumento;
			this.layoutControlItem7.Location = new System.Drawing.Point(390, 77);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem7.Size = new System.Drawing.Size(314, 26);
			this.layoutControlItem7.Text = "Documento:";
			this.layoutControlItem7.TextSize = new System.Drawing.Size(63, 13);
			// 
			// layoutControlItem8
			// 
			this.layoutControlItem8.Control = this.chkActivo;
			this.layoutControlItem8.Location = new System.Drawing.Point(599, 51);
			this.layoutControlItem8.Name = "layoutControlItem8";
			this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.layoutControlItem8.Size = new System.Drawing.Size(105, 26);
			this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem8.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 36);
			this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 15);
			this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 15);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(704, 15);
			this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.pictureEdit1;
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem6.MaxSize = new System.Drawing.Size(45, 36);
			this.layoutControlItem6.MinSize = new System.Drawing.Size(45, 36);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(45, 36);
			this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// frmConsecutivos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 498);
			this.Controls.Add(this.layoutControl1);
			this.Controls.Add(this.ribbonControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConsecutivos";
			this.Ribbon = this.ribbonControl;
			this.Text = "Listado de Consecutivos";
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDocumento.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtConsecutivo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPRefijo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.TextEdit txtDocumento;
        private DevExpress.XtraEditors.TextEdit txtConsecutivo;
        private DevExpress.XtraEditors.TextEdit txtPRefijo;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn colIDConsecutivo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colPrefijo;
        private DevExpress.XtraGrid.Columns.GridColumn colConsecutivo;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}