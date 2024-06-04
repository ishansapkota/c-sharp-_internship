using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{ 
    class Child:Parent
    {
        public override void eat()
        {
            Console.WriteLine("I love burgers");
        }
        public override void sleep()
        {
            Console.WriteLine("I sleep at 12 am.");
        }
    }
}
