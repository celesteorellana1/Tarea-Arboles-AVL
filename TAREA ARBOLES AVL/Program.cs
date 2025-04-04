using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Definimos la cantidad de datos a procesar
        int n = 10000;
        Random rand = new Random();
        int[] datos = new int[n];

        for (int i = 0; i < n; i++)
            datos[i] = rand.Next(1, 100000);

        //BST
        // Inicializamos la raiz del arbol BST
        BSTNode bstRoot = null;

        // Medimos el tiempo de insercion en el arbol BST
        Stopwatch sw = Stopwatch.StartNew();
        foreach (int d in datos)
            bstRoot = BST.Insert(bstRoot, d); 
        sw.Stop();
        Console.WriteLine($"BST - Insercion: {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de busqueda del primer valor (inicio) en el arbol BST
        sw.Restart();
        BST.Search(bstRoot, datos[0]);
        sw.Stop();
        Console.WriteLine($"BST - Busqueda (inicio): {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de busqueda del valor medio en el arbol BST
        sw.Restart();
        BST.Search(bstRoot, datos[n / 2]);
        sw.Stop();
        Console.WriteLine($"BST - Busqueda (medio): {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de busqueda del ultimo valor (final) en el arbol BST
        sw.Restart();
        BST.Search(bstRoot, datos[n - 1]);
        sw.Stop();
        Console.WriteLine($"BST - Busqueda (final): {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de eliminacion de un valor en el arbol BST (valor medio)
        sw.Restart();
        bstRoot = BST.Delete(bstRoot, datos[n / 2]); // Eliminamos el valor medio del arbol
        sw.Stop();
        Console.WriteLine($"BST - Eliminacion: {sw.Elapsed.TotalMilliseconds} ms\n");

        //AVL
        // Inicializamos la raiz del arbol AVL
        AVLNode avlRoot = null;

        // Medimos el tiempo de insercion en el arbol AVL
        sw.Restart();
        foreach (int d in datos)
            avlRoot = AVLTree.Insert(avlRoot, d); 
        sw.Stop();
        Console.WriteLine($"AVL - Insercion: {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de busqueda del primer valor (inicio) en el arbol AVL
        sw.Restart();
        AVLTree.Search(avlRoot, datos[0]);
        sw.Stop();
        Console.WriteLine($"AVL - Busqueda (inicio): {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de busqueda del valor medio en el arbol AVL
        sw.Restart();
        AVLTree.Search(avlRoot, datos[n / 2]);
        sw.Stop();
        Console.WriteLine($"AVL - Busqueda (medio): {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de busqueda del ultimo valor (final) en el arbol AVL
        sw.Restart();
        AVLTree.Search(avlRoot, datos[n - 1]);
        sw.Stop();
        Console.WriteLine($"AVL - Busqueda (final): {sw.Elapsed.TotalMilliseconds} ms");

        // Medimos el tiempo de eliminacion de un valor en el arbol AVL (valor medio)
        sw.Restart();
        avlRoot = AVLTree.Delete(avlRoot, datos[n / 2]); // Eliminamos el valor medio del arbol
        sw.Stop();
        Console.WriteLine($"AVL - Eliminacion: {sw.Elapsed.TotalMilliseconds} ms");
    }
}
