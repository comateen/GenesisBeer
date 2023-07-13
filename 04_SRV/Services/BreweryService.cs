
using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.VM;
using _04_SRV.Helper;
using _04_SRV.Interfaces;

namespace _04_SRV.Services
{
    public class BreweryService : ServiceHelper, IBreweryService
    {
        #region private variable
        private readonly IBreweryRepository _breweryRepository;
        #endregion
        public BreweryService(IBreweryRepository breweryRepository)
        {
            _breweryRepository = breweryRepository;
        }

        #region public method
        public IEnumerable<BreweryWithBeersAndSalers> GetAllBrewerWithBeerAndSalers()
        {
            List<Brewery> breweries = _breweryRepository.GetAllBreweryData();
            if (breweries != null && breweries.Count > 0)
            {
                List<BreweryWithBeersAndSalers> breweryWBS = ConvertBreweriesFromDB(breweries);

                return breweryWBS;
            }
            throw new Exception("Nous n'avons pas trouvé de brasseur");
        }

        public bool IsBreweryExist(int id)
        {
            return _breweryRepository.IsBreweryExist(id);
        }
        #endregion

        #region private method
        private List<BreweryWithBeersAndSalers> ConvertBreweriesFromDB(List<Brewery> breweries)
        {
            List<BreweryWithBeersAndSalers> breweryWBSList = new List<BreweryWithBeersAndSalers>();

            foreach (Brewery brewery in breweries)
            {
                BreweryWithBeersAndSalers breweryWBS = new BreweryWithBeersAndSalers();
                breweryWBS.Id = brewery.Id;
                breweryWBS.Name = brewery.Name;

                breweryWBS.Beers = SetBeerClient(brewery.Beers);

                breweryWBSList.Add(breweryWBS);
            }
            return breweryWBSList;
        }
        #endregion

    }
}
