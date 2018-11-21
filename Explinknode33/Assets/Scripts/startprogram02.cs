using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class startprogram02 : MonoBehaviour {
    public int Clickcount;          //点击开始的次数
    public bool flagmove;           //颜色块是否移动
    public bool flagadress;         //是否填充地址
    public bool flagID;             //是否填充ID
    public bool flagName;           //是否填充Name
    public bool flagnextadress;      //
    public bool flagEnd;            //赋值是否结束
                                    //临时的私有变量
    public string Namestr;
    public int IDnum;

    public int counti, dcounti;
    public int di;                   //点击开始的次数
    public bool flaghead;           //显示头节点
    public bool flagfirst;          //寻找第一个存放数据的节点
   

    void Start () {
        flagmove = false;
        flagID = false;
        flagName = false;
        flagadress = false;
        flagEnd = false;
        Clickcount = 0;
    }
    public void onClickStart()
    {
        Clickcount++;
       
    }

    // Update is called once per frame
    void Update () {
        if (Clickcount==2)
        {
            flagmove = true;
            
        }
        else if(Clickcount == 3)
        {
            flagID = true;
            
        }
        else if(Clickcount == 4)
        {
            flagName = true;
            
        }
        else if (Clickcount==5)
        {
            flagadress = true;
        }
        else if(Clickcount==6)
        {
            
            
        }
	}
}
