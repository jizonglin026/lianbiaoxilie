using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/*
* 在程序开始阶段，指定内存中被占用的内存
* “**”表示内存已被占用，且用红色标出
* 可以在此步骤中考虑随机的内存占用
*/

public class memorystart : MonoBehaviour
{
	private Text[,] MemoryTextArray = new Text[9, 16];
	public Image[] StepImage = new Image[3];

	public Text Adress;                         //内存当前地址
	public Text tip5;                           //提示文本

	public Image ColorImage11;
	public Image ColorImage12;
	public Image ColorImage21;
	public Image ColorImage22;
	public Image ColorImage11_2;
	public Image ColorImage12_2;
	public Image ColorImage21_2;
	public Image ColorImage22_2;
	public Image ColorImage11_3;
	public Image ColorImage12_3;
	public Image ColorImage21_3;
	public Image ColorImage22_3;
	public Image ColorImageBlue1;
	public Image ColorImageBlue2;
	public Image ColorImageBlue3;

	const int Mcount = 16;          //该数据结构需要内存的大小
	const int Xcount = 16;          //每一行的内存块个数
	const int Ycount = 9;           //每一列的内存块的个数
	const int Ocount = 3;           //程序起始时，内存被占用的个数

	private int[,] img = new int[9, 16];        //记录每一个内存块的状态
	private float[] ImagePreX = new float[3];   //记录动画的起始坐标X
	private float[] ImagePreY = new float[3];   //记录动画的起始坐标Y
	public int[] adcount = new int[9];          //记录每一个变量的首内存与整个内存首地址的偏移量
	public int[] IDcount = new int[9];          //记录每一个变量的ID
	public string[] Namecount = new string[9];  //记录每一个变量的Name

	private int[] occupx = new int[6];          //记录随机被占用内存的x坐标
	private int[] occupy = new int[6];          //记录随机被占用内存的y坐标



	public bool flagEnd;                        //记录当前页面是否结束
	public bool flagAddress;                    //记录修改地址是否结束
	public bool flagAction = false;             //记录寻找内存空间的动画是否结束

	public string FirstAdress;                  //内存的起始地址
	public string NextAdress;                   //本次查询的内存的起始地址

	private int Scount;                         //分配内存空间后，变量首内存与整个内存首地址的偏移量
	private int calX;                           //分配内存空间后，变量内存的最后一个位置的X坐标
	private int calY;                           //分配内存空间后，变量内存的最后一个位置的Y坐标
	private int calcount;                       //临时变量，用于函数中个数的临时计算
	private int pi;                             //记录当前是第几个节点

	private int count,countID,countName,countAdress;                 //临时变量
	private int i, j, z;                        //循环变量


	//寻找内存动画的相关变量
	public float ColorXpre, ColorYpre, ColorXnext1, ColorYnext1, ColorXnext2, ColorYnext2;      //图片的坐标
	public float ColorWidth, ColorHeight;                                                       //图片的宽度和高度
	private float BlueX, BlueY;                                                                 //蓝色分割条的位置

	//脚本
	public startprogram2 start2ref_;
	public startprogram3 start3ref_;
	public startprogram4 start4ref_;
	public startprogram5 start5ref_;

	/**
    * 函数功能：初始化参数
    *           初始化img[,]、adcount[]、Namecount[]、IDcount[]数组
    *           随机指定被占用内存occupiedmemory();
    *           初始化变量calcount、flagEnd、adi
    *           指定起始内存地址FirstAdress = "0x0603E848";后期可由程序随机指定
    */
	void Start()
	{
		int i, j;
		for (i = 0; i < Ycount; i++)
		{
			for (j = 0; j < Xcount; j++)
			{
				img[i, j] = 0;          //0表示内存未被占用
			}
		}

		for (i = 0; i < 9; i++)
		{
			IDcount[i] = 0;
			Namecount[i] = "";
			adcount[i] = -1;
		}

		occupiedmemory();

		ColorXpre = 190.0f;
		ColorXnext1 = 190.0f;
		ColorXnext2 = 190.0f;
		ColorYpre = 180.0f;
		ColorYnext1 = 180.0f;
		ColorYnext2 = 180.0f;
		ColorWidth = 0;
		ColorHeight = 40.0f;

		FirstAdress = "0x0603E848";
		pi = 0;

		flagEnd = false;
		flagAddress = false;

		ColorImageBlue1.gameObject.SetActive(false);
		ColorImageBlue2.gameObject.SetActive(false);
		ColorImageBlue3.gameObject.SetActive(false);

		countID = 0;
		countName = 0;
		countAdress = 0;

		//
		for (i=0;i<9;i++)
		{
			for(j=0;j<16;j++)
			{
				MemoryTextArray[i, j] = GameObject.Find("M"+i+"T"+j).GetComponent<Text>();
			}
		}

	}

