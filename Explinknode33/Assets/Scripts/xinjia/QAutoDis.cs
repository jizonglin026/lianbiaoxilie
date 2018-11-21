using UnityEngine;
using System.Collections;

public class QAutoDis : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable()
	{
		StartCoroutine (Autodis());
	}
	IEnumerator Autodis()
	{
		yield return new WaitForSeconds (5f);
		gameObject.SetActive (false);
	}
}
