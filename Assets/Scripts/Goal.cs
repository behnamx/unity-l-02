using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour {

    // Use this for initialization

    public string nextLevel = null;

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
            if (nextLevel != null && nextLevel != "")
            {
                SceneManager.LoadScene(nextLevel);
            }
            meteor.OnDestroy(); //so if we don't load a level we keep playing the current one
        }
    }
}
