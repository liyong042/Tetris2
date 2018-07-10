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
	
	public class Bridge
	{
		//Tetirs_bridge 接口 ,其主要功能是 实现 道具 的使用 ：增行，删行
		private Tetirs_bridge tb;
		//Message_Bridge 接口 ，其主要功能是 向网络发送 信息 如：方块信息，道具使用
		private  Message_Bridge mess_Interface;
		//命令队列，由多线称执行 其中的操作命令
		public static ArrayList stack;//操作栈
		//道具队列，保存用户获得的道具
		public static ArrayList queue;//道具队列
		//操作命令执行线称
		public Thread bridge_t;
		//自定义控件label 用于显示道具队列 的道具
		private 自定义控件label.UserControl1 toolCon;
		//道具信息提示
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
		public void Bridge_start()//开始
		{
			try
			{

				this.Bridge_stop();//先停止

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
					tools="41";//增一行
					break;
				case 10:
					tools="42";//增2行
					break;
				case 11:
					tools="43";//增3行
					break;
				case 12:
					tools="35";//加速
					break;
				case 13:
					tools="31";//消一行
					break;
				case 14:
					tools="32";//消2行
					break;
				case 15:
					tools="33";//消3行
					break;
				case 16:
					tools="36";//减速
					break;
				default:
					break;

			}
			return tools;
		
		}
		private void SendGameTool_Mess(int n)
		{
			if(queue.Count>0)//是否有道具
			{
				//返回道具所对应的操作命令
				string tools=this.queue_Value((int)queue[0]);	
				queue.RemoveAt(0);
				this.drawQueue();//重绘
				//发送道具
				SmallBrick_Tetirs smallBrick2=(SmallBrick_Tetirs)MessageSend.GameTool_Name[n];
				if(smallBrick2.name!=null)
				{
					string cont2="GAME|"+smallBrick2.name+"|"+tools+"|";
					this.mess_Interface.messSendOut(cont2);//发送信息
				}				
			}
		} 
		public void Bridge_stop()//停止命令执行线称
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
				this.toolCon.Invalidate();//重绘
			}
			catch{}
		}

	
    //线程方法体 执行 stack 中的操作命令
		private void Reserve()
		{
			
			try
			{
				bool bridge_pause=false;

				while(true)
				{
					if(bridge_pause)//如果游戏失败停止
					{
						if(stack.Count>0)//清除所有命令
							stack.Clear();

						if(queue.Count>0)//清除所有道具
						{
							queue.Clear();
							this.toolCon.Invalidate();//重绘
						}
					
						break;
					}
				
					if(stack.Count==0)//如果没有命令
					{
						Thread.Sleep(100);//休息片刻
						continue;
					}
				
					int command=(int)stack[0];
						
						
					switch(command)
					{
						case 1://使用道具
						
							if( (int)queue[0]>8)
							{
								switch((int)queue[0])
								{
									case 9:
										stack.Add(41);//增一行
										break;
									case 10:
										stack.Add(42);//增2行
										break;
									case 11:
										stack.Add(43);//增3行
										break;
									case 12:
										stack.Add(35);//加速
										break;
									case 13:
										stack.Add(31);//消一行
										break;
									case 14:
										stack.Add(32);//消2行
										break;
									case 15:
										stack.Add(33);//消3行
										break;
									case 16:
										stack.Add(36);//减速
										break;
									default:
										break;

								}
								queue.RemoveAt(0);//删除道具
								this.drawQueue();//重绘
							}
							break;
						case 2://转序s键
							//道具转序
							object ob=queue[0];
							queue.RemoveAt(0);
							queue.Add(ob);

							this.drawQueue();//重绘
							break;

						case 3:
							if(SingleTetirs.ArrayVisit)//数据是否可访问
							{
								Thread tt=new Thread(new ThreadStart(this.toolUsed_map));
								tt.IsBackground=true;
								tt.Start();
							}

							break;
						case 4:
						
							this.drawQueue();
							break;

						case 11:	//对使用道具 暂用
							break;
						case 12://对对方2使用道具 
							this.SendGameTool_Mess(0);

							break;
						case 13://对 对方3使用道具 
							this.SendGameTool_Mess(1);

							break;
						case 14://对对方4使用道具 
							this.SendGameTool_Mess(2);

							break;
						case 15://对 对方5使用道具 
							this.SendGameTool_Mess(3);

							break;
						case 16:////对 对方6使用道具 
							this.SendGameTool_Mess(4);

							break;
						case 31://消一行
							this.tb.Remove(1);
							
							Thread.CurrentThread.Join(200);
							break;

						case 32://消2行
							this.tb.Remove(2);
							Thread.CurrentThread.Join(200);
							
							break;

						case 33://消3行
							this.tb.Remove(3);
							
							Thread.CurrentThread.Join(200);
							break;
						case 35://加速
							
							break;
						case 36://减速

							break;
						case 41://增一行
							if(!this.tb.HightRow(1))//如果不能增行
							{
								bridge_pause=true;
								continue;
							}

							Thread.CurrentThread.Join(200);
							break;
						case 42://增2行
							if(!this.tb.HightRow(2))//如果不能增行
							{
								bridge_pause=true;
								continue;
							}
							Thread.CurrentThread.Join(300);
							break;
						case 43://增3行
							if(!this.tb.HightRow(3))//如果不能增行
							{
								bridge_pause=true;
								continue;
							}

							Thread.CurrentThread.Join(400);
							break;

						case 52://用户每消3行 其他人就增2 行

							string ss3="GAMEOTHERS|"+Form1.userName+"|42|";

							//发送信息
							this.mess_Interface.messSendOut(ss3);
							break;
						case 53://用户每消4行 其他人就增3行
							string ss4="GAMEOTHERS|"+Form1.userName+"|43|";

							//发送信息
							this.mess_Interface.messSendOut(ss4);
							break;

					}
					stack.RemoveAt(0);//删除命令
				}

			}
			catch{}
		}
		private void drawMess(int n)
		{
			//"道具使用说明";	
			switch(n)
			{
				
				case 9:
					//tools="41";//增一行
					this.toolMess.Text="从底部起增加一层方块";	
					break;
				case 10:
					//tools="42";//增2行
						this.toolMess.Text="从底部起增加二层方块";	
					break;
				case 11:
					//tools="43";//增3行
					this.toolMess.Text="从底部起增加三层方块";	
					break;
				case 12:
					//tools="35";
					this.toolMess.Text="方块下降速度加快20秒";	

					break;
				case 13:
					//tools="31";
						this.toolMess.Text="从底部起减一层方块";	
					break;
				case 14:
					//tools="32";
					this.toolMess.Text="从底部起减二层方块";	
					break;
				case 15:
					//tools="33";
					this.toolMess.Text="从底部起减三层方块";	
					break;
				case 16:
					//tools="36";
					this.toolMess.Text="方块下降速度减慢20秒";	

					break;
				default:
					break;
			}
		}
		private  void drawQueue()//重绘
		{
			this.toolCon.Invalidate();
			this.toolCon.Update();
			if(queue.Count>0)
				this.drawMess((int)queue[0]);


		}
		//因为发送地图信息 的时间长 所以用 另外的线程
		private void toolUsed_map()
		{
			int head=0;//信息开始点
			string ss=this.tb.map(ref head);//地图信息
												
			ss="MAP|"+Form1.userName+"|"+head.ToString()+"|"+ss.Trim()+"|";

			//发送信息
			this.mess_Interface.messSendOut(ss);
			// 删除当前操作命令中 所有发送地图 命令
		}
	}
}
