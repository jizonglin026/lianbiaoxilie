using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MessageManager : MonoBehaviour {
	public  Text tiShi;
	private Button closeButton;
	public Image waitImage;
	public Image successImage;
	// Use this for initialization
	void Start () {
		closeButton = transform.Find ("CloseButton").GetComponent<Button>();
		closeButton .onClick.AddListener(delegate {
		CloseButton();
		});
	}

	// Update is called once per frame
	void Update () {
	
	}
	public  void SetMessage(bool bo,string str,string spriteName)
	{
		gameObject.SetActive (bo);
		tiShi.text = str;
		waitImage.enabled = false;
		successImage.enabled = false;
		if (spriteName == "waitImage") {
			waitImage.enabled = true;
		} else if (spriteName == "successImage") {
			successImage.enabled = true;
		} else {
			return;
		}
	}

	public  IEnumerator WaitHide(float time)
	{
		yield return new WaitForSeconds (time);
		gameObject.SetActive (false);
	}
	public void CloseButton()
	{ 
		gameObject.SetActive (false);

	}
}
