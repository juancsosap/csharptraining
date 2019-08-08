using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Tools
{
    public class ViewTools
    {
        public static List<SelectListItem> ToSelectListItem<T>(T selected, List<T> data, Func<T, String> text, Func<T, String> value, Predicate<T> disable)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (T item in data)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Text = text.Invoke(item),
                    Value = value.Invoke(item),
                    Disabled = disable.Invoke(item)
                };

                if (selected.Equals(item))
                    listItem.Selected = true;

                list.Add(listItem);
            }
            return list;
        }

        public static List<SelectListItem> ToSelectListItem<T>(T selected, List<T> data, Func<T, String> text, Func<T, String> value)
        {
            return ToSelectListItem(selected, data, text, value, i => false);
        }

        public static List<SelectListItem> ToSelectListItem<T>(T selected)
        {
            var type = typeof(T);

            if(!type.IsEnum)
                throw new ApplicationException("Type must be Enum");

            FieldInfo[] members = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (FieldInfo member in members)
            {
                var attributeDescription = (DescriptionAttribute[]) member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                String description = attributeDescription.Any() ? attributeDescription[0].Description : member.Name;

                SelectListItem listItem = new SelectListItem()
                {
                    Text = description,
                    Value = ((int)Enum.Parse(type, member.Name)).ToString()
                };

                if (selected.Equals(Enum.Parse(type, member.Name)))
                    listItem.Selected = true;

                list.Add(listItem);
            }
            return list;
        }
    }
}