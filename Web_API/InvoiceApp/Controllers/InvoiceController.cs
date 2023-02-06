using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InvoiceApp.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    
    public class InvoiceController : ControllerBase
    {

        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<List<DetailedInvoice>>> GetInvoices(string searchKey)
        {
            var list = _invoiceService.GetInvoiceList(searchKey);

            if(list == null) { 
                NotFound();
            }

            return Ok(list);
        }

        [HttpPost]
        public ActionResult PostInvoice(string customerCode, string amount)
        {
            _invoiceService.AddInvoice(customerCode, amount);

            return Ok("Invoice added succussfully");
        }

    }
}
