using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowsStoreClone.UserControls;

public partial class ProductivityTopApps : UserControl
{
    public delegate void OnAnAppClicked(AnApp sender, RoutedEventArgs e);

    public event OnAnAppClicked AppClicked;

    public ProductivityTopApps()
    {
        InitializeComponent();
    }

    private void Image_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        string appName = (new CultureInfo("en-US", false).TextInfo).ToTitleCase(
            (sender as Image).Source.ToString().Split('/').Last().Split('.').First().Split('-').Last().Split('.')
            .First()
        );
        AppClicked(new AnApp(appName, (sender as Image).Source), e);
    }
}