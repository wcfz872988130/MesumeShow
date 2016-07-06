using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISkillTree_lz : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceManager._knowligen == 1)
            SkillEnableToClick(0);
        if (ResourceManager._knowzhitaoshu == 1)
            SkillEnableToClick(1);
        if (ResourceManager._knowfuhaoshu == 1)
            SkillEnableToClick(2);
    }

    public void ClickClose()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public void ClickSkill(GameObject go)
    {
        switch (go.name)
        {
            case "Skill0":
                break;
            case "Skill1":
                Debug.Log("Skill1");
                Object obj3 = Resources.Load("prefab/Slider");
                GameObject go3 = Instantiate(obj3) as GameObject;
                go3.transform.SetParent(ResourceManager._bg.transform, false);

                gameObject.SetActive(false);
                break;
            case "Skill2":
                Debug.Log("Skill2");

                Object obj4 = Resources.Load("prefab/Get");
                GameObject go4 = Instantiate(obj4) as GameObject;
                go4.GetComponent<UIHaveSome>().SetText("提示：给陶器刻上花纹");
                go4.transform.SetParent(ResourceManager._bg.transform, false);

                GameObject chinaTxt = GameObject.Find("Canvas/bg/ChinaTexture(Clone)");
                if (chinaTxt == null)
                {
                    Object obj5 = Resources.Load("prefab/ChinaTexture");
                    chinaTxt = Instantiate(obj5) as GameObject;
                    chinaTxt.transform.SetParent(ResourceManager._bg.transform, false);
                }

                GameObject china = GameObject.Find("Canvas/bg/China(Clone)");
                if (china == null)
                {
                    Object chinaObj = Resources.Load("prefab/China");
                    china = Instantiate(chinaObj) as GameObject;
                    china.transform.SetParent(ResourceManager._bg.transform, false);
                }
                else
                {
                    china.SetActive(true);
                }
                break;
            case "Skill3":
                Debug.Log("Skill 3");

                break;
            case "Skill4":
                break;
        }
    }
    public void SkillEnableToClick(int i)
    {
        Debug.Log("content/Skill" + i);
        transform.FindChild("content/Skill" + i).GetComponent<Button>().interactable = true;
        transform.FindChild("content/Skill" + i + "/Text").GetComponent<Text>().color = Color.white;

    }
}
