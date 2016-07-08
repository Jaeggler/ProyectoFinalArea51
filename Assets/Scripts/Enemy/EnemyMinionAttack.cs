using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMinionAttack : MonoBehaviour {

	public int damagePerAttack;
	GameObject target;
	EnemyMinionMovement movement;
	Animator animator;
	public List<GameObject> enemyList = new List<GameObject>();



	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
		movement = GetComponent<EnemyMinionMovement>();
	}

	// Update is called once per frame
	void Update () {
		AttackMode ();
	}

	//Entrar al rango con Collision Enter
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.CompareTag("Player"))
		{
			enemyList.Add (other.gameObject);
		}
	}

	void OnCollisionExit2D (Collision2D other){
		if (other.gameObject.CompareTag("Player"))
		{
			animator.SetBool("isAtkRange", false);
			target = null;
			enemyList.Remove (enemyList [0]);
			movement.velmovimientolateral = 2;
		}
	}



	//Entrar al rango con Trigger
//	void OnTriggerEnter2D (Collider2D other){
//		if (other.gameObject.CompareTag("Player"))
//		{
//			enemyList.Add (other.gameObject);
//		}
//	}
//
//	void OnTriggerExit2D (Collider2D other){
//		if (other.gameObject.CompareTag("Player"))
//		{
//			animator.SetBool("isAtkRange", false);
//			target = null;
//			enemyList.Remove (enemyList [0]);
//			movement.nowSpeed = 2;
//		}
//	}
//

	void AttackMode(){
		if (target == null && enemyList.Count != 0) {
				target = enemyList [0];
				movement.velmovimientolateral = 0;
				animator.SetBool ("isAtkRange", true);
			}
	}

	void attack (){
		HealthController targetStatus;
		targetStatus = target.GetComponent<HealthController> ();
		if (targetStatus.currentHealth > 0) {
			targetStatus.takeDamage (damagePerAttack);
		}

	}

}
