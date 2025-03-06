using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public string description;
    //public CardEffectType effectType; // Different effect types

    public virtual void Use()
    {
        Debug.Log(cardName + " used!");
    }
}

// don't know how this is going to work...
//public enum CardEffectType
//{
//    TimeWarpTonic,
//    ChaosSwap,
//    DictateFate,
//    DimensionalRift,
//    ShadowWizardMoney,
//}
