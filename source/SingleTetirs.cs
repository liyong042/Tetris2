
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace 俄罗斯1
{
	public interface Tetirs_bridge//接口
	{
		string map(ref  int head);
		void Remove(int num);
		bool HightRow(int num);
	}
	public class SingleTetirs:Tetirs_bridge//后台类
	{
		#region 变量声明
		public Control con;//paint类控件
		private Draw d;//绘图类

		public int Brick_Width;//方块宽
		public int Now_Brick_Num;//当前方块号
		public int Now_Brick_Direct;//当前方块方向
		public int Now_Brick_X;//当前方块x坐标
		public int Now_Brick_Y;//当前方块y坐标
		public SuperBrick NowBrick;//当前方块
		public int Now_Brick_Color;//颜色 
		public int Next_Brick_Num;//下一个方块编码
		public int Next_Brick_Num2;//下下一个方块编码

		public int Next_Brick_Color;//下一个方块颜色
		public int Next_Brick_Color2;//下下一个方块颜色
		
		public  ArrayList BrickArray;//所有方块存放数组

		public int Gridx,Gridy;//地图数组大小
		public int[,] Map_Array;//方块地图数组
		public int [,] Map_Color_Array;//方块颜色数组
		public  Form1 formControl;//窗体界面
		private Image Next_Brick_Im;//下一个方块图片=new Bitmap(this.formControl.panel2.Width,this.formControl.panel2.Height);
		
		private long Game_Score=0;//得分
		private long Game_Line=0;//消去行数
		private int Game_Lervel=100;
	
		public static string Game_Lervel_name="学徒";

		private Image Bo_Image;//图片为消行准备
		private Image module;//画图模板
		private Image now_BrickImage;

		private bool single_start=false;
		private string s_MapCopy=null;
		private  int toolSum;//道具数量
		private 自定义控件label.UserControl1 toolCon;//道具显示的控件
		public static bool FailOrWin=false;//当前玩家游戏状态
		public static bool ArrayVisit=true;//数组是否可访问
	#endregion
		
		//这里要注意的是 ，整个游戏的每一个动作，就像放电影一样，游戏中 准备了三副底片
		//他们是 1 this.formControl.Root_Module 一个没有任何方块的图片
		//    2 this.Bo_Image  消行时所用的图片 因为程序运行中 创建一副图片的时间太长
		//所以选择 先使用后创建 ，这样游戏的速度 感觉上就会快一些
		// 3 this.module 每一次消行后 或者 方块落下 的图片 都会 变成下一次的底片
		public SingleTetirs(Control con1,int gridx,int gridy,int side,Form1 form)//new Block(this.panel1,9,19,25,this.nextShapeNO,firstPos,color)
		{	
			#region 变量初始化
			this.formControl=form;
			this.con=con1;
			
			this.d=new Draw(this);
			this.Brick_Width=side;
			this.d=new Draw(this);
			this.BrickArray=new ArrayList();//所有方块存放数组
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
			//初始化下一个方块显示的 图片
			this.Next_Brick_Im=new Bitmap(this.formControl.panel2.Width,this.formControl.panel2.Height);
			//用于显示当前用户 的呢称 积分 和 等级  加入委托
			PaintDelegate a=new PaintDelegate(this.PaintTopMess);
			Form1.multiDelegate+=a;
			this.start();
			#endregion
		}
		public void start()//开始
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
				this.createNextBrick();//两次创建下一个方块
				this.createNextBrick();//创建下一 个防块
				this.addNextBrick();//加入方块

				this.Game_Line=0;//
				//消行所用！
				if(this.Bo_Image!=null)
					this.Bo_Image.Dispose();
				
				this.Bo_Image=new Bitmap(this.formControl.Root_Module,this.con.Width,this.con.Height);
				//背景模板
				if(this.module!=null)
					this.module.Dispose();

				this.module=new Bitmap(this.formControl.Root_Module,this.con.Width,this.con.Height);
				//开始
				this.single_start=true;
			
				//道具数量=0
				this.toolSum=0;
			
			}
			catch{}
//		
			

		}
		//用于显示当前用户 的呢称 积分 和 等级
		private void   PaintTopMess(Graphics g)
		{
			//显示积分
			g.DrawString(this.Game_Score.ToString(),this.formControl.Font,new SolidBrush(Color.Black),484,72);
			 //显示等级
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
					case"学徒":
						SingleTetirs.Game_Lervel_name= "工人";
						this.Game_Lervel=1000;
						break;
					case "工人":
						SingleTetirs.Game_Lervel_name= "建筑师";
						this.Game_Lervel=10000;
						break;
					case "建筑师":
						SingleTetirs.Game_Lervel_name= "工程师";
						this.Game_Lervel=1000000;
						break;
					case "工程师":
						SingleTetirs.Game_Lervel_name= "总工程师";
						this.Game_Lervel=100000000;
						break;
						
				}
			}
			this.formControl.Invalidate(new Rectangle(484,72,100,30));
			
		}
		private void createNextBrick()
		{
			Random rnd=new Random();//随机变量
			this.Next_Brick_Num=this.Next_Brick_Num2;//下一个方块=下下一个
			this.Next_Brick_Color=this.Next_Brick_Color2;

			
			this.Next_Brick_Num2=rnd.Next(0,7);
		
			this.Next_Brick_Color2=this.Next_Brick_Num2+1;
			//将下一个方块绘到paint2容器
			if(!this.single_start)//未开始
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
		public bool isPut(int x,int y,int type,int mode)//mode=direct 方块是否可
		{	
			SuperBrick sb=(SuperBrick)this.BrickArray[type];
			for(int i=0;i<5;i++)
				for(int j=0;j<5;j++)
					if(sb.Brick_Array[mode,i,j]==1)
					{
						if( (i+x)<0 ||(i+x)>(this.Gridx-1) ||(j+y)<0||(j+y)>(this.Gridy-1)|| (this.Map_Array[i+x,j+y]==1))//有问题？？？？？
						{
							return false;
						}
					}

			return true;
		}
		public void addBrickToMap()//加入地图数组
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
			Bridge.stack.Add(3);//地图发生了变化
		}
	
		public void  checkFull()//是否可删行
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
					if(!SingleTetirs.FailOrWin)//如果游戏没有失败，如果失败后当击练习就不用
					{
						this.updateGame(delLine);//修改积分
					
						if(delLine==1)
						{
							if(Form1.GameLevel==1)//游戏难度为高级
								Bridge.stack.Add(41);
						}
						else if(delLine==3)//每消三行对其他人加2行
						{
							Bridge.stack.Add(12);	
						}
						else if(delLine==4)//每消四行对其他人加3行
						{
							Bridge.stack.Add(13);	
						}
						Bridge.stack.Add(3);
						//重新分配背景图片
					}
					this.Bo_Image=new Bitmap(this.formControl.Root_Module,this.con.Width,this.con.Height);
					Thread.CurrentThread.Join(150);
			
				}
			}
			catch{}
		
		}
		public void removeFull(int line)//删除行
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
				//随机生成道具
				if(SingleTetirs.FailOrWin)//如果游戏失败
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
		private int Ji_Ou_n=0;//奇偶数增行用
		#region Tetirs_bridge 成员
		public string map(ref int head)
		{
				SingleTetirs.ArrayVisit=false;//数组不可访问
				bool find =false;//查找信息起点
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
		public void Remove(int num)//删除行  考虑没有行可删的情况
		{
			
				lock(this)
				{
				
					int j,i;
					//考虑无行可删的情况
					bool find=false;
					for( i=0;i<this.Gridx;i++)
					{
						if(this.Map_Array[i,this.Gridy-1]!=0)
						{
							find=true;
							break;
						}

					}
					if(!find)//无行可删
						return;
				
					for( j=this.Gridy-1;j>=num;j--)//消行
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
		
		public bool HightRow(int num)//增加行：注意2，3行的情况
		{
			
				lock(this)
				{
				//这里有一个问题：当使用道具增加时 如果当前活动方块（也就是正在移动的方块）
				//正好在增加的方块中，就会出现不好的现象
					//需多加考虑
					for(int j=0;j<this.Gridy-num;j++)//增行
						for(int i=0;i<this.Gridx;i++)
						{
						
							this.Map_Array[i,j]=this.Map_Array[i,j+num];
							this.Map_Color_Array[i,j]=this.Map_Color_Array[i,j+num];
						}

					//考虑到顶的情况
					for(int i=0;i<this.Gridx;i++)
					{
						if(this.Map_Array[i,1]!=0)
						{
							return false;
						}

					}
				
					int n=this.Ji_Ou_n;////奇偶数增行用
					n=1-n;//奇偶变换
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
		//画活动方块
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
					this.draw_NowBrick();//画现在的方块
				
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
		
//游戏失败检测
		private void checkFail()
		{
			if(!this.isPut(this.Now_Brick_X,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
			{
				try
				{
					SingleTetirs.FailOrWin=true;//游戏失败
					Sound.Play(5);
					Image_Procces.Image_GameStop(this.con,this.Game_Score,this.Game_Line,this.module);
					this.formControl.Fail();
					//失败 绘图
					
					Thread.Sleep(4000);
					
					this.con.Invalidate();
					this.con.Update();
					//将 提示下一个方块信息 的 窗体清空
					
				}
				catch{}


			}
		}


		public void keyPress(Keys k)//游戏 键盘控制
				{
					try
					{
					
						int x=this.Now_Brick_X;
						int y=this.Now_Brick_Y;
						int direct=this.Now_Brick_Direct;
						
					if(k== Form1.key[0])//旋转方向
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
		
					else if(k== Form1.key[1])//向下移动
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
												
									this.checkFail();//检验是否失败
												
								}
					}
		
					else if(k== Form1.key[2])//向左
					{
								if( this.isPut(this.Now_Brick_X-1,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_X--;
											
									this.draw_NowBrick();
								}
					}
		
					else if(k== Form1.key[3])//向右
					{
								if( this.isPut(this.Now_Brick_X+1,this.Now_Brick_Y,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_X++;
									this.draw_NowBrick();
								}
					}
					else if( k==Form1.key[4])//下丢
					{
								while( this.isPut(this.Now_Brick_X,this.Now_Brick_Y+1,this.Now_Brick_Num,this.Now_Brick_Direct))
								{
									this.Now_Brick_Y++;
									x=this.Now_Brick_X;
									y=this.Now_Brick_Y;
								}
										
								this.draw_NowBrick();//画现在的方块
				
								Sound.Play(3);
								this.addBrickToMap();//加入地图数组
								this.checkFull();//是否消行
								this.addNextBrick();//加入下一 个方块
				
								this.drawBlocks();
								this.checkFail();//检验是否失败
					}
		
					}
					catch
					{
						
					}
					
				}

		private void tools_Use(int n)//向对方使用道具
		{
			if(Bridge.queue.Count>0)
				if(this.toolSum>0)
				{
					Bridge.stack.Add(n);
					this.toolSum--;
					Sound.Play(4);
				}
		}
		//道具使用
		public void keyToolPress(Keys k)
		{
			
			try
			{
				if(k==	Form1.key[5])//Form1.key[5]://切换道具
				{
					if(Bridge.queue.Count>0)
						if(this.toolSum>0)
						{
							Bridge.stack.Add(2);
							Sound.Play(1);
						}

				}
				else if(k== Form1.key[6])//对自己使用道具
				{

					if(Bridge.queue.Count>0)
						if(this.toolSum>0)
						{
										
							Bridge.stack.Add(1);
							this.toolSum--;
							Sound.Play(8);
						}

				}
				else if(k== Form1.key[7])//对2使用道具
				{
					this.tools_Use(12);
				}
				else if(k== Form1.key[8])//对3使用道具
				{
					this.tools_Use(13);
				}
				else if(k== Form1.key[9])//对4使用道具
				{
					this.tools_Use(14);
				}
				else if(k== Form1.key[10])//对5使用道具
				{
					this.tools_Use(15);
				}
				else if(k== Form1.key[11])//对6使用道具
				{
					this.tools_Use(16);
				}

				else if(k== Keys.W)//注意开始才用,
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
