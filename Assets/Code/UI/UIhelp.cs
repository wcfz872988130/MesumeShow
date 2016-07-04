using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIhelp : MonoBehaviour {
	public void HelpClick () {
		SceneManager.LoadSceneAsync ("PDFScene");
	}
}
