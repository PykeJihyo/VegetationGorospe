using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    public int treeCount = 25;

    public float spawnRadius = 80f;
    public float checkRadius = 4f;

    public LayerMask groundLayer;
    public LayerMask treeLayer;

    void Start()
    {
        GenerateTrees();
    }

    void GenerateTrees()
    {
        int spawned = 0;

        while (spawned < treeCount)
        {

            float x = Random.Range(-spawnRadius, spawnRadius);
            float z = Random.Range(-spawnRadius, spawnRadius);

            Vector3 rayStart = new Vector3(x, 200f, z);
            RaycastHit hit;

            if (Physics.Raycast(rayStart, Vector3.down, out hit, 500f, groundLayer))
            {
                Vector3 spawnPos = hit.point;

                Collider[] nearby = Physics.OverlapSphere(spawnPos, checkRadius, treeLayer);

                if (nearby.Length == 0)
                {
                    GameObject tree = Instantiate(treePrefab, spawnPos, Quaternion.identity);
                    tree.layer = LayerMask.NameToLayer("Tree");

                    spawned++;
                }
            }
        }
    }
}