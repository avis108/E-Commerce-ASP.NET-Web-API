using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Models
{
	[MetadataType(typeof(CustomerMetaData))]
	public partial class Customer
	{

	}

	[MetadataType(typeof(OrderlMetaData))]
	public partial class Order
	{

	}

	public class OrderlMetaData
	{
		[Required(ErrorMessage ="Quantity cannot be empty")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "TotalPrice cannot be empty")]
		public decimal TotalPrice { get; set; }

		[Required(ErrorMessage = "ItemName cannot be empty")]
		public string ItemName { get; set; }
	}

	public class CustomerMetaData
	{
		[Required(ErrorMessage = "EmailAddress cannot be empty")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required(ErrorMessage = "Address cannot be empty")]
		public string Address { get; set; }

		[Required(ErrorMessage = "CustomerName cannot be empty")]
		public string CustomerName { get; set; }
	}
}