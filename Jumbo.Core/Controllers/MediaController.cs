using Jumbo.Core.Interfaces;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Jumbo.Core.Controllers
{
    public class MediaController : IMediaController
    {
        private IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService= mediaService;
        }
        public string CreateFolderAtRoot(string folderName)
        {
            var checkFolder = _mediaService.GetMediaByPath($"/media/2nhbxw1a/doggo.webp");

           
            if (checkFolder == null)
            {
                IMedia folder = _mediaService.CreateMedia(folderName, Constants.System.Root, Constants.Conventions.MediaTypes.Folder);
                var saveResult = _mediaService.Save(folder);
            }
           
            return checkFolder.Path;

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
