using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InputFieldEnd : MonoBehaviour {
	private InputField inputfield;
	public GameObject zhushi;
	public GameObject code;
	public Text tipText;
	public Button postButton; 
	private InputField[] inputFieldArray;
	public GameObject arrayParent;
	public GameObject nextButton;
	public Button startBt2;
	// Use this for initialization
	void Start () {
		 inputfield = gameObject.GetComponent<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void InputEnd(int i)
	{
	
		if (string.IsNullOrEmpty (inputfield.text)) {
			postButton.interactable = false;
			return;
		}
		switch (i)
		{
		case 1:
			tipText.text = "如需验证代码请点击提交，否则点击下一步继续填写第二行代码";
			postButton.interactable = true;
			break;
		case 2:
			tipText.text = "如需验证代码请点击提交，否则点击下一步继续填写第三行代码";
			postButton.interactable = true;
			break;
		case 3:
			tipText.text = "如需验证代码请点击提交，否则点击下一步继续填写第四行代码";
			postButton.interactable = true;
			break;
		case 4:
			tipText.text = "如需验证代码请点击提交，否则点击下一步继续填写第五行代码";
			postButton.interactable = true;
			break;
		case 5:
			tipText.text = "如需验证代码请点击提交，否则点击下一步继续填写第六行代码";
			postButton.interactable = true;
			break;
		case 6:
			tipText.text = "请点击提交验证代码正确性";
			postButton.interactable = true;
			nextButton.SetActive (false);
			startBt2.gameObject.SetActive (true);
			startBt2.interactable = false;
			break;

		}
	}
//	private bool CodeIsTrue(){
//		string code="";
//		inputFieldArray = arrayParent.transform.GetComponentsInChildren<InputField> (true);
//		foreach (InputField inputfield in inputFieldArray)
//		{
//			code += inputfield.text;
//		}
//
//	}
}
