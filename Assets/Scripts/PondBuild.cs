using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PondBuild : MonoBehaviour
{
    public GameObject[] Pond; 
                                
    private BoxCollider p_area;    
    public int count = 1;     
    
    private List<GameObject> GameObject = new List<GameObject>();
    
    void Start()
    {
        p_area = GetComponent<BoxCollider>();
        
        for(int i = 0; i < count; ++i)
        {
            Spawn();
        }
        
        p_area.enabled = false;
    }
    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = p_area.size;
        
        float posX = basePosition.x + Random.Range(-size.x/2f, size.x/2f);
        float posY = basePosition.y + Random.Range(-size.y/2f, size.y/2f);
        float posZ = basePosition.z + Random.Range(-size.z/2f, size.z/2f);
        
        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        
        return spawnPos;
    }
     private void Spawn()
    {
        int selection = Random.Range(0, Pond.Length);
        
        GameObject selectedPrefab = Pond[selection];
        
        Vector3 spawnPos = GetRandomPosition();
        
        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        GameObject.Add(instance);
    }
}