using DataGen.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Validation.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            var publishManager = PublishManager.Create();

            publishManager.DisplayMenu();
        }
    }
}
