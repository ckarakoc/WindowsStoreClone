using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowsStoreClone.UserControls;

public partial class TopApps : UserControl
{
    public delegate void OnAnAppClicked(AnApp sender, RoutedEventArgs e);

    public event OnAnAppClicked AppClicked;

    public delegate void OnTopAppButtonClicked(object sender, RoutedEventArgs e);

    public event OnTopAppButtonClicked TopAppButtonClicked;

    public TopApps()
    {
        InitializeComponent();
    }

    private void Image_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        string appName = (new CultureInfo("en-US", false).TextInfo).ToTitleCase
        (
            (sender as Image).Source.ToString().Split('/').Last().Split('.').First().Split('-').Last().Split('.').First()
        );
        AppClicked(new AnApp(appName, (sender as Image).Source), e);
    }

    private void TopAppsButton_OnClick(object sender, RoutedEventArgs e)
    {
        TopAppButtonClicked(sender, e);
    }
}