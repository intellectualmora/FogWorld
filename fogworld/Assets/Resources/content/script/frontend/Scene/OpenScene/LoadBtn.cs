using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Backend;
public class LoadBtn : MonoBehaviour
{
    public Button loadBtn;
    public AudioSource audio;
    public string sceneName;
    // Use this for initialization
    void Start()
    {
    }
    void Awake()
    {
        loadBtn.onClick.AddListener(btClick);//添加监听器用于监听按键事件，并回调函数
    }
    // Update is called once per frame
    void Update()
    {
    }
    void btClick()
    {
        audio.Play();
        Common.IsLoad = true;
        StartCoroutine(AudioPlayFinished(audio.clip.length));
    }

    private IEnumerator AudioPlayFinished(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);//跳转到指定的Level，也就是第一步中的右侧标号
    }
}