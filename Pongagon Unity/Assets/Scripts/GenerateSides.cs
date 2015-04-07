using UnityEngine;
using System.Collections;

public class GenerateSides : MonoBehaviour {
	public GameObject Sides;
	public int NumberSides;
	private float GonAngle;
	// Use this for initialization
	void Start () {
		float angle;
		float y;
		float x;
		float rotate;

		angle = 2.0f * Mathf.PI / NumberSides;
		for (int i = 0; i < NumberSides; i++) {
			x = 10.0f * Mathf.Cos (angle * i + Mathf.PI / 2.0f);
			y = 10.0f * Mathf.Sin (angle * i + Mathf.PI / 2.0f);
			rotate = angle * i * 180.0f / Mathf.PI;
			Quaternion rotation = Quaternion.Euler (0, 0, rotate);
			Vector3 pos = new Vector3 (x, y, 0.0f);
			Instantiate (Sides, pos, rotation);
		}
	}

	// Update is called once per frame
	void Update () {
		float angle;
		float y;
		float x;
		float rotate;
		float moveHorizontal;
		moveHorizontal = Input.GetAxis ("Horizontal");
		GonAngle += -moveHorizontal/15;
		GameObject[] GonSides = new GameObject[NumberSides];
		GonSides = GameObject.FindGameObjectsWithTag ("Block");
		angle = 2.0f * Mathf.PI / NumberSides;
		for (int i = 0; i < NumberSides; i++) {
			x = 10.0f * Mathf.Cos (angle * i + Mathf.PI / 2.0f + GonAngle);
			y = 10.0f * Mathf.Sin (angle * i + Mathf.PI / 2.0f + GonAngle);
			rotate = ((angle * i + GonAngle) * 180.0f) / Mathf.PI;
			Quaternion rotation = Quaternion.Euler (0, 0, rotate);
			Vector3 pos = new Vector3 (x, y, 0.0f);
			GonSides[i].GetComponent<Transform>().position = pos;

			GonSides[i].GetComponent<Transform>().rotation = rotation;
			
		}
		
	}
}
