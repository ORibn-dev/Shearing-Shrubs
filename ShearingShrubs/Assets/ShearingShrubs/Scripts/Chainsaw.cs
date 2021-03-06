﻿using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public event UpdateNumBushes Updatenumberofbushes;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bush"))
        {
            CutBush(col);
            Updatenumberofbushes?.Invoke();
        }
    }

    private void CutBush(Collider coll)
    {
        if (!coll.GetComponent<Rigidbody>())
        {
            coll.gameObject.AddComponent<Rigidbody>();
            coll.isTrigger = false;
            LeavesParticlePool.Instance.InitiateLeavesParticles(coll.transform.position);
            Destroy(coll.gameObject, 3f);
        }
    }
}
