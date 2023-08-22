using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    public GameObject objectToPlace; // The object to be randomly placed.
    public int numberOfObjects = 10; // Number of objects to be placed.
    public Vector3 placementBounds = new Vector3(10f, 0f, 10f); // The bounds in which objects will be placed.

    private void Start()
    {
        PlaceObjectsRandomly();
    }

    void PlaceObjectsRandomly()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-placementBounds.x / 2, placementBounds.x / 2),
                0f,
                Random.Range(-placementBounds.z / 2, placementBounds.z / 2)
            );

            GameObject newObject = Instantiate(objectToPlace, transform.position + randomPosition, Quaternion.identity);
            newObject.transform.parent = transform;
        }
    }
}
