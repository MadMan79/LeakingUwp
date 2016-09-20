using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using LeakingUwpApp.ViewModels;

namespace LeakingUwpApp.Views
{
    public sealed partial class SecondaryPage
    {
        public SecondaryPageViewModel ViewModel => (SecondaryPageViewModel)DataContext;

        public SecondaryPage()
        {
            InitializeComponent();

            DataContext = new SecondaryPageViewModel(); // heavy VM in DataContext
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}
