using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpointSound;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        //Move player to checkpoint position
        transform.position = currentCheckpointSound.position;

        //Restore player health and reset animation
        playerHealth.Respawn();

        //Move the camera back to the checkpoint room (checkpoint obj must be placed as
        //a child of the room obj)
        Camera.main.GetComponent<CameraControler>().MoveToNewRoom(transform.parent);
    }

    //Activate Checkpoint

}
