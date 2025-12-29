

using paper;
using UnityEngine;
using utils;
using utils.math;

namespace smallManagement
{





    public class manageGun : MonoBehaviour
    {


        void Update()
        {

            shoot();



        }

        private void Start()
        {
            _okToShoot = new myTime();
        }


        myTime _okToShoot;//= new();
        [SerializeField] Transform _gun;
        [SerializeField] managementData _data;


        void shoot()
        {




            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            myMath.LookAt2D_chatGtp(_gun, mousePos);

            // spaceDown = Input.GetKey(KeyCode.Space);
            // shootAfter = lastShoot + _data._shootCooldown;
            // now = myTime.now;

            if (Input.GetKey(KeyCode.Space) is false) return;

            //if (lastShoot + _data._shootCooldown > myTime.now) return;

            if (_okToShoot.passed() is false) return;
            _okToShoot.setAfter(_data._shootCooldown);




            shootBullet();
            shootCaliber();



        }
        void shootBullet()
        {
            var bullet = managementMain.inst._bulletPool.Get();
            bullet.name = "bullet poolable";
            bullet.transform.position = _gun.position;
            bullet.transform.rotation = _gun.transform.rotation;
            var rb = bullet.GetComponent<Rigidbody2D>();

            rb.linearVelocity = _gun.up * _data._bulletSpeed;
            rb.gravityScale = 0;

            invo.simple(() =>
            {
                managementMain.inst._bulletPool.Return(bullet);
                //Debug.Log("kill bullet");
            }, 2f);

        }
        void shootCaliber()
        {
            var cal = managementMain.inst._caliberPool.Get();
            cal.name = "caliber poolable";
            cal.transform.position = _gun.position;
            cal.transform.eulerAngles = Vector3.zero;
            var rb = cal.GetComponent<Rigidbody2D>();

            rb.linearVelocity = _data._cacliberStartDir.normalized * _data._caliberStartSpeed;
            rb.angularVelocity = _data._caliberStartRotSpeed;
        }



    }

}