using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Esta clase representa un nodo del Arbol AVL
public class AVLNode
{
    public int key, height; // Valor del nodo y altura
    public AVLNode left, right; // Punteros a los hijos izquierdo y derecho

    public AVLNode(int item)
    {
        key = item;
        height = 1; //La altura del nodo es 1
    }
}

// Clase que maneja las operaciones del Arbol AVL
public class AVLTree
{
    // Devuelve la altura de un nodo (0 si el nodo es nulo)
    private static int Height(AVLNode n) => n?.height ?? 0;

    // Devuelve el factor de balance de un nodo
    private static int GetBalance(AVLNode n) => n == null ? 0 : Height(n.left) - Height(n.right);

    // Realiza una rotacion a la derecha en el subarbol
    private static AVLNode RightRotate(AVLNode y)
    {
        AVLNode x = y.left;
        AVLNode T2 = x.right;

        // Realiza la rotacion
        x.right = y;
        y.left = T2;

        // Actualiza las alturas
        y.height = Math.Max(Height(y.left), Height(y.right)) + 1;
        x.height = Math.Max(Height(x.left), Height(x.right)) + 1;

        // Devuelve la nueva raiz
        return x;
    }

    // Realiza una rotacion a la izquierda en el subarbol
    private static AVLNode LeftRotate(AVLNode x)
    {
        AVLNode y = x.right;
        AVLNode T2 = y.left;

        // Realiza la rotacion
        y.left = x;
        x.right = T2;

        // Actualiza las alturas
        x.height = Math.Max(Height(x.left), Height(x.right)) + 1;
        y.height = Math.Max(Height(y.left), Height(y.right)) + 1;

        // Devuelve la nueva raiz
        return y;
    }

    // Inserta un nuevo nodo en el arbol AVL
    public static AVLNode Insert(AVLNode node, int key)
    {
        if (node == null)
            return new AVLNode(key);

        if (key < node.key)
            node.left = Insert(node.left, key); // Insertar en el subarbol izquierdo
        else if (key > node.key)
            node.right = Insert(node.right, key); // Insertar en el subarbol derecho
        else
            return node; // No se permiten nodos duplicados

        // Actualiza la altura del nodo
        node.height = 1 + Math.Max(Height(node.left), Height(node.right));

        // Calcula el factor de balance
        int balance = GetBalance(node);

        // Rotacion simple a la derecha
        if (balance > 1 && key < node.left.key)
            return RightRotate(node);

        // Rotacion simple a la izquierda
        if (balance < -1 && key > node.right.key)
            return LeftRotate(node);

        // Rotacion doble a la izquierda - derecha
        if (balance > 1 && key > node.left.key)
        {
            node.left = LeftRotate(node.left); // Rotacion izquierda
            return RightRotate(node); // Rotacion derecha
        }

        // Rotacion doble a la derecha - izquierda
        if (balance < -1 && key < node.right.key)
        {
            node.right = RightRotate(node.right); // Rotacion derecha
            return LeftRotate(node); // Rotacion izquierda
        }

        return node;
    }

    // Busca un nodo con la clave especificada
    public static AVLNode Search(AVLNode root, int key)
    {
        if (root == null || root.key == key)
            return root; 

        if (key < root.key)
            return Search(root.left, key); // Buscar en el subarbol izquierdo
        else
            return Search(root.right, key); // Buscar en el subarbol derecho
    }

    // Elimina un nodo con la clave especificada
    public static AVLNode Delete(AVLNode root, int key)
    {
        if (root == null)
            return root; // El arbol esta vacio

        // Realiza la busqueda del nodo a eliminar
        if (key < root.key)
            root.left = Delete(root.left, key); // Eliminar del subarbol izquierdo
        else if (key > root.key)
            root.right = Delete(root.right, key); // Eliminar del subarbol derecho
        else
        {
            // Nodo a eliminar encontrado
            if (root.left == null)
                return root.right; // Solo tiene hijo derecho
            else if (root.right == null)
                return root.left; // Solo tiene hijo izquierdo

            // Nodo con dos hijos: encontrar el sucesor
            AVLNode temp = MinValueNode(root.right);
            root.key = temp.key;
            root.right = Delete(root.right, temp.key); // Eliminar el sucesor
        }

        // Actualiza la altura del nodo
        root.height = 1 + Math.Max(Height(root.left), Height(root.right));

        int balance = GetBalance(root);

        if (balance > 1 && GetBalance(root.left) >= 0)
            return RightRotate(root);

        // Rotacion doble a la izquierda - derecha
        if (balance > 1 && GetBalance(root.left) < 0)
        {
            root.left = LeftRotate(root.left);
            return RightRotate(root);
        }

        // Rotacióon simple a la izquierda
        if (balance < -1 && GetBalance(root.right) <= 0)
            return LeftRotate(root);

        // Rotacion doble a la derecha - izquierda
        if (balance < -1 && GetBalance(root.right) > 0)
        {
            root.right = RightRotate(root.right);
            return LeftRotate(root);
        }

        return root;
    }

    // Encuentra el nodo con el valor minimo en el subarbol derecho
    private static AVLNode MinValueNode(AVLNode node)
    {
        AVLNode current = node;
        while (current.left != null)
            current = current.left;
        return current;
    }
}

