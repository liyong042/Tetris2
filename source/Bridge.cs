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
	
	public class Bridge
	{
		//Tetirs_bridge �ӿ� ,����Ҫ������ ʵ�� ���� ��ʹ�� �����У�ɾ��
		private Tetirs_bridge tb;
		//Message_Bridge �ӿ� ������Ҫ������ �����緢�� ��Ϣ �磺������Ϣ������ʹ��
		private  Message_Bridge mess_Interface;
		//������У��ɶ��߳�ִ�� ���еĲ�������
		public static ArrayList stack;//����ջ
		//���߶��У������û���õĵ���
		public static ArrayList queue;//���߶���
		//��������ִ���߳�
		public Thread bridge_t;
		//�Զ���ؼ�label ������ʾ���߶��� �ĵ���
		private �Զ���ؼ�label.UserControl1 toolCon;
		//������Ϣ��ʾ
		private Label toolMess;
		private ImageList bridge_Mlist;
	
		public Bridge(Tetirs_bridge t1,Form1 f, Message_Bridge mb)
		{
			
			this.tb=t1;
			this.mess_Interface=mb;

			this.toolCon=f.panel_toolCon;
			this.toolMess=f.label_toolMess;
			this.bridge_Mlist=f.imageList1;

			stack=new ArrayList();
			queue=new ArrayList();
			this.toolCon.queList=queue;
			this.bridge_t=new Thread(new ThreadStart(this.Reserve));
			this.bridge_t.IsBackground=true;
			this.bridge_t.Start();
		}
		public void Bridge_start()//��ʼ
		{
			try
			{

				this.Bridge_stop();//��ֹͣ

				this.bridge_t=new Thread(new ThreadStart(this.Reserve));
				this.bridge_t.IsBackground=true;
				this.bridge_t.Start();
			}
			catch{}
		}
		private string queue_Value(int n)
		{
			string tools=null;
			switch(n)
			{
				case 9:
					tools="41";//��һ��
					break;
				case 10:
					tools="42";//��2��
					break;
				case 11:
					tools="43";//��3��
					break;
				case 12:
					tools="35";//����
					break;
				case 13:
					tools="31";//��һ��
					break;
				case 14:
					tools="32";//��2��
					break;
				case 15:
					tools="33";//��3��
					break;
				case 16:
					tools="36";//����
					break;
				default:
					break;

			}
			return tools;
		
		}
		private void SendGameTool_Mess(int n)
		{
			if(queue.Count>0)//�Ƿ��е���
			{
				//���ص�������Ӧ�Ĳ�������
				string tools=this.queue_Value((int)queue[0]);	
				queue.RemoveAt(0);
				this.drawQueue();//�ػ�
				//���͵���
				SmallBrick_Tetirs smallBrick2=(SmallBrick_Tetirs)MessageSend.GameTool_Name[n];
				if(smallBrick2.name!=null)
				{
					string cont2="GAME|"+smallBrick2.name+"|"+tools+"|";
					this.mess_Interface.messSendOut(cont2);//������Ϣ
				}				
			}
		} 
		public void Bridge_stop()//ֹͣ����ִ���߳�
		{
			try
			{
				if(this.bridge_t!=null)
				{
					if(this.bridge_t.IsAlive)
						this.bridge_t.Abort();
				}
				stack.Clear();
				queue.Clear();
				this.toolCon.Invalidate();//�ػ�
			}
			catch{}
		}

	
    //�̷߳����� ִ�� stack �еĲ�������
		private void Reserve()
		{
			
			try
			{
				bool bridge_pause=false;

				while(true)
				{
					if(bridge_pause)//�����Ϸʧ��ֹͣ
					{
						if(stack.Count>0)//�����������
							stack.Clear();

						if(queue.Count>0)//������е���
						{
							queue.Clear();
							this.toolCon.Invalidate();//�ػ�
						}
					
						break;
					}
				
					if(stack.Count==0)//���û������
					{
						Thread.Sleep(100);//��ϢƬ��
						continue;
					}
				
					int command=(int)stack[0];
						
						
					switch(command)
					{
						case 1://ʹ�õ���
						
							if( (int)queue[0]>8)
							{
								switch((int)queue[0])
								{
									case 9:
										stack.Add(41);//��һ��
										break;
									case 10:
										stack.Add(42);//��2��
										break;
									case 11:
										stack.Add(43);//��3��
										break;
									case 12:
										stack.Add(35);//����
										break;
									case 13:
										stack.Add(31);//��һ��
										break;
									case 14:
										stack.Add(32);//��2��
										break;
									case 15:
										stack.Add(33);//��3��
										break;
									case 16:
										stack.Add(36);//����
										break;
									default:
										break;

								}
								queue.RemoveAt(0);//ɾ������
								this.drawQueue();//�ػ�
							}
							break;
						case 2://ת��s��
							//����ת��
							object ob=queue[0];
							queue.RemoveAt(0);
							queue.Add(ob);

							this.drawQueue();//�ػ�
							break;

						case 3:
							if(SingleTetirs.ArrayVisit)//�����Ƿ�ɷ���
							{
								Thread tt=new Thread(new ThreadStart(this.toolUsed_map));
								tt.IsBackground=true;
								tt.Start();
							}

							break;
						case 4:
						
							this.drawQueue();
							break;

						case 11:	//��ʹ�õ��� ����
							break;
						case 12://�ԶԷ�2ʹ�õ��� 
							this.SendGameTool_Mess(0);

							break;
						case 13://�� �Է�3ʹ�õ��� 
							this.SendGameTool_Mess(1);

							break;
						case 14://�ԶԷ�4ʹ�õ��� 
							this.SendGameTool_Mess(2);

							break;
						case 15://�� �Է�5ʹ�õ��� 
							this.SendGameTool_Mess(3);

							break;
						case 16:////�� �Է�6ʹ�õ��� 
							this.SendGameTool_Mess(4);

							break;
						case 31://��һ��
							this.tb.Remove(1);
							
							Thread.CurrentThread.Join(200);
							break;

						case 32://��2��
							this.tb.Remove(2);
							Thread.CurrentThread.Join(200);
							
							break;

						case 33://��3��
							this.tb.Remove(3);
							
							Thread.CurrentThread.Join(200);
							break;
						case 35://����
							
							break;
						case 36://����

							break;
						case 41://��һ��
							if(!this.tb.HightRow(1))//�����������
							{
								bridge_pause=true;
								continue;
							}

							Thread.CurrentThread.Join(200);
							break;
						case 42://��2��
							if(!this.tb.HightRow(2))//�����������
							{
								bridge_pause=true;
								continue;
							}
							Thread.CurrentThread.Join(300);
							break;
						case 43://��3��
							if(!this.tb.HightRow(3))//�����������
							{
								bridge_pause=true;
								continue;
							}

							Thread.CurrentThread.Join(400);
							break;

						case 52://�û�ÿ��3�� �����˾���2 ��

							string ss3="GAMEOTHERS|"+Form1.userName+"|42|";

							//������Ϣ
							this.mess_Interface.messSendOut(ss3);
							break;
						case 53://�û�ÿ��4�� �����˾���3��
							string ss4="GAMEOTHERS|"+Form1.userName+"|43|";

							//������Ϣ
							this.mess_Interface.messSendOut(ss4);
							break;

					}
					stack.RemoveAt(0);//ɾ������
				}

			}
			catch{}
		}
		private void drawMess(int n)
		{
			//"����ʹ��˵��";	
			switch(n)
			{
				
				case 9:
					//tools="41";//��һ��
					this.toolMess.Text="�ӵײ�������һ�㷽��";	
					break;
				case 10:
					//tools="42";//��2��
						this.toolMess.Text="�ӵײ������Ӷ��㷽��";	
					break;
				case 11:
					//tools="43";//��3��
					this.toolMess.Text="�ӵײ����������㷽��";	
					break;
				case 12:
					//tools="35";
					this.toolMess.Text="�����½��ٶȼӿ�20��";	

					break;
				case 13:
					//tools="31";
						this.toolMess.Text="�ӵײ����һ�㷽��";	
					break;
				case 14:
					//tools="32";
					this.toolMess.Text="�ӵײ�������㷽��";	
					break;
				case 15:
					//tools="33";
					this.toolMess.Text="�ӵײ�������㷽��";	
					break;
				case 16:
					//tools="36";
					this.toolMess.Text="�����½��ٶȼ���20��";	

					break;
				default:
					break;
			}
		}
		private  void drawQueue()//�ػ�
		{
			this.toolCon.Invalidate();
			this.toolCon.Update();
			if(queue.Count>0)
				this.drawMess((int)queue[0]);


		}
		//��Ϊ���͵�ͼ��Ϣ ��ʱ�䳤 ������ ������߳�
		private void toolUsed_map()
		{
			int head=0;//��Ϣ��ʼ��
			string ss=this.tb.map(ref head);//��ͼ��Ϣ
												
			ss="MAP|"+Form1.userName+"|"+head.ToString()+"|"+ss.Trim()+"|";

			//������Ϣ
			this.mess_Interface.messSendOut(ss);
			// ɾ����ǰ���������� ���з��͵�ͼ ����
		}
	}
}
