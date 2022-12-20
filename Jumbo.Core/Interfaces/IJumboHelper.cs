using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Jumbo.Core.Interfaces
{
    public interface IJumboHelper
    {
        IPublishedContent GetRoot();
        string GetPageTitle();
        string GetPageDescription();
        string GetPageSetting(string prop);
        IPublishedContent GetCurrentNode();

    }
}
