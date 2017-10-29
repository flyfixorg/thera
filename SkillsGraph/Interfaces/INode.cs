using System.Collections.Generic;
using Skills.Entities;

namespace Skills.Interfaces
{

    public interface INode<T>
    {
        /// <summary>
        /// Store data for node
        /// </summary>
        T Data { get; }

        /// <summary>
        /// Collection of node parents
        /// </summary>
        ICollection<GraphNode<T>> Parents { get; }

        /// <summary>
        /// Add childs to node
        /// </summary>
        /// <param name="childs"></param>
        void AddChild(params GraphNode<T>[] childs);
    }
}