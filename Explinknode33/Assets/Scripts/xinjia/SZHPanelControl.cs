using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SZHPanelControl : MonoBehaviour {
	public GameObject outPutPanel;
	private bool start;
	private float scaleX;
	public  Image Image;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (outPutPanel.transform.localScale.x < 0.83f && start) {
			scaleX += 0.05f;
			outPutPanel.transform.localScale = new Vector3 (scaleX,1.15f,1f);
		} else {
			start = false;
		}

	
	}
	public void OnClickbutton(){
		outPutPanel.SetActive (true);
		scaleX = 0f;
		outPutPanel.transform.localScale=new Vector3 (0f,1f,1f);
		start = true;
		Image.enabled = false;


	}
}
