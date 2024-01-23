using EwalletMobileApp.MVVM.ViewModels;
using The49.Maui.BottomSheet;

namespace EwalletMobileApp.Services.Factories
{
    class BottomSheetFactory
    {
        public static BottomSheet CreateInstance<T, TViewModel>(ViewModelBase viewModel) where TViewModel : ViewModelBase
                                                                                         where T : BottomSheet, new()
        {
            T t = new();
            t.BindingContext = (TViewModel)viewModel;
            return t;
        }
    }
}
