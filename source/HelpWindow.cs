using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace 俄罗斯1
{
	/// <summary>
	/// HelpWindow 的摘要说明。
	/// </summary>
	public class HelpWindow : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HelpWindow(Form1 f)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			Point p=new Point(f.Location.X+50,f.Location.Y+30);
			this.Location=p;

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
