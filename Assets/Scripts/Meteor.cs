using UnityEngine;
using System.Collections.Generic;

public class Meteor : MonoBehaviour {

    public Cannon cannon;
    public float lifeDuration = 5;
    private float curLife;
    public new Rigidbody2D rigidbody;

    public List<Planet> allPlanets;



    void Awake()
    {
        curLife = lifeDuration;
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    void Start()
    {
        allPlanets = new List<Planet>(FindObjectsOfType<Planet>());
    }

    // Update is called once per frame
    void Update ()
    {
        curLife -= Time.deltaTime;
        if (curLife < 0f)
        {
            OnDestroy();
        }
	}

    public void OnDestroy()
    {
        cannon.canFire = true;
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        foreach (Planet p in allPlanets)
        {
            Vector2 pMinusM = p.transform.position - transform.position;
            float distanceKM = pMinusM.magnitude * 20000; //converts the distance from Unity units to Km
            float gAcceleration = (6.674e-11f * p.mass) / (distanceKM * distanceKM); //acceleration due to gravity
            rigidbody.velocity += (pMinusM.normalized * gAcceleration * Time.fixedDeltaTime) / 20000;

        }
    }
}
