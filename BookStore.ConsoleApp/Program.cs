using BookStore.ConsoleApp.Commands;
using CommandLine;
using System.Windows.Input;

class Program
{
	static void Main()
	{
		// call help command
		string command = "--help";
		var args = command.Split();
		Parser.Default
			  .ParseArguments<GetCommand, BuyCommand>(args)
			  .WithParsed<ICommand>(t => t.Execute(args));

		while (true)
        {
			// input command
			Console.WriteLine("Input command:");
			command = Console.ReadLine();
			Console.WriteLine();
			args = command.Split();
			Parser.Default
				  .ParseArguments<GetCommand, BuyCommand>(args)
				  .WithParsed<ICommand>(t => t.Execute(args));

			bool isFinish = false;
            while (true)
            {
				Console.WriteLine("\nFinish? (yes, no)");
				command = Console.ReadLine();
				if (command.ToUpper() == "yes".ToUpper() || command.ToUpper() == "no".ToUpper())
				{
					if (command.ToUpper() == "yes".ToUpper())
						isFinish = true;
					else if (command.ToUpper() == "no".ToUpper())
						isFinish = false;
					else
					{
						Console.WriteLine("Wrong command");
						continue;
					}
					Console.WriteLine();
					break;
				}
			}
			if (isFinish)
				break;
		}
	}
}
