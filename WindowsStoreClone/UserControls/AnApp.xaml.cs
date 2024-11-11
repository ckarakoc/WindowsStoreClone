using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MiscUtil;

namespace WindowsStoreClone.UserControls;

public partial class AnApp : UserControl
{
    public string AppName;
    public ImageSource AppImageSource;

    public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);

    public event OnAppClicked AppClicked;

    public AnApp()
    {
        InitializeComponent();
        var filepaths = Directory.GetFiles(Environment.CurrentDirectory + @"/../../../Images", "*.png")
            .ToList();
        FileInfo fileInfo = new FileInfo(filepaths[StaticRandom.Next(filepaths.Count)]);
        ProductImage.Source = new BitmapImage(new Uri(fileInfo.FullName, UriKind.RelativeOrAbsolute));
        AppNameText.Text = (new CultureInfo("en-US", false).TextInfo)
            .ToTitleCase(fileInfo.Name.Split('-').Last().Split('.').First());

        AppName = AppNameText.Text;
        AppImageSource = ProductImage.Source;
    }

    public AnApp(string appName, ImageSource source)
    {
        InitializeComponent();
        ProductImage.Source = source;
        AppNameText.Text = appName;
        
        AppName = AppNameText.Text;
        AppImageSource = ProductImage.Source;
    }

    private void ProductImage_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        AppClicked(this, e);
    }
}