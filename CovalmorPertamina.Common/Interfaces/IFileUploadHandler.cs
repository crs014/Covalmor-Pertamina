using System.Collections.Generic;
using System.Web;

namespace CovalmorPertamina.Common.Interfaces
{
    public interface IFileUploadHandler
    {
        void SetUploadedFile(IEnumerable<HttpPostedFileWrapper> httpPostedFileWrappers, IEnumerable<string> pathFiles);

        void UploadAction();
    }
}
