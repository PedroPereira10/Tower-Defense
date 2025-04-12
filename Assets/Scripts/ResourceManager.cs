using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int _startingResources = 500;
    private int _currentResources;

    public int CurrentResources => _currentResources;

    private void Start()
    {
        _currentResources = _startingResources;
    }

    public bool Spend(int amount)
    {
        if (_currentResources >= amount)
        {
            _currentResources -= amount;
            return true;
        }

        return false;
    }

    public void Add(int amount)
    {
        _currentResources += amount;
    }
}
