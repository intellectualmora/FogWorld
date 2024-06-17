using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class observe : MonoBehaviour
{
    // Start is called before the first frame update
    public Button click;
    public talker talker;
    public textbox textbox;
    void Start()
    {
        talker = GameObject.FindGameObjectWithTag("talker").GetComponent<talker>();
        textbox = GameObject.FindGameObjectWithTag("textbox").GetComponentInChildren<textbox>(true);
        click.onClick.AddListener(btClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btClick()
    {
        talker.DestroyPanel();
        textbox.Show();
    }
}
