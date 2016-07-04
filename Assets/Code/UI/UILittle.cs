using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;


public class UILittle : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler{

    const float moveTime = 0.6f;
    const float firstTimeDis = 1.5f;
    bool firstDone = false;
    float time = 0.0f;
    float delayTime = moveTime;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<RawImage>().mainTexture.name.Equals("transparent"))
            return;

        if (name.Contains("horse1"))
        {
            time += Time.deltaTime;
            if (time < delayTime)
                return;
            time -= delayTime;

            int num = int.Parse(gameObject.GetComponent<RawImage>().mainTexture.name) - 1;
            Texture _pic = Resources.Load("Cow/Cow1/"+ ((num+1)%3+1)) as Texture;
            gameObject.GetComponent<RawImage>().texture = _pic;

            if (num == 2)
            {
                delayTime = 3.0f;
            }
            else
            {
                delayTime = moveTime;
            }
        }

        if (name.Contains("horse2"))
        {
            time += Time.deltaTime;

            if (firstDone == false)
            {
                if (time <= firstTimeDis)
                    return;
                else
                {
                    firstDone = true;
                    time -= firstTimeDis;
                    return;
                }
            }

            if (time < delayTime)
                return;
            time -= delayTime;

            int num = int.Parse(gameObject.GetComponent<RawImage>().mainTexture.name) - 1;
            Texture _pic = Resources.Load("Cow/Cow2/" + ((num + 1) % 4 + 1)) as Texture;
            gameObject.GetComponent<RawImage>().texture = _pic;

            if (num == 2)
            {
                delayTime = 3.0f;
            }
            else
            {
                delayTime = moveTime;
            }
        }


		if (name.Equals("cao1")||name.Equals("cao2"))
        {
            time += Time.deltaTime;
            if (time < delayTime)
                return;
            time -= delayTime;

            int num = int.Parse(gameObject.GetComponent<RawImage>().mainTexture.name) - 1;
            Texture _pic = Resources.Load("Grass2/" + ((num + 1) % 7 + 1)) as Texture;
            gameObject.GetComponent<RawImage>().texture = _pic;

            if (num == 2)
            {
                delayTime = 3.0f;
            }
            else
            {
                delayTime = moveTime;
            }
        }

//        if (name.Contains("cao3"))
//        {
//            time += Time.deltaTime;
//
//            if (firstDone == false)
//            {
//                if (time <= firstTimeDis)
//                    return;
//                else
//                {
//                    firstDone = true;
//                    time -= firstTimeDis;
//                    return;
//                }
//            }
//
//            if (time < delayTime)
//                return;
//            time -= delayTime;
//
//            int num = int.Parse(gameObject.GetComponent<RawImage>().mainTexture.name) - 1;
//            Texture _pic = Resources.Load("Grass1/" + ((num + 1) % 12 + 1)) as Texture;
//            gameObject.GetComponent<RawImage>().texture = _pic;
//
//            if (num == 2)
//            {
//                delayTime = 3.0f;
//            }
//            else
//            {
//                delayTime = moveTime;
//            }
//        }

	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        Object obj = Resources.Load("prefab/GetBlade");
        GameObject go = Instantiate(obj) as GameObject;
        go.transform.SetParent(transform, false);
        go.transform.rotation = Quaternion.identity;
		go.GetComponent<RectTransform> ().SetAsLastSibling ();
        go.transform.localPosition += new Vector3(0, go.GetComponent<RectTransform>().rect.height * 1.5f, 0);
		if (gameObject.name.Contains ("horse")) {
			go.GetComponent<UIGetSome> ().setTxt (0);
		}
        else if (gameObject.name.Contains("cao"))
        {
            go.GetComponent<UIGetSome>().setTxt(1);

            if (!gameObject.GetComponent<RawImage>().texture.name.Equals("transparent"))
            {
                Destroy(go);
            }

        }
        else if (gameObject.name.Contains("tree"))
            go.GetComponent<UIGetSome>().setTxt(2);
//		else if (gameObject.name.Contains ("Empty"))
//			go.GetComponent<UIGetSome> ().setTxt (3);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

}
