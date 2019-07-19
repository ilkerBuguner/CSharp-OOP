using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] errorArgs = command.Split("|").ToArray();

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = errorFactory.GetError(date, level, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                logger.Log(error);
            }

            Console.WriteLine(logger.ToString());
        }
    }
}
