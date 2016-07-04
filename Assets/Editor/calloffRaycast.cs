using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	[MenuItem("GameObject/UI/Image")]
	static void CreateImage()
	{
		if(Selection.activeTransform)
		{
			if(Selection.activeTransform.GetComponentInParent<Canvas>())//向上递归直到找到一个有效的插件
			{
				GameObject go=new GameObject("Image",typeof(Image));
				go.GetComponent<Image>().raycastTarget=false;
				go.transform.SetParent(Selection.activeTransform);
			}
		}
	}

	[MenuItem("GameObject/UI/RawImage")]
	static void GreateRawImage()
	{
		if(Selection.activeTransform)
		{
			if (Selection.activeTransform.GetComponentInParent<Canvas>()) 
			{
				GameObject ob = new GameObject ("RawImage",typeof(RawImage));
				ob.GetComponent<RawImage> ().raycastTarget = false;
				ob.transform.SetParent (Selection.activeTransform,false);
			}
		}
	}
}
