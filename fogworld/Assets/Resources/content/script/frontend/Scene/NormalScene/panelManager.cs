using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    private bool flag = false;
    private GameObject panel;
    private string oldtype = "";
    void Start()
    {
    }
    void Update()
    {
    }
    public void btClick(string type)
    {
        if (flag == false)
        {
            panel = Resources.Load("content/prefabs/menu/" + type+"panel") as GameObject;
            panel = GameObject.Instantiate(panel);
            panel.transform.parent = canvas.transform;
            panel.transform.localPosition = new Vector3(173.0f, 23, -5);
            flag = true;
            oldtype = type;
        }
        else if (oldtype == type)
        {
            GameObject.Destroy(panel);
            flag = false;
        }
        else
        {
            GameObject.Destroy(panel);
            panel = Resources.Load("content/prefabs/menu/" + type + "panel") as GameObject;
            panel = GameObject.Instantiate(panel);
            panel.transform.parent = canvas.transform;
            panel.transform.localPosition = new Vector3(173.0f, 23, -5);
            oldtype = type;
        }
    }
}
