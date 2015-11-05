﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Singleton class that stores game data
/// </summary>
public class GameManager
{
    #region Fields

    static GameManager instance;
    Dictionary<string, Savegame> saves;
    
    CharacterType playerClass;
    
    #endregion

    #region Constructor

    /// <summary>
    /// Private constructor
    /// </summary>
    private GameManager()
    {
        // Loads the saved levels, if possible
        saves = Serializer.Deserialize<Dictionary<string, Savegame>>(Constants.SAVES_FILE);
        if (saves == null)
        {
            saves = new Dictionary<string, Savegame>();

            // Temporary for things to work
            CurrentSaveName = "temp";
            NewSavegame(CharacterType.Ranger);
            //Save();
        }
        else
        {
            CurrentSaveName = "temp";
        }
        //CurrentSaveName = "";
        Paused = false;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the singleton instance of the game manager
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            { instance = new GameManager(); }

            return instance;
        }
    }

    public CharacterType Type
    {
        get
        {
            return playerClass;
        }
        set
        {
            playerClass = value;
        }
    }

    /// <summary>
    /// Gets the saves dictionary
    /// </summary>
    public Dictionary<string, Savegame> Saves
    { get { return saves; } }

    /// <summary>
    /// Gets or sets the current save name
    /// </summary>
    public string CurrentSaveName
    { get; set; }

    public bool Paused
    { get; set; }

    #endregion

    #region Public Methods

    /// <summary>
    /// Deletes a savegame
    /// </summary>
    public void DeleteSave()
    {
        saves.Remove(CurrentSaveName);
        Save();
    }

    /// <summary>
    /// Creates a new savegame
    /// </summary>
    public void NewSavegame(CharacterType playerType)
    {
        if (!saves.ContainsKey(CurrentSaveName))
        { saves.Add(CurrentSaveName, new Savegame(playerType)); }
        else
        { saves[CurrentSaveName] = new Savegame(playerType); }
        Save();
    }

    /// <summary>
    /// Saves the current state of the savegames to a file
    /// </summary>
    public void Save()
    {
        Serializer.Serialize(Constants.SAVES_FILE, saves);
    }

    #endregion
}
