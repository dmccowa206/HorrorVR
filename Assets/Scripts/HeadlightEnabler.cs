using UnityEngine;

public class HeadlightEnabler : MonoBehaviour
{
    [SerializeField] Light headlight;

    public void TurnOn()
    {
        if (headlight != null)
        {
            headlight.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
