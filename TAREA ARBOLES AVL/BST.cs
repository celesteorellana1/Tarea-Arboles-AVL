using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Esta clase representa un nodo del arbol BST
public class BSTNode
{
    public int key; // Valor del nodo
    public BSTNode left, right; // Hijos izquierdo y derecho

    public BSTNode(int item)
    {
        key = item;
        left = right = null;
    }
}

// Esta clase contiene las operaciones del arbol BST
public class BST
{
    // Inserta un nuevo nodo en el arbol
    public static BSTNode Insert(BSTNode node, int key)
    {
        if (node == null)
            return new BSTNode(key);

        if (key < node.key)
            node.left = Insert(node.left, key); // Insertar en subarbol izquierdo
        else if (key > node.key)
            node.right = Insert(node.right, key); // Insertar en subarbol derecho

        return node;
    }

    // Busca un valor en el arbol
    public static BSTNode Search(BSTNode root, int key)
    {
        if (root == null || root.key == key)
            return root; // Se encontro o esta vacio

        if (key < root.key)
            return Search(root.left, key); // Buscar en subarbol izquierdo
        else
            return Search(root.right, key); // Buscar en subarbol derecho
    }

    // Elimina un nodo del arbol
    public static BSTNode Delete(BSTNode root, int key)
    {
        if (root == null)
            return root; // Arbol vacio

        if (key < root.key)
            root.left = Delete(root.left, key); // Buscar en subarbol izquierdo
        else if (key > root.key)
            root.right = Delete(root.right, key); // Buscar en subarbol derecho
        else
        {
            // Nodo encontrado
            if (root.left == null)
                return root.right; // Solo hijo derecho
            else if (root.right == null)
                return root.left; // Solo hijo izquierdo

            // Nodo con dos hijos: obtener el sucesor
            BSTNode temp = GetSuccessor(root.right);
            root.key = temp.key;
            root.right = Delete(root.right, temp.key); // Eliminar el sucesor
        }
        return root;
    }

    // Encuentra el sucesor (nodo mas pequeño del subarbol derecho)
    private static BSTNode GetSuccessor(BSTNode node)
    {
        BSTNode current = node;
        while (current.left != null)
            current = current.left;
        return current;
    }
}