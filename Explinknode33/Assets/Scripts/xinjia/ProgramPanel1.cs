using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProgramPanel1 : MonoBehaviour {
	public Text text1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public string  AddPanel1Code()
	{
		string panel1code= "\n#include\"stdio.h\"\n#include\"stdlib.h\"\n#include \"string.h\"\nstruct node\n{\n  int id;\n  char name[6];\n  " + text1.text+"\n};";
		return panel1code;
	}
}
