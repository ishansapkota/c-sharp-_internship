using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Parent:interfaceClass
    {
        private string name;
        public string Name
        {
            get; set;
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            } 
            set
            {
                if(value==43)
                {
                    age = value;
                }

            }
        }

        public void getInfo()
        {
            Console.WriteLine("Enter the name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter the age: ");
            Age = Convert.ToInt32(Console.ReadLine());
        }

        public void showInfo()
        {
            Console.WriteLine(Name + " of the age " + Age);
        }

        public virtual void eat()
        {
            Console.WriteLine("I eat food.");
        }

        public virtual void sleep()
        {
            Console.WriteLine("I sleep at 11 pm");
        }

    }
}


