using GameLogic.GroupHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.CompactListView;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class Popup :  MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Image color;
        [SerializeField] private RectTransform parent;

        public void Killed(Group group)
        {
            parent.gameObject.SetActive(true);
            text.text = "You killed: ";
            color.color = group.MaterialColor;
            Invoke("DisablePopup", 2f);
        }

        private void DisablePopup()
        {
            parent.gameObject.SetActive(false);
        }

    }
}
