Imports System
Imports DevExpress.Data
Imports DevExpress.Utils
Imports DevExpress.ExpressApp
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Editors

Namespace WinSolution.Module.Win
    Public Class SimpleBusinessActionGridListViewController
        Inherits ViewController(Of ListView)
        Private unboundModelColumn As IModelColumn
        Private Const ButtonColumnCaption As String = "Action"
        Private Const ButtonColumnName As String = "UnboundButtonColumn"
        Private defaultButtonColumnColumnProperties As RepositoryItemButtonEdit
        Private activebutton As New EditorButton(ButtonPredefines.OK)
        Private inactivebutton As New EditorButton(ButtonPredefines.Close)
        Private gridListEditor As GridListEditor
        Public Sub New()
            TargetObjectType = GetType(Order)
        End Sub
        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            gridListEditor = TryCast(View.Editor, GridListEditor)
            If gridListEditor IsNot Nothing Then
                InitGridView()
                InitButtonColumn()
            End If
        End Sub
        Private Sub InitGridView()
            AddHandler gridListEditor.GridView.CustomRowCellEdit, AddressOf gridView_CustomRowCellEdit
            AddHandler gridListEditor.GridView.CustomRowCellEditForEditing, AddressOf gridView_CustomRowCellEdit
            gridListEditor.GridView.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown
        End Sub
        Private Sub InitButtonColumn()
            unboundModelColumn = gridListEditor.Model.Columns.GetNode(Of IModelColumn)(ButtonColumnName)
            If unboundModelColumn Is Nothing Then
                unboundModelColumn = gridListEditor.Model.Columns.AddNode(Of IModelColumn)(ButtonColumnName)
                unboundModelColumn.PropertyName = ButtonColumnName
                unboundModelColumn.PropertyEditorType = GetType(DefaultPropertyEditor)
	For i As Integer = gridListEditor.Columns.Count - 1 To 0 Step -1
		Dim cw As ColumnWrapper = gridListEditor.Columns(i)
		If cw.PropertyName = unboundModelColumn.PropertyName Then
			gridListEditor.RemoveColumn(cw)
			Exit For
		End If
	Next i
                gridListEditor.AddColumn(unboundModelColumn)
            End If
            Dim buttonColumn As GridColumn = gridListEditor.GridView.Columns(unboundModelColumn.PropertyName)
            If buttonColumn IsNot Nothing Then
                buttonColumn.UnboundType = UnboundColumnType.Boolean
                buttonColumn.Caption = ButtonColumnCaption
                buttonColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                buttonColumn.VisibleIndex = 0
                buttonColumn.Width = 50
                buttonColumn.OptionsColumn.AllowEdit = True
                buttonColumn.OptionsColumn.AllowGroup = DefaultBoolean.False
                buttonColumn.OptionsColumn.AllowMove = False
                buttonColumn.OptionsColumn.AllowShowHide = False
                buttonColumn.OptionsColumn.AllowSize = False
                buttonColumn.OptionsColumn.AllowSort = DefaultBoolean.False
                buttonColumn.OptionsColumn.FixedWidth = True
                buttonColumn.OptionsColumn.ShowInCustomizationForm = False
                buttonColumn.OptionsFilter.AllowFilter = False
                InitButtonEditor()
            End If
        End Sub
        Private Sub InitButtonEditor()
            defaultButtonColumnColumnProperties = New RepositoryItemButtonEdit()
            defaultButtonColumnColumnProperties.TextEditStyle = TextEditStyles.HideTextEditor
            AddHandler defaultButtonColumnColumnProperties.Click, AddressOf buttonColumnColumnProperties_Click
            gridListEditor.GridView.GridControl.RepositoryItems.Add(defaultButtonColumnColumnProperties)
        End Sub
        Private Sub UpdateButtons(ByVal properties As RepositoryItemButtonEdit, ByVal active As Boolean)
            Dim button As EditorButton = Nothing
            If active Then
                button = inactivebutton
            Else
                button = activebutton
            End If
            If properties.Buttons(0).Kind <> button.Kind Then
                properties.BeginInit()
                properties.Buttons.Clear()
                properties.Buttons.Add(button)
                properties.EndInit()
            End If
        End Sub
        Private Sub gridView_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)
            If e.Column.FieldName = ButtonColumnName Then
                Dim order As Order = TryCast(gridListEditor.GridView.GetRow(e.RowHandle), Order)
                If order IsNot Nothing Then
                    Dim item As RepositoryItemButtonEdit = TryCast(defaultButtonColumnColumnProperties.Clone(), RepositoryItemButtonEdit)
                    UpdateButtons(item, order.Active)
                    e.RepositoryItem = item
                End If
            End If
        End Sub
        Private Sub buttonColumnColumnProperties_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim editor As ButtonEdit = CType(sender, ButtonEdit)
            Dim order As Order = TryCast(gridListEditor.GridView.GetFocusedRow(), Order)
            If order IsNot Nothing Then
                order.SimpleBusinessAction()
                UpdateButtons(editor.Properties, order.Active)
            End If
        End Sub
        Protected Overrides Sub OnDeactivating()
            If gridListEditor IsNot Nothing AndAlso gridListEditor.GridView IsNot Nothing Then
                RemoveHandler gridListEditor.GridView.CustomRowCellEdit, AddressOf gridView_CustomRowCellEdit
                RemoveHandler gridListEditor.GridView.CustomRowCellEditForEditing, AddressOf gridView_CustomRowCellEdit
                If unboundModelColumn IsNot Nothing Then
                    CType(unboundModelColumn.Parent, IModelColumns).Remove(unboundModelColumn)
                End If
            End If
            If defaultButtonColumnColumnProperties IsNot Nothing Then
                RemoveHandler defaultButtonColumnColumnProperties.Click, AddressOf buttonColumnColumnProperties_Click
            End If
            MyBase.OnDeactivating()
        End Sub
    End Class
End Namespace