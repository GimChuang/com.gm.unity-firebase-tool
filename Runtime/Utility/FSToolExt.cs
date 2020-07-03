using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.FirebaseTool
{
    public static class FSToolExt
    {
        public const string SUFFIX_QUERY = ":runQuery";

        public const string TIMESTAMP_VALUE = "timestampValue";
        public const string STRING_VALUE = "stringValue";
        public const string BOOLEAN_VALUE = "booleanValue";
        public const string INTEGER_VALUE = "integerValue";
        public const string DOUBLE_VALUE = "doubleValue";

        public enum FieldFilterOperator { LESS_THAN , LESS_THAN_OR_EQUAL , GREATER_THAN , GREATER_THAN_OR_EQUAL , EQUAL , ARRAY_CONTAINS , IN , ARRAY_CONTAINS_ANY }
        public enum OrderDirection { ASCENDING , DESCENDING }
    }
}
