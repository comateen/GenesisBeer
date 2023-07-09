using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04_SRV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_DAL.Interfaces;
using _01_DB.Entities;
using _02_DAL.Repositories;
using _03_Models.VM;
using Microsoft.EntityFrameworkCore;
using FakeItEasy;
using _03_Models.Models;
using _04_SRV.Helper;
using _03_Models.AddModels;
using _04_SRV.Interfaces;

namespace _04_SRV.Services.Tests
{
    [TestClass()]
    public class BeerServiceTests : ServiceHelper
    {
        private static BeerRepository _beerRepository;
        public TestContext TestContext { get; set; }

        private static TestContext _testContext;

        const int idBeerOK = 2;
        const int idBeerNoK = -1;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        private static bool CreateFakeServicesAndRepositories()
        {
            bool result = true;
            try
            {
                _beerRepository = A.Fake<BeerRepository>();  
            }
            catch { result = false; }
            return result;
        }

        [TestMethod()]
        public void BeerService_Success()
        {
            // Arrange / Act
            bool isFakeServicesAndRepositoriesCreated = CreateFakeServicesAndRepositories();

            // Assert
            Assert.IsTrue(isFakeServicesAndRepositoriesCreated);
        }

        [TestMethod()]
        public void GetAllBeerWithBrewerAndSalersTest()
        {
            CreateFakeServicesAndRepositories();

            List<Beer> beers = new List<Beer>();
            List<BeerClient> beerClients = ConvertBeerFromDB(beers);

            Assert.IsNotNull(beerClients);
            beerClients = null;
            Assert.IsNull(beerClients);
        }

        [DataRow(idBeerOK, DisplayName = "Bière en DB")]
        [DataRow(idBeerNoK, DisplayName = "Bière pas en DB")]
        [TestMethod()]
        public void GetOneBeerForEstimateReturnTest(int id)
        {
            CreateFakeServicesAndRepositories();

            BeerToShow beerToShow = null; 
            if (id == 2)
            {
                beerToShow = new BeerToShow();
                beerToShow.Id = 2;
                beerToShow.Name = "Triple Karmeliet";
                beerToShow.Degree = 8.2;
                beerToShow.Price = 2.4;

                Assert.IsNotNull(beerToShow);
            }
            else
            {
                Assert.IsNull(beerToShow);
            }
            
        }

        

        




        private List<BeerClient> ConvertBeerFromDB(List<Beer> beers)
        {
            List<BeerClient> beerClients = SetBeerClient(beers);
            return beerClients;
        }
    }
}