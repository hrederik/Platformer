using System;
using UnityEngine;

[Serializable]
public class PlayerCustomizationItem : CustomizationItem
{
    [SerializeField] private PlayerPrefab _playerPrefab;
    public PlayerPrefab PlayerPrefab => _playerPrefab;
}
