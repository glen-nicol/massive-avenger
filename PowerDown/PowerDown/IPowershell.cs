using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerDown
{
	public interface IPowershell
	{
		string WorkingDirectory { get; }
		string Output { get; }
		bool IssueCommand(string c);
	}
}
