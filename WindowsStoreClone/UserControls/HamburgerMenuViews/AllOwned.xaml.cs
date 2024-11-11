using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.HamburgerMenuViews;

public partial class AllOwned : UserControl
{
    public AllOwned()
    {
        InitializeComponent();
        HamHeader.FilterMenuItemClicked += HamHeader_FilterMenuItemClicked;
        HamHeader.SortByMenuItemClicked += HamHeader_SortByMenuItemClicked;
    }

    private void HamHeader_FilterMenuItemClicked(object sender, RoutedEventArgs e)
    {
        if ((sender as MenuItem).Header.ToString().ToLower() == "all types")
        {
            HamAppsList.AddAll();
        }
        else
        {
            HamAppsList.FilterByType((sender as MenuItem).Header.ToString());
        }
    }

    private void HamHeader_SortByMenuItemClicked(object sender, RoutedEventArgs e)
    {
        if ((sender as MenuItem).Header.ToString().ToLower() == "sort by name")
        {
            HamAppsList.SortByName();
        }
        else
        {
            HamAppsList.SortByDate();
        }
    }
}