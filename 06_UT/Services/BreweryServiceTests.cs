using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04_SRV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_UT;
using _01_DB.Entities;
using _03_Models.VM;
using _03_Models.Models;
using NuGet.Frameworks;

namespace _04_SRV.Services.Tests
{
    [TestClass()]
    public class BreweryServiceTests
    {
        private static FakeContext _dataContext;
        const int IdBreweryOK = 1;
        const int IdBreweryNOk = -1;

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
        public bool BreweryService_success()
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
        public void GetAllBrewerWithBeerAndSalersTest()
        {
            CreateFakeServicesAndRepositories();

            List<BreweryClient> breweryClients = null;
            List<Brewery> breweries = _dataContext.breweries;

            if (breweries.Any())
            {
                breweryClients = ConvertBreweriesFromDB(breweries);
                Assert.IsNotNull(breweryClients);
            }
            else
            {
                Assert.Fail();
            }

        }

        [DataRow(IdBreweryOK, DisplayName = "Brasseur en DB")]
        [DataRow(IdBreweryNOk, DisplayName = "Brasseur pas en DB")]
        [TestMethod()]
        public void IsBreweryExistTest(int id)
        {
            Brewery brewery = _dataContext.breweries.FirstOrDefault(b => b.Id == id);
        }

        private List<BreweryClient> ConvertBreweriesFromDB(List<Brewery> breweries)
        {
            List<BreweryClient> breweryWBSList = new List<BreweryClient>();

            foreach (Brewery brewery in breweries)
            {
                BreweryWithBeersAndSalers breweryWBS = new BreweryWithBeersAndSalers();
                breweryWBS.Id = brewery.Id;
                breweryWBS.Name = brewery.Name;

                breweryWBSList.Add(breweryWBS);
            }
            return breweryWBSList;
        }
    }
}