﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    private GameObject camera;

    private float NextAttack;

    [Tooltip("The prefab used for the bullet")]
    [SerializeField]
    GameObject BulletPrefab;

    [Tooltip("The speed that the bullet goes when being fired")]
    [Range(1000f, 5000f)]
    [SerializeField]
    float shotSpeed;


    private Animator anim;

    #region MonoBehaviours
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            camera.GetComponent<Camera>().thirdPersonCamera = false;
            PlayAnimation("Aiming");
        }
        if (Input.GetMouseButtonUp(1))
        {
            camera.GetComponent<Camera>().thirdPersonCamera = true;
            StopAnimation("Aiming");
        }

        if (Input.GetMouseButtonDown(0) && NextAttack <= 0)
        {
            Attack();
        }

        NextAttack -= Time.deltaTime;
    }
    #endregion


    void PlayAnimation(string animName)
    {
        anim.SetBool(animName, true);
    }
    void StopAnimation(string animName)
    {
        anim.SetBool(animName, false);
    }
    void Attack()
    {
        if (!camera.GetComponent<Camera>().thirdPersonCamera)
        {
            GameObject tempbul = Instantiate(BulletPrefab, camera.transform.position, camera.transform.rotation);
            tempbul.GetComponent<Rigidbody>().AddForce(tempbul.transform.forward * shotSpeed);
        }
        NextAttack = 1f;
    }
}
