Imports System.Collections
Imports System.Windows.Forms


Public Class ListViewColumnSorter
    Implements IComparer
    Private ColumnToSort As Integer ' Specifies the column to be sorted
    Private OrderOfSort As SortOrder ' Specifies the order in which to sort (i.e. 'Ascending').
    Private ObjectCompare As CaseInsensitiveComparer ' Case insensitive comparer object
    Public Sub New() ' Class constructor.  Initializes various elements
        ColumnToSort = 0  ' Initialize the column to '0'
        OrderOfSort = SortOrder.None ' Initialize the sort order to 'none'
        ObjectCompare = New CaseInsensitiveComparer() ' Initialize the CaseInsensitiveComparer object
    End Sub

    'This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    'he result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        On Error Resume Next
        Dim compareResult As Integer
        Dim listviewX, listviewY As ListViewItem : listviewX = DirectCast(x, ListViewItem) : listviewY = DirectCast(y, ListViewItem)
        Dim ts1, ts2 As New TimeSpan
        ts1 = TimeSpan.Parse(listviewX.SubItems(ColumnToSort).Text)
        ts2 = TimeSpan.Parse(listviewY.SubItems(ColumnToSort).Text)
        Dim b As Boolean
        If ts1 = Nothing OrElse ts2 = Nothing Then b = False
        If IsNumeric(listviewX.SubItems(ColumnToSort).Text) = True AndAlso IsNumeric(listviewY.SubItems(ColumnToSort).Text) = True Then
            compareResult = ObjectCompare.Compare(CInt(listviewX.SubItems(ColumnToSort).Text), CInt(listviewY.SubItems(ColumnToSort).Text))
        ElseIf b = True AndAlso ts1.TotalMilliseconds > 0 OrElse ts2.TotalMilliseconds > 0 Then
            'compareResult = ObjectCompare.Compare(ts1, ts2)
            compareResult = TimeSpan.Compare(ts1, ts2)
        Else
            compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
        End If

        ' Calculate correct return value based on object comparison
        If OrderOfSort = SortOrder.Ascending Then
            ' Ascending sort is selected, return normal result of compare operation
            Return compareResult
        ElseIf OrderOfSort = SortOrder.Descending Then
            ' Descending sort is selected, return negative result of compare operation
            Return (-compareResult)
        Else
            ' Return '0' to indicate they are equal
            Return 0
        End If
        ColumnToSort = 3  ' Initialize the column to '0'
        OrderOfSort = SortOrder.None ' Initialize the sort order to 'none'
        ObjectCompare = New CaseInsensitiveComparer() ' Initialize the CaseInsensitiveComparer object
    End Function

    ''' <summary>
    ''' Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    ''' </summary>
    Public Property SortColumn() As Integer
        Get
            Return ColumnToSort
        End Get
        Set(ByVal value As Integer)
            ColumnToSort = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    ''' </summary>
    Public Property Order() As SortOrder
        Get
            Return OrderOfSort
        End Get
        Set(ByVal value As SortOrder)
            OrderOfSort = value
        End Set
    End Property

End Class

