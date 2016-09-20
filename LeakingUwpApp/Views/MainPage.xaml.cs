using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace LeakingUwpApp.Views
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs navigationEventArgs)
        {
            base.OnNavigatedTo(navigationEventArgs);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            ForceGarbageCollection();
        }

        private void GoToLeakingPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LeakingPage));
        }

        private void ForceGarbageCollectionButton_OnClick(object sender, RoutedEventArgs e)
        {
            ForceGarbageCollection();
        }

        private void ForceGarbageCollection()
        {
            var memoryBefore = GC.GetTotalMemory(false) / (1024 * 1024);
            var memoryAfter = GC.GetTotalMemory(true) / (1024 * 1024);
            statusTextBlock.Text = String.Format("Memory usage before GC = {0}MB, after GC = {1}MB, time = {2}", memoryBefore, memoryAfter, DateTime.Now);
        }
    }
}
