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
    public GameObject gameObject;
    public Button mbtn;
    public GameObject background;
    public GameObject siteText;
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
        int roomId = Int32.Parse(gameObject.name);
        Room room = (Room)reg.GetObj(typeof(Room), roomId);
        background = GameObject.FindGameObjectWithTag("background");
        siteText = GameObject.FindGameObjectWithTag("sitetext");
        siteText.GetComponent<TextMeshProUGUI>().text = reg.GetLocationName(roomId);
        SpriteRenderer spr = background.GetComponent<SpriteRenderer>();
        Texture2D texture2d = (Texture2D)Resources.Load(room.ImgPath.Trim());//����Ϊ��ɫ����Ӣ�۽�ɫͼƬ
        Debug.Log(room.ImgPath.Trim());
        Sprite sp = Sprite.Create(texture2d, spr.sprite.textureRect, new Vector2(0.5f, 0.5f));//ע�������ʾ����0.5fֵ
        spr.sprite = sp;
        reg.UpdataCurrentRoomId(roomId);
        Button btn = GameObject.FindGameObjectWithTag("movebtn").GetComponent<Button>();
        btn.onClick.Invoke();
    }
}
