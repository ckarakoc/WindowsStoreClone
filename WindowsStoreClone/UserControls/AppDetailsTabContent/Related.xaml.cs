using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.AppDetailsTabContent;

public partial class Related : UserControl
{
    public delegate void OnRelatedClicked(AnApp sender, RoutedEventArgs e);

    public event OnRelatedClicked RelatedClicked;

    public Related()
    {
        InitializeComponent();
        AppsViewer1.AppClicked += AppsViewerInsideRelatedTab_AnAppClicked;
        AppsViewer2.AppClicked += AppsViewerInsideRelatedTab_AnAppClicked;
        AppsViewer3.AppClicked += AppsViewerInsideRelatedTab_AnAppClicked;
        AppsViewer4.AppClicked += AppsViewerInsideRelatedTab_AnAppClicked;
        AppsViewer5.AppClicked += AppsViewerInsideRelatedTab_AnAppClicked;
    }

    private void AppsViewerInsideRelatedTab_AnAppClicked(AnApp sender, RoutedEventArgs e)
    {
        RelatedClicked(sender, e);
    }
}