using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Transform[] instantietePonts;
	public GameObject[] instantiateBolas;

	float espownEasy, timerEasy;
	float espownMediun, timerMediun;
	float espownHard, timerHard;
	float timerJogo;

	public GameObject prefCanhaoExplosão;

	private static int points;
	private static int timer;
	float count;
	public Text pointsGame;
	public Text timerGame;

	// Use this for initialization
	void Start () {
		timer = 60;
		timerEasy = 2;
		timerMediun = 4;
		timerHard = 5;
		timerJogo = 0;
		points = 0;
	}


	// Update is called once per frame
	void Update () {
		timerJogo += Time.deltaTime;
		timerGame.text = (timer-(int)timerJogo).ToString();
		pointsGame.text = points.ToString();
		if (points < 1000) {	
			if (espownEasy <= 0) {
				espownEasy = timerEasy;
				CalReapeatingEasy ();
			}

			if (points > 50) {
				if (espownMediun <= 0) {
					espownMediun = timerMediun;
					CalReapeatingMediun ();
				}
				espownMediun -= Time.deltaTime;

			}
			if (points > 200) {
				if (espownHard <= 0) {
					espownHard = timerHard;
					CalReapeatingHard ();
				}
				espownHard -= Time.deltaTime;

			}
		} else {
			if (espownEasy <= 0) {
				espownEasy = timerEasy-0.1f;
				CalReapeatingEasy ();
			}	
			if (espownMediun <= 0) {
				espownMediun = timerMediun-0.1f;
				CalReapeatingMediun ();
			}
			if (espownHard <= 0) {
				espownHard = timerHard-0.1f;
				CalReapeatingHard ();
			}
			espownMediun -= Time.deltaTime;
			espownHard -= Time.deltaTime;

		}
		espownEasy -= Time.deltaTime;
		if((timer-(int)timerJogo) <= 0){
			SceneManager.LoadScene (0);
		}
	}

	void CalReapeatingEasy(){
		AtirarCanhao ();
		InstantiateBol (instantiateBolas [0], instantietePonts [Random.Range (0, 2)]);
	}
	void CalReapeatingMediun(){
		AtirarCanhao ();
		InstantiateBol (instantiateBolas [1], instantietePonts [Random.Range (0, 2)]);
	}
	void CalReapeatingHard(){
		AtirarCanhao ();	
		InstantiateBol (instantiateBolas [2], instantietePonts [Random.Range (0, 2)]);
	}

	void InstantiateBol(GameObject bol, Transform canhao){
		GameObject copyBol = Instantiate (bol, canhao.transform.position,Quaternion.identity);
		if (canhao.position.x > 0) {
			Instantiate (prefCanhaoExplosão, canhao);
			copyBol.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (-15f, -5f), 0);
		} else {
			Instantiate(prefCanhaoExplosão, canhao);
			copyBol.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (5f, 15f), 0);
		}
	}

	public static void PlusPoints(int point, int timeMorte){
		points += point;
		timer += timeMorte;
	}
	public static void Deth(int tempoMorte){
		timer -= tempoMorte;
	}
	public void AtirarCanhao(){
		FindObjectOfType<AudioManager> ().Play("canhao");
	}

}
