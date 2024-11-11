using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.AppDetailsTabContent;

public partial class Reviews : UserControl
{
    public Reviews()
    {
        InitializeComponent();
        MainStackPanel.Children.Clear();
        for (int i = 0; i < 9; i++)
        {
            MainStackPanel.Children.Add(new AReview());
        }
    }
}