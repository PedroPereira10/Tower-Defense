using UnityEngine;

[CreateAssetMenu(fileName = "TowerInfo", menuName = "Tower/Info", order = 1)]
public class TowerInfo : ScriptableObject
{
    public string towerName;
    [TextArea] public string description;
    public float damage;
    public float range;
    public int cost;
}
