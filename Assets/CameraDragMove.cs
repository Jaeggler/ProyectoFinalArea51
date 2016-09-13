using UnityEngine;
using System.Collections;

public class CameraDragMove : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;
        UITouch _uiController;

    void Start()
    {
        _uiController = GameObject.Find("UIController").GetComponent<UITouch>();
        ResetCamera = Camera.main.transform.position;
    }
    public bool IsUIInput()
    {
        return _uiController.UIClicked;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !IsUIInput())
        {
            print("Mouse Down");
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("Mouse Up");

            Drag = false;
        }
        if (Drag == true)
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            print("Valor en Y " + (Origin - Diference).y);
            print("Valor en X " + (Origin - Diference).x);

            if ((Origin - Diference).x > 0 || (Origin - Diference).x < -50)
            {

            }
            else
            {
                Vector3 newPos = Origin - Diference;
                newPos.y = 0;
                Camera.main.transform.position = newPos;
            }
        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = ResetCamera;
        }
    }
}
