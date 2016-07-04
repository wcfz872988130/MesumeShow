﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIChinaTexture : MonoBehaviour {
	public static bool co=false;
	public GameObject _bg;
	// Use this for initialization
	void Start () {
		_bg = GameObject.Find ("Canvas/bg");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickBtn(GameObject go)
    {
        GameObject china = GameObject.Find("Canvas/bg/China(Clone)");
        Debug.Log("lalalalalalla");
        china.GetComponent<RawImage>().texture = go.GetComponent<RawImage>().mainTexture;
		if(co==false)
		{
			co = true;
			StartCoroutine (FinishGame());
		}
    }

    public void Close()
    {
        Destroy(gameObject);
    }

	IEnumerator FinishGame()
	{
		yield return new WaitForSeconds (3.0f);
		Object obj = Resources.Load("prefab/Is_Operation");
		GameObject go = Instantiate(obj) as GameObject;
		go.transform.SetParent(_bg.transform, false);
		go.GetComponent<UIQuestionTip>().SetType(ResourceType.Finish);
		//go.GetComponent<UIQuestionTip>().SetTitle("是否?");
		go.GetComponent<UIQuestionTip>().SetContent("是否结束该阶段");
		go.GetComponent<UIQuestionTip> ().SetTextSize (24);
	}
}
