using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesParticlePool : MonoBehaviour
{
    [SerializeField] private ParticleSystem leaves;
    [SerializeField] private Transform ground;

    private List<ParticleSystem> leaves_pool = new List<ParticleSystem>();
    private Queue<GameObject> leavestodestroy = new Queue<GameObject>();
    private ParticleSystem leaves_prefab;

    public static LeavesParticlePool Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InstantiatePool();
    }

    private void InstantiatePool()
    {
        for (int i = 0; i < 25; i++)
        {
            leaves_prefab = (ParticleSystem)Instantiate(leaves);
            leaves_prefab.gameObject.SetActive(false);
            leaves_pool.Add(leaves_prefab);
        }
    }

    private ParticleSystem GetLeavesParticles()
    {
        for (int i = 0; i < leaves_pool.Count; i++)
        {
            if (!leaves_pool[i].gameObject.activeInHierarchy)
            {
                return leaves_pool[i];
            }
        }
        return null;
    }

    public void InitiateLeavesParticles(Vector3 pos)
    {
        StartCoroutine(InitiateLeavesParticlesProcess(pos));
    }

    private IEnumerator InitiateLeavesParticlesProcess(Vector3 pos)
    {
        leaves_prefab = GetLeavesParticles();
        leaves_prefab.collision.SetPlane(0, ground);
        leaves_prefab.transform.position = new Vector3(pos.x, pos.y, -2.95f);
        leaves_prefab.gameObject.SetActive(true);
        leaves_prefab.Play();
        leavestodestroy.Enqueue(leaves_prefab.gameObject);
        yield return new WaitForSeconds(2f);
        leavestodestroy.Dequeue().SetActive(false);
    }
}
