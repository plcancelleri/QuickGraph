using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGraph.Collections;
using System;
using System.Collections.Generic;

namespace QuickGraph.Collections
{
    /// <summary>
    /// This class contains parameterized unit tests for PriorityQueue`2
    /// </summary>
    [TestClass]
    [PexClass(typeof(BinaryQueue<, >))]
    public partial class PriorityQueueTVertexTDistanceTest
    {
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public BinaryQueue<TVertex, TDistance> Constructor<TVertex,TDistance>(IDictionary<TVertex, TDistance> distances)
        {
            BinaryQueue<TVertex, TDistance> target
               = new BinaryQueue<TVertex, TDistance>(distances);
            return target;
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.Constructor(IDictionary`2<!!0,!!1>)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public bool Contains<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target, TVertex value)
        {
            bool result = target.Contains(value);
            return result;
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.Contains(PriorityQueue`2<!!0,!!1>, !!0)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public void CountGet<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target)
        {
            int result = target.Count;
            PexStore.ValueForValidation<int>("result", result);
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.CountGet(PriorityQueue`2<!!0,!!1>)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public void Dequeue<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target)
        {
            TVertex result = target.Dequeue();
            PexStore.ValueForValidation<TVertex>("result", result);
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.Dequeue(PriorityQueue`2<!!0,!!1>)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public void Enqueue<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target, TVertex value)
        {
            target.Enqueue(value);
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.Enqueue(PriorityQueue`2<!!0,!!1>, !!0)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public void Peek<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target)
        {
            TVertex result = target.Peek();
            PexStore.ValueForValidation<TVertex>("result", result);
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.Peek(PriorityQueue`2<!!0,!!1>)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public void ToArray<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target)
        {
            TVertex[] result = target.ToArray();
            PexStore.ValueForValidation<TVertex[]>("result", result);
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.ToArray(PriorityQueue`2<!!0,!!1>)
        }
        
        [PexMethod]
        [PexGenericArguments(new Type[]{typeof(int), typeof(int)})]
        public void Update<TVertex,TDistance>([PexAssumeUnderTest]BinaryQueue<TVertex, TDistance> target, TVertex v)
        {
            target.Update(v);
            // TODO: add assertions to method PriorityQueueTVertexTDistanceTest.Update(PriorityQueue`2<!!0,!!1>, !!0)
        }
        
    }
}
