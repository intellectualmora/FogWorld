using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelbtn : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    public panelManager pm;
    public string type;
    void Start()
    {
        
    }
    void Awake()
    {
        btn.onClick.AddListener(delegate { pm.btClick(type);});//添加监听器用于监听按键事件，并回调函数
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
