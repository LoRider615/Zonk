using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public string description;
    //public CardEffectType effectType; // different effect types

    public virtual void Use()
    {
        Debug.Log(cardName + " used!");
    }
}

//public enum CardEffectType
//{
//    TimeWarpTonic,
//    ChaosSwap,
//    DictateFate,
//    DimensionalRift,
//    ShadowWizardMoney,
//}
