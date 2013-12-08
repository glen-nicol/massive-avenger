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
		private HotKey OpenCloseToggle;
		public bool Open { get; private set; }

		public MainWindow()
		{
			InitializeComponent();
			Width = System.Windows.SystemParameters.PrimaryScreenWidth;
			Left = 0;
			Top = 0;
			Open = true;

			Loaded += Window_Loaded;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			HotKeyHost hotKeyHost = new HotKeyHost((HwndSource)HwndSource.FromVisual(App.Current.MainWindow));
			hotKeyHost.AddHotKey(new FunctionHotKey(ToggleOpen ,Key.F10, ModifierKeys.Control | ModifierKeys.Shift, true));

		}

		private void ToggleOpen()
		{
			if (Open)
			{
				Height = 0;
			}
			else
			{
				Height = 500;
			}
			Open = !Open;
		}
	}
}
