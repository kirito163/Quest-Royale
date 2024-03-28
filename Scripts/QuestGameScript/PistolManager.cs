using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using UnityEngine.InputSystem;


public class PistolManager : MonoBehaviour
{
    public GameObject leftRay;
    public GameObject rightRay;

    public InputActionProperty leftInputController;
    public InputActionProperty rightInputController;
    public Transform rightPos;
    public Transform leftPos;
    public ToggleGroup toggleGroup;
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    private float lastShot;
    public float shootDelay = 0.2f;
    AudioSource fireAudio;


    // Start is called before the first frame update
    void Start()
    {
        fireAudio = this.gameObject.GetComponent<AudioSource>();
        if (Dropdown.isPistoRighHand)
        {
            rightRay.SetActive(false);
            this.gameObject.transform.position = rightPos.position;
            this.gameObject.transform.parent = rightPos;
        }
        else
        {
            leftRay.SetActive(false);
            this.gameObject.transform.position = leftPos.position;
            this.gameObject.transform.parent = leftPos;

        }
    }


    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private void shoot()
    {
        if(lastShot >= Time.time) return;
        lastShot = Time.time + shootDelay;
        if (!toggleGroup.ActiveToggles().FirstOrDefault())
        {
            if ((Dropdown.isPistoRighHand && rightInputController.action.IsPressed())
            || (!Dropdown.isPistoRighHand && leftInputController.action.IsPressed()))
            {
                fireAudio.Play();
                GameObject spawnedBullet = Instantiate(bullet);
                spawnedBullet.transform.position = spawnPoint.position;
                spawnedBullet.transform.rotation = spawnPoint.rotation;
                spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.up * fireSpeed;
                Destroy(spawnedBullet, 3);
            }

        }

    }
}
