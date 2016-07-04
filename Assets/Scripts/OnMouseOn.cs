using UnityEngine;
using System.Collections;

public class OnMouseOn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.shader=Shader.Find("Bumped Specular");
    }
    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
    }
}
