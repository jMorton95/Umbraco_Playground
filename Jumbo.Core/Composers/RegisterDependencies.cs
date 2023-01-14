using Jumbo.Core.Controllers;
using Jumbo.Core.Interfaces;
using Jumbo.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Jumbo.Core.Composers
{
    public class RegisterDependencies : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IJumboHelper, JumboHelper>();
            builder.Services.AddScoped<IMediaController, MediaController>();

        }
    }
}
