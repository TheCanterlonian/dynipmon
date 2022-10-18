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
			//Ensure the log file
			fileInsurance("./dim.log");
			//Ensure the config file
			bool configExisted=fileInsurance("./dynipmon.cfg");
			//see if it didn't exist and if not then try to initialize the file
			if (!(configExisted))
			{
				try
				{
					WriteAllText("./dynipmon.cfg", "./public-ip.txt");
				}
				catch (IOException e)
				{
					Console.WriteLine("General input/output error.");
				}
				catch (UnauthorizedAccessException e)
				{
					Console.WriteLine("General permissions error.");
				}
				catch (SecurityException e)
				{
					Console.WriteLine("Specific permissions error.");
				}
			}
			else //otherwise just load from the file
			{
				string currentFile = ReadAllText("./dynipmon.cfg");
			}
		}
		//checks if a file exists and if it doesn't, creates the file so it does exist
		static bool fileInsurance(string fileToEnsure) //returns True if file exists, False if file created
		{
			if (!(File.Exists(fileToEnsure)))
			{
				File.Create(fileToEnsure);
				return False;
			}
			return True;
		}
	}
}
