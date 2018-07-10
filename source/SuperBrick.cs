using System;

namespace 俄罗斯1
{
	
	public class SuperBrick
	{
		public int[,,] Brick_Array;
		public SuperBrick()
		{
			this.Brick_Array=new int[4,5,5];
			for(int i=0;i<4;i++)
				for(int x=0;x<5;x++)
					for(int y=0;y<5;y++)
						this.Brick_Array[i,x,y]=0;

		}
		protected void turnBrick_Four()//旋转方块（4个方向）
		{
			for(int i=1;i<4;i++)
				for(int x=0;x<5;x++)
					for(int y=0;y<5;y++)
						this.Brick_Array[i,x,y]=this.Brick_Array[i-1,4-y,x];
		}
		protected void turnBrick_Two()//旋转方块（2个方向）
		{
			for(int i=1;i<4;i++)
				for(int x=0;x<5;x++)
					for(int y=0;y<5;y++)
						if(i%2==0)
							this.Brick_Array[i,x,y]=this.Brick_Array[i-1,4-y,x];
						else
							this.Brick_Array[i,x,y]=this.Brick_Array[i-1,y,4-x];
		}
	}
	public class Brick_BB :SuperBrick//田字型方块
	{
		public Brick_BB()
		{
			this.setBrickArray();
		}
		private void setBrickArray()
		{
			for(int i=0;i<4;i++)
			{
				this.Brick_Array[i,3,1]=1;
				this.Brick_Array[i,3,2]=1;
				this.Brick_Array[i,2,1]=1;
				this.Brick_Array[i,2,2]=1;

			}
		}
	}
	public class Brick_UT :SuperBrick//倒T型方块
	{
		public Brick_UT()
		{
			this.setBrickArray();
			this.turnBrick_Four();
		}
		private void setBrickArray()
		{
			this.Brick_Array[0,2,1]=1;
			this.Brick_Array[0,1,2]=1;
			this.Brick_Array[0,2,2]=1;
			this.Brick_Array[0,3,2]=1;
		}
	}
	public class Brick_L :SuperBrick//L型防块
	{
		public Brick_L()
		{
			this.setBrickArray();
			this.turnBrick_Four();

		}
		private void setBrickArray()
		{
			this.Brick_Array[0,1,1]=1;
			this.Brick_Array[0,1,2]=1;
			this.Brick_Array[0,2,2]=1;
			this.Brick_Array[0,3,2]=1;
		}
	}
	public class Brick_UL :SuperBrick//倒L型方块 
	{
		public Brick_UL()
		{
			this.setBrickArray();
			this.turnBrick_Four();
		}
		private void setBrickArray()
		{
			this.Brick_Array[0,3,1]=1;
			this.Brick_Array[0,1,2]=1;
			this.Brick_Array[0,2,2]=1;
			this.Brick_Array[0,3,2]=1;
		}
	}
	public class Brick_I :SuperBrick//-型方块
	{
		public Brick_I()
		{
			this.setBrickArray();
			this.turnBrick_Two();
		}
		private void setBrickArray()
		{
			this.Brick_Array[0,1,2]=1;
			this.Brick_Array[0,2,2]=1;
			this.Brick_Array[0,3,2]=1;
			this.Brick_Array[0,4,2]=1;
		}
	}
	public class Brick_Z :SuperBrick//Z型方块
	{
		public Brick_Z()
		{
			this.setBrickArray();
			this.turnBrick_Two();
		}
		private void setBrickArray()
		{
			this.Brick_Array[0,1,1]=1;
			this.Brick_Array[0,2,1]=1;
			this.Brick_Array[0,2,2]=1;
			this.Brick_Array[0,3,2]=1;
		}
	}
	public class Brick_UZ :SuperBrick//倒Z型方块
	{
		public Brick_UZ()
		{
			this.setBrickArray();
			this.turnBrick_Two();
		}
		private void setBrickArray()
		{
			this.Brick_Array[0,2,1]=1;
			this.Brick_Array[0,3,1]=1;
			this.Brick_Array[0,1,2]=1;
			this.Brick_Array[0,2,2]=1;
		}
	}
}
