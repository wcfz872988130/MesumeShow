using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISkillTree : MonoBehaviour {
	public Texture kongdi;
	// Use this for initialization
	void Start () {
	
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
			Object obj3 = Resources.Load ("prefab/Slider");
			GameObject go3 = Instantiate (obj3) as GameObject;
			go3.transform.SetParent (ResourceManager._bg.transform, false);

            gameObject.SetActive(false);
			break;
		case "Skill3":
			Object obj4 = Resources.Load ("prefab/Get");
			GameObject go4 = Instantiate (obj4) as GameObject;
			go4.GetComponent<UIHaveSome> ().SetText ("提示：给陶器刻上花纹");
			go4.transform.SetParent (ResourceManager._bg.transform, false);

			GameObject chinaTxt = GameObject.Find ("Canvas/bg/ChinaTexture(Clone)");
			if (chinaTxt == null) {
				Object obj5 = Resources.Load ("prefab/ChinaTexture");
				chinaTxt = Instantiate (obj5) as GameObject;
				chinaTxt.transform.SetParent (ResourceManager._bg.transform, false);
			}

			GameObject china = GameObject.Find ("Canvas/bg/China(Clone)");
			if (china == null) {
				Object chinaObj = Resources.Load ("prefab/China");
				china = Instantiate (chinaObj) as GameObject;
				china.transform.SetParent (ResourceManager._bg.transform, false);
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
		GameObject Menu = GameObject.Find ("Canvas/bg/SkillTree");
		Menu.SetActive (false);
		ResourceManager._treeCount -= 10;
		GameObject skillTree = GameObject.Find ("Canvas/bg/SkillTree");
		//go.SetActive (false);
		Object obj2 = Resources.Load ("prefab/ToolTip");
		GameObject go2 = Instantiate (obj2) as GameObject;
		go2.transform.SetParent (ResourceManager._bg.transform, false);
		go2.GetComponent<UIToolTip> ().SetType (TipStyle.HMD_Empty);
		go2.GetComponent<UIToolTip> ().SetContent ("选择一块空地建造建筑。");
		GameObject Empty = GameObject.Find ("Canvas/bg/Resource(Clone)/EmptyArea");
		//Empty.GetComponent<RawImage> ().texture = kongdi;
		GameObject content3 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill1");
		content3.GetComponent<Button> ().interactable = false;
		UIResource._IsFinish = true;
	}

}
