using UnityEngine;
using System.Collections;

/// <summary>
/// Static class in order to allow saving player settings (Using the Unity PlayerPref class)
/// </summary>
public static class PlayerSettings
{
	/// <summary>
	/// Sets or gets the Host
	/// </summary>
	public static string Host
	{
		set
		{
			PlayerPrefs.SetString(ApplicationSettings.PLAYERPREF_HOST_KEY, value);
			PlayerPrefs.Save();
		}
		
		get
		{
			return PlayerPrefs.GetString(ApplicationSettings.PLAYERPREF_HOST_KEY, ApplicationSettings.DEFAULT_SERVER_HOST);
		}
	}
	
	/// <summary>
	/// Sets or gets the current environment
	/// </summary>
	public static Envs Env
	{
		set
		{
			PlayerPrefs.SetString(ApplicationSettings.PLAYERPREF_ENV_KEY, value.ToString());
			PlayerPrefs.Save();
		}
		
		get
		{
			var env = PlayerPrefs.GetString(ApplicationSettings.PLAYERPREF_ENV_KEY, "OFFLINE");
			switch(env){
			case "SERVER":
				return Envs.SERVER;
			case "CLIENT":
				return Envs.CLIENT;
			case "OFFLINE":
				return Envs.OFFLINE;
			default:
				throw new System.Exception("Unknown env: " + env);
			}
		}
	}
	
	/// <summary>
	/// Sets or gets the Player Name
	/// </summary>
	public static string PlayerName
	{
		get
		{
			return PlayerPrefs.GetString(ApplicationSettings.PLAYERPREF_PLAYER_NAME_KEY, ApplicationSettings.DEFAULT_PLAYER_NAME + "_" + (int)(Random.value * 1000)); 
		}
		
		set
		{
			PlayerPrefs.SetString(ApplicationSettings.PLAYERPREF_PLAYER_NAME_KEY, value);
			PlayerPrefs.Save();
		}
	}
	
	/// <summary>
	/// Sets or get the port
	/// </summary>
	public static int Port
	{
		get
		{
			return PlayerPrefs.GetInt(ApplicationSettings.PLAYERPREF_PORT_KEY, ApplicationSettings.DEFAULT_SERVER_PORT);
		}
		
		set
		{
			PlayerPrefs.SetInt(ApplicationSettings.PLAYERPREF_PORT_KEY, value);
			PlayerPrefs.Save();
		}
	}
}