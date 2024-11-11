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
using WindowsStoreClone.Pages;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Main MainWindowContentPage;
    private TopAppsWrapped MyTopAppsWrappedPage;

    public MainWindow()
    {
        InitializeComponent();
        MainWindowContentPage = new Main();
        MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;
        MainWindowContentPage.TopAppButtonClicked += MainWindowContentPage_TopAppButtonClicked;
        // MainWindowContentPage.TopAppButtonClicked += (_, _) => MainFrame.Content = MyTopAppsWrappedPage;

        MyTopAppsWrappedPage = new TopAppsWrapped();
        MyTopAppsWrappedPage.AnAppClicked += MainWindowContentPage_AppClicked;
        MyTopAppsWrappedPage.BackButtonClicked += BackButtonClicked;
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
}