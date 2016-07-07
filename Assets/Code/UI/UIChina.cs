using UnityEngine;
using System.Collections;

public class UIChina : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickClose()
    {
        GameObject go = GameObject.Find("Canvas/bg/ChinaTexture(Clone)");
        if (go != null)
            Destroy(go);
		gameObject.SetActive (false);
        //Destroy(gameObject);
    }

}
