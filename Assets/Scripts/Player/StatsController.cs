using UnityEngine;
using System.Collections;
//This class maintains all main stats of the minion or player minion
public class StatsController : MonoBehaviour {
    public enum Status { Motion, Battle, PushSkill,StunSkill};

    public Status status; 
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
    public float transitionTime;
	// Use this for initialization
	void Awake () {
        //Status can be Motion - Battle
        status = Status.Motion;
        type = "minion";
        transitionTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (transitionTime > 0)
        {
            transitionTime = transitionTime - Time.deltaTime;
        }
    }
}
