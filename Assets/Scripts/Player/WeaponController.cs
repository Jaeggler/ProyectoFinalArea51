using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour {
    public BattleController _battle;

    // Use this for initialization
    void Start()
    {
        //_battle = gameObject.GetComponent<BattleController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_battle.targetTag))
        {
            _battle.isTrigger = true;
            _battle.enemyList.Add(other.gameObject);
            Debug.Log("entrando en colision");
        }

            }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_battle.targetTag))
        {
                _battle.isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
            if (other.gameObject.CompareTag(_battle.targetTag))
            {
                _battle.isTrigger = false;
                _battle.enemyList.Remove(other.gameObject);
            }

    }
}
