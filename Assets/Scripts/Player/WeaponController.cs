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
        bool isEnemy = false; //Verificamos si el objeto con el que colisionamos es un enemigo nuestro
        for (int i = 0; i < _battle.targetTag.Length; i++)
            {
                if (other.gameObject.CompareTag(_battle.targetTag[i]))
                {
                    isEnemy = true;
                }
            }

        if (isEnemy)
        {
            _battle.isTrigger = true;
            _battle.enemyList.Add(other.gameObject);
        }

            }
    void OnTriggerStay2D(Collider2D other)
    {
        bool isEnemy = false; //Verificamos si el objeto con el que colisionamos es un enemigo nuestro
        for (int i = 0; i < _battle.targetTag.Length; i++)
        {
            if (other.gameObject.CompareTag(_battle.targetTag[i]))
            {
                isEnemy = true;
            }
        }

        if (isEnemy)
        {
            _battle.isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        bool isEnemy = false; //Verificamos si el objeto con el que colisionamos es un enemigo nuestro
        for (int i = 0; i < _battle.targetTag.Length; i++)
            {
                if (other.gameObject.CompareTag(_battle.targetTag[i]))
                {
                    isEnemy = true;
                }
            }

        if (isEnemy)
        {
            _battle.isTrigger = false;
            _battle.enemyList.Remove(other.gameObject);
        }

    }
}
