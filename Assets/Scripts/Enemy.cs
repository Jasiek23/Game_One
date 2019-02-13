 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed = 6.0f; // Enemy rotation speed
    public bool softRotation = false; // rotation of enemy

    public float enemySpeed = 5.0f; // Speed of enemy
    public float enemyDistance = 30f; //Distance from enemy to player when enemy starts move
    public float distanceFromPlayer = 2f; // Distance when enemy stops next to player

    private Transform enemyObject;
    private Transform playerObject;
    private bool lookAtPlayer = false;
    private Vector3 playerPositionXYZ;

    void Start()
    {
        enemyObject = transform;

        if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Update()
    {
        playerObject = GameObject.FindWithTag("Player").transform; // Player object
        playerPositionXYZ = new Vector3(playerObject.position.x, enemyObject.position.y, playerObject.position.z); // Player position
        float dist = Vector3.Distance(enemyObject.position, playerObject.position); // distance between player and enemy

        lookAtPlayer = false; 

        if(dist<= enemyDistance && dist>distanceFromPlayer && !isDead()) //check the distance between player and enemy
        {
            lookAtPlayer = true;

            enemyObject.position = Vector3.MoveTowards(enemyObject.position, playerPositionXYZ, enemySpeed * Time.deltaTime); // Vector3.MoveTowards - new position of enemy (first parameter - current position, second parameter -the position to which we aspire, third parameter - speed) 
        }
        else if(dist <= distanceFromPlayer && isDead())
        {
            lookAtPlayer = true;
        }

        if (!isDead())
        {
            lookAtMe();
        }
        else
        {
            if(GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
    }

    public void lookAtMe()
    {
        if(softRotation && lookAtPlayer == true)
        {
            Quaternion rotation = Quaternion.LookRotation(playerPositionXYZ - enemyObject.position);
        }
        else if(!softRotation && lookAtPlayer == true)
        {
            transform.LookAt(playerPositionXYZ);
        }
    }

    bool isDead()
    {
        Healthly h = gameObject.GetComponent<Healthly>();
        if(h != null)
        {
            return h.ifDead();
        }
        return false; 
    }
}
