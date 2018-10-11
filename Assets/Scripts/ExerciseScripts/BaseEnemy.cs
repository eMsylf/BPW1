using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace les2
{
    public abstract class BaseEnemy : MonoBehaviour, IDamagable
    {

        public int Health { get; set; }

        public void TakeDamage(int damage)
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class SmallEnemy : BaseEnemy
    {

    }
}