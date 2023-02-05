using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class SkillsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI whipLvl;
    [SerializeField] private TextMeshProUGUI gunLvl;
    [SerializeField] private TextMeshProUGUI rotativeOrbeLvl;
    [SerializeField] private TextMeshProUGUI lightningLvl;
    [SerializeField] private TextMeshProUGUI shieldLvl;
    [SerializeField] private GameObject _playerSkills;

    private void Start()
    {
        if (_playerSkills == null) _playerSkills = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(2).gameObject;
    }

    public void LevelUpWhip()
    {
        _playerSkills.transform.GetChild(0).GetComponent<WhipController>().LevelUp();

        whipLvl.text = (int.Parse(whipLvl.text) + 1).ToString();        
        
        gameObject.SetActive(false);
        
    }
    
    public void LevelUpGun()
    {
        if(_playerSkills.transform.GetChild(2).GetComponent<GunController>().isActiveAndEnabled)
            _playerSkills.transform.GetChild(2).GetComponent<GunController>().LevelUp();
        else _playerSkills.transform.GetChild(2).GetComponent<GunController>().gameObject.SetActive(true);
        
        gunLvl.text = (int.Parse(gunLvl.text) + 1).ToString();     
        
        gameObject.SetActive(false);

    }    
    
    public void LevelUpRotativeOrbe()
    {
        if(_playerSkills.transform.GetChild(4).GetComponent<RotativeOrbeController>().isActiveAndEnabled)
            _playerSkills.transform.GetChild(4).GetComponent<RotativeOrbeController>().LevelUp();
        else _playerSkills.transform.GetChild(4).GetComponent<RotativeOrbeController>().gameObject.SetActive(true);
        
        rotativeOrbeLvl.text = (int.Parse(rotativeOrbeLvl.text) + 1).ToString();     

        gameObject.SetActive(false);

    }    
    
    public void LevelUpLightning()
    {
        if(_playerSkills.transform.GetChild(3).GetComponent<LightningController>().isActiveAndEnabled)
            _playerSkills.transform.GetChild(3).GetComponent<LightningController>().LevelUp();
        else _playerSkills.transform.GetChild(3).GetComponent<LightningController>().gameObject.SetActive(true);
        
        lightningLvl.text = (int.Parse(lightningLvl.text) + 1).ToString();     

        gameObject.SetActive(false);
    }    
    
    public void LevelUpShield()
    {
        if(_playerSkills.transform.GetChild(1).GetComponent<RepulsiveShieldController>().isActiveAndEnabled)
            _playerSkills.transform.GetChild(1).GetComponent<RepulsiveShieldController>().LevelUp();
        else _playerSkills.transform.GetChild(1).GetComponent<RepulsiveShieldController>().gameObject.SetActive(true);
        
        shieldLvl.text = (int.Parse(shieldLvl.text) + 1).ToString();     

        gameObject.SetActive(false);
    }

}
