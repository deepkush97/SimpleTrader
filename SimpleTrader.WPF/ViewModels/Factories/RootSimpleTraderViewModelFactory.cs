using Microsoft.EntityFrameworkCore.Query.Internal;
using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class RootSimpleTraderViewModelFactory : IRootSimpleTraderViewModelFactory
    {
        private readonly ISimpleTradeViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTradeViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private readonly BuyViewModel _buyViewModel;

        public RootSimpleTraderViewModelFactory(
            ISimpleTradeViewModelFactory<HomeViewModel> homeViewModelFactory,
            ISimpleTradeViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
            BuyViewModel buyViewModel)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _buyViewModel = buyViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModel;
                default:
                    throw new ArgumentException("The viewType does not a have a ViewModel", nameof(viewType));

            }
        }
    }
}
