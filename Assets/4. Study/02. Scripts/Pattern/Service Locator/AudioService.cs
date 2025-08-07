using UnityEngine;


public class AudioService : IAudioService
{
    public void PlayeSound()
    {
        Debug.Log("PlayeSound");
    }

    public void StopSound()
    {
        Debug.Log("StopSound");
    }
}