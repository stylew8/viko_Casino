using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float speed = 5.0f; // —корость вращени€ барабана
    public float endPositionY; // Y-координата, при достижении которой барабан перемещаетс€ вверх
    public float resetPositionY; // Y-координата, куда барабан перемещаетс€ дл€ начала нового цикла

    void Update()
    {
        // ѕеремещение барабана вниз
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        // ѕроверка, достиг ли барабан нижней границы
        if (transform.position.y < endPositionY)
        {
            // ѕеремещение барабана обратно вверх дл€ продолжени€ вращени€
            Vector3 newPosition = transform.position;
            newPosition.y = resetPositionY;
            transform.position = newPosition;
        }
    }
}
