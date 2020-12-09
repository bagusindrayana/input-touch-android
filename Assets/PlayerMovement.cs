using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{	
	public NavMeshAgent playerAgent;
	public GameObject paket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Application.platform == RuntimePlatform.Android){
        	if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject())
	        {
	            Touch touch = Input.GetTouch(0);

	       
	            if (touch.phase == TouchPhase.Began)
	            {
	                Vector2 pos = touch.position;
	                setTujuanAgent(pos);
	            }
	        }
        	
    	} else {

    		if(Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject()){
    			setTujuanAgent(Input.mousePosition);
    		}
    	}

        

    }

    public void setTujuanAgent(Vector3 pos){
    	RaycastHit hit;
        Ray raycast = Camera.main.ScreenPointToRay (pos);
        if (Physics.Raycast(raycast, out hit, 100f))
        {
        	playerAgent.SetDestination(hit.point);
        	playerAgent.Resume();
        }
    }

    public void taruhPaket(){
    	Instantiate(paket,transform.position,transform.rotation);
    }
}
