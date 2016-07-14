using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIFlower : MonoBehaviour {
	GameObject Reader;
	Vector2 enter_end_pos;
	float enter_duringTime;
	// Use this for initialization
	void Start () {
		enter_end_pos = new Vector2 (0,0);
		enter_duringTime = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickDaoju()
    {
		GameObject go2 = GameObject.Find("Canvas/bg/Equipment");
		go2.SetActive(true);
		go2.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public void ClickSkillTree()
    {
		GameObject go3 = GameObject.Find("Canvas/bg/SkillTree");
		if (go3 != null)
		{
			go3.SetActive(true);
			go3.GetComponent<RectTransform>().SetAsLastSibling();
		}

		GameObject go33 = GameObject.Find("Canvas/bg/SkillTree_lz");
		if (go33 != null)
		{
			go33.SetActive(true);
			go33.GetComponent<RectTransform>().SetAsLastSibling();
		}
    }

	public void ClickHelp()
	{ 
		GameObject Reader = GameObject.Find ("Canvas/PDFReader");
		Reader.GetComponent<RectTransform>().DOAnchorPos3D (enter_end_pos, enter_duringTime);
		//Reader.SetActive (true);
		Reader.GetComponent<RectTransform>().SetAsLastSibling();
	}

}
