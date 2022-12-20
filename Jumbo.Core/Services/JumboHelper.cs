using Jumbo.Core.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Jumbo.Core.Services
{
    public class JumboHelper : IJumboHelper
    {
        private UmbracoHelper _umbracoHelper {  get; set; }
        private IUmbracoContextAccessor _umbracoContextAccessor { get; set; }
        public JumboHelper(UmbracoHelper umbracoHelper, IUmbracoContextAccessor umbracoContextAccessor)
        {
            _umbracoHelper = umbracoHelper;
            _umbracoContextAccessor = umbracoContextAccessor;
        }
        public string GetPageTitle()
        {
            return GetPageSetting("pageTitle");
        }
        public string GetPageDescription()
        {
            throw new NotImplementedException();
        }

        public IPublishedContent GetRoot() => _umbracoHelper.ContentAtRoot().FirstOrDefault();

        public IPublishedContent GetCurrentNode()
        {
            _umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext);
            return umbracoContext.PublishedRequest.PublishedContent;
        }

        public string GetPageSetting(string prop)
        {
            var node = GetCurrentNode();
            var pageSetting = node.GetProperty(prop).GetValue().ToString();
            return pageSetting;
        }
    }
}
