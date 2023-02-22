Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Collections
Imports DevExpress.Xpf.Grid

Namespace DXGrid_CustomGrouping

    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            DataContext = New MyViewModel()
        End Sub

        Private Sub grid_CustomColumnGroup(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
            If Equals(e.Column.FieldName, "UnitPrice") Then
                Dim x As Double = Math.Floor(Convert.ToDouble(e.Value1) / 10)
                Dim y As Double = Math.Floor(Convert.ToDouble(e.Value2) / 10)
                Dim res As Integer = Comparer.Default.Compare(x, y)
                If x > 9 AndAlso y > 9 Then res = 0
                e.Result = res
                e.Handled = True
            End If
        End Sub

        Private Sub grid_CustomGroupDisplayText(ByVal sender As Object, ByVal e As CustomGroupDisplayTextEventArgs)
            If Not Equals(e.Column.FieldName, "UnitPrice") Then Return
            Dim groupLevel As Integer = Me.grid.GetRowLevelByRowHandle(e.RowHandle)
            If groupLevel <> e.Column.GroupIndex Then Return
            Dim interval As String = IntervalByValue(e.Value)
            e.DisplayText = interval
        End Sub

        ' Gets the text that represents the interval which contains the specified value.
        Private Function IntervalByValue(ByVal val As Object) As String
            Dim d As Double = Math.Floor(Convert.ToDouble(val) / 10)
            Dim ret As String = String.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10)
            If d > 9 Then ret = String.Format(">= {0:c} ", 100)
            Return ret
        End Function
    End Class
End Namespace
