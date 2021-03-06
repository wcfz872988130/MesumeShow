﻿using UnityEngine;
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
	Finish,
	LZ_shi,
	LZ_cai
}

public class UIQuestionTip : MonoBehaviour {
	UI_Manager _uiManager=UI_Manager.GetUIManager();
    ResourceType _type = ResourceType.Null;

    public Text _title;
    public Text _content;

	// Use this for initialization
	void Start () {
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
			GameObject go = _uiManager.LoadPrefab ("Get",fileAddress.Com,true);
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
				ResourceManager._treeCount -= 10;
                MuseumFrame.currentStep = MuseumStep.ShowBuildHouseToolTip;
			}
			GameObject go = _uiManager.LoadPrefab ("Get",fileAddress.Com,true);
			go.GetComponent<UIHaveSome>().SetText("获得道具:木材+"+num);
			GameObject go3 = _uiManager.LoadPrefab ("wood",fileAddress.Com,true);
		}
		else if(_type==ResourceType.LZ_StoneCollection)
		{
			
		}
		else if(_type==ResourceType.YG_Civilization)
		{
			GameObject _goldTime = _uiManager.LoadPrefab ("ToolTip",fileAddress.Com,true);
			_goldTime.GetComponent<UIToolTip> ().SetContent ("提示:开启“黄金时代“,文明值、技能值增速提高增速提高15%。");
			_goldTime.GetComponent<UIToolTip> ().SetType (TipStyle.YG_GoldTime);
		}
		else if(_type==ResourceType.YG_Algorithm)
		{
			Texture2D cropTexture = Resources.Load ("YG_Textures/"+YG_Data.cropname) as Texture2D;
			GameObject cropland = GameObject.Find ("Canvas/bg/YG_Resources(Clone)/"+YG_Data.cropname);
			cropland.GetComponent<RawImage> ().texture = cropTexture;
		}
		else if(_type==ResourceType.Finish)
		{
			_uiManager.LoadPrefab("EndPanel",fileAddress.HMD,true);
		}
		else if (_type == ResourceType.LZ_shi)
		{
			int num = Random.Range(3, 5);
			Destroy(ResourceManager._chooseResource);
			ResourceManager._chooseResource = null;
			ResourceManager._shiCount += num;
			if (ResourceManager._shiCount >= 5)
			{
				LiangzuFrame.currentStep = MuseumStep.ShowGuliToolTip;
			}
			GameObject go=_uiManager.LoadPrefab("Get",fileAddress.Com,true);
			go.GetComponent<UIHaveSome>().SetText("获得道具:石头+" + num);
			GameObject go3 = _uiManager.LoadPrefab ("wood",fileAddress.Com,true);
		}
		else if(_type == ResourceType.LZ_cai)
		{
			ResourceManager._chooseResource.GetComponent<RawImage>().texture = Resources.Load("LZ_Textures/" + ResourceManager._chooseResource.name) as Texture;
			if(ResourceManager._knowzhitaoshu==0)
			{
				LiangzuFrame.currentStep = MuseumStep.ShowQuestionTip;
				//ResourceManager._knowzhitaoshu = 1;
			}
		}
    }

    public void ClickNo()
    {
        Destroy(gameObject);
    }
		
}
