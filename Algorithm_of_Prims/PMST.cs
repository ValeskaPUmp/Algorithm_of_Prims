using System;
using System.Threading;

namespace Algorithm_of_Prims
{
    public unsafe class PMST
    {
        private int[,] graph;
        private int vertical;
        private int time;
        public PMST(int[,] graph,int vertical)
        {
            this.graph = graph;
            this.vertical = vertical;
            
        }

        public void launch()
        {
            time = DateTime.Now.Millisecond;
            int* keys = stackalloc int[vertical];
            bool* visited = stackalloc bool[vertical];
            int* parent = stackalloc int[vertical];
            bool* y = visited;
            int* m = keys;
            for(int i=0;i<=vertical;++i,++y,++m)
            {
                *y = false;
                *m = int.MaxValue;
            }
            *keys = 0;
            *parent = -1;
            for (int u = 0; u < vertical - 1; ++u)
            {
                int o = minkey(keys, visited);
                *(visited + o) = true;
                for (int v = 0; v < vertical; ++v)
                {
                    if (graph[o, v] != 0 && *(visited + v) == false && graph[o, v] < *(keys + v))
                    {
                        *(parent + v) = o;
                        *(keys + v) = graph[o, v];
                    }
                }
            }
            print(parent,graph);
        }

        private int minkey(int* keys, bool* visited)
        {
            int min = int.MaxValue; 
            int minIndex = -1;
            for (int i = 0; i < vertical; ++i)
            {
                if (*(visited + i) == false && *(keys + i) < min)
                {
                    min = *(keys + i);
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private void print(int* parent, int[,] graph)
        {
            for (int i = 1; i < vertical; ++i)
            {
                Console.WriteLine(*(parent+i)+"--"+i+"--"+graph[i,*(parent+i)]);
            }
            Console.WriteLine("Object has been delete"+$"\n{DateTime.Now.Millisecond-time}");
            Environment.Exit(1);


        }
        
        
    }
}