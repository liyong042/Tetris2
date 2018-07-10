using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace  俄罗斯1
{
	internal class Helpers1 
	{
		[Flags]
			public enum PlaySoundFlags : int 
		{
			SND_SYNC = 0x0000,  /* play synchronously (default) */ //同步
			SND_ASYNC = 0x0001,  /* play asynchronously */ //异步
			SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
			SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
			SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
			SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
			SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS = 0x00010000, /* name is a registry alias */
			SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
			SND_FILENAME = 0x00020000, /* name is file name */
			SND_RESOURCE = 0x00040004  /* name is resource name or atom */
		}

		[DllImport("winmm")]
		public static extern bool PlaySound( string szSound, IntPtr hMod, PlaySoundFlags flags );
	}
	internal class Helpers2 
	{
		[Flags]
			public enum PlaySoundFlags : int 
		{
			SND_SYNC = 0x0000,  /* play synchronously (default) */ //同步
			SND_ASYNC = 0x0001,  /* play asynchronously */ //异步
			SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
			SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
			SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
			SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
			SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS = 0x00010000, /* name is a registry alias */
			SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
			SND_FILENAME = 0x00020000, /* name is file name */
			SND_RESOURCE = 0x00040004  /* name is resource name or atom */
		}

		[DllImport("winmm")]
		public static extern bool PlaySound( string szSound, IntPtr hMod, PlaySoundFlags flags );
	}
	public class Sound
	{
		const string FILE_NAME = @"Wav\back1.mid";
		
		public static  void Play(int sign)
		{
			string strFileName;
			switch(sign)
			{
				case 1:
				strFileName= @"Wav\btn.wav";
					break;
				case 2:
					strFileName= @"Wav\fadelayer.wav";
					break;

				case 3:
					strFileName= @"Wav\fixup.wav";
					break;
				case 4:
					strFileName= @"Wav\flystar.wav";
					break;
				case 5:
					strFileName= @"Wav\lost.wav";
					break;
				case 6:
					strFileName= @"Wav\ReadyGo.WAV";
					break;
				case 7:
					strFileName= @"Wav\transform.wav";
					break;
				case 8:
					strFileName= @"Wav\useitem.wav";
					break;//BF.wav
				case 9:
					strFileName= @"Wav\BF.wav";
					break;
				default:
					strFileName= @"Wav\win.wav";
					break;

			}
			try
			{
				Helpers2.PlaySound( strFileName, IntPtr.Zero, Helpers2.PlaySoundFlags.SND_FILENAME | Helpers2.PlaySoundFlags.SND_ASYNC);				
			}
			catch{}
		}
	}
}
