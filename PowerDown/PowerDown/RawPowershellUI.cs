﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation.Host;

namespace PowerDown
{
	public class TextBlockUI : PSHostRawUserInterface 
	{
		private ConsoleColor _back;
		private ConsoleColor _fore;

		public override ConsoleColor BackgroundColor
		{
			get
			{
				return _back;
			}
			set
			{
				_back = value;
			}
		}

		public override Size BufferSize
		{
			get;
			set;
		}

		public override Coordinates CursorPosition
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override int CursorSize
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override void FlushInputBuffer()
		{
			throw new NotImplementedException();
		}

		public override ConsoleColor ForegroundColor
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override BufferCell[,] GetBufferContents(Rectangle rectangle)
		{
			throw new NotImplementedException();
		}

		public override bool KeyAvailable
		{
			get { throw new NotImplementedException(); }
		}

		public override Size MaxPhysicalWindowSize
		{
			get { throw new NotImplementedException(); }
		}

		public override Size MaxWindowSize
		{
			get { throw new NotImplementedException(); }
		}

		public override KeyInfo ReadKey(ReadKeyOptions options)
		{
			throw new NotImplementedException();
		}

		public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill)
		{
			throw new NotImplementedException();
		}

		public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
		{
			throw new NotImplementedException();
		}

		public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
		{
			throw new NotImplementedException();
		}

		public override Coordinates WindowPosition
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override Size WindowSize
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override string WindowTitle
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
