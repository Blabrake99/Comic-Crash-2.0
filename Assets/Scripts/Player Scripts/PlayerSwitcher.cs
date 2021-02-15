﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] CharactersToSwitchTo = new GameObject[10];
    [SerializeField]
    Transform PlayerTransform;
    GameObject Camera;
    [SerializeField]
    GameObject CurrentPlayer;
    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };
    // Start is called before the first frame update
    void Awake()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                SwitchCharacter(i);
            }
        }

    }
    void SwitchCharacter(int i)
    {

        if (i + 1 <= CharactersToSwitchTo.Length)
        {
            GameObject Temp = Instantiate(CharactersToSwitchTo[i],
                PlayerTransform.position, PlayerTransform.rotation);

            PlayerTransform = Temp.transform;

            Camera.GetComponent<Camera>().target = Temp.transform;
            Destroy(CurrentPlayer);
            CurrentPlayer = Temp;

        }
    }
}
