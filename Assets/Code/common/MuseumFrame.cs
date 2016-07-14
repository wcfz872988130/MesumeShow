using UnityEngine;
using System.Collections;

public enum MuseumStep
{
    Wait,
    Entry,
    Resource,
    ShowGuliToolTip,
    ShowBuildHouseToolTip,
	//lz
	ResourceTip,
	ShowQuestionTip
}

public class MuseumFrame : MonoBehaviour {

    //ui
    public GameObject _ui;
    GameObject _bg;
	private ShowStage instance;
    public static MuseumStep currentStep = MuseumStep.Entry;
	private UI_Manager _uiManager;
	// Use this for initialization
	void Start () {
        _bg = _ui.transform.FindChild("bg").gameObject;
		instance = ShowStage.GetShowStage ();
        ResourceManager._bg = _bg;
		_uiManager = UI_Manager.GetUIManager ();
	}
	
	// Update is called once per frame
	void Update () {
        WhichStepToExecute();
	}

    void WhichStepToExecute()
    {
        switch (currentStep)
        {
            case MuseumStep.Wait:
                break;
            case MuseumStep.Entry:
                ShowEntry();
                Debug.Log("entry");
                currentStep = MuseumStep.Wait;
                break;
            case MuseumStep.Resource:
                Debug.Log("111");
                ShowResource();
                currentStep = MuseumStep.Wait;
                break;
            case MuseumStep.ShowGuliToolTip:
                StartCoroutine(ShowGuliToolTip());
                currentStep = MuseumStep.Wait;
                break;
            case MuseumStep.ShowBuildHouseToolTip:
                StartCoroutine(ShowBuildHouseToolTip());
                currentStep = MuseumStep.Wait;
                break;
            default:
                Debug.Log("default");
                break;
        }
    }

    void ShowEntry()
    {
		GameObject go = _uiManager.LoadPrefab ("Entry",fileAddress.Com,true);
    }
    
    void ShowResourceTip()
    {
		GameObject go = _uiManager.LoadPrefab ("Economic",fileAddress.Com,true);
    }

    void ShowResource()
    {
		GameObject go = _uiManager.LoadPrefab ("Resource",fileAddress.Com,true);
    }

    IEnumerator ShowGuliToolTip()
    {
        yield return new WaitForSeconds(2.0f);
		GameObject go2 = _uiManager.LoadPrefab ("ToolTip",fileAddress.Com,true);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.HMD_GS);
        go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
        go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“骨耜制作”，发展该技能可将骨头制作成骨耜，骨耜看上去很像现代的锹或铲，它的主要用途是松土，能够提高农业劳动生产率。");
        ResourceManager._KillHorse = true;
		instance.AddStage ();
    }

    IEnumerator ShowBuildHouseToolTip()
    {
        yield return new WaitForSeconds(2.0f);
		GameObject go2 = _uiManager.LoadPrefab ("ToolTip",fileAddress.Com,true);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.HMD_Build);
        go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
        go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“榫卯技术”，可用于制造河姆渡的干栏式建筑；咱们河姆人的房舍建筑以大小木桩为基础，做成高于地面的基座，并在建造中较多采用榫卯技术。这种干栏式建筑比同时期黄河流域的半地穴建筑复杂得多；");
		instance.AddStage ();
    }


}