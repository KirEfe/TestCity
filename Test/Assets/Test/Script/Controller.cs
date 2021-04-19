using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed;
    public float rotSpeed;

    private CharacterController Control;
    private Animator Anim;


    // Start is called before the first frame update
    void Start()
    {
        Control = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 1)
        currentWP++;
        

        if (currentWP >= waypoints.Length)
            currentWP = 0;
        //this.transform.LookAt(waypoints[currentWP].transform);
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
        if (currentWP % 2 == 1)
            Anim.SetBool("Run", true);
        else
            Anim.SetBool("Run", false);

    }

   }
