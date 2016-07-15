using UnityEngine;
using System.Collections;


public class EnemyMinionMovement : MonoBehaviour {

	//Variables para uso del RayCast
	//public LayerMask layerMask;
	//public GameObject rangeCheck;


	public int velmovimientolateral;
	Rigidbody2D rb2D;
	//GameObject dummy;
	//DummyStatus dummyStatus;


	// Use this for initialization
	void Awake () {
	
		rb2D = GetComponent<Rigidbody2D> ();

		//Para uso del RayCast
		//dummy = GameObject.FindGameObjectWithTag ("Dummy");
		//dummyStatus = dummy.GetComponent<DummyStatus>();
	}
	
	// Update is called once per frame
	void Update () {

		movement ();
	}

	// Función que controla el movimiento del personaje.
	void movement () {
		Vector2 movimientolateral = new Vector2 (velmovimientolateral, 0);
		rb2D.velocity = movimientolateral;
	}
		
	//	void atRange(){
	//		RaycastHit2D inRange = Physics2D.Linecast (transform.position, rangeCheck.transform.position,layerMask.value);
	//		if (inRange.collider != null) {
	//
	//			animator.SetBool ("isAtkRange", true);
	//		} else {
	//			animator.SetBool ("isAtkRange", false);
	//		}
	//	}
}
