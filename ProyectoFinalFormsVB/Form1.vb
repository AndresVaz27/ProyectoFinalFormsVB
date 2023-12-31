﻿Public Class Form1
    Private random As Random = New Random
    Private auto As Auto = New Auto
    Private stringStack As MyStack(Of String) = New MyStack(Of String)
    Private root As TreeNode = New TreeNode("Root")
    Private tree As Tree = New Tree(root)
    Private cola As Queue(Of String) = New Queue(Of String)
    Private bicola As LinkedList(Of String) = New LinkedList(Of String)
    Private grafo As Grafo = New Grafo
    Private colaPrioridad As SortedDictionary(Of Integer, Queue(Of String)) = New SortedDictionary(Of Integer, Queue(Of String))
    Private array As Integer() = {9, 1, 8, 2, 7}
    Private stopwatch As Stopwatch = New Stopwatch
    Private Async Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim Lista_Simple As SimpleList = New SimpleList
        auto.Auto_Add_SimpleList(Lista_Simple, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Delete_SimpleList(Lista_Simple, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Search_SimpleList(Lista_Simple, random, textBox2, Integer.Parse(textBox1.Text))
    End Sub

    Private Async Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Dim Circular_List As New CircularList

        auto.Auto_Add_CircularList(Circular_List, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)

        auto.Auto_Delete_CircularList(Circular_List, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)

        auto.Auto_Search_CircularList(Circular_List, random, textBox2, Integer.Parse(textBox1.Text))
    End Sub

    Private Async Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        Dim Doubly_List_Linked As New DoublyLinkedList

        auto.Auto_Add_DoublyListLinked(Doubly_List_Linked, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)

        auto.Auto_Delete_DoublyListLinked(Doubly_List_Linked, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)

        auto.Auto_Search_DoublyListLinked(Doubly_List_Linked, random, textBox2, Integer.Parse(textBox1.Text))
    End Sub

    Private Async Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
        Dim Circular_Doubly_Linked_List As New CircularDoublyLinkedList

        auto.Auto_Add_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)

        auto.Auto_Delete_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, Integer.Parse(textBox1.Text))
        Await Task.Delay(2000)

        auto.Auto_Search_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, Integer.Parse(textBox1.Text))
    End Sub

    Private Sub UpdateStackListBox()
        StackListBox.Items.Clear()

        For i As Integer = stringStack.Count - 1 To 0 Step -1
            Dim item As String = stringStack(i)
            StackListBox.Items.Add(item)
        Next
    End Sub

    Private Sub PushButton_Click(sender As Object, e As EventArgs) Handles PushButton.Click
        Dim item As String = InputTextBox.Text
        stringStack.Push(item)
        UpdateStackListBox()
        InputTextBox.Clear()
    End Sub

    Private Sub PopButton_Click(sender As Object, e As EventArgs) Handles PopButton.Click
        Try
            Dim poppedItem As String = stringStack.Pop()
            MessageBox.Show("Elemento desapilado: " & poppedItem)
            UpdateStackListBox()
        Catch ex As InvalidOperationException
            MessageBox.Show("La pila está vacía. No se pueden desapilar elementos.")
        End Try
    End Sub

    Private Sub PeekButton_Click(sender As Object, e As EventArgs) Handles PeekButton.Click
        Try
            Dim topItem As String = stringStack.Peek()
            MessageBox.Show("Elemento en la cima de la pila: " & topItem)
        Catch ex As InvalidOperationException
            MessageBox.Show("La pila está vacía. No hay elementos para ver.")
        End Try
    End Sub

    Private Sub btnEnqueue_Click(sender As Object, e As EventArgs) Handles btnEnqueue.Click
        ' Agregar un elemento a la cola
        Dim elemento As String = txtQueue.Text
        cola.Enqueue(elemento)

        ' Actualizar la lista de elementos en la cola
        ActualizarListaCola()
    End Sub
    Private Sub ActualizarListaCola()
        ' Mostrar la cola en el ListBox
        lstvQueue.Items.Clear()
        For Each elemento As String In cola
            lstvQueue.Items.Add(elemento)
        Next
    End Sub

    Private Sub btnDequeue_Click(sender As Object, e As EventArgs) Handles btnDequeue.Click
        ' Verificar si la cola no está vacía antes de intentar eliminar
        If cola.Count > 0 Then
            ' Eliminar el elemento de la cola
            Dim elementoEliminado As String = cola.Dequeue()

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Se eliminó el elemento: {elementoEliminado}")

            ' Actualizar la lista de elementos en la cola
            ActualizarListaCola()
        Else
            MessageBox.Show("La cola está vacía. No se pueden eliminar elementos.")
        End If
    End Sub

    Private Sub btnEnqueueFirst_Click(sender As Object, e As EventArgs) Handles btnEnqueueFirst.Click
        ' Agregar un elemento al inicio de la bicola
        Dim elemento As String = txtDeque.Text
        bicola.AddFirst(elemento)

        ' Actualizar la lista de elementos en la bicola
        ActualizarListaBicola()
    End Sub
    Private Sub ActualizarListaBicola()
        ' Mostrar la bicola en el ListBox
        lstvDeque.Items.Clear()
        For Each elemento As String In bicola
            lstvDeque.Items.Add(elemento)
        Next
    End Sub

    Private Sub btnEnqueueLast_Click(sender As Object, e As EventArgs) Handles btnEnqueueLast.Click
        ' Agregar un elemento al final de la bicola
        Dim elemento As String = txtDeque.Text
        bicola.AddLast(elemento)

        ' Actualizar la lista de elementos en la bicola
        ActualizarListaBicola()
    End Sub

    Private Sub btnDequeueFirst_Click(sender As Object, e As EventArgs) Handles btnDequeueFirst.Click
        ' Verificar si la bicola no está vacía antes de intentar eliminar al inicio
        If bicola.Count > 0 Then
            ' Eliminar el elemento al inicio de la bicola
            Dim elementoEliminado As String = bicola.First.Value
            bicola.RemoveFirst()

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Se eliminó el elemento al inicio: {elementoEliminado}")

            ' Actualizar la lista de elementos en la bicola
            ActualizarListaBicola()
        Else
            MessageBox.Show("La bicola está vacía. No se pueden eliminar elementos al inicio.")
        End If
    End Sub

    Private Sub btnDequeueLast_Click(sender As Object, e As EventArgs) Handles btnDequeueLast.Click
        ' Verificar si la bicola no está vacía antes de intentar eliminar al final
        If bicola.Count > 0 Then
            ' Eliminar el elemento al final de la bicola
            Dim elementoEliminado As String = bicola.Last.Value
            bicola.RemoveLast()

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Se eliminó el elemento al final: {elementoEliminado}")

            ' Actualizar la lista de elementos en la bicola
            ActualizarListaBicola()
        Else
            MessageBox.Show("La bicola está vacía. No se pueden eliminar elementos al final.")
        End If
    End Sub

    Private Sub btnEnqueuePrior_Click(sender As Object, e As EventArgs) Handles btnEnqueuePrior.Click
        Dim elemento As String = txtPriorityQueue.Text
        Dim prioridad As Integer

        If Integer.TryParse(txtPriorityQueue.Text, prioridad) Then
            If Not colaPrioridad.ContainsKey(prioridad) Then
                colaPrioridad(prioridad) = New Queue(Of String)()
            End If

            colaPrioridad(prioridad).Enqueue(elemento)

            ' Actualizar la lista de elementos en la cola de prioridad
            ActualizarListaColaPrioridad()
        Else
            MessageBox.Show("Por favor, ingrese una prioridad válida (número entero).")
        End If
    End Sub
    Private Sub ActualizarListaColaPrioridad()
        ' Mostrar la cola de prioridad en el ListBox
        lstvPriorityQueue.Items.Clear()
        For Each kvp As KeyValuePair(Of Integer, Queue(Of String)) In colaPrioridad
            For Each elemento As String In kvp.Value
                lstvPriorityQueue.Items.Add($"{elemento} - Prioridad: {kvp.Key}")
            Next
        Next
    End Sub

    Private Sub btnDequeuePiror_Click(sender As Object, e As EventArgs) Handles btnDequeuePiror.Click
        ' Verificar si la cola de prioridad no está vacía antes de intentar eliminar
        If colaPrioridad.Count > 0 Then
            ' Encontrar la cola con la prioridad más baja
            Dim primeraCola = colaPrioridad.Keys.Min()
            Dim elementoEliminado = colaPrioridad(primeraCola).Dequeue()

            ' Si la cola está vacía, eliminarla de la cola de prioridad
            If colaPrioridad(primeraCola).Count = 0 Then
                colaPrioridad.Remove(primeraCola)
            End If

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Se eliminó el elemento: {elementoEliminado}")

            ' Actualizar la lista de elementos en la cola de prioridad
            ActualizarListaColaPrioridad()
        Else
            MessageBox.Show("La cola de prioridad está vacía. No se pueden eliminar elementos.")
        End If
    End Sub

    Private Sub btnAddTree_Click(sender As Object, e As EventArgs) Handles btnAddTree.Click
        Dim parentNodeName As String = txtFather.Text
        Dim newNodeName As String = txtNewNodeTree.Text
        tree.AddNode(parentNodeName, newNodeName, txtTree)
    End Sub

    Private Sub btnDeleteTree_Click(sender As Object, e As EventArgs) Handles btnDeleteTree.Click
        Dim nodeNameToDelete As String = txtFather.Text
        tree.DeleteNode(nodeNameToDelete, txtTree)
    End Sub

    Private Sub btnAddVertex_Click(sender As Object, e As EventArgs) Handles btnAddVertex.Click
        Dim vertice As String = txtVertex.Text

        ' Añadir vértice al grafo
        grafo.AgregarVertice(vertice)

        ' Actualizar la visualización del grafo
        ActualizarVisualizacionGrafo()
    End Sub
    Private Sub ActualizarVisualizacionGrafo()
        ' Crear una imagen para visualizar el grafo
        Dim imagenGrafo As New Bitmap(pictureBox1.Width, pictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(imagenGrafo)
            ' Dibujar los vértices
            For Each vertice In grafo.Vertices
                g.FillEllipse(Brushes.Blue, vertice.Valor.X, vertice.Valor.Y, 30, 30)
                g.DrawString(vertice.Nombre, DefaultFont, Brushes.White, vertice.Valor.X + 8, vertice.Valor.Y + 8)
            Next

            ' Dibujar las aristas
            For Each arista In grafo.Aristas
                g.DrawLine(Pens.Black, arista.Origen.Valor.X + 15, arista.Origen.Valor.Y + 15,
                                  arista.Destino.Valor.X + 15, arista.Destino.Valor.Y + 15)
            Next
        End Using

        ' Mostrar la imagen del grafo en el PictureBox
        pictureBox1.Image = imagenGrafo
    End Sub

    Private Sub btnAddEdge_Click(sender As Object, e As EventArgs) Handles btnAddEdge.Click
        Dim origen As String = txtOrigin.Text
        Dim destino As String = txtDestination.Text

        ' Añadir arista al grafo
        grafo.AgregarArista(origen, destino)

        ' Actualizar la visualización del grafo
        ActualizarVisualizacionGrafo()
    End Sub

    Private Sub btnBubbleRandom_Click(sender As Object, e As EventArgs) Handles btnBubbleRandom.Click
        txtBubble.Text = String.Empty
        stopwatch.Restart()
        stopwatch.Start()
        BubbleSort(array, txtBubble)
        stopwatch.Stop()
        txtBubble.Text += ("Tiempo de ejecucion del metodo BubbleSort() = " + stopwatch.Elapsed.ToString())
        ArrayReset(array)
    End Sub
    Public Shared Sub PrintArray(ByVal array As Integer(), ByVal txtBox As TextBox)
        txtBox.Text += ("[" + String.Join(", ", array) + "]" + vbCrLf)
    End Sub

    Public Shared Sub BubbleSort(ByVal array As Integer(), ByVal txtBox As TextBox)
        txtBox.Text = String.Empty
        txtBox.Text += ("Arreglo inicial: ")
        PrintArray(array, txtBox)

        For i As Integer = 0 To array.Length - 1
            For j As Integer = 0 To array.Length - i - 2
                ' Comparar los elementos adyacentes e intercambiar si el elemento actual es menor que el siguiente
                If array(j) > array(j + 1) Then
                    ' Intercambiar elementos
                    Dim temp As Integer = array(j)
                    array(j) = array(j + 1)
                    array(j + 1) = temp

                    ' Mostrar el estado actual del arreglo
                    txtBox.Text += ("Intercambio - [" + String.Join(", ", array) + "]" + vbCrLf)
                End If
            Next
        Next
        txtBox.Text += ("Arreglo ordenado: ")
        PrintArray(array, txtBox)
    End Sub
    Private Function ArrayReset(ByVal arr As Integer()) As Integer()
        arr(0) = 9
        arr(1) = 1
        arr(2) = 8
        arr(3) = 2
        arr(4) = 7
        Return arr
    End Function

    Private Sub btnBinaryTree_Click(sender As Object, e As EventArgs) Handles btnBinaryTree.Click
        txtBinaryTree.Text = String.Empty
        PrintArray(array, txtBinaryTree)
        Dim binaryTree As New BinaryTreeSort()
        stopwatch.Restart()
        stopwatch.Start()
        binaryTree.Sort(array)
        stopwatch.Stop()
        PrintArray(array, txtBinaryTree)
        txtBinaryTree.Text += "Tiempo de ejecucion del Método Binary Tree Sort = " & stopwatch.Elapsed.ToString
        ArrayReset(array)
    End Sub

    Private Sub btnBucket_Click(sender As Object, e As EventArgs) Handles btnBucket.Click
        Dim bucketSort As New BucketSort
        txtBucket.Text = String.Empty
        stopwatch.Reset()
        txtBucket.Text += ("Arreglo inicial: ")
        PrintArray(array, txtBucket)
        stopwatch.Start()
        bucketSort.BucketSort_int(array, txtBucket)
        stopwatch.Stop()
        txtBucket.Text += ("Arreglo ordenado: ")
        PrintArray(array, txtBucket)
        txtBucket.Text += ("Tiempo de ejecución del método BucketSort() = " + stopwatch.Elapsed.ToString())
        ArrayReset(array)
    End Sub

    Private Sub btnCocktail_Click(sender As Object, e As EventArgs) Handles btnCocktail.Click
        Dim cocktailSort As New CocktailSort()
        txtCocktail.Text = String.Empty
        stopwatch.Reset()
        txtCocktail.Text += "Arreglo inicial: "
        PrintArray(array, txtCocktail)
        stopwatch.Start()
        cocktailSort.CocktailSort(array)
        stopwatch.Stop()
        txtCocktail.Text += "Arreglo ordenado: "
        PrintArray(array, txtCocktail)
        txtCocktail.Text += "Tiempo de ejecucion del metodo CocktailSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnComb_Click(sender As Object, e As EventArgs) Handles btnComb.Click
        Dim combSort As New CombSort()
        txtComb.Text = String.Empty
        stopwatch.Reset()
        txtComb.Text += "Arreglo inicial: "
        PrintArray(array, txtComb)
        stopwatch.Start()
        combSort.Sort(array)
        stopwatch.Stop()
        txtComb.Text += "Arreglo ordenado: "
        PrintArray(array, txtComb)
        txtComb.Text += "Tiempo de ejecucion del metodo CombSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnCounting_Click(sender As Object, e As EventArgs) Handles btnCounting.Click
        Dim countingSort As New CountingSort()
        txtCounting.Text = String.Empty
        stopwatch.Reset()
        txtCounting.Text += "Arreglo inicial: "
        PrintArray(array, txtCounting)
        stopwatch.Start()
        countingSort.Sort(array)
        stopwatch.Stop()
        txtCounting.Text += "Arreglo ordenado: "
        PrintArray(array, txtCounting)
        txtCounting.Text += "Tiempo de ejecucion del metodo CountingSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnGnome_Click(sender As Object, e As EventArgs) Handles btnGnome.Click
        Dim gnomeSort As New GnomeSort()
        txtGnome.Text = String.Empty
        stopwatch.Reset()
        txtGnome.Text += "Arreglo inicial: "
        PrintArray(array, txtGnome)
        stopwatch.Start()
        gnomeSort.Sort(array)
        stopwatch.Stop()
        txtGnome.Text += "Arreglo ordenado: "
        PrintArray(array, txtGnome)
        txtGnome.Text += "Tiempo de ejecucion del metodo GnomeSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnHeap_Click(sender As Object, e As EventArgs) Handles btnHeap.Click
        Dim heapSort As New HeapSort()
        txtHeap.Text = String.Empty
        stopwatch.Reset()
        txtHeap.Text += "Arreglo inicial: "
        PrintArray(array, txtHeap)
        stopwatch.Start()
        heapSort.Sort(array)
        stopwatch.Stop()
        txtHeap.Text += "Arreglo ordenado: "
        PrintArray(array, txtHeap)
        txtHeap.Text += "Tiempo de ejecucion del metodo HeapSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnInsertion_Click(sender As Object, e As EventArgs) Handles btnInsertion.Click
        Dim insertionSort As New InsertionSort()
        txtInsertion.Text = String.Empty
        stopwatch.Reset()
        txtInsertion.Text += "Arreglo inicial: "
        PrintArray(array, txtInsertion)
        stopwatch.Start()
        insertionSort.InsertionSortAlgorithm(array)
        stopwatch.Stop()
        txtInsertion.Text += "Arreglo ordenado: "
        PrintArray(array, txtInsertion)
        txtInsertion.Text += "Tiempo de ejecucion del metodo InsertionSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click
        Dim mergeSort As New MergeSort()
        txtMerge.Text = String.Empty
        stopwatch.Reset()
        txtMerge.Text += "Arreglo inicial: "
        PrintArray(array, txtMerge)
        stopwatch.Start()
        mergeSort.MergeSortt(array)
        stopwatch.Stop()
        txtMerge.Text += "Arreglo ordenado: "
        PrintArray(array, txtMerge)
        txtMerge.Text += "Tiempo de ejecucion del metodo MergeSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnPigeon_Click(sender As Object, e As EventArgs) Handles btnPigeon.Click
        Dim pigeonHole As New PigeonHole()
        txtPigeon.Text = String.Empty
        stopwatch.Reset()
        txtPigeon.Text += "Arreglo inicial: "
        PrintArray(array, txtPigeon)
        stopwatch.Start()
        pigeonHole.PigeonholeSort(array)
        stopwatch.Stop()
        txtPigeon.Text += "Arreglo ordenado: "
        PrintArray(array, txtPigeon)
        txtPigeon.Text += "Tiempo de ejecucion del metodo PigeonHoleSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnQuick_Click(sender As Object, e As EventArgs) Handles btnQuick.Click
        txtQuick.Text = String.Empty
        Dim quickSort As New QuickSort()
        stopwatch.Reset()
        txtQuick.Text += "Arreglo inicial: "
        PrintArray(array, txtQuick)
        stopwatch.Start()
        quickSort.quicksort(array, 0, 4, txtQuick)
        stopwatch.Stop()
        txtQuick.Text += "Arreglo ordenado: "
        PrintArray(array, txtQuick)
        txtQuick.Text += "Tiempo de ejecucion del metodo QuickSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnRadix_Click(sender As Object, e As EventArgs) Handles btnRadix.Click
        txtRadix.Text = String.Empty
        Dim radixSort As New RadixSort()
        stopwatch.Reset()
        txtRadix.Text += "Arreglo inicial: "
        PrintArray(array, txtRadix)
        stopwatch.Start()
        radixSort.Sort(array)
        stopwatch.Stop()
        txtRadix.Text += "Arreglo ordenado: "
        PrintArray(array, txtRadix)
        txtRadix.Text += "Tiempo de ejecucion del metodo RadixSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnSelection_Click(sender As Object, e As EventArgs) Handles btnSelection.Click
        txtSelection.Text = String.Empty
        Dim selection_Sort As New SelectionSort()
        stopwatch.Reset()
        txtSelection.Text += "Arreglo inicial: "
        PrintArray(array, txtSelection)
        stopwatch.Start()
        selection_Sort.Sort(array)
        stopwatch.Stop()
        txtSelection.Text += "Arreglo ordenado: "
        PrintArray(array, txtSelection)
        txtSelection.Text += "Tiempo de ejecucion del metodo SelectionSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnShell_Click(sender As Object, e As EventArgs) Handles btnShell.Click
        txtShell.Text = String.Empty
        Dim shellSort As New ShellSort()
        stopwatch.Reset()
        txtShell.Text += "Arreglo inicial: "
        PrintArray(array, txtShell)
        stopwatch.Start()
        shellSort.ShellSortAlgorithm(array, txtShell)
        stopwatch.Stop()
        txtShell.Text += vbCrLf + "Arreglo ordenado: "
        PrintArray(array, txtShell)
        txtShell.Text += "Tiempo de ejecucion del metodo ShellSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnSmooth_Click(sender As Object, e As EventArgs) Handles btnSmooth.Click
        txtSmooth.Text = String.Empty
        Dim smoothSort As New SmoothSort()
        stopwatch.Reset()
        txtSmooth.Text += "Arreglo inicial: "
        PrintArray(array, txtSmooth)
        stopwatch.Start()
        smoothSort.Sort(array)
        stopwatch.Stop()
        txtSmooth.Text += vbCrLf + "Arreglo ordenado: "
        PrintArray(array, txtSmooth)
        txtSmooth.Text += "Tiempo de ejecucion del metodo SmoothSort() = " + stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub
End Class
