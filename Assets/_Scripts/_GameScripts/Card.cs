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

    public virtual void Use(DiceCast diceCast, PocketHandler pocketHandler)
    {
        Debug.Log(cardName + " used!");
        if (cardType == CardType.SerpentStare)
        {
            diceCast.snakeEyesActive = true;
        }
        if (cardType == CardType.FinalChance)
        {
            diceCast.finalChance = true;
        }
        if (cardType == CardType.DoubleRainbow)
        {
            diceCast.doubleRainbow = true;
        }
        if (cardType == CardType.CouncilOf5)
        {
            diceCast.councilOfFive = true;
        }
        if (cardType == CardType.ScoringBuff)
        {
            //scorebuff
        }
        if (cardType == CardType.ExtraLife)
        {
            // logic here
        }
        if (cardType == CardType.Duo2)
        {
            diceCast.duoTwoModifier = true;
        }
        if (cardType == CardType.Duo3)
        {
            diceCast.duoThreeModifier = true;
        }
        if (cardType == CardType.Duo4)
        {
            diceCast.duoFourModifier = true;
        }
        if (cardType == CardType.Duo6)
        {
            diceCast.duoSixModifier = true;
        }
        if (cardType == CardType.EvenFlow)
        {
            // logic here
        }
    }
}

public enum CardType
{
    SerpentStare,
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
