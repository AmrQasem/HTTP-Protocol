using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{
    class Logger
    {
        public static void LogException(Exception ex)
        {
			// TODO: Create log file named log.txt to log exception details in it
			FileStream fs = new FileStream("E:\\F C I S\\Forth Year\\Http Protocol\\HTTP-Protocol\\HTTPServer\\Exception.txt", FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);
			// for each exception write its details associated with datetime
			sw.WriteLine(ex.Message , DateTime.Now);
			sw.Close();
		}
	}
}
