using UnityEngine;
using System.Collections;

public class SummonPlayer : MonoBehaviour {

	public GameObject PlayerMinion;
	public GameObject summonPoint;
    public BloodController Player;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void summonPlayer (){
        if (Player.currentBlood > 0)
        {
            if (Player.decreaseBlood(PlayerMinion.GetComponent<StatsController>().bloodCost))
            {
                Instantiate(PlayerMinion, summonPoint.transform.position, Quaternion.identity);
            }

        }
    }
}
