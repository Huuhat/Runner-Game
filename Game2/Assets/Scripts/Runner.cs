using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1, 
    MIDDLE = 0, 
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] float positionX = 4.0f;

    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        roadLine = RoadLine.MIDDLE;

        animator = GetComponent<Animator>();

        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        OnKeyUpdate();

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
             roadLine--; 
                animator.Play("Left Avoid");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((roadLine != RoadLine.RIGHT))
            {
                roadLine++;

                animator.Play("Right Avoid");
            }

        }

    }

    public void Move()
    {
        rigidBody.position = new Vector3(positionX * (int)roadLine, 0, 0);
    }
}
