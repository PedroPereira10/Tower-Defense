using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int _startingResources = 500;
    [SerializeField] private TextMeshProUGUI _goldText;

    private int _currentResources;

    public int CurrentResources => _currentResources;

    private void Start()
    {
        _currentResources = _startingResources;
        UpdateGoldUI();

    }
    private void UpdateGoldUI()
    {
        _goldText.text = "" + _currentResources;
    }

    public bool Spend(int amount)
    {
        if (_currentResources >= amount)
        {
            _currentResources -= amount;
            UpdateGoldUI(); 
            return true;
        }

        return false;
    }


    public void Add(int amount)
    {
        _currentResources += amount;
        UpdateGoldUI();

    }

    

}
