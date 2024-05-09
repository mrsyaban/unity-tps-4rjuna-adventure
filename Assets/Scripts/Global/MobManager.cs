using UnityEngine;

public class MobManager : MonoBehaviour {

    public void Spawn(GameObject mob, Transform transform)
    {
        Instantiate(mob, transform.position, Quaternion.identity);
    }

}