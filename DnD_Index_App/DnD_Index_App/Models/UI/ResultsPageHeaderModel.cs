using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.UI
{
    public class ResultsPageHeaderModel
    {
        private string? _titleText;
        public string? TitleText
        {
            get { return (_titleText != null) ? _titleText : ""; }
            set { _titleText = value; }
        }

        private string? _subTitleText;
        public string? SubTitleText
        {
            get { return (_subTitleText != null) ? _subTitleText : ""; }
            set { _subTitleText = value; }
        }

        private Image? _icon;
        public Image? Icon
        {
            get { return (_icon != null) ? _icon : new Image(); }
            set { _icon = value; }
        }

        public ResultsPageHeaderModel(string? titleText, string? subTitleText, Image? icon = null)
        {
            TitleText = titleText;
            SubTitleText = subTitleText;
            Icon = icon;
        }
    }
}
