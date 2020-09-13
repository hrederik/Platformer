using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemScenePresenter : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Image _preview;
    [SerializeField] private Button _button;

    public event UnityAction Choosen
    {
        add => _button.onClick.AddListener(value);
        remove => _button.onClick.RemoveListener(value);
    }

    public void Initialize(CustomizationItem customizationItem)
    {
        _name.text = customizationItem.Name;
        _preview.sprite = customizationItem.Preview;
    }
}