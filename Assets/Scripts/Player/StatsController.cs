using UnityEngine;
using System.Collections;
//This class maintains all main stats of the minion or player minion
public class StatsController : MonoBehaviour {
    public string status;
    //Status can be: Motion - Battle
    public float initHealth;
    public float initSpeed;
    public float initDamage;
    public float initDefense;
    public float initAttackSpeed;
    public float initDodge;
    public string type;
    public float bloodCost;
    public float bloodDrop;

    public float initBlood;
    public float initMana;
	// Use this for initialization
	void Awake () {
        //Status can be Motion - Battle
        status = "Motion";
        type = "minion";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
