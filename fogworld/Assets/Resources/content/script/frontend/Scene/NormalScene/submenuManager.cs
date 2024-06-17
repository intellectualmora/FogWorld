using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class submenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    private GameObject submenu;
    public GameObject menu;
    private GameObject panel;
    public string type;
    void Start()
    {
        btn.onClick.AddListener(delegate { btnClick(type);});

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void btnClick(string type)
    {
        for (int i = 0; i < menu.transform.childCount; i++)
        {
            if (menu.transform.GetChild(i).name == "submenu")
            {
                GameObject.Destroy(menu.transform.GetChild(i).gameObject);
                break;
            }
        }
        submenu = new GameObject("submenu");
        submenu.transform.parent = menu.transform;
        panel = Resources.Load("content/prefabs/actions/"+type) as GameObject;
        panel = GameObject.Instantiate(panel);
        panel.transform.parent = menu.transform.parent.transform;
        panel.transform.position = new Vector3(menu.transform.position.x-200, menu.transform.position.y,
            panel.transform.position.z);
        panel.transform.parent = submenu.transform;

    }
}
