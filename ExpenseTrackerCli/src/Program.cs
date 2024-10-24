using ExpenseTrackerCli.src.cli;
using ExpenseTrackerCli.src.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerCli.src.models;

namespace ExpenseTrackerCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var expenseRepo = new ExpenseRepository();

                if (args.Length == 0)
                {
                    Console.WriteLine("No command provided. Use 'add', 'show', 'edit', 'showbymonth' or 'delete'.");
                    return;
                }

                var commandName = args[0].ToLower();
                ICommandHandler commandHandler = null;

                switch (commandName)
                {
                    case "add":
                        commandHandler = new AddCommand();
                        break;
                    case "list":
                        commandHandler = new ListCommand();
                        break;
                    case "remove":
                        commandHandler = new RemoveCommand();
                        break;
                    case "update":
                        commandHandler = new UpdateCommand();
                        break;
                    case "summary":
                        commandHandler = new SummaryCommand();
                        break;
                    case "summary--":
                        commandHandler = new ShowSummaryByMonth();
                        break;
                    default:
                        Console.WriteLine("Command not exists");
                        return;
                }

                if (commandHandler != null)
                {
                    commandHandler.Execute(args.Skip(1).ToArray(), expenseRepo);
                }
            }
        }

    }
}