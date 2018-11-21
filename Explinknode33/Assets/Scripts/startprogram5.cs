using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startprogram5 : MonoBehaviour {

    public Text T1;
    public Text T2;
    public Text T3;
    public Text T4;
    public Text T5;
    public Text T6;
    public Text T7;
    public Text T8;
    public Text tipText;                //提示文本
    public Text address;             //当前内存地址文本

    public Button startBt;          //开始执行按钮
    public Button nextBt;           //下一步按钮
    public Button preBt;                //上一步按钮

    public GameObject TipPanel;

    public Image preImageAble;
    public Image preImageDisable;
    public Image startImageAble;
    public Image startImageDisable;
    public Image nextImageAble;
    public Image nextImageDisable;

    public int counti,dcounti;        
    public int Clickcount, di;                   //点击开始的次数
    public bool flaghead;           //显示头节点
    public bool flagfirst;          //寻找第一个存放数据的节点
    public bool flagnextadress;     //寻找下一个节点的地址
    public bool flagcontextID;      //节点存放的ID
    public bool flagcontextName;    //节点存放的Name
    public bool flagEnd;            //循环是否结束

    public int count = 3;            //节点的总个数
    public int IDnum;
    public string NameStr;
    public string AddressStr;

    public GameObject finishObj;

    public memorystart memorystartref_;

    //初始化时，文本颜色均为黑色
    void Start()
    {
        T1.color = Color.black;
        T2.color = Color.black;
        T3.color = Color.black;
        T4.color = Color.black;
        T5.color = Color.black;
        T6.color = Color.black;
        T7.color = Color.black;
        T8.color = Color.black;

        TipPanel.SetActive(false);
        nextBt.enabled = false;
        preBt.enabled = true;
        startBt.enabled = true;

        flaghead = false;
        flagfirst = false;
        flagcontextID = false;
        flagcontextName = false;
        flagEnd = false;
        flagnextadress = false;

        Clickcount = 0;
        di = 1;
        counti = 0;
        dcounti = 0;
    }

    public void onClickStart()
    {
        Clickcount += di;
        counti += dcounti;
        di = 0;
        dcounti = 0;
        startBt.enabled = true;
        
    }


    // Update is called once per frame
    void Update()
    {
        //node *p;
        if (Clickcount == 1)
        {
            preBt.enabled = false;
            T1.color = Color.blue;
            TipPanel.SetActive(true);
            tipText.text = "声明一个变量 *p";
            di = 1;
            dcounti = 0;
        }
        //p=head->link;
        else if (Clickcount == 2)
        {
            flaghead = true;
            counti = 0;
            T1.color = Color.black;
            T2.color = Color.blue;
            tipText.text = "寻找第一个存放数据的节点";
            di = 1;
        }
        //while(p!=NULL)
        else if (Clickcount == 3)
        {
            flaghead = false;
            T2.color = Color.black;
            T3.color = Color.blue;
            di = 1;
            tipText.text = "判断循环条件";
        }
        //{
        else if (Clickcount == 4)
        {
            T3.color = Color.black;
            T4.color = Color.blue;
            di = 1;
            tipText.text = "进入循环体";
        }
        //    printf("%d",p->ID);
        else if (Clickcount == 5)
        {
            flagcontextName = false;
            flagcontextID = true;
            flagnextadress = false;

            T5.color = Color.blue;
            if (counti == 0)
            {
                T4.color = Color.black;
            }
            else
            {
                T7.color = Color.black;
            }
            di = 1;
            flagfirst = true;//循环开始
        }

        //  puts(p->name);
        else if (Clickcount == 6)
        {
            flagcontextName = true;
            flagcontextID = false;
            flagnextadress = false;

            T6.color = Color.blue;
            T5.color = Color.black;
            di = 1;
        }
        //    p=p->link;
        else if (Clickcount == 7)
        {
            flagcontextName = false;
            flagcontextID = false;
            flagnextadress = true;

            T6.color = Color.black;
            T7.color = Color.blue;
            if (counti < count-1)
            {
                di = -2;
            }
            else if(counti== count -1)
            {
                di = 1;
                          //循环结束
            }
            dcounti = 1;
        }

        //}
        else if (Clickcount == 8)
        {
            flagfirst = false;
            flagcontextName = false;
            flagcontextID = false;
            flagnextadress = false;
            nextBt.enabled = true;
            preBt.enabled = true;
            T7.color = Color.black;
            T8.color = Color.blue;
            di = 1;
            flagEnd = true;             //程序结束
            tipText.text = "结束循环";

        }
        else if (Clickcount > 8)
        {
            //报错
            startBt.enabled = false;
            T8.color = Color.black;
            tipText.text = "恭喜你，实验完成！";
            finishObj.SetActive(true);
        }

        //判断按钮的显示颜色
        if (startBt.enabled == true)
        {
            startImageAble.gameObject.SetActive(true);
            startImageDisable.gameObject.SetActive(false);
        }
        else
        {
            startImageAble.gameObject.SetActive(false);
            startImageDisable.gameObject.SetActive(true);
        }
        if (preBt.enabled == true)
        {
            preImageAble.gameObject.SetActive(true);
            preImageDisable.gameObject.SetActive(false);
        }
        else
        {
            preImageAble.gameObject.SetActive(false);
            preImageDisable.gameObject.SetActive(true);
        }
        if (nextBt.enabled == true)
        {
            nextImageAble.gameObject.SetActive(true);
            nextImageDisable.gameObject.SetActive(false);
        }
        else
        {
            nextImageAble.gameObject.SetActive(false);
            nextImageDisable.gameObject.SetActive(true);
        }
    }
}
