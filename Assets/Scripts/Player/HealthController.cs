using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {


	//Variables de creación
	public int IdNum;

	//Variables publicas para la vida.
	public float currentHealth;
    private StatsController _stats;
    public Renderer healthBar;

	//Cargamos el componente BoxCollider2D en una variable para usarla posteriormente
	BoxCollider2D BoxCol2D;


	void Awake () {
		BoxCol2D = GetComponent<BoxCollider2D> ();
        _stats = GetComponent<StatsController>();
    }

    void Start()
    {
        currentHealth = _stats.initHealth;
        if (healthBar)
        {
            healthBar.material.SetFloat("_Progress", currentHealth / _stats.initHealth);
        }
    }
    // Update is called once per frame
    void Update () {
		checkDeath ();
	}

	//Funcion para tomar dano que es llamada por el ataque del atacante.
	public void takeDamage(float amount){
		currentHealth -= amount;
        if (healthBar)
        {
            healthBar.material.SetFloat("_Progress", currentHealth / _stats.initHealth);
        }
    }

    //Funcion para muerte del character. Se utilizara un sistema de reduccion de BoxCollider2D para que
    //la funcion OnCollisionExit2D del atacante sea dispare.
     void checkDeath(){

		//variables y vector2 para definir la reduccion del BoxCol2D.
		float siz1 = 0.1f;
		float siz2 = 0.1f;
		Vector2 BoxColSize = new Vector2 (siz1, siz2);
		if (currentHealth <= 0) {

			//Reducimos el tamano del BoxCollider para que se active el OnColliderExit del atacante.
			BoxCol2D.size = BoxColSize;

			//Destruimos el objeto con un pequeno delay para que la reduccion de collider sea efectiva.
			Destroy(gameObject,0.1f);
		}

	}

}
