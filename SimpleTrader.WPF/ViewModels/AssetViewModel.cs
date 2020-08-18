using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetViewModel : ViewModelBase
    {
        public string Symbol { get; set; }
        public int Shares { get; set; }

        public AssetViewModel(string symbol, int shares)
        {
            Symbol = symbol;
            Shares = shares;
        }

    }
}
