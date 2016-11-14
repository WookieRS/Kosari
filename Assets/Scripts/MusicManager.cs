using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicArray;

	private AudioSource music;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Start () {
		music = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded (int level){
		AudioClip thisLevelMusic = levelMusicArray[level];

		if (level == 7 || level == 1  && music.isPlaying) {
			return;
		}else if (level == 6) {
			music.clip = thisLevelMusic;
			music.loop = false;
			music.Play();

		}	else if (thisLevelMusic) {
			//Если клип существует
			music.clip = thisLevelMusic;
			music.loop = true;
			music.Play();
		}
	}

	public void SetVolume (float volume){
		music.volume = volume;
	}
}
