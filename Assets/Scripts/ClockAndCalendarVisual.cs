using HoloBot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockAndCalendarVisual : MonoBehaviour
{
    public Text date;
    public Text time;

    private BotService m_BotService;
    private CanvasGroup m_CanvasGroup;
    private bool m_Visible;

    // Start is called before the first frame update
    void Start()
    {
        m_BotService = GetComponent<BotService>();
        m_BotService.BotResponseEvent += OnBotResponse;
        m_CanvasGroup = GetComponent<CanvasGroup>();
        m_Visible = false;
    }

    private void OnBotResponse(object sender, BotResponseEventArgs e)
    {
        if (e.Text == "Foo")
        {
            m_Visible = true;
        }
        else
        {
            m_Visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Visible)
        {
            m_CanvasGroup.alpha = 1;
            m_CanvasGroup.interactable = true;
        }
        else
        {
            m_CanvasGroup.alpha = 0;
            m_CanvasGroup.interactable = false;
        }

        var now = DateTime.UtcNow;

        date.text = now.ToString("MMMM dd, yyyy");
        time.text = now.ToString("H:mm:ss");
    }
}
