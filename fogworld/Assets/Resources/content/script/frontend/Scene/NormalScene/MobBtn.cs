using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Backend;
using TMPro;

public class MobBtn : MonoBehaviour
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
        int mobId = Int32.Parse(this.transform.name);
        GameObject[] talkers = GameObject.FindGameObjectsWithTag("talker");
        if (talkers.Length != 0)
        {
            talker t = talkers[0].GetComponent<talker>();
            t.DestroyPanel();
            GameObject.Destroy(talkers[0]);
        }
        Mob mob = (Mob)reg.GetObj(typeof(Mob), mobId);
        GameObject talker = Resources.Load("content/prefabs/talker0") as GameObject;
        talker = GameObject.Instantiate(talker);
        talker.transform.parent = GameObject.FindGameObjectWithTag("talkerwrap").transform;
        SpriteRenderer spr = talker.GetComponent<SpriteRenderer>();
        Texture2D texture2d = (Texture2D)Resources.Load((mob.ImgPath+"_"+mob.Apparel).Trim());
        Sprite sp = Sprite.Create(texture2d, spr.sprite.textureRect, new Vector2(0.5f, 0.5f)); //注意居中显示采用0.5f值
        spr.sprite = sp;
    }
}
