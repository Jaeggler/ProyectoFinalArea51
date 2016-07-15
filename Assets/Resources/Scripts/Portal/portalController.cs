using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class portalController : MonoBehaviour {
    // Use this for initialization 
    public portalClass[] _summon;
    public List<GameObject> _creatures;
    int nowCreature = 0;
    int nowCount = 0;
    int totalCount = 0;

    void Summon()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        _creatures.Add((GameObject)Instantiate(_summon[nowCreature]._monster, transform.position,transform.rotation));
        StatsController _creatureStats = _creatures[_creatures.Count-1].GetComponent<StatsController>();
        Transform _creatureTransform =  _creatures[_creatures.Count - 1].transform;
        //Check rotation and speed of sprites
        if (playerPos.x > _creatureTransform.position.x)
        {
            //If creature is looking to the wrong side
            if (_creatureStats.initSpeed < 0)
            {
                //Changing Speed
                _creatureStats.initSpeed = _creatureStats.initSpeed * -1;
                //Changing rotation
                Vector3 _newScale = _creatureTransform.localScale;
                _newScale.x = _newScale.x * -1;
                _creatures[_creatures.Count - 1].transform.localScale = _newScale;
            }
            
        }
        else
        {

        }

        nowCount = nowCount + 1;
        totalCount = totalCount + 1;
        if (nowCount >= _summon[nowCreature]._quantity)
        {
            nowCreature = nowCreature + 1;
            nowCount = 0;
        }
        if (nowCreature < _summon.Length)
        {
            Invoke("Summon", _summon[nowCreature]._delay);
        }

    }

    void Start () {
        _creatures = new List<GameObject>();
        if (_summon.Length > 0)
        {
            Invoke("Summon", _summon[nowCreature]._delay);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
