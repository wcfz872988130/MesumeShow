using UnityEngine;
using System.Collections;

public class LiangzuFrame : MonoBehaviour
{

    //ui
    public GameObject _ui;
    GameObject _bg;

    public static MuseumStep currentStep = MuseumStep.Entry;

    // Use this for initialization
    void Start()
    {
        _bg = _ui.transform.FindChild("bg").gameObject;
        ResourceManager._bg = _bg;

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
        go.GetComponent<UIToolTip>().SetContent("发展农业");
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
        go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“ligenshu”，发展该技能可将骨头制作成骨耜，骨耜看上去很像现代的锹或铲，它的主要用途是松土，能够提高农业劳动生产率。");

        ResourceManager._knowligen= 1;
    }

    IEnumerator ShowBuildHouseToolTip()
    {
        yield return new WaitForSeconds(2.0f);

        Object obj2 = Resources.Load("prefab/ToolTip");
        GameObject go2 = Instantiate(obj2) as GameObject;
        go2.transform.SetParent(_bg.transform, false);
        go2.GetComponent<UIToolTip>().SetType(TipStyle.HMD_Build);
        go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
        go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“榫卯技术”，可用于制造河姆渡的干栏式建筑；咱们河姆人的房舍建筑以大小木桩为基础，做成高于地面的基座，并在建造中较多采用榫卯技术。这种干栏式建筑比同时期黄河流域的半地穴建筑复杂得多；");
        ResourceManager.HiStage += 1;
        //UIBg.ChangeStage(ResourceManager.HiStage);
    }


}