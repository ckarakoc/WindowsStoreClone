using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using WindowsStoreClone.Pages;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : MetroWindow
{
    private Main MainWindowContentPage;
    private TopAppsWrapped MyTopAppsWrappedPage;
    private DownloadsAnUpdates DownloadsAnUpdatesPage;

    private MetroWindow accentThemeTestWindow;

    public MainWindow()
    {
        InitializeComponent();
        MainWindowContentPage = new Main();
        MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;
        MainWindowContentPage.TopAppButtonClicked += MainWindowContentPage_TopAppButtonClicked;
        // MainWindowContentPage.TopAppButtonClicked += (_, _) => MainFrame.Content = MyTopAppsWrappedPage;
        MainWindowContentPage.DownloadsAndUpdatesClicked += MainWindowContentPage_DownloadsAndUpdatesClicked;

        MyTopAppsWrappedPage = new TopAppsWrapped();
        MyTopAppsWrappedPage.AnAppClicked += MainWindowContentPage_AppClicked;
        MyTopAppsWrappedPage.BackButtonClicked += BackButtonClicked;

        DownloadsAnUpdatesPage = new DownloadsAnUpdates();
        DownloadsAnUpdatesPage.BackButtonClicked += BackButtonClicked;
    }

    private void MainWindowContentPage_DownloadsAndUpdatesClicked()
    {
        MainFrame.Content = DownloadsAnUpdatesPage;
    }

    private void MainWindowContentPage_TopAppButtonClicked(object sender, RoutedEventArgs e)
    {
        MainFrame.Content = MyTopAppsWrappedPage;
    }

    private void MainWindowContentPage_AppClicked(AnApp sender, RoutedEventArgs e)
    {
        AppDetails myAppDetails = new AppDetails(sender);
        myAppDetails.BackButtonClicked += BackButtonClicked;
        myAppDetails.AppClicked += MainWindowContentPage_AppClicked;
        MainFrame.Content = myAppDetails;
    }

    private void MainFrame_OnLoaded(object sender, RoutedEventArgs e)
    {
        MainFrame.Content = MainWindowContentPage;
    }

    private void BackButtonClicked(object sender, RoutedEventArgs e)
    {
        if (MainFrame.NavigationService.CanGoBack)
            MainFrame.NavigationService.GoBack();
    }

    private void ChangeAppStyleButtonClick(object sender, RoutedEventArgs e)
    {
    }
}