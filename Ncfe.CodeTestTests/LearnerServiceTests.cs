using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ncfe.CodeTest;

namespace Ncfe.CodeTestTests
{
    [TestClass]
    public class LearnerServiceTests
    {
        [TestMethod]
        public void GetLearnerTest(int learnerId, bool isLearnerArchived)
        {
            Learner learner = new Learner();
            Assert.IsNotNull(learner);
        }
    }
}
