using CovalmorPertamina.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CovalmorPertamina.Common.Services
{
    public class FileUploadHandler : IFileUploadHandler
    {
        private IEnumerable<HttpPostedFileWrapper> _httpPostedFileWrappers;
        private IEnumerable<string> _pathFiles;

        public void SetUploadedFile(IEnumerable<HttpPostedFileWrapper> httpPostedFileWrappers, IEnumerable<string> pathFiles)
        {
            _httpPostedFileWrappers = httpPostedFileWrappers;
            _pathFiles = pathFiles;
        }

        public void UploadAction()
        {
            int i = 0;
            foreach(HttpPostedFileWrapper httpPostedFile in _httpPostedFileWrappers)
            {
                httpPostedFile.SaveAs(_pathFiles.ToList()[i]);
                i++;
            }
        }
    }
}
