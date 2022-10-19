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
			if (!(args.Length == 0)) //checks if any arguments were used
			{
				//makes all arguments lowercase
				for (int i = 0; i < args.Length; i++)
				{
					args[i] = args[i].ToLower();
				}
				//checks if "skip logging" option was passed
				if (args.Contains("s"))
				{
					//start the async task for checking the IP address and sending it to standard output
				}
			}
			else
			{
				fileInsurance("./dim.log"); //Ensure the log file
				bool configExisted = fileInsurance("./dynipmon.cfg"); //Ensure the config file
				//initialize function-wide variables
				string logFile = "./dim.log"
				string currentFile = "./dynipmon.cfg"
				//initialize program state
				if (!(configExisted)) //see if it didn't exist and if not then try to initialize the file
				{
					overwriteFile(currentFile, "./public-ip.txt");
					//no matter what happens, don't exit the block without doing this
					currentFile = File.ReadAllText(currentFile);
				}
				else //otherwise just load from the file
				{
					//no matter what happens, don't exit the block without doing this
					currentFile = File.ReadAllText(currentFile);
				}
				appendFile(logFile, "Dynipmon program start.\n");
				//grab the last recorded IP address in the current working file
				string recordedIP = File.ReadAllText(currentFile);
				appendFile(logFile, "Initially recorded IP was: " + recordedIP + "\n");
				//start the two async tasks for checking & recording the IP address and waiting for input & interupting the program tasks
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
		//overwrites a file in entirety, also handles errors associated with file overwrites
		static bool overwriteFile(string file, string text) //returns True if overwrite succeeds, False if it fails
		{
			//
		}
		//appends a file with new content to be added, also handles errors associated with concatenation
		static bool appendFile(string file, string content) //returns True if overwrite succeeds, False if it fails
		{
			//
		}
		//checks to see what the ip address is
		static string checkIP() //returns current IP address
		{
			//
		}
	}
}
