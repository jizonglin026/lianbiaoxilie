using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System .Collections.Generic;
public class SelectionControl : MonoBehaviour {
	[HideInInspector]
	public Button buttonSelection;
	private Toggle[] toggleList;
	private Text[] textList;
	[HideInInspector]
	public string saveString;
	private int start;
	// Use this for initialization
	void Start () 
	{
		toggleList = transform.GetComponentsInChildren <Toggle> ();
		textList = transform.GetComponentsInChildren<Text> ();
        
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void ToggleValueChange(string buttonid)
	{
		buttonSelection = GameObject.Find ("SelctionButton"+buttonid).GetComponent<Button>();
		for(int i=0;i<toggleList.Length;i++)
		{
			if (toggleList [i].isOn)
			{
				buttonSelection.GetComponentInChildren<Text>().text = textList [i].text;
				return;
			}

		}
	}
	/// <summary>
	/// 字符串处理 函数功能是将代码部分替换成选项	/// </summary>
	/// <returns>The string do.</returns>
	/// <param name="t">T.</param>
	/// <param name="t2">T2.</param>
	private string SaveStringDo(string t,string t2)
	{
		 start = t.IndexOf ('《');
		int end = t.IndexOf ('》');
		string ret = t.Remove (start, (end - start + 1));
		string ret2 = ret.Insert (start, t2);
		Debug.Log (start);
		Debug.Log (ret);
		return ret2;
	}

}
