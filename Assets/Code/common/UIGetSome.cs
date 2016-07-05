using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGetSome : MonoBehaviour {

    public Text _txt;

	// Use this for initialization
	void Start () {
        transform.SetAsFirstSibling();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTxt(float num)
    {
		if (num == 1.0f)
			_txt.text = "捕猎可获得肩胛骨";
		else if (num == 1.1f)
			_txt.text = "可以开垦发展农业";
		else if (num == 1.2f)
			_txt.text = "可以获得木材资源";
		else if (num == 3.0f)
			_txt.text = "矿石，可以收集矿材";
		else if (num == 3.1f)
			_txt.text = "肥沃的土壤，可以开垦发展农业";
    }

}
