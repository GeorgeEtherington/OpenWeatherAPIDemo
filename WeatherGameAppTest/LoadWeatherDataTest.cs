using WeatherGameApp;
using NUnit.Framework;

namespace WeatherGameAppTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        public void TestCanLoadCityNames()
        {
            var TestLondon = new City();
            var TestLeeds = new City();

            TestLondon.SetData("London");
            TestLeeds.SetData("Leeds");
            Assert.AreEqual(TestLondon.CityData.name, "London");
            Assert.AreEqual(TestLeeds.CityData.name, "Leeds");
        }

        [Test]
        public void TestCanLoadCityCoords()
        {
            var TestLondon = new City();
            var TestLeeds = new City();

            TestLondon.SetData("London");
            TestLeeds.SetData("Leeds");
            Assert.AreEqual(TestLondon.CityData.coord.lon, -0.1257);
            Assert.AreEqual(TestLondon.CityData.coord.lat, 51.5085);

            Assert.AreEqual(TestLeeds.CityData.coord.lon, -1.5477);
            Assert.AreEqual(TestLeeds.CityData.coord.lat, 53.7964);
        }
    }
}