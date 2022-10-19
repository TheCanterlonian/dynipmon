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
			Console.WriteLine("Dynipmon starting...");
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
		//the async method for checking the ip and sending it directly to stdout
		async Task checkAndSkipAsync()
		{
			string ip = checkIP(); //gets the ip
			Console.Out.WriteLine(ip); //writes to standard output
			breakTime(); //takes a break
		}
		//the async method for checking the ip and recording it in the ip file
		async Task checkAndLogAsync(string ipFile, string logFile)
		{
			string ipNew = checkIP(); //gets new ip
			string ipContent = File.ReadAllText(ipFile); //checks recorded ip
			if (!(ipNew == ipContent)) //checks if they're not identical
			{
				//meat & potatoes block
				appendFile(logFile, "IP changed from: " + ipContent + "\n");
				appendFile(logFile, "New IP is now: " + ipNew + "\n");
				overwriteFile(ipFile, ipNew);
			}
			breakTime(); //takes a break
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
		//appends a file with new content to be added, also handles errors associated with file concatenation
		static bool appendFile(string file, string content) //returns True if overwrite succeeds, False if it fails
		{
			//
		}
		//checks to see what the ip address is
		static string checkIP() //returns current IP address
		{
			string currentAddress = "";
			WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
			using (WebResponse response = request.GetResponse())
			{
				using (StreamReader stream = new StreamReader(response.GetResponseStream()))
				{
					currentAddress = stream.ReadToEnd();
					stream.Close();
				}
				int first = currentAddress.IndexOf("Address: ") + 9;
				int last = currentAddress.LastIndexOf("</body>");
				currentAddress = currentAddress.Substring(first, last - first);
			}
			return currentAddress;
		}
		static void breakTime() //lets the program relax for a predetermined amount of time
		{
			/*
			waits for a predetermined amount of miliseconds
			60000 milis is 1 minute (for normal operating)
			3600000 milis is 1 hour (for debugging)
			*/
			Thread.Sleep(3600000);
		}
	}
}
