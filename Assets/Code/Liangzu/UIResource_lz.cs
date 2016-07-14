using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIResource_lz : MonoBehaviour
{
    public static bool _IsFinish = false;
    GameObject _bg;
	private ShowStage _instance;

    void Start()
    {
        _bg = GameObject.Find("Canvas/bg");
		_instance = ShowStage.GetShowStage ();
    }

    void Update()
    {
    }

    public void ClickShitou(GameObject res)     //点击石头
    {
        ResourceManager._chooseResource = res;

        Debug.Log("click shi");
        Object obj = Resources.Load("prefab/Is_Operation");
        GameObject go = Instantiate(obj) as GameObject;
        go.transform.SetParent(_bg.transform, false);
        go.GetComponent<UIQuestionTip>().SetType(ResourceType.LZ_shi);
        go.GetComponent<UIQuestionTip>().SetTitle("");
        go.GetComponent<UIQuestionTip>().SetContent("是否收集石头？");
		ResourceManager.Score += 8;
    }

    public void ClickCai(GameObject res)
    {
        if (ResourceManager._knowligen > 0)
        {
            if (!res.GetComponent<RawImage>().texture.name.Equals("transparent"))
                return;

            ResourceManager._chooseResource = res;
            Object obj = Resources.Load("prefab/Is_Operation");
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.SetParent(ResourceManager._bg.transform, false);
            go.GetComponent<UIQuestionTip>().SetType(ResourceType.LZ_cai);
            go.GetComponent<UIQuestionTip>().SetTitle("犁耕农业");
			go.GetComponent<UIQuestionTip>().SetContent("是否使用“犁耕”开垦荒地？");
			ResourceManager.Score += 8;

        }
        else
        {
            Object obj2 = Resources.Load("prefab/ToolTip");
            GameObject go2 = Instantiate(obj2) as GameObject;
            go2.transform.SetParent(_bg.transform, false);
            go2.GetComponent<UIToolTip>().SetType(0);
            go2.GetComponent<UIToolTip>().SetTitle("亲爱的主人，请先打造农具，再来开垦土壤");
            go2.GetComponent<UIToolTip>().SetContent("介绍：收集石材，打造石制农具");
        }
    }

    public void ClickTree(GameObject res)
    {
        Debug.Log("click ");
        ResourceManager._chooseResource = res;
        Object obj = Resources.Load("prefab/Is_Operation");
        GameObject go = Instantiate(obj) as GameObject;
        go.transform.SetParent(_bg.transform, false);
        go.GetComponent<UIQuestionTip>().SetType(ResourceType.HMD_Tree);
        go.GetComponent<UIQuestionTip>().SetTitle("是否砍取？");
        go.GetComponent<UIQuestionTip>().SetContent("介绍：从树木这里可以获得木材资源，集齐10份木材可以建造房屋。");
    }

    IEnumerator ShowQuestionTip()
    {
        yield return StartCoroutine(Wait(2));
        Object obj2 = Resources.Load("prefab/ToolTip");
        GameObject go2 = Instantiate(obj2) as GameObject;
        go2.transform.SetParent(_bg.transform, false);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.LZ_zhitaoshu);
        go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
		go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“制陶术”；良渚文化时期的手工制品的技术成分含量更高：陶器品种多样，用途分明，有壶、罐、尊、簋、鼎、豆、皿、盆、盘等，贵族墓中出土的玉器种类达20余种，有琮、璧、钺、锥形器、三叉形器、冠形器、璜、纺轮、圆牌饰等，还刻有花纹。");
		_instance.AddStage();
    }

    IEnumerator Wait(float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            yield return 0;
        }
    }
}
