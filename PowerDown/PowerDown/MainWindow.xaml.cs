using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using PowerDown.HDLibrary.Wpf.Input;
using System.Windows.Interop;

namespace PowerDown
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window 
	{
		//public string CurrentTabOutput { get { return _currentPowershell.Output; } }
		public IPowershell CurrentPowershell { get; private set; }
		private HotKeyHost _host;
		public bool Open { get; private set; }

		public MainWindow()
		{
			InitializeComponent();
			CurrentPowershell = new PowershellTab();
			ShowInTaskbar = false;
			Topmost = true;
			Width = System.Windows.SystemParameters.PrimaryScreenWidth;
			Left = 0;
			Top = 0;
			Open = true;
			DataContext = this;
			Loaded += Window_Loaded;
			Closing += Window_Closed;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			_host = new HotKeyHost((HwndSource)HwndSource.FromVisual(App.Current.MainWindow));
			_host.AddHotKey(new FunctionHotKey(ToggleOpen, Key.F10, ModifierKeys.Control | ModifierKeys.Shift, true));
		}
		private void Close_Clicked(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Window_Closed(object sender, CancelEventArgs e)
		{
			_host.Dispose();
		}

		private void ToggleOpen()
		{
			
			if (Open)
			{
				Visibility = System.Windows.Visibility.Hidden;
			}
			else
			{
				Visibility = System.Windows.Visibility.Visible;
			}
			Open = !Open;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			CurrentPowershell.IssueCommand("Get-process");
		}
	}
}
