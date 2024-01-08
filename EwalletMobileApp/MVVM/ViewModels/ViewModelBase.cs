using CommunityToolkit.Mvvm.ComponentModel;
using EwalletMobileApp.Services.Interfaces;

namespace EwalletMobileApp.MVVM.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    protected readonly INavigationService _navigationService;

    public ViewModelBase(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

}
