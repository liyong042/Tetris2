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
	//
	public class MoveNext_Brick//显示下一个方块
	{
		private System.Windows.Forms.Panel Next_panel=null;//显示方块的控件
		private Draw Next_draw=null;//绘图
		private SingleTetirs st=null;//方块后台类
		public MoveNext_Brick(Panel p,SingleTetirs sTetirs)
		{
			this.Next_panel=p;
			this.st=sTetirs;
			this.Next_draw=new Draw(this.st);
			Thread t=new Thread(new ThreadStart(this.drawNext_Brick));
			t.IsBackground=true;
			t.Start();
		}
		//清空 panel2 (下一个方块显示窗体)
		public MoveNext_Brick(Panel p)
		{
			try
			{
				
				this.Next_panel=p;
				Graphics g=Graphics.FromImage(this.Next_panel.BackgroundImage);
				g.Clear(this.Next_panel.BackColor);
				this.Next_panel.Invalidate();
				this.Next_panel .Update();

				Graphics g2=this.Next_panel.CreateGraphics();
				g2.DrawImage(this.Next_panel.BackgroundImage,0,0,this.Next_panel.Width,this.Next_panel.Height);
				g.Dispose();
				g2.Dispose();
			}
			catch{}
		}
		private void drawNext_Brick()//将下一个方块绘到paint2容器
		{
			try
			{
				Graphics g=Graphics.FromImage(this.Next_panel.BackgroundImage);
				g.Clear(this.Next_panel.BackColor);
				//绘制下一个方块
				this.Next_draw.DrawBrickGroup(0,0,this.st.Next_Brick_Num,0,this.st.Now_Brick_Color,g);
				//绘制下下一个方块
				this.Next_draw.DrawBrickGroup(0,5,this.st.Next_Brick_Num2,0,this.st.Next_Brick_Color2,g);
				Graphics g2=this.Next_panel.CreateGraphics();
				g2.DrawImage(this.Next_panel.BackgroundImage,0,0,this.Next_panel.Width,this.Next_panel.Height);
				g.Dispose();
				g2.Dispose();
			}
			catch{}
		}
	}
}
