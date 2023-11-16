using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   
    public float speed;
    public Transform[] waypoints;
    public float waitTime;

    private int dir = 1;
    private int index;
    private bool wait;
    private float timer;

    // Update is called once per frame
    void Update()
    {

        if(wait){
            CountWaitTime();
            return;
        }

        ChangeWaypoints();

        Moving();

    }


    void Moving(){
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);

    }

    void ChangeWaypoints(){
        float distance = Vector2.Distance(transform.position, waypoints[index].position);
        if(dir>0 && distance <=0){
            index++;
            if(index >= waypoints.Length){
                index=waypoints.Length -1;
                dir = -1;
                wait = true;
            }
        }else if(dir <0 && distance <=0){
            index--;
            if(index < 0){
                index = 0;
                dir = 1;
                wait = true;
            }
        }
    }

    void CountWaitTime(){
        timer += Time.deltaTime;
            if(timer >= waitTime){
                wait = false;
                timer =0;
            }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(null);
        }
    }

}
