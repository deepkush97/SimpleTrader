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
        private readonly ISimpleTradeViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly BuyViewModel _buyViewModel;

        public RootSimpleTraderViewModelFactory(
            ISimpleTradeViewModelFactory<HomeViewModel> homeViewModelFactory,
            ISimpleTradeViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
            ISimpleTradeViewModelFactory<LoginViewModel> loginViewModelFactory,
            BuyViewModel buyViewModel)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
            _buyViewModel = buyViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
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
