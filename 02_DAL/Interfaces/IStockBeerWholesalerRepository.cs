﻿using _01_DB.Entities;
using _02_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DAL.Interfaces
{
    public interface IStockBeerWholesalerRepository
    {
        public bool AddNewBeerToWholeSaler(StockBeerWholesaler stockBeerWolesaler);
        public bool UpdateStockBeerWholesaler(StockBeerWholesaler stockBeerWolesaler);
        public List<StockBeerWholesaler> GetAllStockBeerByWholesalerId(int id);
        public StockBeerWholesaler GetStockBeerWholesalerByBeerIdAndWholesalerId(int beerId, int wholesalerId);
        public bool DeleteStockBeerWholesaler(StockBeerWholesaler stockBeerWolesaler);
    }
}
