Imports System.Collections.ObjectModel

Namespace DXGrid_CustomGrouping

    Public Class MyViewModel

        Public Sub New()
            CreateList()
        End Sub

        Public Property ListPerson As ObservableCollection(Of Person)

        Private Sub CreateList()
            ListPerson = New ObservableCollection(Of Person)()
            For i As Integer = 0 To 100 - 1
                Dim p As Person = New Person(i)
                ListPerson.Add(p)
            Next
        End Sub
    End Class

    Public Class Person

        Public Sub New()
        End Sub

        Public Sub New(ByVal i As Integer)
            FirstName = "FirstName" & i
            LastName = "LastName" & i
            UnitPrice = i
        End Sub

        Private _firstName As String

        Public Property FirstName As String
            Get
                Return _firstName
            End Get

            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName As String

        Private _age As Integer

        Public Property UnitPrice As Integer
            Get
                Return _age
            End Get

            Set(ByVal value As Integer)
                _age = value
            End Set
        End Property
    End Class
End Namespace
