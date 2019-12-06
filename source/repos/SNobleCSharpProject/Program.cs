using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SNobleCSharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            AppTaskManager initPrompt = new AppTaskManager();

            initPrompt.InitPrompt();

            AppTaskManager.MainMenu();

        }
    }
}
