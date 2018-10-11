using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace les2
{
    public interface IDamagable
    {

        int Health { get; set; }
        void TakeDamage(int damage);

    }
}