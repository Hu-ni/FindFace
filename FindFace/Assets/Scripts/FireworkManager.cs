using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    private void Start()
    {
        InvokeRepeating("GenFirework", 1.0f, 2.0f);
    }

    private void GenFirework()
    {
        ParticleSystem p = Instantiate(particle, this.transform);
        p.transform.localPosition = new Vector3(Random.Range(-300f, 300f), Random.Range(-100f, 500f), 0);
        p.Play();
    }
}
