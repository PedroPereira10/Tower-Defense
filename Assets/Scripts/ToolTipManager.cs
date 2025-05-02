using UnityEngine;
using TMPro;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    //[SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _rangeText;
    [SerializeField] private TextMeshProUGUI _costText;

    private void Start()
    {
        ToolTiper._onMouseOver += ShowInfo;
        _panel.SetActive(false);
    }

    private void ShowInfo(TowerInfo info)
    {
        if (info == null)
        {
            _panel.SetActive(false);
            return;
        }

        _panel.SetActive(true);
        //_nameText.text = info.towerName;
        _descText.text = info.description;
        _damageText.text = "Damage: " + info.damage;
        _rangeText.text = "Range: " + info.range;
        _costText.text = "Cost: " + info.cost;
    }

    private void OnDestroy()
    {
        ToolTiper._onMouseOver -= ShowInfo;
    }
}
