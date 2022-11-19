using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchItem : MonoBehaviour
{

    private Transform m_item;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        m_item = GameObject.FindWithTag("Item").transform;
        if(m_item == null){
            m_item = GameObject.FindWithTag("Exit").transform;
        }
        LookAt2D(this.transform,m_item);
    }

    public static void LookAt2D(Transform self, Transform _target)
	{
        
	    var current = self.position;
	    var direction = _target.position - current;
	    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
	    self.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
