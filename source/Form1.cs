using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;

namespace ����˹1
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	/// 
	public delegate void PaintDelegate(Graphics g);//���ƶԷ���Ϣ(�� �س�)
	public interface fail_start_Interface
	{
		void StartGame();
		void FailGame();
	}
	public class Form1 : System.Windows.Forms.Form,fail_start_Interface
	{
		private System.ComponentModel.IContainer components=null;
		
		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			this.init();

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
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.panel1 = new System.Windows.Forms.Panel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtSendContent = new System.Windows.Forms.TextBox();
			this.lstContent = new System.Windows.Forms.ListBox();
			this.user_Exerc = new �ؼ�����.UserControl1();
			this.user_start = new �ؼ�����.UserControl1();
			this.user_Exit = new �ؼ�����.UserControl1();
			this.user_send = new �ؼ�����.UserControl1();
			this.user_help = new �ؼ�����.UserControl1();
			this.use_set = new �ؼ�����.UserControl1();
			this.userControl11 = new �ؼ�����.UserControl1();
			this.user_stop = new �ؼ�����.UserControl1();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label_toolMess = new System.Windows.Forms.Label();
			this.panel_toolCon = new �Զ���ؼ�label.UserControl1();
			this.label_SmallTetirs1 = new �Զ���ؼ�_LabelSmallTetir.UserControl1();
			this.label_SmallTetirs2 = new �Զ���ؼ�_LabelSmallTetir.UserControl1();
			this.label_SmallTetirs3 = new �Զ���ؼ�_LabelSmallTetir.UserControl1();
			this.label_SmallTetirs4 = new �Զ���ؼ�_LabelSmallTetir.UserControl1();
			this.label_SmallTetirs5 = new �Զ���ؼ�_LabelSmallTetir.UserControl1();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(52)), ((System.Byte)(52)));
			this.panel1.Location = new System.Drawing.Point(390, 139);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(193, 336);
			this.panel1.TabIndex = 0;
			this.panel1.Click += new System.EventHandler(this.Form1_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(53)), ((System.Byte)(53)));
			this.panel2.Location = new System.Drawing.Point(290, 138);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(88, 147);
			this.panel2.TabIndex = 4;
			// 
			// txtSendContent
			// 
			this.txtSendContent.BackColor = System.Drawing.Color.White;
			this.txtSendContent.Location = new System.Drawing.Point(611, 312);
			this.txtSendContent.MaxLength = 30;
			this.txtSendContent.Multiline = true;
			this.txtSendContent.Name = "txtSendContent";
			this.txtSendContent.Size = new System.Drawing.Size(125, 20);
			this.txtSendContent.TabIndex = 10;
			this.txtSendContent.Text = "";
			this.txtSendContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendContent_KeyDown);
			this.txtSendContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSendContent_MouseDown);
			// 
			// lstContent
			// 
			this.lstContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(254)), ((System.Byte)(255)));
			this.lstContent.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(88)), ((System.Byte)(105)), ((System.Byte)(181)));
			this.lstContent.ItemHeight = 12;
			this.lstContent.Location = new System.Drawing.Point(611, 120);
			this.lstContent.Name = "lstContent";
			this.lstContent.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.lstContent.Size = new System.Drawing.Size(172, 184);
			this.lstContent.TabIndex = 9;
			this.lstContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstContent_MouseDown);
			// 
			// user_Exerc
			// 
			this.user_Exerc.Enabled = false;
			this.user_Exerc.Image = ((System.Drawing.Image)(resources.GetObject("user_Exerc.Image")));
			this.user_Exerc.Location = new System.Drawing.Point(616, 528);
			this.user_Exerc.Name = "user_Exerc";
			this.user_Exerc.Size = new System.Drawing.Size(73, 32);
			this.user_Exerc.TabIndex = 12;
			this.user_Exerc.Click += new System.EventHandler(this.user_Exerc_Click);
			this.user_Exerc.MouseEnter += new System.EventHandler(this.user_start_MouseEnter);
			this.user_Exerc.MouseLeave += new System.EventHandler(this.user_start_MouseLeave);
			// 
			// user_start
			// 
			this.user_start.Enabled = false;
			this.user_start.Image = ((System.Drawing.Image)(resources.GetObject("user_start.Image")));
			this.user_start.Location = new System.Drawing.Point(704, 472);
			this.user_start.Name = "user_start";
			this.user_start.Size = new System.Drawing.Size(73, 32);
			this.user_start.TabIndex = 14;
			this.user_start.Click += new System.EventHandler(this.user_start_Click);
			this.user_start.MouseEnter += new System.EventHandler(this.user_start_MouseEnter);
			this.user_start.MouseLeave += new System.EventHandler(this.user_start_MouseLeave);
			// 
			// user_Exit
			// 
			this.user_Exit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(223)), ((System.Byte)(253)), ((System.Byte)(255)));
			this.user_Exit.Image = ((System.Drawing.Image)(resources.GetObject("user_Exit.Image")));
			this.user_Exit.Location = new System.Drawing.Point(704, 528);
			this.user_Exit.Name = "user_Exit";
			this.user_Exit.Size = new System.Drawing.Size(73, 32);
			this.user_Exit.TabIndex = 13;
			this.user_Exit.Click += new System.EventHandler(this.user_Exit_Click);
			this.user_Exit.MouseEnter += new System.EventHandler(this.user_start_MouseEnter);
			this.user_Exit.MouseLeave += new System.EventHandler(this.user_start_MouseLeave);
			// 
			// user_send
			// 
			this.user_send.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(223)), ((System.Byte)(253)), ((System.Byte)(255)));
			this.user_send.Image = ((System.Drawing.Image)(resources.GetObject("user_send.Image")));
			this.user_send.Location = new System.Drawing.Point(744, 312);
			this.user_send.Name = "user_send";
			this.user_send.Size = new System.Drawing.Size(38, 20);
			this.user_send.TabIndex = 15;
			this.user_send.Click += new System.EventHandler(this.user_send_Click);
			this.user_send.MouseEnter += new System.EventHandler(this.user_start_MouseEnter);
			this.user_send.MouseLeave += new System.EventHandler(this.user_start_MouseLeave);
			// 
			// user_help
			// 
			this.user_help.Image = ((System.Drawing.Image)(resources.GetObject("user_help.Image")));
			this.user_help.Location = new System.Drawing.Point(576, 6);
			this.user_help.Name = "user_help";
			this.user_help.Size = new System.Drawing.Size(90, 20);
			this.user_help.TabIndex = 16;
			this.user_help.Click += new System.EventHandler(this.user_help_Click);
			this.user_help.MouseEnter += new System.EventHandler(this.user_start_MouseEnter);
			this.user_help.MouseLeave += new System.EventHandler(this.user_start_MouseLeave);
			// 
			// use_set
			// 
			this.use_set.Image = ((System.Drawing.Image)(resources.GetObject("use_set.Image")));
			this.use_set.Location = new System.Drawing.Point(482, 6);
			this.use_set.Name = "use_set";
			this.use_set.Size = new System.Drawing.Size(89, 20);
			this.use_set.TabIndex = 17;
			this.use_set.Click += new System.EventHandler(this.use_set_Click);
			this.use_set.MouseEnter += new System.EventHandler(this.user_start_MouseEnter);
			this.use_set.MouseLeave += new System.EventHandler(this.user_start_MouseLeave);
			// 
			// userControl11
			// 
			this.userControl11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(223)), ((System.Byte)(253)), ((System.Byte)(255)));
			this.userControl11.Image = ((System.Drawing.Image)(resources.GetObject("userControl11.Image")));
			this.userControl11.Location = new System.Drawing.Point(716, 6);
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(21, 19);
			this.userControl11.TabIndex = 18;
			this.userControl11.Click += new System.EventHandler(this.userControl11_Click);
			// 
			// user_stop
			// 
			this.user_stop.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(223)), ((System.Byte)(253)), ((System.Byte)(255)));
			this.user_stop.Image = ((System.Drawing.Image)(resources.GetObject("user_stop.Image")));
			this.user_stop.Location = new System.Drawing.Point(766, 6);
			this.user_stop.Name = "user_stop";
			this.user_stop.Size = new System.Drawing.Size(21, 19);
			this.user_stop.TabIndex = 19;
			this.user_stop.Click += new System.EventHandler(this.user_stop_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label_toolMess
			// 
			this.label_toolMess.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(53)), ((System.Byte)(53)));
			this.label_toolMess.ForeColor = System.Drawing.Color.Red;
			this.label_toolMess.Location = new System.Drawing.Point(390, 530);
			this.label_toolMess.Name = "label_toolMess";
			this.label_toolMess.Size = new System.Drawing.Size(193, 18);
			this.label_toolMess.TabIndex = 21;
			// 
			// panel_toolCon
			// 
			this.panel_toolCon.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(53)), ((System.Byte)(53)));
			this.panel_toolCon.ImageList = this.imageList1;
			this.panel_toolCon.Location = new System.Drawing.Point(390, 496);
			this.panel_toolCon.Name = "panel_toolCon";
			this.panel_toolCon.Size = new System.Drawing.Size(193, 16);
			this.panel_toolCon.TabIndex = 24;
			// 
			// label_SmallTetirs1
			// 
			this.label_SmallTetirs1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(45)), ((System.Byte)(45)), ((System.Byte)(45)));
			this.label_SmallTetirs1.Image = ((System.Drawing.Image)(resources.GetObject("label_SmallTetirs1.Image")));
			this.label_SmallTetirs1.Location = new System.Drawing.Point(17, 119);
			this.label_SmallTetirs1.Name = "label_SmallTetirs1";
			this.label_SmallTetirs1.Size = new System.Drawing.Size(97, 169);
			this.label_SmallTetirs1.TabIndex = 29;
			this.label_SmallTetirs1.Text = "userControl12";
			// 
			// label_SmallTetirs2
			// 
			this.label_SmallTetirs2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(45)), ((System.Byte)(45)), ((System.Byte)(45)));
			this.label_SmallTetirs2.Image = ((System.Drawing.Image)(resources.GetObject("label_SmallTetirs2.Image")));
			this.label_SmallTetirs2.Location = new System.Drawing.Point(140, 118);
			this.label_SmallTetirs2.Name = "label_SmallTetirs2";
			this.label_SmallTetirs2.Size = new System.Drawing.Size(97, 169);
			this.label_SmallTetirs2.TabIndex = 30;
			this.label_SmallTetirs2.Text = "userControl12";
			// 
			// label_SmallTetirs3
			// 
			this.label_SmallTetirs3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(45)), ((System.Byte)(45)), ((System.Byte)(45)));
			this.label_SmallTetirs3.Image = ((System.Drawing.Image)(resources.GetObject("label_SmallTetirs3.Image")));
			this.label_SmallTetirs3.Location = new System.Drawing.Point(16, 380);
			this.label_SmallTetirs3.Name = "label_SmallTetirs3";
			this.label_SmallTetirs3.Size = new System.Drawing.Size(97, 169);
			this.label_SmallTetirs3.TabIndex = 31;
			this.label_SmallTetirs3.Text = "userControl12";
			// 
			// label_SmallTetirs4
			// 
			this.label_SmallTetirs4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(45)), ((System.Byte)(45)), ((System.Byte)(45)));
			this.label_SmallTetirs4.Image = ((System.Drawing.Image)(resources.GetObject("label_SmallTetirs4.Image")));
			this.label_SmallTetirs4.Location = new System.Drawing.Point(139, 380);
			this.label_SmallTetirs4.Name = "label_SmallTetirs4";
			this.label_SmallTetirs4.Size = new System.Drawing.Size(97, 169);
			this.label_SmallTetirs4.TabIndex = 32;
			this.label_SmallTetirs4.Text = "userControl12";
			// 
			// label_SmallTetirs5
			// 
			this.label_SmallTetirs5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(45)), ((System.Byte)(45)), ((System.Byte)(45)));
			this.label_SmallTetirs5.Image = ((System.Drawing.Image)(resources.GetObject("label_SmallTetirs5.Image")));
			this.label_SmallTetirs5.Location = new System.Drawing.Point(264, 380);
			this.label_SmallTetirs5.Name = "label_SmallTetirs5";
			this.label_SmallTetirs5.Size = new System.Drawing.Size(97, 169);
			this.label_SmallTetirs5.TabIndex = 33;
			this.label_SmallTetirs5.Text = "userControl12";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(223)), ((System.Byte)(253)), ((System.Byte)(255)));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.label_SmallTetirs5);
			this.Controls.Add(this.label_SmallTetirs4);
			this.Controls.Add(this.label_SmallTetirs3);
			this.Controls.Add(this.label_SmallTetirs2);
			this.Controls.Add(this.label_SmallTetirs1);
			this.Controls.Add(this.panel_toolCon);
			this.Controls.Add(this.label_toolMess);
			this.Controls.Add(this.user_stop);
			this.Controls.Add(this.userControl11);
			this.Controls.Add(this.use_set);
			this.Controls.Add(this.user_help);
			this.Controls.Add(this.user_send);
			this.Controls.Add(this.user_Exit);
			this.Controls.Add(this.user_Exerc);
			this.Controls.Add(this.txtSendContent);
			this.Controls.Add(this.lstContent);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.user_start);
			this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "sw";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Click += new System.EventHandler(this.Form1_Click);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#region windows API
		//������϶�
			[DllImport("user32.dll")]
			public static extern bool ReleaseCapture();
			[DllImport("user32.dll")]
			public static extern bool SendMessage(IntPtr hwnd,int wMsg,int wParam,int lParam);
			public const int w=0x0112;
			public const int s=0xF010;
			public const int h=0x0002;
	
		#endregion

		#region �ؼ��ͱ�������
		public System.Windows.Forms.Panel panel1;//������
		public  System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.Panel panel2;//��һ������ʾ����
		public System.Windows.Forms.TextBox txtSendContent;
		public System.Windows.Forms.ListBox lstContent;//�Ƿ�ʧ��
	
		private �ؼ�����.UserControl1 user_Exerc;
		private �ؼ�����.UserControl1 user_start;
		private �ؼ�����.UserControl1 user_Exit;
		private �ؼ�����.UserControl1 user_send;
		private �ؼ�����.UserControl1 user_help;
		private �ؼ�����.UserControl1 use_set;
		private �ؼ�����.UserControl1 userControl11;
		private �ؼ�����.UserControl1 user_stop;

		private SingleTetirs block=null;//�����̨
		private MessageSend send=null;//������ϢͨѶ
		public System.Windows.Forms.ImageList imageList1;
		public System.Windows.Forms.Label label_toolMess;
		private bool Game_Fail=true;
		private Bridge bridge;//���������������

		public static  string userNumber="1";
		public �Զ���ؼ�label.UserControl1 panel_toolCon;//������ʾ
		public static string userName=null;
		private bool keyCanUse=true;

		public SoundBack soundBack;//��������

		//����
		public static  Keys[] key=new Keys[12];
		//��Ϸ�Ѷ�
		public static int GameLevel=0;
		//��ת����
		public static int GameDirect=1;//��ʱ��
		//��ɫ����ͼƬ��QQ ����
		public static Image[] ColorImage=new Image[6];
		//��ʾ�����û���Ϸ��Ϣ
		public static Image[] toolAndBrickImage=new Image[19];
		public  �Զ���ؼ�_LabelSmallTetir.UserControl1 label_SmallTetirs1;
		public �Զ���ؼ�_LabelSmallTetir.UserControl1 label_SmallTetirs2;
		public �Զ���ؼ�_LabelSmallTetir.UserControl1 label_SmallTetirs3;
		public �Զ���ؼ�_LabelSmallTetir.UserControl1 label_SmallTetirs4;
		public �Զ���ؼ�_LabelSmallTetir.UserControl1 label_SmallTetirs5;
		
		//�һ�����
		public Image Root_Module=null;

		//����ί�� �����˽���ʱ Ҫ��ʾ�� �س� �� ����
		public static PaintDelegate multiDelegate=null;
		// ��ϰ���Ƿ�����
		private bool Exec_used=false;
		//һ����Ϸ�Ƿ�ʼ
		private bool OneGame=true;
	

		#endregion

		//��ʼ ������ �� ���� ��
		#region  ��ʼ
		void init()
		{
			try
			{
				this.Opacity=0.0;
				Color c=Color.FromArgb(45,45,45);
			
				//������Ϸ��������
				Image_Procces.ImageForBackImage(this.panel1);
			
				//������Ϸ�¸����鱳��
				this.panel2.BackColor=c;
				Image_Procces.ImageForBackImage(this.panel2);
			
				//�Է��������ı���1
				//��������
				key[0]=Keys.Up;// ��ת
				key[1]=Keys.Down;//����
				key[2]=Keys.Left;//����
				key[3]=Keys.Right;//����
				key[4]=Keys.Space;
				key[5]=Keys.S;//�л�����
				key[6]=Keys.D1;//��1��ʹ�õ���
				key[7]=Keys.D2;
				key[8]=Keys.D3;
				key[9]=Keys.D4;
				key[10]=Keys.D5;
				key[11]=Keys.D6;//��6��ʹ�õ���
				keysSet.getForm(this);//�������û��������
				// ��ɫ����ͼƬ(�� ��������
				ColorImage[0]=new  Bitmap(@"ͼƬ\man1.gif");
				ColorImage[1]=new  Bitmap(@"ͼƬ\man2.gif");
				ColorImage[2]=new  Bitmap(@"ͼƬ\man3.gif");
				ColorImage[3]=new  Bitmap(@"ͼƬ\man4.gif");
				ColorImage[4]=new  Bitmap(@"ͼƬ\man5.gif");
				ColorImage[5]=new  Bitmap(@"ͼƬ\man6.gif");
				
				//����Ϸ�� �����һ�
				Image_Procces.Image_Hui(ColorImage[0],this.panel1);
				Root_Module=new Bitmap(this.panel1.BackgroundImage,this.panel1.Width,this.panel1.Height);
				Image_Procces.Image_AddPicture(ColorImage[0],this.panel1);
		
			
				this.block=new SingleTetirs(this.panel1,12,21,16,this);//(Control con1,int gridx,int gridy,int side,Form formControl)
			//��������
				this.soundBack=new SoundBack();
			}
			catch{}
		}
		#endregion

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{	
			if(this.Game_Fail)//ʧ�ܺ��ڻ��Ʒ���ͼƬ
				return;

			if(this.block!=null)
				this.block.drawBlocks();
			
		}
		
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(this.Game_Fail)//ʧ�ܺ��������ƶ�
				return;
			if(this.block==null)
				return;
			this.block.keyPress(Form1.key[1]);//�����ƶ�
				

			
		}
		
		bool EnterOrder=true;//��������
		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.Game_Fail)//ʧ�ܺ���ʹ�ü���
				return;
			if(!this.keyCanUse)//���㲻����Ϸ��
				return ;
			if(this.block!=null)
			{
				this.block.keyPress(e.KeyCode);
				if(this.EnterOrder)//���ߵ�ʹ���谴�� ��ſ� (��������ʹ��)
				{
					this.block.keyToolPress(e.KeyCode);
					this.EnterOrder=false;
				}
			}

		}
		private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.EnterOrder=true;
		}
		private void user_Exit_Click(object sender, System.EventArgs e)
		{
			this.user_Exit.Enabled=false;
			this.user_stop.Enabled=false;
			this.user_start.Enabled=false;
			this.Close();
			
		}
		private void user_start_Click(object sender, System.EventArgs e)
		{
			if(this.OneGame)//һ����Ϸ��ʼ
			{				
				this.start();
				this.txtSendContent.ReadOnly=true;
				this.txtSendContent.Focus();
				this.keyCanUse=true;
				this.OneGame=false;
				this.Exec_used=false;
				SingleTetirs.FailOrWin=false;//û��ʧ��
				SingleTetirs.ArrayVisit=true;//����ɷ���
			}
		}

		//��Ϸ��ʼ
		private void start()
		{
			try
			{
				this.bridge.Bridge_start();//������ʼ
				//����ʼ��Ϣ
				string message="START|"+Form1.userName+"|"+Form1.userNumber.ToString()+"|";
				this.send.sendMessage(message);		
				this.timer1.Enabled=true;
			}
			catch{}

			
			
		}
		
		//��Ϸʧ��
		public void Fail()
		{	
			try
			{	
				this.Game_Fail=true;
				this.timer1.Enabled	=false;
				this.soundBack.music_stop();//��������ֹͣ
			
				
				string fs="FAIL|"+Form1.userName+"|"+SingleTetirs.Game_Lervel_name+"|";//��ʧ����Ϣ
				this.send.sendMessage(fs);

				this.bridge.Bridge_stop();//����ִֹͣ�в�������
				new MoveNext_Brick(this.panel2);//�����һ������ ����ʾ����
		
				this.user_Exerc.Enabled=true;

			}
			catch{}
		
		}
		
		//���ٰ���
		private void user_help_Click(object sender, System.EventArgs e)
		{
			HelpWindow f=new HelpWindow(this);
			f.ShowDialog();
		}

		//���ش���
		private void Form1_Load(object sender, System.EventArgs e)
		{
		try
			{
				Login dlgLogin=new Login();
				//��ʾLogin�Ի���
				DialogResult result=dlgLogin.ShowDialog();
				if(result==DialogResult.OK)
				{
					//��Login���ڵ���ɹ�����
					
					this.send=new MessageSend(this,dlgLogin.tcpClient,dlgLogin.Alias.Trim(),this);
					this.bridge=new Bridge(this.block,this,this.send);
					Form1.userName=dlgLogin.Alias.Trim();
					dlgLogin.Close();
				}
				else
				{
					this.Close();
					return ;
					//�û��ڵ��봰���е����ˡ�ȡ������ť

				}
			}
			catch(Exception e1)
			{
				MessageBox.Show(e1.ToString());
			}
			
			Thread.CurrentThread.Join(100);
			//���봰��
			Thread tt=new Thread(new ThreadStart(this.WindowsEntry));
			tt.IsBackground=true;
			tt.Start();

			this.lstContent.Items.Add("QQGame��������");
			this.lstContent.Items.Add("������:");
			this.lstContent.Items.Add("����,����,����,����,����");
			this.lstContent.Items.Add("��̷��,����");
			this.lstContent.Items.Add("ָ����ʦ:Ԭ����");
			this.Form1_Click(null,null);//�������this.txtSendContent��
			this.user_start.Enabled=true;
			
		}

		
			//����
		private void user_send_Click(object sender, System.EventArgs e)
		{
			if(this.send!=null)
			{
				if(this.txtSendContent.Text.Trim()!="")
				{
					string message="CHAT|"+Form1.userName+":"+txtSendContent.Text+"|";
					this.send.sendMessage(message);
					txtSendContent.Text="";
					
				}
			}
		}

		
		//�رմ���ǰ��һЩ
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				
				if(this.send!=null)
					this.send.Exit();//�������Ҫ���뿪

				if(this.bridge!=null)
					if(this.bridge.bridge_t.IsAlive)//ֹͣ��������
					{
						this.bridge.Bridge_stop();
					}
			//����ĵ���
				this.Opacity=1;//������δ��ȫ����
				Thread.Sleep(100);
				this.Opacity=0.96;
				while(this.Opacity>0.0)//���嵭��
				{
					this.Opacity-=0.014;
					Thread.Sleep(3);
				}
				this.Opacity=0;

			}
			catch{}
			
		}

		
		//����
		private void txtSendContent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				user_send_Click(null,null);
		}

		
		//������ؼ�
		private void user_start_MouseEnter(object sender, System.EventArgs e)
		{
			try
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
			catch{}
			
		}

		
		//����뿪�ؼ�
		private void user_start_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				Label t=(Label)sender;
				Point p=new Point(t.Location.X,t.Location.Y);
				p.X++;
				p.Y++;
				t.Location=p;

				t.Width-=2;
				t.Height-=2;
			}
			catch{}
		}

		
		//��С��
		private void userControl11_Click(object sender, System.EventArgs e)
		{
			this.WindowState=FormWindowState.Minimized;
		}

		
		//�˳�ϵͳ
		private void user_stop_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
		//����
		private void Form1_Click(object sender, System.EventArgs e)
		{
			this.txtSendContent.Focus();
			this.txtSendContent.ReadOnly=true;
			this.keyCanUse=true;
		}


		//�����뷢����
		private void txtSendContent_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.txtSendContent.ReadOnly=false;
			this.keyCanUse=false;
		}
		//�϶�����
		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//����ApI ����
			ReleaseCapture();
			SendMessage(this.Handle,w,s+h,0);
		}

		private void lstContent_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Form1_Click(null,null);
		}
		// ���ٰ���
		private void use_set_Click(object sender, System.EventArgs e)
		{
			keysSet k=new keysSet();
			k.ShowDialog();
	
		}
		//���嵭��
		void WindowsEntry()//���嵭��
		{
			while(this.Opacity<0.95)
			{
				this.Opacity+=0.01;
			
				Thread.Sleep(1);
			}
			this.Opacity=1;

		}		

	
		protected override void OnPaint(PaintEventArgs e)
		{
			// TODO:  ��� Form1.OnPaint ʵ��
			base.OnPaint (e);
			if(Form1.userName!=null)
				e.Graphics.DrawString(Form1.userName.ToString(),this.Font,new SolidBrush(Color.Black),484,56);

			if(Form1.multiDelegate!=null)
				Form1.multiDelegate(e.Graphics);
		}
		#region fail_start_Interface ��Ա
		//��ʼ��Ϸ
		//����Ŀ�ʼ ����� ������ ʵ�������ͬ�� ������ �˶���ʼ ��Ϸ�ſ�ʼ
		//ͬ�� ��ֻ��һ��û��ʧ��ʱ�Ž���
		public void StartGame()
		{
			// TODO:  ��� Form1.StartGame ʵ��
			
			this.block.start();//��̨��ʼ
			Sound.Play(6);
			//Ready go ��ʼ
			Image_Procces.Image_GameStart(this.panel1);

			Thread.CurrentThread.Join(400);
			this.Game_Fail=false;
			if(keysSet.musicBack)
				this.soundBack.music_start();

		}
		//������Ϸ
		public void FailGame()
		{
			this.Game_Fail=true;//����ʹ�� ����
			this.OneGame=true;//��һ����Ϸ����
		
			if(!SingleTetirs.FailOrWin)//û��ʧ��
			{
				Sound.Play(10);
				this.soundBack.music_stop();//��������ֹͣ
			}
				SingleTetirs.FailOrWin=false;//û��ʧ��
				this.panel1.Invalidate();
				this.panel1.Update();

				new MoveNext_Brick(this.panel2);//�����һ������ ����ʾ����
			
		}

		#endregion

		private void user_Exerc_Click(object sender, System.EventArgs e)
		{
			if(SingleTetirs.FailOrWin)//ʧ�� ���  ��
			{
				this.block.start();//��̨��ʼ
				this.Game_Fail=false;
				this.timer1.Enabled=true;
				this.Exec_used=true;
			}
			
		}
	}
}
