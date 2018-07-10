using System;
using System.Drawing;
using System.Collections;
namespace ����˹1
{
	
	public class Draw
	{
		private SingleTetirs st;
		public Draw(SingleTetirs s)
		{
			this.st=s;
		}
		//������ ���� num ����Ӧ��С����
		public void DrawBrick(int x,int y,int num,Graphics gr)
		{
			try
			{
		
				//����С����
				gr.DrawImageUnscaled(this.st.formControl.imageList1.Images[num],x*this.st.Brick_Width,
					y*this.st.Brick_Width,this.st.formControl.imageList1.Images[num].Width,this.st.formControl.imageList1.Images[num].Width);
			}
			catch{}
		}
		//������ڵ��ƶ�����
		public void DrawBrickGroup(Graphics g3)
		{
			try
			{
				for(int i=0;i<5;i++)//������ڵķ���
					for(int j=0;j<5;j++)
					{
						//�ж��Ƿ�Խ��
						if(  (i+this.st.Now_Brick_X)>=0 && (i+this.st.Now_Brick_X)<this.st.Gridx  &&  (j+this.st.Now_Brick_Y)>=0 && (j+this.st.Now_Brick_Y)<this.st.Gridy	)
							if(this.st.NowBrick.Brick_Array[st.Now_Brick_Direct,i,j]==1)
								this.DrawBrick(i+st.Now_Brick_X,j+st.Now_Brick_Y,st.Now_Brick_Color,g3);

					}
			}
			catch{}

		}
	//����type��Ӧ�ķ���
		public void DrawBrickGroup(int x,int y,int type,int direct ,int c,Graphics g3)//����type��Ӧ�ķ���
		{
			try
			{
				SuperBrick sb=(SuperBrick)st.BrickArray[type];

				for(int i=0;i<5;i++)//������ڵķ���
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
