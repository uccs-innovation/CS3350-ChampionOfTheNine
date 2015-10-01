﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Abstract parent script that controls AI characters
/// </summary>
public abstract class AIScript : CharacterControllerScript
{
    #region Fields

    protected float targetRange;
    protected GameObject target;
    [SerializeField]Transform lineStart;
    [SerializeField]Transform lineEnd;

    #endregion

    #region Properties

    /// <summary>
    /// Returns the tag of this character's target
    /// </summary>
    public override string TargetTag
    { get { return Constants.PLAYER_TAG; } }

    #endregion

    #region Public Methods

    /// <summary>
    /// Handles the character dying
    /// </summary>
    public override void Death()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Protected Methods

    /// <summary>
    /// Start is called once on object creation
    /// </summary>
    protected override void Start()
    {
        base.Start();
        character.simple = true;
        InvokeRepeating("FindTarget", Constants.AI_SCAN_DELAY, Constants.AI_SCAN_DELAY);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    protected override void Update()
    {
        // Finds a new target if it doesn't have one
        if (target == null)
        { FindTarget(); }
        else
        {
            if (Vector2.Distance(transform.position, target.transform.position) > targetRange)
            {
                // Out of range, move towards target
                if (Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << Constants.GROUND_LAYER) && character.Grounded)
                { jumpAbility(); }
                float direction = Mathf.Sign(target.transform.position.x - transform.position.x);
                movement(direction);
                armDirection(90 - (direction * 135));
            }
            else
            {
                // In range, attack
                movement(0);
                Attack();
            }
        }
    }

    /// <summary>
    /// Attacks the target
    /// </summary>
    protected abstract void Attack();

    /// <summary>
    /// Finds the nearest target, if any
    /// </summary>
    protected void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag);
        float nearestDistanceSqr = Mathf.Infinity;
        foreach (GameObject obj in targets) 
        {
            float distanceSqr = (obj.transform.position - transform.position).sqrMagnitude;
            if (distanceSqr < nearestDistanceSqr) 
            {
                target = obj;
                nearestDistanceSqr = distanceSqr;
            }
        }
    }

    #endregion
}
