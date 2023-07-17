using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                nextRoom.GetComponent<ResetTraps>().ActivateRoom(true);
                previousRoom.GetComponent<ResetTraps>().ActivateRoom(false);
            }
            else
            {
                previousRoom.GetComponent<ResetTraps>().ActivateRoom(true);
                nextRoom.GetComponent<ResetTraps>().ActivateRoom(false);
            }
        }
    }
}