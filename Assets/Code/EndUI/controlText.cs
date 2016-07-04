using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class controlText : MonoBehaviour {
	public Text text1;
	public Text text2;
	private bool finish = true;
	private float _t = 0.0f;
	// Use this for initialization
	void Start () {
		text1.DOText ("<color=#F0F1EAFF><b>获得技能:</b></color>\n<color=#F0F1EAFF>骨耜制作\r 榫卯技术\r 制陶术 装饰艺术</color>",2).SetEase (Ease.Linear).SetAutoKill (false);
	}
	
	// Update is called once per frame
	void Update () {
		_t += Time.deltaTime;
		if (_t > 2.5f&&finish) {
			text2.DOText ("<color=#F0F1EAFF><b>获得道具:</b></color>\n<color=#F0F1EAFF>陶器</color>",2).SetEase (Ease.Linear).SetAutoKill (false);
			finish = false;
		}
	
	}
	public void ButtonClick()
	{
		SceneManager.LoadSceneAsync ("Level1");
	}
}
