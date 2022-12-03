using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour


{
    public static bool reset = false;
    public static bool isDead = false;

    public float speed;
    public float jump;
    public ParticleSystem dust;
    public ParticleSystem superJump;
    public ParticleSystem superDash;
    public float gravityMod;
    public float jumpBoost;
    public float dashDuration;
    public float dashMultiplier;
    public Transform restart_position;
    public ParticleSystem deadEffect;


    // private attributes
    private CharacterController control;
    private Vector3 direction;
    private float currentJump;
    private float regularJumpHeight;
    private float superJumpHeight;
    private float graceTime = 0.15f;
    private float jumpTimer = -1f;
    private float superJumpTimer = -1f;
    private bool inRedCollision;
    private bool dashState;
    private bool hasJumped;
    private float dashDurationRemaining = 0;
    private float currentDashMultiplier = 1;

    void Start()
    {
        if (GetComponent<CharacterController>() != null)
        {
            control = GetComponent<CharacterController>();
        }
        else
        {
            control = gameObject.AddComponent<CharacterController>();
        }
        currentJump = Mathf.Sqrt(-2.0f * jump * Physics.gravity.y * gravityMod);
        StopRedEffect();
        StopBlueEffect();
        hasJumped = false;
        superJumpTimer = -graceTime;
        superJumpHeight = Mathf.Sqrt(-2.0f * jump * jumpBoost * Physics.gravity.y * gravityMod);
        regularJumpHeight = Mathf.Sqrt(-2.0f * jump * Physics.gravity.y * gravityMod);
    }

    // Update is called once per frame
    void Update()
    {
        //if player is dead, no update
        if (isDead)
        {
            return;
        }
        // super jump logic
        if (inRedCollision)
        {
            superJumpTimer = Time.time;
        }
        if (superJumpTimer + graceTime >= Time.time)
        {
            currentJump = superJumpHeight;
        }
        else
        {
            currentJump = regularJumpHeight;
        }

        // dash state code
        if (dashState)
        {
            dashDurationRemaining = dashDuration;
            dashState = false;
        }

        if (dashDurationRemaining > 0)
        {
            if (!superDash.isPlaying)
            {
                CreateDashEffect();
            }
            currentDashMultiplier = dashMultiplier;
            dashDurationRemaining -= Time.deltaTime;
        }
        //dashstate expires on landing & timeout
        else if (dashDurationRemaining <= 0 && control.isGrounded)
        {
            if (!superDash.isStopped)
            {
                StopBlueEffect();
            }
            currentDashMultiplier = 1;
            dashDurationRemaining = 0;
        }

        //check the grace time
        if (!control.isGrounded && jumpTimer < 0)
        {
            jumpTimer = Time.time;
        }

        // Jumps if key is pressed else reset downwards velocity
        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetButtonDown("Jump")) && (control.isGrounded || (jumpTimer > 0 && Time.time < (jumpTimer + graceTime)) && !hasJumped))
        {
            direction.y = currentJump;
            createDust();
            //call the jump audio
            AudioManger.audioManger.JumpAudio();
            //check if the jump is super jump
            if (currentJump == superJumpHeight)
            {
                CreateSuperJumpEffect();
            }
            hasJumped = true;
        }
        else if (control.isGrounded)
        {
            hasJumped = false;
            direction.y = -15;
            jumpTimer = -1f;
            StopRedEffect();
        }

        // Horizontal velocity
        
        direction = new Vector3(Input.GetAxisRaw("Horizontal") * speed * currentDashMultiplier, direction.y, direction.z);
        
        if (Input.GetAxisRaw("Horizontal") != 0 && control.isGrounded)
        {
            createDust();
            //StopEffect();
        }

        // apply gravity
        direction.y = direction.y + (Physics.gravity.y * gravityMod * Time.deltaTime);

        // move player
        control.Move(direction * Time.deltaTime);

        inRedCollision = false;
    }
        

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Vector3.Dot(hit.normal, Vector3.down) > 0.8 && direction.y > 0 && !hit.collider.isTrigger)
        {
            direction.y = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "redObject")
        {
            inRedCollision = true;
        }
        if (other.gameObject.tag == "blueObject")
        {
            this.dashState = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            UIController.win = true;
        }
        if (other.gameObject.tag == "hazard")
        {
            playerDeath();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "redObject")
        {
            currentJump = Mathf.Sqrt(-2.0f * jump * Physics.gravity.y * gravityMod);
        }
    }

    void createDust()
    {
        dust.Play();
    }
    void CreateSuperJumpEffect()
    {
        superJump.Play();
    }

    void CreateDashEffect()
    {
        superDash.Play();
    }
    void StopRedEffect()
    {
        superJump.Stop();
    }

    void StopBlueEffect()
    {
        superDash.Stop();
    }

    public CharacterController getControl()
    {
        return control;
    }

    public void TurnoffReset()
    {
        reset = false;
    }

    public void playerDeath()
    {

        dashDurationRemaining = 0;
        StopRedEffect();
        StopBlueEffect();
        if (!isDead)
        {
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            
            this.transform.Translate(new Vector3(0,-999));
            if (!reset)
            {
                reset = true;
                this.transform.SetParent(null);
                Invoke("TurnoffReset", 1);
            }
            Invoke("death", 1.1f);


            isDead = true;
        }
        
    }

    public void death()
    {


        control.enabled = false;
        transform.position = new Vector3(restart_position.position.x, restart_position.position.y,
            restart_position.position.z);
        transform.SetParent(null);
        direction = new Vector3(0, 0, 0);
        control.enabled = true;
        isDead = false;

    }




}