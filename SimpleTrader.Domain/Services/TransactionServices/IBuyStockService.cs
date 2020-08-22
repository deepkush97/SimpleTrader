using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        /// <summary>
        /// Purchase the stock for an account.
        /// </summary>
        /// <param name="buyer">The account of the buyer.</param>
        /// <param name="symbol">The symbol to be purchased.</param>
        /// <param name="shares">The amount of shares.</param>
        /// <returns>The updated account.</returns>
        /// <exception cref="InsufficientFundsException">Throws if the account have insufficient balance.</exception>
        /// <exception cref="InsufficientFundsException">Throws if the purchased symbol is invalid.</exception>
        /// <exception cref="InsufficientFundsException">Throws if the transaction fails.</exception>
        Task<Account> BuyStock(Account buyer, string symbol, int shares);
    }
}
