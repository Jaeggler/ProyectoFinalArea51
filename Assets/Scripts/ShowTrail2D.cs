using UnityEngine;
using System.Collections;

public class ShowTrail2D : MonoBehaviour {
    TrailRenderer tr;

    // Use this for initialization
    void Start () {
        tr = GetComponent<TrailRenderer>();
        tr.sortingLayerName = "Player";
    }

    // Update is called once per frame
    void Update () {
	
	}
}
