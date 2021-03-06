﻿using System;
using UnityEngine;

[Serializable]
public class CustomizationItem
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _preview;

    public string Name => _name;
    public Sprite Preview => _preview;
}