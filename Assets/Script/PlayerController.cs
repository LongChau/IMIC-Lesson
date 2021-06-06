using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace FirstGame.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Fields
        [SerializeField ]
        private float speed;
        [SerializeField ]
        private bool isSlowSpeed;
        [SerializeField ]
        private SpriteRenderer spriteRenderer;
        [SerializeField ]
        private Animator animator;
        [SerializeField]
        private int _score;

        [SerializeField]
        private TextMeshProUGUI _txtScore;
        // public float Speed 
        // {
        //     get {
        //         return speed;
        //     }
        // }

        // Property
        public float Speed => speed;
        public float DoubleSpeed 
        {
            get 
            {
                return speed * 2;
            }
        }

        void Awake()
        {
            Debug.Log("Awake()");
            //animator = GetComponent<Animator>();
        }

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Start()");
            speed = 10f;
            // UnityEngine.Random.Range(5, 10);
            TestInvoke();
        }

        [ContextMenu("TestInvoke")]
        private void TestInvoke()
        {
            Debug.Log("TestInvoke()");
        }

        [ContextMenu("RunLeft")]
        private void RunLeft()
        {
            // Debug.Log("TestInvoke()");
            transform.Translate(Vector2.left * speed);
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("Update()");
            //Khi bat isSlowSpeed = true thi speed = 2.5
            if (isSlowSpeed == true)
            {
                speed = 2.5f;
            }
            // Khi tat isSlowSpeed = false thi speed 10
            else
            {
                speed = 10f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // Cho nhân vật đi với tốc độ speed qua trái trong 1 giây.
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                // Cho nhan vat xoay trai bang sprite renderer
                //spriteRenderer.flipX = false;
                // Cho nhan vat xoay trai bang animator.
                animator.SetBool("isRight", false);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                // Cho nhan vat xoay phai bang sprite renderer
                //spriteRenderer.flipX = true;
                // Cho nhan vat xoay phai bang animator.
                animator.SetBool("isRight", true);
            }
        }

        /// <summary>
        /// Chỉ callback khi mà IsTrigger = false.
        /// Xử lý theo vật lý.
        /// </summary>
        /// <param name="collision"></param>
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    Debug.Log($"Collide with {collision.collider.name}");
        //    // TODO: Destroy collider object.
        //    bool isItem = collision.gameObject.CompareTag("Item");
        //    if (isItem)
        //    {
        //        Destroy(collision.gameObject);
        //    }
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Collide with trigger {collision.name}");
            bool isItem = collision.CompareTag("Item");
            if (isItem)
            {
                Destroy(collision.gameObject);
                _score += 10;
                _txtScore.SetText($"Score: {_score}");
            }
        }

        void OnEnable()
        {
            Debug.Log("OnEnable()");
        }

        void OnDisable()
        {
            Debug.Log("OnDisable()");
        }

        void OnDestroy()
        {
            Debug.Log($"OnDestroy() {gameObject.name}");
        }
    }
}
