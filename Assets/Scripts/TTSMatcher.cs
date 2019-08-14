using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TTSMatcher : MonoBehaviour
{
    // Public fields in the Unity inspector
    [Tooltip("Text to match")]
    public string Text;

    [Tooltip("Event that fires when Text is contained in what TTS is about to say.")]
    public UnityEvent OnTTSMatch;

    private SpeechRecognition m_SpeechRecognition;

    // Start is called before the first frame update
    void Start()
    {
        var speechManager = GameObject.Find("SpeechManager");
        m_SpeechRecognition = speechManager.GetComponent<SpeechRecognition>();
        m_SpeechRecognition.TextResponseEvent += OnTextResponse;
    }

    private void OnTextResponse(object sender, TextResponseEventArgs e)
    {
        if (e.Text.Contains(Text))
        {
            OnTTSMatch.Invoke();
        }
    }
}
