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
    [SerializeField] private GameObject lizard;

    [SerializeField] private Image pistolSprite;
    [SerializeField] private Image shotgunSprite;
    [SerializeField] private Image weaponUI;

    private bool hasPistol = false;
    private bool hasShotgun = false;
    private bool hasDrone = false;
    private bool hasLizard = false;

    private bool isUsingPistol = true;

    private int lizardsNumber = 5;

    private Animator _animator;
    
    private void Awake()
    {
        hasPistol = PlayerPrefs.GetInt("hasPistol") == 1;
        hasShotgun = PlayerPrefs.GetInt("hasShotgun") == 1;
        hasDrone = PlayerPrefs.GetInt("hasDrone") == 1;
        hasLizard = PlayerPrefs.GetInt("hasLizard") == 1;
    }

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
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

    private void HideLizard()
    {
        lizard.SetActive(false);
    }

    private void EatLizard()
    {
        if (hasLizard && lizardsNumber > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            lizard.SetActive(true);
            _animator.SetTrigger("Eat");
            lizardsNumber--;
        }
    }

    private void Update()
    {
        ChangeToShotgun();
        EatLizard();
    }
}
