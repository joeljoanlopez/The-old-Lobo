using System;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class HealthManager : MonoBehaviour
{

    [SerializeField] GameObject _Ammo;
    [SerializeField] private float healthAmount = 100f;


    private MoveController moveController;

    private bool _isPlayer;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
        _isPlayer = moveController != null;
    }

    private void Update()
    {
        if (isDead())
        {
            if (_isPlayer)
                moveController.StopMovement();
            else
            {
                GameObject ammo = Instantiate(_Ammo, transform.position, transform.rotation);
                ammo.transform.parent = transform.parent.parent;
                Destroy(this.gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        print(healthAmount);
        healthAmount -= damage;
        //healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        print(healthAmount);
        print(damage);
        if (healthAmount <= 0)
            Kill();

    }

    public void Heal(float healthGained)
    {
        healthAmount += healthGained;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }

    public void Kill()
    {
        healthAmount = 0;
    }

    public bool isDead()
    {
        return healthAmount <= 0;
    }

    public float GetHP()
    {
        return healthAmount;
    }
}