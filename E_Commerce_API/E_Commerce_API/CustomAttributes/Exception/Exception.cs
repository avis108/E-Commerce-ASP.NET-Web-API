using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;

namespace E_Commerce_API.CustomAttributes.Exception
{
	public class CusomExceptionAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			actionExecutedContext.Response = 
				new System.Net.Http.HttpResponseMessage(HttpStatusCode.NotImplemented);
		}
	}
}