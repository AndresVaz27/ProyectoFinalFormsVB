Public Class Auto
    Public Sub Auto_Add_SimpleList(ByVal lista As SimpleList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.[Next](25))
        Next

        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_SimpleList(ByVal lista As SimpleList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_SimpleList(ByVal lista As SimpleList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Add_CircularList(ByVal lista As CircularList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        textBox.Text = String.Empty

        For i As Integer = 0 To numDatos - 1
            lista.Add(R.[Next](25))
        Next

        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_CircularList(ByVal lista As CircularList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_CircularList(ByVal lista As CircularList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Add_DoublyListLinked(ByVal lista As DoublyLinkedList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.[Next](25))
        Next

        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_DoublyListLinked(ByVal lista As DoublyLinkedList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_DoublyListLinked(ByVal lista As DoublyLinkedList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Add_CircularDoublyLinkedList(ByVal lista As CircularDoublyLinkedList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.[Next](25))
        Next

        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_CircularDoublyLinkedList(ByVal lista As CircularDoublyLinkedList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.[Next](25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_CircularDoublyLinkedList(ByVal lista As CircularDoublyLinkedList, ByVal R As Random, ByVal textBox As System.Windows.Forms.TextBox, ByVal numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.[Next](25), textBox)
        Next
    End Sub
End Class
