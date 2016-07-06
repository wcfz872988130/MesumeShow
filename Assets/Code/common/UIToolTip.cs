using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum TipStyle
{
	Null,
	HMD_GS,
	HMD_China,
	HMD_Build,
	HMD_Decorate,
	HMD_Empty,
	YG_Start,
	YG_metallurgy,
	YG_GoldTime,
	YG_Book,
    BuildHouse,
	LZ_Resource,
	LZ_zhitaoshu,    //制陶术
	LZ_CCC,
	LZ_fuhaoshu     //符号数
}

public class UIToolTip : MonoBehaviour {

	TipStyle type=TipStyle.Null;
    //int type = 0;
    public Text _title;
    public Text _content;

	public Texture tx1;
	public Texture tx2;
	public Texture tx3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetType(TipStyle style)
    {
        type = style;
    }

    public void SetTitle(string str)
    {
        _title.text = str;
    }

    public void SetContent(string str)
    {
        _content.text = str;
    }

    public void Click()
    {
        Destroy(gameObject);

		if (type == TipStyle.Null) {

		} else if (type == TipStyle.HMD_GS) {
			Object obj2 = Resources.Load ("prefab/Result");
			GameObject go2 = Instantiate (obj2) as GameObject;
			go2.transform.SetParent (ResourceManager._bg.transform, false);
			go2.GetComponent<UIResult> ().SetTxt ("开启耜耕阶段\n获得道具“骨耜”，可使用“骨耜”开发土壤资源");
			GameObject c0 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill0/IconBg/skill0Image");
			c0.GetComponent<RawImage> ().texture = tx3;
			GameObject t0 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill0/Text");
			t0.GetComponent<Text> ().color = Color.white;
		} else if (type == TipStyle.HMD_Build) {
			GameObject go = GameObject.Find ("Canvas/bg/SkillTree");
			go.SetActive (true);
			go.GetComponent<RectTransform> ().SetAsLastSibling ();
			GameObject content1 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill1");
			content1.GetComponent<Button> ().interactable = true;
			GameObject c1 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill1/IconBg/RawImage");
			c1.GetComponent<RawImage> ().texture = tx1;
			GameObject t1 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill1/Text");
			t1.GetComponent<Text> ().color = Color.white;
		} else if (type == TipStyle.HMD_China) {
			GameObject go3 = GameObject.Find ("Canvas/bg/SkillTree");
			go3.SetActive (true);
			go3.GetComponent<RectTransform> ().SetAsLastSibling ();
			GameObject content2 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill2");
			content2.GetComponent<Button> ().interactable = true;
			GameObject c2 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill2/IconBg/RawImage");
			c2.GetComponent<RawImage> ().texture = tx2;
			GameObject t2 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill2/Text");
			t2.GetComponent<Text> ().color = Color.white;
		} else if (type == TipStyle.HMD_Decorate) {
			GameObject go3 = GameObject.Find ("Canvas/bg/SkillTree");
			go3.SetActive (true);
			go3.GetComponent<RectTransform> ().SetAsLastSibling ();
			GameObject content3 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill3");
			content3.GetComponent<Button> ().interactable = true;
			GameObject c3 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill3/IconBg/RawImage");
			c3.GetComponent<RawImage> ().texture = tx3;
			GameObject t3 = GameObject.Find ("Canvas/bg/SkillTree/content/Skill3/Text");
			t3.GetComponent<Text> ().color = Color.white;
		} else if (type == TipStyle.HMD_Empty) {
			UIEmptyArea empty = Transform.FindObjectOfType (typeof(UIEmptyArea)) as UIEmptyArea;
			empty._isOpen = true;
		} else if (type == TipStyle.YG_Start) {
			YG_Data.start_finish = true;
		}
		else if(type==TipStyle.YG_Book)
		{
			YG_Data.Had_Finish_Book = true;
		}
		else if (type == TipStyle.YG_metallurgy) {
			GameObject slider = GameObject.Find ("Canvas/bg/ShowStage");
			//slider.GetComponent<ShowStage> ().AddStage ();
		}
		else if(type==TipStyle.YG_GoldTime)
		{
			YG_Data.start_war = true;
		}
		else if(type == TipStyle.LZ_Resource)
		{
			LiangzuFrame.currentStep = MuseumStep.Resource;
		}
		else if (type == TipStyle.LZ_zhitaoshu)
		{
			ResourceManager._knowzhitaoshu = 1;
		}
		else if (type == TipStyle.LZ_CCC)
		{
			Object obj2 = Resources.Load("prefab/Result");
			GameObject go2 = Instantiate(obj2) as GameObject;
			go2.transform.SetParent(ResourceManager._bg.transform, false);
			go2.GetComponent<UIResult>().SetTxt("开启耜耕阶段\n获得道具“骨耜”，可使用“骨耜”开发土壤资源");
			GameObject c0 = GameObject.Find("Canvas/bg/SkillTree_lz/content/Skill0/IconBg/skill0Image");
			c0.GetComponent<RawImage>().texture = tx3;
			GameObject t0 = GameObject.Find("Canvas/bg/SkillTree_lz/content/Skill0/Text");
			t0.GetComponent<Text>().color = Color.white;
		}
		else if (type == TipStyle.LZ_fuhaoshu)
		{
			ResourceManager._knowfuhaoshu = 1;
		}
    }

}
