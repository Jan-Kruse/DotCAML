using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML
{
    public class CamlValues
    {
        public static string UserID = "{UserID}";

        public static string Today = "{Today}";

        public static string TodayWithOffset(int offsetDays)
        {
            return "{Today OffsetDays=\"" + offsetDays + "\"}";
        }

        public static string Now = "{Now}";

        public static ListProperty ListProperty  = new ListProperty {
            Created = "{ListProperty Name=\"Created\"}",
            DefaultViewUrl = "{ListProperty Name=\"DefaultViewUrl\"}",
            Description = "{ListProperty Name=\"Description\"}",
            EnableSyndication = "{ListProperty Name=\"EnableSyndication\"}",
            ItemCount = "{ListProperty Name=\"ItemCount\"}",
            LinkTitle = "{ListProperty Name=\"LinkTitle\"}",
            MajorVersionLimit = "{ListProperty Name=\"MajorVersionLimit\"}",
            MajorWithMinorVersionsLimit = "{ListProperty Name=\"MajorWithMinorVersionsLimit\"}",
            RelativeFolderPath = "{ListProperty Name=\"RelativeFolderPath\"}",
            Title = "{ListProperty Name=\"Title\"}",
            ViewSelector = "{ListProperty Name=\"ViewSelector\"}"
        };

        public static ProjectProperty ProjectProperty = new ProjectProperty {
            BlogCategoryTitle = "{ProjectProperty Name=\"BlogCategoryTitle\"}",
            BlogPostTitle = "{ProjectProperty Name=\"BlogPostTitle\"}",
            Description = "{ProjectProperty Name=\"Description\"}",
            RecycleBinEnabled = "{ProjectProperty Name=\"RecycleBinEnabled\"}",
            SiteOwnerName = "{ProjectProperty Name=\"SiteOwnerName\"}",
            SiteUrl = "{ProjectProperty Name=\"SiteUrl\"}",
            Title = "{ProjectProperty Name=\"Title\"}",
            Url = "{ProjectProperty Name=\"Url\"}"
        };
    }

    public class ListProperty
    {
        public string Created { get; set; }
        public string DefaultViewUrl { get; set; }
        public string Description { get; set; }
        public string EnableSyndication { get; set; }
        public string ItemCount { get; set; }
        public string LinkTitle { get; set; }
        public string MajorVersionLimit { get; set; }
        public string MajorWithMinorVersionsLimit { get; set; }
        public string RelativeFolderPath { get; set; }
        public string Title { get; set; }
        public string ViewSelector { get; set; }
    }

    public class ProjectProperty
    {
        public string BlogCategoryTitle { get; set; }
        public string BlogPostTitle { get; set; }
        public string Description { get; set; }
        public string RecycleBinEnabled { get; set; }
        public string SiteOwnerName { get; set; }
        public string SiteUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
