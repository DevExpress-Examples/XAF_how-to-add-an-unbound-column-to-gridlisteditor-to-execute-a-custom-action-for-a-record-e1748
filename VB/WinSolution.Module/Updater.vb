Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating

Namespace WinSolution.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub

		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			For i As Integer = 0 To 4
				Dim o As Order = ObjectSpace.CreateObject(Of Order)()
				o.Name = String.Format("Order{0}", i)
				If i Mod 2 = 0 Then
					o.SimpleBusinessAction()
				End If
			Next i
		End Sub
	End Class
End Namespace