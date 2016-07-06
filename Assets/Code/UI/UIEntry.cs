using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//this.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
	}

	// Update is called once per frame
	void Update () {

	}

	//add --------------------
	public void setText(string str)
	{
		Debug.Log(str);
		Text txt = transform.FindChild("Text").GetComponent<Text>();
		txt.text = str;
	}

	public void Click()
	{
		Debug.Log("Entry Click");

		MuseumFrame.currentStep = MuseumStep.Resource;
		//add --------------------
		LiangzuFrame.currentStep = MuseumStep.ResourceTip;

		Destroy(this.gameObject);
	}

}
