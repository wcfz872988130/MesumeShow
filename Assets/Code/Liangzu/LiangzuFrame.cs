using UnityEngine;
using System.Collections;

public class LiangzuFrame : MonoBehaviour
{

    //ui
    public GameObject _ui;
    GameObject _bg;
	private UIEquipment _equipInstance;
	private ShowStage _instance;
    public static MuseumStep currentStep;

    // Use this for initialization
    void Start()
    {
        _bg = _ui.transform.FindChild("bg").gameObject;
        ResourceManager._bg = _bg;
		ResourceManager.nextScene = "Level2";
		_instance = ShowStage.GetShowStage ();
		currentStep=MuseumStep.Entry;
		ResourceManager.HiStage = 3;
		ResourceManager.Score = 52;
		_equipInstance = UIEquipment.GetUIEquipement ();
		foreach (string equipName in ResourceManager._totalEquipement) {
			GameObject obj = Resources.Load (equipName) as GameObject;
			GameObject eqiup=Instantiate (obj);
			_equipInstance.Get_Props (eqiup);
		}
    }

    // Update is called once per frame
    void Update()
    {
        WhichStepToExecute();
    }

    void WhichStepToExecute()
    {
        switch (currentStep)
        {
            case MuseumStep.Wait:
                break;
            case MuseumStep.Entry:              //欢迎界面
                ShowEntry();
                Debug.Log("entry");
                currentStep = MuseumStep.Wait;
                break;
            case MuseumStep.ResourceTip:
                Debug.Log("111");
                ShowResourceTip();
                currentStep = MuseumStep.Wait;
                break;
            case MuseumStep.Resource:
                ShowResource();
                break;
            case MuseumStep.ShowGuliToolTip:
                StartCoroutine(ShowGuliToolTip());
                currentStep = MuseumStep.Wait;
                break;
            case MuseumStep.ShowBuildHouseToolTip:
                StartCoroutine(ShowBuildHouseToolTip());
                currentStep = MuseumStep.Wait;
                break;
			case MuseumStep.ShowQuestionTip:
				StartCoroutine (ShowQuestionTip ());
				currentStep = MuseumStep.Wait;
				break;
            default:
                Debug.Log("default");
                break;
        }
    }

    void ShowEntry()
    {
        Object obj = Resources.Load("prefab/Entry");
        GameObject go = Instantiate(obj) as GameObject;
        go.GetComponent<UIEntry>().setText("终于等到您啦！我是良渚的小土地神。现在请您掌管这一片土地。");
        go.transform.SetParent(_bg.transform, false);
    }

    void ShowResourceTip()
    {
        Object obj = Resources.Load("prefab/ToolTip");
        GameObject go = Instantiate(obj) as GameObject;
        go.GetComponent<UIToolTip>().SetType(TipStyle.LZ_Resource);
		go.GetComponent<UIToolTip> ().SetTitle ("");
		go.GetComponent<UIToolTip>().SetContent(@"主人，经济基础决定上层建筑，想要让您的文明良好发展，请先发展农业。");
        go.transform.SetParent(_bg.transform, false);
    }

    void ShowResource()
    {
        _ui.transform.FindChild("bg/Resource_liangzu").gameObject.SetActive(true);
    }

    IEnumerator ShowGuliToolTip()
    {
        yield return new WaitForSeconds(2.0f);
        Object obj2 = Resources.Load("prefab/ToolTip");
        GameObject go2 = Instantiate(obj2) as GameObject;
        go2.transform.SetParent(_bg.transform, false);
        go2.GetComponent<UIToolTip>().SetType(TipStyle.LZ_CCC);
        go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
		go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“犁耕术”：良渚文化遗址出土了大量石制农具，表明农业已经发展到犁耕农业。农业文化的先进自然伴随着相关教育的发展。");
        ResourceManager._knowligen= 1;
		_instance.AddStage ();
    }

    IEnumerator ShowBuildHouseToolTip()
    {
        yield return new WaitForSeconds(2.0f);

        Object obj2 = Resources.Load("prefab/ToolTip");
        GameObject go2 = Instantiate(obj2) as GameObject;
        go2.transform.SetParent(_bg.transform, false);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.LZ_fuhaoshu);
        go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
		go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“符号术”；中国史前文化中大量存在于陶器、玉器上的刻划符号应是汉字的源头。良渚出土的一些陶器、玉器上已出现了不少的单个或成组具有表意功能的刻划符号，可称之为“原始文字”。");
		_instance.AddStage ();
    }

	IEnumerator ShowQuestionTip()
	{
		yield return new WaitForSeconds(2.0f);
		Object obj2 = Resources.Load("prefab/ToolTip");
		GameObject go2 = Instantiate(obj2) as GameObject;
		go2.transform.SetParent(_bg.transform, false);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.LZ_zhitaoshu);
		go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
		go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“制陶术”；良渚文化时期的手工制品的技术成分含量更高：陶器品种多样，用途分明，有壶、罐、尊、簋、鼎、豆、皿、盆、盘等，贵族墓中出土的玉器种类达20余种，有琮、璧、钺、锥形器、三叉形器、冠形器、璜、纺轮、圆牌饰等，还刻有花纹。");
		_instance.AddStage();
	}

}