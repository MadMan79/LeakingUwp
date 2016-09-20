using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using LeakingUwpApp.ViewModels;

namespace LeakingUwpApp.Views
{
    public sealed partial class LeakingPage
    {
        public HeavyViewModel ViewModel => (HeavyViewModel)DataContext;

        public LeakingPage()
        {
            DataContext = new HeavyViewModel(); // heavy VM in DataContext

            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}
