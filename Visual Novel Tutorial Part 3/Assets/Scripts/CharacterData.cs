using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class CharacterData
{
    public CharacterPosition Position { get; set; }
    public CharacterName Name { get; set; }
    public CharacterMood Mood { get; set; }

    public bool IsShowing { get; set; }

    public CharacterData(CharacterName name, CharacterPosition position, CharacterMood mood)
    {
        Name = name;
        Position = position;
        Mood = mood;
    }

    public static CharacterData Create(string characterName, string characterPosition, string characterMood)
    {
        if (!Enum.TryParse(characterName, out CharacterName name))
        {
            Debug.Log($"Failed to parse character name to enum: {characterName}");
            return null;
        }

        if (!Enum.TryParse(characterPosition, out CharacterPosition position))
        {
            Debug.Log($"Failed to parse character position to enum: {characterPosition}");
            return null;
        }

        
        if (!Enum.TryParse(characterMood, out CharacterMood mood))
        {
            Debug.Log($"Failed to parse character mood to enum: {characterMood}");
            return null;
        }
        
        return new CharacterData(name, position, mood);
    }
}
public enum CharacterName { Alice, Me };
public enum CharacterPosition { Center, Left, Right };
public enum CharacterMood { Fine, Happy, Sad, SadHappy, Upset, Blush, Crying, Serious, Surprised, Uncomfortable };

*/