	/**
    * 函数功能：设置被占用的内存位置
    *           计算并返回符合要求的连续空闲内存的个数
    * 计算规则：
    *           被占用内存块的x坐标从小到大排列
    *           被占用的一段内存的前后两个坐标值,y值进行大小对比，x值相同时，前一个的y值需小于后一个
    */
	void RandomMemory()
	{
//		int rxy=0,rocount=16;
//		occupx[0] = Random.Range(0, 1);  
//		occupy[0] = Random.Range(0, 13);
		occupx[0] =0;  
		occupy[0] =0;
//		rxy = occupx[0] * Xcount + occupy[0] + rocount + Random.Range(0, 5);
//
//		occupx[1] = rxy / Xcount;
//		occupy[1] = rxy % Xcount;
		int []py=new int[4]{3,7,11,15};
		occupx [1] = UnityEngine.Random.Range (0, 5);
		occupy[1] =py[UnityEngine.Random.Range(0,4)];
//		if (occupx[1]<=occupx[0])
//		{
//			if (occupy[1]<occupy[0])
//			{
//				occupy[1]=py[Random .Range(1,4)];
//				if (occupy[1]<occupy[0])
//				{
//					occupy[1]=py[Random .Range(2,4)];
//
//				}
//			}
//		}
		if (1 == UnityEngine.Random.Range(0,20)) 
		{
			occupx [0] = 8;
			occupy [0] =15;
			occupx [1] = 8;
			occupy [1] = 15;
		}
//		rxy += Mcount + Random.Range(2, 9);
//		occupx[2] = rxy / Xcount;
//		occupy[2] = rxy % Xcount;
		occupx[2] =8;
		occupy[2] =15;
//
//		rxy += rocount + Random.Range(0, 5);
//		occupx[3] = rxy / Xcount;
//		occupy[3] = rxy % Xcount;
		occupx[3] =8;
		occupy[3] =15;
//		rxy += Mcount + Random.Range(2, 9);
//		occupx[4] = rxy / Xcount;
//		occupy[4] = rxy % Xcount;
		occupx[4] =8;
		occupy[4] =15;
//		rxy += rocount + Random.Range(0, 5);
//		occupx[5] = rxy / Xcount;
//		occupy[5] = rxy % Xcount;
		occupx[5] =8;
		occupy[5] =15;
	}

	/**
    * 函数功能：设置被占用的内存位置
    *           被占用的内存为三段
    *           被占用的内存位置随机分布
    */
	void occupiedmemory()
	{
		//连续空闲内存是否满足要求
		RandomMemory();
		//改变内存块的状态值，即修改img[]数组相应值
		for (i=0;i<6;i+=2)
		{
			z = occupy[i];
			for (j=occupx[i];j<=occupx[i+1];j++)
			{
				for(;z<Xcount;z++)
				{
					img[j, z] = 1;
					if (j==occupx[i+1]&&z==occupy[i+1])
					{
						break;
					}
				}
				if(z==Xcount)
				{
					z = 0;
				}
			}
		}
	}

	/**
    * 函数功能：计算连续的空余内存的位置（img值为）
    *           1：表示程序开始时，内存被随机分配的占用状态
    *           6：表示程序运行时，内存由于变量的写入，发生的内存的占用状态
    */
	bool calculatememory()
	{
		calcount = 0;
		for (i = 0; i < Ycount; i++)
		{
			for (j = 0; j < Xcount; j++)
			{
				if (img[i, j] != 1 && img[i, j] != 6 && img[i, j] != 7 && img[i, j] != 8)
				{
					calX = i;
					calY = j;
					calcount++;
					if (calcount >= Mcount)
					{
					Scount = calX * Xcount + calY - Mcount + 1; //计算当前变量空间的第一个内存块所在位置
						adcount[pi] = Scount;
						return true;
					}
				}
				if (img[i, j] == 1 || img[i, j] == 6 || img[i, j] == 7 || img[i, j] == 8)
				{
					calcount = 0;
				}
			}
		}
		return false;
	}

	/**
    * 函数功能：十进制、十六进制转换
    * dd:本位是否存在下一位的进位
    * de:本位向上一位的进位
    */
	string calTenToSixteen(int tx, int di, int dd, ref int de)
	{
		if (tx + di + dd >= 16)
		{
			tx = tx + di + dd - 16;
			de = 1;
		}
		else if (tx + di + dd < 16)
		{
			tx = tx + di + dd;
			de = 0;
		}
		return tx.ToString("x8").Substring(7, 1).ToUpper();       //十进制转十六进制，取最后一位
	}

	/**
    * 函数功能：显示当前的内存地址
    *
    */
	void showContextAddress()
	{
		string xstr = "", ystr = "", zstr = "";
		int xi, yi, zi;                                 //十进制、十六进制转换的临时变量，只在此函数中使用
		int dd = 0, dx = 0, dy = 0, dz = 0;             //是否有进位
		xi = Scount / 16 / 16;
		yi = (Scount / 16) % 10;
		zi = Scount % 16;
		zstr = calTenToSixteen(zi, 8, dz, ref dy);
		ystr = calTenToSixteen(yi, 4, dy, ref dz);
		xstr = calTenToSixteen(xi, 8, dx, ref dd);
		FirstAdress = "0x0603E" + xstr + ystr + zstr;
		Adress.text = FirstAdress;
	}

	public void showNextAddress(int nextcount)
	{
		string xstr = "", ystr = "", zstr = "";
		int xi, yi, zi;         //十进制、十六进制转换的临时变量，只在此函数中使用
		int dd = 0, dx = 0, dy = 0, dz = 0;             //是否有进位
		xi = nextcount / 16 / 16;
		yi = (nextcount % 100) / 16;
		zi = nextcount % 16;
		zstr = calTenToSixteen(zi, 8, dz, ref dy);
		ystr = calTenToSixteen(yi, 4, dy, ref dz);
		xstr = calTenToSixteen(xi, 8, dx, ref dd);
		NextAdress = "0x0603E" + xstr + ystr + zstr;
	}

