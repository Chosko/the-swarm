using UnityEngine;
using System.Collections;

/// <summary>
/// Main menu GUI.
/// </summary>
public class MainNetworkMenu : MonoBehaviour
{
	/// <summary>
	/// The current GUI State
	/// </summary>
	public GUIState currentGUIState = GUIState.MAIN_PANEL;
	
	//Server configuration vars
	private int GUIPort, GUIMaxPlayers;
	private string GUIServerHost, GUIServerName, GUIPlayerName;
	private bool GUIDedicatedServer;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		Debug.Log ("Starting Main Menu GUI");
		
		// GUI variables initialization 
		GUIServerHost = PlayerSettings.Host;
		GUIPlayerName = PlayerSettings.PlayerName;
		GUIPort = PlayerSettings.Port;
		GUIServerName = AppSettings.DEFAULT_SERVER_NAME;
		GUIMaxPlayers = AppSettings.DEFAULT_MAX_PLAYERS;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() { }
	
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI ()
	{
		// calls the correct GUI Panel base on state
		switch (currentGUIState) {
		case GUIState.MAIN_PANEL:
			displayMainPanel ();
			break;
		case GUIState.CLIENT_PANEL:
			displayClientSettings ();
			break;
		case GUIState.SERVER_PANEL:
			displayServerSettings ();
			break;
		}
	}
	
	//////////////////////////////////////////////////////////////////
	// DISPLAY MENU FUNCTIONS
	//////////////////////////////////////////////////////////////////
	
	/// <summary>
	/// Displaies the server settings.
	/// Render the menu controls for starting a dedicated server
	/// </summary>
	private void displayServerSettings ()
	{
		
		//Port Area
		GUILayout.BeginArea (new Rect (10, 10, 100, 50));
		GUILayout.Label ("Port: ");
		GUIPort = int.Parse (GUI.TextField (new Rect (0, 20, 50, 21), GUIPort.ToString ()));
		GUILayout.EndArea ();
		
		//Max Players
		GUILayout.BeginArea (new Rect (65, 10, 100, 50));
		GUILayout.Label ("Max. Players: ");
		GUIMaxPlayers = int.Parse (GUI.TextField (new Rect (0, 20, 50, 21), GUIMaxPlayers.ToString ()));
		GUILayout.EndArea ();
		
		//Game Name
		GUILayout.BeginArea (new Rect (155, 10, 200, 50));
		GUILayout.Label ("Game Name: ");
		GUIServerName = GUI.TextField (new Rect (0, 20, 150, 21), GUIServerName);
		GUILayout.EndArea ();
		
		//Dedicated server
		GUILayout.BeginArea(new Rect(330, 10, 200, 50));
		GUILayout.Label("Dedicated server");
		GUIDedicatedServer = GUI.Toggle(new Rect(0, 20, 10, 10), GUIDedicatedServer, "");
		GUILayout.EndArea();
		
		//start a server
		if (GUI.Button (new Rect (10, 60, 180, 25), "Start a Server")) {
      MainMenuController.StartServer(GUIPort, "Server Player");
		}
		
		//return to the main menu
		if (GUI.Button (new Rect (10, 90, 100, 25), "Main Menu")) {
			currentGUIState = GUIState.MAIN_PANEL;
		}
	}
	
	/// <summary>
	/// Displaies the client settings.
	/// </summary>
	private void displayClientSettings ()
	{
		GUILayout.BeginArea (new Rect (10, 10, 100, 50));
		GUILayout.Label ("Direct connect");
		GUILayout.EndArea ();
		
		GUILayout.BeginArea (new Rect (10, 30, 100, 50));
		GUILayout.Label ("IP or Host name: ");
		GUIServerHost = GUI.TextField (new Rect (0, 20, 80, 21), GUIServerHost);
		GUILayout.EndArea ();
		
		GUILayout.BeginArea (new Rect (120, 30, 100, 50));
		GUILayout.Label ("Game Port: ");
		GUIPort = int.Parse (GUI.TextField (new Rect (0, 20, 80, 21), GUIPort.ToString ()));
		GUILayout.EndArea ();
		
		GUILayout.BeginArea (new Rect (230, 30, 100, 50));
		GUILayout.Label ("Player Name: ");
		GUIPlayerName = GUI.TextField (new Rect (0, 20, 80, 21), GUIPlayerName);
		GUILayout.EndArea ();
		
		// connection to server
		if (GUI.Button (new Rect (10, 80, 100, 24), "Connect")) {
			MainMenuController.ConnectToServer(GUIServerHost, GUIPort, GUIPlayerName);
		}
		
		//return to the main menu
		if (GUI.Button (new Rect (10, 110, 100, 24), "Main Menu")) {
			currentGUIState = GUIState.MAIN_PANEL;
		}
	}
	
	/// <summary>
	/// Displays the main panel.
	/// </summary>
	private void displayMainPanel()
	{
		if (GUI.Button(new Rect(210, 10, 150, 25), "Single Player"))
		{
			MainMenuController.StartSinglePlayerMatch("Player");
		}
		
		if (GUI.Button(new Rect(210, 50, 150, 25), "Start a Server"))
		{
			currentGUIState = GUIState.SERVER_PANEL;
		}
		
		if (GUI.Button(new Rect(210, 90, 150, 25), "Connect to a Server ..."))
		{
			currentGUIState = GUIState.CLIENT_PANEL;
		}
		
		if (GUI.Button(new Rect(210, 130, 150, 25), "Exit"))
		{
			Application.Quit();
		}
	}
}
