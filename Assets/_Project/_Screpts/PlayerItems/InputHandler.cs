using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project._Screpts.Player
{
    public class InputHandler : MonoBehaviour,IService
    {
        [SerializeField] private Button _buttonJump; // Кнопка для прыжка

        public delegate void TouchInputEvent(Vector2 touchPosition);

        public event TouchInputEvent OnTouchBegin;
        public event TouchInputEvent OnTouchEnd;

        private bool _isCharging = false; // Флаг, показывающий, идет ли зарядка

        private void Awake()
        {
            // Подписываемся на события кнопки
            EventTrigger trigger = _buttonJump.gameObject.AddComponent<EventTrigger>();

            // Начало зажатия кнопки
            EventTrigger.Entry onPointerDown = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerDown
            };
            onPointerDown.callback.AddListener((_) => StartCharging());
            trigger.triggers.Add(onPointerDown);

            // Завершение нажатия кнопки
            EventTrigger.Entry onPointerUp = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerUp
            };
            onPointerUp.callback.AddListener((_) => EndCharging());
            trigger.triggers.Add(onPointerUp);
        }

        private void StartCharging()
        {
            _isCharging = true;
            OnTouchBegin?.Invoke(Vector2.zero); // Вызываем событие начала зарядки
        }

        private void EndCharging()
        {
            _isCharging = false;
            OnTouchEnd?.Invoke(Vector2.zero); // Вызываем событие завершения зарядки
        }
    }
}