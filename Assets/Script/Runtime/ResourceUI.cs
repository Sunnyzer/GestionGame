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
    public void Init(int _ID, int _amount)
    {
        resourceImage.sprite = DataTableManager.Instance.ResourcesDataTable.Datas[_ID].Sprite;
        resourceAmount.text = _amount.ToString();
    }
}
