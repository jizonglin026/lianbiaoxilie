using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO ;
using System .Text;
public class CanvasControl : MonoBehaviour {
	public GameObject textParent;
	public GameObject inputGameobject;
	public GameObject Selection;
//	public InputFieldGcc inputFieldGcc;
	public MessageManager messageManager;
	private ResultQuery resultQuery;
	private Text[] daiMaArray;
	public Button buttonReturn;
	public Button buttonInputTrue;
//	private Button buttonTrue;
	private	string[] str;
	private string inputA;
	private string url = "http://veep2.chinacloudapp.cn/admin/expres/postc";
	private int t;
	private int t2;
	// Use this for initialization
	void Start () {
		
		Init ();
	}
	private void Init()
	{
//		buttonTrue = transform.Find ("InputPanel/TrueButton").GetComponent<Button>();
		resultQuery = GameObject.Find ("Canvas").transform.Find ("Output").GetComponent<ResultQuery> ();
	}
	// Update is called once per frame
	void Update () {
//		daiMaArray = textParent.GetComponentsInChildren<Text> ();
//		Debug.Log (daiMaArray.Length);

	}
	public void OnPostClick(string parameter)
	{
//		StaticToken.Instatic ().openInputPanel = true;
//		CParameter ();
		Debug.Log ("onclickpost");
		Debug.Log (parameter);
//		if(inputGameobject.activeSelf)
//		{
//			return;	
//		}
//		inputGameobject.SetActive (false);
		inputA = " ";
		StartCoroutine (PostAB (url,"######"+"3313"+"######"+parameter+"######"+inputA+"######"));
	}
	/// <summary>
	///scanf面板确认提交
	/// </summary>
	public  void InputSureButton(string parameter)
	{
//		StaticToken.Instatic ().openInputPanel = false;
//		CParameter ();
		Debug.Log (parameter);
		StartCoroutine (PostAB(url,"######"+"3313"+"######"+parameter+"######"+inputA+"######"));
		inputA = "";
		inputGameobject.SetActive (false);
	}
	//测试用
//	IEnumerator posta(string r,string namea){
//		WWW ww = new WWW (r, UTF8Encoding.UTF8.GetBytes (namea));
//		yield return ww;
//		Debug.Log (ww.text);
//		if (ww.error == null) {
//			Debug.Log ("errorweikong");
//		} else {
//			Debug.Log ("errorbuweikong");
//		}
//	}
	/*public void InputPanelAuto()
	{
		t2 = 0;
		inputA = inputFieldGcc.InputAdd ();
		char[] charste = inputA.ToCharArray ();
		if (charste.Length<1||charste [charste.Length - 1] != '\n') {
			return;
		}
		for (int i = 0; i < charste.Length; i++) {
			if (charste [i] != '\n') {
				t = i;
				break;
			}
		}
		for (int i = t + 1; i < charste.Length; i++) {

			if (charste [i - 1] != '\n' && charste [i] == '\n') {
				t2 += 1;
			}
		}
		if(t2==StaticToken.Instatic().scanfcount&&StaticToken.Instatic().scanfcount!=0&&StaticToken.Instatic().scanfopen)
		{
			InputSureButton ();
		}
	}*/
	IEnumerator PostAB(string path,string mes)
	{   
         //	    WWWForm form = new WWWForm ();
		 //		form.AddBinaryData ("txt",UTF8Encoding.UTF8 .GetBytes (StaticToken.Instatic ().token+"!"+parameter2+"!"+parameter));
		// 		form.AddBinaryData ("c", ConvertToBinary (path + "/file.c"));
		//		WWW www = new WWW (path,form);
		Debug.Log(mes);
		WWW www=new WWW (path,UTF8Encoding.UTF8.GetBytes (mes));
		string message="正在提交请等待···";
//		StaticToken.Instatic ().disable = false;
		messageManager.SetMessage(true,message,"waitImage");
//		SetActivity (Selection,false);
		yield return www;
		if(www.isDone)
		{
			if (www.error != null)
			{
				Debug.Log (UTF8Encoding.UTF8.GetString( www.bytes));
				Debug.Log (www.error);
				//			StaticToken.Instatic ().disable = true;
				messageManager.SetMessage(true,www.error,"error");
				SetActivity (Selection,false);
			} else {
				//			StaticToken.Instatic ().disable = true;
				messageManager.SetMessage(true,"提交成功","successImage");
				resultQuery.gameObject.SetActive(true);
				resultQuery.resultPanelState = true;
				StartCoroutine (messageManager.WaitHide(0.5f));
//				SetActivity (Selection,false);
				StartCoroutine (WaitOneSecond());


			}
		}
	}
	IEnumerator WaitOneSecond()
	{
		yield return new WaitForSeconds (1f);
		
		resultQuery.OnClickResultQuery ();
	}
	private void SetActivity(GameObject game,bool bo)
	{
		game.SetActive (bo);
		
	}
	/// <summary>
	///读取文本（文件读取获得流） 	
	/// </summary>
	public static byte []ConvertToBinary(string path)
	{
		FileStream stream = new FileStream (path,FileMode.Open);
		byte[] buffer = new byte[stream.Length];
		stream.Read (buffer, 0, (int)stream.Length);
		return buffer;
	}
	/// <summary>
	/// 二进制转string
	/// </summary>
	/// <param name="byt">Byt.</param>
	private void DoStream(byte[] byt)
	{
		string wwwTex = UTF8Encoding.UTF8.GetString (byt);
		str = wwwTex.Split ('!');
	}
	/// <summary>
	/// 创建文本	
	/// </summary>


	void CreatC()
	{
		CreateWriteC ("", "", str [1]);
	}
	void CreateWriteC(string path,string name,string info)
	{
		FileStream fs = new FileStream (path +"/"+name+".c", FileMode.Create);
		byte[] bytes = UTF8Encoding.UTF8.GetBytes (info.ToString ());
		fs.Write (bytes, 0, bytes.Length);
		fs.Close();
	}

	/// <summary>
	/// unity封装textasset读文件
	/// </summary>
	void DuQuText(){
		TextAsset tex = GameObject.Instantiate (Resources.Load ("datastring"))as TextAsset;
		string[] strArr = tex.text.Split ('\n');
		for (int i = 0; i < strArr.Length; i++) {
			if (strArr [i] != string.Empty) {

			}
		}
	}
	private void OnReturnButton()
	{
		Application.LoadLevel ("WelcomeScene");
	}
	//Writer out = response.getWriter();
	//out.print("Hello World");
}
