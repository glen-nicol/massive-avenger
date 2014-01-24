using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ComponentModel;

namespace PowerDown
{
	class PowershellTab : IPowershell, INotifyPropertyChanged
	{
		private StringBuilder _output = new StringBuilder();
		public string Output
		{
			get { return _output.ToString(); }
			private set { _output.Clear(); _output.Append(value); PropertyChange("Output"); }
		}
		private void AppendToOutput(string s)
		{
			_output.Append(s);
			PropertyChange("Output");
		}

		string IPowershell.WorkingDirectory
		{
			get { throw new NotImplementedException(); }
		}


		public bool IssueCommand(string c)
		{
			Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();

			Pipeline pipeline =runspace.CreatePipeline(c);
			pipeline.Commands.Add("Out-String");

			pipeline.Output.DataReady +=
				new EventHandler(HandleDataReady);
			pipeline.Error.DataReady +=
				new EventHandler(HandleDataReady);

			pipeline.InvokeAsync();
			pipeline.Input.Close();
			return true;
		}

		private void HandleDataReady(object sender, EventArgs e)
		{
			PipelineReader<PSObject> output =
				sender as PipelineReader<PSObject>;

			if (output != null)
			{
				while (output.Count > 0)
				{
					AppendToOutput(output.Read().ToString());
				}
				return;
			}

			PipelineReader<object> error =
				sender as PipelineReader<object>;

			if (error != null)
			{
				while (error.Count > 0)
				{
					AppendToOutput(error.Read().ToString());
				}
				return;
			}
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
