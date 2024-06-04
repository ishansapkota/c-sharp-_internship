using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//When Private constructors are made, it cannot be accessed by the object of that class rather you will have to make sure that another class is made inside that class making it a nested class, then from that inside class the private constructor 
//can be accessed

namespace SecondDay
{
    public class ConstructorExamples
    {

        public int id,allowance;
        static int salary;
        static int counter;

        private ConstructorExamples()
        {
            id = 5;
        }

        static ConstructorExamples()
        {
            salary = 10000;
        }


        //This static method cannot be called by the object of the class rather we will have to directly call it by the class.
        //eg: WRONG WAY 
        // ConstructorExample consteg = new ConstructorExample;
        //  consteg.getCount(); WRONG WAY
        //RIGHT WAY 
        // ConstructorExample.getCount(); RIGHT WAY

        public static int getCount()
        {
            return ++counter;
        }
        public class NestedConstructorExamples
        {
            public void Test()
            {
                ConstructorExamples coneg = new ConstructorExamples();
                Console.WriteLine(coneg.id);
            }
        }

        public ConstructorExamples(int allowance)
        {
            this.allowance = allowance;
        }

        public int Add(int b)
        {
            return salary + b;
        }
    }

}


