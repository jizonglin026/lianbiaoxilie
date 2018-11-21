using UnityEngine;
using System.Collections;

public class SelectionButton : MonoBehaviour {
	private GameObject sel;

	// Use this for initialization
	void Start () {
		sel = GameObject.Find ("Selc");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OpenSelectionFromId(int id)
	{
		StaticClass.Instaticclass().selbuttonid= id;
		Transform selection = sel.transform.Find ("Q"+id.ToString());
		if(selection!=null)
		{
			selection.gameObject.SetActive (!selection.gameObject.activeSelf);
			selection.transform.SetAsFirstSibling();
		}
	}
}
