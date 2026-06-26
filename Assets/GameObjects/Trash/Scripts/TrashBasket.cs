using UnityEngine;

public class TrashBasket : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    public float padding = 0.2f;

    void Start()
    {
        float camHeight = cam.orthographicSize * 2f;
        float bottom = cam.transform.position.y - camHeight / 2f;
        float halfHeight = GetComponent<Renderer>().bounds.extents.y;

        transform.position = new Vector3(cam.transform.position.x,
            bottom + halfHeight + padding,transform.position.z);
    }

  
}
