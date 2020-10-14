using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterManager : MonoBehaviour
{
    private PlayerCharacterSheet _playerCharacterSheet;

    // Start is called before the first frame update
    void Awake()
    {
        _playerCharacterSheet = new PlayerCharacterSheet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerCharacterSheet GetPlayerCharacterSheet()
    {
        return _playerCharacterSheet;
    }
}
