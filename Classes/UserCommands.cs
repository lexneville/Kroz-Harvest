using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class UserCommands
    {
        public string Look { get; set; }
        public string Take { get; set; }
        public string Use { get; set; }

        public void Actions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Your options are:" +
                "Look" +
                "Take" +
                "Use" +
                "Move");
            Console.ReadLine();
        }


    }
}
