using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MiscUtil;

namespace WindowsStoreClone.UserControls.HamburgerMenuViews;

public partial class HamburgerMenuApp : UserControl
{
    public List<string> AppNames;
    public List<string> AppTypes;
    public string AppName;
    public DateTime Purchased;
    public string Type;

    public HamburgerMenuApp()
    {
        InitializeComponent();
        AppTypes = ["Apps", "Games", "Movies", "Avatars"];
        List<string> filepaths = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\..\Images\MiniIcons", "*.png").ToList<string>();
        FileInfo myRandomFile = new FileInfo(filepaths[StaticRandom.Next(filepaths.Count)]);
        AppImage.Source = new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
        AppNameLabel.Content = (new CultureInfo("en-US", false).TextInfo).ToTitleCase(
            AppImage.Source.ToString().Split('/').Last().Split('.').First().Split('-').Last().Split('.').First()
        );
        AppName = AppNameLabel.Content.ToString();
        Type = AppTypes[StaticRandom.Next(AppTypes.Count)];
        Purchased = new DateTime(2021, 1, StaticRandom.Next(1, DateTime.Now.Day + 1));
        PurchasedLabel.Content = "Purchased " + Purchased.ToString("d");
    }
}