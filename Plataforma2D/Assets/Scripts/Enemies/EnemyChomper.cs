using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChomper : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Flip By Time")]
    public bool flipByTime;
    public float flipTime = 3f;

    [Header("Attack")]
    public float attackRate;
    public float attackDistance;
    private Transform player;
    private float nextAttack;
    public AudioClip AttackSfx;

    public AudioClip[] footstepSfx;

    private Rigidbody2D rb;
    private bool onGround;
    private Animator anim;

    private AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        audioManager = GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(flipByTime)
            InvokeRepeating("Flip", flipTime, flipTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(flipByTime) return;


        onGround = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        
        
        if(!onGround){
            Flip();
        }

        CheckTarget();
    }

    void CheckTarget(){
        float distance = Vector2.Distance(transform.position, player.position);
        float dir = player.transform.position.x - transform.position.x;
        
        if(distance < attackDistance){
            if((speed < 0 && dir < 0) || (speed > 0 && dir > 0)){
                if(Time.time > nextAttack){
                    nextAttack = Time.time + attackRate;
                    anim.SetTrigger("Attack");
                    audioManager.PlayAudio(AttackSfx);
                }
            }
        }
    }

    private void FixedUpdate(){
        rb.velocity = Vector2.right * speed;

    }

    void Flip(){
        speed*=-1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Footsteps(){
        audioManager.PlayAudio(footstepSfx[UnityEngine.Random.Range(0, footstepSfx.Length)]);
    }

}
