using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableEnv 
{
    private float _currentHealth;
    private float _maxHealth;
    private bool _isBroken;
    public BreakableEnv()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
        _isBroken = false;
    }

    //getters
    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public bool GetIsBroken()
    {
        return _isBroken;
    }

    //setters
    public void EnvTakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            _isBroken = true;
        }
    }

    public void FixEnv(float heal)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += heal;

            if (_currentHealth > _maxHealth)
            {
                float tmp = _currentHealth - _maxHealth;
                _currentHealth -= tmp;
            }
            _isBroken = false;
        }
        
    }

    public void BreakEnv()
    {
        _isBroken = true;
    }
}
