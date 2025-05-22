/*using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
  
        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location

        //Move the camera back to the checkpoint room (checkpoint obj must be placed as
        //a child of the room obj)
        Camera.main.GetComponent<CameraControler>().MoveToNewRoom(currentCheckpoint.parent);
    }

    //Activate Checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint we activated as the current one
            //SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
        
        } 
    }
}
*/