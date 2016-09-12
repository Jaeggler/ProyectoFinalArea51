using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SkillTouch : SkillClass {
    public float damageOnTouch;
    private GameObject Player;
    public GameObject SkillExplosion;
    GameObject explosion;
    UITouch _uiController;
    // Use this for initialization
    void Start () {
        _uiController = GameObject.Find("UIController").GetComponent<UITouch>();
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

    public bool IsUIInput()
    {
        return _uiController.UIClicked;
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
                    
                    if (_objTouched.CompareTag("Button") || _objTouched.CompareTag("Blood") || IsUIInput()) //Checking if a button has been clicked
                    {

                    }
                    else
                    {
                        if (SkillExplosion)
                        {
                            explosion = (GameObject)Instantiate(SkillExplosion, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), SkillExplosion.transform.rotation);
                            explosion.transform.parent = gameObject.transform;
                        }
                        Player.GetComponent<ManaController>().decreaseMana(manaCost);

                        if (_objTouched.CompareTag("Enemy"))
                        {
                            MakeDamage(_objTouched.gameObject.GetComponent<HealthController>());
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits = Physics.RaycastAll(myray, 1000.0f);
                
                Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                //First check if the user has touched any UI Element
                if (IsUIInput())
                {

                }
                else
                {
                    if (_objTouched != null)
                    {
                        if (_objTouched.CompareTag("Button") || _objTouched.CompareTag("Blood"))
                        {

                        }
                        else
                        {
                            if (SkillExplosion && Player.GetComponent<ManaController>().decreaseMana(manaCost))
                            {
                                explosion = (GameObject)Instantiate(SkillExplosion, Camera.main.ScreenToWorldPoint(Input.mousePosition), SkillExplosion.transform.rotation);
                                explosion.transform.parent = gameObject.transform;
                                if (_objTouched.CompareTag("Enemy"))
                                {
                                    MakeDamage(_objTouched.gameObject.GetComponent<HealthController>());
                                }
                            }

                        }

                    }
                    else
                    {
                        if (SkillExplosion && Player.GetComponent<ManaController>().decreaseMana(manaCost))
                        {
                            explosion = (GameObject)Instantiate(SkillExplosion, Camera.main.ScreenToWorldPoint(Input.mousePosition), SkillExplosion.transform.rotation);
                            explosion.transform.parent = gameObject.transform;
                        }
                    }
                }
            }
        }

    }

}
