using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ComputeSuger
{
    public class ComputeToolTest
    {
        private ComputeTool computeTool;

        [SetUp]
        public void Inite()
        {
            computeTool = new ComputeTool();
        }

        [Test]
        public void FullDigital()
        {
            //ComputeTool computeTool = new ComputeTool();
            bool result = computeTool.judgeDigital("123456");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ContainCharacter()
        {
            bool result = computeTool.judgeDigital("12a456");
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ContainPoint()
        {
            bool result = computeTool.judgeDigital("1.2");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PointBegin()
        {
            bool result = computeTool.judgeDigital(".2");
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PointEnd()
        {
            bool result = computeTool.judgeDigital("1.");
            Assert.AreEqual(false, result);
        }

        [Test]
        public void SingleDigital()
        {
            bool result = computeTool.judgeDigital("1");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Empty()
        {
            bool result = computeTool.judgeDigital("");
            Assert.AreEqual(false, result);
        }
    }
}
