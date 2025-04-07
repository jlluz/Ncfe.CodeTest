using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ncfe.CodeTest;

namespace Ncfe.CodeTestTests
{
    [TestClass]
    public class FailoverLearnerDataAccessTests
    {
        [TestMethod]
        public void GetLearnerById(int learnerId)
        {
            Assert.IsNotNull(learnerId);
            Assert.AreEqual(1, learnerId);
        }
    }
}
