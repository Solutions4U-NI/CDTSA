﻿Imports Clases
Imports DevExpress.XtraGrid.Columns
Public Class frmpopupPromociones
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()
    Public gsProductoID As String
    Public gsIDNivel As String
    Public gsIDMoneda As String
    Private Sub frmpopupPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsProductoID <> "" Then
            Dim filterString As String = "[IDProducto] =" & gsProductoID
            Me.GridViewDetalle.Columns("IDProducto").FilterInfo = New ColumnFilterInfo(filterString)
        End If
        RefreshGrid()
    End Sub
    Sub RefreshGrid()
        Try
            tableData = cManager.ExecSPgetData("fafprintPromocionPrecios", "0," & gsIDNivel & "," & gsIDMoneda)
            GridControl1.DataSource = tableData
            GridControl1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub
End Class