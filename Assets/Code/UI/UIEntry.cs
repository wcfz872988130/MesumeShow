using UnityEngine;
using System.Collections;

public class UIEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //this.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click()
    {
        Debug.Log("Entry Click");

        MuseumFrame.currentStep = MuseumStep.Resource;

        Destroy(this.gameObject);
    }

}
