using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTradeViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
