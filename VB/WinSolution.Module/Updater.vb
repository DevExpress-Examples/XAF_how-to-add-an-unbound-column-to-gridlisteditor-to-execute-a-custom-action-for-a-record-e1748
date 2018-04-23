Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace WinSolution.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Using uow As New UnitOfWork(Session.DataLayer)
				For i As Integer = 0 To 4
					Dim o As New Order(uow)
					o.Name = String.Format("Order{0}", i)
					If i Mod 2 = 0 Then
						o.SimpleBusinessAction()
					End If
				Next i
				uow.CommitChanges()
			End Using
		End Sub
	End Class
End Namespace
