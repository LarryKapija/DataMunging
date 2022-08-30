using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace DataMungingTest
{
    [TestFixture]
    public abstract class TestsBase
    {
        [SetUp]
        protected virtual void SetUp()
        {
            /*By default, the tests work in a chain.
            That is, if one fails, the others will be ignored.

            To avoid this behavior, overwrite these functions 
            (SetUp and TearDown) ignoring their base implementation.*/

            if (stopTesting)
            {
                Assert.Ignore("Previous test failed");
            }
        }

        [TearDown]
        protected virtual void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                stopTesting = true;
            }
        }
        private bool stopTesting;
    }
}