using UnityEngine;
using System.Collections;

public class itemController : MonoBehaviour
{
    public float _itemValue = 0;
    public int _itemType = 0;
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
        if (Input.GetMouseButtonDown(0))
        {
            BloodController _playerBlood = GameObject.FindGameObjectWithTag("Player").GetComponent<BloodController>();
            Debug.Log(_playerBlood.currentBlood);
            _playerBlood.incrementBlood(10f);
            Destroy(gameObject, 0.01f);
        }

    }
}