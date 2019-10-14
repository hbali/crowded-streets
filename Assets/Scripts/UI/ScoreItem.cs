using System;
using GameLogic.GroupHandling;
using UI.CompactListView;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class ScoreItem : BaseCompactListItem
    {
        [SerializeField] private Image color;
        [SerializeField] private Text score;

        public Group group;

        public override void Initialize(params object[] parameters)
        {
            this.group = parameters[0] as Group;
        }

        public override void OnClick()
        {

        }

        internal void Refresh()
        {
            color.color = group.MaterialColor;
            score.text = group.ModelCount.ToString();
        }
    }
}