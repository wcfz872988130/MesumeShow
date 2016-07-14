using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISlider : MonoBehaviour {
	private float time=0;
	private UIBg _Instance;
	private UI_Manager _uimanager;
	private UIEquipment _instance = UIEquipment.GetUIEquipement ();
	// Use this for initialization
	void Start () {
		_Instance = UIBg.GetUIBg ();
		_uimanager = UI_Manager.GetUIManager ();
	}
	
	// Update is called once per frame
	void Update () {
		if(time<3.0f)
		{
			time += Time.deltaTime;
			gameObject.GetComponent<Slider> ().value+=(Time.deltaTime)/3.0f;
		}
		if (gameObject.GetComponent<Slider> ().value == 1) {
			Destroy (gameObject);
			GameObject go = _uimanager.LoadPrefab ("Get",fileAddress.Com,true);
			go.GetComponent<UIHaveSome>().SetText("获得道具:"+"陶器+1");
			go.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,60);

			//Object it = Resources.Load ("prefab/china_daoju");
			//GameObject equip = Instantiate (it) as GameObject;
			GameObject equip=_uimanager.LoadPrefab("china_daoju",fileAddress.Com,false);
			ResourceManager._totalEquipement.Add ("prefab/china_daoju");
			_instance.Get_Props (equip);

			_uimanager.LoadPrefab ("China",fileAddress.Com,true);
			GameObject skillTree = GameObject.Find ("Canvas/bg/SkillTree");
			if (skillTree != null) {
				GameObject content3 = skillTree.transform.Find ("content/Skill2").gameObject;
				if (content3 != null)
					skillTree.GetComponent<UISkillTree> ().changeInteractable (2);
				if(content3 !=null)
					_Instance.ShowQuestionTips();
			}

			//lz
			GameObject content4 = GameObject.Find("Canvas/bg/SkillTree_lz/content/Skill1");
			if(content4 != null)
				content4.GetComponent<Button>().interactable = false;
			LiangzuFrame.currentStep = MuseumStep.ShowBuildHouseToolTip;
//			if (content4 != null)
//			{
//				Debug.Log("!=NULL");
//				GameObject go2=_uimanager.LoadPrefab("ToolTip",fileAddress.Com,true);
//				go2.GetComponent<UIToolTip>().SetType(TipStyle.LZ_fuhaoshu);
//				go2.GetComponent<UIToolTip>().SetTitle("新科技");
//				go2.GetComponent<UIToolTip>().SetContent("符号术");
//			}


		}
	}
}
