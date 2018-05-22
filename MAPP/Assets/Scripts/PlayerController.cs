using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidbody2d;
    public SpringJoint2D joint;
    public Vector2 playerpos;
    public GameObject hook;

    public float jumpHeight;
    public float pullSpeed = 1f;

    public float kickBackDistance = 2f;

    public float minimumDistance = 1f;
    public float maximumDistance = 50f;

    public float thrust;

    private AudioSource audioSource;
    public AudioClip collideSound;
    public AudioClip missSound;
    public AudioClip jumpSound;

    public float countdownTime = 3.0f;
    public bool countdownDone;

    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public float fireRate = 0.8F;
    public float nextFire = 0.0F;
    public float fireRate2 = 0.3F;
    public float nextFire2 = 0.0F;
    public Vector3 particlePos;


    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        // Safetycheck, makes sure a reference to joint exists
        if (joint == null)
        {
            joint = this.GetComponent<SpringJoint2D>();
        }

        if (rigidbody2d == null)
        {
            rigidbody2d = this.GetComponent<Rigidbody2D>();
        }

        // Resets joint.distance
        joint.distance = 0;

        transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
        StartCoroutine("Countdown");
    }

    void Update()
    {

        if (!countdownDone)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
        }

        // Throw hook on mouseButtonDown
        if (Input.GetMouseButtonDown(0))
        {
            if(!countdownDone)
            {
                return;
            }

            if (Time.time > nextFire)
            {
                //particle1.Play();
                nextFire = Time.time + fireRate;
            }

            if (!joint.enabled)
            {

                joint.distance = 250;

                DestroyGrappleHooks();


                Instantiate(hook, transform.position, Quaternion.identity);



            }
            else
            {
                DestroyGrappleHooks();
                DisableJoint();

                rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
        }


        GameObject hooks = GameObject.FindGameObjectWithTag("GrappleHook");

        if (hooks != null)
        {
            if (hooks.GetComponent<Rope>().hooked)
            {
                if (joint.distance < minimumDistance)
                {
                    DestroyGrappleHooks();
                    DisableJoint();
                }

                if (Vector2.Distance(hooks.transform.position, transform.position) > 0.5f && (Time.time > nextFire2))
                {
                    particlePos = hooks.transform.position;
                    Instantiate(particle3, particlePos, Quaternion.identity);
                    nextFire2 = Time.time + fireRate2;
                }


            }
            else
            {
                if (Vector2.Distance(hooks.transform.position, transform.position) > maximumDistance)
                {
                    DestroyGrappleHooks();
                    DisableJoint();
                    audioSource.PlayOneShot(missSound);
                }



            }
        }

        PullPlayerToHook();
    }

    void FixedUpdate()
    {
        rigidbody2d.AddForce(rigidbody2d.GetRelativePointVelocity(transform.position) * thrust);
    }

    public void SetDistance()
    {
        if (Vector2.Distance(joint.connectedAnchor, transform.position) > kickBackDistance)
        {
            joint.distance = Vector2.Distance(joint.connectedAnchor, transform.position);

        }
        else
        {
            joint.distance = kickBackDistance;
            audioSource.PlayOneShot(jumpSound, 0.5f);

            GameObject hooks = GameObject.FindGameObjectWithTag("GrappleHook");
            particlePos = hooks.transform.position;
            Instantiate(particle2, particlePos, Quaternion.identity);
        }

    }


    private void DisableJoint()
    {
        joint.enabled = false;
    }

    public void EnableJoint()
    {
        joint.enabled = true;
    }

    private void PullPlayerToHook()
    {

        // Reduces joint.distance over time
        // Meant to pull the player towards the hook
        joint.distance -= pullSpeed * Time.deltaTime;

    }

    public void DestroyGrappleHooks()
    {

        GameObject[] oldGrappleHooks;
        oldGrappleHooks = GameObject.FindGameObjectsWithTag("GrappleHook");

        GameObject oldLine = GameObject.Find("Line");
        Destroy(oldLine);

        foreach (GameObject oldGrappleHook in oldGrappleHooks)
        {

            Destroy(oldGrappleHook);

        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        audioSource.PlayOneShot(collideSound, 1f);

    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(countdownTime +0.1f);
        countdownDone = true;
        rigidbody2d.velocity = new Vector2(PlayerPrefs.GetFloat("xVel"), PlayerPrefs.GetFloat("yVel"));
    }

}
