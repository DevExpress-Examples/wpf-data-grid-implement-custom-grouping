Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace CustomGrouping_MVVM

    Public Class Person

        Public Property FirstName As String

        Public Property LastName As String

        Public Property UnitPrice As Integer

        Public Sub New()
        End Sub

        Public Sub New(ByVal i As Integer)
            FirstName = "FirstName" & i
            LastName = "LastName" & i
            UnitPrice = i
        End Sub
    End Class

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property ListPerson As ObservableCollection(Of Person)

        Public Sub New()
            ListPerson = New ObservableCollection(Of Person)(GetPersonList())
        End Sub

        Private Shared Function GetPersonList() As IEnumerable(Of Person)
            Return Enumerable.Range(0, 100).[Select](Function(i) New Person(i))
        End Function

        <Command>
        Public Sub CustomColumnGroup(ByVal args As RowSortArgs)
            If Not Equals(args.FieldName, "UnitPrice") Then Return
            Dim x As Double = Math.Floor(Convert.ToDouble(args.FirstValue) / 10)
            Dim y As Double = Math.Floor(Convert.ToDouble(args.SecondValue) / 10)
            args.Result = If(x > 9 AndAlso y > 9, 0, x.CompareTo(y))
        End Sub

        <Command>
        Public Sub CustomGroupDisplayText(ByVal args As GroupDisplayTextArgs)
            If Not Equals(args.FieldName, "UnitPrice") Then Return
            Dim interval As String = IntervalByValue(args.Value)
            args.DisplayText = interval
        End Sub

        ' Gets the interval which contains the specified value.
        Private Function IntervalByValue(ByVal val As Object) As String
            Dim d As Double = Math.Floor(Convert.ToDouble(val) / 10)
            Dim ret As String = String.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10)
            If d > 9 Then ret = String.Format(">= {0:c} ", 100)
            Return ret
        End Function
    End Class
End Namespace
