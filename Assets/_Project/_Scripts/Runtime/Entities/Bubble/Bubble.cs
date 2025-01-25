using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float minSize;
    public float maxSize;
    
    public float inflationSpeed;
    
    public float size;
    public bool Popped = false;
    private void Update()
    {
        if (minSize < maxSize && !Popped)
        {
            foreach(Transform child in transform)
            {
                size += inflationSpeed * Time.deltaTime;
                size = Mathf.Clamp(size, minSize, maxSize);
                child.localScale = new Vector3(size, size, size);
            }
           
        }

        if (size == maxSize)
        {
            Pop();
        }
    }

    
    
    private void Pop()
    {
        Destroy(gameObject);
    }
}
