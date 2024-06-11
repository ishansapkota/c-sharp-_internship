using System;

namespace Test
{
    class Program

    {
        static void Main(string[] args)
        {
            //Normal class and object problem
            Class1 class1 = new Class1();
            class1.getInput();
            class1.getOutput();

            //Utilizing inheritance
            Parent parentobj = new Parent();
            parentobj.getInfo();
            parentobj.showInfo();
            parentobj.eat();
            parentobj.sleep();

            Child childobj = new Child();
            childobj.getInfo();
            childobj.showInfo();
            childobj.eat();
            childobj.sleep();

            Arrayclass[] arrayclass = new Arrayclass[2];
            for (int i = 0; i < 2; i++)
            {
                arrayclass[i] = new Arrayclass();
                arrayclass[i].GetName();
            }

            Console.WriteLine("---------------------");

            for (int i = 0; i < 2; i++)
            {
                arrayclass[i].DisplayName();
            }


/*            Arrayclass arrayclass = new Arrayclass();
            arrayclass.GetName();
            arrayclass.DisplayName();
*/        }
    }
}
