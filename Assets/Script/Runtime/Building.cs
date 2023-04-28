using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour,IInteract
{
    BuildingData buildingData;
    public BuildingData BuildingData => buildingData;
    Farmer currentFarmer = null;
    [SerializeField] BoxCollider boxCollider = null;
    float time = 0;

    private void Update()
    {
        if (!currentFarmer) return;
        time += Time.deltaTime;
        if(time >= buildingData.GenerationRate / currentFarmer.Stat.SpeedMultiplicateur)
        {
            GenerateResources();
            time = 0;
        }
    }
    void GenerateResources() 
    {
        for (int i = 0; i < buildingData.ResourceEarn.Count; i++)
        {
            Resource _resource = buildingData.ResourceEarn[i];
            PlayerInventory.Instance.AddResource(_resource.ID, Mathf.RoundToInt(_resource.Amount * currentFarmer.Stat.ProductionMultiplicateur));
        }
    }
    public bool AddFarmer(Farmer _currentFarmer)
    {
        bool _farmer = currentFarmer;
        if(!_farmer)
            currentFarmer = _currentFarmer;
        return !_farmer;
    }
    public void ChangeFarmer(Farmer _currentFarmer)
    {
        if (currentFarmer)
            currentFarmer = _currentFarmer;
        else
            AddFarmer(_currentFarmer);
    }
    private void Init(BuildingData _buildingData)
    {
        Transform _mesh = Instantiate(_buildingData.Mesh, transform.position, Quaternion.identity);
        _mesh.SetParent(transform);
        Collider _collider = _mesh.GetComponent<Collider>();
        boxCollider.size = _collider.bounds.extents * 2;
        boxCollider.center = new Vector3(0, _collider.bounds.center.y, 0);
        Destroy(_collider);
    }
    public void SetBuildingData(BuildingData _buildingData)
    {
        buildingData = _buildingData;
        Init(buildingData);
    }

    public void Interaction()
    {
        BuildingUI _buildingUIPrefab = DataTableManager.Instance.BuildingDataTable.BuildingUI;
        BuildingUI _buildingUI = Instantiate(_buildingUIPrefab);
        _buildingUI.Init(this);
        UIManager.Instance.DisplayInteractUI(_buildingUI);
    }
}
