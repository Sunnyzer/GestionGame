using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] Building buildingPrefab = null;
    [SerializeField] LayerMask layerMask;
    BuildingData buildingData = null;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        bool _mouseDown = Input.GetMouseButtonDown(0);
        if (_mouseDown)
        {
            if(buildingData != null)
            {
                CreateBuilding();
                buildingData = null;
            }
            else
                Interact();
        }
    }
    bool Hit(out RaycastHit _raycastHit, LayerMask _layerMask)
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(_ray, out _raycastHit, 100, _layerMask);
    }
    void Interact()
    {
        if (!Hit(out RaycastHit _raycastHit, layerMask)) return;
        IInteract _interact = _raycastHit.collider.GetComponent<IInteract>();
        if (_interact == null) return;
        _interact.Interaction();
    }
    public void SelectItem(IInteract _interact)
    {
        
    }
    void CreateBuilding()
    {
        if (!Hit(out RaycastHit _raycastHit, layerMask)) return;
        Building building = Instantiate(buildingPrefab, _raycastHit.point, Quaternion.identity);
        building.SetBuildingData(buildingData);
    }
    public void SetBuildingData(BuildingData _buildingData)
    {
        buildingData = _buildingData;
    }
}
