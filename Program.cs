using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            treesort ts = new treesort();
            char ch;
            int c, n;
            do
            {
                Console.WriteLine("\nMuhammad Junaid 17b-012-se");
                Console.WriteLine("\nFizah Imtiaz 17b-011-se");
                Console.WriteLine("\nHiza Fatima 17b-042-se");
                Console.WriteLine("\nEnter Your Choice");
                Console.WriteLine("Enter 1 To insert the element");
                Console.WriteLine("Enter 2 To delete the element");
                Console.WriteLine("Enter 3 To get the list of the sorted element");
                Console.WriteLine("Enter 4 To get height of the tree");
                Console.WriteLine("Enter 5 To get size of the size");
                c = Convert.ToInt16(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        {
                            Console.WriteLine("enter the size of element you want to insert:");
                            int flag = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("now enter the list of elements below:");
                            for (int i = 0; i < flag; i++)
                            {
                                n = Convert.ToInt16(Console.ReadLine());
                                ts.add(n);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("enter the element you want to delete");
                            n = Convert.ToInt16(Console.ReadLine());
                            ts.delete(n);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("sorted list:");
                            ts.inorder();
                            break;
                        }
                    case 4:
                        {
                            ts.height();
                            break;
                        }
                    case 5:
                        {
                            ts.size();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("enter the correct choice");
                            break;
                        }
                }
                Console.WriteLine("Do you want to continue y or n");
                ch = Convert.ToChar(Console.ReadLine());
                Console.Clear();

            } while (ch == 'y' || ch == 'Y');
        }
        public class node
        {
            public int key;
            public node right;
            public node left;
            public node(int data)
            {
                key = data;
                left = null;
                right = null;
            }
        }
        public class treesort
        {
            node root;
            public treesort()
            {
                root = null;
            }
            public void add(int e)
            {
                root = add(root, e);
            }
            private node add(node node1, int e)
            {
                if (node1 == null)
                {
                    node1 = new node(e);
                    return node1;
                }
                if (e < node1.key)
                    node1.left = add(node1.left, e);
                else
                    node1.right = add(node1.right, e);
                return node1;
            }
            public node successor(node node1)
            {
                if (node1 == null)
                    return null;

                return minimum(node1.right);

            }
            public node predeccessor(node node1)
            {
                if (node1 == null)
                    return null;

                return maximum(node1.left);
            }
            public node minimum(node node1)
            {
                if (node1 == null)
                    return null;
                if (node1.left == null)
                    return node1;
                else
                    return minimum(node1.left);
            }

            public node maximum(node node1)
            {
                if (node1 == null)
                    return null;
                if (node1.right == null)
                    return node1;
                else
                    return maximum(node1.right);
            }
            public void delete(int e)
            {
                root = delete(root, e);
            }
            public node delete(node node1, int e)
            {
                if (node1 == null)
                    return null;
                if (node1.key == e)
                {
                    if (node1.left == null && node1.right == null)
                        return null;
                    if (node1.left == null && node1.right == null)
                        return node1.left;
                    if (node1.right != null && node1.left == null)
                        return node1.right;
                    if (node1.right != null)
                    {
                        node succ = successor(node1);
                        node1.key = succ.key;
                        node1.right = delete(node1.right, succ.key);
                    }
                    else
                    {
                        node pred = predeccessor(node1);
                        node1.key = pred.key;
                        node1.left = delete(node1.left, pred.key);
                    }
                    return node1;

                }
                if (e < node1.key)
                    node1.left = delete(node1.left, e);
                else
                    node1.right = delete(node1.right, e);
                return node1;

            }
            public void height()
            {
                int f = height(root);
                Console.WriteLine("height of tree is {0}",f);
            }
            public int height(node node1)
            {
                if (node1 == null)
                    return -1;
                int l = height(node1.left);
                int r = height(node1.right);
                if (l > r)
                    return l + 1;
                else
                    return r + 1;
            }
            private void inorder(node node1)
            {
                if (node1 == null)
                    return;
                inorder(node1.left);
                Console.WriteLine(node1.key);
                inorder(node1.right);
            }
            public void inorder()
            {
                inorder(root);
            }
            public void size()
            {
                int s = size(root);
                Console.WriteLine("size of the tree is :{0}", s);
            }
            public int size(node node1)
            {
                if (node1 == null)
                    return 0;
                return 1 + size(node1.left) + size(node1.right);

            }

        }
    }
}
