using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class startprogram2 : MonoBehaviour {
                                        //程序文本
    public Text T1;
    public Text T2;
    public Text T3;
    public Text T4;
    public Text T5;
    public Text T6;                         
    public Text address;                //当前内存地址文本
    public Text tipText;                //每一行程序的提示文字

    public Button startBt;              //开始执行按钮
    public Button nextBt; 
	public Button postbutton; //下一步按钮
    public Button preBt;                //上一步按钮

    public GameObject TipPanel;
    public GameObject headInputAddressPanel;
    public GameObject pInputAddressTipPanel;

    public Image ErrorImage1;
    public Image RightImage1;
    public Image ErrorImage2;
    public Image RightImage2;

    public Image preImageAble;
    public Image preImageDisable;
    public Image startImageAble;
    public Image startImageDisable;
    public Image nextImageAble;
    public Image nextImageDisable;

    public InputField InputID;
    public InputField InputName;
    public InputField InputAdress1;
    public InputField InputAdress2;

    public int Clickcount;          //点击开始的次数
    public bool flagmove;           //颜色块是否移动
    public bool flagadress;         //是否填充地址
    public bool flagID;             //是否填充ID
    public bool flagName;           //是否填充Name
    public bool flagEnd;            //赋值是否结束
                                   //临时的私有变量
    public string Namestr;
    public int IDnum;

    public InputEdit IDInputEditref_;
    public InputEdit NameInputEditref_;
    public InputEdit pAddressInputEditref_;
    public InputEdit headAddressInputEditref_;
    public memorystart memorystartref_;

    public int counti, dcounti;
    public int di;                   //点击开始的次数
    public bool flaghead;           //显示头节点
    public bool flagfirst;          //寻找第一个存放数据的节点

    //初始化时，文本颜色均为黑色
    void Start () {
        //
        T1.color = Color.black;
        T2.color = Color.black;
        T3.color = Color.black;
        T4.color = Color.black;
        T5.color = Color.black;
        T6.color = Color.black;

        //TipPanel.SetActive(true);
        headInputAddressPanel.SetActive(false);
        pInputAddressTipPanel.SetActive(false);
        //ErrorImage1.enabled = false;
       // RightImage1.enabled = false;
       // ErrorImage2.enabled = false;
       // RightImage2.enabled = false;
        nextBt.enabled = false;
        //preBt.enabled = true;
        startBt.enabled = true;
        InputID.gameObject.SetActive(false);
        InputName.gameObject.SetActive(false);
        InputID.enabled = false;
        InputName.enabled = false;
        InputAdress1.enabled = true;
        InputAdress2.enabled = true;
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
        startBt.enabled = true;
    }
     void Update()
    {
       
        if (Clickcount==1)
        {
            {
                T1.color = Color.blue;
                TipPanel.SetActive(true);
                tipText.text = "声明两个变量*head , *p";
            }
        }
        else if (Clickcount==2)
        {
            T1.color = Color.black;
            T2.color = Color.blue;
            flagmove = true;
            TipPanel.SetActive(true);
            tipText.text = "在内存中请求分配一块内存，让p指向这个内存";
            //yield return new WaitForSeconds(0.5f);
        }
        else if (Clickcount == 3)
        {
            T2.color = Color.black;
            T3.color = Color.blue;
            IDnum = int.Parse("000001");
            flagID = true;
            TipPanel.SetActive(true);
            tipText.text = "请输入学号后六位，数值存储采用小端存储";
        }
        else if (Clickcount == 4)
        {
            T3.color = Color.black;
            T4.color = Color.blue;
            Namestr = "ert";
            flagName = true;
            TipPanel.SetActive(true);
            tipText.text = "结构体变量name为ert";
        }
        else if (Clickcount == 5)
        {
            T4.color = Color.black;
            T5.color = Color.blue;
            flagadress = true;
            TipPanel.SetActive(true);
            tipText.text = "结构的link成员指向空";
        }
        else if (Clickcount == 6)
        {
            T5.color = Color.black;
            T6.color = Color.blue;
            flagEnd = true;
            TipPanel.SetActive(true);
            tipText.text = "此时指针p指向头结点";
        }


    }

   

//	void Update () {
//                                        //node *head,*p;
//        if (Clickcount == 1)
//        {
//            preBt.enabled = false;
//            T1.color = Color.blue;
//            TipPanel.SetActive(true);
//            tipText.text = "声明两个变量*head , *p";
           
//        }
//                                        //p=(node *)malloc(sizeof(node));                        
//        else if (Clickcount == 2)
//        {

//            T1.color = Color.black;
//            T2.color = Color.blue;
//            flagmove = true;
//           // TipPanel.SetActive(true);
//           // tipText.text = "在内存中请求分配一块内存，让p指向这个内存";
//            InputID.enabled = false;
//        }
//                                        //用户输入p->ID;
//        else if (Clickcount == 3) 
//        {
//            //startBt.enabled = false;
//            T2.color = Color.black;
//            T3.color = Color.blue;
           
//            //if (IDInputEditref_.flagID==true && memorystartref_.flagAction==true)
//            //{
//            //    IDnum = int.Parse(IDInputEditref_.StrID);
//            //    flagID = true;
//            //    startBt.enabled = true;
//            //}
//            //TipPanel.SetActive(true);
//            //tipText.text = "请输入学号后六位，数值存储采用小端存储";
//            //InputID.gameObject.SetActive(true);
//            //InputID.enabled = true;
//            //InputName.enabled = false;
//        }
//                                        //用户输入p->name
//        else if (Clickcount == 4)
//        {
//            //startBt.enabled = false;
//            T3.color = Color.black;
//            T4.color = Color.blue;
//            Namestr = "head";
//            flagName = true;
//            Namestr = NameInputEditref_.StrName;
//            if (Namestr != "")
//            {
//                startBt.enabled = true;
//                flagName = true;
//            }
//            TipPanel.SetActive(true);
//            tipText.text = "请输入学生姓名，除汉字";
//            InputID.enabled = false;
//            InputName.gameObject.SetActive(true);
//            InputName.enabled = true;
//        }
//        //p->link=NULL;
//        else if (Clickcount == 5)
//        {
//            //InputName.enabled = false;
//            //startBt.enabled = false;
//            T4.color = Color.black;
//            T5.color = Color.blue;
            

//            //TipPanel.SetActive(false);
//            //pInputAddressTipPanel.SetActive(true);
//            //InputAdress1.enabled = true;
//            //if(pAddressInputEditref_.StrAddress=="0x00000000")
//            //{
//            //    flagadress = true;
//            //    ErrorImage1.enabled = false;
//            //    RightImage1.enabled = true;
//            //    startBt.enabled = true;
//            //    InputAdress1.enabled = false;
//            //}
//            //else if(pAddressInputEditref_.StrAddress.Length>0)
//            //{
//            //    ErrorImage1.enabled = true;
//            //    RightImage1.enabled = false;
//            //    InputAdress1.enabled = true;
//            //} 
//        }
//                                            //head=p;
//        else if (Clickcount == 6)
//        {
//          //  startBt.enabled = false;
//            T5.color = Color.black;
//            T6.color = Color.blue;
           



//            //            pInputAddressTipPanel.SetActive(false);
//            //            headInputAddressPanel.SetActive(true);
//            //            InputAdress2.enabled = true;
//            //            if (headAddressInputEditref_.StrAddress== address.text.ToString().ToLower())
//            //            {
//            //                ErrorImage2.enabled = false;
//            //                RightImage2.enabled = true;
//            //                flagEnd = true;                 //标记，将被赋值之后的空间置为红色
//            //                flagmove = false;
//            //                flagID = false;
//            //                flagName = false;
//            //                flagadress = false;
//            ////                nextBt.enabled = true;
//            //				postbutton.gameObject.SetActive(true);
//            //                preBt.enabled = true;
//            //                InputAdress2.enabled = false;
//            //            }
//            //            else if (headAddressInputEditref_.StrAddress.Length > 0)
//            //            {
//            //                ErrorImage2.enabled = true;
//            //                RightImage2.enabled = false;
//            //                InputAdress2.enabled = true;
//            //            }
//        }
//        if (Clickcount >= 6)
//        {
//            //报错
//            startBt.enabled = false;
//        }


       
//        if (preBt.enabled == true)
//        {
//            preImageAble.gameObject.SetActive(true);
//            preImageDisable.gameObject.SetActive(false);
//        }
//        else
//        {
//            preImageAble.gameObject.SetActive(false);
//            preImageDisable.gameObject.SetActive(true);
//        }
////        if (nextBt.enabled == true)
////        {
////            nextImageAble.gameObject.SetActive(true);
////            nextImageDisable.gameObject.SetActive(false);
////        }
////        else
////        {
////            nextImageAble.gameObject.SetActive(false);
////            nextImageDisable.gameObject.SetActive(true);
////        }
//    }
}
