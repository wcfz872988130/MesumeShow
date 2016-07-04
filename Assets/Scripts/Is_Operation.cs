using UnityEngine;
using System.Collections;

public class Is_Operation : MonoBehaviour {
    public int _ID = 0;
    private GameObject _bone;
    private GameObject _GuSiTips;
    private GameObject _wood;
    private GameObject _daoju;
    private GameObject _getWood;
    private int woodNum=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        switch(_ID)
        {
            case 0:
                isHunt();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    private void isHunt()
    {
       // _bone = Resources.Load("");
    }
}
