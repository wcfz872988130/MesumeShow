using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIEmptyArea : MonoBehaviour {

    public bool _isOpen = false;

    private float _Time=0.0f;

    Texture _biankuang;
    Texture _transparent;

	// Use this for initialization
	void Start () {
        _biankuang = Resources.Load("Textures/biankuang") as Texture;
        _transparent = Resources.Load("pic/transparent") as Texture;
	}
	
	// Update is called once per frame
	void Update () {

        if (_isOpen == false)
            return;

        _Time += Time.deltaTime;
        if (_Time >= 0.8f)
        {
            _Time = 0;

            Texture txt = transform.GetComponent<RawImage>().texture;

            if (txt == null)
            {
                txt = _biankuang;
                return;
            }

            string txtName = txt.name;
            if (txtName.Equals("biankuang"))
            {
                transform.GetComponent<RawImage>().texture = _transparent;
                return;
            }
            else if (txtName.Equals("transparent"))
            {
                transform.GetComponent<RawImage>().texture = _biankuang;
                return;
            }

        }
        

	}
}

