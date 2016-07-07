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
	GameObject skillTree;

	private UI_Manager _uimanager;

	// Use this for initialization
	void Start () {
		_uimanager = UI_Manager.GetUIManager ();
		if(GameObject.Find ("Canvas/bg/SkillTree"))
			skillTree=GameObject.Find ("Canvas/bg/SkillTree").gameObject;
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
			GameObject go2 = _uimanager.LoadPrefab ("Result",fileAddress.Com,true);
			go2.GetComponent<UIResult> ().SetTxt ("开启耜耕阶段\n获得道具“骨耜”，可使用“骨耜”开发土壤资源");
			skillTree.GetComponent<UISkillTree> ().changeTextureAndTxtColor (0);
		} else if (type == TipStyle.HMD_Build) {
			skillTree.SetActive (true);
			skillTree.GetComponent<RectTransform> ().SetAsLastSibling ();
			skillTree.GetComponent<UISkillTree> ().changeInteractable (1);      //改变相应位置状态栏的可交互性
			skillTree.GetComponent<UISkillTree> ().changeTextureAndTxtColor (1);//改变相应状态栏的图标的纹理及文字颜色
		} else if (type == TipStyle.HMD_China) {
			skillTree.SetActive (true);
			skillTree.GetComponent<RectTransform> ().SetAsLastSibling ();
			skillTree.GetComponent<UISkillTree> ().changeInteractable (2); 
			skillTree.GetComponent<UISkillTree> ().changeTextureAndTxtColor (2);
		} else if (type == TipStyle.HMD_Decorate) {
			skillTree.SetActive (true);
			skillTree.GetComponent<RectTransform> ().SetAsLastSibling ();
			skillTree.GetComponent<UISkillTree> ().changeInteractable (3); 
			skillTree.GetComponent<UISkillTree> ().changeTextureAndTxtColor (3);
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
			//GameObject slider = GameObject.Find ("Canvas/bg/ShowStage");
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
			GameObject go2 = _uimanager.LoadPrefab ("Result",fileAddress.Com,true);
			go2.GetComponent<UIResult>().SetTxt("开启耜耕阶段\n获得道具“骨耜”，可使用“骨耜”开发土壤资源");
			GameObject c0 = GameObject.Find("Canvas/bg/SkillTree_lz/content/Skill0/IconBg/skill0Image");
			Texture tx3 = Resources.Load ("pic/skill_guli") as Texture;
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
