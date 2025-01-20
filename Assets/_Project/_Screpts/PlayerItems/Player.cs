using System.Collections;
using _Project._Screpts.Player;
using Services;
using UnityEngine;

namespace _Project._Screpts.PlayerItems
{
    public class Player : MonoBehaviour
    {
        [Header("Jump Settings")] [SerializeField]
        private float maxJumpPower = 20f; // Максимальная сила прыжка

        [SerializeField] private float powerChargeRate = 10f; // Скорость зарядки прыжка
        [SerializeField] private float gravity = -9.8f; // Гравитация

        [Header("Trajectory Settings")] [SerializeField]
        private Trajectory trajectory; // Ссылка на компонент Trajectory

        [SerializeField] private Rigidbody2D _rigidbody2D;
        private InputHandler _inputHandler; // Ссылка на компонент InputHandler

        [Header("Sprite Settings")] [SerializeField]
        private SpriteRenderer spriteRenderer; // Ссылка на SpriteRenderer

        [SerializeField] private Sprite idleSprite; // Спрайт для состояния покоя
        [SerializeField] private Sprite chargingSprite; // Спрайт для зарядки прыжка
        [SerializeField] private Sprite jumpingSprite; // Спрайт для прыжка
        [SerializeField] private Sprite landingSprite; // Спрайт для приземления

        private float _currentJumpPower = 0f; // Текущая сила прыжка
        private bool _isCharging = false;
        private bool _isGrounded = true; // Для отслеживания состояния приземления
        

        public void Init()
        {
            _inputHandler = ServiceLocator.Instance.GetService<InputHandler>();
            _inputHandler.OnTouchBegin += StartCharging;
            _inputHandler.OnTouchEnd += EndCharging;
        }

        private void OnDisable()
        {
            _inputHandler.OnTouchBegin -= StartCharging;
            _inputHandler.OnTouchEnd -= EndCharging;
        }

        private void StartCharging(Vector2 touchPosition)
        {
            if (!_isGrounded) return; // Если игрок в воздухе, не начинаем зарядку

            _isCharging = true;
            _currentJumpPower = 0f;
            spriteRenderer.sprite = chargingSprite; // Смена спрайта на зарядку
            StartCoroutine(ChargeJumpPower());
            trajectory.CreateTrajectory(transform.position, _currentJumpPower, gravity);
        }

        private void EndCharging(Vector2 touchPosition)
        {
            if (!_isGrounded) return; // Если игрок в воздухе, игнорируем завершение зарядки

            _isCharging = false;
            PerformJump();
            trajectory.ClearTrajectory();
        }

        private IEnumerator ChargeJumpPower()
        {
            while (_isCharging && _currentJumpPower < maxJumpPower)
            {
                _currentJumpPower += powerChargeRate * Time.deltaTime;
                trajectory.CreateTrajectory(transform.position, _currentJumpPower, gravity);
                yield return null;
            }
        }

        private void PerformJump()
        {
            if (!_isGrounded) return; // Если игрок уже в воздухе, игнорируем

            _isGrounded = false; // Устанавливаем состояние "в воздухе"
            spriteRenderer.sprite = jumpingSprite; // Смена спрайта на прыжок
            Vector2 jumpForce = new Vector2(_currentJumpPower, _currentJumpPower * 0.7f);
            _rigidbody2D.velocity = jumpForce;
        }

        private void Update()
        {
            CheckIfGrounded(); // Проверяем состояние приземления
        }

        private void CheckIfGrounded()
        {
            // Простая проверка: если скорость по Y около нуля, то считаем, что игрок на земле
            if (_rigidbody2D.velocity.y == 0 && !_isGrounded)
            {
                _isGrounded = true;
                spriteRenderer.sprite = landingSprite; // Смена спрайта на приземление
                Invoke(nameof(SetIdleSprite), 0.2f); // Возврат к спрайту покоя через небольшую задержку
            }
        }

        private void SetIdleSprite()
        {
            if (_isGrounded && !_isCharging)
            {
                spriteRenderer.sprite = idleSprite; // Возвращаем спрайт состояния покоя
            }
        }
    }
}