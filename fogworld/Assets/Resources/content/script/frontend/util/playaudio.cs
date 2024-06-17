using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playaudio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject audio; // 
    public float second;

    void Start()
    {
        StartCoroutine(PlayAfterSeconds(second, audio)); 

    }

    IEnumerator PlayAfterSeconds(float seconds, GameObject audio)
    {
        AudioSource c = audio.GetComponent<AudioSource>();
        c.PlayDelayed(seconds);
        yield return new WaitForSeconds(0.05f);
    }
}
