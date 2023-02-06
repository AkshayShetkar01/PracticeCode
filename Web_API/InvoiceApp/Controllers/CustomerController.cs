using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Linq;
using System.Threading;

namespace InvoiceApp.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult GetCustomerList()
        {
            //Thread.Sleep(2000);

            //var list = new List<Customer>();



            try
            {
                Console.WriteLine(this.HttpContext.Request.Headers["userName"].ToString());
                //if (this.HttpContext.Request.Headers.Keys.Contains("userName"))
                //{
                    
                    var userName = this.HttpContext.Request.Headers["userName"].ToString();
                    

                    if (userName.ToUpper() == "AKSHAY")
                    {
                        var list = _customerService.GetCustomerList();
                        if (list != null)
                        {
                            return Ok(list);
                        }                 
                    }
                    else
                    {
                        throw new Exception("Invalid User Name passed with request.");
                    }

                //}
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            return NotFound("user not found");
            //if (userName == "Akshay")
            //{
            //    list = _customerService.GetCustomerList();

            //    if (list == null)
            //    {
            //        return NotFound();
            //    }
            //}else
            //{
            //    Console.WriteLine("User not valid");
            //}

            //return Ok(list);
        }

        [HttpPost]
        [Route("/add")]
        public ActionResult AddCustomer(string firstName, string lastName) {

            var result = _customerService.AddCustomer(firstName, lastName);

            if (result > 0)
            {
                return Ok("Customer added successfully");
            }
            else
            {
                return NotFound();
            }
        
        }

        [HttpDelete]
        [Route("/delete")]

        public ActionResult DeleteCustomer(string customerCode)
        {
            try
            {
                var deleteCustomerResult = _customerService.DeleteCustomer(customerCode);

                if (deleteCustomerResult > 0)
                {
                    return Ok("Customer deleted successfully");
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            { 
                return NotFound(ex.Message);
            }

       
        }

        [HttpPut]
        [Route("/update")]

        public ActionResult UpdateCustomer(string firstName ,string customerCode )
        {
            try
            {
                var updateCustomerResult = _customerService.UpdateCustomer(firstName, customerCode);

                if (updateCustomerResult > 0)
                {
                    return Ok("Customer updated successfully ");
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                return NotFound();
            }

           

        }

    }
}
