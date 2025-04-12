using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIButton : MonoBehaviour
{
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;

    [SerializeField] private GameObject _tower1Prefab;
    [SerializeField] private GameObject _tower2Prefab;
    [SerializeField] private GameObject _tower3Prefab;

    [SerializeField] private int _tower1Price = 100;
    [SerializeField] private int _tower2Price = 150;
    [SerializeField] private int _tower3Price = 200;

    [SerializeField] private TowerPlacementSystem _placementSystem;
    [SerializeField] private ResourceManager _resourceManager;

    private void Start()
    {
        _button1.onClick.AddListener(() => TryPlaceTower(_tower1Prefab, _tower1Price));
        _button2.onClick.AddListener(() => TryPlaceTower(_tower2Prefab, _tower2Price));
        _button3.onClick.AddListener(() => TryPlaceTower(_tower3Prefab, _tower3Price));
    }

    private void TryPlaceTower(GameObject towerPrefab, int price)
    {
        if (_resourceManager.CurrentResources >= price)
        {
            _placementSystem.StartPlacingTower(towerPrefab, price);
        }
        else
        {
            Debug.Log("Not enogh money!");
        }
    }
}

