using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace WindowsStoreClone.Pages;

public partial class DownloadsAnUpdates : Page
{
    public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);

    public event OnBackButtonClicked BackButtonClicked;

    public DownloadsAnUpdates()
    {
        InitializeComponent();
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        BackButtonClicked(sender, e);
    }

    private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs args)
    {
        HamburgerMenuControl.Content = args.InvokedItem;
    }
}