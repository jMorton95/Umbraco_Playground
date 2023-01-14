using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace Jumbo.Core.Interfaces
{
    public interface IMediaController
    {
        public List<IMedia> CreateFolderAtRoot(string folderName);
        public IMedia GetImageBlobs();
    }
}
