using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ToolSupportCoding.Utils
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
        #endregion

        #region Create Template
        public static string CreateAppenIn(string model, string tab)
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

            return sb.ToString();
        }

        public static string CreTmlAdapForEachIn(string tab)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(CONST.STRING_ADD_LINE + CONST.STRING_ADD_LINE)
              .Append(tab + "List<string> {0}List = new List<string>;\r\n")
              .Append(tab + "foreach ({1} obj{1} in inModel.{1}List)\r\n");
            return sb.ToString();
        }

        public static string CreTmlAdapForEachOut(string tab, int index, string model)
        {
            string dAry = index > 1 ? "dAry" + index : "dAry";
            StringBuilder sb = new StringBuilder();

            if (model == "0")
            {
                sb.Append(tab + "foreach (string row in DataSplit(pOut, {0}))\r\n");
            }
            else if (model == "1")
            {
                sb.Append(tab + "foreach (string row in DataSplit(" + dAry + "[idx++], {0}))\r\n");
            }

            return sb.ToString();
        }

        public static string CreTmlAdapModelOut(string tab, string model)
        {
            StringBuilder sb = new StringBuilder();

            if (model == "0")
            {
                sb.Append(tab + "{0} outputModel = new {0}();\r\n\r\n");
            }
            else if (model == "1")
            {
                sb.Append(tab + "{0} {1} = new {0}();\r\n\r\n");
            }
            else if (model == "2")
            {
                sb.Append(tab + "List<{0}> outputModelList = new List<{0}>();\r\n");
            }

            return sb.ToString();
        }

        public static string CreTmlAdapListObjOut(string tab, int index, string model)
        {
            string dAry = index > 1 ? "dAry" + index : "dAry";
            string idx = index > 1 ? "idx" + index : "idx";

            StringBuilder sb = new StringBuilder();

            if (model == "0")
            {
                sb.Append(tab + "// {0}\r\n")
                  .Append(tab + "outputModel.{1}List = new List<{1}>();\r\n");
            }
            else if (model == "1")
            {
                sb.Append(tab + "// {0}\r\n")
                  .Append(tab + "outputModel.{1}List = DataSplit(" + dAry + "[" + idx + "++], {2}).ToList();\r\n");
            }
            if (model == "2")
            {
                sb.Append(tab + "// {0}\r\n")
                  .Append(tab + "{1}.{2}List = new List<{2}>();\r\n");
            }
            else if (model == "3")
            {
                sb.Append(tab + "// {0}\r\n")
                  .Append(tab + "{1}.{2}List = DataSplit(" + dAry + "[" + idx + "++], {3}).ToList();\r\n");
            }
            return sb.ToString();
        }

        public static string CreTmlAdapArrayOut(string tab, int index)
        {
            string dAry = index > 1 ? "dAry" + index : "dAry";
            string idx = index > 1 ? "idx" + index : "idx";

            StringBuilder sb = new StringBuilder();

            sb.Append(tab + "int " + idx + " = 0;\r\n")
              .Append(tab + "string[] " + dAry + " = DataSplit(row, {0});\r\n\r\n");

            return sb.ToString();
        }

        public static string CreTmlAdapOut(string tab, int index, string model)
        {
            string dAry = index > 1 ? "dAry" + index : "dAry";
            string idx = index > 1 ? "idx" + index : "idx";

            StringBuilder sb = new StringBuilder();

            if (model == "0")
            {
                sb.Append(tab + "// {0}\r\n")
                  .Append(tab + "outputModel.{1} = " + dAry + "[" + idx + "++];\r\n");
            }
            else if (model == "1")
            {
                sb.Append(tab + "// {0}\r\n")
                  .Append(tab + "{1}.{2} = " + dAry + "[" + idx + "++];\r\n");
            }

            return sb.ToString();
        }

        public static string CreTmlAdapAddListOut(string tab, string model)
        {
            StringBuilder sb = new StringBuilder();

            if (model == "0")
            {
                sb.Append(tab + "outputModel.{0}.Add({1});\r\n");
            }
            else if (model == "1")
            {
                sb.Append(tab + "{0}.{1}.Add({2});\r\n");
            }

            return sb.ToString();
        }

        public static string CreateComment(string input)
        {
            return "// " + input + CONST.STRING_ADD_LINE;
        }

        public static string CreTmlCommonCaseOut(string tab)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(tab + "\"Case\": \"{0}\",").Append(CONST.STRING_ADD_LINE)
              .Append(tab + "\"Outp\": \"{1}\",").Append(CONST.STRING_ADD_LINE)
              .Append(tab + "\"Data\": ");
            return sb.ToString(); ;
        }

        public static string CreTmlCommonAddData(string tab, bool isLast)
        {
            StringBuilder sb = new StringBuilder();
            if (isLast)
            {
                return sb.Append(tab + "\"{0}\": \"{1}\"").Append(CONST.STRING_ADD_LINE).ToString();
            }
            else
            {
                return sb.Append(tab + "\"{0}\": \"{1}\",").Append(CONST.STRING_ADD_LINE).ToString();
            }

        }

        public static string CreTmlCommonAddArr(string tab, bool isLast)
        {
            StringBuilder sb = new StringBuilder();

            if (isLast)
            {
                return sb.Append(tab + "\"{0}\": [{1}]").Append(CONST.STRING_ADD_LINE).ToString();
            }
            else
            {
                return sb.Append(tab + "\"{0}\": [{1}],").Append(CONST.STRING_ADD_LINE).ToString();
            }
        }

        public static string CreTmlCommonObj(string tab)
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append(tab + "\"{0}\": ").ToString();
        }

        public static string CreTmlMess(string mode)
        {
            StringBuilder sb = new StringBuilder();
            if (mode == "0")
            {
                return sb.Append("{0}={1}").Append(CONST.STRING_ADD_LINE).ToString();
            }
            else
            {
                return sb.Append("{0}={1}[%EQ%]{2}").Append(CONST.STRING_ADD_LINE).ToString();
            }
        }
        #endregion

        #region Method
        public static string FormatCode(int mode, string input, int maxLengthRow, bool isBlankLine = false)
        {
            string result = string.Empty;
            string[] lstInput = input.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            string charComment = "/**";
            if (mode == 1) charComment = "//";

            foreach (string line in lstInput)
            {
                int lengthText = line.LastIndexOf(charComment);
                if (lengthText != -1 && lengthText < maxLengthRow)
                {
                    string textAdd = new string(CONST.CHAR_SPACE, maxLengthRow - lengthText);

                    string textComment = line.Substring(lengthText - 1, line.Length - lengthText + 1);
                    if (!textComment.Contains(charComment + " ")) textComment = textComment.Replace(charComment, charComment + " ");

                    result += line.Substring(0, lengthText - 1) + textAdd + textComment + CONST.STRING_ADD_LINE;
                    if (isBlankLine) result += CONST.STRING_ADD_LINE;
                }
                else
                {
                    result = result + line + CONST.STRING_ADD_LINE;
                    if (isBlankLine) result += CONST.STRING_ADD_LINE;
                }
            }

            return result;
        }

        public static string CreateTab(ref int indexTab)
        {
            indexTab++;
            int length = indexTab * 4;
            return new string(CONST.CHAR_SPACE, length);
        }

        public static string CreateSpace(int length)
        {
            return new string(CONST.CHAR_SPACE, length);
        }

        public static string RemoveTab(ref int indexTab)
        {
            indexTab--;
            if (indexTab < 0)
            {
                indexTab = 0;
            }
            int length = indexTab * 4;
            return new string(CONST.CHAR_SPACE, length);
        }

        public static string RemoveEndTab(string input)
        {
            if (string.IsNullOrEmpty(input) || input == string.Empty)
            {
                return input;
            }

            while (input.Last().Equals(CONST.CHAR_TAB))
            {
                input = input.Substring(0, input.Length - 1);
            }

            return input;
        }

        public static int GetNumTab(string input)
        {
            int result = 0;
            if (string.IsNullOrEmpty(input) || input == string.Empty)
            {
                return 0;
            }

            while (input.First().Equals(CONST.CHAR_TAB))
            {
                result++;
                input = input.Substring(1, input.Length - 1);
            }

            return result;
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

        public static string removeLastLineBlank(string str)
        {
            int lastIndex = str.LastIndexOf("\r\n");
            if (lastIndex != -1 && lastIndex == str.Length - 2)
            {
                str = str.Substring(0, lastIndex);
                str = removeLastLineBlank(str);
            }
            return str;
        }
        #endregion
    }

}
