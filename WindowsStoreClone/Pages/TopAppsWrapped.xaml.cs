using System.Windows;
using System.Windows.Controls;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone.Pages;

public partial class TopAppsWrapped : Page
{
    public delegate void OnAnAppClicked(AnApp sender, RoutedEventArgs e);

    public event OnAnAppClicked AnAppClicked;

    public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);

    public event OnBackButtonClicked BackButtonClicked;

    public TopAppsWrapped()
    {
        InitializeComponent();
        for (int i = 0; i < 20; i++)
        {
            AnApp currAnApp = new AnApp();
            currAnApp.AppClicked += CurrAnApp_AppClicked;
            TopAppsWrappedPageMainWrapPanel.Children.Add(currAnApp);
        }
    }

    private void Back_Btn(object sender, RoutedEventArgs e)
    {
        BackButtonClicked(sender, e);
    }

    private void CurrAnApp_AppClicked(AnApp sender, RoutedEventArgs e)
    {
        AnAppClicked(sender, e);
    }

    private void TopAppsWrappedPageMainSV_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.VerticalChange > 0)
        {
            int adjustment = 400;
            if (e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight)
            {
                for (int i = 0; i < 6; i++)
                {
                    AnApp newApp = new AnApp();
                    newApp.AppClicked += CurrAnApp_AppClicked;
                    TopAppsWrappedPageMainWrapPanel.Children.Add(newApp);
                }
            }
        }
    }
}