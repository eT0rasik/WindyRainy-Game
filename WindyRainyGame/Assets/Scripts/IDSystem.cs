using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDSystem : MonoBehaviour
{
    //���� ������ ������ ���� �������� �� ���� �������� � ����� "cloud";
    //����������������?
    [SerializeField] private int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return this.id;
    }
}
