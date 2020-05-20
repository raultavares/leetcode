using System.Collections.Generic;

namespace GeneralPurpose
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a dummy tree
            TreeNode t = new TreeNode(3);
            t.left = new TreeNode(9);
            t.right = new TreeNode(20);
            t.right.left = new TreeNode(15);
            t.right.right = new TreeNode(7);

            // call the function
            System.Console.WriteLine(MaxDepth(t));

        }

        static public int MaxDepth(TreeNode root)
        {
            // check if tree is null
            if (root == null)
            {
                return 0;
            }

            // check if there is only one node, the root, hence level = 1
            if (root.left == null && root.right == null)
                return 1;

            // initialize the queue with tuple to hold (TREENODE, DEPTH)
            Queue<(TreeNode,int)> q = new Queue<(TreeNode,int)>();

            // starting depth is one
            int depth = 1;

            // enqueue the root node and depth = 1
            q.Enqueue((root, depth));

            // use queue to traverse the tree
            while (q.Count > 0)
            {
                // dequeue the front element
                (TreeNode,int) current = q.Dequeue();

                // I assume the final depth is the current node
                depth = current.Item2;

                // enqueue left node if exists, incrementing the depth in 1
                if (current.Item1.left != null)
                    q.Enqueue((current.Item1.left,depth + 1));

                //enqueue right node if exists, incrementing the depth in 1
                if (current.Item1.right != null)
                    q.Enqueue((current.Item1.right, depth + 1));

            }

            // after all nodes are visited, the last node's depth will be the answer
            return depth;

        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
