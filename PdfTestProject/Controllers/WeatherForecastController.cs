using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Reflection.Metadata;
using System.Diagnostics;
using iText.Html2pdf;
using System.Drawing;

namespace PdfTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /*[HttpGet]
        [Route("{orderId}/getPdf")]
        public async Task<IActionResult> GeneratePdf([FromRoute] int orderId)
        {

            try
            {
                ConversionOptions options = new ConversionOptions(PageSize.A4, PageOrientation.Landscape, 50.0f);

                // Dynamic HTML content with supplier name interpolated
                string dynamicHtml = $@"<!DOCTYPE html>
                            <html lang=""en"">
                            <head>
                                <meta charset=""UTF-8"">
                                <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <title>PURCHASE ORDER</title>
                            </head>
                            <body style=""display: flex; flex-direction: column; gap: 25px; margin: 10px; font-family: Arial, sans-serif;"">
                                <div style=""display: flex; flex-direction: row; gap: 25px;justify-content:space-between;"">
                                    <div style=""width: 30%;""></div>
                                    <div style=""width: 33%;font-size: 25px; font-weight: bold;"">
                                        <h1 style=""margin: 0;"">PURCHASE ORDER</h1>
                                    </div>
                                    <div style=""width: 36%; text-align: left;"">
                                        <table style=""float: right;"">
                                            <tr>
                                                <td style=""border-bottom: 1px solid grey;padding: 8px;"">Purchase Order No.  <strong></strong></td>
                                            </tr>
                                            <tr>
                                                <td style=""border-bottom: 1px solid grey;padding: 8px;"">Date Ordered  <strong></strong></td>
                                            </tr>
                                            <tr>
                                                <td style=""border-bottom: 1px solid grey;padding: 8px;"">Submitted By <strong></strong></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div style=""display: flex; flex-direction: row; justify-content:space-between ;"">
                                    <div style=""width: 25%;"">
                                        <h3>VENDOR</h3>
                                        <hr>
                                    </div>
                                    <div style=""width: 25%;"">
                                        <h3>SHIPPING ADDRESS</h3>
                                        <hr>
                                        <p style=""margin: 0;"">Dolce gourmando Inc</p>
                                        <p style=""margin: 0;"">Address</p>
                                        <p style=""margin: 0;"">City, Province, Zip</p>
                                    </div>
                                    <div style=""width: 25%;"">
                                        <h3>BILLING ADDRESS</h3>
                                        <hr>
                                        <p style=""margin: 0;"">Dolce gourmando Inc</p>
                                        <p style=""margin: 0;"">Address</p>
                                        <p style=""margin: 0;"">City, Province, Zip</p>
                                    </div>
                                </div>
                                <div style=""display: flex; flex-direction: column;"">
                                    <table style=""width: 100%; border-collapse: collapse;border-bottom: 2px solid black;"">
                                        <thead>
                                            <tr style=""border-bottom: 2px solid black; padding: 4px;"">
                                                <th style=""text-align: left;padding-bottom: 10px;"">ITEM DESCRIPTION</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">ITEM #</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">Date Expected</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">QUANTITY</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">UNIT RATE</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">AMOUNT</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                    <div style=""float: right;"">
                                        <table style=""float: right;font-size: 18px; border-collapse: collapse;"">
                                             <tbody>
                                             </tbody>                                            
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px;"">Subtotal</td>
                                                <td style=""padding: 8px;""></td>
                                            </tr>
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px;"">Discounts</td>
                                                <td style=""padding: 8px;"">Discounts</td>
                                            </tr>
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px;"">Tax</td>
                                                <td style=""padding: 8px;"">Tax</td>
                                            </tr>
                                            <tr style=""border-bottom: 2px solid black;"">
                                                <td style=""padding: 8px;"">Shipping</td>
                                                <td style=""padding: 8px;"">Shipping</td>
                                            </tr>
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px; font-weight: bold;"">Order Total</td>
                                                <td style=""padding: 8px; font-weight: bold;""></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </body>
                            </html>";

                byte[] pdfBytes = Converter.Convert(dynamicHtml, null, options);


                return File(pdfBytes, "application/pdf", $"PurchaseOrder_{orderId}.pdf");
            }
           
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error - " + ex.Message);
            }

        }*/



        [HttpGet("generate")]
        public IActionResult GeneratePdf()
        {
             string dynamicHtml = @"<!DOCTYPE html>
                            <html lang=""en"">
                              <head>
            <style>
                @page {size: landscape;}
            </style>
        </head>
                            <body style=""display: flex; flex-direction: column; gap: 25px; margin: 10px; font-family: Arial, sans-serif;"">
                                <div style=""display: flex; flex-direction: row; gap: 25px;justify-content:space-between;"">
                                    <div style=""width: 30%;""></div>
                                    <div style=""width: 33%;font-size: 25px; font-weight: bold;"">
                                        <h1 style=""margin: 0;"">PURCHASE ORDER</h1>
                                    </div>
                                    <div style=""width: 36%; text-align: left;"">
                                        <table style=""float: right;"">
                                            <tr>
                                                <td style=""border-bottom: 1px solid grey;padding: 8px;"">Purchase Order No.  <strong></strong></td>
                                            </tr>
                                            <tr>
                                                <td style=""border-bottom: 1px solid grey;padding: 8px;"">Date Ordered  <strong></strong></td>
                                            </tr>
                                            <tr>
                                                <td style=""border-bottom: 1px solid grey;padding: 8px;"">Submitted By <strong></strong></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div style=""display: flex; flex-direction: row; justify-content:space-between ;"">
                                    <div style=""width: 25%;"">
                                        <h3>VENDOR</h3>
                                        <hr>
                                    </div>
                                    <div style=""width: 25%;"">
                                        <h3>SHIPPING ADDRESS</h3>
                                        <hr>
                                        <p style=""margin: 0;"">Dolce gourmando Inc</p>
                                        <p style=""margin: 0;"">Address</p>
                                        <p style=""margin: 0;"">City, Province, Zip</p>
                                    </div>
                                    <div style=""width: 25%;"">
                                        <h3>BILLING ADDRESS</h3>
                                        <hr>
                                        <p style=""margin: 0;"">Dolce gourmando Inc</p>
                                        <p style=""margin: 0;"">Address</p>
                                        <p style=""margin: 0;"">City, Province, Zip</p>
                                    </div>
                                </div>
                                <div style=""display: flex; flex-direction: column;"">
                                    <table style=""width: 100%; border-collapse: collapse;border-bottom: 2px solid black;"">
                                        <thead>
                                            <tr style=""border-bottom: 2px solid black; padding: 4px;"">
                                                <th style=""text-align: left;padding-bottom: 10px;"">ITEM DESCRIPTION</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">ITEM #</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">Date Expected</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">QUANTITY</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">UNIT RATE</th>
                                                <th style=""text-align: left;padding-bottom: 10px;"">AMOUNT</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                    <div style=""float: right;"">
                                        <table style=""float: right;font-size: 18px; border-collapse: collapse;"">
                                             <tbody>
                                             </tbody>                                            
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px;"">Subtotal</td>
                                                <td style=""padding: 8px;""></td>
                                            </tr>
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px;"">Discounts</td>
                                                <td style=""padding: 8px;"">Discounts</td>
                                            </tr>
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px;"">Tax</td>
                                                <td style=""padding: 8px;"">Tax</td>
                                            </tr>
                                            <tr style=""border-bottom: 2px solid black;"">
                                                <td style=""padding: 8px;"">Shipping</td>
                                                <td style=""padding: 8px;"">Shipping</td>
                                            </tr>
                                            <tr style=""border-bottom: 1px solid grey;"">
                                                <td style=""padding: 8px; font-weight: bold;"">Order Total</td>
                                                <td style=""padding: 8px; font-weight: bold;""></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </body>
                            </html>";

            // Create a byte array to hold the PDF content
            byte[] pdfBytes;

            // Use a memory stream to generate the PDF content
            using (MemoryStream pdfMemoryStream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(dynamicHtml, pdfMemoryStream);
                pdfBytes = pdfMemoryStream.ToArray();
            }

            // Return the PDF as a file attachment in the response
            return File(pdfBytes, "application/pdf", "output.pdf");
        }
    }
}
