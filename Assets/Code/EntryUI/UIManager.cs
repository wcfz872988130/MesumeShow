using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	public GameObject startGame;
	public GameObject SelectedGame;
	public GameObject Loading;
	public GameObject _text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGameClick()
	{
		startGame.SetActive (false);
		SelectedGame.SetActive (true);
	}

	public void SelectedGameClick()
	{
		SelectedGame.SetActive (false);
		Loading.SetActive (true);
	}

	public void SliderChange()
	{
		
	}

	public void Button1Click()
	{
		_text.GetComponent<Text>().text=@"....河姆渡遗址发现大量的谷物和骨耜，证明当时的农业已进入“耜耕阶段”。农业种植技术的传承、农具和粮食加工工具的制造，都成为教育的主要内容。";
	}

	public void Button2Click()
	{
		_text.GetComponent<Text>().text=@"....河姆人的房舍建筑以大小木桩为基础，做成高于地面的基座，并在建造中较多采用榫卯技术。这种干栏式建筑比同时期黄河流域的半地穴建筑复杂得多。";
	}

	public void Button3Click()
	{
		_text.GetComponent<Text>().text=@"....手工制作产品的出现，是人类文明史上的一个重要进步。河姆渡刻于器物上的装饰艺术，内容以鸟为主，其次是太阳、鱼、蚕等形象和一些图案，展示河姆渡人的原始审美取向，开艺术教育之先河。";
	}
}
