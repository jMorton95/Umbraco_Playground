using Jumbo.Core.Interfaces;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Persistence.Querying;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Jumbo.Core.Controllers
{
    public class MediaController : IMediaController
    {
        private IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService= mediaService;
        }
        public List<IMedia> CreateFolderAtRoot(string folderName)
        {
            //var checkFolder = _mediaService.GetMediaFileContentStream($"/media/2nhbxw1a/Doggo.webp");
            var logoFolder = _mediaService.GetPagedChildren(1067, 1, 100, out long num).ToList();



            /*if (checkFolder == null)
            {
                IMedia folder = _mediaService.CreateMedia(folderName, Constants.System.Root, Constants.Conventions.MediaTypes.Folder);
                var saveResult = _mediaService.Save(folder);
            }*/
            //checkFolder.GetUrl($"/media/2nhbxw1a/doggo.webp");
            return logoFolder;

        }
        public IMedia GetImageBlobs()
        {
            var path = "/Logos";
            var fileObj = _mediaService.GetMediaByPath(path);
            //var count = mediaService.CountChildren(path);
            return fileObj;
        }
    }

   

}
