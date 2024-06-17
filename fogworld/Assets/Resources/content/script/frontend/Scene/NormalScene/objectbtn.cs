using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class objectbtn : MonoBehaviour
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
        RemoveAllChildren(content);
        for (int i = 0; i < 3; i++)
        {
            
            panel = Resources.Load("content/prefabs/scrollbtn/object") as GameObject;
            panel = GameObject.Instantiate(panel);
            panel.transform.parent = content.transform;
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
