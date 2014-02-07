using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerDown
{
	interface IShowOutput
	{
		void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value);
		void Write(string value);
		void WriteLine(string value);
	}
}
