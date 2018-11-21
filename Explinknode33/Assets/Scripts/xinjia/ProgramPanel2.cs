using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProgramPanel2 : MonoBehaviour {
	private string panel1code;
	public ProgramPanel1 programpanel1;
	public CanvasControl canvascontrol;
	public InputField input1;
	public InputField input2;
	public GameObject zhushi1;
	public GameObject code1;
	public GameObject zhushi2;
	public GameObject code2;
	public GameObject zhushi3;
	public GameObject code3;
	public GameObject zhushi4;
	public GameObject code4;
	public GameObject zhushi5;
	public GameObject code5;
	private InputField[] inputFieldArray;
	public GameObject arrayParent;
	public Text tipText;
	public Button postButton;
	private int count;

    
	// Use this for initialization
	void Start () {
		count = 2;
		inputFieldArray = arrayParent.transform.GetComponentsInChildren<InputField> (true);
		postButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPostButton()
	{
		string code = AddCode ();
		canvascontrol.OnPostClick (code);
	}
	private string AddCode()
	{
		panel1code = programpanel1.AddPanel1Code();
		string panel2code="\nvoid main(){\n";
		for (int i=0;i<6;i++){
			if (inputFieldArray [i].IsActive()) {
				panel2code += inputFieldArray [i].text;
				if(i!=5)
				{
					panel2code += "\n";
				}

			} else {
				switch(i)
				{
				case 1:
					panel2code += "p=(struct node*)malloc(sizeof(struct node));";
					break;
				case 2:
					panel2code += "\np->id=000000;";
					break;
				case 3:
					panel2code += "\nstrcpy(p->name,\"ert\");";
					break;
				case 4:
					panel2code += "\np->link=NULL;";
					break;
				case 5:
					panel2code += "\nhead=p;";
					break;
				default:
					break;
				}
			}
		}
		panel2code += "\n}";
		return panel1code + panel2code;
	}
	public void OnButtonNext()
	{
		
		switch(count)
		{
		case 2:
			if (string.IsNullOrEmpty (inputFieldArray [count-2].text)) {
				tipText.text = "请先根据注释填写第一行代码";
				return;
			} else {
				count++;
				tipText.text = "请根据注释填写第二行代码";
				zhushi1.SetActive (true);
				code1.SetActive (true);
			}
			break;
		case 3:
			if (string.IsNullOrEmpty (inputFieldArray [count-2].text)) {
				tipText.text = "请先根据注释填写第二行代码";
				return;
			} else {
				count++;
				tipText.text = "请根据注释填写第三行代码";
				zhushi2.SetActive (true);
				code2.SetActive (true);
			}
			break;
		case 4:
			if (string.IsNullOrEmpty (inputFieldArray [count-2].text)) {
				tipText.text = "请先根据注释填写第三行代码";
				return;
			} else {
				count++;
				tipText.text = "请根据注释填写第四行代码";
				zhushi3.SetActive (true);
				code3.SetActive (true);
			}
			break;
		case 5:
			if (string.IsNullOrEmpty (inputFieldArray [count-2].text)) {
				tipText.text = "请先根据注释填写第四行代码";
				return;
			} else {
				count++;
				tipText.text = "请根据注释填写第五行代码";
				zhushi4.SetActive (true);
				code4.SetActive (true);
			}
			break;
		case 6:
			if (string.IsNullOrEmpty (inputFieldArray [count-2].text)) {
				tipText.text = "请先根据注释填写第五行代码";
				return;
			} else {
				count++;
				tipText.text = "请根据注释填写第六行代码";
				zhushi5.SetActive (true);
				code5.SetActive (true);
               

			}
                
                break;
          
		}
	}
}
