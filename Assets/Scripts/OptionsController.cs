using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultSlider;
	//public LevelManager levelManager;

	private MusicManager musicManager;
	private Animator anim;
	private bool isOptionsShown = false;


	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultSlider.value = PlayerPrefsManager.GetDifficulty();
		anim = GetComponent<Animator> ();
		if (PlayerPrefsManager.GetMasterVolume() == 0) {
			SetDefaults ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}

	public void Save(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (Mathf.RoundToInt(difficultSlider.value));
		//levelManager.LoadLevel("Start");
	}

	public void SetDefaults(){
		volumeSlider.value = 0.4f;
		difficultSlider.value = 2f;
		//Screen.SetResolution(1920,1050,true);
	
	}

	public void SwitchOptionsShow(){
		isOptionsShown = !isOptionsShown;
		anim.SetBool ("active", isOptionsShown);
	}
}
