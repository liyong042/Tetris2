using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Drawing2D;

namespace 俄罗斯1
{
	
	public class SmallBrick_Tetirs:自定义控件_LabelSmallTetir.Small_Pictrue_Inter
	{
		private ImageList small_imgList;

		private 自定义控件_LabelSmallTetir.UserControl1 labelCon;

		private int number=0;
		public string name;//用户名
		private string map=null;//方块显示的地图信息
		public string Game_Lervel="学徒";//等级
	private  int SortNumber=0;
		private  int smallBrick_Width;// 小方块宽
		private  int gridx;
		private int gridy;
		public Thread smallBrick_T;
	
		private int head;//头
		public bool  haveBody=false;//是否有人
		private Rectangle rect;
		private Form1 mainForm=null;
		public SmallBrick_Tetirs(Form1 f,自定义控件_LabelSmallTetir.UserControl1 con,int num,int x,int y,int side)//(Form1 f,Panel con,int num,int x,int y,int side)
		{
			this.mainForm=f;
			this.small_imgList=f.imageList1;

			this.labelCon=con;
			this.labelCon.addPic_Inter(this);

			this.number=num+1;
			this.gridx=x;
			this.gridy=y;
			this.smallBrick_Width=side;
			this.rect=new Rectangle(this.labelCon.Location.X,this.labelCon.Location.Y-70,96,42);
			
			////当前游戏玩家 个人信息绘制 的方法体 加入到 委托
			PaintDelegate a=new PaintDelegate(this.PaintTopMess);
			Form1.multiDelegate+=a;
		}
		//将网络信息加入 到地图中来
		public void SmallBrick_pic(string h,string c)
		{
				int n=int.Parse(h);
				if( (n+c.Length)==this.gridx*this.gridy)
				{
					this.map=null;
					this.map=c;
					this.head=n;
					this.labelCon.Invalidate();
					
				}

			
		}
		private void drawSmallBlock(int x,int y,int type,Graphics gr)
		{
			try//有下标越界
			{
				gr.DrawImage(this.small_imgList.Images[type],x*this.smallBrick_Width,y*this.smallBrick_Width,this.smallBrick_Width,this.smallBrick_Width);
			}
			catch{}
		}
		//当前游戏玩家 个人信息绘制
		private void PaintTopMess(Graphics g)
		{
			if(!this.haveBody)//如果没有人
				return ;

			g.FillRectangle(Brushes.Green,this.rect);
			g.DrawString("呢称  "+this.name,this.mainForm.Font,new SolidBrush(Color.Black),this.rect.Left+3,this.rect.Top+4);
			g.DrawString("等级  "+this.Game_Lervel,this.mainForm.Font,new SolidBrush(Color.Black),this.rect.Left+3,this.rect.Top+22);

			Font	f = new System.Drawing.Font("楷体_GB2312", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			g.DrawString(this.number.ToString(),f,new SolidBrush(Color.White),this.rect.Left+70,this.rect.Top+15) ;

		}
	

		//玩家进入
		public void man_Come()
		{
			
			this.haveBody=true;
			this.labelCon.Invalidate();
			this.mainForm.Invalidate(this.rect);//更新信息区域

		}

		public void come()//游戏重新开始
		{
			this.SortNumber=0;
			this.man_Come();
		}
		public void Ready()//准备状态
		{
			//设置准备背景
			this.SortNumber=0;
		}
		public void start()//开始
		{
			
			this.map=null;//清空map
			this.SortNumber=0;//排名为0；
			this.labelCon.Invalidate();
			//灰化背景
			//唤醒线程
		}
		public void Final(int num)//失败
		{
			
			this.SortNumber=num;
			this.labelCon.Invalidate();


		}

		public void man_Out()//玩家离开
		{
			this.haveBody=false;
			this.map=null;
			this.name=null;
			this.SortNumber=0;
			this.labelCon.Invalidate();
			this.mainForm.Invalidate(this.rect);//更新信息区域	
		}
		#region Small_Pictrue_Inter 成员

		//对方游戏信息绘制（对方的方块）
		public void small_PaintPic(Graphics g)
		{
			// TODO:  添加 SmallBrick_Tetirs.small_PaintPic 实现

			if(!this.haveBody)//此窗体没有人
				return;
		//绘制小窗体背景
			g.DrawImage(Form1.ColorImage[this.number-1],10,0,80,160);
		//是否有游戏信息
			if(this.map==null)
				return;
		//绘制游戏小方块
			
				int n;
				for(int i=this.head;i<this.gridy*this.gridx;i++)
				{
					n=int.Parse(this.map[i-this.head].ToString());
					if(n!=0&&n<9)
						this.drawSmallBlock(i%this.gridx,i/this.gridx,n,g);
				}
			
			
			
			

		}

		#endregion
	}
}
