using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Result;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        //!ApiKey : 93a0f0fa22a30a36bcdf78728bed4ff7
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                //string uri = $"demo/{symbol}";
                //StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);
                //if (stockPriceResult.Price == 0)
                //{
                //    throw new InvalidSymbolException(symbol);
                //}
                //return stockPriceResult.Price;

                return DateTime.Now.Minute + (DateTime.Now.Millisecond * 0.01);
            }
        }
    }
}
