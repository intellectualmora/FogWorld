using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Backend;
using TMPro;

public class LocationBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(btnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void btnClick()
    {
        Registry reg = Registry.GetRegistry();
        int roomId = Int32.Parse(this.transform.name);
        Room room = (Room)reg.GetObj(typeof(Room), roomId);
        GameObject background = GameObject.FindGameObjectWithTag("background");
        GameObject siteText = GameObject.FindGameObjectWithTag("sitetext");
        siteText.GetComponent<TextMeshProUGUI>().text = reg.GetLocationName(roomId);
        SpriteRenderer spr = background.GetComponent<SpriteRenderer>();
        Texture2D texture2d = (Texture2D)Resources.Load(room.ImgPath.Trim());
        Sprite sp = Sprite.Create(texture2d, spr.sprite.textureRect, new Vector2(0.5f, 0.5f));//注意居中显示采用0.5f值
        spr.sprite = sp;
        reg.UpdataCurrentRoomId(roomId);
        GameObject[] talkers = GameObject.FindGameObjectsWithTag("talker");
        foreach (var talker in talkers)
        {
            talker t = talker.GetComponent<talker>();
            t.DestroyPanel();
            GameObject.Destroy(talker);
        }
        Button btn = GameObject.FindGameObjectWithTag("movebtn").GetComponent<Button>();
        btn.onClick.Invoke();
    }
}
