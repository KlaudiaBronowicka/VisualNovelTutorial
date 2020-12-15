using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData
{
    public CharacterPosition Position { get; set; }
    public CharacterName Name { get; set; }
    public CharacterMood Mood { get; set; }
}