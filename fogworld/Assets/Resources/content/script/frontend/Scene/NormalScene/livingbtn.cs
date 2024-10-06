using System.Collections;
using System.Collections.Generic;
using Backend;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class livingbtn : MonoBehaviour
{
    // Start is called before the first frame update
    public Button mbtn;
    public GameObject content;
    private GameObject panel;
    void Start()
    {
        mbtn.onClick.AddListener(btnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void btnClick()
    {
        Registry reg = Registry.GetRegistry();
        RemoveAllChildren(content);
        List<int> surroundMobIdList = reg.GetSurroundMobIdList();
        foreach (var mobId in surroundMobIdList)
        {
            panel = Resources.Load("content/prefabs/scrollbtn/living") as GameObject;
            panel = GameObject.Instantiate(panel);
            panel.transform.parent = content.transform;
            TextMeshProUGUI text = panel.GetComponentInChildren<TextMeshProUGUI>();
            text.text = reg.GetObj(typeof(Mob),mobId).ObjName;
            panel.name = mobId.ToString();
        }
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(
            content.GetComponent<RectTransform>().sizeDelta.x,
            65*30);
    }


    public static void RemoveAllChildren(GameObject parent)
    {
        Transform transform;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            transform = parent.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }
    }
}
