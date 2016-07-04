using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIEntrySlider : MonoBehaviour {
	private float _Time=0.0f;
	private bool _isFinish = true;
	AsyncOperation asyncOperation;
	// Use this for initialization
	void Start () {
		StartCoroutine (Delta());

	}

	IEnumerator Delta()
	{
		
		yield return wait (5.0f);
		StartCoroutine (LoadScene("Level1"));
	}

	IEnumerator LoadScene(string sceneName)
	{
		yield return asyncOperation = SceneManager.LoadSceneAsync (sceneName);
	}

	IEnumerator wait(float _Time)
	{
		for(float tt=0;tt<_Time;tt+=Time.deltaTime)
		{
			gameObject.GetComponent<Slider> ().value =tt/5.0f;
			yield return 0;
		}
	}

	// Update is called once per frame
//	void Update () {
//		
////		if(_Time>=3.0f){
////			SceneManager.LoadSceneAsync ("Level1");
////		}
//		if (_Time < 5.0f) {
//			gameObject.GetComponent<Slider> ().value += Time.deltaTime / 3.0f;
//			_Time += Time.deltaTime;
//			if(_Time>=3.0f&&_isFinish)
//			{
//				_isFinish = false;
//				SceneManager.LoadScene ("Level1");
//			}
//		} else {
//			Destroy (gameObject);
//		}
//	}
}
