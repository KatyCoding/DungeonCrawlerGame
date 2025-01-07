using System;
using UnityEngine;

public class EntityHealthBar : MonoBehaviour
{
    
    public float MaxSize = 8;
    public EntityBehavior Entity;
    public Transform Container;
    private void OnValidate()
    {
        if (Entity == null)
        {
            Entity = this.GetComponentInParent<EntityBehavior>();
        }
    }

    private void FixedUpdate()
    {
        Container.LookAt(Camera.main.transform);
    }

    private void Awake()
    {
        Entity.OnHealthChanged += OnHealthChanged;
    }

    public void OnHealthChanged(float prevHealth, float newHealth, float maxHealth)
    {
        transform.parent.localScale = new Vector3((newHealth / maxHealth) * MaxSize,
            transform.parent.localScale.y,transform.parent.localScale.z);
    }
}
