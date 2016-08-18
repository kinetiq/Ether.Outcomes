using Ether.Outcomes.Composer.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ether.Outcomes.Composer.Tests
{
    [TestClass]
    public class ComposerTests
    {
        [TestMethod]
        public void ExecuteGenericString()
        {
            var outcome = Composer.Execute(StaticHelpers.Success);

            Assert.IsTrue(outcome.Success); 
        }

        [TestMethod]
        public void ExecuteNonGenericObject()
        {
            var outcome = Composer.Execute(StaticHelpers.NonGenericFailObj);

            Assert.IsTrue(outcome.Failure);
        }

        [TestMethod]
        public void EecuteNonGenericConstructor()
        {
            var outcome = Composer.Execute(StaticHelpers.NonGenericFail);

            Assert.IsTrue(outcome.Failure);
        }

        [TestMethod]
        public void ExecuteNonGenericWithParam()
        {
            //For this, you have to use a lambda.
            var outcome = Composer.Execute(() => StaticHelpers.NonGenericFailWithParam(0));

            Assert.IsTrue(outcome.Failure);
        }

        [TestMethod]
        public void ExecuteGenericWithParam()
        {
            //For this, you have to use a lambda.
            var outcome = Composer.Execute(() => StaticHelpers.GenericFailWithParam(0));

            Assert.IsTrue(outcome.Failure);
        }

        [TestMethod]
        public void OnSuccessTest()
        {
            var outcome = Composer.Execute(StaticHelpers.Fail)
                                  .IfFailure(StaticHelpers.Success);

            Assert.IsTrue(outcome.Success);
        }

        [TestMethod]
        public void OnFailureTest()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .BreakIf(outcome => outcome.Failure)
                                 .IfSuccess(outcome => Outcomes.Success<string>()); //should not fire

            Assert.IsTrue(result.Failure);
        }

        [TestMethod]
        public void IfTest()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .If(outcome => outcome.Failure, Outcomes.Success<string>)
                                 .IfSuccess(outcome => Outcomes.Success<string>()); //should not fire

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ElseTest1()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .If(outcome => outcome.Success, Outcomes.Success<string>) //should not fire
                                 .Else(outcome => Outcomes.Failure<string>());             //should fire

            Assert.IsTrue(result.Failure);
        }

        [TestMethod]
        public void ElseTest2()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .If(outcome => outcome.Success, Outcomes.Success<string>) //should not fire
                                 .Else(Outcomes.Failure<string>)                           //should fire
                                 .Else(Outcomes.Success<string>);                          //should not fire
                                    
            Assert.IsTrue(result.Failure);
        }

        [TestMethod]
        public void ElseTest3()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .If(outcome => outcome.Success, Outcomes.Success<string>) //should not fire
                                 .Else(Outcomes.Failure<string>)                           //should fire
                                 .Else(Outcomes.Success<string>)                           //should not fire
                                 .Else(Outcomes.Success<string>);                          //should fire

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ElseTest4()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .IfSuccess(Outcomes.Success<string>)              //should not fire
                                 .Else(outcome => Outcomes.Failure<string>());     //should fire

            Assert.IsTrue(result.Failure);
        }

        [TestMethod]
        public void ElseTest5()
        {
            var result = Composer.Execute(StaticHelpers.Success)
                                 .IfSuccess(Outcomes.Success<string>)              //should fire 
                                 .Else(outcome => Outcomes.Failure<string>());     //should not fire

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ElseTest6()
        {
            var result = Composer.Execute(StaticHelpers.Success)
                                 .IfFailure(Outcomes.Success<string>)              //should not fire
                                 .Else(Outcomes.Failure<string>);                  //should fire

            Assert.IsTrue(result.Failure);
        }

        [TestMethod]
        public void ElseTest7()
        {
            var result = Composer.Execute(StaticHelpers.Fail)
                                 .IfFailure(Outcomes.Failure<string>)              //should fire
                                 .Else(Outcomes.Success<string>);                  //should not fire

            Assert.IsTrue(result.Failure);
        }
    }
}
