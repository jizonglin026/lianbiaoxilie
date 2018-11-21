using UnityEngine;
using System.Collections;

public class StaticClass : MonoBehaviour {

	// Use this for initialization
	private static StaticClass staticclass;
	public static StaticClass Instaticclass()
	{
		if (staticclass == null) 
		{
			staticclass = new StaticClass ();
		}
		return staticclass;
	}
	public int selbuttonid;
	public bool isTextScanf;
	public bool openInputPanel;
	private StaticClass(){}

}
