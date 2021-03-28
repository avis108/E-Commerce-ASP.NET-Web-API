using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using E_Commerce_API.Repository;
using E_Commerce_API.Models;
using E_Commerce_API.JsonHeplerClass;
using E_Commerce_API.UnitOfWork;
using E_Commerce_API.CustomAttributes.Validation;
using E_Commerce_API.CustomAttributes.Exception;

namespace E_Commerce_API.Controllers
{
	[RoutePrefix("api/Customer")]
	[CusomExceptionAttribute]
	public class CustomerController : ApiController
	{
		private IUnitOfwork unitOfwork;
		public CustomerController()
		{
			this.unitOfwork = new UnitWork(new E_CommContext());
		}

		[HttpGet]
		[Route("GetAccountDetails")]
		public HttpResponseMessage GetCustomerAccount(int CustomerID)
		{
			Customer customer = unitOfwork.customerRepository.FindByID(CustomerID);
			if (customer != null)
			{
				CustomerJsonMapper customerJsonMapper = JsonUtility.CustomerJsonHelper(customer);
				return Request.CreateResponse(HttpStatusCode.OK, customerJsonMapper);
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found with CustomerID :" + CustomerID.ToString());
			}
		}

		[HttpPost]
		[Route("CreateAccount")]
		[EmailAddressValidation]
		public HttpResponseMessage CreateCustomerAccount(Customer customer)
		{
			if (ModelState.IsValid)
			{
				Customer createdCustomer = unitOfwork.customerRepository.Create(customer);
				unitOfwork.Save();
				CustomerJsonMapper customerJsonMapper = JsonUtility.CustomerJsonHelper(customer);

				HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.Created, customerJsonMapper);
				responseMessage.Headers.Location = new Uri(Request.RequestUri.
					AbsoluteUri.Replace("CreateAccount", "") + "GetAccountDetails/?CustomerID=" + customer.CustomerID.ToString());
				return responseMessage;
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

	}
}
