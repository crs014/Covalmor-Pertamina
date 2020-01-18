using System.IO;

namespace CovalmorPertamina.Common.Interfaces
{
    public interface IPdfService
    {
        void CreateDocumentA4FromMemoryStream(MemoryStream memory);

        void ReadPdf(Stream stream, byte[] fileByte);

        void SetPdfField(string fieldName, string fieldValue);

        void ClosePdf();
    }
}
