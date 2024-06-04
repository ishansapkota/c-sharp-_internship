using System;
using SecondDay;

namespace Assembly2
{

    class Assembly2DerivedClass:testBaseClass
    {
        public void getInfo()
        {
            //not accessible
            /*Console.WriteLine(id);
            Console.WriteLine(description);*/

            //accessible
            Console.WriteLine(name);
            Console.WriteLine(address);
            Console.WriteLine(hobby);
        }

    }

    class Assembly2OtherClass
    {
        public void getInfo()
        {
            testBaseClass testbsecls = new testBaseClass();
            
            //not accessible
            /*Console.WriteLine(testbsecls.id);
            Console.WriteLine(testbsecls.address);
            Console.WriteLine(testbsecls.description);
            Console.WriteLine(testbsecls.hobby);*/

            //accessible
            Console.WriteLine(testbsecls.name);
          
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Assembly2DerivedClass as2derivedcls = new Assembly2DerivedClass();
            as2derivedcls.getInfo();

            Assembly2OtherClass as2othercls = new Assembly2OtherClass();
            as2othercls.getInfo();

        }
    }
}
