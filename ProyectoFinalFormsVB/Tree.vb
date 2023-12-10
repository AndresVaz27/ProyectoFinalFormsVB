Public Class Tree
    Public Property Root As TreeNode

    Public Sub New(root As TreeNode)
            Me.Root = root
        End Sub

        Public Sub PrintTree(node As TreeNode, textBox As TextBox, Optional indent As String = "")
            textBox.Text &= (indent & $"└─  {node.Name}" & vbCrLf)

            For i As Integer = 0 To node.Children.Count - 1
                PrintTree(node.Children(i), textBox, indent & "   ")
            Next
        End Sub

        Public Function FindNode(nodeName As String, Optional node As TreeNode = Nothing) As TreeNode
            If node Is Nothing Then
                node = Root
            End If

            If node.Name = nodeName Then
                Return node
            End If

            For Each child In node.Children
                Dim foundNode = FindNode(nodeName, child)
                If foundNode IsNot Nothing Then
                    Return foundNode
                End If
            Next

            Return Nothing
        End Function

        Public Async Sub AddNode(parentNodeName As String, newNodeName As String, textBox As TextBox)
            Dim parentNode = FindNode(parentNodeName)
            If parentNode IsNot Nothing Then
                parentNode.Children.Add(New TreeNode(newNodeName))
                textBox.Text = String.Empty
                PrintTree(Root, textBox)
            Else
                textBox.Text = $"No se encontró el nodo padre '{parentNodeName}'."
                Await Task.Delay(2000)
                textBox.Text = String.Empty
                PrintTree(Root, textBox)
            End If
        End Sub

        Public Async Sub DeleteNode(nodeName As String, textBox As TextBox)
            Dim nodeToDelete = FindNode(nodeName)
            If nodeToDelete IsNot Nothing Then
                Dim parent = FindParentNode(nodeName)

                If nodeToDelete Is Root Then
                    ' Eliminando el nodo raíz
                    If nodeToDelete.Children.Count > 0 Then
                        ' Asignar el primer hijo como el nuevo nodo raíz
                        Root = nodeToDelete.Children(0)
                        textBox.Text = $"El nodo raíz '{nodeName}' se eliminó, y el primer hijo se convirtió en el nuevo raíz."
                    Else
                        Root = Nothing
                        textBox.Text = $"El nodo raíz '{nodeName}' se eliminó."
                    End If
                ElseIf parent IsNot Nothing Then
                    If nodeToDelete.Children.Count > 0 Then
                        ' Convertir el primer hijo en el nuevo padre
                        Dim firstChild = nodeToDelete.Children(0)
                        firstChild.Children.AddRange(nodeToDelete.Children.Skip(1))
                        parent.Children.Insert(parent.Children.IndexOf(nodeToDelete), firstChild)
                    End If
                    parent.Children.Remove(nodeToDelete)
                    textBox.Text = $"El nodo '{nodeName}' se eliminó, y el primer hijo se convirtió en el nuevo padre sin cambiar la posición de la rama."
                End If

                Await Task.Delay(2000)
                textBox.Text = String.Empty
                PrintTree(Root, textBox)
            Else
                textBox.Text = $"No se encontró el nodo '{nodeName}'."
            End If
        End Sub

        Private Function FindParentNode(nodeName As String, Optional node As TreeNode = Nothing) As TreeNode
            If node Is Nothing Then
                node = Root
            End If

            For Each child In node.Children
                If child.Name = nodeName Then
                    Return node
                End If

                Dim parent = FindParentNode(nodeName, child)
                If parent IsNot Nothing Then
                    Return parent
                End If
            Next

            Return Nothing
        End Function
    End Class