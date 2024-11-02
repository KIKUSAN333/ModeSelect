using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    float NotesSpeed; // クラス内に変数を定義
    public float pushPosition;

    bool start;

    void Start()
    {
        NotesSpeed = GManager.instance.notesSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if (start)
        {
            transform.Translate(Vector3.left * NotesSpeed * Time.deltaTime);
        }
    }
}