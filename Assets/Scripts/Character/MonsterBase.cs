using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [SerializeField]
    public Monster_Data monster;
    [SerializeField]
    private nodeBase node;
    
    public void get_Damage(float atk)
    {
        monster.hp -= atk;
    }
    private void FixedUpdate()
    {
        if (monster.hp <= 0)
        {
            transform.parent.parent.GetComponent<nodeActive>().Monsters.Remove(this.gameObject);
            GetComponent<Collider>().enabled = false;
            node.resetNodeStatus();
            Destroy(gameObject);

        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Node"))
        {
            node = other.gameObject.GetComponent<nodeBase>();
        }    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (GetComponent<MonsterMovement>()._characterState != PlayerController.CharacterState.Attack)
        {
            return;
        }
        if (other.transform.CompareTag("Player") )
        {
            other.gameObject.GetComponent<PlayerBase>().get_Damage(monster.atk);
            GameObject d = Resources.Load<GameObject>("Damage");
            d.GetComponent<DamagePopup>().damage = (int) monster.atk;
            GameObject i = Instantiate(d);
            i.transform.position = other.transform.position;
            GetComponent<MonsterMovement>()._characterState = PlayerController.CharacterState.Idle;

        }
    }
}
[Serializable]
public class Monster_Data
{
    public int id;
    public float hp;
    public float atk;
    public float def;
}