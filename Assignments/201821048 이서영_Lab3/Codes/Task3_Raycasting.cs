using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3_Raycasting : MonoBehaviour
{
    public float range = 200;
    public LayerMask shootableMask;

    private bool isSplit = false;
    public GameObject SplitEnemy;
    public GameObject SplitEnemy_prefab;
    //private float half = -0.5f;
    private Vector3 scaleChange = new Vector3(-0.5f, -0.5f, -0.5f);
    private Vector3 positionChange;

    private bool isBomb = false;
    public GameObject BombEnemy;
    public float bomb_radius = 50.0F;
    public float bomb_power = 200.0F;
    public float bomb_lift = 30;

    private bool isSpecial = false;
    public GameObject SpecialEnemy;

    private AudioSource audioSource;
    public AudioClip gun_default;
    public AudioClip gun_1;
    public AudioClip gun_2;
    public AudioClip gun_3;

    private GameObject gobj;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // play sound when the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.clip = gun_default;
            audioSource.Play();
        }

        // Create a ray using the mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }

        // when the mouse is pressed and raycast hits a target...
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, range, shootableMask))
        {
            Debug.Log("The ray hit: " + hit.collider.gameObject.name + ", " + hit.distance);

            if (hit.collider.gameObject.tag == "SplitEnemy")
            {
                Debug.Log("SplitEnemy");
                isSplit = true;
                audioSource.clip = gun_1;
                audioSource.Play();

                gobj = hit.collider.gameObject;
                
                Vector3 SplitPos = gobj.transform.position;
                Vector3 SplitSize = gobj.transform.localScale;
                Destroy(gobj);

                SplitEnemy = Instantiate(gobj, SplitPos, Quaternion.identity);
                SplitEnemy.transform.localScale -= new Vector3(SplitSize.x/2, SplitSize.y / 2, SplitSize.z / 2);
                SpecialEnemy.tag = "SplitEnemy";

                SplitEnemy = Instantiate(gobj, SplitPos, Quaternion.identity);
                SplitEnemy.transform.localScale -= new Vector3(SplitSize.x / 2, SplitSize.y / 2, SplitSize.z / 2);
                SpecialEnemy.tag = "SplitEnemy";

                SplitEnemy = Instantiate(gobj, SplitPos, Quaternion.identity);
                SplitEnemy.transform.localScale -= new Vector3(SplitSize.x / 2, SplitSize.y / 2, SplitSize.z / 2);
                SpecialEnemy.tag = "SplitEnemy";

                SplitEnemy = Instantiate(gobj, SplitPos, Quaternion.identity);
                SplitEnemy.transform.localScale -= new Vector3(SplitSize.x / 2, SplitSize.y / 2, SplitSize.z / 2);
                SpecialEnemy.tag = "SplitEnemy";


            }
            else if (hit.collider.gameObject.name == "BombEnemy")
            {
                Debug.Log("BombEnemy");
                isBomb = true;
                audioSource.clip = gun_2;
                audioSource.Play();


            }
            else if (hit.collider.gameObject.name == "SpecialEnemy")
            {
                Debug.Log("SpecialEnemy");
                audioSource.clip = gun_3;
                audioSource.Play();

                gobj = hit.collider.gameObject;
                Color _color;
                _color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
                gobj.GetComponent<Renderer>().material.color = _color;
            }
        }

    }


    void FixedUpdate()
    {
        if (isBomb)
        {
            // This gameobject's position is where the explosion happens (e.g. a bomb)
            Vector3 BombPos = BombEnemy.transform.position;
            // Get all colliders that are within the radius, and apply the explosion force on them.
            Collider[] colliders = Physics.OverlapSphere(BombPos, bomb_radius);
            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                    hit.GetComponent<Rigidbody>().AddExplosionForce(bomb_power, BombPos, bomb_radius, bomb_lift);
            }
            isBomb = false;
        }

        if (isSplit)
        {
        

            isSplit = false;
        }

      

    }
}
