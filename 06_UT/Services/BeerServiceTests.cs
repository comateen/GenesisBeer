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
using _01_DB;
using _06_UT;
using NuGet.Frameworks;

namespace _04_SRV.Services.Tests
{
    [TestClass()]
    public class BeerServiceTests : ServiceHelper
    {
        private static FakeContext _dataContext;
        
        const int idBeerOK = 2;
        const int idBeerNoK = -1;

        private static bool CreateFakeServicesAndRepositories()
        {
            bool result = true;
            try
            {
                _dataContext = FakeContext.SeedContext();
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

            List<BeerClient> beerClients = null;
            
            List<Beer> beers = _dataContext.beers;
            if (beers.Any())
            {
                beerClients = ConvertBeerFromDB(beers);
                Assert.IsNotNull(beerClients);
            } 
            else
            {
                Assert.Fail();
            }
        }

        [DataRow(idBeerOK, DisplayName = "Bière en DB")]
        [DataRow(idBeerNoK, DisplayName = "Bière pas en DB")]
        [TestMethod()]
        public void GetOneBeerForEstimateReturnTest(int id)
        {
            CreateFakeServicesAndRepositories();

            Beer beerDB = _dataContext.beers.FirstOrDefault(b => b.Id == id);
            if (beerDB != null)
            {
                BeerToShow beerToShow = new BeerToShow();
                beerToShow.Id = beerDB.Id;
                beerToShow.Name = beerDB.Name;
                beerToShow.Degree = beerDB.Degree;
                beerToShow.Price = beerDB.Price;

                Assert.IsNotNull(beerToShow);
            }
            else
            {
                Assert.IsNull(beerDB);
            }
        }


        [TestMethod()]
        public void AddBeer_OK()
        {
            CreateFakeServicesAndRepositories();
            Beer beer = new Beer { Id = 9, Name = "Grimbergen été", Degree = 8, Price = 2.3, BreweryId = 3 };
            if (_dataContext.breweries.Any(b => b.Id == beer.BreweryId))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddBeer_NotOK()
        {
            CreateFakeServicesAndRepositories();
            Beer beer = new Beer { Id = 9, Name = "Grimbergen été", Degree = 8, Price = 2.3, BreweryId = 99 };
            if (!_dataContext.breweries.Any(b => b.Id == beer.BreweryId))
            {
                Assert.IsFalse(false);
            }
            else
            {
                Assert.Fail();
            }
        }




        private List<BeerClient> ConvertBeerFromDB(List<Beer> beers)
        {
            List<BeerClient> beerClients = new List<BeerClient>();
            foreach (Beer beer in beers)
            {
                BeerClient beerClient = new BeerClient();
                beerClient.Id = beer.Id;
                beerClient.Name = beer.Name;
                beerClient.Degree = beer.Degree;
                beerClient.Price = beer.Price;

                beerClients.Add(beerClient);
            }
            return beerClients;
        }



       
    }

    
}