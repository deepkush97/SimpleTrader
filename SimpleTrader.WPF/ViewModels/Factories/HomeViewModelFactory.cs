using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    class HomeViewModelFactory : ISimpleTradeViewModelFactory<HomeViewModel>
    {
        private readonly ISimpleTradeViewModelFactory<MajorIndexListingViewModel> _majorIndexViewModelFactory;

        public HomeViewModelFactory(ISimpleTradeViewModelFactory<MajorIndexListingViewModel> majorIndexViewModelFactory )
        {
            _majorIndexViewModelFactory = majorIndexViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_majorIndexViewModelFactory.CreateViewModel());
        }
    }
}
