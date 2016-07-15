using UnityEngine;
using System.Collections;

public class DummyStatus : MonoBehaviour {

	//Variables publicas para la vida.
	public int startingHealth;
	[HideInInspector] public int currentHealth;

	//Cargamos el componente BoxCollider2D en una variable para usarla posteriormente
	BoxCollider2D BoxCol2D;



	void Awake () {
		currentHealth = startingHealth;
		BoxCol2D = GetComponent<BoxCollider2D> ();
	}
	

	void Update () {
		Death ();
	
	}

	//Funcion para tomar dano que es llamada por el ataque del atacante.
	public void takeDamage(int amount){
		currentHealth -= amount;
		Debug.Log (currentHealth);
	}

	//Funcion para muerte del character. Se utilizara un sistema de reduccion de BoxCollider2D para que
	//la funcion OnCollisionExit2D del atacante sea dispare.
	void Death(){

		//variables y vector2 para definir la reduccion del BoxCol2D.
		float siz1 = 0.5f;
		float siz2 = 0.5f;
		Vector2 BoxColSize = new Vector2 (siz1, siz2);
		if (currentHealth == 0) {

			//Reducimos el tamano del BoxCollider para que se active el OnColliderExit del atacante.
			BoxCol2D.size = BoxColSize;

			//Destruimos el objeto con un pequeno delay para que la reduccion de collider sea efectiva.
			Destroy(gameObject,0.1f);
		}
		
	}
}
