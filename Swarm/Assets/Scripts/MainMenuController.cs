using UnityEngine;
using System.Collections;

// This is a static controller that loads the game scene based on the environment (server, client, offline)
public static class MainMenuController{

  // Start an hosted match
  public static void StartServer(int Port, string PlayerName){
    PlayerSettings.Port = Port;
    PlayerSettings.PlayerName = PlayerName;
    PlayerSettings.Env = Envs.SERVER;
    Debug.Log("Starting a server");
    Network.InitializeServer (ApplicationSettings.DEFAULT_MAX_PLAYERS, Port, false);
  }

  // Connect to the server and join a match
  public static void ConnectToServer(string Host, int Port, string PlayerName){
    PlayerSettings.Host = Host;
    PlayerSettings.PlayerName = PlayerName;
    PlayerSettings.Port = Port;
    PlayerSettings.Env = Envs.CLIENT;
    Debug.Log ("Connecting to " + Host + ":" + Port);
    Network.Connect (Host, Port);
  }

  // Start a single player match
  public static void StartSinglePlayerMatch(string PlayerName){
    Debug.Log ("Starting single player match - loading " + ApplicationSettings.GAME_SCENE);
    PlayerSettings.PlayerName = PlayerName;
    PlayerSettings.Env = Envs.OFFLINE;
    Application.LoadLevel (ApplicationSettings.GAME_SCENE);
    Debug.Log ("Scene loaded");
  }
}