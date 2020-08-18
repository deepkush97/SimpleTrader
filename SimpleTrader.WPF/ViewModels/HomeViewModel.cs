using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        public AssetSummaryViewModel AssetSummaryViewModel { get; }

        public HomeViewModel(AssetSummaryViewModel assetSummaryViewModel, MajorIndexListingViewModel majorIndexListingViewModel)
        {
            AssetSummaryViewModel = assetSummaryViewModel;
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }

        public MajorIndexListingViewModel MajorIndexListingViewModel { get; }
    }
}
