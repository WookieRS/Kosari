using UnityEngine;
\using System.Collections;
\using UnityEngine.UI;
\
\public class Kosar : MonoBehaviour {
\
\	private Animator kosar;
\	private Animator grassSpawnerAnimator;
\	public GrassSpawner grassSpawner;
\	public float speed = 0.5f;
\	private AudioSource audioSource;
\
\
\	private float min_X;
\	private float max_X;
\	public float enrageTimer;
\	private bool isEnrage;
\
\	public Slider enrageSlider;
\
\
\	// Use this for initialization
\	void Start () {
\		audioSource = GetComponent<AudioSource> ();
\		kosar = GetComponent<Animator> ();
\
\		float distance = transform.position.z - Camera.main.transform.position.z;
\		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
\		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
\		min_X = leftmost.x + 0.5f;
\		max_X = rightmost.x - 0.5f;
\	}
\	
\	// Update is called once per frame
\	void Update () {
\		
\
\		if (Input.GetKeyDown(KeyCode.Space)) {
\			kosar.SetTrigger("kosit");
\			//grassSpawner.CutGrass (); вызывается из аниматора
\		}
\
\		if (!isEnrage && enrageTimer> 5f) {
\			if (Input.GetKeyDown(KeyCode.E)) {
\				EnrageEnable ();
\			}
\		}
\
\		if (isEnrage && enrageTimer > 0) {
\			enrageTimer -= Time.deltaTime;
\			kosar.SetTrigger ("kosit");
\			kosar.SetBool("enrage", true);
\		} else {
\			EnrageDisable ();
\		}
\
\		if (Input.GetKey(KeyCode.A)) {
\			transform.position += Vector3.left * speed * Time.deltaTime;
\		}
\		if (Input.GetKey(KeyCode.D)) {
\			transform.position += Vector3.right * speed * Time.deltaTime;
\		}
\					
\
\		//Ограничение по оси Х
\		float newX = Mathf.Clamp(transform.position.x, min_X, max_X);
\		transform.position = new Vector3(newX, transform.position.y);
\	}
\
\
\	void OnTriggerStay2D(Collider2D collider){
\		grassSpawner = collider.GetComponent<GrassSpawner> ();
\	}
\
\	public void PlayCutSound(){
\		audioSource.Play ();
\	}
\
\	void CutGrass(){
\		grassSpawner.CutGrass ();
\		if (!isEnrage) {
\			enrageTimer += 0.2f;
\		}
\		enrageSlider.value = enrageTimer;
\		if (enrageTimer >= 5) {
\			enrageSlider.fillRect.GetComponent<Image> ().color = new Color (1f, 0.5f, 0f);
\		} else {
\			enrageSlider.fillRect.GetComponent<Image> ().color = new Color (0.9f, 0.9f, 0.9f);
\		}
\	}
\
\	public void EnrageEnable(){
\		kosar.speed = 2f;
\		isEnrage = true;
\	}
\
\	public void EnrageDisable(){
\		kosar.speed = 1f;
\		kosar.SetBool ("enrage", false);
\		isEnrage = false;
\	}
\
\
\}
\