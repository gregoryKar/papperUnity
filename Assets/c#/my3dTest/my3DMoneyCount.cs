

using UnityEngine;
using utils.math;

namespace my3dtest
{


    public class my3DMoneyCount : MonoBehaviour
    {

        [SerializeField] Transform _moneyFather;
        int _correctMoneyCount;
        [SerializeField] int _moneyCount;
        [SerializeField] TMPro.TextMeshProUGUI _moneyText;

        void Start()
        {
            _correctMoneyCount = _moneyFather.childCount;
            _moneyCount = myRandom.integer(5, 20);
            _moneyText.text = _moneyCount.ToString();
        }

        public void addMoneyCount() { _moneyCount++; graphicChange(); }
        public void reduceMoneyCount() { _moneyCount--; graphicChange(); }

        void graphicChange()
        {
            _moneyText.text = "count : " + _moneyCount.ToString();
            if (_moneyCount == _correctMoneyCount) _moneyText.color = Color.green;
            else _moneyText.color = Color.red;
        }




    }


}