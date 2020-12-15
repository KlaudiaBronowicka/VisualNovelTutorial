using Assets.Scripts;
using UnityEngine;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;

    public Sprite Fine;
    public Sprite Sad;
    public Sprite SadHappy;
    public Sprite Upset;
    public Sprite Serious;
    public Sprite Surprised;
    public Sprite Crying;
    public Sprite Uncomfortable;

    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood)
        {
            case CharacterMood.Fine:
                return Fine;
            case CharacterMood.Sad:
                return Sad ?? Fine;
            case CharacterMood.SadHappy:
                return SadHappy ?? Fine;
            case CharacterMood.Upset:
                return Upset ?? Fine;
            case CharacterMood.Serious:
                return Serious ?? Fine;
            case CharacterMood.Surprised:
                return Surprised ?? Fine;
            case CharacterMood.Crying:
                return Crying ?? Fine;
            case CharacterMood.Uncomfortable:
                return Uncomfortable ?? Fine;
            default:
                Debug.Log($"Didn't find Sprite for character: {Name}, mood: {mood}");
                return Fine;
        }
    }
}
