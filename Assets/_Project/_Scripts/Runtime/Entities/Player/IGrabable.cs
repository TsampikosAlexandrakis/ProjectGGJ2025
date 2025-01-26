using UnityEngine;

public interface IGrabable
{
    public void Grab();
    public void Release();
    
    public bool IsGrabbed { get; set; }
}
