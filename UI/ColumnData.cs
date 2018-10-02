﻿using System;
using System.Xml;

namespace LiveSplit.UI
{
    public class ColumnData
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public Boolean Static { get; set; }
        public string Comparison { get; set; }
        public string TimingMethod { get; set; }

        public ColumnData(string name, ColumnType type, string comparison, string method)
            : this(name, type, false, comparison, method)
        {
        }

        public ColumnData(string name, ColumnType type, Boolean static_, string comparison, string method)
        {
            Name = name;
            Type = type;
            Static = static_;
            Comparison = comparison;
            TimingMethod = method;
        }

        public static ColumnData FromXml(XmlNode node)
        {
            var element = (XmlElement)node;
            return new ColumnData(element["Name"].InnerText,
                (ColumnType)Enum.Parse(typeof(ColumnType), element["Type"].InnerText),
                element["Static"] != null ? Boolean.Parse(element["Static"].InnerText) : false,
                element["Comparison"].InnerText,
                element["TimingMethod"].InnerText);
        }

        public int CreateElement(XmlDocument document, XmlElement element)
        {
            return SettingsHelper.CreateSetting(document, element, "Version", "1.5") ^
            SettingsHelper.CreateSetting(document, element, "Name", Name) ^
            SettingsHelper.CreateSetting(document, element, "Type", Type) ^
            SettingsHelper.CreateSetting(document, element, "Static", Static) ^
            SettingsHelper.CreateSetting(document, element, "Comparison", Comparison) ^
            SettingsHelper.CreateSetting(document, element, "TimingMethod", TimingMethod);
        }
    }
}
