using Ether.Outcomes.Composer.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ether.Outcomes.Composer.Tests
{
    [TestClass]
    public class ComposerTests
    {
        [TestMethod]
        public void ComposerBasics()
        {
            var outcome = Composer.Execute<string>(StaticHelpers.Success);

            Assert.IsTrue(outcome.Success); 
        }

        [TestMethod]
        public void OnSuccessTest()
        {
            var outcome = Composer.Execute<string>(StaticHelpers.Fail)
                                  .IfFailure(StaticHelpers.Success);

            Assert.IsTrue(outcome.Success);
        }

        [TestMethod]
        public void OnFailureTest()
        {
            var result = Composer.Execute<string>(StaticHelpers.Fail)
                                 .BreakIf(outcome => outcome.Failure)
                                 .IfSuccess(outcome => Outcomes.Success<string>()); //should not fire

            Assert.IsTrue(result.Failure);
        }

        [TestMethod]
        public void IfTest()
        {
            var result = Composer.Execute<string>(StaticHelpers.Fail)
                                 .If(outcome => outcome.Failure, Outcomes.Success<string>)
                                 .IfSuccess(outcome => Outcomes.Success<string>()); //should not fire

            Assert.IsTrue(result.Success);
        }
    }
}
