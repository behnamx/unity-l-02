using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Meteor meteor = other.gameObject.GetComponent<Meteor>();
        if (meteor != null)
        {
            meteor.OnDestroy();
        }
    }


}
