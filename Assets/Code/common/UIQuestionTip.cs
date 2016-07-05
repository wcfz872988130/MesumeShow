using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ResourceType { 
    Null,
    HMD_Tree,
	HMD_Cao,
	HMD_Cao1,
	HMD_Horse,
	LZ_StoneCollection,
	YG_Civilization,
	YG_Algorithm,
	Finish
}

public class UIQuestionTip : MonoBehaviour {
    GameObject _bg;

    ResourceType _type = ResourceType.Null;

    public Text _title;
    public Text _content;

	// Use this for initialization
	void Start () {
        _bg = GameObject.Find("Canvas/bg");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetType(ResourceType type)
    {
        _type = type;
    }

	public void SetTextSize(int data)
	{
		_content.fontSize = data;
	}

    public void SetTitle(string str)
    {
        _title.text = str;
    }

    public void SetContent(string str)
    {
        _content.text = str;
    }

    public void ClickYes()
    {
        Destroy(gameObject);

		if (_type == ResourceType.HMD_Horse)
        {
            Object obj = Resources.Load("prefab/Get");
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.SetParent(_bg.transform, false);
            go.GetComponent<UIHaveSome>().SetText("获得道具：骨头+1");
            ResourceManager._guliCount += 1;
            Destroy(ResourceManager._chooseResource);
            ResourceManager._chooseResource = null;

			if (ResourceManager._KillHorse == true)
				return;

            MuseumFrame.currentStep = MuseumStep.ShowGuliToolTip;
		}
		else if (_type == ResourceType.HMD_Cao)
        {
			ResourceManager._chooseResource.GetComponent<RawImage>().texture = Resources.Load("Grass2/"+1) as Texture;
        }
		else if (_type == ResourceType.HMD_Cao1)
		{
			string name = ResourceManager._chooseResource.name.Substring (3);
			ResourceManager._chooseResource.GetComponent<RawImage>().texture = Resources.Load("Grass1/"+name) as Texture;
		}
		else if(_type==ResourceType.HMD_Tree)
		{
			int num = Random.Range (3,5);
			Destroy(ResourceManager._chooseResource);
			ResourceManager._chooseResource = null;
			ResourceManager._treeCount += num;
			if(ResourceManager._treeCount>=10)
			{
                MuseumFrame.currentStep = MuseumStep.ShowBuildHouseToolTip;
			}
			Object obj = Resources.Load ("prefab/Get");
			GameObject go = Instantiate (obj) as GameObject;
			go.transform.SetParent (_bg.transform,false);
			go.GetComponent<UIHaveSome>().SetText("获得道具:木材+"+num);

			Object obj3 = Resources.Load ("prefab/wood");
			GameObject go3 = Instantiate (obj3) as GameObject;
			go3.transform.SetParent (_bg.transform,false);
		}
		else if(_type==ResourceType.LZ_StoneCollection)
		{
			
		}
		else if(_type==ResourceType.YG_Civilization)
		{
			GameObject _obj = Resources.Load ("prefab/ToolTip") as GameObject;
			GameObject _goldTime = Instantiate (_obj);
			_goldTime.transform.SetParent (_bg.transform,false);
			_goldTime.GetComponent<UIToolTip> ().SetContent ("提示:开启“黄金时代“,文明值、技能值增速提高增速提高15%。");
			YG_Data.start_war = true;
		}
		else if(_type==ResourceType.YG_Algorithm)
		{
			Texture2D cropTexture = Resources.Load ("YG_Textures/"+YG_Data.cropname) as Texture2D;
			GameObject cropland = GameObject.Find ("Canvas/bg/YG_Resources(Clone)/"+YG_Data.cropname);
			cropland.GetComponent<RawImage> ().texture = cropTexture;
		}
		else if(_type==ResourceType.Finish)
		{
			SceneManager.LoadSceneAsync ("End");
		}
    }

    public void ClickNo()
    {
        Destroy(gameObject);
    }
		
}
