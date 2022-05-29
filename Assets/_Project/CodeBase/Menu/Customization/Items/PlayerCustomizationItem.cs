using System;
using CodeBase.Game.Player;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Menu.Customization.Items
{
    [Serializable]
    public class PlayerCustomizationItem : CustomizationItem
    {
        [SerializeField] private HeroStaticData _playerPrefab;
        public HeroStaticData PlayerPrefab => _playerPrefab;
    }
}
