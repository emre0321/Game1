using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnums{}

public enum InitiliazeType { None, OnAwake, OnStart }
public enum GameStates { None, MainMenu, Gameplay, LevelSuccess, LevelFail}

public enum ControllerTypes { None, GameController, LevelController}

public enum GridColoumnType { None, Horizontal, Vertical}

public enum GridElementState { None, Empty, Filled}
