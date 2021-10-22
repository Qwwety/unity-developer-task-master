using UnityEngine;

public class MovementClassic : CMovement
{
    protected override void Rotation()
    {
        transform.Rotate(0, HorizontalMovment * TurnSpeed, 0);
    }
    protected override void GetAxis()
    {
        VerticalMovment = Input.GetAxis("Vertical");//Обрашение к GetAxis для получения значения при взаимодействи с определенными кнопками определенными в данном GetAxis
        HorizontalMovment = Input.GetAxis("Horizontal");//Обрашение к GetAxis для получения значения при взаимодействи с определенными кнопками определенными в данном GetAxis
    }
}
