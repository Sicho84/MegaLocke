using UnityEngine;
using System.Collections;

//a simple script to auto destruct "one shot" Particle Systems since there is no more auto-destruct checkbox in Unity
//simply attach script to your particle system
//2017 Sacha Galgon


public class ParticleSystemAutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }

}