using UnityEngine;
using System.Collections;

public class Velocity : MonoBehaviour {

	private int CollCount = 1;
	private GameObject[] GonBall;

	void OnCollisionEnter2D(Collision2D coll) {
		CollCount += 1;
		GonBall = GameObject.FindGameObjectsWithTag ("Ball");
		Vector2 vel = new Vector2(GonBall [0].GetComponent<Rigidbody2D> ().velocity.x ,GonBall [0].GetComponent<Rigidbody2D> ().velocity.y);
		GonBall [0].GetComponent<Rigidbody2D> ().velocity = vel * Mathf.Log (CollCount);
	}
}
