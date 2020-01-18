using CovalmorPertamina.Common.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CovalmorPertamina.Common.Services
{
    public class PdfService : IPdfService
    {
        private PdfReader _pdfReader;
        private PdfStamper _pdfStamper;
        private AcroFields _acroFields;

        public void ClosePdf()
        {
            _pdfStamper.Close();
            _pdfReader.Close();
        }

        public void CreateDocumentA4FromMemoryStream(MemoryStream memory)
        {
            Document document = new Document(PageSize.A4);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memory);
            pdfWriter.CloseStream = false;          
        }

        public void ReadPdf(Stream stream, byte[] fileByte)
        {
            _pdfReader = new PdfReader(fileByte);
            _pdfStamper = new PdfStamper(_pdfReader, stream);
            _acroFields = _pdfStamper.AcroFields;
            _pdfStamper.FormFlattening = true;
        }

        public void SetPdfField(string fieldName, string fieldValue)
        {
            _acroFields.SetField(fieldName, fieldValue);
        }
    }
}
