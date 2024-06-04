using System;

namespace SecondDay
{
    public class testBaseClass
    {
        private int id=1;
        public string name="Ishan";
        protected string address="Baneshwor";
        internal string description="I love football";
        protected internal string hobby="Trekking";

        public void getInfo()
        {
            Console.WriteLine(id);
            Console.WriteLine(name);
            Console.WriteLine(address);
            Console.WriteLine(description);
            Console.WriteLine(hobby);
        }
    }

    public class testDerivedClass : testBaseClass
    {
        public void getInfo()
        {
            //not accessible 
            //Console.WriteLine(id);

            //accessible
            Console.WriteLine(name);
            Console.WriteLine(address);
            Console.WriteLine(description);
            Console.WriteLine(hobby);
        }
    
    }

    public class testOtherClass
    {
        public void getInfo()
        {
            testBaseClass basecls = new testBaseClass();
            
            //not accessible
            /*Console.WriteLine(basecls.id);
            Console.WriteLine(basecls.address);*/

            //accessible
            Console.WriteLine(basecls.name);
            Console.WriteLine(basecls.description);
            Console.WriteLine(basecls.hobby);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            /*//base class 
            testBaseClass basecls = new testBaseClass();
            basecls.getInfo();

            //other class
            testOtherClass othercls = new testOtherClass();
            othercls.getInfo();*/

            /*ConstructorExamples consteg = new ConstructorExamples(5000);
            Console.WriteLine(consteg.Add(consteg.allowance));
            Console.WriteLine("Counter {0}", ConstructorExamples.getCount());*/

            //accessing private constructor with nested class 
            ConstructorExamples.NestedConstructorExamples nestedconsteg = new ConstructorExamples.NestedConstructorExamples();
            nestedconsteg.Test();

            //for static method we should access it directly using class without the use of the object
            Console.WriteLine("Counter {0}", ConstructorExamples.getCount());




        }
    }
}
