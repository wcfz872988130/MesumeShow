using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class UISelected : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		text.DOText ("请选择一个原始部落，开启您的旅程。",2).SetEase (Ease.Linear).SetAutoKill (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
