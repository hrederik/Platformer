using System;
using CodeBase.Game.Player;
using UnityEngine;

namespace CodeBase.Menu.Customization.Items
{
    [Serializable]
    public class PlayerCustomizationItem : CustomizationItem
    {
        [SerializeField] private PlayerPrefab _playerPrefab;
        public PlayerPrefab PlayerPrefab => _playerPrefab;
    }
}
