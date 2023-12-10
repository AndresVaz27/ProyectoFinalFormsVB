Public Class BinaryTreeNode
    Public Value As Integer
    Public Left, Right As BinaryTreeNode

    Public Sub New(value As Integer)
        Me.Value = value
        Left = Nothing
        Right = Nothing
    End Sub
End Class
