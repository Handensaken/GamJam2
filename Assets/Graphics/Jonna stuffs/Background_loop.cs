using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_loop : MonoBehaviour{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = gameObject.GetCompontent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }
        
        void loadChildObjects(GameObject obj) {
        Debug.Log(obj.name);
        }

}
