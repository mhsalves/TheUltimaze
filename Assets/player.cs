using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	//public GameObject ob;
	public GameObject payer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKey(KeyCode.Space)){
//			GetComponent<Rigidbody>().velocity = new Vector3 (0,0, 0);
//
//
//		}

		Movimentacao ();
	}



	void Movimentacao() {
		if ((Input.touchCount > 0 && Input.touchCount < 2) || (Input.GetKey(KeyCode.RightArrow))) {
			//ob.transform.Rotate (10f, 0f, 0f);
			//transform.eulerAngles = new Vector2 (0, 90);
			//print(ob.transform.eulerAngles);
			//ob.GetComponent<Animation>().Play("Walk");
			payer.transform.Translate (-Vector3.left * 0.025f );

		} 
		
		else if ((Input.touchCount > 1 && Input.touchCount < 3) || (Input.GetKey(KeyCode.LeftArrow))) {
			//transform.eulerAngles = new Vector2 (0, -90);
			//print(ob.transform.eulerAngles);
			//ob.GetComponent<Animation>().Play("Walk");
			payer.transform.Translate (Vector3.left * 0.025f );
		
		} 
	
		else if ((Input.touchCount > 2 && Input.touchCount < 4) || (Input.GetKey(KeyCode.UpArrow))) {
			transform.eulerAngles = new Vector2 (0, 0);
			//print(ob.transform.eulerAngles);
			//ob.GetComponent<Animation>().Play("Walk");
			payer.transform.Translate (Vector3.forward * 0.025f );

		} 
		else if ((Input.touchCount > 3 && Input.touchCount < 5) || (Input.GetKey(KeyCode.DownArrow))) {
			//transform.eulerAngles = new Vector2 (0, 180);
			//print(ob.transform.eulerAngles);
			//ob.GetComponent<Animation>().Play("Walk");
			payer.transform.Translate (-Vector3.forward * 0.025f);

		} 
		//else ob.GetComponent<Animation>().Play("Idle");
	}

}
