using UnityEngine;

public class MovementNew : CMovement
{
    protected override void Rotation()
    {
        Vector3 MousePosition = Input.mousePosition;//запись позиции мышки в переменную 
        MousePosition.z = 20;// поправка на положение камеры, для точного расчета позиции мыши
        Vector3 ObjectPosition = Camera.main.ScreenToWorldPoint(MousePosition);// перевод позиции мышки из пикселей в мировые координаты
        Vector3 TargetPosition = new Vector3(ObjectPosition.x, 0, ObjectPosition.z);// определение позиции мышки по 2-м координатам-x,z(x и z  так как я поднял камеру по  оси y и она при положении мышки всегда будет равна 0)
        Vector3 Direction = (transform.position - TargetPosition).normalized;// Определите направление "носа" на его корабля
        float angle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;// после определения носа по осям x и z, нужно найти точку по данным координатам
        Quaternion target = Quaternion.Euler(0, angle, 0);// определения угла на который требуется повернуть
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * TurnSpeed);// сам поворот
    }
    protected override void GetAxis()
    {
        VerticalMovment = Input.GetAxis("NewControll");//Обрашение к GetAxis для получения значения при взаимодействи с определенными кнопками определенными в данном GetAxis
    }

}