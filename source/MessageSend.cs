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
	public interface Message_Bridge
	{
		void messSendOut(string s);

	}	
	public class MessageSend: Message_Bridge
	{
		private System.Windows.Forms.TextBox txtSendContent;
		
		private System.Windows.Forms.ListBox lstContent;
		//�������������
		private TcpClient tcpclient=null;
		//����������ݽ�������ͨ��
		private NetworkStream Strm;
		//�û���
		private string UserAlias;
		private bool connect=false;
		private Thread thread=null;
		private SmallBrick_Tetirs[] smallbrick=new SmallBrick_Tetirs[5];
		

		//object ��ҪΪ����ʹ��ʱ������ ��ţ�2��3����������Ӧ�� �û���
		public static object[] GameTool_Name;

		//�ӿڡ�����ʼ �� ����
		private fail_start_Interface FsInterface;
		//��������
		public static  int OnlineNumber=1;
		//ʧ������
		public static int FailNumber=0;

		public MessageSend(Form1 f,TcpClient t,string name,fail_start_Interface fs)
		{
			//��ͼ���ݻ�ȡ�ӿ�
		
			//��ʼ �� ���� �Ľӿ�
			this.FsInterface=fs;

			this.lstContent=f.lstContent;
			this.txtSendContent=f.txtSendContent;
			this.tcpclient=t;
			//this.smallbrick=smallB;
			
			//�����Ϸ��ϢС����
			this.smallbrick[0]=new SmallBrick_Tetirs(f,f.label_SmallTetirs1,1,12,21,8);
			this.smallbrick[1]=new SmallBrick_Tetirs(f,f.label_SmallTetirs2,2,12,21,8);
			this.smallbrick[2]=new SmallBrick_Tetirs(f,f.label_SmallTetirs3,3,12,21,8);
			this.smallbrick[3]=new SmallBrick_Tetirs(f,f.label_SmallTetirs4,4,12,21,8);
			this.smallbrick[4]=new SmallBrick_Tetirs(f,f.label_SmallTetirs5,5,12,21,8);
			//
			GameTool_Name=this.smallbrick;
			//�������������ݽ�������ͨ����NetworkStream)
			Strm=tcpclient.GetStream();
			this.UserAlias=name;
			this.Message_load();
		}
		
		//�����ش���ʱ�������� Load ���������Load ��������У����Login���ڵ���ɹ�����ô��ȡ������������Ӳ�
		//�õ�����������ݽ�������ͨ��������������͡�CONN���������ͬʱ����һ���µ��߳�������Ӧ�ӷ��������ص���Ϣ���ڷ���ServerResponse������ʵ�֣�
		private void Message_load()
		{
			try
			{
				
				//����һ���µ��̣߳�ִ�з���this.ServerResponse()���Ա�����Ӧ�ӷ��������ص���Ϣ
				thread=new Thread(new ThreadStart(this.ServerResponse));
				this.thread.IsBackground=true;
				thread.Start();
				this.connect=true;
				//����������͡�CONN���������������ĸ�ʽ��������˵Ķ���ĸ�ʽһ�£�
				//�����ʽΪ�������־����CONN��|�����ߵ��û���|
				string cmd="CONN|"+UserAlias.Trim()+"|";
				//���ַ���ת��Ϊ�ַ�����
				Byte[] outbytes=System.Text.Encoding.Unicode.GetBytes(cmd.ToCharArray());
				Strm.Write(outbytes,0,outbytes.Length);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}	
		}

		//��Ϸ������������� ����ȫ���� �� ����֮�� ��Ҫ�޸ģ� 
	   // 1 �κ�һ��������Ϣ û�п��� ��Ϣ�Ķ�ʧ �ͱ仯
		//һ�� �������� �� ����ԭ���� ��Ÿ��ţ������ж�

		//ServerResponse()�������ڽ��մӷ��������ص���Ϣ�����ݲ�ͬ�����ִ����Ӧ�Ĳ���
		private void ServerResponse()
		{
			//����һ��byte���飬���ڽ��մӷ������˷����������ݣ�ÿ�����ܽ��յ����ݰ�����󳤶�Ϊ1024���ֽ�
			byte[] buff=new byte[1024];
			string msg;
			int len;
			try
			{
				if(!Strm.CanRead)
					return;
				//����ѭ�������ϵ�����������н�����ֱ��������������QUIT��������˳�ѭ����
				//�ر����ӣ����ҹرտͻ��˳���
				while(this.connect)
				{
					//�����еõ����ݣ������뵽buff�ַ�������
					len=Strm.Read(buff,0,buff.Length);
					//���ַ�����ת��Ϊ�ַ���
					msg=null;
					msg=System.Text.Encoding.Unicode.GetString(buff,0,len);
					msg.Trim();
					string[] tokens=msg.Split(new Char[]{'|'});
					//tokens[0]�б����������־����LIST��JOIN��QUIT��
					//tokens[1],tokens[2],tokens[3] ��Ҫ�����Ƿ����
					switch(tokens[0])
					{
						case "FULL"://��������������
							this.connect=false;
					
							MessageBox.Show("�������������������½������������");
							Application.Exit();
							break;
						case "TIMEOUT":
							this.connect=false;
							MessageBox.Show(" �˷�������Ϸ�ѿ�ʼ�����½������������");
							Application.Exit();
							break;
						case "SAMENAME"://�û�����ͬ
							this.connect=false;
					
							MessageBox.Show("�����û����Ѵ��ڣ������µ�½��");
							Application.Exit();
							break;
						case "GIVE":
							Form1.userNumber=tokens[1];
							break;

					//��ʱ�ӷ��������ص���Ϣ��ʽ�������־����JOIN��|�ոյ�����û���|
						case "JOIN":
							//this.smallbrick.man_Come();
							lstContent.Items.Add(tokens[1]+" "+" ���������ң�");

							for(int i=0;i<this.smallbrick.Length;i++)
							{
								if(this.smallbrick[i].name==null)
								{
									this.smallbrick[i].name=tokens[1].Trim();
									this.smallbrick[i].man_Come();//���˽��� 
									MessageSend.OnlineNumber++;
									break;
								}
							}
							

							break;
						case "OUT"://�����뿪
							
							int num2=this.Name_Compare(tokens[1].Trim());
							if(num2!=-1)
							{
								this.smallbrick[num2].man_Out();
								MessageSend.OnlineNumber--;
							}
							break;//�����뿪

						case "JOINSORT"://�������������Ϣ
							
							for(int i=1;i<tokens.Length-1&&i<=5;i++)
							{
								this.smallbrick[i-1].name=tokens[i].Trim();
								this.smallbrick[i-1].man_Come();// ���˽���
								MessageSend.OnlineNumber++;

							}
							
							break;
						case "START"://���˿�ʼ
							this.lstContent.Items.Add(tokens[1]+" ��ʼ");
							break;
						case "MAP"://�Է���Ϸ��Ϣ ����
							
							int num1=this.Name_Compare(tokens[1].Trim());
							if(num1!=-1)
								this.smallbrick[num1].SmallBrick_pic(tokens[2],tokens[3]);
							break;
						case "GAMESTART":
							this.FsInterface.StartGame();
							for(int i=0;i<this.smallbrick.Length;i++)
							{
								if(this.smallbrick[i].name!=null)
								{
									this.smallbrick[i].start();//��Ϸ��ʼ
								}
							}
							MessageSend.FailNumber=0;
							break;
						case "GAME"://����ע�ⰲȫ
							int n=int.Parse(tokens[1].Trim());
							Bridge.stack.Add(n);
							Bridge.stack.Add(3);//������Ϣ

							Sound.Play(4);
							break;
		
						case "FAIL":

							this.lstContent.Items.Add(tokens[1]+" ʧ��");
							int numf=this.Name_Compare(tokens[1].Trim());
							if(numf!=-1)
							{
								this.smallbrick[numf].Game_Lervel=tokens[2].Trim();
								this.smallbrick[numf].Final(MessageSend.OnlineNumber-MessageSend.FailNumber);
								MessageSend.FailNumber++;
							}

							break;
						case "WIN"://��Ϸ����
							if(!SingleTetirs.FailOrWin)
								this.lstContent.Items.Add("ף���㣬ʤ����");
							//��������
							this.FsInterface.FailGame();
							for(int i=0;i<this.smallbrick.Length;i++)
							{
								if(this.smallbrick[i].name!=null)
								{
									this.smallbrick[i].start();//��Ϸ����׼��״̬
								}
							}
							MessageSend.FailNumber=0;
							break;
					//����ӷ������յ���QUIT�������ô��ֹ������������Ӳ��ҹرտͻ��˳���
						case "QUIT":
							
							this.connect=false;
							break;
						case "OVER":			
							this.connect=false;
					
							MessageBox.Show("�������رգ������µ�½��","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
							Application.Exit();
							break;
						
						case "CHAT":
							lstContent.Items.Add(tokens[1]);
							break;

					}
					
					msg=null;
					
				}
				//�ر�����
				tcpclient.Close();
				//�رտͻ��˳���
			}
			catch
			{
				lstContent.Items.Add("���緢������");
			}
		}

		private int Name_Compare(string s)
		{
			for(int i=0;i<this.smallbrick.Length;i++)
			{
				if(this.smallbrick[i].name!=null)
				{
					if(this.smallbrick[i].name.CompareTo(s)==0)
						return i;
				}
			}
			return -1;
		}

		public void sendMessage(string m)
		{
			try
			{
					//��ʱ����ĸ�ʽ�ǣ������־����CHAT��|�����ߵ��û�������������|
					
					//���ַ���ת��Ϊ�ַ�����
				Byte[] outbytes=System.Text.Encoding.Unicode.GetBytes(m.ToCharArray());
				lock(this)
				{
					Strm.Write(outbytes,0,outbytes.Length);
				}
				
			}
			catch
			{
				lstContent.Items.Add("���緢�����������µ�½");
			}

		}

		public void Exit()
		{
			if(this.connect)
			{
				try
				{
					string message="EXIT|"+UserAlias+"|"+Form1.userNumber+"|";
					//���ַ���ת��Ϊ�ַ�����
					Byte[]outbytes=System.Text.Encoding.Unicode.GetBytes(message.ToCharArray());
					Strm.Write(outbytes,0,outbytes.Length);
					
				}
				catch{}
				try
				{
					this.connect=false;
					if(this.thread==null)
						return ;
					if(this.thread.IsAlive)
					{
						
						this.tcpclient.Close();
						this.thread.Abort();
					}
				}
				catch{}
			}

		}
		#region Message_Bridge ��Ա

		public void messSendOut(string s)
		{
			// TODO:  ��� MessageSend.messSendOut ʵ��
			lock(this)
			{
				
				//���ַ���ת��Ϊ�ַ�����
				Byte[] outbytes=System.Text.Encoding.Unicode.GetBytes(s.ToCharArray());
				lock(this)
				{
					Strm.Write(outbytes,0,outbytes.Length);
				}
				

			}
		}

		#endregion
		
	}
}


