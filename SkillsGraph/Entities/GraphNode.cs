using System.Collections.Generic;
using Skills.Interfaces;

namespace Skills.Entities
{
    public class GraphNode<T> : INode<T>
    {

        public T Data { get; }
        public ICollection<GraphNode<T>> Parents { get; }


        public GraphNode(T data)
        {
            Data = data;
            Parents = new List<GraphNode<T>>();
        }


        public void AddChild(params GraphNode<T>[] childs)
        {
            foreach (var c in childs)
            {
                c.Parents.Add(this);
            }
        }
    }
}