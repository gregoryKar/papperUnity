using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using utils;
using utils.colliders;
using utils.math;

namespace paper
{


    public class backroundManager : MonoBehaviour
    {

        static backroundManager instForbidden;
        public static backroundManager inst
        {
            get
            {
                if (instForbidden == null)
                {
                    var gameObject = new GameObject("backroundManager");
                    instForbidden = gameObject.AddComponent<backroundManager>();
                }
                return instForbidden;
            }

        }


        private void Awake()
        {
            if (instForbidden == null) instForbidden = this;
            else Debug.LogError("DOUBLE backroundManager");
        }

        void Start()
        {

            createEditGrid();
        }




        //[SerializeReference] public readonly bool[,] _pointsArray;
        public readonly HashSet<int2> _occupationPoints = new();

        [SerializeField] Vector2 _wordGridStart;
        [SerializeField] int2 _gridSize;
        [SerializeField] float _blockSize;
        //[SerializeField] Vector2 editPerisevi;

        bool insideGrid(int2 pos)
        {
            return
           (pos.x > -1
         && pos.x < _gridSize.x
         && pos.y > -1
         && pos.y < _gridSize.x);
        }
        int2 positionToGridPoint(Vector2 pos)
        {
            // Debug.LogError("1 pos " + pos);
            // Debug.LogError("_wordGridStart " + _wordGridStart);

            pos -= _wordGridStart;
            int2 gridPos;

            //Debug.LogError("2 pos " + pos);

            gridPos.x = (int)(pos.x / _blockSize);
            gridPos.y = (int)(pos.y / _blockSize);

            //Debug.LogError("3 gridPos " + pos);

            // editPerisevi.x = pos.x % _blockSize;
            // editPerisevi.y = pos.y % _blockSize;
            if (pos.x % _blockSize > (_blockSize / 2f)) gridPos.x++;
            if (pos.y % _blockSize > (_blockSize / 2f)) gridPos.y++;

            //Debug.LogError("4 gridPos " + pos);

            gridPos.x = myMath.clamp(gridPos.x, 0, _gridSize.x);
            gridPos.y = myMath.clamp(gridPos.y, 0, _gridSize.y);

            //Debug.LogError("5 gridPos clamped " + pos);

            return gridPos;

        }
        Vector2 gridPointToPosition(int2 pos) =>
        _wordGridStart + new Vector2(pos.x, pos.y) * _blockSize;

        public HashSet<int2> colliderToPoints(myCollider col)
        {


            HashSet<int2> pointsChecked = new();
            HashSet<int2> collisionPoints = new();

            //Debug.LogError("col._trans.vek2()" + col._trans.vek2());

            int2 startPos = positionToGridPoint(col._trans.vek2());

            //Debug.LogError("startPos" + startPos);

            //bool center = col.pointInside(gridPointToPosition(startPos));
            //pointsChecked.Add(startPos);
            //if (center) collisionPoints.Add(startPos);

            colliderPointExpantion(startPos);


            void colliderPointExpantion(int2 pos)
            {
                if (insideGrid(pos) is false)
                {  return; }//Debug.LogError("insideGrid(pos)" + pos);
                if (pointsChecked.Contains(pos)) {  return; }
                pointsChecked.Add(pos);//Debug.LogError("pointsChecked.Contains(pos)");

                if (col.pointInside(gridPointToPosition(pos)) is false) {  return; }//Debug.LogError("col.pointInside(gridPointToPosition(pos)");
                collisionPoints.Add(pos);

                int2[] neighbors =
                {
                     pos + new int2(-1, 1),
                     pos + new int2(0, 1),
                     pos + new int2(1, 1),

                     pos + new int2(1, 0),
                     pos + new int2(-1, 0),

                     pos + new int2(-1, -1),
                     pos + new int2(0, -1),
                     pos + new int2(1, -1),
                     };

                foreach (var item in neighbors)
                {
                    if (insideGrid(item) is false) continue;
                    if (pointsChecked.Contains(item)) continue;

                    colliderPointExpantion(item);

                }

                //kiklos giro giro if checkd continue ,
                // also if valid position false continue
                // if not check with same function
            }

            return collisionPoints;

        }

        void updateGrid()
        {

            //return;
            //_pointsArray = new bool[_gridSize.x, _gridSize.y];
            //reset all grid

            //all enemies > colliderToPoints
            //HashSet<int2> occupationPoints = new();
            _occupationPoints.Clear();


            foreach (var item in test.instance._enemies)
            {
                var collisions = colliderToPoints(item._col);
                if (collisions.Count == 0) continue;
                //Debug.LogError("ENEMY WITH COLLISION");
                _occupationPoints.UnionWith(collisions);
            }

            foreach (var item in editGridSquares)
            {
                item.color = new Color(0f, 0f, 0f, 0.2f);
            }

            foreach (var item in _occupationPoints)
            {
                //_pointsArray[item.x, item.y] = true;
                editGridSquares[item.x, item.y].color = Color.white;
            }
            //_occupiedPositions = occupationPoints;



        }

        private void Update()
        {

            //return;

            int2 gridMousePos = positionToGridPoint(myFunctions.mousePos());
            //editGridSquares[gridMousePos.x, gridMousePos.y].color = Color.red;

            myFunctions.drawCube(myFunctions.mousePos(), -1);

            updateGrid();


            // Debug.DrawLine(myFunctions.mousePos(),myFunctions.mousePos() + Vector2.up, Color.red, 0.-1f);

            //Debug.Log("POS = " + myFunctions.mousePos() + " grid " + gridMousePos);

            // invo.simple(() =>
            // {
            //     editGridSquares[gridMousePos.x, gridMousePos.y].color = Color.white;
            // }, 0.-1f);
        }


        [SerializeReference] SpriteRenderer[,] editGridSquares;
        //[Button()]
        void createEditGrid()
        {
            //GameObject preffab = Resources.Load("utilityPreffabs/squarePreffab") as GameObject;

            editGridSquares = new SpriteRenderer[_gridSize.x, _gridSize.y];

            Vector3 pos;// = _wordGridStart;
            pos.z = -10;
            for (int x = 0; x < _gridSize.x; x++)
            {
                for (int y = 0; y < _gridSize.y; y++)
                {
                    pos = _wordGridStart + new Vector2(x, y) * _blockSize;
                    //var obj = Instantiate(preffab, pos, Quaternion.identity);
                    var square = pools.sprite();
                    square.sprite = constants.square;
                    square.color = new Color(0, 0, 0, 0.2f);
                    //square.color = Color.black;
                    square.transform.localScale = new Vector3(0.1f, 0.1f, -1f);
                    square.transform.position = pos;

                    editGridSquares[x, y] = square;

                    square.transform.parent = transform;

                }
            }
        }






    }

}