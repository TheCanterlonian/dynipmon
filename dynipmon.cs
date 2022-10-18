using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Data;
//dynipmon by Tiffany Darling
namespace dynipmon
{
	class Program
	{
		static void Main(string[] args)
		{
			//check the log file exists and if not, create it
			//
		}
		//checks if a file exists and if it doesn't, creates the file so it does exist
		static bool fileInsurance(string fileToEnsure) //returns 1 if file exists, 0 if file created
		{
			if (!(File.Exists(fileToEnsure)))
			{
				File.Create(fileToEnsure);
				return 0;
			}
			return 1;
		}
	}
}
