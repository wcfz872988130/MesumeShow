using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UISkillTree : MonoBehaviour {
	const int _barNum = 4;
	public Texture kongdi;
	private UI_Manager _uiManager;
	private Dictionary<int,UIStatusBar> staBar=new Dictionary<int,UIStatusBar>();
	bool _isLoading=false;
	// Use this for initialization
	void Start () {
		_uiManager = UI_Manager.GetUIManager ();
		}

	void Loading()
	{
		Texture skill2 = Resources.Load ("pic/skill2") as Texture;
		Texture skill3 = Resources.Load ("pic/skill3") as Texture;
		Texture skill_guli = Resources.Load ("pic/skill_guli") as Texture;
		Color co = Color.white;
		for(int i=0;i<_barNum;i++)
		{
			GameObject go = gameObject.transform.Find ("content/Skill"+i.ToString()).gameObject;
			switch(i)
			{
			case 0:
				UIStatusBar statusBar0 = new UIStatusBar (skill_guli, co, go);
				staBar.Add (i,statusBar0);
				break;
			case 1:
				UIStatusBar statusBar1 = new UIStatusBar (skill2, co, go);
				staBar.Add (i,statusBar1);
				break;
			case 2:
				UIStatusBar statusBar2 = new UIStatusBar (skill3, co, go);
				staBar.Add (i,statusBar2);
				break;
			case 3:
				UIStatusBar statusBar3 = new UIStatusBar (skill_guli, co, go);
				staBar.Add (i,statusBar3);
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickClose()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public void ClickSkill(GameObject go)
    {
		switch(go.name)
		{
		case "Skill1":
			StartCoroutine (LoadBuilding());
			break;
		case "Skill2":
			GameObject go3=_uiManager.LoadPrefab("Slider",fileAddress.Com,true);
            gameObject.SetActive(false);
			break;
		case "Skill3":
			GameObject go4 = _uiManager.LoadPrefab("Get",fileAddress.Com,true);
			go4.GetComponent<UIHaveSome> ().SetText ("提示：给陶器刻上花纹");

			GameObject chinaTxt = GameObject.Find ("Canvas/bg/ChinaTexture(Clone)");
			if (chinaTxt == null) {
				chinaTxt=_uiManager.LoadPrefab("ChinaTexture",fileAddress.Com,true);
			}

			GameObject china = GameObject.Find ("Canvas/bg/China(Clone)");
			if (china == null) {
				china = _uiManager.LoadPrefab ("China",fileAddress.Com,true);
			} else {
				china.SetActive (true);
			}

			break;
		case "Skill4":
			break;
		}
    }

	IEnumerator LoadBuilding()
	{
		yield return new WaitForSeconds (1.0f);
		gameObject.SetActive (false);
		ResourceManager._treeCount -= 10;
		GameObject go2=_uiManager.LoadPrefab("ToolTip",fileAddress.Com,true);
		go2.GetComponent<UIToolTip> ().SetType (TipStyle.HMD_Empty);
		go2.GetComponent<UIToolTip> ().SetContent ("选择一块空地建造建筑。");
		GameObject Empty = GameObject.Find ("Canvas/bg/Resource(Clone)/EmptyArea");
		GameObject content3 =gameObject.transform.Find("content/Skill1").gameObject;
		content3.GetComponent<Button> ().interactable = false;
		UIResource._IsFinish = true;
	}

	public void changeTextureAndTxtColor(int barLocation)	//skill in i with texture and txt color
	{
		if(!_isLoading)
		{
			Loading ();
			_isLoading = true;
		}
		staBar [barLocation].ChangeTextureAndText ();
	}

	public void changeInteractable(int barLocation)
	{
		if(!_isLoading)
		{
			Loading ();
			_isLoading = true;
		}
		staBar [barLocation].ChangeInteractable ();
	}

}
