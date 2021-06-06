using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstGame.Food
{
    public class FoodController : MonoBehaviour
    {
        // Field
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _downBorder;

        // Property
        public float Speed { get => _speed; set => _speed = value; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y >= _downBorder)
            {
                transform.Translate(Vector2.down * Speed * Time.deltaTime);
            }
            else
            {
                //Destroy(gameObject);
                Speed = 0f;
            }
        }
    }
}
