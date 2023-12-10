Public Class TreeNode
    Public Property Name As String
    Public ReadOnly Property Children As List(Of TreeNode) = New List(Of TreeNode)()

        Public Sub New(name As String)
            Me.Name = name
        End Sub
End Class