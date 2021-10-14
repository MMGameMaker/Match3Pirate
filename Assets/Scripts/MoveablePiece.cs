using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePiece : MonoBehaviour
{
    private GamePiece piece;
    private IEnumerator moveCoroutine;

    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int newX, int newY, float time)  //chua hieu ro vai tro cua method nay
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = MoveCoroutine(newX, newY, time);
        StartCoroutine(moveCoroutine);
    }

    private IEnumerator MoveCoroutine(int newX, int newY, float time) //method nay co the la de go di chuyen tu tu, khong phai nhay tung o
    {
        piece.X = newX;
        piece.Y = newY;

        Vector3 starPos = transform.position;
        Vector3 entPos = piece.GridRef.GetWorldPosition(newX, newY);

        for(float t=0; t<1*time; t += Time.deltaTime)
        {
            piece.transform.position = Vector3.Lerp(starPos, entPos, t / time);
            yield return 0;
        }

        piece.transform.position = entPos;
    }

}
