﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Script that controls an AI ranger character
/// </summary>
public class AIRangerScript : AIScript
{
    #region Protected Methods

    /// <summary>
    /// Start is called once on object creation
    /// </summary>
    protected override void Start()
    {
        base.Start();
        targetRange = Constants.RANGER_AI_RANGE;
    }

    /// <summary>
    /// Attacks the target
    /// </summary>
    protected override void Attack()
    {
        if (!character.GCDTimer.IsRunning)
        {
            // Sometimes does nothing
            int choice = Random.Range(0, Constants.RANGER_AI_SHOT_THRESHOLD);
            if (choice == 0)
            {
                armDirection(character.CalculateLaunchAngle(target.transform.position, Constants.BASIC_ARROW_SPEED) +
                    Random.Range(-Constants.RANGER_AI_ANGLE_RANGE, Constants.RANGER_AI_ANGLE_RANGE));
                mainAbility();
            }
            else
            { character.GCDTimer.Start(); }
        }
    }

    #endregion
}
