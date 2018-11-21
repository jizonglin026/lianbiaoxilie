using UnityEngine;
using System.Collections;

public class chazhaozujian : MonoBehaviour {
	public GameObject game;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<game.transform.childCount;i++){
			if (game.transform.GetChild (i).GetComponent<memorystart> () != null) {
				Debug.Log (game.transform.GetChild (i).gameObject.name);
			}

		}
	}
}
