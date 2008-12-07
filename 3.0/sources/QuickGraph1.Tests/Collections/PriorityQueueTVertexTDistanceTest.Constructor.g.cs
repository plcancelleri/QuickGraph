// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace QuickGraph.Collections
{
    public partial class PriorityQueueTVertexTDistanceTest
    {

        [TestMethod]
        [PexRaisedException(typeof(ArgumentNullException))]
        [PexGeneratedBy(typeof(PriorityQueueTVertexTDistanceTest))]
        public void Constructor02()
        {
            BinaryQueue<int, int> priorityQueue;
            priorityQueue = this.Constructor<int, int>((IDictionary<int, int>)null);
        }

        [TestMethod]
        [Ignore]
        [Description("the test state was: duplicate path")]
        public void Constructor03()
        {
            BinaryQueue<int, int> priorityQueue;
            priorityQueue = this.Constructor<int, int>((IDictionary<int, int>)null);
        }

        [TestMethod]
        [Ignore]
        [Description("the test state was: duplicate path")]
        public void Constructor05()
        {
            BinaryQueue<int, int> priorityQueue;
            priorityQueue = this.Constructor<int, int>((IDictionary<int, int>)null);
        }

        [TestMethod]
        [Ignore]
        [Description("the test state was: duplicate path")]
        public void Constructor06()
        {
            BinaryQueue<int, int> priorityQueue;
            priorityQueue = this.Constructor<int, int>((IDictionary<int, int>)null);
        }

    }
}
