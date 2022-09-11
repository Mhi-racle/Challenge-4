using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;

    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private SpawnManagerX spawnManagerX;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        //finds the playerGoal and stores it in the variable
        playerGoal = GameObject.Find("Player Goal");

        //finds the SpawnManager script and sets it into the variable
        spawnManagerX = FindObjectOfType<SpawnManagerX>();

        //sets the speed to the spawnManager's speed
        speed = spawnManagerX.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
