using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class VRCamera : MonoBehaviour
{ // flag to keep track whether we are dragging or not
    public  bool isDragging = false;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // starting point of a camera movement
    float startMouseX;
    float startMouseY;

    // Camera component
    public  Camera cam;
    public GameObject stadiumtext;
    // Start is called before the first frame update
    void Start()
    {
        // Get our camera component
        cam = this.gameObject.GetComponent<Camera>();
        // stadiumtext = this.gameObject.GetComponent<Plane>();
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();

    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A)) {
            SceneManager.LoadScene("loganpark");
        }

        float xAxisValue = Input.GetAxis("Vertical");
        float zAxisValue = Input.GetAxis("Horizontal");
        if (Camera.current != null)
        {
            Camera.current.transform.Rotate(new Vector3(xAxisValue, zAxisValue, 0.0f));
        }
		    
        // if we press the left button and we haven't started dragging
        if(Input.GetMouseButtonDown(0) && !isDragging )
        {                
            // set the flag to true
            isDragging = true;

            // save the mouse starting position
            startMouseX = Input.mousePosition.x;
            startMouseY = Input.mousePosition.y;
        }
        // if we are not pressing the left btn, and we were dragging
        else if(Input.GetMouseButtonUp(0) && isDragging)
        {                
            // set the flag to false
            isDragging = false;
        }

       
        // Vector3 viewPos = cam.WorldToViewportPoint(stadiumtext.position);
        // Debug.Log(viewPos);
        // if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        // {
        //     Debug.Log("yay");
        // }
        // else
        // {
        //     Debug.Log("Nooo!");
        // }
    }

    void LateUpdate()
    {
        // Check if we are dragging
         if(isDragging)
        {
            //Calculate current mouse position
            float endMouseX = Input.mousePosition.x;
            float endMouseY = Input.mousePosition.y;

            //Difference (in screen coordinates)
            float diffX = endMouseX - startMouseX;
            float diffY = endMouseY - startMouseY;

            //New center of the screen
            float newCenterX = Screen.width / 2 + diffX;
            float newCenterY = Screen.height / 2 + diffY;

            //Get the world coordinate , this is where we want to look at
            Vector3 LookHerePoint = cam.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, cam.nearClipPlane));

            //Make our camera look at the "LookHerePoint"
            transform.LookAt(LookHerePoint);

            //starting position for the next call
            startMouseX = endMouseX;
            startMouseY = endMouseY;
        }
    }
}