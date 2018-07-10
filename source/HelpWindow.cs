using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ����˹1
{
	/// <summary>
	/// HelpWindow ��ժҪ˵����
	/// </summary>
	public class HelpWindow : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HelpWindow(Form1 f)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			Point p=new Point(f.Location.X+50,f.Location.Y+30);
			this.Location=p;

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HelpWindow));
			// 
			// HelpWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(328, 544);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "HelpWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Click += new System.EventHandler(this.HelpWindow_Click);
			this.Load += new System.EventHandler(this.HelpWindow_Load);

		}
		#endregion

		private void HelpWindow_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.OK;
		
		}

		private void HelpWindow_Load(object sender, System.EventArgs e)
		{
			this.Opacity=0.7;
			this.TopMost=true;
		}

		
	}
}
