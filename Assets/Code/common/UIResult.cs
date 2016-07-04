using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIResult : MonoBehaviour {

    public Text _txt;

    float beginTime = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (beginTime == 0)
            beginTime = Time.time;
        if (Time.time - beginTime > 2.0f)
        {
            Destroy(gameObject);

//            Object obj = Resources.Load("prefab/Is_Operation");
//            GameObject go = Instantiate(obj) as GameObject;
//            go.transform.SetParent(ResourceManager._bg.transform, false);
//			go.GetComponent<UIQuestionTip>().SetType(ResourceType.Cao);
//            go.GetComponent<UIQuestionTip>().SetTitle("耜耕农业");
//            go.GetComponent<UIQuestionTip>().SetContent("是否使用“骨耜”开垦荒地？");
        }
	}

    public void SetTxt(string str)
    {
        _txt.text = str;
    }

}
