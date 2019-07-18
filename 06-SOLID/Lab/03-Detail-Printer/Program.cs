using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            Employee employee = new Employee("Ilker");
            Manager manager = new Manager("Sasho", new List<string>() { "vs 2019", "vs 2017" });
            List<IEmployee> employees = new List<IEmployee>() { manager, employee };

            DetailsPrinter printer = new DetailsPrinter(employees);

            printer.PrintDetails();
        }
    }
}
