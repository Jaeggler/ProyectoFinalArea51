using UnityEngine;
using System.Collections;


public class MovementController : MonoBehaviour {

	public float nowSpeed;
	Rigidbody2D rb2D;
    StatsController _stats;



    // Use this for initialization
    void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
        _stats = GetComponent<StatsController>();
    }

    void Start()
    {
        nowSpeed = _stats.initSpeed;
    }

    // Update is called once per frame
    void LateUpdate () {
		movement ();
	}

	// Función que controla el movimiento del personaje.
	void movement () {
        if (_stats.status == "Motion")
        {
            Vector2 movimientolateral = new Vector2(nowSpeed, 0);
            rb2D.velocity = movimientolateral;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }
		
}
