using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    int hp = 10;

    GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if(hp> 0)
        {
            bool seesPlayer = false;
            bool hearsPlayer = false;

            RaycastHit hit;
            //wektor prowadz¹cy od zombiaka do gracza
            Vector3 playerVector = player.transform.position - transform.position;

            //testowy raycast
            //Debug.DrawRay(transform.position, playerVector, Color.yellow);

            //"wzrok" zombiaka
            Physics.Raycast(transform.position, playerVector, out hit);
            if (hit.collider.gameObject.CompareTag("Player"))
                seesPlayer = true;

            //znajdz wszystkow w promieniu 5m
            Collider[] nearby = Physics.OverlapSphere(transform.position, 5f);
            foreach (Collider collider in nearby)
            {
                if (collider.transform.CompareTag("Player"))
                {
                    hearsPlayer = true;
                }
            }

            if (seesPlayer || hearsPlayer)
            {
                agent.destination = player.transform.position;
                agent.isStopped = false;
            }
            else
            {
                agent.isStopped = true;
            }
        }
        
    }
    public void ReciveDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            //transform.Translate(Vector3.up);
            //transform.Rotate(Vector3.right * -90);
            //transform.GetComponent<BoxCollider>().enabled = false;
            //transform.gameObject.tag = "Untagged";
            //Destroy(transform.gameObject, 10);
            Destroy(gameObject);
        }
    }
}
