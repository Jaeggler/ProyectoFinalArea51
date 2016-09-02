using UnityEngine;
using System.Collections;

public class SkillTouch : SkillClass {
    public float damageOnTouch;
    private GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        touchDetector();
    }

    void MakeDamage(HealthController _health)
    {
        _health.takeMagicDamage(damageOnTouch);
        Player.GetComponent<ManaController>().decreaseMana(manaCost);
    }


    void touchDetector()
    {
        Debug.Log("En touchdetector");
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
                if (_objTouched != null)
                {
                        MakeDamage(GetComponent<HealthController>());
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (_objTouched != null && _objTouched.CompareTag("Enemy"))
                {
                        Debug.Log("haciendole daño al zombie");
                        MakeDamage(_objTouched.gameObject.GetComponent<HealthController>());
                }
            }
        }

    }

}
