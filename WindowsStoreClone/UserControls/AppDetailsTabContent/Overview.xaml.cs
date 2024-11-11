using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.AppDetailsTabContent;

public partial class Overview : UserControl
{
    public delegate void OnAppDetailsAppClicked(AnApp sender, RoutedEventArgs e);

    public event OnAppDetailsAppClicked AppClicked;

    public Overview()
    {
        InitializeComponent();
        AppsViewerInsideOverviewTab.AppClicked += AppsViewerInsideOverviewTab_AnAppClicked;
    }

    private void AppsViewerInsideOverviewTab_AnAppClicked(AnApp sender, RoutedEventArgs e)
    {
        AppClicked(sender, e);
    }
}