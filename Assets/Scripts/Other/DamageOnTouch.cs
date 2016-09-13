using UnityEngine;
using System.Collections;

public class DamageOnTouch : MonoBehaviour {
    public float damageOnTouch;
    public float manaCost;
    private GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {
	
	}

    void MakeDamage(HealthController _health)
    {
        _health.takeMagicDamage(damageOnTouch);
        Player.GetComponent<ManaController>().decreaseMana(manaCost);
    }

    void OnMouseOver()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
                if (_objTouched != null)
                {
                    if (_objTouched.GetInstanceID() == gameObject.GetComponent<Collider2D>().GetInstanceID())
                    {
                        MakeDamage(GetComponent<HealthController>());
                    }

                }
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (_objTouched != null)
                {
                    if (_objTouched.GetInstanceID() == gameObject.GetComponent<Collider2D>().GetInstanceID())
                    {
                        Debug.Log("haciendole daño al zombie");
                        MakeDamage(GetComponent<HealthController>());
                    }

                }
            }
        }

    }
}

