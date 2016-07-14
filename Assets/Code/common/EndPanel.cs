using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour{

	// Use this for initialization
	void Start () {
		GameObject _score = gameObject.transform.Find ("Score").gameObject;
		_score.GetComponent<Text> ().text = (ResourceManager.Score).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void next()
	{
		SceneManager.LoadSceneAsync(ResourceManager.nextScene);
		MuseumFrame.currentStep=MuseumStep.Entry;
	}
}
