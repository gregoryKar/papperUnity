
using System;
using System.Collections.Generic;
using paper;
using UnityEngine;

namespace smallManagement
{


    [Serializable]
    public class gameobjectPool
    {
        const int spawnCount = 5;

        [SerializeField] GameObject _preffab;

        List<GameObject> _active = new(), _inactive = new();

        public GameObject Get()
        {
            if (_inactive.Count == 0)
            {

                for (int i = 0; i < spawnCount; i++)
                {

                    var g = GameObject.Instantiate(_preffab);
                    g.name = "object pool item";
                    g.SetActive(false);
                    _inactive.Add(g);
                }

            }

            var give = _inactive[0];
            give.SetActive(true);
            _inactive.Remove(give);
            _active.Add(give);
            return give;


        }
        public void Return(GameObject obj)
        {
            _active.Remove(obj);
            _inactive.Add(obj);
            obj.SetActive(false);
        }


    }



}