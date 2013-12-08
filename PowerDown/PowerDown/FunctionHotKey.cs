using PowerDown.HDLibrary.Wpf.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PowerDown
{
	[Serializable]
	public class FunctionHotKey : HotKey
	{
		private Action _function;
		public FunctionHotKey(Action f, Key key, ModifierKeys modifiers, bool enabled)
			: base(key, modifiers, enabled)
		{
			_function = f;
		}

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				if (value != name)
				{
					name = value;
					OnPropertyChanged(name);
				}
			}
		}

		protected override void OnHotKeyPress()
		{
			_function.Invoke();
		}

		public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("function", _function.GetHashCode());
		}

	}
}