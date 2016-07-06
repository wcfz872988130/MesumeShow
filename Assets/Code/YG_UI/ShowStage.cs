using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowStage : MonoBehaviour {
	public static ShowStage _instance;
	// Use this for initialization
	void Start () {
	}

	ShowStage()
	{
		_instance = this;
	}

	public static ShowStage GetShowStage()
	{
		if(_instance==null)
		{
			_instance = new ShowStage ();
		}
		return _instance;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void AddStage()
	{
		StartCoroutine (Stage());
	}

	public IEnumerator Stage()
	{
		float m_time = 0.0f;
		while(m_time<1.0f)
		{
			yield return new WaitForSeconds (0.05f);
			m_time += 0.05f;
			gameObject.GetComponent<Slider>().value+=(1.0f/(ResourceManager.HiStage*20));
		}
	}
}
