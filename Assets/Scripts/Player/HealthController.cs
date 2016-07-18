using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {


	//Variables de creación
	public int IdNum;

	//Variables publicas para la vida.
	public float currentHealth;
    private StatsController _stats;
    public Renderer healthBar;
    private GameObject _bloodPrefab;
    private bool alive;
    public float nowDefense;
    public float nowDodge;

    //Cargamos el componente BoxCollider2D en una variable para usarla posteriormente
    BoxCollider2D BoxCol2D;


	void Awake () {
		BoxCol2D = GetComponent<BoxCollider2D> ();
        _stats = GetComponent<StatsController>();
    }

    void Start()
    {
        alive = true;
        nowDefense = _stats.initDefense;
        nowDodge = _stats.initDodge;
        currentHealth = _stats.initHealth;
        _bloodPrefab = Resources.Load("Prefabs/BloodDrop") as GameObject;
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
        if (Random.Range(0.00f, 0.99f) < (1 - (nowDodge / 100))) //Aplicamos el Dodge
        {
            currentHealth -= amount * (1 - nowDefense / 100); //Aplicamos la defensa
        }
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

        if (currentHealth <= 0 && alive) {

            //Reducimos el tamano del BoxCollider para que se active el OnColliderExit del atacante.
            BoxCol2D.size = BoxColSize;
            alive = false;
            if (tag == "Enemy")
            {
                Vector3 newPos = transform.position;
                newPos.z = _bloodPrefab.transform.position.z;
                //Creamos el objeto blood que puede recoger el player con un click y le asignamos el valor de blood
                GameObject _bloodDrop = Instantiate(_bloodPrefab, newPos, transform.rotation) as GameObject;
                _bloodDrop.GetComponent<ItemController>()._itemValue = _stats.bloodDrop; //Setear cantidad de blood
                _bloodDrop.GetComponent<ItemController>()._itemType = 1; //Setear tipo Blood
            }

            //Destruimos el objeto con un pequeno delay para que la reduccion de collider sea efectiva.
            Destroy(gameObject,0.1f);

		}

	}

}
