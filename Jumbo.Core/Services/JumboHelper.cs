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
            return GetPageSetting("pageDescription");
        }

        public IPublishedContent GetRoot() => _umbracoHelper.ContentAtRoot().FirstOrDefault(x => x.ContentType.Alias == "Home");

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

        public IPublishedContent GetSEO()
        {
            var node = GetCurrentNode();
            var seo = node.Children.FirstOrDefault(x => x.ContentType.Alias == "sEOPageSettings");
            return seo;
        }
    }
}
