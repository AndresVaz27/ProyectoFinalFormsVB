Public Class DoublyLinkedList
    Private Property Head As DoubleNode
    Private Property LastNode As DoubleNode

        Public Sub New()
            Clear()
        End Sub

        Public Sub Add(data As Integer)
            ' Caso 0: Creamos un nuevo nodo
            Dim NewNode As New DoubleNode(data)

            ' Caso 1: Insertamos al inicio
            If IsEmpty() Then
                Head = NewNode
                LastNode = NewNode
                Return
            End If

            ' Caso 2: Impedimos datos repetidos
            If Exist(NewNode.Data) Then
                Return
            End If

            ' Caso 3: El dato nuevo se inserta al inicio
            If NewNode.Data < Head.Data Then
                Head.Back = NewNode
                NewNode.Next = Head
                Head = NewNode
                Return
            End If

            ' Caso 4: El dato nuevo se inserta al final
            If NewNode.Data > LastNode.Data Then
                LastNode.Next = NewNode
                NewNode.Back = LastNode
                LastNode = NewNode
                Return
            End If

            ' Caso 5: Recorremos la lista
            Dim CurrentNode As DoubleNode = Head
            While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data < NewNode.Data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 6: Insertamos en X posición
            NewNode.Next = CurrentNode.Next
            NewNode.Back = CurrentNode
            If CurrentNode.Next IsNot Nothing Then
                CurrentNode.Next.Back = NewNode
            End If
            CurrentNode.Next = NewNode
        End Sub

        Public Sub Delete(data As Integer, textBox As TextBox)
            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                Return
            End If

            ' Caso 2: El dato a eliminar está al inicio de la lista
            If Head.Data = data Then
                Head = Head.Next
                If Head IsNot Nothing Then
                    Head.Back = Nothing
                End If
                textBox.Text = $"- Dato[{data}] Eliminado de la lista"
                Return
            End If

            ' Caso 3: El dato a eliminar está al final de la lista
            If LastNode.Data = data Then
                LastNode = LastNode.Back
                If LastNode IsNot Nothing Then
                    LastNode.Next = Nothing
                End If
                textBox.Text = $"- Dato[{data}] Eliminado de la lista"
                Return
            End If

            ' Caso 4: Recorremos la lista
            Dim CurrentNode As DoubleNode = Head
            While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data < data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 5: El dato está en X posición de la lista
            If CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data = data Then
                If CurrentNode.Next.Next IsNot Nothing Then
                    CurrentNode.Next.Next.Back = CurrentNode
                End If
                CurrentNode.Next = CurrentNode.Next.Next
                textBox.Text = $"- Dato[{data}] Eliminado de la lista"
                Return
            End If

            ' Caso 6: No se encontró el dato
            textBox.Text = $"- Dato[{data}] No existe/eliminado de la lista"
        End Sub

        Public Sub Search(data As Integer, textBox As TextBox)
            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                Return
            End If

            ' Caso 2: Si el dato está al inicio
            If Head.Data = data Then
                textBox.Text = $"- Dato[{data}] Existe en la lista"
                Return
            End If

            ' Caso 3: Si el dato está al final
            If LastNode.Data = data Then
                textBox.Text = $"- Dato[{data}] Existe en la lista"
                Return
            End If

            ' Caso 4: Recorremos la lista
            Dim CurrentNode As DoubleNode = Head
            While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data <= data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 5: Si existe el dato en X posición
            If CurrentNode.Data = data Then
                textBox.Text = $"- Dato[{data}] Existe en la lista"
                Return
            End If

            ' Caso 6: No existe el dato en la lista
            textBox.Text = $"- Dato[{data}] No Existe en la lista"
        End Sub

        Public Sub Show(textBox As TextBox)
            textBox.Text = String.Empty

            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                textBox.Text = "Lista vacía"
                Return
            End If

            ' Caso 2: Recorremos la lista
            Dim CurrentNode As DoubleNode = Head
            Dim i As Integer = 0
            While CurrentNode IsNot Nothing
                textBox.Text += $"- Nodo[{i}] y dato: {CurrentNode.Data}{vbCrLf}"
                CurrentNode = CurrentNode.Next
                i += 1
            End While
        End Sub

        ' Public Sub ShowRevers()
        '     ' Caso 1: Si la lista está vacía
        '     If IsEmpty() Then
        '         Console.WriteLine("Lista vacía")
        '         Return
        '     End If

        '     ' Caso 2: Recorremos la lista
        '     Dim CurrentNode As DoubleNode = LastNode
        '     Dim i As Integer = 0
        '     Console.WriteLine("=== Mi Lista doblemente enlazada Reversa===")
        '     Do
        '         Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data)
        '         CurrentNode = CurrentNode.Back
        '         i += 1
        '     Loop While CurrentNode IsNot Nothing
        ' End Sub

        Public Function Exist(data As Integer) As Boolean
            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                Return False
            End If

            ' Caso 2: Si el primer elemento ya existe
            If Head.Data = data Then
                Return True
            End If

            ' Caso 3: Si el dato está al final
            If LastNode.Data = data Then
                Return True
            End If

            ' Caso 4: Recorremos la lista
            Dim CurrentNode As DoubleNode = Head
            While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data <= data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 5: El dato ingresado existe en X posición
            If CurrentNode.Data = data Then
                Return True
            End If

            ' Caso 6: El dato no existe en la lista
            Return False
        End Function

        Public Function IsEmpty() As Boolean
            Return Head Is Nothing
        End Function

        Public Sub Clear()
            Head = Nothing
            LastNode = Nothing
        End Sub
    End Class