	/**
    * 函数功能：改变分配空间的内存块状态
    * 内存刚被分配空间，且未进行数据写入时，其状态为2
    * 分配空间大小：mcount
    */
	void setMemory()
	{
		i = Scount / Xcount;
		j = Scount % Xcount;
		for (; i <= calX; i++)
		{
			for (; j < Xcount; j++)
			{
				if (i == calX && j > calY)
				{
					break;
				}
				img[i, j] = 2;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}
	}

	/**
    * 函数功能：改变变量存储的ID值的内存块状态
    * ID数据写入时，其内存块状态为3
    */
	void setValueID()
	{
		count = 0;         //记录地址开始的文本块个数
		i = Scount / Xcount;   //第一个地址文本块的x坐标
		j = Scount % Xcount;   //第一个地址文本块的y坐标
		for (; i <= Ycount && count < 4; i++)
		{
			for (; j < Xcount && count < 4; j++)
			{
				img[i, j] = 3;
				count++;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}
	}

	/**
    * 函数功能：改变变量存储的Name值的内存状态
    * Name数据写入时，其内存块状态为4
    */
	void setValueName()
	{
		int NameCount;            //偏移量
		count = 0;            //记录地址开始的文本块个数
		NameCount = Scount + 4;
		i = NameCount / Xcount;   //第一个地址文本块的x坐标
		j = NameCount % Xcount;   //第一个地址文本块的y坐标
		for (; i <= Ycount && count < 6; i++)
		{
			for (; j < Xcount && count < 6; j++)
			{
				img[i, j] = 4;
				count++;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}
	}

	/**
    * 函数功能：改变变量存储的Adress值的内存状态
    * Adress数据写入时，其内存状态为5
    */
	void setValueAdress()
	{
		int AdressCount;            //开辟临时变量，记录地址的开始文本块
		count = 0;              //记录地址开始的文本块个数
		AdressCount = Scount + Mcount - 4;
		i = AdressCount / Xcount;   //第一个地址文本块的x坐标
		j = AdressCount % Xcount;   //第一个地址文本块的y坐标
		for (; i <= Ycount && count < 4; i++)
		{
			for (; j < Xcount && count < 4; j++)
			{
				img[i, j] = 5;
				count++;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}
	}

	/**
    * 函数功能：修改上一个节点的地址值
    * 找到上一个节点的地址值，修改其值为现在节点的起始位置
    * 适用于：node *p;
    *         head->link=p;
    */
	int ccount;         //函数中使用的临时变量
	void changeAdressPre()
	{
		count = 0;
		ccount = adcount[0] + 12;
		i = ccount / Xcount;   //第一个地址文本块的x坐标
		j = ccount % Xcount;   //第一个地址文本块的y坐标
		for (; i <= Ycount && count < 4; i++)
		{
			for (; j < Xcount && count < 4; j++)
			{
				img[i, j] = 7;           //修改内存中地址值
				count++;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}
	}

	/**
    * 函数功能：修改本节点指向下一节点的地址值
    * 找到上一个节点的地址值，修改其值为现在节点的地址值
    * 适用于：p->link=head->link;
    * 位置发生改变，数组中存储的值也要发生改变
    */
	int nexcount;         //函数中使用的临时变量
	void changeAdressNext()
	{
		count = 0;
		if (start4ref_.isActiveAndEnabled == true)
		{
			nexcount = adcount[1];
		}
		i = (Scount + 12) / Xcount;   //第一个地址文本块的x坐标
		j = (Scount + 12) % Xcount;   //第一个地址文本块的y坐标
		for (; i <= Ycount && count < 4; i++)
		{
			for (; j < Xcount && count < 4; j++)
			{
				img[i, j] = 8;           //修改内存中地址值
				count++;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}
		showNextAddress(nexcount);

	}

	/**
    * 函数功能：在插入值后，更改变量中存储的值
    * 暂时是：pi=1与pi=2值互换
    */
	void changeValue()
	{
		int swapi;
		string swapstr;
		swapi = adcount[1];
		adcount[1] = adcount[2];
		adcount[2] = swapi;
		swapi = IDcount[1];
		IDcount[1] = IDcount[2];
		IDcount[2] = swapi;
		swapstr = Namecount[1];
		Namecount[1] = Namecount[2];
		Namecount[2] = swapstr;
	}

	/**
    * 函数功能：显示变量存储的值
    * 填写指针的值
    */
	void setValueEnd()
	{
		i = Scount / Xcount;
		j = Scount % Xcount;
		for (; i <= calX; i++)
		{
			for (; j < Xcount; j++)
			{
				if (i == calX && j > calY)
				{
					break;
				}
				img[i, j] = 6;
			}
			if (j == Xcount)
			{
				j = 0;
			}
		}

		for (i = 0; i < Ycount; i++)
		{
			for (j = 0; j < Xcount; j++)
			{
				if (img[i, j] != 1 && img[i, j] != 6 && img[i, j] != 0)
				{
					img[i, j] = 6;
				}
			}
		}
		flagEnd = true;
	}

	/**
    * 函数功能：读取链表中的值
    * ID存储在：
    * Name存储在：
    * link存储在：
    * i表示链表中第几个元素
    */
	void showAllIDValue(int i)
	{
		tip5.text = "id: " + IDcount[i];
	}

	/**
    * 函数功能：读取链表中的值
    * ID存储在：
    * Name存储在：
    * link存储在：
    * i表示链表中第几个元素
    */
	void showAllNameValue(int i)
	{
		tip5.text = "name: " + Namecount[i];
	}

	/**
    * 函数功能：读取链表中的值
    * ID存储在：
    * Name存储在：
    * link存储在：
    * i表示链表中第几个元素
    */
	void showAllAddress(int i)
	{
		showNextAddress(adcount[i]);
		tip5.text = "p的值是: " + NextAdress;
		Adress.text = NextAdress;
	}

	/**
    * 函数功能：根据img数组中的值进行文本块的不同显示
    * 0：内存可用，显示颜色为黑色
    * 1: 内存已被占用，颜色为红色，显示文本为"--"
    * 2：刚分配，颜色为绿色
    * 3：表示为地址，颜色为橘色
    * 4: 表示为内容，int型数值采用小端存储
    * 5：表示本节点的地址
    * 6：表示存储已经结束
    * 7：表示地址值发生修改，修改前一个节点的地址
    * 8：表示地址值发生改变，修改本节点的地址值
    */
	int IDi = 6;                      //临时变量，记录每一个文本int的开始位置
	int Namei = 0;
	char a;
	int numa;
	int Addi,Addi2;
	void showText(Text text, int value)
	{

		if (value == 0)
		{
			IDi = 6;
			Namei = 0;
			Addi = 8;
			Addi2 = 8;
			text.color = Color.black;
		}
		else if (value == 1)
		{
			IDi = 6;  
//			text.color = Color.red;
		}
		else if (value == 2)
		{
			text.fontStyle = FontStyle.Normal;
		}
		else if (value == 3)
		{
			if (start2ref_.isActiveAndEnabled == true)
			{
				IDcount[pi] = start2ref_.IDnum;
			}
			else if (start3ref_.isActiveAndEnabled == true)
			{
				IDcount[pi] = start3ref_.IDnum;
			}
			else if (start4ref_.isActiveAndEnabled == true)
			{
				IDcount[pi] = start4ref_.IDnum;
			}
			text.color = Color.magenta;
			text.text = IDcount[pi].ToString("x8").Substring(IDi, 2);      //数据实现小端读写
			IDi -= 2;
		}
		else if (value == 4)
		{
			text.color = Color.magenta;
			if (start2ref_.isActiveAndEnabled == true)
			{
				if (Namei >= start2ref_.Namestr.Length)
				{
					text.text = "00";
				}
				else
				{
					Namecount[pi] = start2ref_.Namestr;
					a = char.Parse(start2ref_.Namestr.Substring(Namei, 1));
					numa = (int)a;
					text.text = numa.ToString("x8").Substring(6, 2);
					Namei += 1;
				}

			}
			else if (start3ref_.isActiveAndEnabled == true)
			{
				if (Namei >= start3ref_.Namestr.Length)
				{
					text.text = "00";
				}
				else
				{
					Namecount[pi] = start3ref_.Namestr;
					a = char.Parse(start3ref_.Namestr.Substring(Namei, 1));
					numa = (int)a;
					text.text = numa.ToString("x8").Substring(6, 2);
					Namei += 1;
				}

			}
			else if (start4ref_.isActiveAndEnabled == true)
			{
				if (Namei >= start4ref_.Namestr.Length)
				{
					text.text = "00";
				}
				else
				{
					Namecount[pi] = start4ref_.Namestr;
					a = char.Parse(start4ref_.Namestr.Substring(Namei, 1));
					numa = (int)a;
					text.text = numa.ToString("x8").Substring(6, 2);
					Namei += 1;
				}
			}
		}
		else if (value == 5)
		{
			text.color = Color.magenta;
			text.text = "00";

		}
		else if (value == 6)
		{
			text.color = Color.red;
		}
		else if (value == 7)           //修改上一节点地址的值
		{
			text.color = Color.magenta;
			text.text = FirstAdress.Substring(Addi, 2);
			Addi -= 2;
		}
		else if (value == 8)           //修改上一节点地址的值
		{
			text.color = Color.magenta;
			text.text = NextAdress.Substring(Addi2, 2);
			Addi2 -= 2;
		}
	}

	/**
    *  函数功能：确定图片的起始位置
    *
    */
	void ImagePosition(int pagecount)
	{
		if (ui < Ycount && uj < Xcount)
		{
			if (colorcount==0)
			{
				colorcount = 1;
				if (pagecount == 1)
				{
					if (img[0, 0] == 0)
					{
						ColorXpre = 180;
						ColorYpre = 160;
					}
				}
				else
				{
					if ((ui * Xcount + uj) < (occupx[0] * Xcount + occupy[0]))
					{
						ColorXpre = 180 + uj * 40;
						ColorYpre = 160 - ui * 45;
					}
					else if (((ui * Xcount + uj) > (occupx[1] * Xcount + occupy[1])) && ((ui * Xcount + uj) < (occupx[2] * Xcount + occupy[2])))
					{
						ColorXpre = 180 + uj * 40;
						ColorYpre = 160 - ui * 45;
					}
					else if (((ui * Xcount + uj) > (occupx[3] * Xcount + occupy[3])) && ((ui * Xcount + uj) < (occupx[4] * Xcount + occupy[4])))
					{
						ColorXpre = 180 + uj * 40;
						ColorYpre = 160 - ui * 45;
					}
					else if ((ui * Xcount + uj) > (occupx[5] * Xcount + occupy[5]))
					{
						ColorXpre = 180 + uj * 40;
						ColorYpre = 160 - ui * 45;
					}
				}
			}
			else if ((ui * Xcount + uj) == (occupx[1] * Xcount + occupy[1]+1))
			{
				if (occupy[1] < Xcount - 1)
				{
					ColorXpre = 180 + (occupy[1] + 1) * 40;
					ColorYpre = 160 - occupx[1] * 45;
				}
				else
				{
					ColorXpre = 180;
					ColorYpre = 160 - (occupx[1] + 1) * 45;
				}

			}
			else if ((ui * Xcount + uj) == (occupx[3] * Xcount + occupy[3]+1))
			{
				if (occupy[3] < Xcount - 1)
				{
					ColorXpre = 180 + (occupy[3] + 1) * 40;
					ColorYpre = 160 - occupx[3] * 45;
				}
				else
				{
					ColorXpre = 180;
					ColorYpre = 160 - (occupx[3] + 1) * 45;
				}
			}
			else if ((ui * Xcount + uj) == (occupx[5] * Xcount + occupy[5]+1))
			{
				if (occupy[5] < Xcount - 1)
				{
					ColorXpre = 180 + (occupy[5] + 1) * 40;
					ColorYpre = 160 - occupx[5] * 45;
				}
				else
				{
					ColorXpre = 180;
					ColorYpre = 160 - (occupx[5] + 1) * 45;
				}
			}
			if (img[ui, uj] == 0)
			{
				if (ux < 40.0f)
				{
					ColorWidth += 20.0f;
					ux += 20.0f;
				}
				else
				{
					ux = 0;
					uj++;
					if ((ui <= Ycount - 1) && (uj > Xcount - 1))
					{
						uj = 0;
						ui += 1;
					}
				}
			}
			else
			{
				if ((ui == occupx[0]) && (uj == occupy[0]))
				{
					ui = occupx[1];
					uj = occupy[1];
					uj++;
					if ((ui <= Ycount - 1) && (uj > Xcount - 1))
					{
						uj = 0;
						ui += 1;
					}
					if(img[ui,uj]==0)
					{
						;
					}
					else
					{
						ui = occupx[3];
						uj = occupy[3];
						uj++;
						if ((ui <= Ycount - 1) && (uj > Xcount - 1))
						{
							uj = 0;
							ui += 1;
						}
						if (uj>-1)
						{
							if (img[ui, uj] == 0)
							{
								;
							}	
						}

						else
						{
							ui = occupx[5];
							uj = occupy[5];
							uj++;
							if ((ui <= Ycount - 1) && (uj > Xcount - 1))
							{
								uj = 0;
								ui += 1;
							}
						}
					}

				}
				else if ((ui == occupx[2]) && (uj == occupy[2]))
				{
					ui = occupx[3];
					uj = occupy[3];
					uj++;
					if ((ui <= Ycount - 1) && (uj > Xcount - 1))
					{
						uj = 0;
						ui += 1;
					}
					if (img[ui, uj] == 0)
					{
						;
					}
					else
					{
						ui = occupx[5];
						uj = occupy[5];
						uj++;
						if ((ui <= Ycount - 1) && (uj > Xcount - 1))
						{
							uj = 0;
							ui += 1;
						}
					}
				}
				else if ((ui == occupx[4]) && (uj == occupy[4]))
				{
					ui = occupx[5];
					uj = occupy[5];
					uj++;
					if ((ui <= Ycount - 1) && (uj > Xcount - 1))
					{
						uj = 0;
						ui += 1;
					}
				}
				ColorWidth = 0;
				ux = 0;
			}
		}
		if (ColorWidth < 640)
		{
			if (pagecount == 1)
			{
				ImageAction(ColorImage11, ColorImage12, ColorImage21, ColorImage22);
				if ((ColorXpre + (ColorWidth - 40 * 12)) >= 820)
				{
					BlueY = ColorYpre - 45;
					BlueX = ColorXpre + ColorWidth - 40 * 11.45f - 640;
					ColorImageBlue1.gameObject.SetActive(true);
					ColorImageBlue1.rectTransform.anchoredPosition = new Vector2(BlueX, BlueY);
				}
				else if (ColorWidth >= 40 * 12)
				{
					BlueY = ColorYpre;
					BlueX = ColorXpre + ColorWidth - 40 * 11.45f;
					ColorImageBlue1.gameObject.SetActive(true);
					ColorImageBlue1.rectTransform.anchoredPosition = new Vector3(BlueX, BlueY);
				}
			}
			else if (pagecount == 2)
			{
				ImageAction(ColorImage11_2, ColorImage12_2, ColorImage21_2, ColorImage22_2);
				if ((ColorXpre + ColorWidth - 40 * 12) >= 820)
				{
					BlueY = ColorYpre - 45;
					BlueX = ColorXpre + ColorWidth - 40 * 11.45f - 640;
					ColorImageBlue2.gameObject.SetActive(true);
					ColorImageBlue2.rectTransform.anchoredPosition = new Vector2(BlueX, BlueY);
				}
				else if (ColorWidth >= 40 * 12)
				{
					BlueY = ColorYpre;
					BlueX = ColorXpre + ColorWidth - 40 * 11.45f;
					ColorImageBlue2.gameObject.SetActive(true);
					ColorImageBlue2.rectTransform.anchoredPosition = new Vector3(BlueX, BlueY);
				}
			}
			else if (pagecount == 3)
			{
				ImageAction(ColorImage11_3, ColorImage12_3, ColorImage21_3, ColorImage22_3);
				if ((ColorXpre + ColorWidth - 40 * 12) >= 820)
				{
					BlueY = ColorYpre - 45;
					BlueX = ColorXpre + ColorWidth - 40 * 11.45f - 640;
					ColorImageBlue3.gameObject.SetActive(true);
					ColorImageBlue3.rectTransform.anchoredPosition = new Vector2(BlueX, BlueY);
				}
				else if (ColorWidth >= 40 * 12)
				{
					BlueY = ColorYpre;
					BlueX = ColorXpre + ColorWidth - 40 * 11.45f;
					ColorImageBlue3.gameObject.SetActive(true);
					ColorImageBlue3.rectTransform.anchoredPosition = new Vector3(BlueX, BlueY);
				}
			}
		}
		else if (ColorWidth == 640)
		{
			if (pagecount == 1)
			{
				ImageAction(ColorImage11, ColorImage12, ColorImage21, ColorImage22);
			}
			else if (pagecount == 2)
			{
				ImageAction(ColorImage11_2, ColorImage12_2, ColorImage21_2, ColorImage22_2);
			}
			else if (pagecount == 3)
			{
				ImageAction(ColorImage11_3, ColorImage12_3, ColorImage21_3, ColorImage22_3);
			}
			flagAction = true;
			ColorWidth = 0;
			colorcount = 0;
			uj++;
			if ((ui <= Ycount - 1) && (uj > Xcount - 1))
			{
				uj = 0;
				ui += 1;
			}
			ux = 0;
		}
	}



	/**
    * 函数功能：执行寻找空间的动画
    *
    */
	float ux = 0.0f;
	int ui=0, uj=0;      //文本的行与列
	int colorcount=0;
	bool zhuanhang1 = false, zhuanhang2 = false;
	void ImageAction(Image Image11, Image Image12, Image Image21, Image Image22)
	{
		if (ColorWidth == 0)
		{
			Image11.rectTransform.sizeDelta = new Vector2(0, 40);
			Image21.rectTransform.sizeDelta = new Vector2(0, 40);
			Image12.rectTransform.sizeDelta = new Vector2(0, 40);
			Image22.rectTransform.sizeDelta = new Vector2(0, 40);
			zhuanhang1 = false;
		}
		else if (ColorWidth < 160 && ColorXpre + ColorWidth <= 820)
		{
			Image11.rectTransform.anchoredPosition = new Vector3(ColorXpre, ColorYpre);
			Image11.rectTransform.sizeDelta = new Vector2(ColorWidth, 40);
			zhuanhang1 = false;
		}
		else if (ColorWidth < 160 && ColorXpre + ColorWidth > 820)
		{
			ColorXnext1 = 180;
			ColorYnext1 = ColorYpre - 45;
			Image21.rectTransform.anchoredPosition = new Vector3(ColorXnext1, ColorYnext1);
			Image21.rectTransform.sizeDelta = new Vector2((ColorXpre + ColorWidth - 820), 40);
			zhuanhang1 = true;
		}
		else if (zhuanhang1 == true)
		{
			if (ColorXpre + ColorWidth - 820 <= 160)
			{
				Image21.rectTransform.anchoredPosition = new Vector3(ColorXnext1, ColorYnext1);
				Image21.rectTransform.sizeDelta = new Vector2((ColorXpre + ColorWidth - 820), 40);
				Image11.rectTransform.anchoredPosition = new Vector3((ColorXpre + ColorWidth - 160), ColorYpre);
				Image11.rectTransform.sizeDelta = new Vector2(820 - (ColorXpre + ColorWidth - 160), 40);
				Image12.rectTransform.anchoredPosition = new Vector3(ColorXpre, ColorYpre);
				Image12.rectTransform.sizeDelta = new Vector2(ColorWidth - 160, 40);
			}
			else if (ColorXpre + ColorWidth - 820 > 160)
			{
				ColorXnext1 = 180 + ColorXpre + ColorWidth - 820 - 160;
				Image21.rectTransform.anchoredPosition = new Vector3(ColorXnext1, ColorYnext1);
				Image21.rectTransform.sizeDelta = new Vector2(160, 40);
				//判断蓝色的图片是否要换行
				if(ColorXpre+ ColorWidth - 160<820)
				{
					Image12.rectTransform.anchoredPosition = new Vector3(ColorXpre, ColorYpre);
					Image12.rectTransform.sizeDelta = new Vector2(ColorWidth - 160, 40);
				}
				else
				{
					ColorXnext2 = 180;
					ColorYnext2 = ColorYpre - 45;
					Image22.rectTransform.anchoredPosition = new Vector3(ColorXnext2, ColorYnext2);
					Image22.rectTransform.sizeDelta = new Vector2(ColorXpre + ColorWidth - 160 - 820, 40);
				}
			}
		}
		else if (zhuanhang1 == false)
		{
			if (ColorXpre + ColorWidth <= 820)
			{
				Image11.rectTransform.anchoredPosition = new Vector3(ColorXpre + ColorWidth - 160, ColorYpre);
				Image11.rectTransform.sizeDelta = new Vector2(160, 40);
				Image12.rectTransform.anchoredPosition = new Vector3(ColorXpre, ColorYpre);
				Image12.rectTransform.sizeDelta = new Vector2(ColorWidth - 160, 40);
			}
			else if (ColorXpre + ColorWidth > 820 && ColorXpre + ColorWidth - 160 <= 820)
			{
				ColorXnext1 = 180;
				ColorYnext1 = ColorYpre - 45;
				Image21.rectTransform.anchoredPosition = new Vector3(ColorXnext1, ColorYnext1);
				Image21.rectTransform.sizeDelta = new Vector2((ColorXpre + ColorWidth - 820), 40);
				zhuanhang2 = true;
				Image11.rectTransform.anchoredPosition = new Vector3(ColorXpre + ColorWidth - 160, ColorYpre);
				Image11.rectTransform.sizeDelta = new Vector2(820 - (ColorXpre + ColorWidth - 160), 40);
				Image12.rectTransform.anchoredPosition = new Vector3(ColorXpre, ColorYpre);
				Image12.rectTransform.sizeDelta = new Vector2(ColorWidth - 160, 40);
			}
			else if(ColorXpre + ColorWidth > 820 && ColorXpre + ColorWidth - 160 > 820)
			{
				ColorXnext1 = 180 + ColorXpre + ColorWidth - 820 - 160;
				Image21.rectTransform.anchoredPosition = new Vector3(ColorXnext1, ColorYnext1);
				Image21.rectTransform.sizeDelta = new Vector2(160, 40);
				ColorXnext2 = 180;
				ColorYnext2 = ColorYpre - 45;
				Image22.rectTransform.anchoredPosition = new Vector3(ColorXnext2, ColorYnext2);
				Image22.rectTransform.sizeDelta = new Vector2(ColorXpre + ColorWidth - 160 - 820, 40);
			}
		}
	}


	/**
        * 每隔一定时间进行刷新
        * 相应start事件，为变量分配空间或写值
        */

	void FixedUpdate()
	{
		if (start2ref_.isActiveAndEnabled == true && flagEnd == false)
		{
			showmemory();
			//播放动画
			if(flagAction==false&& start2ref_.flagmove == true)
			{
				ImagePosition(1);
				ImagePreX[0] = ColorXpre;
				ImagePreY[0] = ColorYpre;
			}
			/*分配空间的同时，将内存块标为已被占用*/
			if (start2ref_.flagmove == true && calculatememory() == true&& flagAction==true)
			{
				setMemory();
				showContextAddress();
				start2ref_.flagmove = false;
				showmemory();
			}
			//显示ID
			if (start2ref_.flagID == true && flagAction == true)
			{
				setValueID();
				start2ref_.flagID = false;
				showmemory();
                startprogram02ID();//id闪闪
            }
			//显示Name
			if (start2ref_.flagName == true)
			{
				setValueName();
				start2ref_.flagName = false;
				showmemory();
                startprogram02Name();//name闪闪
			}
			//显示地址的值
			if (start2ref_.flagadress == true)
			{
				setValueAdress();
				start2ref_.flagadress = false;
				showmemory();
                startprogram02adress();//address闪闪
            }
			//将已被占用的内存设置为已占用情况
			if (start2ref_.flagEnd == true)
			{
				showmemory();
				setValueEnd();
				start2ref_.flagEnd = false;
				pi++;
				flagAction = false;
				zhuanhang1 = false;
				zhuanhang2 = false;
			}
		}
		else if (start3ref_.isActiveAndEnabled == true && flagEnd == false)
		{
			showmemory();
			if (flagAction == false && start3ref_.flagmove == true)
			{
				ImagePosition(2);
				ImagePreX[2] = ColorXpre;
				ImagePreY[2] = ColorYpre;
			}
			/*分配空间的同时，将内存块标为已被占用*/
			if (start3ref_.flagmove == true && calculatememory() == true&& flagAction==true)
			{
				setMemory();
				showContextAddress();
				start3ref_.flagmove = false;
				showmemory();
			}
			//显示ID
			if (start3ref_.flagID == true && flagAction == true)
			{
				setValueID();
				showmemory();
			}
			//显示Name
			if (start3ref_.flagName == true && flagAction == true)
			{
				setValueName();
				showmemory();
			}
			//显示地址的值
			if (start3ref_.flagadress == true && flagAction == true)
			{
				setValueAdress();
				showmemory();
			}
			//将已被占用的内存设置为已占用情况
			if (start3ref_.flagChangePre == true && start3ref_.flagEnd == true)
			{
				changeAdressPre();
				showmemory();
				setValueEnd();
				start3ref_.flagEnd = false;
				pi++;
				flagAction = false;
				zhuanhang1 = false;
				zhuanhang2 = false;
			}
		}
		else if (start4ref_.isActiveAndEnabled == true && flagEnd == false)
		{
			showmemory();
			if (flagAction == false && start4ref_.flagmove == true)
			{
				ImagePosition(3);
				ImagePreX[1] = ColorXpre;
				ImagePreY[1] = ColorYpre;
			}
			/*分配空间的同时，将内存块标为已被占用*/
			if (start4ref_.flagmove == true && calculatememory() == true && flagAction == true)
			{
				setMemory();
				showContextAddress();
				start4ref_.flagmove = false;
				showmemory();
			}
			//显示ID
			if (start4ref_.flagID == true && flagAction == true)
			{
				setValueID();
				showmemory();
			}
			//显示Name
			if (start4ref_.flagName == true && flagAction == true)
			{
				setValueName();
				showmemory();
			}
			//显示地址的值
			if (start4ref_.flagadress == true && flagAction == true)
			{
				setValueAdress();
				changeAdressNext();
				showmemory();
			}
			//将已被占用的内存设置为已占用情况
			if (start4ref_.flagChangePre == true && start4ref_.flagEnd == true && flagAction == true)
			{
				changeAdressPre();
				showmemory();
				setValueEnd();
				changeValue();
				start4ref_.flagEnd = false;
				pi++;

			}
		}
		else if (start5ref_.isActiveAndEnabled == true && flagEnd == false)
		{
			showmemory();
			/*分配空间的同时，将内存块标为已被占用*/
			if (start5ref_.flaghead == true && start5ref_.flagEnd == false)
			{
				showAllAddress(0);
				countID = 0;
			}
			if (start5ref_.flagfirst == true && start5ref_.flagEnd == false)
			{
				if(start5ref_.flagcontextID==true)
				{
					for(i=0;i<3;i++)
					{
						if(i== start5ref_.counti)
						{
							StepImage[i].gameObject.SetActive(true);
						}
						else
						{
							StepImage[i].gameObject.SetActive(false);
						}
					}

					StepImage[start5ref_.counti].rectTransform.anchoredPosition = new Vector2(ImagePreX[start5ref_.counti]-30, ImagePreY[start5ref_.counti]+30);
					showAllIDValue(start5ref_.counti);
					countName = 0;
					//让内存中的值闪一闪
					i = adcount[start5ref_.counti] / Xcount;
					j = adcount[start5ref_.counti] % Xcount;
					if(countID == 0)
					{
						for (; i <= Ycount && countID < 4; i++)
						{
							for (; j < Xcount && countID < 4; j++)
							{
								MemoryTextArray[i, j].GetComponent<Animation>().Play();
								countID++;
							}
							if (j == Xcount)
							{
								j = 0;
							}
						}
					}

				}
				if (start5ref_.flagcontextName == true)
				{
					showAllNameValue(start5ref_.counti);
					countAdress = 0;
					//让内存中的值闪一闪
					i = (adcount[start5ref_.counti]+4) / Xcount;
					j = (adcount[start5ref_.counti]+4) % Xcount;
					if (countName == 0)
					{
						for (; i <= Ycount && countName < 6; i++)
						{
							for (; j < Xcount && countName < 6; j++)
							{
								MemoryTextArray[i, j].GetComponent<Animation>().Play();
								countName++;
							}
							if (j == Xcount)
							{
								j = 0;
							}
						}
					}
				}
				if(start5ref_.flagnextadress==true&& start5ref_.counti< start5ref_.count-1)
				{
					showAllAddress(start5ref_.counti+1);
					countID = 0;
					//让内存中的值闪一闪
					i = (adcount[start5ref_.counti]+12) / Xcount;
					j = (adcount[start5ref_.counti] + 12) % Xcount;
					if (countAdress == 0)
					{
						for (; i <= Ycount && countAdress < 4; i++)
						{
							for (; j < Xcount && countAdress < 4; j++)
							{
								MemoryTextArray[i, j].GetComponent<Animation>().Play();
								countAdress++;
							}
							if (j == Xcount)
							{
								j = 0;
							}
						}
					}
				}
				else if(start5ref_.flagnextadress == true && start5ref_.counti >= start5ref_.count-1)
				{
					tip5.text = "p的地址是:0x00000000";
					Adress.text = "0x00000000";
					//让内存中的值闪一闪
					i = (adcount[start5ref_.counti] + 12) / Xcount;
					j = (adcount[start5ref_.counti] + 12) % Xcount;
					if (countAdress == 0)
					{
						for (; i <= Ycount && countAdress < 4; i++)
						{
							for (; j < Xcount && countAdress < 4; j++)
							{
								MemoryTextArray[i, j].GetComponent<Animation>().Play();
								countAdress++;
							}
							if (j == Xcount)
							{
								j = 0;
							}
						}
					}
				}    
				showmemory();
			}
		}
	}

    private void startprogram02adress()
    {
        for (i = 0; i < 3; i++)
        {
            if (i == start2ref_.counti)
            {
                StepImage[i].gameObject.SetActive(true);
            }
            else
            {
                StepImage[i].gameObject.SetActive(false);
            }
        }

        StepImage[start2ref_.counti].rectTransform.anchoredPosition = new Vector2(ImagePreX[start2ref_.counti] - 30, ImagePreY[start2ref_.counti] + 30);
        showAllIDValue(start2ref_.counti);
        countName = 0;
        //让内存中的值闪一闪
        i = adcount[start2ref_.counti] / Xcount;
        j = adcount[start2ref_.counti] % Xcount;
        if (countID == 0)
        {
            for (; i <= Ycount && countID < 4; i++)
            {
                for (; j < Xcount && countID < 4; j++)
                {
                    MemoryTextArray[i, j].GetComponent<Animation>().Play();
                    countID++;
                }
                if (j == Xcount)
                {
                    j = 0;
                }
            }
        }
    }

    private void startprogram02ID()
    {
        for (i = 0; i < 3; i++)
        {
            if (i == start2ref_.counti)
            {
                StepImage[i].gameObject.SetActive(true);
            }
            else
            {
                StepImage[i].gameObject.SetActive(false);
            }
        }

        StepImage[start2ref_.counti].rectTransform.anchoredPosition = new Vector2(ImagePreX[start2ref_.counti] - 30, ImagePreY[start2ref_.counti] + 30);
        showAllIDValue(start2ref_.counti);
        countName = 0;
        //让内存中的值闪一闪
        i = adcount[start2ref_.counti] / Xcount;
        j = adcount[start2ref_.counti] % Xcount;
        if (countID == 0)
        {
            for (; i <= Ycount && countID < 4; i++)
            {
                for (; j < Xcount && countID < 4; j++)
                {
                    MemoryTextArray[i, j].GetComponent<Animation>().Play();
                    countID++;
                }
                if (j == Xcount)
                {
                    j = 0;
                }
            }
        }
    }
    private void startprogram02Name()
    {
        for (i = 0; i < 3; i++)
        {
            if (i == start2ref_.counti)
            {
                StepImage[i].gameObject.SetActive(true);
            }
            else
            {
                StepImage[i].gameObject.SetActive(false);
            }
        }

        StepImage[start2ref_.counti].rectTransform.anchoredPosition = new Vector2(ImagePreX[start5ref_.counti] - 30, ImagePreY[start5ref_.counti] + 30);
        showAllNameValue(start2ref_.counti);
        countAdress = 0;
        //让内存中的值闪一闪
        i = (adcount[start2ref_.counti] + 4) / Xcount;
        j = (adcount[start2ref_.counti] + 4) % Xcount;
        if (countName == 0)
        {
            for (; i <= Ycount && countName < 6; i++)
            {
                for (; j < Xcount && countName < 6; j++)
                {
                    MemoryTextArray[i, j].GetComponent<Animation>().Play();
                    countName++;
                }
                if (j == Xcount)
                {
                    j = 0;
                }
            }
        }

    }

    /**
    * 函数功能：根据内存的占用情况进行显示
    */
    void showmemory()
	{
		for (int MemoryArrayi = 0; MemoryArrayi < 9; MemoryArrayi++)
		{
			for (int MemoryArrayj = 0; MemoryArrayj < 16; MemoryArrayj++)
			{
				showText(MemoryTextArray[MemoryArrayi, MemoryArrayj], img[MemoryArrayi, MemoryArrayj]);
			}
		}
	}
}
