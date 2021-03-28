using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using E_Commerce_API.Repository;
using E_Commerce_API.Models;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Http;
using E_Commerce_API.UnitOfWork;


namespace E_Commerce_API.CustomAttributes.Validation
{
	public class EmailAddressValidation : ActionFilterAttribute
	{
		private IUnitOfwork unitOfwork = new UnitWork(new E_CommContext());
		
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			var data = (Customer)actionContext.ActionArguments["customer"];
			bool flag = unitOfwork.customerRepository.FindByEmailAddress(data.EmailAddress);
			if (flag)
			{
				actionContext.Response = actionContext.Request.
					CreateResponse(System.Net.HttpStatusCode.Forbidden, data.EmailAddress + " EmailAddress is already taken");
				
			}
		}

		
	}
}