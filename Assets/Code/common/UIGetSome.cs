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

    public void setTxt(int num)
    {
		if (num == 0)
			_txt.text = "捕猎可获得肩胛骨";
		else if (num == 1)
			_txt.text = "可以开垦发展农业";
		else if (num == 2)
			_txt.text = "可以获得木材资源";
    }

}
