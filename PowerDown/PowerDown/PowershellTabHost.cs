using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PowerDown
{
	class PowershellTabHost : PSHostUserInterface, INotifyPropertyChanged
	{
		private IGiveInput _input;
		private IShowOutput _output;
		
		private StringBuilder _commandOutput = new StringBuilder();
		public string Output
		{
			get { return _commandOutput.ToString(); }
			private set { _commandOutput.Clear(); _commandOutput.Append(value); PropertyChange("Output"); }
		}

		public string InputCommand { get; set; }
		private void AppendToOutput(string s)
		{
			_commandOutput.Append(s);
			PropertyChange("Output");
		}

		public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
		{
			throw new NotImplementedException();
		}

		public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
		{
			throw new NotImplementedException();
		}

		public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, System.Management.Automation.PSCredentialTypes allowedCredentialTypes, System.Management.Automation.PSCredentialUIOptions options)
		{
			throw new NotImplementedException();
		}

		public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
		{
			throw new NotImplementedException();
		}

		public override PSHostRawUserInterface RawUI
		{
			get { throw new NotImplementedException(); }
		}

		public override string ReadLine()
		{
			return _input.ReadLine();
		}

		public override SecureString ReadLineAsSecureString()
		{
			return _input.ReadLineAsSecureString();
		}

		public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
		{
			_output.Write(foregroundColor, backgroundColor, value);
		}

		public override void Write(string value)
		{
			_output.Write(value);
		}

		public override void WriteDebugLine(string message)
		{
			throw new NotImplementedException();
		}

		public override void WriteErrorLine(string value)
		{
			throw new NotImplementedException();
		}

		public override void WriteLine(string value)
		{
			_output.WriteLine(value);
		}

		public override void WriteProgress(long sourceId, ProgressRecord record)
		{
			throw new NotImplementedException();
		}

		public override void WriteVerboseLine(string message)
		{
			throw new NotImplementedException();
		}

		public override void WriteWarningLine(string message)
		{
			throw new NotImplementedException();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void PropertyChange(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
