using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PDFReader : MonoBehaviour {
	public Texture[] tex;
	private int index = 0;
	private GameObject Content;
	private GameObject _text;
	private Vector2 exit_position;
	private float exit_duringTime;
	// Use this for initialization
	void Start () {
		Content = GameObject.Find ("Canvas/PDFReader/Viewport/Content/RawImage");
		_text = gameObject.transform.Find ("tip").gameObject;
		exit_position = new Vector2 (1210,0);
		exit_duringTime = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void close()
	{
		gameObject.GetComponent<RectTransform> ().DOAnchorPos3D (exit_position,exit_duringTime);
	}

	public void NextReader()
	{
		index += 1;
		if (index >= tex.Length) 
		{
			if (!_text.activeSelf) 
			{
				StartCoroutine (ShowTime());
				_text.SetActive (true);
				_text.GetComponent<Text> ().text = "已到达尾页";
			}
			index = tex.Length - 1;
			return;
		}
		Content.GetComponent<RawImage>().texture=tex[index];
	}

	public void frontReader()
	{
		index -= 1;
		if (index < 0) 
		{
			if (!_text.activeSelf) 
			{
				StartCoroutine (ShowTime());
				_text.SetActive (true);
				_text.GetComponent<Text> ().text = "已到达首页";
			}
			index = 0;
			return;
		}
		Content.GetComponent<RawImage>().texture=tex[index];
	}

	IEnumerator ShowTime()
	{
		yield return new WaitForSeconds (0.5f);
		_text.SetActive (false);
	}
}
