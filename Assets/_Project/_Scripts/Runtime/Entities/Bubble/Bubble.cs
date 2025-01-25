using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float minSize;
    public float maxSize;
    
    
    public float size;
    public bool Popped = false;
    private void Update()
    {
        if (minSize < maxSize && !Popped)
        {
            foreach(Transform child in transform)
            {
                size = Mathf.Clamp(size, minSize, maxSize);
                child.localScale = new Vector3(size, size, size);
            }
           
        }

        if (size == maxSize)
        {
            Pop();
        }
    }

    public void Inflate(float inflationRate)
    {
        
        size += inflationRate;
        
    }
    


    private void Pop()
    {
        Destroy(gameObject);
    }
}
