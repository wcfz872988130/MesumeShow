using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBg : MonoBehaviour {
	public bool _IsFinish = false;
	public static UIBg _Instance;
	UI_Manager _uimanager;
	ShowStage instance;
	// Use this for initialization
	void Start () {
		ResourceManager.HiStage = 4;
		instance = ShowStage.GetShowStage ();
		_uimanager=UI_Manager.GetUIManager();
	}

	void Update()
	{
//		if(m_stage!=ResourceManager.HiStage)
//		{
//			m_stage = ResourceManager.HiStage;
//			ChangeStage (m_stage);
//		}
	}

	private UIBg()
	{
		_Instance = this;
	}

	public static UIBg GetUIBg()
	{
		if(_Instance==null)
		{
			_Instance = new UIBg ();
		}
		return _Instance;
	}

	public void ShowQuestionTips()
	{
		StartCoroutine (ShowQuestionTip());
	}

//    public void ChangeStage(int stage)
//    {
//        switch (stage)
//        {
//		case 1:
//				StartCoroutine (ShowStage());
//			break;
//            case 2:
//				StartCoroutine (ShowStage());
//                break;
//            case 3:
//				StartCoroutine (ShowStage());
//                break;
//            case 4:
//				StartCoroutine (ShowStage());
//                break;
//        }
//    }

	IEnumerator ShowQuestionTip()
	{
		yield return StartCoroutine (Wait(1.0f));
		//string pathname = "prefab/ToolTip";
		GameObject go2 = _uimanager.LoadPrefab ("ToolTip",fileAddress.Com,true);
		go2.GetComponent<UIToolTip>().SetType(TipStyle.HMD_Decorate);
		go2.GetComponent<UIToolTip>().SetTitle("有新的技能可以发展");
		go2.GetComponent<UIToolTip>().SetContent("介绍：发展技能“装饰技术”，河姆渡刻于器物上的装饰艺术，内容以鸟为主，其次是太阳、鱼、蚕等形象和一些图案，展示河姆渡人的原始审美取向，开艺术教育之先河。");
		instance.AddStage ();
        //ResourceManager.HiStage += 1;
    }

//	public static IEnumerator ShowStage()
//	{
//		float m_time = 0.0f;
//		while(m_time<1.0f)
//		{
//			yield return new WaitForSeconds (0.05f);
//			m_time += 0.05f;
//			CurrentStage.GetComponent<Slider>().value+=0.0125f;
//		}
//	}

	IEnumerator Wait(float time)
	{
		for(float i=0;i<time;i+=Time.deltaTime)
		{
			yield return 0;
		}
	}
}
