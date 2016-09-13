using UnityEngine;
using System.Collections;


public class MovementController : MonoBehaviour {

	public float nowSpeed;
	Rigidbody2D rb2D;
    StatsController _stats;
    private float distToGround;
    public LayerMask detectGroundMask;

    // Use this for initialization
    void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
        _stats = GetComponent<StatsController>();
    }

    void Start()
    {
        nowSpeed = _stats.initSpeed;
        distToGround = gameObject.GetComponent<Collider2D>().bounds.extents.y+0.1f;
    }

    // Update is called once per frame
    void LateUpdate () {
		movement ();
	}

    private bool IsGrounded(){
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround,detectGroundMask);
    }

// Función que controla el movimiento del personaje.
void movement () {
        switch (_stats.status)
        {       
            case StatsController.Status.Motion:
                if (IsGrounded())
                {
                    GetComponent<Light>().enabled = false;
                    Vector2 movimientolateral = new Vector2(nowSpeed, 0);
                    rb2D.velocity = movimientolateral;
                }
                break;
            case StatsController.Status.Battle:
                GetComponent<Light>().enabled = false;
                rb2D.velocity = Vector2.zero;
                break;
            case StatsController.Status.PushSkill:
                if (IsGrounded() && _stats.transitionTime<=0)
                {
                    _stats.status = StatsController.Status.Motion;
                }
                break;
            case StatsController.Status.StunSkill:
                if (IsGrounded() && _stats.transitionTime <= 0)
                {
                    _stats.status = StatsController.Status.Motion;
                }
                break;
            default:
                break;
        }
    }
		
}
