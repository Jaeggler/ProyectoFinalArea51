using UnityEngine;
using System.Collections;

public class SummonEnemy : MonoBehaviour {

	public GameObject EnemyMinion;
	public GameObject summonPoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void summonEnemy (){
		Instantiate (EnemyMinion,summonPoint.transform.position,Quaternion.identity);
	}
}
