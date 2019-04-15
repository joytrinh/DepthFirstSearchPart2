using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LTDT_BTTuan04_PhanCaiDat
{
    class Program
    {
        static void Main(string[] args)
        {
            BTTuan04 bt = new BTTuan04();
            bt.RunModule();
        }
    }
    class GRAPH
    {
        public int n;
        public int[,] a;
        public bool DocDoThi(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Tap tin khong ton tai");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            n = Int32.Parse(lines[0]);
            string[] tokens = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int start = Int32.Parse(tokens[0]);
            int goal = Int32.Parse(tokens[1]);
            a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                tokens = lines[i + 2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                    a[i, j] = Int32.Parse(tokens[j]);
            }
            return true;
        }

        public void XuatDoThi()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
    class BTTuan04
    {
        private bool KiemTraDoThiVoHuong(GRAPH g)
        {
            // Y tuong: do thi vo huong phai co ma tran ke doi xung, neu ton tai 1 vi tri nao do tren ma tran khong co doi xung thi khong phai la do thi vo huong
            for (int i = 0; i < g.n; i++)
                for (int j = i + 1; j < g.n; j++)
                    if (g.a[i, j] != g.a[j, i])
                        return false;
            return true;
        }
        private void Visit(GRAPH g, int i, int label, int[] labelOfVertex)
        {
            labelOfVertex[i] = label;
            for (int j = 0; j < g.n; j++)
                if (g.a[i, j] != 0 && labelOfVertex[j] == 0)
                    Visit(g, j, label, labelOfVertex);
        }
        private void findNextPath(GRAPH g, int start, int goal, int[] labelOfVertex)
        {
            Queue<int> queue = new Queue<int>();
            for (int j = 0; j < g.n; j++)
                if (g.a[start, j] != 0 && labelOfVertex[j] == 0)
                {
                    if (j != goal)
                    {
                        queue.Enqueue(j);
                        findNextPath(g, j, goal, labelOfVertex);
                    }
                    else if(j == goal)
                    {
                        queue.Enqueue(goal);
                        break;
                    }
                }                    
        }
        private void printPath(Queue<int> queue)
        {
            Console.Write("Danh sach dinh da duyet theo thu tu: ");
            int[] array = queue.ToArray();
            int m = array.Length;
            for (int i = 0; i < m; i++)
                Console.Write(i + " ");
            Console.WriteLine();
            Console.Write("Duong di in theo kieu nguoc: ");
            for (int i = m - 1; i >= 0; i--)
                Console.Write(i + " <- ");
        }
        public void RunModule()
        {
            GRAPH g1 = new GRAPH();
            g1.DocDoThi("input_vd1.txt");
            

            GRAPH g2 = new GRAPH();
            g2.DocDoThi("input_vd2.txt");
            
            
        }
    }
}
