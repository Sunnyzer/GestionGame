using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackManager : Singleton<FeedbackManager>
{
    [SerializeField] TextMeshProUGUI textFeedback = null;
    [SerializeField] Transform resourcesNeededFeedback = null;
    public void ClearResourcesFeedback()
    {
        for (int i = 0; i < resourcesNeededFeedback.childCount; i++)
            Destroy(resourcesNeededFeedback.GetChild(i).gameObject);
    }
    public void DisplayText(string _text)
    {
        textFeedback.text = _text;
        ClearResourcesFeedback();
    }
    public void DisplayTextDelay(string _text, float _duration)
    {
        CancelInvoke();
        DisplayText(_text);
        Invoke(nameof(ClearFeedback), _duration);
    }
    public void DisplayResourcesNeeded(string _text, List<Resource> _resources)
    {
        DisplayText(_text);
        Resource.AddToUIGridResources(_resources, resourcesNeededFeedback);
    }
    public void DisplayResourcesNeededDelay(string _text, List<Resource> _resources, float _duration)
    {
        CancelInvoke();
        DisplayResourcesNeeded(_text, _resources);
        Invoke(nameof(ClearFeedback), _duration);
    }
    public void ClearFeedback()
    {
        ClearResourcesFeedback();
        textFeedback.text = "";
    }
}
