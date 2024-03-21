using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    public int ID;

    public string Name;

    public Vector3 Position;

    public float Health;

    public float AttackPower;

    public float Speed;

    public abstract void Move();
   

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
