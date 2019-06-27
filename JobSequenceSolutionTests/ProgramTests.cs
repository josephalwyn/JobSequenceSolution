using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JobSequenceSolution.Tests
{
    [TestClass()]
    public class ProgramTests
    {
       
        [TestMethod()]
        public void OrderSequenceTestempty()
        {
            string result = Program.OrderSequence(null);

            Assert.AreEqual("", result);
        }
        [TestMethod()]
        public void OrderSequenceTestThreeJob()
        {
            List<string> job = new List<string>();
            job.Add("a =>");
            job.Add("b =>");
            job.Add("c =>");
            string result = Program.OrderSequence(job);

            Assert.AreEqual("a,b,c", result); ;
        }
        [TestMethod()]
        public void OrderSequenceTestSixJob()
        {
            List<string> job = new List<string>();
            job.Add("a =>");
            job.Add("b => c");
            job.Add("c => f");
            job.Add("d => a");
            job.Add("e => b");
            job.Add("f =>");
            string result = Program.OrderSequence(job);

            Assert.AreEqual("a,f,d,c,b,e", result); ;
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception),
    "Error: Job can't depend on themself")]
        public void OrderSequenceTestCantSelfDependJob()
        {
            List<string> job = new List<string>();
            job.Add("a =>");
            job.Add("b =>");
            job.Add("c => c");
            string result = Program.OrderSequence(job);


        }
        [TestMethod()]
        [ExpectedException(typeof(Exception),
    "Error: Jobs can't have circular dependencies")]
        public void OrderSequenceTestCircularDependent()
        {
            List<string> job = new List<string>();
            job.Add("a =>");
            job.Add("b => c");
            job.Add("c => f");
            job.Add("d => a");
            job.Add("e =>");
            job.Add("f => b");
            string result = Program.OrderSequence(job);

            
        }
    }
}