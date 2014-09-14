using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : Singleton<AudioController> {
	
	public AudioClip introClip;
	
	public AudioClip guiH;
	public AudioClip guiM;
	public AudioClip guiL;
	
	public AudioClip shootClipA;
	public AudioClip shootClipB;
	public AudioClip shootClipC;
	public AudioClip shootClipD;
	
	public AudioClip explosionClip;

	public AudioClip runningMovesClip;

	public AudioClip selectingMovesClip;

	private AudioSource m_activeMusic;

	class ClipInfo
	{
		//ClipInfo used to maintain default audio source info
		public AudioSource source { get; set; }
		public float defaultVolume { get; set; }
	}

//	public class Init : MonoBehaviour {
		//testSound is public in order to set in the inspector
//		public AudioClip testSound; 
//		private AudioSource playingSound;

		private List<ClipInfo> m_activeAudio;
		
//		void Awake(){
//			m_activeAudio = new List<ClipInfo>();
			
//			Debug.Log("AudioManager Initializing");
//			try {
//				transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
//				transform.localPosition = new Vector3(0, 0, 0);
//			} catch {
//				Debug.Log("Unable to find main camera to put audiomanager");
//			}
//		}
//		void Start(){
			//playingSound = AudioController.Instance.PlayLoop (testSound, m_enemy.transform, 1);
//		}
		
//		void Update(){
//			if(Input.GetKeyDown(KeyCode.Space)){
				//AudioController.Instance.stopSound(playingSound);
//			}
//		}
//	}

	public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume) {
		//Create an empty game object
		GameObject soundLoc = new GameObject("Audio: " + clip.name);
		soundLoc.transform.position = soundOrigin;
		
		//Create the source
		AudioSource source = soundLoc.AddComponent<AudioSource>();
		setSource(ref source, clip, volume);
		source.Play();
		Destroy(soundLoc, clip.length);
		
		//Set the source as active - add to list
		m_activeAudio.Add(new ClipInfo{source = source, defaultVolume = volume});
		return source;
	}

	private void setSource(ref AudioSource source, AudioClip clip, float volume) {
		source.rolloffMode = AudioRolloffMode.Logarithmic;
		source.dopplerLevel = 0.2f;
		source.minDistance = 150;
		source.maxDistance = 1500;
		source.clip = clip;
		source.volume = volume;
	}

	//public AudioSource PlayLoop(AudioClip loop, Transform emitter, float volume) {
	public AudioSource PlayLoop(AudioClip loop, Vector3 soundOrigin, float volume) {
		//Create an empty game object
		//GameObject movingSoundLoc = new GameObject("Audio: " + loop.name);
		//movingSoundLoc.transform.position = emitter.position;
		//movingSoundLoc.transform.parent = emitter;
		GameObject soundLoc = new GameObject("Audio: " + loop.name);
		soundLoc.transform.position = soundOrigin;
		//Create the source
		AudioSource source = soundLoc.AddComponent<AudioSource>();
		setSource(ref source, loop, volume);
		source.loop = true;
		source.Play();
		//Set the source as active
		m_activeAudio.Add(new ClipInfo{source = source, defaultVolume = volume});
		return source;
	}

	public void stopSound(AudioSource toStop) {
		try {
			Destroy(m_activeAudio.Find(s => s.source == toStop).source.gameObject);
		} catch {
			Debug.Log("Error trying to stop audio source "+toStop);
		}
	}

	private void updateActiveAudio() { 
		var toRemove = new List<ClipInfo>();
		try {
			foreach (var audioClip in m_activeAudio) {
				if (!audioClip.source) {
					toRemove.Add(audioClip);
				} 
			}
		} catch {
			Debug.Log("Error updating active audio clips");
			return;
		}
		//cleanup
		foreach (var audioClip in toRemove) {
			m_activeAudio.Remove(audioClip);
		}
	}

	void Awake() {
			m_activeAudio = new List<ClipInfo>();
			
			Debug.Log("AudioManager Initializing");
			try {
				transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
				transform.localPosition = new Vector3(0, 0, 0);
			} catch {
				Debug.Log("Unable to find main camera to put audiomanager");
			}



		Debug.Log ("AudioController Initializing");
		try {
			transform.parent = GameObject.FindGameObjectWithTag ("MainCamera").transform;
			transform.localPosition = new Vector3 (0, 0, 0);
		} catch {
			Debug.Log ("Unable to find main camera to put audiomanager");
		}
	}

	public AudioSource PlayMusic(AudioClip music, float volume) {
		m_activeMusic = PlayLoop(music, Vector3.zero, volume);
		return m_activeMusic;
	}

	public void pauseFX() { 
		foreach (var audioClip in m_activeAudio) {
			try {
				if (audioClip.source != m_activeMusic) {
					audioClip.source.Pause();
				}
			} catch {
				continue;
			}
		}
	}
	
	public void unpauseFX() {
		foreach (var audioClip in m_activeAudio) {
			try {
				if (!audioClip.source.isPlaying) {
					audioClip.source.Play();
				}
			} catch {
				continue;
			}
		}
	}


	// Use this for initialization
	void Start () {
	
	}

	public void PlayIntroLoop()
	{
		PlayMusic(introClip, 1.0f);
	}

	public void StopIntroLoop()
	{
		stopSound (m_activeMusic);
	}

	public void PlaySelectItemClip()
	{
		Play (guiH, Vector3.zero, 1.0f);
	}

	public void PlayShootClip()
	{
		Play (shootClipA, Vector3.zero, 1.0f);
	}

	public void PlayExplodeClip()
	{
		Play (explosionClip, Vector3.zero, 1.0f);
	}

	public void PlayRunningActionsLoop()
	{
		//PlayLoop(runningMovesClip, Vector3.zero, 1.0f);
		PlayMusic(introClip, 1.0f);
	}

	public void StopRunningActionsLoop()
	{
		//stopSound(runningMovesClip);
		stopSound (m_activeMusic);
	}

	public void PlaySelectingMovesLoop(){
		PlayMusic (selectingMovesClip, 1.0f);
	}

	public void StopSelectingMovesLoop(){
		stopSound (m_activeMusic);
	}
	// Update is called once per frame
	void Update() {
		updateActiveAudio();
	}

}
