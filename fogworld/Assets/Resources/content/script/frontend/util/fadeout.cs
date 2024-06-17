using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HideImage : MonoBehaviour
{
    public GameObject imageToHide; // 将你想隐藏的图片拖拽到这个变量上
    public float second;
    void Start()
    {
        StartCoroutine(HideAfterSeconds(second, imageToHide)); // 在1秒后隐藏图片
    }

    IEnumerator HideAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(1f);//等待0.1秒再继续进行循环
        for (float f = 1f; f >= 0; f -= 0.05f)//物体的阿尔法值（透明度）从1开始每次减少0.1
        {
            Color c = imageToHide.GetComponent<Image>().color;//获取物体材质中的颜色
            c.a = f;//改变颜色中的阿尔法值
            imageToHide.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.05f);//等待0.1秒再继续进行循环
        }
        obj.SetActive(false); // 隐藏图片
    }
}