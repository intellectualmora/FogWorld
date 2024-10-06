using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class talker : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public UnityEvent rightClick;
    private GameObject panel;
    public GameObject canvas;
    public bool ispanel = false;
    public textbox textbox;
    public bool isdisable = false;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("canvas");
        textbox = GameObject.FindGameObjectWithTag("textbox").GetComponentInChildren<textbox>(includeInactive:true);
        rightClick.AddListener(new UnityAction(ButtonRightClick));
    }

    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable()
    {
        isdisable = true;
    }

    public void Acitavte()
    {
        isdisable = false;
    }
    public void DestroyPanel()
    {
        if (ispanel == true)
        {
            GameObject.Destroy(panel);
            ispanel = false;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right & isdisable== false)
        {
            if (GetComponent<PolygonCollider2D>().OverlapPoint(Input.mousePosition))
            {
                rightClick.Invoke();
            }
        }
        else
        {
            DestroyPanel();
        }
    }
    private void ButtonRightClick()
    {
        if (ispanel == false & textbox.isactivate == false){
            panel = Resources.Load("content/prefabs/actions/clickmenu0") as GameObject;
            panel = GameObject.Instantiate(panel);
            panel.transform.parent = canvas.transform;
            panel.transform.localPosition = new Vector3(Input.mousePosition.x - 1053, Input.mousePosition.y - 664,
                Input.mousePosition.z);
            ispanel = true;
        }
        else if (textbox.isactivate == false)
        {
            GameObject.Destroy(panel);
            panel = Resources.Load("content/prefabs/actions/clickmenu0") as GameObject;
            panel = GameObject.Instantiate(panel);
            panel.transform.parent = canvas.transform;
            panel.transform.localPosition = new Vector3(Input.mousePosition.x - 1053, Input.mousePosition.y - 664,
                Input.mousePosition.z);
            ispanel = true;
        }
    }
}
