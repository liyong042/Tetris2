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
	//
	public class MoveNext_Brick//��ʾ��һ������
	{
		private System.Windows.Forms.Panel Next_panel=null;//��ʾ����Ŀؼ�
		private Draw Next_draw=null;//��ͼ
		private SingleTetirs st=null;//�����̨��
		public MoveNext_Brick(Panel p,SingleTetirs sTetirs)
		{
			this.Next_panel=p;
			this.st=sTetirs;
			this.Next_draw=new Draw(this.st);
			Thread t=new Thread(new ThreadStart(this.drawNext_Brick));
			t.IsBackground=true;
			t.Start();
		}
		//��� panel2 (��һ��������ʾ����)
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
		private void drawNext_Brick()//����һ������浽paint2����
		{
			try
			{
				Graphics g=Graphics.FromImage(this.Next_panel.BackgroundImage);
				g.Clear(this.Next_panel.BackColor);
				//������һ������
				this.Next_draw.DrawBrickGroup(0,0,this.st.Next_Brick_Num,0,this.st.Now_Brick_Color,g);
				//��������һ������
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
