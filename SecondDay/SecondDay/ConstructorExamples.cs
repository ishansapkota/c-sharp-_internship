using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondDay
{
    public class ConstructorExamples
    {

        public int id,allowance;
        static int salary;

        private ConstructorExamples()
        {
            id = 5;
        }

        static ConstructorExamples()
        {
            salary = 10000;
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


