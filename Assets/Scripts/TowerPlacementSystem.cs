using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacementSystem : MonoBehaviour
{
    [SerializeField] private LayerMask _placeableLayer;
    [SerializeField] private LayerMask _unbuildableLayer;
    [SerializeField] private GameObject _previewMaterialPrefab;

    private GameObject _currentPreview;
    private GameObject _towerToPlace;
    private int _towerCost;
    private ResourceManager _resourceManager;

    private bool _isPlacing = false;

    public void StartPlacingTower(GameObject towerPrefab, int cost)
    {
        CancelPlacing(); 
        _towerToPlace = towerPrefab;
        _towerCost = cost;

        _currentPreview = Instantiate(towerPrefab);
        _currentPreview.GetComponent<Collider>().enabled = false;
        SetLayerRecursively(_currentPreview, LayerMask.NameToLayer("Ignore Raycast"));

        
        foreach (Renderer r in _currentPreview.GetComponentsInChildren<Renderer>())
        {
            r.material.color = new Color(1f, 1f, 1f, 0.5f);
        }

        _isPlacing = true;
    }

    private void Start()
    {
        _resourceManager = FindObjectOfType<ResourceManager>();
    }

    private void Update()
    {
        if (!_isPlacing || _currentPreview == null)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, _placeableLayer))
        {
            _currentPreview.transform.position = hit.point;

            bool canPlace = !Physics.CheckSphere(hit.point, 0.5f, _unbuildableLayer);
            Color previewColor = canPlace ? Color.green : Color.red;
            previewColor.a = 0.5f;

            foreach (Renderer r in _currentPreview.GetComponentsInChildren<Renderer>())
            {
                r.material.color = previewColor;
            }

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceTower(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            CancelPlacing();
        }
    }

    private void PlaceTower(Vector3 position)
    {
        GameObject tower = Instantiate(_towerToPlace, position, Quaternion.identity);

        // Ativar script depois de construir
        MonoBehaviour[] scripts = tower.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            script.enabled = true;
        }

        // Coloca na layer unbuildable
        tower.layer = LayerMask.NameToLayer("Unbuildable");
        foreach (Transform child in tower.transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Unbuildable");
        }

        _resourceManager.Spend(_towerCost);
        CancelPlacing();
    }



    private void CancelPlacing()
    {
        if (_currentPreview != null)
        {
            Destroy(_currentPreview);
        }

        _isPlacing = false;
        _towerToPlace = null;
    }

    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}

