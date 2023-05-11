using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour,IInteract
{
    [SerializeField] Farmer currentFarmer = null;
    [SerializeField] BoxCollider boxCollider = null;
    BuildingData buildingData;
    public BuildingData BuildingData => buildingData;
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
    
    private void Init(BuildingData _buildingData)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Transform _mesh = Instantiate(_buildingData.Mesh, transform.position, Quaternion.identity);
        _mesh.SetParent(transform);
        Collider _collider = _mesh.GetComponent<Collider>();
        boxCollider.size = _collider.bounds.extents * 2;
        boxCollider.center = new Vector3(0, _collider.bounds.center.y, 0);
        Destroy(_collider);
    }
    
    public void RemoveFarmer(Farmer _currentFarmer)
    {
        if (!currentFarmer) return;
        if (currentFarmer == _currentFarmer)
            currentFarmer = null;
    }
    public void ChangeFarmer(Farmer _currentFarmer)
    {
        if (currentFarmer)
            currentFarmer = _currentFarmer;
        else
            AddFarmer(_currentFarmer);
    }
    public bool AddFarmer(Farmer _currentFarmer)
    {
        bool _farmer = currentFarmer;
        if(!_farmer)
            currentFarmer = _currentFarmer;
        return !_farmer;
    }

    public void SetBuildingData(BuildingData _buildingData)
    {
        buildingData = _buildingData;
        Init(buildingData);
    }
    
    private void Upgrade()
    {
        BuildingData _buildingData = buildingData.BuildingUpgrade;
        if(_buildingData != null)
        {
            Init(_buildingData);
            buildingData = _buildingData;
            DisplayBuildingUI();
        }
    }
    public void BuyUpgrade()
    {
        if (buildingData.BuildingUpgrade != null && PlayerInventory.Instance.UseResources(buildingData.ResourcesToUpgrade))
            Upgrade();
        else
            Debug.Log("Can t Upgrade");
    }

    private void DisplayBuildingUI()
    {
        BuildingUI _buildingUIPrefab = DataTableManager.Instance.BuildingDataTable.BuildingUI;
        BuildingUI _buildingUI = Instantiate(_buildingUIPrefab);
        _buildingUI.Init(this);
        UIManager.Instance.InteractWindow.DisplayInteractUI(_buildingUI);
    }
    public void Interaction()
    {
        DisplayBuildingUI();
    }
}
