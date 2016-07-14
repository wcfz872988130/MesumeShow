using UnityEngine;
using System.Collections;

public class UIEquipment : MonoBehaviour {
	public GameObject[] Cells;
	//public Object[] items;
	//private GameObject equip;
	private static UIEquipment _Instance;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private UIEquipment()
	{
		_Instance=this;
	}

	public static UIEquipment GetUIEquipement()
	{
		if(_Instance==null)
		{
			_Instance = new UIEquipment ();
		}
		return _Instance;
	}

	public void Get_Props(GameObject equip)//获取的物品的索引；
	{
		for(int i=0;i<Cells.Length;i++)
		{
			if(Cells[i].transform.childCount==0)
			{
				equip.transform.SetParent (Cells[i].transform,false);
				break;
			}
		}
	}

	public void ClickClose()
	{
		gameObject.SetActive (false);
	}
		
}
