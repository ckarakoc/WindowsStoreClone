using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls;

public partial class HeaderRightButtons : UserControl
{
    public delegate void OnDownloadButtonClick(object sender, RoutedEventArgs e);

    public event OnDownloadButtonClick HeaderRightButtonsDownloadButtonClick;

    public HeaderRightButtons()
    {
        InitializeComponent();
    }

    private void DownloadsAndUpdatesMenuItem_Click(object sender, RoutedEventArgs e)
    {
        HeaderRightButtonsDownloadButtonClick(sender, e);
    }

    private void DownloadButton_Click(object sender, RoutedEventArgs e)
    {
        HeaderRightButtonsDownloadButtonClick(sender, e);
    }

    public void MouseDown_OutsideOfHeaderRightButtons()
    {
        if (!SearchTextBox.IsMouseOver)
        {
            SearchTextBox.Visibility = Visibility.Collapsed;
            SearchButton.Visibility = Visibility.Visible;
        }
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        (sender as Button).Visibility = Visibility.Collapsed;
        SearchTextBox.Visibility = Visibility.Visible;
    }
}