using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone.Pages;

public partial class Main : Page
{
    public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
    public event OnAppClicked AppClicked;
    
    public Main()
    {
        InitializeComponent();
        MainScrollViewer.AddHandler(ScrollViewer.MouseWheelEvent,
            new MouseWheelEventHandler(ScrollViewer_MouseWheel), true);
        MainProductivitySV.AddHandler(ScrollViewer.MouseWheelEvent,
            new MouseWheelEventHandler(ScrollViewer_MouseWheelMP), true);

        DealsAppsViewer.AppClicked += AnAppClicked;
        
        ProductivityTopApps.AppClicked += AnAppClicked;
        ProductivityAppsL1.AppClicked += AnAppClicked;
        ProductivityAppsL2.AppClicked += AnAppClicked;
        ProductivityAppsL3.AppClicked += AnAppClicked;
        
        EntertainmentAppsViewer.AppClicked += AnAppClicked;
        GamingAppsViewer.AppClicked += AnAppClicked;
        
        FeaturesAppViewer.AppClicked += AnAppClicked;
        MostPopularAppViewer.AppClicked += AnAppClicked;
        FreeAppsViewer.AppClicked += AnAppClicked;
        GamesAppViewer.AppClicked += AnAppClicked;
    }

    private void AnAppClicked(AnApp sender, RoutedEventArgs e)
    {
        AppClicked(sender, e);
    }

    private void ScrollViewer_MouseWheelMP(object sender, MouseWheelEventArgs e)
    {
        if (e.Delta > 0)
        {
            this.MainProductivitySV.ScrollToVerticalOffset(this.MainProductivitySV.VerticalOffset - 50);
        }
        else
        {
            this.MainProductivitySV.ScrollToVerticalOffset(this.MainProductivitySV.VerticalOffset + 50);
        }
    }

    private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (e.Delta > 0)
        {
            this.MainScrollViewer.ScrollToVerticalOffset(this.MainScrollViewer.VerticalOffset - 50);
        }
        else
        {
            this.MainScrollViewer.ScrollToVerticalOffset(this.MainScrollViewer.VerticalOffset + 50);
        }
    }

    private void MainScrollViewer_OnLoaded(object sender, RoutedEventArgs e)
    {
        // XAML has higher priority, so this won't be animated
        UIElement element = (UIElement) sender;
        element.Opacity = 0;
        DoubleAnimation animation = new DoubleAnimation()
        {
            From = 0,
            To = 1,
            Duration = new Duration(TimeSpan.FromMilliseconds(1000))
        };
        element.BeginAnimation(UIElement.OpacityProperty, animation);
    }
}