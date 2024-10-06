using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class textbox : MonoBehaviour
{
    // Start is called before the first frame update\
    public Button textBtn;
    public TextMeshProUGUI text;
    public talker talker;
    public bool isactivate = false;
    private Queue<string> scripts = new Queue<string>();

    public void Start()
    {
    }

    private void ShowScript()
    {
        if (scripts.Count <= 0)
        {
            return;
        }

        text.TypeText(scripts.Dequeue(), onComplete: () => Debug.Log("TypeText Complete"));
    }

    void Awake()
    {
        talker = GameObject.FindGameObjectWithTag("talker").GetComponent<talker>();
        textBtn.onClick.AddListener(btClick);//添加监听器用于监听按键事件，并回调函数

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void btClick()
    {   
        talker.DestroyPanel();
        if (scripts.Count <= 0)
        {
            Hide();
        }
        if (text.IsSkippable())
        {
            // 跳过，直接显示全部文本
            text.SkipTypeText();
        }
        else
        {
            ShowScript();
        }
    }


    public void Show()
    {
        this.gameObject.SetActive(true);
        isactivate = true;
        talker.Disable();
        scripts.Enqueue("这是一只saber。");
        scripts.Enqueue("怎么看都是只Saber。");
        scripts.Enqueue("");
        ShowScript();
    }

    public void Hide()
    {
        isactivate = false;
        talker.Acitavte();
        this.gameObject.SetActive(false);
    }
}
