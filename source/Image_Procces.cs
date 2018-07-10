using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Threading;
namespace 俄罗斯1
{
	
	public class Image_Procces//图片处理
	{
		public Image_Procces()
		{
		}
		//添加彩色背景图片
		public static void  Image_AddPicture(Image m,Control p)
		{
			try
			{
				Bitmap bmp=new Bitmap(m);
				Graphics g=Graphics.FromImage(p.BackgroundImage);
				g.Clear(p.BackColor);
				g.DrawImage(bmp,55,55,80,200);
				g.Dispose();
				bmp.Dispose();
			}
			catch{}
		}
		//将图片灰化
		public static void Picture_HuiHua(Image m)
		{
			Bitmap bmp=(Bitmap)m;
			for(int i=0;i<bmp.Width-1;i++)
				for(int j=0;j<bmp.Height-1;j++)
				{
					Color c=bmp.GetPixel(i,j);
					if(c.A!=0)
					{
						int rgb=(c.R+c.G+c.B)/3;
						//颜色的透明度设置为150 
						bmp.SetPixel(i,j,Color.FromArgb(150,rgb,rgb,rgb));
					}

				}

		}
		public static void Image_Hui(Image m,Control p)//灰化图片
		{
			try
			{
				Bitmap bmp=new Bitmap(m);
				for(int i=0;i<bmp.Width-1;i++)
					for(int j=0;j<bmp.Height-1;j++)
					{
						Color c=bmp.GetPixel(i,j);
						if(c.A!=0)
						{
							int rgb=(c.R+c.G+c.B)/3;
							//颜色的透明度设置为150 
							bmp.SetPixel(i,j,Color.FromArgb(150,rgb,rgb,rgb));
						}

					}
				Graphics g=Graphics.FromImage(p.BackgroundImage);
				g.Clear(p.BackColor);
				g.DrawImage(bmp,55,55,80,200);
				g.Dispose();
				bmp.Dispose();
			}
			catch{}
			
		}
			//游戏开始 
		public static void Image_GameStart(Control con)
		{
			Graphics g=con.CreateGraphics();
			Font	f = new System.Drawing.Font("GungsuhChe", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			g.DrawString("Ready  Go ",f,new SolidBrush(Color.Red),30,150);
			g.Dispose();
		}

		//游戏失败时 灰化背景 显示得分 和 
		public static void Image_GameStop(Control p,long Game_Score,long  Game_Line,Image module)
		{
			try
			{
				Graphics fail_G	=p.CreateGraphics();
				Bitmap m=new Bitmap(module,p.Width,p.Height);
				//灰化背景
				for(int i=0;i<m.Width-1;i++)
					for(int j=0;j<m.Height-1;j++)
					{
						Color c=m.GetPixel(i,j);
						if(c.A!=0||c!=p.BackColor)
						{
							int rgb=(c.R+c.G+c.B)/3;
							m.SetPixel(i,j,Color.FromArgb(100,rgb,rgb,rgb));
						}

					}

				Graphics g=Graphics.FromImage(m);
				Font	f = new System.Drawing.Font("楷体_GB2312", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				g.DrawString("GAME OVER",f,new SolidBrush(Color.Red),1,60);
				int n=MessageSend.OnlineNumber-MessageSend.FailNumber;
				g.DrawString(n.ToString(),f,new SolidBrush(Color.White),80,150);
				string s1="得分：    "+Game_Score.ToString();
				string s2="行数：    "+Game_Line.ToString();
				Font t = new System.Drawing.Font("楷体_GB2312", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
				g.DrawString(s1,t,new SolidBrush(Color.White),30,200);
				g.DrawString(s2,t,new SolidBrush(Color.White),30,240);
				fail_G.Clear(p.BackColor);
				fail_G.DrawImage(m,0,0,p.Width,p.Height);
				fail_G.Dispose();
				m.Dispose();
				
			}
			catch{}

			
		}
		//为panel 添加 背景图片
		public static void  ImageForBackImage(Panel p)
		{
			try
			{
				Image Im=new Bitmap(p.Width,p.Height);//设置游戏容器背景
				Graphics g=Graphics.FromImage(Im);
				g.Clear(p.BackColor);
				p.BackgroundImage=Im;
				g.Dispose();
			}
			catch{}
		}
	}
}
