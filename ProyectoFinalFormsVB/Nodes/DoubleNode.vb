Public Class DoubleNode
    Public Property Back As DoubleNode
    Public Property [Next] As DoubleNode
        Public Property Data As Integer

    Public Sub New(data As Integer)
        Me.Data = data
        Me.Next = Nothing
        Me.Back = Nothing
    End Sub
End Class
