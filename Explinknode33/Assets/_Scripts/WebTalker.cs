using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class WebTalker : MonoBehaviour
{
    #region Variables
    #region Public
    public Text msgTextUI;      // 错误信息显示控件
    #endregion Public

    #region Private
    private string token;       // 服务器返回的用户Token
    private string url;         // 服务器接口地址
    private string time;        // 第一次请求时间 (s)
    private string expid;
    private int type = 0;       // 加密字符串索引值，参见keyIndex
    const float loadDelayTime = 1.0f;

    private int[,] keyIndex = new int[8, 8]             //加密字符串索df引
           {{ 1, 4, 7, 8, 10, 50, 38, 34 }, { 3, 6, 9, 25, 31, 40, 55, 60 },
            { 2, 12, 18, 22, 23, 53, 56, 62 }, { 5, 63, 41, 32, 42, 51, 0, 11 },
            { 9, 13, 21, 33, 44, 57, 61, 14 }, { 15, 59, 43, 45, 52, 46, 58, 16 },
            { 17, 24, 27, 35, 47, 37, 29, 19 }, { 20, 26, 28, 36, 48, 49, 39, 30 } };
    #endregion Private
    #endregion Variables

    #region Methods
    #region Public
    public void parsePramas(string paras)
    {
        string[] paramStr = paras.Split(new char[] { '&' });
        this.token = paramStr[0];
        this.url = paramStr[1];
        this.time = paramStr[2];
        //this.type = paramStr[3];
    }
    #endregion Public

    #region Private
    void Start()
    {
        expid = "";
        msgTextUI.text = "正在验证权限......";

        Application.ExternalCall("SendParas", "");
        StartCoroutine(GetParas(loadDelayTime));
    }

    IEnumerator GetParas(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        check();
    }

    private void check()
    {
        //msgTextUI.text = token;
        if (!checkToken())
        {
            msgTextUI.text = "token错误(100)!";      // 未设置TOKEN!
            //Application.ExternalCall("AlertMsg","参数错误(01)!");
        }
        else
        {
            connectToServer();
        }
    }

    private bool parseXML()
    {
        CrossDomain crossXML = new CrossDomain();

        expid = crossXML.getExperimentID();

        if (expid != "")
        {
            return crossXML.ParseCrossDomain(url);
        }
        else
        {
            return false;
        }
    }

    // 验证token的有效性
    private bool checkToken()
    {
        //Application.ExternalCall("AlertMsg", SecurityUtil.token);
        //msg.text = token;
        if (token == null || "".Equals(token) || 
            "null".Equals(token) || token.Length != 72)
        {
            return false;
        }
        return true;
    }

    private void connectToServer()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token);

        if (parseXML())
        {
            form.AddField("expid", expid);

            WWW w = new WWW(url, form);
            StartCoroutine(serverMessage(w));
        }
        else
        {
            msgTextUI.text = "配置文件匹配失败！(200)";   // +w.error;
        }
    }

    // 服务器返回信息
    IEnumerator serverMessage(WWW w)
    {
        yield return w;
        
        //print(w.ToString());
        if (w.error != null)
        {
            //print("网络连接错误:" + w.error);
            msgTextUI.text = "网络连接错误！(300)";  // +w.error;
        }
        else
        {
            if (w.isDone)
            {
                try
                {
                    string originMsg, localMd5Str;
                    string serverMsg = w.text;
                    string[] msgs = serverMsg.Split(new char[] { ':' });

                    //msgTextUI.text = "131: "+msgTextUI.text + serverMsg + "\n";

                    string flag = msgs[0]; // 成功标志位
                    string serverMD5 = msgs[1];  //MD5

                    //msgTextUI.text = "136: " + msgTextUI.text + msgs[2] + "\n";

                    type = Convert.ToInt16(msgs[2]);  // 加密type
                    string errCode = msgs[3]; // 错误代码
                    string time2 = msgs[4];
                    string other = msgs[5];

                    originMsg = flag + ":" + type + ":" + errCode + ":" + time2 + ":" + other;
                    localMd5Str = SecurityUtil.GetStrMd5(originMsg + getCheckStr());

                    //string testStr = serverMD5 + " \n  " + localMd5Str + " \n " + getCheckStr()
                    //                + " \n " + type + " \n " + originMsg + " \n " + serverMsg;
                    //msgTextUI.text = testStr;

                    if ("1".Equals(flag))
                    {
                        if (localMd5Str.Equals(serverMD5))
                        {
                            long timeDiff = Convert.ToInt64(time2) - Convert.ToInt64(time); // 时间差
                            if (timeDiff > 60 * 3) // 3分钟
                            {
                                msgTextUI.text = "网络连接超时!(500)";
                            }
                            else // 时间是否超时
                            {
								msgTextUI.text = "实验正在加载中，请稍后......";
								StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
									{
                                        toMainScene();
                                    }, 3f));
                            }
                        }
                        else  // MD5校验失败
                        {
                            msgTextUI.text = "MD5校验失败!(600)"; //"MD5校验失败!";
                        }
                    }
                    else // 服务器校验失败
                    {
                        if (localMd5Str.Equals(serverMD5))
                        {
                            msgTextUI.text = errCode;  // 服务器返回的错误信息
                        }
                        else
                        {
                            msgTextUI.text = "服务器校验失败(700)!"; //"MD5校验失败!";
                        }
                    }
                }
                catch (Exception e)
                {
                    msgTextUI.text = "参数错误(400)!";  // e.Message;
                    Debug.Log(e.Message);
                }   
            }
        }
    }

	void toMainScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    // 随机字符串
    private string getCheckStr()
    {
        string ret = "";
        if (type > 0)
        {
            for (int i = 0; i < 8; i++)
            {
                ret +=  token.Substring(keyIndex[type - 1, i], 1);  // 从token取
            }
        }
        return ret;
    }
    #endregion Private
    #endregion Methods
}