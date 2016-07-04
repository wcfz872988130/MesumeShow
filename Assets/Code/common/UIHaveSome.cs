using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIHaveSome : MonoBehaviour {

    public Text _txt;

    float beginTime = 0;

    public void SetText(string str)
    {
        _txt.text = str;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (beginTime == 0)
            beginTime = Time.time;
        if (Time.time - beginTime > 1.0f)
            Destroy(gameObject);
	}
}
