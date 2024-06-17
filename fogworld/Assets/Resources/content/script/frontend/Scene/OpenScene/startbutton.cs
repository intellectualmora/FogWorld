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
        startBtn.onClick.AddListener(btClick);//��Ӽ��������ڼ��������¼������ص�����
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
        SceneManager.LoadScene(sceneName);//��ת��ָ����Level��Ҳ���ǵ�һ���е��Ҳ���
    }
}