using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ToolSupportUchida.Utils
{
    public static class CUtils
    {
        #region Format String
        public static string ReplaceFormat(string str, string oldValue, string newValue, string formatValue = "")
        {
            try
            {
                if (string.IsNullOrEmpty(formatValue))
                {
                    return str.Replace(oldValue, newValue);
                }
                else
                {
                    return str.Replace(string.Format(oldValue, formatValue), string.Format(newValue, formatValue));
                }
            }
            catch (Exception)
            {
                return str;
            }
        }

        public static string ReplaceFormatText(string str, string oldValue, string oldFormat, string newValue, string newFormat = "")
        {
            try
            {
                if (string.IsNullOrEmpty(newFormat))
                {
                    return str.Replace(string.Format(oldFormat, oldValue), string.Format(oldFormat, newValue));
                }
                else
                {
                    return str.Replace(string.Format(oldFormat, oldValue), string.Format(newFormat, newValue));
                }
            }
            catch (Exception)
            {
                return str;
            }
        }

        public static bool ConvertStringToBoolean(string text)
        {
            bool result = false;
            string conditional = string.Empty;
            Dictionary<string, string> lstDic = ConvertStringConditionalToLsit(text);

            foreach (KeyValuePair<string, string> item in lstDic)
            {
                if (string.Empty.Equals(item.Key))
                {
                    result = bool.Parse(item.Value);
                }
                else
                {
                    conditional = Regex.Replace(item.Key, CONST.REGEX_KEY_LIST_DIC, string.Empty).Trim();
                    result = CompareConditional(result, conditional, bool.Parse(item.Value));
                }
            }

            return result;
        }

        private static Dictionary<string, string> ConvertStringConditionalToLsit(string text)
        {
            text = text.Replace(CONST.STRING_CHECK_ELSE_IF, string.Empty)
                       .Replace(CONST.STRING_CHECK_IF, string.Empty)
                       .Replace(CONST.STRING_CHECK_THEN, string.Empty).Trim();
            string key = string.Empty;
            string resultCompare = string.Empty;

            bool isBrace = false;

            Dictionary<string, string> lstDic = new Dictionary<string, string>();
            lstDic.Add(key, string.Empty);

            string[] arrText = text.Split(CONST.CHAR_SPACE);
            int index = 0;

            foreach (string item in arrText)
            {
                index++;

                if (item.Contains("("))
                {
                    isBrace = true;
                }

                if (item.ToUpper().Equals(CONST.STRING_UPPER_AND))
                {
                    if (isBrace)
                    {
                        resultCompare = resultCompare + CompareString(lstDic[key]) + CONST.CHAR_SPACE
                        + CONST.STRING_UPPER_AND + CONST.CHAR_SPACE;
                        lstDic[key] = string.Empty;
                    }
                    else
                    {
                        lstDic[key] = CompareString(lstDic[key]);
                        key = string.Format(CONST.STRING_KEY_LIST_DIC, lstDic.Count) + CONST.STRING_AND;
                        lstDic.Add(key, string.Empty);
                    }
                }
                else if (item.ToUpper().Equals(CONST.STRING_UPPER_OR))
                {
                    if (isBrace)
                    {
                        resultCompare = resultCompare + CompareString(lstDic[key]) + CONST.CHAR_SPACE
                        + CONST.STRING_UPPER_OR + CONST.CHAR_SPACE;
                        lstDic[key] = string.Empty;
                    }
                    else
                    {
                        lstDic[key] = CompareString(lstDic[key]);
                        key = string.Format(CONST.STRING_KEY_LIST_DIC, lstDic.Count) + CONST.STRING_UPPER_OR;
                        lstDic.Add(key, string.Empty);
                    }
                }
                else
                {
                    if (isBrace)
                    {
                        if (item.Contains(")"))
                        {
                            lstDic[key] = lstDic[key] + item.Replace(")", string.Empty) + CONST.CHAR_SPACE;
                        }
                        else
                        {
                            lstDic[key] = lstDic[key] + item.Replace("(", string.Empty) + CONST.CHAR_SPACE;
                        }
                    }
                    else
                    {
                        lstDic[key] = lstDic[key] + item + CONST.CHAR_SPACE;
                    }

                    if (index == arrText.Length)
                    {
                        lstDic[key] = CompareString(lstDic[key]);
                    }
                }

                if (item.Contains(")"))
                {
                    resultCompare = resultCompare + CompareString(lstDic[key]);

                    string[] arrResult = resultCompare.Split(CONST.CHAR_SPACE);

                    if (arrResult.Length == 3)
                    {
                        lstDic[key] = CompareConditional(bool.Parse(arrResult[0]), arrResult[1], bool.Parse(arrResult[2])).ToString();
                        isBrace = false;
                    }
                    else if (arrText.Length > 3)
                    {
                        bool result = bool.Parse(arrResult[0]);
                        for (int i = 1; i < arrResult.Length; i = i + 2)
                        {
                            result = CompareConditional(result, arrResult[i], bool.Parse(arrResult[i + 1]));
                        }
                        lstDic[key] = result.ToString();
                        isBrace = false;
                    }
                }
            }
            return lstDic;
        }

        private static bool CompareConditional(bool left, string operators, bool right)
        {
            switch (operators)
            {
                case "And": case "AND": case "&&": return left && right;
                case "Or": case "OR": case "||": return left || right;
                default: throw new ArgumentException("Invalid comparison operator: {0}", operators);
            }
        }

        private static string CompareString(string text)
        {
            text = text.Trim();
            string[] arrText = text.Split(CONST.CHAR_SPACE);

            if (arrText.Length == 1 && (CONST.STRING_FALSE.Equals(arrText[0]) || CONST.STRING_TRUE.Equals(arrText[0])))
            {
                return text;
            }
            else if (arrText.Length == 3)
            {
                if (CONST.STRING_EMPTY.Equals(arrText[0]) || CONST.STRING_CHECK_EMPTY.Equals(arrText[0]))
                {
                    arrText[0] = string.Empty;
                }
                if (CONST.STRING_EMPTY.Equals(arrText[2]) || CONST.STRING_CHECK_EMPTY.Equals(arrText[2]))
                {
                    arrText[2] = string.Empty;
                }

                return CompareOperators(arrText[0], arrText[1], arrText[2]).ToString();
            }
            return string.Empty;
        }

        private static bool CompareOperators<ICompare>(ICompare left, string operators, ICompare right) where ICompare : IComparable
        {

            switch (operators)
            {
                case "==":
                case "=": return left.CompareTo(right) == 0;
                case "!=":
                case "<>": return left.CompareTo(right) != 0;
                case ">": return left.CompareTo(right) > 0;
                case ">=": return left.CompareTo(right) >= 0;
                case "<": return left.CompareTo(right) < 0;
                case "<=": return left.CompareTo(right) <= 0;
                default: throw new ArgumentException("Invalid comparison operator: {0}", operators);
            }
        }

        public static StringBuilder CreateAppenIn(string model, string tab)
        {
            StringBuilder sb = new StringBuilder();

            if (model == "0")
            {
                sb.Append(tab + "b.Append(inModel.{0}).Append({1}) // {2}");
            }
            else if (model == "1")
            {
                sb.Append(tab + " .Append(inModel.{0}).Append({1});// {2}");
            }
            else if (model == "2")
            {
                sb.Append(tab + " .Append(inModel.{0});            // {2}");
            }
            else if (model == "3")
            {
                sb.Append(tab + "b.Append(DataJoin({0}List, {1})).Append({2}) // {3}");
            }
            else if (model == "4")
            {
                sb.Append(tab + " .Append(DataJoin({0}List, {1})).Append({2}) // {3}");
            }
            else if (model == "5")
            {
                sb.Append(tab + "b.Append(DataJoin({0}List, {1}));// {2}");
            }
            else if (model == "6")
            {
                sb.Append(tab + "b.Append(DataJoin({0}List, {1})).Append({2});// {3}");
            }
            else if (model == "7")
            {
                sb.Append(tab + " .Append(DataJoin({0}List, {1})); // {2}");
            }
            else
            {
                sb.Append(tab + " .Append(inModel.{0}).Append({1}) // {2}");
            }

            return sb;
        }

        public static StringBuilder CreateTemplateForEachInOpen(string tab)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(CONST.STRING_ADD_LINE + CONST.STRING_ADD_LINE)
              .Append(tab + "List<string> {0}List = new List<string>;\r\n")
              .Append(tab + "foreach ({1} obj{1} in inModel.{1}List)\r\n");
            return sb;
        }

        public static StringBuilder CreateTemplateForEachInClose(string tab)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(tab + "{0}List.Add(sb.ToString());").Append(CONST.STRING_ADD_LINE)
              .Append(tab + "}");
            return sb;
        }

        public static string CreateComment(string input)
        {
            return "// " + input + CONST.STRING_ADD_LINE;
        }

        public static string FirstCharToLowerCase(string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string FirstCharToUpperCase(string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str[0]))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }
        #endregion
    }
}
