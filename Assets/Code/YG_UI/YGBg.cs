using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YGBg : MonoBehaviour {
	private GameObject _startTip;
	private GameObject YG_resource;
	// Use this for initialization
	void Start () {
		_startTip = GameObject.Find ("Canvas/bg/YG_StartTip");
		_startTip.SetActive (true);
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
		GameObject _obj = Resources.Load ("prefabs/YG_Prefabs/YG_Resources") as GameObject;
		YG_resource = Instantiate (_obj);
		YG_resource.transform.SetParent (gameObject.transform,false);
		StartCoroutine (showTip_start());
		Destroy (_startTip);
	}

	IEnumerator showTip_start()
	{
		yield return new WaitForSeconds (0.8f);
		GameObject _obj = Resources.Load ("prefab/ToolTip") as GameObject;
		GameObject _tooltip = Instantiate (_obj);
		_tooltip.transform.SetParent (gameObject.transform,false);
		_tooltip.GetComponent<UIToolTip> ().SetContent (@"主人，经济基础决定上层建筑，想要让您的文明良好发展，请先发展农业。");
		_tooltip.GetComponent<UIToolTip> ().SetTitle ("");
		_tooltip.GetComponent<UIToolTip> ().SetType (TipStyle.YG_Start);
	}

	IEnumerator showTip_metallurgy()
	{
		yield return new WaitForSeconds (1.0f);
		GameObject _obj = Resources.Load ("prefab/ToolTip") as GameObject;
		GameObject _tooltip = Instantiate (_obj);
		_tooltip.transform.SetParent (gameObject.transform,false);
		_tooltip.GetComponent<UIToolTip> ().SetTitle (@"有新的技能可以发展:");
		_tooltip.GetComponent<UIToolTip> ().SetContent (@"介绍:发展技能“冶金术”:越国的冶金技术已经较为发达。青铜器和铁质工具的使用" +
			"促进农业和手工业的发展，越国的铸剑术也享有盛名，传说著名的锻冶匠欧冶子铸剑地点在今龙泉县城南秦溪山下。");
		_tooltip.GetComponent<UIToolTip> ().SetType (TipStyle.YG_metallurgy);
		YG_resource.transform.FindChild ("RawImage").gameObject.SetActive (false);
		StartCoroutine (show_if_addCilivalization());
	}

	IEnumerator show_if_addCilivalization()
	{
		yield return new WaitForSeconds (10);
		GameObject _obj = Resources.Load ("prefab/Is_Operation") as GameObject;
		GameObject _addCilivalization = Instantiate (_obj);
		_addCilivalization.transform.SetParent (gameObject.transform,false);
		_addCilivalization.GetComponent<UIQuestionTip> ().SetContent ("该关卡文明值增加值达到100");
		_addCilivalization.GetComponent<UIQuestionTip> ().SetType (ResourceType.YG_Civilization);
	}
	IEnumerator showWar()
	{
		yield return new WaitForSeconds (3.0f);
		GameObject _obj = Resources.Load ("prefab/Get") as GameObject;
		GameObject _warInformation = Instantiate (_obj);
		_warInformation.transform.SetParent (gameObject.transform,false);
		_warInformation.GetComponent<UIHaveSome> ().SetText ("吴军入侵,我军大败!");
	}

	IEnumerator showBook()
	{
		yield return new WaitForSeconds (2.0f);
		GameObject _obj = Resources.Load ("prefab/ToolTip") as GameObject;
		GameObject _birdBook = Instantiate (_obj);
		_birdBook.transform.SetParent (gameObject.transform,false);
		_birdBook.GetComponent<UIToolTip> ().SetTitle ("有新的技能可以发展");
		_birdBook.GetComponent<UIToolTip> ().SetContent (@"发展技能”鸟虫书“:北方人常常用“南蛮(觖)舌”来形容越人语言，即听起来就像鸟叫。事实上，越语确实是一种鸟语，越族的文字也是以汉字的篆书为基础加上鸟纹修饰而成的一种“鸟虫语”");
		_birdBook.GetComponent<UIToolTip> ().SetType (TipStyle.YG_Book);
	}

	IEnumerator showTange()
	{
		yield return new WaitForSeconds (3.0f);
		GameObject _obj = Resources.Load ("prefab/ToolTip") as GameObject;
		GameObject _birdBook = Instantiate (_obj);
		_birdBook.transform.SetParent (gameObject.transform,false);
		_birdBook.GetComponent<UIToolTip> ().SetTitle ("获得越语猎歌《谈歌》");
		_birdBook.GetComponent<UIToolTip> ().SetContent (@"《谈歌》记载于《吴越春秋》,传说是黄帝时代的作品，是古代一种原始猎歌,全文共八个字:断竹、续竹、飞土、");
	}
}
