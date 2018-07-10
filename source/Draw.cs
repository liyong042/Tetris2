using System;
using System.Drawing;
using System.Collections;
namespace 俄罗斯1
{
	
	public class Draw
	{
		private SingleTetirs st;
		public Draw(SingleTetirs s)
		{
			this.st=s;
		}
		//画方块 画出 num 所对应的小方块
		public void DrawBrick(int x,int y,int num,Graphics gr)
		{
			try
			{
		
				//绘制小方块
				gr.DrawImageUnscaled(this.st.formControl.imageList1.Images[num],x*this.st.Brick_Width,
					y*this.st.Brick_Width,this.st.formControl.imageList1.Images[num].Width,this.st.formControl.imageList1.Images[num].Width);
			}
			catch{}
		}
		//绘出现在的移动方块
		public void DrawBrickGroup(Graphics g3)
		{
			try
			{
				for(int i=0;i<5;i++)//绘出现在的方块
					for(int j=0;j<5;j++)
					{
						//判断是否越界
						if(  (i+this.st.Now_Brick_X)>=0 && (i+this.st.Now_Brick_X)<this.st.Gridx  &&  (j+this.st.Now_Brick_Y)>=0 && (j+this.st.Now_Brick_Y)<this.st.Gridy	)
							if(this.st.NowBrick.Brick_Array[st.Now_Brick_Direct,i,j]==1)
								this.DrawBrick(i+st.Now_Brick_X,j+st.Now_Brick_Y,st.Now_Brick_Color,g3);

					}
			}
			catch{}

		}
	//画出type对应的方块
		public void DrawBrickGroup(int x,int y,int type,int direct ,int c,Graphics g3)//画出type对应的方块
		{
			try
			{
				SuperBrick sb=(SuperBrick)st.BrickArray[type];

				for(int i=0;i<5;i++)//绘出现在的方块
					for(int j=0;j<5;j++)
					{
						if(sb.Brick_Array[direct,i,j]==1)
							this.DrawBrick(i+x,j+y,c,g3);

					}
			}
			catch{}

		}


	}
}
