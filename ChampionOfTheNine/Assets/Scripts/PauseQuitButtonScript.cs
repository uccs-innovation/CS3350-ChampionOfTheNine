﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Script that controls the pause quit button
/// </summary>
public class PauseQuitButtonScript : MonoBehaviour
{
    #region Fields

    [SerializeField]bool tutorial;

    #endregion

    #region Public Methods



    #endregion

    #region Protected Methods



    #endregion

    #region Properties



    #endregion

    #region Private Methods

    /// <summary>
    /// Start is called once on object creation
    /// </summary>
    private void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {

    }



    public void OnMouseDown()
    {
        if (tutorial)
        { Application.LoadLevel(Constants.CHAR_CREATE_SCENE); }
        else
        { Application.LoadLevel(Constants.MAIN_MENU_SCENE); }
    }

    #endregion
}
