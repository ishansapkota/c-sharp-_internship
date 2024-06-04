using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Arrayclass
    {
        string[] names = new string[3];

        public void GetName()
        {
            for(int i=0;i<3;i++)
            {
                names[i] = Console.ReadLine();
            }
            
        }

        public void DisplayName()
        {
            for(int i=0;i<3;i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
    
 
}
