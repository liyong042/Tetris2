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
	public interface Message_Bridge
	{
		void messSendOut(string s);

	}	
	public class MessageSend: Message_Bridge
	{
		private System.Windows.Forms.TextBox txtSendContent;
		
		private System.Windows.Forms.ListBox lstContent;
		//与服务器的连接
		private TcpClient tcpclient=null;
		//与服务器数据交互的流通道
		private NetworkStream Strm;
		//用户名
		private string UserAlias;
		private bool connect=false;
		private Thread thread=null;
		private SmallBrick_Tetirs[] smallbrick=new SmallBrick_Tetirs[5];
		

		//object 主要为道具使用时，查找 编号（2，3。。）所对应的 用户名
		public static object[] GameTool_Name;

		//接口——开始 和 结束
		private fail_start_Interface FsInterface;
		//在线人数
		public static  int OnlineNumber=1;
		//失败人数
		public static int FailNumber=0;

		public MessageSend(Form1 f,TcpClient t,string name,fail_start_Interface fs)
		{
			//地图数据获取接口
		
			//开始 和 结束 的接口
			this.FsInterface=fs;

			this.lstContent=f.lstContent;
			this.txtSendContent=f.txtSendContent;
			this.tcpclient=t;
			//this.smallbrick=smallB;
			
			//五个游戏信息小窗体
			this.smallbrick[0]=new SmallBrick_Tetirs(f,f.label_SmallTetirs1,1,12,21,8);
			this.smallbrick[1]=new SmallBrick_Tetirs(f,f.label_SmallTetirs2,2,12,21,8);
			this.smallbrick[2]=new SmallBrick_Tetirs(f,f.label_SmallTetirs3,3,12,21,8);
			this.smallbrick[3]=new SmallBrick_Tetirs(f,f.label_SmallTetirs4,4,12,21,8);
			this.smallbrick[4]=new SmallBrick_Tetirs(f,f.label_SmallTetirs5,5,12,21,8);
			//
			GameTool_Name=this.smallbrick;
			//获得与服务器数据交互的流通道（NetworkStream)
			Strm=tcpclient.GetStream();
			this.UserAlias=name;
			this.Message_load();
		}
		
		//当加载窗体时，便会进入 Load 处理程序。在Load 处理程序中，如果Login窗口登入成功，那么获取与服务器的连接并
		//得到与服务器数据交互的流通道，向服务器发送“CONN”请求命令，同时启动一个新的线程用于响应从服务器发回的信息（在方法ServerResponse（）中实现）
		private void Message_load()
		{
			try
			{
				
				//启动一个新的线程，执行方法this.ServerResponse()，以便来响应从服务器发回的信息
				thread=new Thread(new ThreadStart(this.ServerResponse));
				this.thread.IsBackground=true;
				thread.Start();
				this.connect=true;
				//向服务器发送“CONN”请求命令，此命令的格式与服务器端的定义的格式一致，
				//命令格式为：命令标志符（CONN）|发送者的用户名|
				string cmd="CONN|"+UserAlias.Trim()+"|";
				//将字符串转化为字符数组
				Byte[] outbytes=System.Text.Encoding.Unicode.GetBytes(cmd.ToCharArray());
				Strm.Write(outbytes,0,outbytes.Length);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}	
		}

		//游戏的在着里有许多 不安全因素 和 不足之处 需要修改： 
	   // 1 任何一条网络信息 没有考虑 信息的丢失 和变化
		//一旦 网络数据 因 网络原因（如 电磁干扰，网络中断

		//ServerResponse()方法用于接收从服务器发回的信息，根据不同的命令，执行相应的操作
		private void ServerResponse()
		{
			//定义一个byte数组，用于接收从服务器端发送来的数据，每次所能接收的数据包的最大长度为1024个字节
			byte[] buff=new byte[1024];
			string msg;
			int len;
			try
			{
				if(!Strm.CanRead)
					return;
				//用死循环来不断地与服务器进行交互，直到服务器发出“QUIT”命令，则退出循环，
				//关闭连接，并且关闭客户端程序
				while(this.connect)
				{
					//从流中得到数据，并存入到buff字符数组中
					len=Strm.Read(buff,0,buff.Length);
					//将字符数组转化为字符串
					msg=null;
					msg=System.Text.Encoding.Unicode.GetString(buff,0,len);
					msg.Trim();
					string[] tokens=msg.Split(new Char[]{'|'});
					//tokens[0]中保存了命令标志符（LIST或JOIN或QUIT）
					//tokens[1],tokens[2],tokens[3] 都要考虑是否存在
					switch(tokens[0])
					{
						case "FULL"://服务器人数已满
							this.connect=false;
					
							MessageBox.Show("服务器人数已满！请登陆其他服务器！");
							Application.Exit();
							break;
						case "TIMEOUT":
							this.connect=false;
							MessageBox.Show(" 此服务器游戏已开始！请登陆其他服务器！");
							Application.Exit();
							break;
						case "SAMENAME"://用户名相同
							this.connect=false;
					
							MessageBox.Show("您的用户名已存在！请重新登陆！");
							Application.Exit();
							break;
						case "GIVE":
							Form1.userNumber=tokens[1];
							break;

					//此时从服务器返回的消息格式：命令标志符（JOIN）|刚刚登入的用户名|
						case "JOIN":
							//this.smallbrick.man_Come();
							lstContent.Items.Add(tokens[1]+" "+" 加入聊天室！");

							for(int i=0;i<this.smallbrick.Length;i++)
							{
								if(this.smallbrick[i].name==null)
								{
									this.smallbrick[i].name=tokens[1].Trim();
									this.smallbrick[i].man_Come();//有人进入 
									MessageSend.OnlineNumber++;
									break;
								}
							}
							

							break;
						case "OUT"://有人离开
							
							int num2=this.Name_Compare(tokens[1].Trim());
							if(num2!=-1)
							{
								this.smallbrick[num2].man_Out();
								MessageSend.OnlineNumber--;
							}
							break;//有人离开

						case "JOINSORT"://所有在线玩家信息
							
							for(int i=1;i<tokens.Length-1&&i<=5;i++)
							{
								this.smallbrick[i-1].name=tokens[i].Trim();
								this.smallbrick[i-1].man_Come();// 有人进入
								MessageSend.OnlineNumber++;

							}
							
							break;
						case "START"://有人开始
							this.lstContent.Items.Add(tokens[1]+" 开始");
							break;
						case "MAP"://对方游戏信息 方块
							
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
									this.smallbrick[i].start();//游戏开始
								}
							}
							MessageSend.FailNumber=0;
							break;
						case "GAME"://道具注意安全
							int n=int.Parse(tokens[1].Trim());
							Bridge.stack.Add(n);
							Bridge.stack.Add(3);//发送信息

							Sound.Play(4);
							break;
		
						case "FAIL":

							this.lstContent.Items.Add(tokens[1]+" 失败");
							int numf=this.Name_Compare(tokens[1].Trim());
							if(numf!=-1)
							{
								this.smallbrick[numf].Game_Lervel=tokens[2].Trim();
								this.smallbrick[numf].Final(MessageSend.OnlineNumber-MessageSend.FailNumber);
								MessageSend.FailNumber++;
							}

							break;
						case "WIN"://游戏结束
							if(!SingleTetirs.FailOrWin)
								this.lstContent.Items.Add("祝贺你，胜利！");
							//考虑排名
							this.FsInterface.FailGame();
							for(int i=0;i<this.smallbrick.Length;i++)
							{
								if(this.smallbrick[i].name!=null)
								{
									this.smallbrick[i].start();//游戏进入准备状态
								}
							}
							MessageSend.FailNumber=0;
							break;
					//如果从服务器收到“QUIT”命令，那么中止与服务器的连接并且关闭客户端程序
						case "QUIT":
							
							this.connect=false;
							break;
						case "OVER":			
							this.connect=false;
					
							MessageBox.Show("服务器关闭！请重新登陆！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
							Application.Exit();
							break;
						
						case "CHAT":
							lstContent.Items.Add(tokens[1]);
							break;

					}
					
					msg=null;
					
				}
				//关闭连接
				tcpclient.Close();
				//关闭客户端程序
			}
			catch
			{
				lstContent.Items.Add("网络发生错误");
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
					//此时命令的格式是：命令标志符（CHAT）|发送者的用户名：发送内容|
					
					//将字符串转化为字符数组
				Byte[] outbytes=System.Text.Encoding.Unicode.GetBytes(m.ToCharArray());
				lock(this)
				{
					Strm.Write(outbytes,0,outbytes.Length);
				}
				
			}
			catch
			{
				lstContent.Items.Add("网络发生错误请重新登陆");
			}

		}

		public void Exit()
		{
			if(this.connect)
			{
				try
				{
					string message="EXIT|"+UserAlias+"|"+Form1.userNumber+"|";
					//将字符串转化为字符数组
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
		#region Message_Bridge 成员

		public void messSendOut(string s)
		{
			// TODO:  添加 MessageSend.messSendOut 实现
			lock(this)
			{
				
				//将字符串转化为字符数组
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


