Public Class CircularDoublyLinkedList
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
            NewNode.Back = Head
            NewNode.Next = Head
            LastNode = Head
            Return
        End If

        ' Caso 2: Impedimos datos repetidos
        If Exist(NewNode.Data) Then
            Return
        End If

        ' Caso 3: Insertamos al inicio si el dato es menor
        If NewNode.Data < Head.Data Then
            NewNode.Next = Head
            NewNode.Back = Head
            Head.Next = NewNode
            Head.Back = NewNode
            LastNode = Head
            Head = NewNode
            Return
        End If

        ' Caso 4: Insertamos al final si el dato es mayor
        If NewNode.Data > LastNode.Data Then
            NewNode.Back = LastNode
            LastNode.Next = NewNode
            LastNode = NewNode
            LastNode.Next = Head
            Head.Back = LastNode
            Return
        End If

        ' Caso 5: Recorremos la lista
        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data < NewNode.Data
            CurrentNode = CurrentNode.Next
        End While

        ' Caso 6: Insertamos en X posición
        NewNode.Next = CurrentNode.Next
        NewNode.Back = CurrentNode
        CurrentNode.Next.Back = NewNode
        CurrentNode.Next = NewNode
    End Sub

    Public Sub Delete(data As Integer, textBox As TextBox)
        ' Caso 1: Si la lista está vacía
        If IsEmpty() Then
            Return
        End If

        ' Caso 2: Eliminamos y comprobamos si hay solo un elemento
        If Head.Data = LastNode.Data Then
            Clear()
            textBox.Text = $"- Dato[{data}] Eliminado de la lista"
            Return
        End If

        ' Caso 3: El dato está al inicio de la lista
        If Head.Data = data Then
            Head = Head.Next
            Head.Back = LastNode
            LastNode.Next = Head
            textBox.Text = $"- Dato[{data}] Eliminado de la lista"
            Return
        End If

        ' Caso 4: El dato está al final de la lista
        If LastNode.Data = data Then
            LastNode = LastNode.Back
            LastNode.Next = Head
            Head.Back = LastNode
            textBox.Text = $"- Dato[{data}] Eliminado de la lista"
            Return
        End If

        ' Caso 5: Recorremos la lista
        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data < data
            CurrentNode = CurrentNode.Next
        End While

        ' Caso 6: El dato está en X posición de la lista
        If CurrentNode.Next.Data = data Then
            If CurrentNode.Next.Next IsNot Nothing Then
                CurrentNode.Next.Next.Back = CurrentNode
            End If
            CurrentNode.Next = CurrentNode.Next.Next
            textBox.Text = $"- Dato[{data}] Eliminado de la lista"
            Return
        End If

        ' Caso 7: No se encontró el dato a eliminar
        textBox.Text = $"- Dato[{data}] No encontrado/eliminado de la lista"
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
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
            CurrentNode = CurrentNode.Next
        End While

        ' Caso 5: Si existe el dato en la lista
        If CurrentNode.Data = data Then
            textBox.Text = $"- Dato[{data}] Existe en la lista"
            Return
        End If

        ' Caso 6: No existe el dato en la lista
        textBox.Text = $"- Dato[{data}] No Existe en la lista "
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
        Do
            textBox.Text += $"- Nodo[{i}] y dato: {CurrentNode.Data}{vbCrLf}"
            CurrentNode = CurrentNode.Next
            i += 1
        Loop While CurrentNode IsNot Head
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
    '     Console.WriteLine("=== Mi Lista circular doblemente enlazada Reversa ===")
    '     Do
    '         Console.WriteLine($"- Nodo[{i}] y dato: " + CurrentNode.Data)
    '         CurrentNode = CurrentNode.Back
    '         i += 1
    '     Loop While CurrentNode IsNot LastNode
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
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
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