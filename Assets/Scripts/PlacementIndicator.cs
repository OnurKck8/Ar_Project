using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;//zemini tespit eder
    private GameObject visual;//halka �ekli i�in

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        visual.SetActive(false);
    }

    void Update()
    {
        List<ARRaycastHit> hits= new List<ARRaycastHit>();
        aRRaycastManager.Raycast(new Vector2(Screen.width/2,Screen.height/2),hits,TrackableType.Planes);//ekran�n tam ortas�

        if(hits.Count>0)
        {
            transform.position = hits[0].pose.position;//pozunu e�itle
            transform.rotation = hits[0].pose.rotation;
            
            if(!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }
}
