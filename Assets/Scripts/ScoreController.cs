using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public static float totalScore;
	public static string playerName;
	public InputField input;
	private HSController hsController;
	int finalScore;
	private LevelManager levelManager;
	private float timer;
	private float maxVgrass;
	public float mediumPerSec;

	// Use this for initialization
	void Start () {
		timer = 0;
		totalScore = 0;
		finalScore = 0;
		hsController = GameObject.FindObjectOfType<HSController> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//Debug.Log (totalScore / timer);
	}

	public void addScore(float score){
		totalScore += score;
		finalScore = Mathf.RoundToInt(totalScore);
		totalScore *= 100f;
		totalScore = Mathf.Round (totalScore) / 100f;
		scoreText.text = ("Травы скошено: " + totalScore + " кг");
	}

	public void SaveScore(){

		if (CheckResult()) {
			StartCoroutine (hsController.PostScores (playerName, finalScore));
		} else {
			playerName = playerName + " CHEATER";
			finalScore = 0;
			StartCoroutine (hsController.PostScores (playerName, finalScore));
		}
	
	}
		

	public void SetPlayerName(string player){
		playerName = input.text;
	}
	//TODO спрятать принцип проверки?
	bool CheckResult(){
		maxVgrass = mediumPerSec * timer;

		if (finalScore >= maxVgrass ) {
			Debug.Log ("CHEATER");
			return false;
		}
		Debug.Log ("NOT CHEATER");
		return true;
	}
}
