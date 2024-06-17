using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startBtn;
    public AudioSource audio;
    public string sceneName;
    // Use this for initialization
    void Start()
    {
    }
    void Awake()
    {
        startBtn.onClick.AddListener(btClick);//添加监听器用于监听按键事件，并回调函数
    }
    // Update is called once per frame
    void Update()
    {
    }
    void btClick()
    {
        print("Button Click");
        audio.Play();
        StartCoroutine(AudioPlayFinished(audio.clip.length));
    }

    private IEnumerator AudioPlayFinished(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);//跳转到指定的Level，也就是第一步中的右侧标号
    }
}