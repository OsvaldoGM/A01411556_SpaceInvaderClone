using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeSin : MonoBehaviour {

    public GameObject projectile;
    private ScoreKeeper scoreKeeper;
    public float projectileSpeed = 10f;
    public float shotsPerSeconds = 0.5f;
    public AudioClip fireSound;
    private Rigidbody2D rgb;

    // Use this for initialization
    void Start () {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
	
	// Update is called once per frame
	void Update () {
        float probability = shotsPerSeconds * Time.deltaTime;

        //	If a random generated value is less than the computed shooting probability, then the enemy
        //	ship shoots a laser beam.
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        //	We instantiate the laser bean and give it a negative velocity in the y axis.  We offset the
        //	beam's position 1 unit below the enemy0s ship, because we do not want an instant collision
        //	between them.
        //	Vector3 startPosition = transform.position + new Vector3 (0, -1, 0);
        //	GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        rgb = missile.gameObject.GetComponent<Rigidbody2D>();
        rgb.velocity = new Vector2(0, -projectileSpeed);

        //	We play the fireSound Clip
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
