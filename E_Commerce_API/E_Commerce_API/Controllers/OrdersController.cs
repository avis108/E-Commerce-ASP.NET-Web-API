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
using E_Commerce_API.CustomAttributes.Exception;

namespace E_Commerce_API.Controllers
{
	[RoutePrefix("EComm/Orders")]
	[CusomExceptionAttribute]
	public class OrdersController : ApiController
	{
		private IUnitOfwork unitOfwork;
		public OrdersController()
		{
			this.unitOfwork = new UnitWork(new E_CommContext());
		}

		[HttpGet]
		[Route("GetOrdersByPaging")]
		public HttpResponseMessage GetOrders([FromUri]int pageIndex = 1, [FromUri]int pagesize = 1)
		{
			List<Order> orders = unitOfwork.ordersRepository.GetOrders(pagesize, pageIndex).ToList();

			if (orders.Count == 0)
			{ 
				List<OrderJsonMapper> orderJsonMappers = JsonUtility.OrderJsonHelper(orders);

				HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, orderJsonMappers);
				return message;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Please provide a vaild PageIndex nad PageSize values");
			}
		}

		[HttpGet]
		[Route("GetOrdersByID")]
		public HttpResponseMessage GetOrderByID(int OrderID)
		{

			Order order = unitOfwork.ordersRepository.FindByID(OrderID);
			if (order != null)
			{
				OrderJsonMapper orderJsonMapper = JsonUtility.OrderJsonHelper(order);
				
				HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, orderJsonMapper);
				return message;
			}
			else
			{
				HttpResponseMessage message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "OrderID : " + ((int)OrderID).ToString() + " is not found");
				return message;
			}


		}

		[HttpPost]
		public HttpResponseMessage CreateOrder([FromBody]Order order, [FromUri] int customerID)
		{
			if (ModelState.IsValid)
			{
				Customer customer = unitOfwork.customerRepository.FindByID(customerID);
				if (customer == null)
				{

					HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.NotFound, "CustomerID :" + ((int)customerID).ToString() + " not found");
					return message;
				}
				else
				{
					order.Customer = customer;
					order.CreatedDateTime = DateTime.Now;

					unitOfwork.ordersRepository.Create(order);
					unitOfwork.Save();

					OrderJsonMapper orderJsonMapper = JsonUtility.OrderJsonHelper(order);

					HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, orderJsonMapper);
					var locationUri = Request.RequestUri.ToString().Replace(Request.RequestUri.Query, "");
					message.Headers.Location = new Uri(locationUri + "GetOrdersByID/" + order.OrderID);
					return message;
				}
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

	}
}
