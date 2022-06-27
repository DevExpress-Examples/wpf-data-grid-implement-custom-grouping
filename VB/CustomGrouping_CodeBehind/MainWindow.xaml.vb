Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Namespace CustomGrouping_CodeBehind

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

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = GetPersonList().ToList()
        End Sub

        Private Shared Function GetPersonList() As IEnumerable(Of Person)
            Return Enumerable.Range(0, 100).[Select](Function(i) New Person(i))
        End Function

        Private Sub OnCustomColumnGroup(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
            If Not Equals(e.Column.FieldName, "UnitPrice") Then Return
            Dim x As Double = Math.Floor(Convert.ToDouble(e.Value1) / 10)
            Dim y As Double = Math.Floor(Convert.ToDouble(e.Value2) / 10)
            e.Result = If(x > 9 AndAlso y > 9, 0, x.CompareTo(y))
            e.Handled = True
        End Sub

        Private Sub OnCustomGroupDisplayText(ByVal sender As Object, ByVal e As CustomGroupDisplayTextEventArgs)
            If Not Equals(e.Column.FieldName, "UnitPrice") Then Return
            Dim interval As String = IntervalByValue(e.Value)
            e.DisplayText = interval
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
