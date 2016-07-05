using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YG_Little : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {
	private bool _haveOre=false;
	private bool _haveIron=false;
	private Texture2D _cropsTexture;
	// Use this for initialization
	void Start () {
		_cropsTexture = Resources.Load ("YG_Textures/"+gameObject.name) as Texture2D;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		GameObject _obj = Resources.Load ("prefab/GetBlade") as GameObject;
		GameObject _littleTip = Instantiate (_obj);
		_littleTip.transform.SetParent (gameObject.transform,false);
		_littleTip.GetComponent<RectTransform> ().SetAsLastSibling ();
		_littleTip.transform.localPosition += new Vector3(0, _littleTip.GetComponent<RectTransform>().rect.height * 1.5f, 0);
		if(gameObject.name.Contains("ore"))
		{
			_littleTip.GetComponent<UIGetSome> ().setTxt (3.0f);
			_littleTip.GetComponent<RectTransform> ().sizeDelta = new Vector2 (170,60);
		}
		else if(gameObject.name.Contains("crops"))
		{
			_littleTip.GetComponent<UIGetSome> ().setTxt (3.1f);
			_littleTip.GetComponent<RectTransform> ().sizeDelta = new Vector2 (180,80);
			_littleTip.transform.FindChild ("Text").GetComponent<RectTransform> ().sizeDelta = new Vector2 (160,80);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if(gameObject.name.Contains("ore"))
		{
			GameObject _bg = GameObject.Find ("Canvas/bg");
			GameObject _obj = Resources.Load ("prefab/Get")as GameObject;
			GameObject _getTip = Instantiate (_obj);
			_getTip.transform.SetParent (_bg.transform,false);
			_getTip.GetComponent<UIHaveSome> ().SetText ("获得道具:矿材＋1");
			if (!_haveOre) {
				GameObject _bj = Resources.Load ("prefab/ToolTip")as GameObject;
				GameObject _toolTip = Instantiate (_bj);
				_toolTip.transform.SetParent (_bg.transform,false);
				_toolTip.GetComponent<UIToolTip> ().SetTitle ("可以打造铁器");
				_toolTip.GetComponent<UIToolTip> ().SetContent ("1959年绍兴城北西施山出土的大批越国或稍后的青铜器和铁质工具(青铜器有犁头、锄头" +
					"镰刀、剑等，铁器有锄、斧、镰刀等)。");
				_haveOre = true;
				_haveIron = true;
			}
			Destroy (gameObject);
		}
		if(gameObject.name.Contains("crops"))
		{
			GameObject _bg = GameObject.Find ("Canvas/bg");
			if (!_haveIron) {
				GameObject _ob = Resources.Load ("prefab/ToolTip") as GameObject;
				GameObject Tip_mine = Instantiate (_ob);
				Tip_mine.transform.SetParent (_bg.transform,false);
				Tip_mine.GetComponent<UIToolTip> ().SetContent (@"亲爱的主人，请先根据提示发展技能，打造农具，再来开垦土壤");
				return;
			}

			GameObject _obj = Resources.Load ("prefab/Is_Operation")as GameObject;
			GameObject _getTip = Instantiate (_obj);
			_getTip.transform.SetParent (_bg.transform,false);
			_getTip.GetComponent<UIQuestionTip> ().SetContent ("是否用铁器发展农业？");
			_getTip.GetComponent<UIQuestionTip> ().SetType (ResourceType.YG_Algorithm);
			if(YG_Data.Is_Cultivate==true)
			{
				
				gameObject.GetComponent<RawImage>().texture=_cropsTexture;
				YG_Data.Had_Finish_Cultivate +=1 ;
			}
		}
	}
}
