using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISlider : MonoBehaviour {
	private float time=0;
	private UIBg _Instance;
	private UIEquipment _instance = UIEquipment.GetUIEquipement ();
	// Use this for initialization
	void Start () {
		_Instance = UIBg.GetUIBg ();
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
			Object obj = Resources.Load ("prefab/Get");
			GameObject go = Instantiate (obj) as GameObject;
			go.transform.SetParent (ResourceManager._bg.transform,false);
			go.GetComponent<UIHaveSome>().SetText("获得道具:"+"陶器+1");
			go.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,60);

			Object it = Resources.Load ("prefab/china_daoju");
			GameObject equip = Instantiate (it) as GameObject;
			_instance.Get_Props (equip);
			ResourceManager._totalEquipement.Add (equip);

			Object obj3 = Resources.Load ("prefab/China");
			GameObject go3 = Instantiate (obj3) as GameObject;
			go3.transform.SetParent (ResourceManager._bg.transform,false);

			GameObject content3 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill2");
			if (content3 !=null)
				content3.GetComponent<Button> ().interactable = false;
			if(content3 !=null)
				_Instance.ShowQuestionTips();

			//lz
			GameObject content4 = GameObject.Find("Canvas/bg/SkillTree_lz/content/Skill2");
			if(content4 != null)
				content4.GetComponent<Button>().interactable = false;

			if (content4 != null)
			{
				Debug.Log("!=NULL");
				Object obj2 = Resources.Load("prefab/ToolTip");
				GameObject go2 = Instantiate(obj2) as GameObject;
				go2.transform.SetParent(ResourceManager._bg.transform, false);
				go2.GetComponent<UIToolTip>().SetType(TipStyle.LZ_fuhaoshu);
				go2.GetComponent<UIToolTip>().SetTitle("新科技");
				go2.GetComponent<UIToolTip>().SetContent("符号术");
			}


		}
	}
}
