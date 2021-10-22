using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpaceShip : MonoBehaviour
{
    [SerializeField] private int MinTimeSpawn;
    [SerializeField] private int MaxTimeSpawn;
    [SerializeField] private GameObject SpaceShip;
    [SerializeField] private Transform Transform;

    private int limitationsY;
    private int SpawnRate;
    private Vector3 onScreenPosition;
    private Vector3 newPosition;
    private Vector3 worldCoordinates;
    private Vector3 Destination;

    void Start()
    {
        SetScreenSeatings();
        StartCoroutine(SpaceShipSpawn());
    }
    IEnumerator SpaceShipSpawn()
    {
        while(true)
        {
            SpawnRate = Random.Range(MinTimeSpawn, MaxTimeSpawn + 1);
            yield return new WaitForSeconds(SpawnRate);
            Destination = SetSpaceShipPosition();
            Instantiate(SpaceShip, Destination, Quaternion.identity);
            MovementSpaceShip.Instance.Destination = SetDestination(Destination);
        }
    }
    private void SetScreenSeatings()
    {
        onScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        newPosition = onScreenPosition;
        limitationsY = (Screen.height * 85) / 100;
        newPosition.x = Screen.width;
        newPosition.y = limitationsY;
    }
    private Vector3 SetSpaceShipPosition()
    {
        worldCoordinates = Camera.main.ScreenToWorldPoint(newPosition);
        worldCoordinates.z = Random.Range(-worldCoordinates.z, worldCoordinates.z);
        float XSite = Random.Range(-1, 1);
        worldCoordinates.x += 2;
        if (XSite == -1)
        {
            worldCoordinates.x *= -1;
        }
        return new Vector3(worldCoordinates.x, 0, worldCoordinates.z);
    }
    private Vector3 SetDestination(Vector3 DefaultDestination)
    {
        Vector3 ConvertedDestination = new Vector3(-DefaultDestination.x, DefaultDestination.y, DefaultDestination.z);
        return ConvertedDestination;
    }
}
