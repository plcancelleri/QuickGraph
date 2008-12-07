using System;
using System.Collections.Generic;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Collections;
using QuickGraph.Algorithms.Services;

namespace QuickGraph.Algorithms.ShortestPath
{
    /// <summary>
    /// A single-source shortest path algorithm for undirected graph
    /// with positive distance.
    /// </summary>
    /// <reference-ref
    ///     idref="lawler01combinatorial"
    ///     />
    [Serializable]
    public sealed class UndirectedDijkstraShortestPathAlgorithm<TVertex, TEdge> :
        ShortestPathAlgorithmBase<TVertex, TEdge, IUndirectedGraph<TVertex, TEdge>>,
        IVertexColorizerAlgorithm<TVertex, TEdge>,
        IVertexPredecessorRecorderAlgorithm<TVertex, TEdge>,
        IDistanceRecorderAlgorithm<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        private BinaryQueue<TVertex, double> vertexQueue;

        public UndirectedDijkstraShortestPathAlgorithm(
            IUndirectedGraph<TVertex, TEdge> visitedGraph,
            Func<TEdge, double> weights)
            : this(visitedGraph, weights, ShortestDistanceRelaxer.Instance)
        { }

        public UndirectedDijkstraShortestPathAlgorithm(
            IUndirectedGraph<TVertex, TEdge> visitedGraph,
            Func<TEdge, double> weights,
            IDistanceRelaxer distanceRelaxer
            )
            : this(null, visitedGraph, weights, distanceRelaxer)
        { }

        public UndirectedDijkstraShortestPathAlgorithm(
            IAlgorithmComponent host,
            IUndirectedGraph<TVertex, TEdge> visitedGraph,
            Func<TEdge, double> weights,
            IDistanceRelaxer distanceRelaxer
            )
            : base(host, visitedGraph, weights, distanceRelaxer)
        { }

        public event VertexEventHandler<TVertex> InitializeVertex;
        public event VertexEventHandler<TVertex> StartVertex;
        public event VertexEventHandler<TVertex> DiscoverVertex;
        public event VertexEventHandler<TVertex> ExamineVertex;
        public event EdgeEventHandler<TVertex, TEdge> ExamineEdge;
        public event VertexEventHandler<TVertex> FinishVertex;

        public event EdgeEventHandler<TVertex, TEdge> EdgeNotRelaxed;
        private void OnEdgeNotRelaxed(TEdge e)
        {
            if (EdgeNotRelaxed != null)
                EdgeNotRelaxed(this, new EdgeEventArgs<TVertex, TEdge>(e));
        }

        private void InternalTreeEdge(Object sender, EdgeEventArgs<TVertex, TEdge> args)
        {
            bool decreased = Relax(args.Edge);
            if (decreased)
                OnTreeEdge(args.Edge);
            else
                OnEdgeNotRelaxed(args.Edge);
        }

        private void InternalGrayTarget(Object sender, EdgeEventArgs<TVertex, TEdge> args)
        {
            bool decreased = Relax(args.Edge);
            if (decreased)
            {
                this.vertexQueue.Update(args.Edge.Target);
                OnTreeEdge(args.Edge);
            }
            else
            {
                OnEdgeNotRelaxed(args.Edge);
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.VertexColors.Clear();
            // init color, distance
            foreach (var u in VisitedGraph.Vertices)
                this.VertexColors.Add(u, GraphColor.White);
        }

        protected override void InternalCompute()
        {
            TVertex rootVertex;
            if (!this.TryGetRootVertex(out rootVertex))
                throw new InvalidOperationException("RootVertex not initialized");

            this.VertexColors[rootVertex] = GraphColor.Gray;
            this.Distances[rootVertex] = 0;

            ComputeNoInit(rootVertex);
        }

        public void ComputeNoInit(TVertex s)
        {
            this.vertexQueue = new BinaryQueue<TVertex, double>(this.Distances);
            UndirectedBreadthFirstSearchAlgorithm<TVertex, TEdge> bfs = null;

            try
            {
                bfs = new UndirectedBreadthFirstSearchAlgorithm<TVertex, TEdge>(
                    this,
                    this.VisitedGraph,
                    this.vertexQueue,
                    VertexColors
                    );

                bfs.InitializeVertex += this.InitializeVertex;
                bfs.DiscoverVertex += this.DiscoverVertex;
                bfs.StartVertex += this.StartVertex;
                bfs.ExamineEdge += this.ExamineEdge;
                bfs.ExamineVertex += this.ExamineVertex;
                bfs.FinishVertex += this.FinishVertex;

                bfs.TreeEdge += new EdgeEventHandler<TVertex, TEdge>(this.InternalTreeEdge);
                bfs.GrayTarget += new EdgeEventHandler<TVertex, TEdge>(this.InternalGrayTarget);

                bfs.Visit(s);
            }
            finally
            {
                if (bfs != null)
                {
                    bfs.InitializeVertex -= this.InitializeVertex;
                    bfs.DiscoverVertex -= this.DiscoverVertex;
                    bfs.StartVertex -= this.StartVertex;
                    bfs.ExamineEdge -= this.ExamineEdge;
                    bfs.ExamineVertex -= this.ExamineVertex;
                    bfs.FinishVertex -= this.FinishVertex;

                    bfs.TreeEdge -= new EdgeEventHandler<TVertex, TEdge>(this.InternalTreeEdge);
                    bfs.GrayTarget -= new EdgeEventHandler<TVertex, TEdge>(this.InternalGrayTarget);
                }
            }
        }
    }
}
