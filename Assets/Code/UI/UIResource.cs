using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIResource : MonoBehaviour {
	public Texture StiltHouse;
	public static bool _IsFinish = false;
    GameObject _bg;
	// Use this for initialization
	void Start () {
        _bg = GameObject.Find("Canvas/bg");
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 mouseP = Input.mousePosition;
        //Debug.Log("X:"+mouseP.x+",Y:"+mouseP.y);

	}
       
    void PointHorse()
    {
        
    }

    public void ClickHorse(GameObject res)
    {
        ResourceManager._chooseResource = res;
		ResourceManager.Score += 5;            //level score add 5;
		AbilityNum.Hunter += 1;                //level hunt ability number add 1;
        Debug.Log("click horse");
        Object obj = Resources.Load("prefab/Is_Operation");
        GameObject go = Instantiate(obj) as GameObject;
        go.transform.SetParent(_bg.transform, false);
		go.GetComponent<UIQuestionTip>().SetType(ResourceType.HMD_Horse);
        go.GetComponent<UIQuestionTip>().SetTitle("是否捕猎?");
        go.GetComponent<UIQuestionTip>().SetContent("介绍：捕猎动物，可获取骨头，用来制作成耕地的农具。骨耜看上去很像现代的锨或铲，它的主要用途是松土，大部分取材于大型偶蹄哺乳动物的肩胛骨。");
    }

    void PointCao()
    {
    
    }

    public void ClickCao(GameObject res)
    {
        if (ResourceManager._guliCount > 0)
        {
            if (!res.GetComponent<RawImage>().texture.name.Equals("transparent"))
                return;
			ResourceManager.Score += 5;    //level score add 5;
			AbilityNum.Algorithm += 1;     //level cultivate ability number add 1;
            ResourceManager._chooseResource = res;
			Object obj = Resources.Load("prefab/Is_Operation");
			GameObject go = Instantiate(obj) as GameObject;
			go.transform.SetParent(ResourceManager._bg.transform, false);
			if(res.name.Contains("cao1")||res.name.Contains("cao2"))
			{
				go.GetComponent<UIQuestionTip>().SetType(ResourceType.HMD_Cao);
			}
			else
			{
				go.GetComponent<UIQuestionTip>().SetType(ResourceType.HMD_Cao1);
			}
			go.GetComponent<UIQuestionTip>().SetTitle("耜耕农业");
			go.GetComponent<UIQuestionTip>().SetContent("是否使用“骨耜”开垦荒地？");
        }
        else {
            Object obj2 = Resources.Load("prefab/ToolTip");
            GameObject go2 = Instantiate(obj2) as GameObject;
            go2.transform.SetParent(_bg.transform, false);
            go2.GetComponent<UIToolTip>().SetType(0);
            go2.GetComponent<UIToolTip>().SetTitle("亲爱的主人，请先打造农具，再来开垦土壤");
            go2.GetComponent<UIToolTip>().SetContent("介绍：从动物身上可获取骨头，打造骨耜农具，开启耜耕时代");
        }
    }

    void PointTree()
    {
 
    }

	public void ClickTree(GameObject res)
    {
        Debug.Log("click ");
		ResourceManager.Score += 5;     //level score add 5;
		AbilityNum.lumbering += 1;      //level lumber ability number add 1;
		ResourceManager._chooseResource = res;
        Object obj = Resources.Load("prefab/Is_Operation");
        GameObject go = Instantiate(obj) as GameObject;
        go.transform.SetParent(_bg.transform, false);
		go.GetComponent<UIQuestionTip>().SetType(ResourceType.HMD_Tree);
        go.GetComponent<UIQuestionTip>().SetTitle("是否砍取？");
        go.GetComponent<UIQuestionTip>().SetContent("介绍：从树木这里可以获得木材资源，集齐10份木材可以建造房屋。");
    }
	public void ClickEmptyArea(GameObject res)
	{
		if(_IsFinish)
		{
			//ResourceManager._chooseResource = res;
			res.GetComponent<RawImage> ().texture = StiltHouse;
			StartCoroutine (ShowQuestionTip());
			_IsFinish = false;
			ResourceManager.Score += 10;
		}
	}

	IEnumerator ShowQuestionTip()
	{
		yield return StartCoroutine(Wait(2));
		Object obj2 = Resources.Load("prefab/ToolTip");
		GameObject go2 = Instantiate(obj2) as GameObject;
		go2.transform.SetParent(_bg.transform, false);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.HMD_China);
		go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
		go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“制陶术”；手工制作产品的出现，是人类文明史上的一个重要进步");
        ResourceManager.HiStage += 1;
        //UIBg.ChangeStage(ResourceManager.HiStage);
	}

	IEnumerator Wait(float time)
	{
		for(float i=0;i<time;i+=Time.deltaTime)
		{
			yield return 0;
		}
	}
}
