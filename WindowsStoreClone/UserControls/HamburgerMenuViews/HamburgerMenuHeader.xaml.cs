using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.HamburgerMenuViews;

public partial class HamburgerMenuHeader : UserControl
{
    public delegate void OnFilterMenuItemClicked(object sender, RoutedEventArgs e);

    public event OnFilterMenuItemClicked FilterMenuItemClicked;

    public delegate void OnSortByMenuItemClicked(object sender, RoutedEventArgs e);

    public event OnSortByMenuItemClicked SortByMenuItemClicked;

    public HamburgerMenuHeader()
    {
        InitializeComponent();
    }

    private void SortBy_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        SortByLabel.Content = (sender as MenuItem).Header.ToString();
        SortByMenuItemClicked(sender, e);
    }

    private void Filter_MenuItem_Click(object sender, RoutedEventArgs e)
    {
        FilterByTypeLabel.Content = (sender as MenuItem).Header.ToString();
        FilterMenuItemClicked(sender, e);
    }
}