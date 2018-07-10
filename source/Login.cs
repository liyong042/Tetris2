using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace 俄罗斯1
{
	
	public class Login : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtAlias;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.TextBox txtHost;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		//tcpClient是Login的一个公共属性，它用于创建客户端套接字
		public TcpClient tcpClient;
		private System.Windows.Forms.TextBox textBox1;
		private 控件制作.UserControl1 userControl11;
		private 控件制作.UserControl1 userControl12;
		//Alias是Login的一个公共属性，它向ChatClient窗体传送用户名
		public string Alias="";



		public Login()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Login));
			this.txtAlias = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.userControl11 = new 控件制作.UserControl1();
			this.userControl12 = new 控件制作.UserControl1();
			this.SuspendLayout();
			// 
			// txtAlias
			// 
			this.txtAlias.Location = new System.Drawing.Point(104, 40);
			this.txtAlias.MaxLength = 8;
			this.txtAlias.Name = "txtAlias";
			this.txtAlias.Size = new System.Drawing.Size(128, 21);
			this.txtAlias.TabIndex = 1;
			this.txtAlias.Text = "";
			// 
			// txtPort
			// 
			this.txtPort.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPort.Location = new System.Drawing.Point(112, 155);
			this.txtPort.Name = "txtPort";
			this.txtPort.ReadOnly = true;
			this.txtPort.Size = new System.Drawing.Size(88, 21);
			this.txtPort.TabIndex = 11;
			this.txtPort.Text = "1234";
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(104, 128);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(120, 21);
			this.txtHost.TabIndex = 9;
			this.txtHost.Text = "127.0.0.1";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 72);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.Size = new System.Drawing.Size(128, 21);
			this.textBox1.TabIndex = 12;
			this.textBox1.Text = "134";
			// 
			// userControl11
			// 
			this.userControl11.Image = ((System.Drawing.Image)(resources.GetObject("userControl11.Image")));
			this.userControl11.Location = new System.Drawing.Point(40, 200);
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(64, 24);
			this.userControl11.TabIndex = 13;
			this.userControl11.Text = "userControl11";
			this.userControl11.Click += new System.EventHandler(this.userControl11_Click);
			this.userControl11.MouseEnter += new System.EventHandler(this.userControl11_MouseEnter);
			this.userControl11.MouseLeave += new System.EventHandler(this.userControl11_MouseLeave);
			// 
			// userControl12
			// 
			this.userControl12.Image = ((System.Drawing.Image)(resources.GetObject("userControl12.Image")));
			this.userControl12.Location = new System.Drawing.Point(152, 200);
			this.userControl12.Name = "userControl12";
			this.userControl12.Size = new System.Drawing.Size(64, 24);
			this.userControl12.TabIndex = 14;
			this.userControl12.Text = "userControl12";
			this.userControl12.Click += new System.EventHandler(this.userControl12_Click);
			this.userControl12.MouseEnter += new System.EventHandler(this.userControl11_MouseEnter);
			this.userControl12.MouseLeave += new System.EventHandler(this.userControl11_MouseLeave);
			// 
			// Login
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.OldLace;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(248, 246);
			this.Controls.Add(this.userControl12);
			this.Controls.Add(this.userControl11);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txtAlias);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtHost);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
			this.Load += new System.EventHandler(this.Login_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region windows API
		//窗体的拖动
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();
		[DllImport("user32.dll")]
		public static extern bool SendMessage(IntPtr hwnd,int wMsg,int wParam,int lParam);
		public const int w=0x0112;
		public const int s=0xF010;
		public const int h=0x0002;
	
		#endregion

		private void Login_Load(object sender, System.EventArgs e)
		{
			this.TopMost=true;
		}

		private void userControl11_Click(object sender, System.EventArgs e)
		{
			txtAlias.Text=txtAlias.Text.Trim();
		
			if(txtAlias.Text.Length==0)
			{
				MessageBox.Show("请输入您的呢称!","提示信息",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				txtAlias.Focus();
				return;
			}
			try
			{
				//创建一个客户端套接字，它是Login的一个公共属性，将被传递给ChatClient窗体
				tcpClient=new TcpClient();
				//向指定的IP地址的服务器发出连接请求
				tcpClient.Connect(IPAddress.Parse(txtHost.Text),
					Int32.Parse(txtPort.Text));
				Alias=txtAlias.Text;
				this.DialogResult=DialogResult.OK;
			}
			catch
			{
				MessageBox.Show("服务器未开启","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				this.DialogResult=DialogResult.No;
			}
		}

		private void userControl12_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
		}

		private void Login_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle,w,s+h,0);
		}

		private void userControl11_MouseEnter(object sender, System.EventArgs e)
		{
			Label t=(Label)sender;
			Point p=new Point(t.Location.X,t.Location.Y);
			p.X--;
			p.Y--;
			t.Location=p;
			t.Width+=2;
			t.Height+=2;
			Sound.Play(9);
			
		}

		private void userControl11_MouseLeave(object sender, System.EventArgs e)
		{
			Label t=(Label)sender;
			Point p=new Point(t.Location.X,t.Location.Y);
			p.X++;
			p.Y++;
			t.Location=p;

			t.Width-=2;
			t.Height-=2;
		}

		

	}
}
