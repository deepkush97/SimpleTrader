using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.Domain.Services
{

    public interface IStockPriceService
    {
        /// <summary>
        /// Get the share price for a symbol.
        /// </summary>
        /// <param name="symbol">The symbol to get the price of.</param>
        /// <returns>The price of the symbol</returns>
        /// <exception cref="InvalidSymbolException">Throws if the symbol does not exist.</exception>
        /// <exception cref="Exception">Throws if getting the symbol fails.</exception>
        Task<double> GetPrice(string symbol);
    }
}
