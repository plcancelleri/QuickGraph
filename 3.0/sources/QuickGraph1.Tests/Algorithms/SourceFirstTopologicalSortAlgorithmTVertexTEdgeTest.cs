using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Collections;
using System.Collections.Generic;

namespace QuickGraph.Algorithms
{
    /// <summary>
    /// This class contains parameterized unit tests for SourceFirstTopologicalSortAlgorithm`2
    /// </summary>
    [TestClass]
    [PexClass(typeof(SourceFirstTopologicalSortAlgorithm<, >))]
    public partial class SourceFirstTopologicalSortAlgorithmTVertexTEdgeTest
    {
        [PexMethod]
        public void Compute<TVertex,TEdge>(
            [PexAssumeUnderTest]SourceFirstTopologicalSortAlgorithm<TVertex, TEdge> target,
            IList<TVertex> vertices
        )
            where TEdge : IEdge<TVertex>
        {
            target.Compute(vertices);
            // TODO: add assertions to method SourceFirstTopologicalSortAlgorithmTVertexTEdgeTest.Compute(SourceFirstTopologicalSortAlgorithm`2<!!0,!!1>, IList`1<!!0>)
        }
        
        [PexMethod]
        public SourceFirstTopologicalSortAlgorithm<TVertex, TEdge> Constructor<TVertex,TEdge>(IVertexAndEdgeListGraph<TVertex, TEdge> visitedGraph)
            where TEdge : IEdge<TVertex>
        {
            SourceFirstTopologicalSortAlgorithm<TVertex, TEdge> target
               = new SourceFirstTopologicalSortAlgorithm<TVertex, TEdge>(visitedGraph);
            return target;
            // TODO: add assertions to method SourceFirstTopologicalSortAlgorithmTVertexTEdgeTest.Constructor(IVertexAndEdgeListGraph`2<!!0,!!1>)
        }
        
        [PexMethod]
        public void HeapGet<TVertex,TEdge>(
            [PexAssumeUnderTest]SourceFirstTopologicalSortAlgorithm<TVertex, TEdge> target
        )
            where TEdge : IEdge<TVertex>
        {
            BinaryQueue<TVertex, int> result = target.Heap;
            PexStore.ValueForValidation<BinaryQueue<TVertex, int>>("result", result);
            // TODO: add assertions to method SourceFirstTopologicalSortAlgorithmTVertexTEdgeTest.HeapGet(SourceFirstTopologicalSortAlgorithm`2<!!0,!!1>)
        }
        
        [PexMethod]
        public void InDegreesGet<TVertex,TEdge>(
            [PexAssumeUnderTest]SourceFirstTopologicalSortAlgorithm<TVertex, TEdge> target
        )
            where TEdge : IEdge<TVertex>
        {
            IDictionary<TVertex, int> result = target.InDegrees;
            PexStore.ValueForValidation<IDictionary<TVertex, int>>("result", result);
            // TODO: add assertions to method SourceFirstTopologicalSortAlgorithmTVertexTEdgeTest.InDegreesGet(SourceFirstTopologicalSortAlgorithm`2<!!0,!!1>)
        }
        
        [PexMethod]
        public void SortedVerticesGet<TVertex,TEdge>(
            [PexAssumeUnderTest]SourceFirstTopologicalSortAlgorithm<TVertex, TEdge> target
        )
            where TEdge : IEdge<TVertex>
        {
            ICollection<TVertex> result = target.SortedVertices;
            PexStore.ValueForValidation<ICollection<TVertex>>("result", result);
            // TODO: add assertions to method SourceFirstTopologicalSortAlgorithmTVertexTEdgeTest.SortedVerticesGet(SourceFirstTopologicalSortAlgorithm`2<!!0,!!1>)
        }
        
    }
}
