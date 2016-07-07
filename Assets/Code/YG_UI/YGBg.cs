using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YGBg : MonoBehaviour {
	private GameObject _startTip;
	private GameObject YG_resource;
	private ShowStage instance;
	private UIEquipment _instance;
	private GameObject _iron;
	private GameObject _tange;
	private UI_Manager _uimanager;
	// Use this for initialization
	void Start () {
		_startTip = GameObject.Find ("Canvas/bg/YG_StartTip");
		_startTip.SetActive (true);
		ResourceManager.HiStage = 2;
		instance = ShowStage.GetShowStage ();
		_instance=UIEquipment.GetUIEquipement();
		GameObject obj1 = Resources.Load ("prefabs/YG_Prefabs/Iron") as GameObject;
		_iron = Instantiate (obj1);
		GameObject obj2 = Resources.Load ("prefabs/YG_Prefabs/Tange") as GameObject;
		_tange = Instantiate (obj2);
		_uimanager = UI_Manager.GetUIManager ();
	}

	void Update()
	{
		if (YG_Data.start_finish == true) {
			YG_Data.start_finish = false;
			StartCoroutine (showTip_metallurgy());
		}
		if(YG_Data.start_war==true)
		{
			YG_Data.start_war = false;
			StartCoroutine (showWar());
		}
		if(YG_Data.Had_Finish_Cultivate==1)
		{
			YG_Data.Had_Finish_Cultivate += 1;
			StartCoroutine (showBook());
		}
		if(YG_Data.Had_Finish_Book==true)
		{
			YG_Data.Had_Finish_Book = false;
			StartCoroutine (showTange());
		}
	}

	public void ShowResources()
	{
		YG_resource = _uimanager.LoadPrefab ("YG_Resources",fileAddress.YG,true);
		StartCoroutine (showTip_start());
		Destroy (_startTip);
	}

	IEnumerator showTip_start()
	{
		yield return new WaitForSeconds (0.8f);
		GameObject _tooltip=_uimanager.LoadPrefab("ToolTip",fileAddress.Com,true);
		_tooltip.GetComponent<UIToolTip> ().SetContent (@"主人，经济基础决定上层建筑，想要让您的文明良好发展，请先发展农业。");
		_tooltip.GetComponent<UIToolTip> ().SetTitle ("");
		_tooltip.GetComponent<UIToolTip> ().SetType (TipStyle.YG_Start);
	}

	IEnumerator showTip_metallurgy()
	{
		yield return new WaitForSeconds (1.0f);
		GameObject _tooltip=_uimanager.LoadPrefab("ToolTip",fileAddress.Com,true);
		_tooltip.GetComponent<UIToolTip> ().SetTitle (@"有新的技能可以发展:");
		_tooltip.GetComponent<UIToolTip> ().SetContent (@"介绍:发展技能“冶金术”:越国的冶金技术已经较为发达。青铜器和铁质工具的使用" +
			"促进农业和手工业的发展，越国的铸剑术也享有盛名，传说著名的锻冶匠欧冶子铸剑地点在今龙泉县城南秦溪山下。");
		_tooltip.GetComponent<UIToolTip> ().SetType (TipStyle.YG_metallurgy);
		instance.AddStage ();
		YG_resource.transform.FindChild ("RawImage").gameObject.SetActive (false);

		yield return new WaitForSeconds (1.0f);
		GameObject tange=_uimanager.LoadPrefab("Get",fileAddress.Com,true);
		tange.GetComponent<UIHaveSome> ().SetText ("获得道具铁器。");
		_instance.Get_Props (_iron);

		StartCoroutine (show_if_addCilivalization());
	}

	IEnumerator show_if_addCilivalization()
	{
		yield return new WaitForSeconds (20);
		GameObject _addCilivalization=_uimanager.LoadPrefab("Is_Operation",fileAddress.Com,true);
		_addCilivalization.GetComponent<UIQuestionTip> ().SetContent ("该关卡文明值增加值达到100");
		_addCilivalization.GetComponent<UIQuestionTip> ().SetType (ResourceType.YG_Civilization);
	}
	IEnumerator showWar()
	{
		yield return new WaitForSeconds (3.0f);
		GameObject _warInformation=_uimanager.LoadPrefab("Get",fileAddress.Com,true);
		_warInformation.GetComponent<UIHaveSome> ().SetText ("吴军入侵,我军大败!");
	}

	IEnumerator showBook()
	{
		yield return new WaitForSeconds (2.0f);
		GameObject _birdBook=_uimanager.LoadPrefab("ToolTip",fileAddress.Com,true);
		_birdBook.GetComponent<UIToolTip> ().SetTitle ("有新的技能可以发展");
		_birdBook.GetComponent<UIToolTip> ().SetContent (@"发展技能”鸟虫书“:北方人常常用“南蛮(觖)舌”来形容越人语言，即听起来就像鸟叫。事实上，越语确实是一种鸟语，越族的文字也是以汉字的篆书为基础加上鸟纹修饰而成的一种“鸟虫语”");
		_birdBook.GetComponent<UIToolTip> ().SetType (TipStyle.YG_Book);
		instance.AddStage ();
	}

	IEnumerator showTange()
	{
		yield return new WaitForSeconds (3.0f);
		GameObject _birdBook=_uimanager.LoadPrefab("ToolTip",fileAddress.Com,true);
		_birdBook.GetComponent<UIToolTip> ().SetTitle ("获得越语猎歌《谈歌》");
		_birdBook.GetComponent<UIToolTip> ().SetContent (@"《谈歌》记载于《吴越春秋》,传说是黄帝时代的作品，是古代一种原始猎歌,全文共八个字:断竹、续竹、飞土、");
		yield return new WaitForSeconds (1.0f);
		GameObject tange=_uimanager.LoadPrefab("Get",fileAddress.Com,true);
		tange.GetComponent<UIHaveSome> ().SetText ("获得道具谈歌。");
		_instance.Get_Props (_tange);
	}
}
