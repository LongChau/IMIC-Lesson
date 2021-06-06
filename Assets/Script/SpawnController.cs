using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FirstGame.Food;

namespace FirstGame.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _foodPrefabs = new List<GameObject>();
        [SerializeField]
        private List<FoodController> _foodCtrlPrefabs = new List<FoodController>();
        [SerializeField]
        private float _startX;
        [SerializeField]
        private float _startY;

        // Start is called before the first frame update
        void Start()
        {
            //foreach (var food in _foodPrefabs)
            //{
            //    _startX = UnityEngine.Random.Range(-2.79f, 2.79f);
            //    var randomSpeed = UnityEngine.Random.Range(1, 3);
            //    var foodObj = Instantiate(food, new Vector2(_startX, _startY), Quaternion.identity);
            //    var foodCtrl =  foodObj.GetComponent<FoodController>();
            //    foodCtrl.Speed = randomSpeed;
            //}

            foreach (var food in _foodCtrlPrefabs)
            {
                _startX = UnityEngine.Random.Range(-2.79f, 2.79f);
                var foodCtrl = Instantiate(food, new Vector2(_startX, _startY), Quaternion.identity);
                foodCtrl.Speed = UnityEngine.Random.Range(1, 3);
            }
        }
    }
}
