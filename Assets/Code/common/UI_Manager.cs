using UnityEngine;
using System.Collections;

public enum fileAddress
{
	HMD,
	LZ,
	YG,
	Com
}

public class UI_Manager : MonoBehaviour {
	public const string KPrefabYG = "prefabs/YG_Prefabs/";
	public const string KPrefabLZ = "prefabs/LZ_Prefabs/";
	public const string KPrefabHMD = "prefabs/";
	public const string KPrefabCom = "prefab/";

	private GameObject bg;
	private static UI_Manager _uiInstance;
	// Use this for initialization

//	UI_Manager()
//	{
//		_uiInstance = this;
//	}
	void Awake () {
		_uiInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static UI_Manager GetUIManager()
	{
//		if(_uiInstance==null)
//		{
//			_uiInstance = new UI_Manager ();
//		}
		return _uiInstance;
	}
	public GameObject LoadPrefab(string name,fileAddress fa,bool _Show)
	{
		bg=GameObject.Find("Canvas/bg");
		string address="";
		switch(fa)
		{
		case fileAddress.Com:
			address = KPrefabCom + name;
			break;
		case fileAddress.HMD:
			address = KPrefabHMD + name;
			break;
		case fileAddress.LZ:
			address = KPrefabLZ + name;
			break;
		case fileAddress.YG:
			address = KPrefabYG + name;
			break;
		}
		GameObject _obj = Resources.Load (address) as GameObject;
		GameObject tempObject = Instantiate (_obj);
		if(_Show==true)
		{
			tempObject.transform.SetParent (bg.transform,false);
		}
		return tempObject;
	}
}
