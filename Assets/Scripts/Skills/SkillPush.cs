using UnityEngine;
using System.Collections;

public class SkillPush : SkillClass {
    public GameObject SkillExplosion;
    public float pushForce;
    public float damage;
    GameObject explosion;
    private ArrayList enemiesTouched;
	// Use this for initialization
	void Start () {
        enemiesTouched = new ArrayList();
        if (SkillExplosion)
        {
            explosion = (GameObject)Instantiate(SkillExplosion, gameObject.transform.position, SkillExplosion.transform.rotation);
            explosion.transform.parent = gameObject.transform;
        }
    }

    bool EnemyTouched(int itemID)
    {
        foreach (int i in enemiesTouched)
        {
            if (i == itemID)
            {
                return true;
            }
        }
        return false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        StatsController otherStats = other.GetComponent<StatsController>();
        HealthController otherHealth = other.GetComponent<HealthController>();
        if (other && other.CompareTag("Enemy") && (otherStats.status == StatsController.Status.Battle || otherStats.status == StatsController.Status.Motion) && !EnemyTouched(other.GetInstanceID()))
        {
            Debug.Log("Firebolt!");
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-15f, 50f) * pushForce);
            otherHealth.takeMagicDamage(damage);
            otherStats.status = StatsController.Status.PushSkill;
            otherStats.transitionTime = 0.25f;
            enemiesTouched.Add(other.GetInstanceID());
        }
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
