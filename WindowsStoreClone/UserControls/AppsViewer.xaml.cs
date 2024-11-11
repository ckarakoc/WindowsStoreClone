using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowsStoreClone.UserControls;

public partial class AppsViewer : UserControl
{
    private List<AnApp> PresentedApps;
    public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
    public event OnAppClicked AppClicked;

    public AppsViewer()
    {
        InitializeComponent();
        PresentedApps = [];
        AppsList.ItemsSource = PresentedApps;
        for (int i = 0; i < 19; i++)
        {
            var app = new AnApp();
            app.AppClicked += Curr_AppClicked;
            PresentedApps.Add(app);
        }
    }

    private void Curr_AppClicked(AnApp sender, RoutedEventArgs e)
    {
        AppClicked(sender, e);
    }

    private void ScrollLeftButton_OnClick(object sender, RoutedEventArgs e)
    {
        int widthOfOneApp = (int) PresentedApps.First().ActualWidth + 2 * (int) PresentedApps.First().Margin.Left;
        AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 4 * widthOfOneApp);
    }

    private void ScrollRightButton_OnClick(object sender, RoutedEventArgs e)
    {
        int widthOfOneApp = (int) PresentedApps.First().ActualWidth + 2 * (int) PresentedApps.First().Margin.Left;
        AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 4 * widthOfOneApp);
    }

    private void AppsScrollView_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        e.Handled = true;
        var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
        eventArg.RoutedEvent = UIElement.MouseWheelEvent;
        eventArg.Source = sender;
        var parent = ((Control) sender).Parent as UIElement;
        parent.RaiseEvent(eventArg);
    }
}