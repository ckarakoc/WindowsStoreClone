using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.HamburgerMenuViews;

public partial class HamburgerMenuAppList : UserControl
{
    public List<HamburgerMenuApp> AllApps;
    public List<HamburgerMenuApp> AppsOnFilter;

    public HamburgerMenuAppList()
    {
        InitializeComponent();
        AllApps = new List<HamburgerMenuApp>();
        AppsOnFilter = new List<HamburgerMenuApp>();
        for (int i = 0; i < 15; i++)
        {
            AddNewHamApp();
        }
    }

    private void AddNewHamApp()
    {
        HamburgerMenuApp anApp = new HamburgerMenuApp();
        MainStackPanel.Children.Add(anApp);
        AllApps.Add(anApp);
    }

    public void FilterByType(string inFilter)
    {
        AppsOnFilter = AllApps.Where(p => p.Type == inFilter).ToList<HamburgerMenuApp>();
        AddToMainStackPanel(AppsOnFilter);
    }

    public void AddAll()
    {
        AppsOnFilter = new List<HamburgerMenuApp>();
        AddToMainStackPanel(AllApps);
    }

    public void SortByName()
    {
        List<HamburgerMenuApp> AllAppsSorted = new List<HamburgerMenuApp>();
        if (AppsOnFilter.Count < 1)
        {
            AllAppsSorted = AllApps.OrderBy(p => p.AppName).ToList<HamburgerMenuApp>();
        }
        else
        {
            AllAppsSorted = AppsOnFilter.OrderBy(p => p.AppName).ToList<HamburgerMenuApp>();
        }

        AddToMainStackPanel(AllAppsSorted);
    }

    public void SortByDate()
    {
        List<HamburgerMenuApp> AllAppsSorted = new List<HamburgerMenuApp>();
        if (AppsOnFilter.Count < 1)
        {
            AllAppsSorted = AllApps.OrderByDescending(p => p.Purchased).ToList<HamburgerMenuApp>();
        }
        else
        {
            AllAppsSorted = AppsOnFilter.OrderByDescending(p => p.Purchased).ToList<HamburgerMenuApp>();
        }

        AddToMainStackPanel(AllAppsSorted);
    }

    private void AddToMainStackPanel(List<HamburgerMenuApp> inList)
    {
        MainStackPanel.Children.Clear();
        foreach (HamburgerMenuApp item in inList)
        {
            MainStackPanel.Children.Add(item);
        }
    }
}