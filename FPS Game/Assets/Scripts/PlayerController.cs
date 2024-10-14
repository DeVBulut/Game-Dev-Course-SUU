using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : CharacterBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private GameObject _failureWindow;
    [SerializeField] private TextMeshProUGUI _healthUIText;
    private void Awake()
    {
        Instance = this;
        Debug.Log("Starting player");
    }
    private void Update()
    {
        _healthUIText.text = "Health: " + _currentHealth + "/" + _maxHealth; 
    }
    public override void Die()
    {
        _failureWindow.SetActive(true);
        GetComponent<PlayerMovementBehaviour>().enabled = false;
        GetComponent<PlayerWeaponBehaviour>().enabled = false;
        GetComponentInChildren<CameraController>().enabled = false;
    }
}
