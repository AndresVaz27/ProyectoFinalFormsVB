Public Class CircularList

    Private Property Head As Node
    Private Property LastNode As Node

        Public Sub New()
            Clear()
        End Sub

        Public Sub Add(data As Integer)
            ' Caso 0: Creamos un nuevo nodo
            Dim NewNode As New Node(data)

            ' Caso 1: Insertamos al inicio
            If IsEmpty() Then
                Head = NewNode
                Head.Next = Head
                LastNode = NewNode
                Return
            End If

            ' Caso 2: Impedimos datos repetidos
            If Exist(NewNode.Data) Then
                Return
            End If

            ' Caso 3: Colocamos el dato después del primero
            If NewNode.Data < Head.Data Then
                NewNode.Next = Head
                Head = NewNode
                LastNode.Next = Head
                Return
            End If

            ' Caso 4: Recorremos la lista
            Dim CurrentNode As Node = Head
            While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= NewNode.Data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 5: Insertamos en X posición
            If NewNode.Data < CurrentNode.Next.Data Then
                NewNode.Next = CurrentNode.Next
                CurrentNode.Next = NewNode
                Return
            End If

            ' Caso 6: Insertamos al último
            NewNode.Next = CurrentNode.Next
            CurrentNode.Next = NewNode
            LastNode = NewNode
        End Sub

        Public Sub Delete(data As Integer, textBox As TextBox)
            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                Return
            End If

            ' Caso 2: El dato está al inicio de la lista
            If Head.Data = data Then
                Head = Head.Next
                LastNode.Next = Head
                textBox.Text = $"- Dato[{data}] Eliminado de la lista"
                Return
            End If

            ' Caso 3: Recorremos la lista
            Dim CurrentNode As Node = Head
            While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data < data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 4: El dato está al final de la lista
            If CurrentNode.Next Is LastNode AndAlso CurrentNode.Next.Data = data Then
                CurrentNode.Next = CurrentNode.Next.Next
                LastNode = CurrentNode
                LastNode.Next = Head
                textBox.Text = $"- Dato[{data}] Eliminado de la lista"
                Return
            End If

            ' Caso 5: El dato está en X posición de la lista
            If CurrentNode.Next.Data = data Then
                CurrentNode.Next = CurrentNode.Next.Next
                textBox.Text = $"- Dato[{data}] Eliminado de la lista"
                Return
            End If

            ' Caso 6: No se encontró el dato
            textBox.Text = $"- Dato[{data}] No encontrado/eliminado de la lista"
        End Sub

        Public Sub Search(data As Integer, textBox As TextBox)
            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                Return
            End If

            ' Caso 2: Si el dato está al inicio de la lista
            If Head.Data = data Then
                textBox.Text = $"- Dato[{data}] Existe en la lista"
                Return
            End If

            ' Caso 3: Recorremos la lista
            Dim CurrentNode As Node = Head
            While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 4: El dato ingresado existe en X posición
            If CurrentNode.Data = data Then
                textBox.Text = $"- Dato[{data}] Existe en la lista"
                Return
            End If

            ' Caso 5: No existe el dato
            textBox.Text = $"- Dato[{data}] No Existe en la lista"
        End Sub

        Public Sub Show(textBox As TextBox)
            ' Caso 1: Comprobamos si la lista está vacía
            If IsEmpty() Then
                textBox.Text = "Lista vacía"
                Return
            End If

            ' Caso 2: Recorremos la lista
            Dim CurrentNode As Node = Head
            Dim i As Integer = 0

            Do
                textBox.Text += $"- Nodo[{i}] y dato: {CurrentNode.Data}{vbCrLf}"
                CurrentNode = CurrentNode.Next
                i += 1
            Loop While CurrentNode IsNot Head
        End Sub

        Public Function Exist(data As Integer) As Boolean
            ' Caso 1: Si la lista está vacía
            If IsEmpty() Then
                Return False
            End If

            ' Caso 2: Si el dato ya existe al inicio
            If Head.Data = data Then
                Return True
            End If

            ' Caso 3: Recorremos la lista
            Dim CurrentNode As Node = Head
            While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
                CurrentNode = CurrentNode.Next
            End While

            ' Caso 4: Si el dato ya existe en X posición/ o al final
            If CurrentNode.Data = data Then
                Return True
            End If

            ' Caso 5: El dato no existe en la lista
            Return False
        End Function

        Public Function IsEmpty() As Boolean
            Return Head Is Nothing
        End Function

        Public Sub Clear()
            Head = Nothing
        End Sub
End Class