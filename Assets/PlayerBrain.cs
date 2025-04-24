using System;
using Tanks.Complete;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] TankShooting _shooting;

    InputAction _fireAction;
    InputAction _cancelAction;
    TankInputUser m_InputUser;
    
    void Start()
    {
        // On récupère la manette
        m_InputUser = GetComponent<TankInputUser>();
        _fireAction = m_InputUser.ActionAsset.FindAction("Fire");
        _cancelAction = m_InputUser.ActionAsset.FindAction("Cancel");
        
        // input
        _fireAction.started += StartShoot;
        _fireAction.canceled += StopShoot;
        _cancelAction.performed += CancelShoot;
    }

    void OnDestroy()
    {
        _fireAction.started -= StartShoot;
        _fireAction.canceled -= StopShoot;
        _cancelAction.performed -= CancelShoot;
    }

    void StopShoot(InputAction.CallbackContext obj)
    {
        _shooting.StartCharging();
    }

    void StartShoot(InputAction.CallbackContext obj)
    {
        _shooting.StopCharging();
    }
    void CancelShoot(InputAction.CallbackContext obj)
    {
        _shooting.CancelCharging();
    }
}
