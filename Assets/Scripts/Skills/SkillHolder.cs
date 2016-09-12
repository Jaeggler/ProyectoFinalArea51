using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillHolder : MonoBehaviour {
    public enum ClassHolder { Draggable, Activated};
    private bool isDrag = false;
    public Cooldown cooldownController;
    private GameObject newSkill;
    public GameObject SkillAttached;
    public GameObject Player;
    public ClassHolder holderType;
    // Use this for initialization
    public void onEnter()
    {
        switch (holderType)
        {
            case ClassHolder.Draggable:
                if (Input.GetMouseButtonDown(0))
                {
                    if (!cooldownController.isCooldown())
                    {
                        if (Player.GetComponent<ManaController>().decreaseMana(SkillAttached.GetComponent<SkillClass>().manaCost))
                        {
                            isDrag = true;
                            SkillAttached.GetComponent<MonoBehaviour>().enabled = false;
                            SkillAttached.GetComponent<Collider2D>().enabled = false;

                            newSkill = (GameObject)Instantiate(SkillAttached, Vector3.zero, SkillAttached.transform.rotation);
                            newSkill.transform.position = Vector3.zero;
                            cooldownController.setCooldown(SkillAttached.GetComponent<SkillClass>().coolDown);
                        }
                    }
                }
                break;
            case ClassHolder.Activated:
                    if (newSkill)
                    {
                        Destroy(newSkill, newSkill.GetComponent<SkillClass>().lifetime);
                        cooldownController.setCooldown(0.1f);

                    }
                else
                {
                    newSkill = (GameObject)Instantiate(SkillAttached, Vector3.zero, SkillAttached.transform.rotation);
                    newSkill.transform.position = Vector3.zero;
                    newSkill.GetComponent<MonoBehaviour>().enabled = true;
                    newSkill.GetComponent<Collider2D>().enabled = true;
                    cooldownController.setCooldown(10000f);
                }

                break;
            default:
                break;
        }

    }

    public void onOut()
    {
        switch (holderType)
        {
            case ClassHolder.Draggable:
                if (isDrag)
                {
                    newSkill.GetComponent<MonoBehaviour>().enabled = true;
                    newSkill.GetComponent<Collider2D>().enabled = true;
                    isDrag = false;
                    Destroy(newSkill, newSkill.GetComponent<SkillClass>().lifetime);
                }
                break;
            case ClassHolder.Activated:
                break;
            default:
                break;
        }
    }

    void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	    if (isDrag)
        {
            newSkill.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, -5f);
        }
	}

    /*
    void OnMouseEnter()
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
                        buttonPressed = true;
                        CopyButton = Instantiate(gameObject);

                    }

                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Entre a GetMouseDown");
                Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (_objTouched != null)
                {
                    if (_objTouched.GetInstanceID() == gameObject.GetComponent<Collider2D>().GetInstanceID())
                    {
                        buttonPressed = true;
                        CopyButton = Instantiate(gameObject);

                    }

                }
            }
        }
    }*/
    }
