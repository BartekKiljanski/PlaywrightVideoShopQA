
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PlaywrightVideoShopQA.Hooks
{



	public class ConfigurationHelper : IConfigurationHelper
	{
		public string DefaultConnection => Configuration["AppSettings:DefaultConnection"];

		private static IConfigurationRoot Configuration { get; }

		static ConfigurationHelper()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			Configuration = builder.Build();
		}
	}


}
