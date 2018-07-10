
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace ����˹1
{
	public interface Tetirs_bridge//�ӿ�
	{
		string map(ref  int head);
		void Remove(int num);
		bool HightRow(int num);
	}
	public class SingleTetirs:Tetirs_bridge//��̨��
	{
		#region ��������
		public Control con;//paint��ؼ�
		private Draw d;//��ͼ��

		public int Brick_Width;//�����
		public int Now_Brick_Num;//��ǰ�����
		public int Now_Brick_Direct;//��ǰ���鷽��
		public int Now_Brick_X;//��ǰ����x����
		public int Now_Brick_Y;//��ǰ����y����
		public SuperBrick NowBrick;//��ǰ����
		public int Now_Brick_Color;//��ɫ 
		public int Next_Brick_Num;//��һ���������
		public int Next_Brick_Num2;//����һ���������

		public int Next_Brick_Color;//��һ��������ɫ
		public int Next_Brick_Color2;//����һ��������ɫ
		
		public  ArrayList BrickArray;//���з���������

		public int Gridx,Gridy;//��ͼ�����С
		public int[,] Map_Array;//�����ͼ����
		public int [,] Map_Color_Array;//������ɫ����
		public  Form1 formControl;//�������
		private Image Next_Brick_Im;//��һ������ͼƬ=new Bitmap(this.formControl.panel2.Width,this.formControl.panel2.Height);
		
		private long Game_Score=0;//�÷�
		private long Game_Line=0;//��ȥ����
		private int Game_Lervel=100;
	
		public static string Game_Lervel_name="ѧͽ";

		private Image Bo_Image;//ͼƬΪ����׼��
		private Image module;//��ͼģ��
		private Image now_BrickImage;

		private bool single_start=false;
		private string s_MapCopy=null;
		private  int toolSum;//��������
		private �Զ���ؼ�label.UserControl1 toolCon;//������ʾ�Ŀؼ�
		public static bool FailOrWin=false;//��ǰ�����Ϸ״̬
		public static bool ArrayVisit=true;//�����Ƿ�ɷ���
	#endregion
		
		//����Ҫע����� ��������Ϸ��ÿһ������������ŵ�Ӱһ������Ϸ�� ׼����������Ƭ
		//������ 1 this.formControl.Root_Module һ��û���κη����ͼƬ
		//    2 this.Bo_Image  ����ʱ���õ�ͼƬ ��Ϊ���������� ����һ��ͼƬ��ʱ��̫��
		//����ѡ�� ��ʹ�ú󴴽� ��������Ϸ���ٶ� �о��Ͼͻ��һЩ
		// 3 this.module ÿһ�����к� ���� �������� ��ͼƬ ���� �����һ�εĵ�Ƭ
		public SingleTetirs(Control con1,int gridx,int gridy,int side,Form1 form)//new Block(this.panel1,9,19,25,this.nextShapeNO,firstPos,color)
		{	
			#region ������ʼ��
			this.formControl=form;
			this.con=con1;
			
			this.d=new Draw(this);
			this.Brick_Width=side;
			this.d=new Draw(this);
			this.BrickArray=new ArrayList();//���з���������
			this.BrickArray.Add(new Brick_BB());
			this.BrickArray.Add(new Brick_I());
			this.BrickArray.Add(new Brick_L());
			this.BrickArray.Add(new Brick_UL());
			this.BrickArray.Add(new Brick_UT());
			this.BrickArray.Add(new Brick_UZ());
			this.BrickArray.Add(new Brick_Z());
			this.Gridx=gridx;
			this.Gridy=gridy;

			this.Map_Array=new int[this.Gridx,this.Gridy];
			this.Map_Color_Array=new int[this.Gridx,this.Gridy];
			
			this.toolCon=form.panel_toolCon;
			//��ʼ����һ��������ʾ�� ͼƬ
			this.Next_Brick_Im=new Bitmap(this.formControl.panel2.Width,this.formControl.panel2.Height);
			//������ʾ��ǰ�û� ���س� ���� �� �ȼ�  ����ί��
			PaintDelegate a=new PaintDelegate(this.PaintTopMess);
			Form1.multiDelegate+=a;
			this.start();
			#endregion
		}
		public void start()//��ʼ
		{
			
			try
			{
				this.Now_Brick_Num=0;
				this.Now_Brick_Direct=0;
				this.Now_Brick_X=0;
				this.Now_Brick_Y=0;
				this.NowBrick=new Brick_BB();
				for(int i=0;i<this.Gridx;i++)
					for(int j=0;j<this.Gridy;j++)
					{
						this.Map_Array[i,j]=0;
						this.Map_Color_Array[i,j]=0;
					}
				
				this.Next_Brick_Num2=0;
				this.Next_Brick_Color2=1;//this.con.BackColor;
				this.createNextBrick();//���δ�����һ������
				this.createNextBrick();//������һ ������
				this.addNextBrick();//���뷽��

				this.Game_Line=0;//
				//�������ã�
				if(this.Bo_Image!=null)
					this.Bo_Image.Dispose();
				
				this.Bo_Image=new Bitmap(this.formControl.Root_Module,this.con.Width,this.con.Height);
				//����ģ��
				if(this.module!=null)
					this.module.Dispose();

				this.module=new Bitmap(this.formControl.Root_Module,this.con.Width,this.con.Height);
				//��ʼ
				this.single_start=true;
			
				//��������=0
				this.toolSum=0;
			
			}
			catch{}
//		
			

		}
		//������ʾ��ǰ�û� ���س� ���� �� �ȼ�
		private void   PaintTopMess(Graphics g)
		{
			//��ʾ����
			g.DrawString(this.Game_Score.ToString(),this.formControl.Font,new SolidBrush(Color.Black),484,72);
			 //��ʾ�ȼ�
			g.DrawString(SingleTetirs.Game_Lervel_name,this.formControl.Font,new SolidBrush(Color.Black),484,89);

	
		}
		private void updateGame(int line)
		{
			this.Game_Score+=5*line*line*line;
			this.Game_Line+=line;
			if(this.Game_Score>=this.Game_Lervel)
			{
				switch(SingleTetirs.Game_Lervel_name)
				{
					case"ѧͽ":
						SingleTetirs.Game_Lervel_name= "����";
						this.Game_Lervel=1000;
						break;
					case "����":
						SingleTetirs.Game_Lervel_name= "����ʦ";
						this.Game_Lervel=10000;
						break;
					case "����ʦ":
						SingleTetirs.Game_Lervel_name= "����ʦ";
						this.Game_Lervel=1000000;
						break;
					case "����ʦ":
						SingleTetirs.Game_Lervel_name= "�ܹ���ʦ";
						this.Game_Lervel=100000000;
						break;
						
				}
			}
			this.formControl.Invalidate(new Rectangle(484,72,100,30));
			
		}
		private void createNextBrick()
		{
			Random rnd=new Random();//�������
			this.Next_Brick_Num=this.Next_Brick_Num2;//��һ������=����һ��
			this.Next_Brick_Color=this.Next_Brick_Color2;

			
			this.Next_Brick_Num2=rnd.Next(0,7);
		
			this.Next_Brick_Color2=this.Next_Brick_Num2+1;
			//����һ������浽paint2����
			if(!this.single_start)//δ��ʼ
				return;
			MoveNext_Brick nextBrick_show=new MoveNext_Brick(this.formControl.panel2,this);  
			
				
		}
		private void addNextBrick()
		{
			this.Now_Brick_X=4;
			this.Now_Brick_Y=-1;
			this.Now_Brick_Num=this.Next_Brick_Num;
			this.NowBrick=(SuperBrick)this.BrickArray[this.Now_Brick_Num];
			this.Now_Brick_Color=this.Next_Brick_Color;
			this.createNextBrick();

		}
		public bool isPut(int x,int y,int type,int mode)//mode=direct �����Ƿ��
		{	
			SuperBrick sb=(SuperBrick)this.BrickArray[type];
			for(int i=0;i<5;i++)
				for(int j=0;j<5;j++)
					if(sb.Brick_Array[mode,i,j]==1)
					{
						if( (i+x)<0 ||(i+x)>(this.Gridx-1) ||(j+y)<0||(j+y)>(this.Gridy-1)|| (this.Map_Array[i+x,j+y]==1))//�����⣿��������
						{
							return false;
						}
					}

			return true;
		}
		public void addBrickToMap()//�����ͼ����
		{
			lock(this)
			{
				for(int i=0;i<5;i++)
					for(int j=0;j<5;j++)
					{
						if( (i+this.Now_Brick_X)>=0 &&(i+this.Now_Brick_X)<this.Gridx &&(j+this.Now_Brick_Y)>=0 && 
							(j+this.Now_Brick_Y)<this.Gridy && (this.NowBrick.Brick_Array[this.Now_Brick_Direct,i,j]==1) )
						{
							this.Map_Array[this.Now_Brick_X+i,this.Now_Brick_Y+j]=1;
							this.Map_Color_Array[this.Now_Brick_X+i,this.Now_Brick_Y+j]=this.Now_Brick_Color;
						}
					}
				this.module.Dispose();
				this.module=this.now_BrickImage;
			}
			Bridge.stack.Add(3);//��ͼ�����˱仯
		}
	
		public void  checkFull()//�Ƿ��ɾ��
		{
			try
			{
				bool blFull=true;
				int delLine=0;
				for(int j=this.Now_Brick_Y;j<this.Now_Brick_Y+5;j++)
				{
					if(j>=this.Gridy||j<0)
						break;

					blFull=true;
					for(int i=0;i<this.Gridx;i++)
					{
						if(j>=0 &&j<this.Gridy)
						{
							if(this.Map_Array[i,j]!=1)
							{
								blFull=false;
								break;
							}
						}
					}
					if(blFull)
					{
						this.removeFull(j);
						delLine++;	
					}
				}
			
				
				if(delLine>0)
				{
					this.drawBlocks(this.Bo_Image);
					Sound.Play(2);
					if(!SingleTetirs.FailOrWin)//�����Ϸû��ʧ�ܣ����ʧ�ܺ󵱻���ϰ�Ͳ���
					{
						this.updateGame(delLine);//�޸Ļ���
					
						if(delLine==1)
						{
							if(Form1.GameLevel==1)//��Ϸ�Ѷ�Ϊ�߼�
								Bridge.stack.Add(41);
						}
						else if(delLine==3)//ÿ�����ж������˼�2��
						{
							Bridge.stack.Add(12);	
						}
						else if(delLine==4)//ÿ�����ж������˼�3��
						{
							Bridge.stack.Add(13);	
						}
						Bridge.stack.Add(3);
						//���·��䱳��ͼƬ
					}
					this.Bo_Image=new Bitmap(this.formControl.Root_Module,this.con.Width,this.con.Height);
					Thread.CurrentThread.Join(150);
			
				}
			}
			catch{}
		
		}
		public void removeFull(int line)//ɾ����
		{
			lock(this)
			{
				
				for(int i=0;i<this.Gridx;i++)
				{	
					int n=this.Map_Color_Array[i,line];
					if(n>8)
					{
						Bridge.queue.Add(n);
						this.toolSum++;
						this.toolCon.Invalidate();
					
					}
				}

				for(int j=line;j>0;j--)
				{
					for(int i=0;i<this.Gridx;i++)
					{	
						this.Map_Array[i,j]=this.Map_Array[i,j-1];
						this.Map_Color_Array[i,j]=this.Map_Color_Array[i,j-1];
					}
				}
				//������ɵ���
				if(SingleTetirs.FailOrWin)//�����Ϸʧ��
					return;
				Random r=new Random();
				int t=r.Next(5,16);
				if(t<=8)
					return;
				
				int nx=r.Next(1,12);
				int ny=r.Next(line,this.Gridy);
				this.Map_Array[nx,ny]=1;
				this.Map_Color_Array[nx,ny]=t;
			}
		}
		private int Ji_Ou_n=0;//��ż��������
		#region Tetirs_bridge ��Ա
		public string map(ref int head)
		{
				SingleTetirs.ArrayVisit=false;//���鲻�ɷ���
				bool find =false;//������Ϣ���
				this.s_MapCopy=null;
				for(int j=0;j<this.Gridy;j++)
					for(int i=0;i<this.Gridx;i++)
					{
						if(!find)
						{
							if(this.Map_Color_Array[i,j]!=0)
							{
								head=j*this.Gridx+i;
								find=true;
							}
							else
								continue;
						}

						if(this.Map_Color_Array[i,j]<9)
							this.s_MapCopy+=this.Map_Color_Array[i,j].ToString();
						else
							this.s_MapCopy+="8";
					}
				SingleTetirs.ArrayVisit=true;
				return this.s_MapCopy;
			
			
		}
		public void Remove(int num)//ɾ����  ����û���п�ɾ�����
		{
			
				lock(this)
				{
				
					int j,i;
					//�������п�ɾ�����
					bool find=false;
					for( i=0;i<this.Gridx;i++)
					{
						if(this.Map_Array[i,this.Gridy-1]!=0)
						{
							find=true;
							break;
						}

					}
					if(!find)//���п�ɾ
						return;
				
					for( j=this.Gridy-1;j>=num;j--)//����
						for( i=0;i<this.Gridx;i++)
						{
							this.Map_Array[i,j]=this.Map_Array[i,j-num];
							this.Map_Color_Array[i,j]=this.Map_Color_Array[i,j-num];
						}
				
					for(j=0;j<num;j++)
						for(i=0;i<this.Gridx;i++)
						{
							this.Map_Array[i,j]=0;
							this.Map_Color_Array[i,j]=0;
						}
						
				}
				this.drawBlocks();
			
			


		}
		
		public bool HightRow(int num)//�����У�ע��2��3�е����
		{
			
				lock(this)
				{
				//������һ�����⣺��ʹ�õ�������ʱ �����ǰ����飨Ҳ���������ƶ��ķ��飩
				//���������ӵķ����У��ͻ���ֲ��õ�����
					//���ӿ���
					for(int j=0;j<this.Gridy-num;j++)//����
						for(int i=0;i<this.Gridx;i++)
						{
						
							this.Map_Array[i,j]=this.Map_Array[i,j+num];
							this.Map_Color_Array[i,j]=this.Map_Color_Array[i,j+num];
						}

					//���ǵ��������
					for(int i=0;i<this.Gridx;i++)
					{
						if(this.Map_Array[i,1]!=0)
						{
							return false;
						}

					}
				
					int n=this.Ji_Ou_n;////��ż��������
					n=1-n;//��ż�任
					this.Ji_Ou_n=n;

					for(int j=1;j<=num;j++)
					{
						int k=n;
						for(int i=1-n;i<this.Gridx;i+=2,k+=2)
						{
							this.Map_Array[i,this.Gridy-j]=1;
							this.Map_Color_Array[i,this.Gridy-j]=8;
							if(k<this.Gridx)
							{
								this.Map_Array[k,this.Gridy-j]=0;
								this.Map_Color_Array[k,this.Gridy-j]=0;
							}
						}
					}

					Random r=new Random();
					int t=r.Next(7,16);
					if(t<=8)
						return true;

					this.Map_Array[this.Gridx-n-3,this.Gridy-1]=1;
					this.Map_Color_Array[this.Gridx-n-3,this.Gridy-1]=t;
					this.formControl.timer1.Enabled=true;
				}
				
				this.drawBlocks();
			
			return true;
		}

		#endregion
		//�������
		private void draw_NowBrick()
		{
			try
			{
				this.now_BrickImage=(Image)this.module.Clone();//new Bitmap(this.module,this.con.Width,this.con.Height);
				lock(this)
				{
					Graphics paint_g=this.con.CreateGraphics();
			
					Graphics  mg=Graphics.FromImage(this.now_BrickImage);
					this.d.DrawBrickGroup(mg);
					paint_g.DrawImageUnscaled(this.now_BrickImage,0,0,this.con.Width,this.con.Height);
					mg.Dispose();
					paint_g.Dispose();
				}
			}
			catch{}
		}
		public void drawBlocks(Image m)
		{
			try
			{
				lock(this)
				{

					Graphics paint_g=this.con.CreateGraphics();
					Graphics  mg=Graphics.FromImage(m);
					
					for(int i=0;i<this.Gridx;i++)
						for(int j=0;j<this.Gridy;j++)
							if(this.Map_Array[i,j]==1)
								d.DrawBrick(i,j,this.Map_Color_Array[i,j],mg);

					paint_g.DrawImageUnscaled(m,0,0,this.con.Width,this.con.Height);
					mg.Dispose();
					paint_g.Dispose();
					this.module.Dispose();
					this.module=m;
					this.draw_NowBrick();//�����ڵķ���
				
				}
			}
			catch{}
		}
		public  void drawBlocks()
		{
			try
			{
				Image  m=(Image)this.formControl.Root_Module.Clone();//this.con.BackgroundImage.Clone();//new Bitmap(this.con.BackgroundImage,this.con.Width,this.con.Height);
				this.drawBlocks(m);
			}
			catch{}

		}
		
//��Ϸʧ�ܼ��
		private void checkFail()
		{
			if(!this.isPut(this.Now_Brick_X,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
			{
				try
				{
					SingleTetirs.FailOrWin=true;//��Ϸʧ��
					Sound.Play(5);
					Image_Procces.Image_GameStop(this.con,this.Game_Score,this.Game_Line,this.module);
					this.formControl.Fail();
					//ʧ�� ��ͼ
					
					Thread.Sleep(4000);
					
					this.con.Invalidate();
					this.con.Update();
					//�� ��ʾ��һ��������Ϣ �� �������
					
				}
				catch{}


			}
		}


		public void keyPress(Keys k)//��Ϸ ���̿���
				{
					try
					{
					
						int x=this.Now_Brick_X;
						int y=this.Now_Brick_Y;
						int direct=this.Now_Brick_Direct;
						
					if(k== Form1.key[0])//��ת����
							{
								this.Now_Brick_Direct+=Form1.GameDirect;
								if(this.Now_Brick_Direct>=4)
									this.Now_Brick_Direct=0;
								if(this.Now_Brick_Direct<0)
								{
									this.Now_Brick_Direct=3;
								}
					
								if(this.isPut(this.Now_Brick_X,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.draw_NowBrick();
									Sound.Play(7);
								}
								else
								{
									this.Now_Brick_Direct-=Form1.GameDirect;
									if(this.Now_Brick_Direct<0)
										this.Now_Brick_Direct=3;
									if(this.Now_Brick_Direct>=4)
										this.Now_Brick_Direct=0;
								}
								
					}
		
					else if(k== Form1.key[1])//�����ƶ�
					{

								if( this.isPut(this.Now_Brick_X,this.Now_Brick_Y+1,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_Y++;
											
									this.draw_NowBrick();
								}
								else
								{
									this.addBrickToMap();
									this.checkFull();
									this.addNextBrick();
					
									this.drawBlocks();
												
									this.checkFail();//�����Ƿ�ʧ��
												
								}
					}
		
					else if(k== Form1.key[2])//����
					{
								if( this.isPut(this.Now_Brick_X-1,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_X--;
											
									this.draw_NowBrick();
								}
					}
		
					else if(k== Form1.key[3])//����
					{
								if( this.isPut(this.Now_Brick_X+1,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_X++;
									this.draw_NowBrick();
								}
					}
					else if( k==Form1.key[4])//�¶�
					{
								while( this.isPut(this.Now_Brick_X,this.Now_Brick_Y+1,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_Y++;
									x=this.Now_Brick_X;
									y=this.Now_Brick_Y;
								}
										
								this.draw_NowBrick();//�����ڵķ���
				
								Sound.Play(3);
								this.addBrickToMap();//�����ͼ����
								this.checkFull();//�Ƿ�����
								this.addNextBrick();//������һ ������
				
								this.drawBlocks();
								this.checkFail();//�����Ƿ�ʧ��
					}
		
					}
					catch
					{
						
					}
					
				}

		private void tools_Use(int n)//��Է�ʹ�õ���
		{
			if(Bridge.queue.Count>0)
				if(this.toolSum>0)
				{
					Bridge.stack.Add(n);
					this.toolSum--;
					Sound.Play(4);
				}
		}
		//����ʹ��
		public void keyToolPress(Keys k)
		{
			
			try
			{
				if(k==	Form1.key[5])//Form1.key[5]://�л�����
				{
					if(Bridge.queue.Count>0)
						if(this.toolSum>0)
						{
							Bridge.stack.Add(2);
							Sound.Play(1);
						}

				}
				else if(k== Form1.key[6])//���Լ�ʹ�õ���
				{

					if(Bridge.queue.Count>0)
						if(this.toolSum>0)
						{
										
							Bridge.stack.Add(1);
							this.toolSum--;
							Sound.Play(8);
						}

				}
				else if(k== Form1.key[7])//��2ʹ�õ���
				{
					this.tools_Use(12);
				}
				else if(k== Form1.key[8])//��3ʹ�õ���
				{
					this.tools_Use(13);
				}
				else if(k== Form1.key[9])//��4ʹ�õ���
				{
					this.tools_Use(14);
				}
				else if(k== Form1.key[10])//��5ʹ�õ���
				{
					this.tools_Use(15);
				}
				else if(k== Form1.key[11])//��6ʹ�õ���
				{
					this.tools_Use(16);
				}

				else if(k== Keys.W)//ע�⿪ʼ����,
				{
					Bridge.queue.Add(11);
					this.toolSum++;
					this.toolCon.Invalidate();
				}
				else if(k== Keys.X)//
				{
					Bridge.queue.Add(15);
					this.toolSum++;
					this.toolCon.Invalidate();
					
				}
			}
			catch{}

		}
		
	}
}
