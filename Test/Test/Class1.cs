using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Class1
    {
        public string name;

        public int age;

        public void getInput()
        {
            Console.WriteLine("Enter the name of the user: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the age of the user: ");
            age = Convert.ToInt16(Console.ReadLine());
        }

        public void getOutput()
        {
            Console.WriteLine(name + " is of the age " + age);

        }
    }
}