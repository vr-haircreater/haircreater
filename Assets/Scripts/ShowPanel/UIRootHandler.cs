using UnityEngine;

public class UIRootHandler : MonoBehaviour
{
	GameObject panel = null;
    RectTransform rect;
    void Awake()
	{
		UIManager.Instance.m_CanvasRoot = gameObject;
	}

    private void Start()
    {
        panel = GameObject.Find("PanelLayout");
        rect = panel.GetComponent(typeof(RectTransform)) as RectTransform;
        rect.sizeDelta = new Vector2(400, 400);
    }
    private void Update()
    {
        if(PanelMain.icon == 1)
        {
            rect.sizeDelta = new Vector2(800, 400);
        }        
    }

}