using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float timerAutoLoadNextLevel;
	static public int losedLevel;
	public InputField inputField;
	private string playerName;
	public Animator animatorNameField;
	public GameObject stormFX;

	public bool gameIsStopped = false;


	void Start(){
		if (timerAutoLoadNextLevel != 0) {
			Invoke("LoadNextLevel",timerAutoLoadNextLevel);
		}
	}

	public void StartGame(){
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			playerName = inputField.text;
			if (playerName == "ENTER NAME" || playerName == "") {
				Debug.Log ("wrong name");
				//inputField.textComponent.color = Color.red;
				animatorNameField.SetTrigger ("wrongName");
	
			} else {
				LoadNextLevel ();
			}
		}


	}
		
	public void LoadLevel(string level){
        SceneManager.LoadScene(level);        
	}

	public void LoadNextLevel(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit(){
		Application.Quit();
	}

	public void LoadLastLevel (){
		SceneManager.LoadScene(losedLevel);
	}

	public void MakeStormFx(){
		float stormChance = Random.Range (0, 1f);

			if (stormChance >= 0.97f) {
				float posX = Random.Range (-3f, 3f);
				float posY = Random.Range (0f, 5f);
				Vector3 position = new Vector3 (posX, posY);
				GameObject stormFxClone = Instantiate(stormFX, position, Quaternion.identity) as GameObject;
				Destroy (stormFxClone, 5);
			}
		}



}