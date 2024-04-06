using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayer : MonoBehaviour
{
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject drone;

    [SerializeField] private Image pistolSprite;
    [SerializeField] private Image shotgunSprite;
    [SerializeField] private Image weaponUI;

    private bool hasPistol = false;
    private bool hasShotgun = false;
    private bool hasDrone = false;

    private bool isUsingPistol = true;
    private void Awake()
    {
        hasPistol = PlayerPrefs.GetInt("hasPistol") == 1;
        hasShotgun = PlayerPrefs.GetInt("hasShotgun") == 1;
        hasDrone = PlayerPrefs.GetInt("hasDrone") == 1;
    }

    private void Start()
    {
        if (hasPistol)
        {
            pistol.SetActive(true);
        }
        else if (hasShotgun)
        {
            shotgun.SetActive(true);
        }

        if (hasDrone)
        {
            drone.SetActive(true);
        }
    }

    private void ChangeToShotgun()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isUsingPistol)
            {
                pistol.SetActive(false); 
                shotgun.SetActive(true);
                weaponUI.sprite = pistolSprite.sprite;
                isUsingPistol = false;
            }
            else if (!isUsingPistol)
            {
                shotgun.SetActive(false);
                pistol.SetActive(true);
                weaponUI.sprite = shotgunSprite.sprite;
                isUsingPistol = true;
            }
            
        }
    }

    private void Update()
    {
        ChangeToShotgun();
    }
}
