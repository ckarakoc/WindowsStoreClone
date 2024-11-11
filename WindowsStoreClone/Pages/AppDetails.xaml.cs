using System.Windows;
using System.Windows.Controls;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone.Pages;

public partial class AppDetails : Page
{
    public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);

    public event OnBackButtonClicked BackButtonClicked;

    public delegate void OnAppDetailsAnotherAppClicked(AnApp sender, RoutedEventArgs e);

    public event OnAppDetailsAnotherAppClicked AppClicked;

    public AppDetails(AnApp anApp)
    {
        InitializeComponent();

        AppDetailsTitleBackgroundUC.AppNameLabel.Content = anApp.AppName;
        AppDetailsTitleBackgroundUC.AppImage.Source = anApp.AppImageSource;
        AppDetailsTitleBackgroundUC.BackButtonClicked += AppDetailsTitleBackgroundUC_BackButtonClicked;

        OverviewTabUC.AppClicked += OverviewTabUC_AppClicked;
        RelatedTabUC.RelatedClicked += OverviewTabUC_AppClicked;
    }

    private void OverviewTabUC_AppClicked(AnApp sender, RoutedEventArgs e)
    {
        AppClicked(sender, e);
    }

    private void AppDetailsTitleBackgroundUC_BackButtonClicked(object sender, RoutedEventArgs e)
    {
        BackButtonClicked(sender, e);
    }
}