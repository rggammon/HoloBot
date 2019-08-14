using HoloBot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoloCard : MonoBehaviour
{
    private CanvasGroup m_CanvasGroup;
    private Image m_Image;
    private RectTransform m_ImageTransform;
    private bool m_Visible;
    private int lastSpriteIndex = 0;
    private int spriteIndex = 0;
    private Sprite[] m_Sprites;

    // Start is called before the first frame update
    void Start()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
        m_Image = GetComponent<Image>();
        m_ImageTransform = GetComponent<RectTransform>();
        m_Sprites = new[]
        {
            Resources.Load<Sprite>("AirplaneDetails"),
            Resources.Load<Sprite>("Calendar"),
            Resources.Load<Sprite>("Diagnostics1"),
            Resources.Load<Sprite>("Diagnostics2"),
            Resources.Load<Sprite>("Diagnostics3"),
            Resources.Load<Sprite>("Diagnostics4"),
            Resources.Load<Sprite>("Diagnostics5"),
            Resources.Load<Sprite>("EngineDetails"),
            Resources.Load<Sprite>("JobLocation"),
            Resources.Load<Sprite>("SensorData"),
            Resources.Load<Sprite>("WorkItem"),
        };
        m_Visible = false;
    }

    public void OnTextResponse()
    {
        m_Visible = true;
        spriteIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Visible)
        {
            m_CanvasGroup.alpha = 1;
            m_CanvasGroup.interactable = true;
            if (spriteIndex != lastSpriteIndex)
            {
                m_Image.sprite = m_Sprites[spriteIndex];
                lastSpriteIndex = spriteIndex;

                //m_ImageTransform.position.Set(0, 0, 0);
                //m_ImageTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                //m_ImageTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
            }
        }
        else
        {
            m_CanvasGroup.alpha = 0;
            m_CanvasGroup.interactable = false;
        }
    }
}
