using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Exp
{
    public class ExpBar : MonoBehaviour
    {
        public Slider expBar;
        public ExpAttribute expAttribute;
        public TextMeshProUGUI levelInfo;
        
        private void Start()
        {
            expBar.maxValue = expAttribute.expForNextLvl;
        }
        private void Update()
        {
            expBar.value = expAttribute.currentExp;
            levelInfo.text = $"Level: {expAttribute.level}";
        }
    }
}