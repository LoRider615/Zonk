using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public string description;
    public CardType cardType;

    public virtual void Use(DiceCast diceCast)
    {
        Debug.Log(cardName + " used!");
        if (cardType == CardType.Duo2)
        {
            diceCast.duoTwoModifier = true;
        }
    }
}

public enum CardType
{
    FinalChance,
    DoubleRainbow,
    CouncilOf5,
    ScoringBuff,
    ExtraLife,
    Duo2,
    Duo3,
    Duo4,
    Duo6,
    EvenFlow
}
