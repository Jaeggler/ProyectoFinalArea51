using UnityEngine;
using System.Collections;


public class UITouch : MonoBehaviour {
    public bool UIClicked = false;
    ArrayList _clickedList = new ArrayList();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onEnterUI()
    {
        Debug.Log("On Enter UI");
            _clickedList.Add(gameObject);
        if (_clickedList.Count > 0)
            {
                UIClicked = true;
            }
            else
            {
                UIClicked = false;
            }
        
    }

    public void onExitUI()
    {
        Debug.Log("On Exit UI");
            if (gameObject)
            {
                _clickedList.Remove(gameObject);
            }

            if (_clickedList.Count > 0)
            {
                UIClicked = true;
            }
            else
            {
                UIClicked = false;
            }
        
    }
}
