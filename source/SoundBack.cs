using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QuartzTypeLib;  
using System.Threading;


namespace 俄罗斯1
{
	/// <summary>
	/// SoundBack 的摘要说明。
	/// </summary>
	public class SoundBack//背景音乐播放
	{
		private const int WM_APP = 0x8000;  
		private const int WM_GRAPHNOTIFY = WM_APP + 1;  
		private const int EC_COMPLETE = 0x01;  
		private const int WS_CHILD = 0x40000000;  
		private const int WS_CLIPCHILDREN = 0x2000000;  

		private FilgraphManager m_objFilterGraph = null;  
		private IBasicAudio m_objBasicAudio = null;  
		
		private IMediaEvent m_objMediaEvent = null;  
		private IMediaEventEx m_objMediaEventEx = null;  
		
		private IMediaControl m_objMediaControl = null;

		private Thread t=null;
		private string paths1=null;
		private string paths2=null;

		public SoundBack()
		{
			this.paths1=@"Wav\back1.mid";
			this.paths2=@"Wav\back2.mid";
		}
		private void init(string s)//初始播放器
		{
			try
			{
				m_objFilterGraph = new FilgraphManager();  
				m_objFilterGraph.RenderFile(s);
		
				m_objBasicAudio = m_objFilterGraph as IBasicAudio;  

				m_objMediaEvent = m_objFilterGraph as IMediaEvent;  

				m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;  

				m_objMediaControl = m_objFilterGraph as IMediaControl;  
			}
			catch{}
		}
		public void music_start()
		{
			try
			{
				if(this.t!=null)
				{
					if(this.t.IsAlive)
						this.t.Abort();
				}
				this.t=new Thread(new ThreadStart(this.music_Runing));
				this.t.IsBackground=true;
				this.t.Start();
			}
			catch{}
			
		}
		public void music_Runing()
		{
			try
			{
			int n=0;
			while(true)
			{
				if(m_objMediaControl!=null)
				this.m_objMediaControl.Stop();
				if(n==0)
					this.init(this.paths1);
				else
					this.init(this.paths2);

				if(m_objMediaControl!=null)
				{
					m_objMediaControl.Run(); 
				}
				if(n==0)
				Thread.Sleep(120000);
				else
					Thread.Sleep(40000);
				n=1-n;
			}
			}
			catch{}
		}
		public void music_stop()
		{
			try
			{
				if(this.t!=null)
				{
					if(this.t.IsAlive)
						this.t.Abort();
				}
		
				if(m_objMediaControl!=null)
				{
					this.m_objMediaControl.Stop();
					m_objMediaControl=null;
				}
			}
			catch{}
		}
	}
}
