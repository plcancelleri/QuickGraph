﻿using System;
using System.Collections.Generic;

using QuickGraph.Algorithms.Search;
using System.Diagnostics.Contracts;

namespace QuickGraph.Algorithms
{
    [Serializable]
    public sealed class UndirectedTopologicalSortAlgorithm<TVertex, TEdge>
        : AlgorithmBase<IUndirectedGraph<TVertex, TEdge>>
        where TEdge : IEdge<TVertex>
    {
        private IList<TVertex> vertices;
        private bool allowCyclicGraph = false;

        public UndirectedTopologicalSortAlgorithm(IUndirectedGraph<TVertex, TEdge> g)
            : this(g, new List<TVertex>())
        { }

        public UndirectedTopologicalSortAlgorithm(
            IUndirectedGraph<TVertex, TEdge> g,
            IList<TVertex> vertices)
            : base(g)
        {
            Contract.Requires(vertices != null);

            this.vertices = vertices;
        }

        public IList<TVertex> SortedVertices
        {
            get
            {
                return vertices;
            }
        }

        public bool AllowCyclicGraph
        {
            get { return this.allowCyclicGraph; }
            set { this.allowCyclicGraph = value; }
        }

        private void BackEdge(Object sender, TEdge args)
        {
            if (!this.AllowCyclicGraph)
                throw new NonAcyclicGraphException();
        }

        private void FinishVertex(Object sender, TVertex v)
        {
            vertices.Insert(0, v);
        }

        protected override void InternalCompute()
        {
            UndirectedDepthFirstSearchAlgorithm<TVertex, TEdge> dfs = null;
            try
            {
                dfs = new UndirectedDepthFirstSearchAlgorithm<TVertex, TEdge>(
                    this,
                    VisitedGraph,
                    new Dictionary<TVertex, GraphColor>(this.VisitedGraph.VertexCount)
                    );
                dfs.BackEdge += new EdgeAction<TVertex, TEdge>(this.BackEdge);
                dfs.FinishVertex += new VertexAction<TVertex>(this.FinishVertex);

                dfs.Compute();
            }
            finally
            {
                if (dfs != null)
                {
                    dfs.BackEdge -= new EdgeAction<TVertex, TEdge>(this.BackEdge);
                    dfs.FinishVertex -= new VertexAction<TVertex>(this.FinishVertex);
                }
            }
        }

        public void Compute(IList<TVertex> vertices)
        {
            this.vertices = vertices;
            this.vertices.Clear();
            this.Compute();
        }
    }
}
