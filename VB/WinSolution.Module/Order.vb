Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinSolution.Module
	<DefaultClassOptions> _
	Public Class Order
		Inherits BaseObject
		Implements ISimpleBusinessAction
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private nameCore As String
		Public Property Name() As String
			Get
				Return nameCore
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", nameCore, value)
			End Set
		End Property
		Private descriptionCore As String
		Public Property Description() As String
			Get
				Return descriptionCore
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Description", descriptionCore, value)
			End Set
		End Property
		<Persistent("Active")> _
		Private activeCore As Boolean = True
		<PersistentAlias("activeCore")> _
		Public ReadOnly Property Active() As Boolean Implements ISimpleBusinessAction.Active
			Get
				Return activeCore
			End Get
		End Property
		<Action> _
		Public Sub SimpleBusinessAction() Implements ISimpleBusinessAction.SimpleBusinessAction
			activeCore = Not activeCore
			OnChanged("Active")
		End Sub
	End Class
	Public Interface ISimpleBusinessAction
		ReadOnly Property Active() As Boolean
		Sub SimpleBusinessAction()
	End Interface
End Namespace