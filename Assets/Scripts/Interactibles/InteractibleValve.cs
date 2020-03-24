﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleValve : MonoBehaviour, IInteractible
{
    public ValveColor _valveColor;

    public bool Interact(ACustomItem item)
    {
        CustomPotion potion = (CustomPotion)item;

        // Mix potion only if it already has a slot assigned or if a slot is assigned successfully
        if (!potion.HasSlotAssigned)
        {
            if (SlotManager.Instance.AssignFirstSlotAvailable(item))
                return MixPotion(potion);
        }
        else
            return MixPotion(potion);
        return false;
    }

    /// <summary>
    /// Mix color and change 'potion' color
    /// </summary>
    /// <param name="potion"></param>
    private bool MixPotion(CustomPotion potion)
    {
        potion.Color = MixPotionColor.MixPotion(potion.Color, _valveColor);
        return potion.ResetPositionToSlot();
    }
}
