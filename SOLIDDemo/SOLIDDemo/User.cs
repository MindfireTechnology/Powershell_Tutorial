using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SOLIDDemo
{
	public class User
	{
		public int Id { get; set; }

		[JsonPropertyName("first_name")]
		public string FirstName { get; set; }

		[JsonPropertyName("last_name")]
		public string LastName { get; set; }

		public string Email { get; set; }

		public string Gender { get; set; }

		[JsonPropertyName("ip_address")]
		public string IpAddress { get; set; }
	}
}
