using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HideImage : MonoBehaviour
{
    public GameObject imageToHide; // ���������ص�ͼƬ��ק�����������
    public float second;
    void Start()
    {
        StartCoroutine(HideAfterSeconds(second, imageToHide)); // ��1�������ͼƬ
    }

    IEnumerator HideAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(1f);//�ȴ�0.1���ټ�������ѭ��
        for (float f = 1f; f >= 0; f -= 0.05f)//����İ�����ֵ��͸���ȣ���1��ʼÿ�μ���0.1
        {
            Color c = imageToHide.GetComponent<Image>().color;//��ȡ��������е���ɫ
            c.a = f;//�ı���ɫ�еİ�����ֵ
            imageToHide.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.05f);//�ȴ�0.1���ټ�������ѭ��
        }
        obj.SetActive(false); // ����ͼƬ
    }
}