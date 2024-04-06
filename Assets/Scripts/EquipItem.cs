using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject drone;
    [SerializeField] private GameObject lizard;

    private void Start()
    {
        PlayerPrefs.SetInt("hasPistol", 0);
        PlayerPrefs.SetInt("hasShotgun", 0);
        PlayerPrefs.SetInt("hasDrone", 0);
        PlayerPrefs.SetInt("hasLizard", 0);
    }

    public void EquipPistol()
    {
        pistol.SetActive(true);
        shotgun.SetActive(false);
        PlayerPrefs.SetInt("hasPistol", 1);
    }

    public void EquipShotgun()
    {
        shotgun.SetActive(true);
        pistol.SetActive(false);
        PlayerPrefs.SetInt("hasShotgun", 1);
    }

    public void EquipDrone()
    {
        drone.SetActive(true);
        PlayerPrefs.SetInt("hasDrone", 1);
    }

    public void EquipLizard()
    {
        lizard.SetActive(true);
        PlayerPrefs.SetInt("hasLizard", 1);
    }
}
