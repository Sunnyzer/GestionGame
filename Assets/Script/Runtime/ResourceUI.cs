using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] Image resourceImage = null;
    [SerializeField] TextMeshProUGUI resourceAmount = null;
    public void Init(Resource _resource)
    {
        resourceImage.sprite = ((ResourceData)_resource).Sprite;
        resourceAmount.text = _resource.Amount.ToString();
    }
}
