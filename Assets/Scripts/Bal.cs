using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bal : MonoBehaviour {
	public int timerBolEsplode;
	public int pointsBal;

	float timer;
	public GameObject prefabExplosao;
	public GameObject texto;
	GameObject canvas;
	GameObject instance;
	TextFollow instanceText;
	Vector2 screenPosition;
	// Use this for initialization
	void Start () {
		StartCoroutine ("TimerExplode");
		canvas = GameObject.Find("Canvas");
		screenPosition = transform.position;
		CreateFollowText (timerBolEsplode.ToString(), gameObject.transform);

	}

	void Update(){
		timer += Time.deltaTime;
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		instance.transform.position = screenPosition;
		instanceText.SetText ((timerBolEsplode-(int)timer).ToString());

	}

	public void CreateFollowText(string text, Transform location)
	{
		instance = Instantiate(texto);
		instanceText = instance.GetComponent<TextFollow> ();
		instance.transform.SetParent(canvas.transform, false);
	}

	IEnumerator TimerExplode(){
		yield return new WaitForSeconds(timerBolEsplode);
		Instantiate (prefabExplosao, transform.position,Quaternion.identity);
		GameController.PlusPoints (pointsBal, timerBolEsplode);
		Destroy (instance);
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll) {	
		if (coll.gameObject.tag == "cair") {
			Instantiate (prefabExplosao, transform.position,Quaternion.identity);
			GameController.Deth (timerBolEsplode);
			Destroy (instance);
			Destroy (this.gameObject);
		}
	}
}
