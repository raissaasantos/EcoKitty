using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //Room camera
    [SerializeField] private float speed;
    private float currentPosition;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        //Room camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosition, transform.position.y, transform.position.z), ref velocity, speed);

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosition = _newRoom.position.x;

    }

}
