using UnityEngine;
using UnityEngine.XR.ARFoundation;

//execute this before anything else
[DefaultExecutionOrder(-1)]
public class SessionOrigin : MonoBehaviour
{ 
    public static SessionOrigin Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (!Instance.GetComponent<ARSessionOrigin>())
            {
                Debug.LogError($"Error: The Session Origin Instance was not attached to the ARSessionOrigin");
            }
        }
        else if (Instance != this)
        {
            Debug.LogError($"Error: more than one Session Origin found in the scene - destroying {this.name}");
            Destroy(this);
        }
    }
}
