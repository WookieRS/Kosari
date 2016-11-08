using UnityEngine;
\using System.Collections;
\
\public class GrassSpawner : MonoBehaviour {
\
\
\	public Animator grass;
\	private ScoreController scoreController;
\	public GameObject grassGameObj;
\	private LevelManager levelManager;
\	public GameObject grassFx;
\
\
\	// Use this for initialization
\	void Start () {
\		grass = GetComponent<Animator> ();
\		scoreController = GameObject.FindObjectOfType<ScoreController> ();
\		levelManager = GameObject.FindObjectOfType<LevelManager> ();
\
\
\	}
\	
\	// Update is called once per frame
\	void Update () {
\		
\
\	}
\
\	public void CutGrass(){
\		if (!grass.GetBool("cut")) {
\			grass.SetTrigger ("cut");
\			scoreController.addScore (CalcBonus());
\			MakeGrassFx ();
\			levelManager.MakeStormFx ();
\		}
\	}
\
\	public float CalcBonus(){
\		float bonus;
\		float posY = grassGameObj.transform.localPosition.y;
\		bonus = posY + 1.878f;
\		 if (bonus >= 3) {
\			bonus *= 3;
\		} else if (bonus >=2) {
\			bonus *= 2;
\		}
\
\			
\		return bonus;
\	}
\		
\	void EndGame ()	{
\		
\		if (!levelManager.gameIsStopped) {
\			levelManager.gameIsStopped = true;
\			scoreController.SaveScore ();
\		}
\	}
\
\	void MakeGrassFx(){
\		GameObject grassFXClone = Instantiate (grassFx);
\		grassFXClone.transform.position = transform.position;
\		Destroy (grassFXClone, 2);
\
\	}
\
\		
\}
\