using UnityEngine;
using System.Collections;

public class GeneratePong : MonoBehaviour {

	public GameObject Ball;
	private GameObject[] GonBall;
	private float Collisions;

	// Use this for initialization
	void Start () {
		Vector2 vel = new Vector2(0, 5);
		Vector3 pos = new Vector3 (0, 0, 0);
		Quaternion rotation = Quaternion.Euler (0, 0, 0);
		Instantiate (Ball, pos, rotation);
		GonBall = GameObject.FindGameObjectsWithTag ("Ball");
		GonBall [0].GetComponent<Rigidbody2D> ().velocity = vel;
	}
	// Update is called once per frame
	void Update () {
		float d;
		float x;
		float y;
		GonBall = GameObject.FindGameObjectsWithTag ("Ball");
		d = Mathf.Sqrt (Mathf.Pow (GonBall [0].GetComponent<Rigidbody2D> ().position.x, 2) + Mathf.Pow (GonBall [0].GetComponent<Rigidbody2D> ().position.y, 2));
		Vector2 vel = new Vector2(GonBall [0].GetComponent<Rigidbody2D> ().velocity.x, GonBall [0].GetComponent<Rigidbody2D> ().velocity.y);
		x = Mathf.Clamp( (vel.x) , -25.0f, 25.0f);
		y = Mathf.Clamp( (vel.y) , -25.0f, 25.0f);
		Vector2 vel2 = new Vector2(x,y);
		GonBall [0].GetComponent<Rigidbody2D> ().velocity = vel2;
		if (d > 20) {
			GameOver();
		}
	}
	void OnCollisionEnter(Collision collision){
		Debug.Log (collision);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Hit");
		if (other.gameObject.tag == "Ball")
			Collisions += 1; 
		Debug.Log (Collisions);
	}
	
	void GameOver() {
		GonBall = GameObject.FindGameObjectsWithTag ("Ball");
		Destroy (GonBall[0]);
		Start ();
	}
}