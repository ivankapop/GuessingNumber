using GuessNumber;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace GameBoxMSTest
{
    [TestClass]
    public class GameTest
    {
        private GameBox _gameBox;
        bool? actualBool;

        [TestInitialize]
        public void TestInitialize()
        {
            _gameBox = new GameBox(new ConsoleGameView())
            {
                NumberToBeGuessed = 19
            };
        }

        [TestMethod]
        public void Test_Processing_Valid_Number()
        {
            //arrange
            var initMethod = GetMethod("TryProccessNumber");
            bool expected = true;

            //act
            actualBool = initMethod.Invoke(_gameBox, new object[] { 19 }) as bool?;

            //assert
            Assert.AreEqual(expected, actualBool, "Return value is not correct");
        }

        [TestMethod]
        public void Test_Processing_Invalid_Number()
        {
            //arrange
            var initMethod = GetMethod("TryProccessNumber");
            bool expected = false;

            //act
            actualBool = initMethod.Invoke(_gameBox, new object[] { 53 }) as bool?;

            //assert
            Assert.AreEqual(expected, actualBool, "Return value is not correct");
        }

        [TestMethod]
        public void Test_Plaiyng_Again_Game()
        {
            //arrange
            var initMethod = GetMethod("PlayAgain");
            bool expected = true;

            //act
            actualBool = initMethod.Invoke(_gameBox, new object[] { "yes" }) as bool?;

            //assert
            Assert.AreEqual(expected, actualBool, "Return value is not correct");
        }

        [TestMethod]
        public void Test_Stop_Game()
        {
            //arrange

            var initMethod = GetMethod("PlayAgain");
            bool expected = false;
            bool? actual;

            //act
            actual = initMethod.Invoke(_gameBox, new object[] { "NO" }) as bool?;

            //assert
            Assert.AreEqual(expected, actual, "Return value is not correct");
        }


        private MethodInfo GetMethod(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("methodName cannot be null or whitespace");

            var method = _gameBox.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }
    }
}
