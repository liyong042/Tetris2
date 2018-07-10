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

namespace ����˹1
{
	
	public class SmallBrick_Tetirs:�Զ���ؼ�_LabelSmallTetir.Small_Pictrue_Inter
	{
		private ImageList small_imgList;

		private �Զ���ؼ�_LabelSmallTetir.UserControl1 labelCon;

		private int number=0;
		public string name;//�û���
		private string map=null;//������ʾ�ĵ�ͼ��Ϣ
		public string Game_Lervel="ѧͽ";//�ȼ�
	private  int SortNumber=0;
		private  int smallBrick_Width;// С�����
		private  int gridx;
		private int gridy;
		public Thread smallBrick_T;
	
		private int head;//ͷ
		public bool  haveBody=false;//�Ƿ�����
		private Rectangle rect;
		private Form1 mainForm=null;
		public SmallBrick_Tetirs(Form1 f,�Զ���ؼ�_LabelSmallTetir.UserControl1 con,int num,int x,int y,int side)//(Form1 f,Panel con,int num,int x,int y,int side)
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
			
			////��ǰ��Ϸ��� ������Ϣ���� �ķ����� ���뵽 ί��
			PaintDelegate a=new PaintDelegate(this.PaintTopMess);
			Form1.multiDelegate+=a;
		}
		//��������Ϣ���� ����ͼ����
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
			try//���±�Խ��
			{
				gr.DrawImage(this.small_imgList.Images[type],x*this.smallBrick_Width,y*this.smallBrick_Width,this.smallBrick_Width,this.smallBrick_Width);
			}
			catch{}
		}
		//��ǰ��Ϸ��� ������Ϣ����
		private void PaintTopMess(Graphics g)
		{
			if(!this.haveBody)//���û����
				return ;

			g.FillRectangle(Brushes.Green,this.rect);
			g.DrawString("�س�  "+this.name,this.mainForm.Font,new SolidBrush(Color.Black),this.rect.Left+3,this.rect.Top+4);
			g.DrawString("�ȼ�  "+this.Game_Lervel,this.mainForm.Font,new SolidBrush(Color.Black),this.rect.Left+3,this.rect.Top+22);

			Font	f = new System.Drawing.Font("����_GB2312", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			g.DrawString(this.number.ToString(),f,new SolidBrush(Color.White),this.rect.Left+70,this.rect.Top+15) ;

		}
	

		//��ҽ���
		public void man_Come()
		{
			
			this.haveBody=true;
			this.labelCon.Invalidate();
			this.mainForm.Invalidate(this.rect);//������Ϣ����

		}

		public void come()//��Ϸ���¿�ʼ
		{
			this.SortNumber=0;
			this.man_Come();
		}
		public void Ready()//׼��״̬
		{
			//����׼������
			this.SortNumber=0;
		}
		public void start()//��ʼ
		{
			
			this.map=null;//���map
			this.SortNumber=0;//����Ϊ0��
			this.labelCon.Invalidate();
			//�һ�����
			//�����߳�
		}
		public void Final(int num)//ʧ��
		{
			
			this.SortNumber=num;
			this.labelCon.Invalidate();


		}

		public void man_Out()//����뿪
		{
			this.haveBody=false;
			this.map=null;
			this.name=null;
			this.SortNumber=0;
			this.labelCon.Invalidate();
			this.mainForm.Invalidate(this.rect);//������Ϣ����	
		}
		#region Small_Pictrue_Inter ��Ա

		//�Է���Ϸ��Ϣ���ƣ��Է��ķ��飩
		public void small_PaintPic(Graphics g)
		{
			// TODO:  ��� SmallBrick_Tetirs.small_PaintPic ʵ��

			if(!this.haveBody)//�˴���û����
				return;
		//����С���屳��
			g.DrawImage(Form1.ColorImage[this.number-1],10,0,80,160);
		//�Ƿ�����Ϸ��Ϣ
			if(this.map==null)
				return;
		//������ϷС����
			
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
