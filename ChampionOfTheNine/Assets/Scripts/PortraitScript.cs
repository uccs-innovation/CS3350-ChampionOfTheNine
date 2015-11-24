﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Script that controls the portrait
/// </summary>
public class PortraitScript : MonoBehaviour
{
    #region Fields

    [SerializeField]GameObject ranger;
    [SerializeField]GameObject mage;
    [SerializeField]GameObject warrior;

    #endregion

    #region Private Methods

    /// <summary>
    /// Start is called once on object creation
    /// </summary>
    private void Start()
    {
        switch (GameManager.Instance.Saves[GameManager.Instance.CurrentSaveName].PlayerType)
        {
            case CharacterType.Ranger:
                ranger.SetActive(true);
                break;
            case CharacterType.Mage:
                mage.SetActive(true);
                break;
            case CharacterType.Warrior:
                warrior.SetActive(true);
                break;
        }
    }

    #endregion
}
