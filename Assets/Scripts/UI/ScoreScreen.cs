using GameLogic.GroupHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.CompactListView;
using UnityEngine;

namespace UI
{
    class ScoreScreen : BaseCompactVerticalListView<ScoreItem>
    {

        protected override float ItemSize => 30;

        public void Initialize(IEnumerable<Group> groups)
        {
            foreach (Group g in groups.OrderByDescending(x => x.ModelCount))
            {
                CreateSingleItem("UI/ScoreItem").Initialize(g);
            }
        }

        /// <summary>
        /// Refreshes score screen based on the groups
        /// </summary>
        /// <param name="groups"></param>
        public void Refresh()
        {
            ScoreItem[] ordered = itemList.OrderByDescending(x => x.group.ModelCount).ToArray();
            for (int i = 0; i < ordered.Length; i++)
            {
                ordered[i].Refresh();
                ordered[i].transform.SetSiblingIndex(i);
            }
        }
    }
}
