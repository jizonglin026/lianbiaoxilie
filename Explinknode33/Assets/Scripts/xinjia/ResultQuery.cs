using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO ;
using System .Text;
public class ResultQuery : MonoBehaviour {
	public GameObject resultPanel;
	private string url;
	private string url2;
	public Button closeResultPanel;
	public Text resultText;
	private string wwwText;
	private string wwwText2;
	private string strwww0;
	private string strwww01;
	private int startt;
	private int endd;
	[HideInInspector]
	public Image image;
	public  bool resultPanelState;
	public Image szhImage;
	public GameObject InputPanel;
	public Text inputText;


    private bool istrue;
    
    // Use this for initialization
    void Start () {
		
//		OnClickRefresh ();
//		refresh.onClick.AddListener (delegate {
//			OnClickRefresh ();
//		});
		closeResultPanel.onClick.AddListener (delegate {
			CloseResultPanel ();
		});
		url = "http://veep2.chinacloudapp.cn/admin/expres/expResReq?name=3313";
	}
	// Update is called once per frame
	void Update ()
	{
	}
	IEnumerator Quesry()
	{
		resultText.text = "";
		if (string.IsNullOrEmpty (url)) {
			url =  "http://veep2.chinacloudapp.cn/admin/expres/expResReq?name=3313";
		}
		WWW wwww = new WWW (url);
		if (!wwww.isDone) 
		{
			Debug.Log ("正在查询中");
			resultText.text = "处理中···";
		} 
		 yield return wwww;
		Debug.Log ("查询结束");
			if (wwww.error != null) {
				wwwText2 =(string) wwww.error;
				resultText.text = wwwText2;
			} else {
			Debug.Log ("成功");
			Debug.Log (wwww.text);
			wwwText = wwww.text;
			if (string.IsNullOrEmpty (wwww.text)) {
				Debug.Log ("weikong");
			}
			Debug.Log (wwww.text);
			if (JudgeReturn (wwwText)) {
				wwwText2 = StringDo (wwww.text);
//				if(string.IsNullOrEmpty(StringDo (wwww.text)))
//				{
//					wwwText2 = wwww.text;
//				}
				resultText.text = wwwText2;
			} else {
				resultText.text = wwwText;
			}
			   
//			Debug.Log (StringDo(wwww.text));
				
				//			wwwTextSplit (wwwText);
			}
	}
	private bool JudgeReturn(string str)
	{
		return str.IndexOf("\n######\n")>=0?true:false;
	}
	public string StringDo(string str)
	{
		Debug.Log (str);
//		string str2=str.Replace ("\n", "");
		int start = str.IndexOf ("\n######\n");
		int leng = str.Length;
		string[] strWww = new string[2];
		strWww [0] = str.Substring (0, start);
		strWww [1] = str.Substring (start+8);
		Debug.Log (start);
		Debug.Log (leng);
		Debug.Log (strWww[0]);//错误信息
		Debug.Log (strWww[1]);
//		if(string.IsNullOrEmpty(strWww[1])&&string.IsNullOrEmpty (strWww[0])){
//			return "结果为空";
//		}
		if(string.IsNullOrEmpty (strWww[0]))
		{
			if (StaticClass.Instaticclass ().isTextScanf) 
			{
				if(StaticClass.Instaticclass ().openInputPanel)
				{
					InputPanel.SetActive (true);
					inputText.text = "";
				}else {
					InputPanel.SetActive (false);
                    if(string.IsNullOrEmpty(strWww[1])){
                        return "代码验证成功";
                        
                    }else{
                        return strWww[1];
                    }
					
				}

			} else {
				InputPanel.SetActive (false);
                if (string.IsNullOrEmpty(strWww[1]))
                {
                    return "代码验证成功";
                    
                }
                else {
                    return strWww[1];
                }
                
            }

		}
		int n = 0;
		for(int i=0;i>=0;i++)
		{
			if (string.IsNullOrEmpty (strwww01)) {
				if (strWww [0].IndexOf ("/home/azureuser/test") >= 0 && strWww [0].IndexOf (".c:")>= 0) {
					 n++;
					 startt = strWww [0].IndexOf ("/home/azureuser/test");
					 endd = strWww [0].IndexOf (".c:");
					strwww0 = strWww [0].Insert (endd + 3, "错误信息" + n.ToString ()+":\n");
					strwww01 = strwww0.Remove (startt, endd - startt + 3);
					i = 1;
				} else {
					break;
				}
			} else {
				if (strwww01.IndexOf ("/home/azureuser/test") >= 0 && strwww01.IndexOf (".c:")>= 0) {
					n++;
					 startt = strwww01.IndexOf ("/home/azureuser/test");
					 endd = strwww01.IndexOf (".c:");
					strwww0 = strwww01.Insert (endd + 3, "错误信息" + n.ToString ()+":\n");
					strwww01 = strwww0.Remove (startt, endd - startt + 3);
					i = 1;
				} else {
					break;
				}
			}

		}
		if(string.IsNullOrEmpty(strwww01))
		{
			return strWww[0];
		}
		return strwww01;
	}
	public void OnClickRefresh()
	{
		StartCoroutine (Quesry());

//		StartCoroutine (hideRefresh());
	}
//	IEnumerator hideRefresh()
//	{
//		yield return new WaitForSeconds (2f);
//		refresh.interactable = true;
//	}
	public void OnClickResultQuery()
	{
		if (resultPanelState == false)
		{
			resultPanel.SetActive (true);
		}
		resultPanelState = true;
		StartCoroutine (Quesry());
//		resultQuery.interactable = false;
	}

	public  void CloseResultPanel()
	{
		gameObject.SetActive (false);	
		resultPanelState = false;
		szhImage.enabled=true;
	}
	public void SetImageColorA(float a)
	{
		image.color = new Color(255f, 255f, 255f, a);
	}

//	private void wwwTextSplit(string wwwtext)
//	{
//		str=wwwtext.Split ('!');
//			for(int i=0;i<str.Length;i++)
//			{
//			str [i] += "\n";
//			}
//	}

	}
