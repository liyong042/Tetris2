using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace 俄罗斯1
{
	/// <summary>
	/// keysSet 的摘要说明。
	/// </summary>
	public class keysSet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public keysSet()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			Point p=new Point(mainForm.Location.X+50,mainForm.Location.Y+30);
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 336);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 28);
			this.button1.TabIndex = 15;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(160, 336);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(56, 28);
			this.button2.TabIndex = 16;
			this.button2.Text = "取消";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(248, 328);
			this.tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.trackBar1);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(240, 303);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "界面设置";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(24, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(152, 72);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "旋转方向";
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(8, 40);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(112, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "1";
			this.radioButton2.Text = "逆时针";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Tag = "-1";
			this.radioButton1.Text = "顺时针";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Location = new System.Drawing.Point(24, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(152, 80);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "游戏难度";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 40);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(112, 32);
			this.radioButton4.TabIndex = 1;
			this.radioButton4.Tag = "1";
			this.radioButton4.Text = "高级";
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(8, 16);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(136, 24);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "0";
			this.radioButton3.Text = "初级";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(16, 240);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Minimum = 50;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(208, 45);
			this.trackBar1.SmallChange = 5;
			this.trackBar1.TabIndex = 10;
			this.trackBar1.Value = 100;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.ForeColor = System.Drawing.Color.Blue;
			this.label8.Location = new System.Drawing.Point(8, 216);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 24);
			this.label8.TabIndex = 9;
			this.label8.Text = "透明度";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(240, 303);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "键盘设置";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox5);
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.textBox3);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(32, 24);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(184, 272);
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(96, 232);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(72, 21);
			this.textBox5.TabIndex = 23;
			this.textBox5.Tag = "4";
			this.textBox5.Text = "";
			this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(96, 178);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(72, 21);
			this.textBox4.TabIndex = 22;
			this.textBox4.Tag = "3";
			this.textBox4.Text = "";
			this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(96, 124);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(72, 21);
			this.textBox3.TabIndex = 21;
			this.textBox3.Tag = "2";
			this.textBox3.Text = "";
			this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 70);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(72, 21);
			this.textBox2.TabIndex = 20;
			this.textBox2.Tag = "1";
			this.textBox2.Text = "";
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(72, 21);
			this.textBox1.TabIndex = 19;
			this.textBox1.Tag = "0";
			this.textBox1.Text = "";
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.Blue;
			this.label5.Location = new System.Drawing.Point(16, 232);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 24);
			this.label5.TabIndex = 18;
			this.label5.Text = "直接下落";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(16, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 32);
			this.label4.TabIndex = 17;
			this.label4.Text = "加速";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Blue;
			this.label3.Location = new System.Drawing.Point(16, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 24);
			this.label3.TabIndex = 16;
			this.label3.Text = "左移";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Blue;
			this.label2.Location = new System.Drawing.Point(16, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 15;
			this.label2.Text = "右移";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 14;
			this.label1.Text = "变形";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(240, 303);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "道具设置";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox12);
			this.groupBox4.Controls.Add(this.textBox11);
			this.groupBox4.Controls.Add(this.textBox10);
			this.groupBox4.Controls.Add(this.textBox9);
			this.groupBox4.Controls.Add(this.textBox8);
			this.groupBox4.Controls.Add(this.textBox7);
			this.groupBox4.Controls.Add(this.textBox6);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label23);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.label22);
			this.groupBox4.Location = new System.Drawing.Point(32, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(184, 280);
			this.groupBox4.TabIndex = 35;
			this.groupBox4.TabStop = false;
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(88, 246);
			this.textBox12.Name = "textBox12";
			this.textBox12.ReadOnly = true;
			this.textBox12.Size = new System.Drawing.Size(72, 21);
			this.textBox12.TabIndex = 41;
			this.textBox12.Tag = "11";
			this.textBox12.Text = "";
			this.textBox12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(88, 209);
			this.textBox11.Name = "textBox11";
			this.textBox11.ReadOnly = true;
			this.textBox11.Size = new System.Drawing.Size(72, 21);
			this.textBox11.TabIndex = 40;
			this.textBox11.Tag = "10";
			this.textBox11.Text = "";
			this.textBox11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(88, 176);
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(72, 21);
			this.textBox10.TabIndex = 39;
			this.textBox10.Tag = "9";
			this.textBox10.Text = "";
			this.textBox10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(88, 135);
			this.textBox9.Name = "textBox9";
			this.textBox9.ReadOnly = true;
			this.textBox9.Size = new System.Drawing.Size(72, 21);
			this.textBox9.TabIndex = 38;
			this.textBox9.Tag = "8";
			this.textBox9.Text = "";
			this.textBox9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(88, 98);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(72, 21);
			this.textBox8.TabIndex = 37;
			this.textBox8.Tag = "7";
			this.textBox8.Text = "";
			this.textBox8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(88, 61);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(72, 21);
			this.textBox7.TabIndex = 36;
			this.textBox7.Tag = "6";
			this.textBox7.Text = "";
			this.textBox7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(88, 24);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(72, 21);
			this.textBox6.TabIndex = 35;
			this.textBox6.Tag = "5";
			this.textBox6.Text = "";
			this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label20.ForeColor = System.Drawing.Color.Blue;
			this.label20.Location = new System.Drawing.Point(8, 172);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 24);
			this.label20.TabIndex = 27;
			this.label20.Text = "对4号";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.ForeColor = System.Drawing.Color.Blue;
			this.label21.Location = new System.Drawing.Point(8, 135);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(56, 24);
			this.label21.TabIndex = 26;
			this.label21.Text = "对3号";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.ForeColor = System.Drawing.Color.Blue;
			this.label18.Location = new System.Drawing.Point(8, 248);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 24);
			this.label18.TabIndex = 34;
			this.label18.Text = "对6号";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label23.ForeColor = System.Drawing.Color.Blue;
			this.label23.Location = new System.Drawing.Point(8, 61);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(56, 24);
			this.label23.TabIndex = 24;
			this.label23.Text = "对1号";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.Blue;
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 24);
			this.label6.TabIndex = 15;
			this.label6.Text = "切换道具";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.ForeColor = System.Drawing.Color.Blue;
			this.label19.Location = new System.Drawing.Point(8, 209);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(64, 24);
			this.label19.TabIndex = 28;
			this.label19.Text = "对5号";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label22.ForeColor = System.Drawing.Color.Blue;
			this.label22.Location = new System.Drawing.Point(8, 98);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 24);
			this.label22.TabIndex = 25;
			this.label22.Text = "对2号";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.groupBox5);
			this.tabPage4.Location = new System.Drawing.Point(4, 21);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(240, 303);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "音效设置";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButton5);
			this.groupBox5.Controls.Add(this.radioButton6);
			this.groupBox5.Location = new System.Drawing.Point(48, 24);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(136, 88);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			// 
			// radioButton5
			// 
			this.radioButton5.Checked = true;
			this.radioButton5.Location = new System.Drawing.Point(16, 16);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(112, 24);
			this.radioButton5.TabIndex = 0;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "0";
			this.radioButton5.Text = "开启背景音乐";
			this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(16, 48);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(112, 24);
			this.radioButton6.TabIndex = 2;
			this.radioButton6.Tag = "1";
			this.radioButton6.Text = "关闭背景音乐";
			this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// keysSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(248, 366);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "keysSet";
			this.Opacity = 0.9;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "参数设置";
			this.Load += new System.EventHandler(this.keysSet_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private static Form1 mainForm=null;
		private Keys[] k=new Keys[12];
         public static bool musicBack=true;
		private void init()
		{
			try
			{
				Array.Copy(Form1.key,0,this.k,0,this.k.Length);//备份数组
				foreach(System.Windows.Forms.Control t in this.groupBox3.Controls )
				{
					if(t is TextBox )
					{
					
						int n=int.Parse(t.Tag.ToString());
					
						t.Text=this.k[n].ToString();//Form1.key[n].ToString();
					}
				}
			
				foreach(System.Windows.Forms.Control t in this.groupBox4.Controls )
				{
					if(t is TextBox )
					{
					
						int n=int.Parse(t.Tag.ToString());
					
						t.Text=this.k[n].ToString();
					}
				}
			}
			catch{}

		}
		public static void getForm(Form1 f)
		{
			mainForm=f;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Form1.key=this.k;
			this.DialogResult=DialogResult.OK;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
		}


		private void trackBar1_Scroll_1(object sender, System.EventArgs e)
		{
			mainForm.Opacity=this.trackBar1.Value/100.0;
		}

		private void keysSet_Load(object sender, System.EventArgs e)
		{
			 init();
			if(Form1.GameLevel==0)// 游戏难度
				this.radioButton3.Checked=true;
			else
				this.radioButton4.Checked=true;
			//旋转方向
			if(Form1.GameDirect==-1)
				this.radioButton1.Checked=true;
			else
				this.radioButton2.Checked=true;
			//背景音乐
			if(keysSet.musicBack)
				this.radioButton5.Checked=true;
			else
				this.radioButton6.Checked=true;
			//透明度
			
		}
		//游戏难度设置
		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				RadioButton r=(RadioButton)sender;
				if(r.Checked)
				{
					Form1.GameLevel=int.Parse(r.Tag.ToString());
				}
			}
			catch
			{
				Form1.GameLevel=0;
			}

		}
		//游戏旋转方向设置
		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				RadioButton r=(RadioButton)sender;
				if(r.Checked)
				{
					Form1.GameDirect=int.Parse(r.Tag.ToString());
				}
			}
			catch
			{
				Form1.GameDirect=1;
			}
		}

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				TextBox t=(TextBox)sender;
				t.Text=e.KeyCode.ToString();
				int n=int.Parse(t.Tag.ToString());
				this.k[n]=e.KeyCode;
			}
			catch{
				this.init();
			}
		}

		private void radioButton5_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				RadioButton r=(RadioButton)sender;
				if(r.Checked)
				{
					int n=int.Parse(r.Tag.ToString());
					if(n==0)
					{
						mainForm.soundBack.music_start();
						keysSet.musicBack=true;
					}
					else
					{
						mainForm.soundBack.music_stop();
						keysSet.musicBack=false;
					}
				}
			}
			catch{}
		}

		

		
	}
}
