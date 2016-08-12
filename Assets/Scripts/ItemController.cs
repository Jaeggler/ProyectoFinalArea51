using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    public float _itemValue = 0;
    public int _itemType = 0;
    private RuntimePlatform platform = Application.platform;

    /*
     * ItemType representa el tipo de variable que sera afectada por el valor.
     * ItemType 1 = Blood
     * ItemType 2 = Mana
    */
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "blood")
            {
                Debug.Log("Success");
            }
        }
        */
    }

    void OnMouseOver()
    {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Collider2D _objTouched = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            if (_objTouched != null)
            {
                Debug.Log(_objTouched.name);
                Debug.Log("Obj Touched "+ _objTouched.GetInstanceID());
                Debug.Log("My object "+gameObject.GetComponent<Collider2D>().GetInstanceID());
                if (_objTouched.GetInstanceID() == gameObject.GetComponent<Collider2D>().GetInstanceID())
                {
                    BloodController _playerBlood = GameObject.FindGameObjectWithTag("Player").GetComponent<BloodController>();
                    Debug.Log(_playerBlood.currentBlood);
                    _playerBlood.incrementBlood(10f);
                    Destroy(gameObject, 0.01f);

                }

            }
        }

    }
}


/* Este codigo parece util
 using UnityEngine;
 using System.Collections;
 
 public class OnTouch : MonoBehaviour
{
    private RuntimePlatform platform = Application.platform;

    void Update()
    {
        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
        }
    }

    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {
            hit.transform.gameObject.SendMessage("Clicked", 0, SendMessageOptions.DontRequireReceiver);
        }
    }
}

*/