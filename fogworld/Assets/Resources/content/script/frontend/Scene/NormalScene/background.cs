using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class background : MonoBehaviour
{
    // Start is called before the first frame update
    public talker talker;
    public Button click;
    void Start()
    {
        click.onClick.AddListener(new UnityAction(btClick));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btClick()
    {
        talker.DestroyPanel();
    }
}
