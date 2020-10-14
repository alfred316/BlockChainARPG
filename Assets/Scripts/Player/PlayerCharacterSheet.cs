using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSheet
{
    private float _stamina;
    private float _currentHealth;
    private float _mana;
    private float _currentMana;
    private float _armor;
    private float _phyattack;
    private float _magattack;
    private float _crit;
    private PlayerInventory _inventory;

    public PlayerCharacterSheet() 
    {
        _stamina = 100;
        _currentHealth = _stamina;
        _mana = 100;
        _currentMana = _mana;
        _armor = 10;
        _phyattack = 5;
        _magattack = 5;
        _crit = 1;
        _inventory = new PlayerInventory();
    }

    //getters
    public float GetStamina()
    {
        return _stamina;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMagic()
    {
        return _mana;
    }

    public float GetCurrentMana()
    {
        return _currentMana;
    }

    public float GetArmor()
    {
        return _armor;
    }

    public float GetPhyAttack()
    {
        return _phyattack;
    }

    public float GetMagAttack()
    {
        return _magattack;
    }

    public float GetCrit()
    {
        return _crit;
    }

    public PlayerInventory GetInventory()
    {
        return _inventory;
    }

    public PlayerItem GetItemFromInventory(int id)
    {
        return _inventory.FindItem(id);
    }

    //setters
    public void SetStamina(float stamina)
    {
        _stamina = stamina;
    }

    public void SetCurrentHealth(float health)
    {
        _currentHealth = health;
    }
    public void SetMagic(float mana)
    {
        _mana = mana;
    }

    public void SetCurrentMana(float mana)
    {
        _currentMana = mana;
    }
    public void SetArmor(float armor)
    {
        _armor = armor;
    }
    public void SetPhyAttack(float phyAttack)
    {
        _phyattack = phyAttack;
    }
    public void SetMagAttack(float magAttack)
    {
        _magattack = magAttack;
    }
    public void SetCrit(float crit)
    {
        _crit = crit;
    }
}
