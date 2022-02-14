using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdWing 
{

    public void WingAcceleration(Rigidbody2D rigid, float force)
    {
        rigid.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
