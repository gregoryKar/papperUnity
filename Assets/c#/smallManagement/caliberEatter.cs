


using paper;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace smallManagement
{



    public class caliberEater : MonoBehaviour
    {


        [SerializeField]TMPro.TextMeshProUGUI _text;
        int _count = 0;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "caliber") return;

            managementMain.inst._caliberPool.Return(other.gameObject);
            _count++;
            _text.text = _count.ToString();
        }




    }



}