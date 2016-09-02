using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	Animator _animator;
	MovementController _movement;
	StatsController _stats;

	public GameObject target;
	public List<GameObject> enemyList = new List<GameObject>();
    public string[] targetTag;
    public float nowDamage;
    public bool isTrigger;

    // Use this for initialization
    void OnEnable () {
		_animator = GetComponent<Animator> ();
		_movement = GetComponent<MovementController>();
        _stats = GetComponent<StatsController>();
    }

    void Start()
    {
        nowDamage = _stats.initDamage;
        isTrigger = false;
    }
	
	// Update is called once per frame
    void checkBattle()
    {
        if (isTrigger)
        {
            _animator.SetBool("isAtkRange", true);
            _stats.status = "Battle";
        }
        else
        {
            _animator.SetBool("isAtkRange", false);
            target = null;
            _stats.status = "Motion";
        }

    }
    void FixedUpdate () {
        checkBattle();
        checkEnemyList();
    }

	//Entrar al rango Collision

	void checkEnemyList(){
        if (_stats.status == "Battle")
        {
            if (target == null && enemyList.Count != 0)
            {
                if (enemyList[0] == null) //Checking bug of enemy[0] is missing, if its bugged remove it
                {
                    enemyList.RemoveAt(0);
                }
                if (enemyList.Count == 0) //After fixing bug, check if there are other enemies colliding, if not just keep moving
                {
                    isTrigger = false;
                }
                else //If there are other enemies colliding target the next one
                {
                    target = enemyList[0];
                }

            }
        }
    }

	void attack (){
        if (_stats.status == "Battle")
        {
                HealthController targetHealth;
                

			float targetDefense;
                float targetDodge;
                if (target)
                {
                    targetHealth = target.GetComponent<HealthController>();
                    targetDefense = target.GetComponent<HealthController>().nowDefense;
                    targetDodge = target.GetComponent<HealthController>().nowDodge;
                    if (targetHealth.currentHealth > 0)
                    {
                        targetHealth.takeDamage(nowDamage);
                    }
                

            }
         }
    }

}
