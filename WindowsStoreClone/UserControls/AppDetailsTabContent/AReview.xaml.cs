using System.Windows.Controls;
using MiscUtil;

namespace WindowsStoreClone.UserControls.AppDetailsTabContent;

public partial class AReview : UserControl
{
    private List<string> Names;

    public AReview()
    {
        InitializeComponent();
        Names =
        [
            "Sophia Rivera", "Ethan Mitchell", "Olivia Harrison", "Lucas Bennett", "Ava Sullivan", "Liam Roberts",
            "Isabella Clark", "Noah Walker", "Mia Carter", "Mason Harris"
        ];

        string reviewerName = Names[StaticRandom.Next(0, Names.Count)];
        ReviewerNameLabel.Content = reviewerName;
        AvatarLabel.Content = reviewerName[0];
        var stars = GetRandomNumOfStars();
        NumOfStarsLabel.Content = stars;
        ReviewTitle.Content = GetReviewTitle(stars);
    }

    private string GetReviewTitle(string stars)
    {
        return stars.Length >=4 ? "This app is awesome!" : stars.Length == 3 ? "This app is all right." : "This app is poor!";
    }

    private string GetRandomNumOfStars()
    {
        string content = "";
        for (int i = 0; i < StaticRandom.Next(1, 6); i++)
        {
            content += "★";
        }
        return content;
    }
}