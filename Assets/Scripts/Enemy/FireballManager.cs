using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    [SerializeField] float _damage;
    GameObject player;                          // Reference to the player GameObject.
    PlayerCharacterManager playerCharacterManager;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCharacterManager = player.GetComponent<PlayerCharacterManager>();

        _damage = playerCharacterManager.GetPlayerCharacterSheet().GetMagAttack();
        _damage = 5f + _damage * 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>();
            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(_damage, Vector3.zero);

                //Destroy(gameObject);
            }
        }
        Destroy(gameObject);
    }
}
