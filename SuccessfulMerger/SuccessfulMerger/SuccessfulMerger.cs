using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessfulMerger
{
    public class SuccessfulMerger
    {
        public int minimumMergers(int[] road)
        {
            
            var graph = new Dictionary<int, List<int>>();
            int size = road.Length;
           
            for (int x = 0; x < size; x++)
            {
                graph.Add(x, new List<int>());
            }

            for (int x = 0; x < size; x++)
            {
                graph[x].Add(road[x]);
                graph[road[x]].Add(x);
            }
            int centralPoint = 0;
            int mergeCount = 0;
            //What do we need to fix
            bool done = true;
            do
            {
                centralPoint = determineMidPoint(graph);
                done = true;
                foreach (int x in graph.Keys)
                {
                    if (!(x == centralPoint || graph[x].Contains(centralPoint)) &&  graph[x].Count != 0)
                    {
                        done = false;
                        var q = new Queue<int>();
                        q.Enqueue(x);
                        while(q.Count>0)
                        {
                            var currNode = q.Dequeue();
                            if(graph[currNode].Contains(centralPoint))
                            {
                                //merge the two
                                mergeCount++;
                                graph[centralPoint].AddRange(graph[currNode]);
                                foreach (var place in graph.Values)
                                {
                                    if(place.Contains(currNode))
                                    {
                                        place.Add(centralPoint);
                                        place.RemoveAll(i => i == currNode);
                                    }
                                } 
                                graph[currNode].RemoveAll(i=>1==1);
                                break;
                            }
                            else
                            {
                                foreach(var link in graph[currNode]) q.Enqueue(link);
                            }
                        }
                        done = false;
                    }
                }
            }
            while (!done);
            int newcount = 0;
            //deal with short circuits
            foreach (int x in graph.Keys)
            {
                
                if(x!=centralPoint && graph[x].Any(i => i!=centralPoint))
                {
                    newcount++;
                }
            }

                return mergeCount + (newcount/2);
        }
        int determineMidPoint(Dictionary<int,List<int>> graph)
        {
            int maxCount=0;
            int maxKey=0;
            foreach(var key in graph.Keys)
            {
                if (graph[key].Count > maxCount)
                {
                    maxCount = graph[key].Count;
                    maxKey = key;
                }
            }
            return maxKey;
        }
        
    }
   
}
