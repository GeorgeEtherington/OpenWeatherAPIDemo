using NUnit.Framework;
using WeatherGameApp;

namespace WeatherGameAppTest
{
    class GameManagerTest
    {
        [Test]
        public void TestCanLoadCityNames()
        {
            var TestManager = new GameManager();
            TestManager.CreateCityArray();
            Assert.AreEqual("London", TestManager.Cities[0].CityName);
        }

        [Test]
        public void TestCanGenerateCity()
        {
            var TestManager = new GameManager();
            TestManager.CreateCityArray();
            Assert.IsTrue(TestManager.CheckGuessIsValid(TestManager.GenerateAnswer()));
        }

        [Test]
        public void TestGuessCanBeCorrect()
        {
            var TestManager = new GameManager();
            TestManager.CorrectAnswer.SetData("London");
            TestManager.CreateCityArray();
            TestManager.Guess = "London";
            TestManager.CheckGuess();
            Assert.IsTrue(TestManager.AnswerGuessed);
        }

        [Test]
        public void TestGuessCanBeInCorrect()
        {
            var TestManager = new GameManager();
            TestManager.CorrectAnswer.SetData("London");
            TestManager.CreateCityArray();
            TestManager.Guess = "Leeds";
            TestManager.CheckGuess();
            Assert.IsFalse(TestManager.AnswerGuessed);
        }

        [Test]
        public void TestCheckGuessIsCorrect()
        {
            var TestManager = new GameManager();
            TestManager.CorrectAnswer.SetData("London");
            TestManager.Guess = "London";
            Assert.IsTrue(TestManager.CheckGuessIsCorrect());
        }

        [Test]
        public void TestCheckGuessIsIncorrect()
        {
            var TestManager = new GameManager();
            TestManager.CorrectAnswer.SetData("London");
            TestManager.Guess = "Leeds";
            Assert.IsFalse(TestManager.CheckGuessIsCorrect());
        }

        [Test]
        public void TestDoubleComparison()
        {
            var TestManager = new GameManager();
            Assert.IsTrue(TestManager.CompareDouble(10.0, 15.0));
            Assert.IsFalse(TestManager.CompareDouble(15.0, 10.0));
        }
    }
}
