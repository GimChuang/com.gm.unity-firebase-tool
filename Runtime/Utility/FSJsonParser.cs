using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GM.FirebaseTool
{
    public static class FSJsonParser
    {
        // Parse your object to a Firestore-style json string
        // Currently only support string, int, float, double, boolean
        public static string ObjToJson(System.Object _obj)
        {
            Type t = _obj.GetType();
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            string content = "";
            List<string> fields = new List<string>();

            for (int i = 0; i < propInfos.Length; i++)
            {
                //Debug.Log(propInfos[i].PropertyType.Name + " - " + propInfos[i].Name + " : " + propInfos[i].GetValue(_obj).ToString());

                string comma = (i == propInfos.Length - 1) ? "" : ",";

                string valueTypeString = GetFSValueTypeString(propInfos[i].PropertyType);
                string valueString = "";
                if (propInfos[i].PropertyType == typeof(DateTime)) // Format the DateTime string to be the same as Firestore's format
                {
                    valueString = ((DateTime)propInfos[i].GetValue(_obj)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffff'Z'");
                    //Debug.LogWarning($"DateTime: {valueString}");
                }
                else
                {
                    valueString = propInfos[i].GetValue(_obj).ToString();
                }

                fields.Add("\"" + propInfos[i].Name + "\":"
                    + "{"
                    + "\"" + valueTypeString + "\""
                    + ":\"" + valueString + "\""
                    + "}" + comma);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                content = content + fields[i];
            }

            return "{\"fields\":{" + content + "}}";
        }

        // Using string to check is not very good. Using C# 7 's new feature would be better.
        static string GetFSValueTypeString(Type _type)
        {
            string result = "";
            switch (_type.Name)
            {
                case "String":
                    result = "stringValue";
                    break;
                case "DateTime":
                    result = "timestampValue";
                    break;
                case "Boolean":
                    result = "booleanValue";
                    break;
                case "Int32":
                    result = "integerValue";
                    break;
                case "Single":
                    result = "doubleValue"; // There is no floatValue in Firestore
                    break;
                case "Double":
                    result = "doubleValue";
                    break;
            }
            return result;
        }

        /*
        static string GetFSValueString(PropertyInfo _propertyInfo)
        {
            string result = "";
            if(_propertyInfo.PropertyType == typeof(DateTime))
            {
                result = ((DateTime)_propertyInfo.GetValue(_propertyInfo)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffff'Z'");
            }
            else
            {
                result = 
            }

            
            switch (_propertyInfo.PropertyType.Name)
            {
                case "DateTime":
                    //_propertyInfo.SetValue(_propertyInfo, (DateTime)_propertyInfo.GetValue(_propertyInfo));
                    result = ((DateTime)_propertyInfo.GetValue(_propertyInfo)).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffff'Z'"));
                    break;
            }
            
        }
        */
    }
}
