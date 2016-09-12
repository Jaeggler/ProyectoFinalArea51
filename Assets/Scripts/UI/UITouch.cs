using UnityEngine;
using System.Collections;


public class UITouch : MonoBehaviour {
    public bool UIClicked = false;
    private ArrayList _clickedList;
	// Use this for initialization
	void Start () {
        _clickedList = new ArrayList();
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
            _clickedList.Remove(gameObject);
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
