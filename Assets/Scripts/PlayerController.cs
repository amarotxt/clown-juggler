using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed, speedMax, speedMin;
	public GameObject personagem;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float translation = Input.GetAxis("Horizontal") * speed;
		transform.Translate(translation*Time.deltaTime, 0, 0);

		if (Mathf.Abs(translation) > 0 && Mathf.Abs(translation) < speedMax)
			speed += 1f;
		else {
			speed = speedMin;
		}
		personagem.transform.Translate (translation*Time.deltaTime*-1, 0, 0);
		personagem.transform.SetPositionAndRotation(new Vector3(personagem.transform.position.x,-4.1f,personagem.transform.position.z),Quaternion.identity);
		if(transform.position.x > 7){
			transform.position = new Vector3 (7, transform.position.y,0);
			personagem.transform.position = new Vector3 (-7, personagem.transform.position.y,0);
		}	
		if(transform.position.x < -7){
			transform.position = new Vector3 (-7, transform.position.y,0);
			personagem.transform.position = new Vector3 (7, personagem.transform.position.y,0);
		}	
	}
		
}
