using System;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("fapen/[controller]")]
    public class PDFReaderController : ControllerBase
    {
        [HttpGet]
        public string Get() => ReadFile();
        public static string ReadFile()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                using (PdfReader reader = new PdfReader(@"files/example.pdf"))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        stringBuilder.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ler o arquivo" + e.Message);
            }
        }
    }
}
