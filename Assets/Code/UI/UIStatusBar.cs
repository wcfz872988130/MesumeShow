using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusBar
{
	private Texture m_pic;
	private Color m_txtColor;
	private GameObject m_go;
	public UIStatusBar (Texture pic,Color txtColor,GameObject go)
	{
		m_pic = pic;
		m_txtColor = txtColor;
		m_go = go;
	}
	public void ChangeTextureAndText()
	{
		m_go.transform.Find ("IconBg/RawImage").gameObject.GetComponent<RawImage> ().texture = m_pic;
		m_go.transform.Find ("Text").gameObject.GetComponent<Text> ().color = m_txtColor;
	}

	public void ChangeInteractable()
	{
		bool inter = m_go.GetComponent<Button> ().interactable;
		m_go.GetComponent<Button> ().interactable = !inter;
	}
}


