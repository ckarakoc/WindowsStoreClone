using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls;

public partial class AppDetailsTitleBackground : UserControl
{
    public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
    public event OnBackButtonClicked BackButtonClicked;
    
    public AppDetailsTitleBackground()
    {
        InitializeComponent();
    }

    private void Back_Btn(object sender, RoutedEventArgs e)
    {
        BackButtonClicked(sender, e);
    }
}