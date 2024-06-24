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

        public static string ConvertSQLToCType(string type)
        {
            switch (type)
            {
                case var varchar when type.Contains(CONST.SQL_TYPE_VARCHAR):
                case var nvarchar when type.Contains(CONST.SQL_TYPE_NVARCHAR):
                    return CONST.C_TYPE_STRING;
                case CONST.SQL_TYPE_DATE:
                case CONST.SQL_TYPE_DATE_TIME:
                    return CONST.C_TYPE_DATE_TIME;
                case CONST.SQL_TYPE_SMALLINT:
                    return CONST.C_TYPE_SHORT;
                case CONST.SQL_TYPE_BIGINT:
                    return CONST.C_TYPE_LONG;
                case CONST.SQL_TYPE_MONEY:
                case CONST.SQL_TYPE_NUMERIC:
                case CONST.SQL_TYPE_DECIMAL:
                    return CONST.C_TYPE_DECIMAL;
                default:
                    return CONST.C_TYPE_INT;
            }
        }

        public static string CastTypeCToTs(string type)
        {
            switch (type)
            {
                case CONST.C_TYPE_BOOL:
                case CONST.C_TYPE_BOOLEAN:
                    return CONST.TS_TYPE_BOOLEAN;
                case CONST.C_TYPE_DATE_TIME:
                    return CONST.TS_TYPE_DATE;
                case CONST.C_TYPE_SHORT:
                case CONST.C_TYPE_INT:
                case CONST.C_TYPE_LONG:
                case CONST.C_TYPE_DECIMAL:
                    return CONST.TS_TYPE_NUMBER;
                case CONST.C_TYPE_STRING:
                    return CONST.C_TYPE_STRING;
                default:
                    return CONST.TS_TYPE_ANY;
            }
        }

        public static string CastTypeCToSqlMetaData(string type)
        {
            switch (type)
            {
                case CONST.C_TYPE_STRING:
                    return CONST.SQL_META_DATA_NTEXT;
                case CONST.C_TYPE_BOOL:
                    return CONST.SQL_META_DATA_BIT;
                case CONST.C_TYPE_DATE_TIME:
                    return CONST.C_TYPE_DATE_TIME;
                case CONST.C_TYPE_SHORT:
                    return CONST.SQL_META_DATA_SMALL_INT;
                case CONST.C_TYPE_INT:
                    return CONST.SQL_META_DATA_INT;
                case CONST.C_TYPE_LONG:
                    return CONST.SQL_META_DATA_BIG_INT;
                case CONST.C_TYPE_DECIMAL:
                    return CONST.SQL_META_DATA_MONEY;
                case CONST.C_TYPE_DOUBLE:
                    return CONST.SQL_META_DATA_FLOAT;
                default:
                    return string.Empty;
            }
        }

        public static string CastTypeCToSqlDataRecord(string type)
        {
            switch (type)
            {
                case CONST.C_TYPE_STRING:
                    return CONST.SQL_DATA_RECORD_STRING;
                case CONST.C_TYPE_BOOL:
                    return CONST.SQL_DATA_RECORD_BOOLEAN;
                case CONST.C_TYPE_DATE_TIME:
                    return CONST.SQL_DATA_RECORD_DATE_TIME;
                case CONST.C_TYPE_SHORT:
                    return CONST.SQL_DATA_RECORD_INT16;
                case CONST.C_TYPE_INT:
                    return CONST.SQL_DATA_RECORD_INT32;
                case CONST.C_TYPE_LONG:
                    return CONST.SQL_DATA_RECORD_INT64;
                case CONST.C_TYPE_DECIMAL:
                    return CONST.SQL_DATA_RECORD_MONEY;
                case CONST.C_TYPE_DOUBLE:
                    return CONST.SQL_DATA_RECORD_DOUBLE;
                default:
                    return string.Empty;
            }
        }

        public static bool IsDefaultTypeC(string type)
        {
            return !type.Equals(CONST.C_TYPE_STRING) && !type.Equals(CONST.C_TYPE_BOOL) &&
                !type.Contains(CONST.STRING_LIST_EN + CONST.STRING_OPEN_TAG);
        }

        public static string AddDefaultTypeC(string type)
        {
            if (IsDefaultTypeC(type))
            {
                return type + CONST.STRING_QUESTION;
            }
            else
            {
                return type;
            }
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

        public static string CreTmlHTMLComment(string value)
        {
            return CONST.STRING_COMMENT_O_HTML + value + CONST.STRING_COMMENT_C_HTML;
        }

        public static string CreTmlFileControllerC(string logicName, string physycalName, string path)
        {
            logicName = logicName.Replace(CONST.STRING_JP_CONTROLLER, string.Empty);
            physycalName = physycalName.Replace(CONST.STRING_CONTROLLER, string.Empty);
            path = path.Replace(CONST.STRING_SLASH, CONST.STRING_DOT);

            if (path.First() == CONST.CHAR_DOT) path = path.Substring(1);
            if (path.Last() == CONST.CHAR_DOT) path = path.Remove(path.Length - 1);

            StringBuilder sb = new StringBuilder();
            sb.Append("using Microsoft.AspNetCore.Mvc;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("namespace {0}").Append(CONST.STRING_ADD_LINE);
            sb.Append("{{").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// {1}コントローラ。").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    [MyApiController]").Append(CONST.STRING_ADD_LINE);
            sb.Append("    public class {2}Controller : ControllerBase").Append(CONST.STRING_ADD_LINE);
            sb.Append("    {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("        // {1}サービス。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        private readonly {2}Service _service;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// 新しいインスタンスを初期化します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"service\">{1}サービス。</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        public {2}Controller({2}Service service)").Append(CONST.STRING_ADD_LINE);
            sb.Append("        {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("            _service = service;").Append(CONST.STRING_ADD_LINE);
            sb.Append("        }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("    }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("}}");

            return string.Format(sb.ToString(), path, logicName, physycalName);
        }

        public static string CreTmlFileServiceC(string logicName, string physycalName, string path)
        {
            logicName = logicName.Replace(CONST.STRING_JP_SERVICE, string.Empty);
            physycalName = physycalName.Replace(CONST.STRING_SERVICE, string.Empty);
            path = path.Replace(CONST.STRING_LIB, string.Empty).Replace(CONST.STRING_SLASH, CONST.STRING_DOT);

            if (path.First() == CONST.CHAR_DOT) path = path.Substring(1);
            if (path.Last() == CONST.CHAR_DOT) path = path.Remove(path.Length - 1);

            StringBuilder sb = new StringBuilder();
            sb.Append("using AutoMapper;").Append(CONST.STRING_ADD_LINE);
            sb.Append("using ITS.UsoliaShogai.Data;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("namespace {0}").Append(CONST.STRING_ADD_LINE);
            sb.Append("{{").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// {1}サービス。").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    public class {2}Service").Append(CONST.STRING_ADD_LINE);
            sb.Append("    {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("        // 悲観的排他制御。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        private readonly LockService _lockService;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        // リポジトリ—を管理します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        private readonly RepositoryManager<{2}Repository> _repository;").Append(CONST.STRING_ADD_LINE);
            sb.Append("        private readonly IMapper _mapper;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// 新しいインスタンスを初期化します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"lockService\">ロックサービスのインスタンス。</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"repository\">レポジトリーのインスタンス。</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"mapper\">ビューモデル内のマッパー データ。</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        public {2}Service(LockService lockService,  RepositoryManager<{2}Repository> repository, IMapper mapper)").Append(CONST.STRING_ADD_LINE);
            sb.Append("        {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("            _lockService = lockService;").Append(CONST.STRING_ADD_LINE);
            sb.Append("            _repository = repository;").Append(CONST.STRING_ADD_LINE);
            sb.Append("            _mapper = mapper;").Append(CONST.STRING_ADD_LINE);
            sb.Append("        }}").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// ビューモデルを初期化します。マスタの参照、空明細への補填など、どのモードでも必要な処理を行います。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"model\">{1}ViewModel。</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        public void InitializeViewModel({2}ViewModel model)").Append(CONST.STRING_ADD_LINE);
            sb.Append("        {{").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("    }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("}}");

            return string.Format(sb.ToString(), path, logicName, physycalName);
        }

        public static string CreTmlFileRepositoryC(string logicName, string physycalName, string path)
        {
            logicName = logicName.Replace(CONST.STRING_JP_REPOSITORY, string.Empty);
            physycalName = physycalName.Replace(CONST.STRING_REPOSITORY, string.Empty);
            path = path.Replace(CONST.STRING_LIB, string.Empty).Replace(CONST.STRING_SLASH, CONST.STRING_DOT);

            if (path.First() == CONST.CHAR_DOT) path = path.Substring(1);
            if (path.Last() == CONST.CHAR_DOT) path = path.Remove(path.Length - 1);

            StringBuilder sb = new StringBuilder();
            sb.Append("using Dapper;").Append(CONST.STRING_ADD_LINE);
            sb.Append("using System.Data;").Append(CONST.STRING_ADD_LINE);
            sb.Append("using System.Data.Common;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("namespace {0}").Append(CONST.STRING_ADD_LINE);
            sb.Append("{{").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// {1}リポジトリ。").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    public class {2}Repository").Append(CONST.STRING_ADD_LINE);
            sb.Append("    {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("        // データベース接続。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        private readonly DbConnection _connection;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// 新しいインスタンスを初期化します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"connection\"></param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        public {2}Repository(DbConnection connection)").Append(CONST.STRING_ADD_LINE);
            sb.Append("        {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("            _connection = connection;").Append(CONST.STRING_ADD_LINE);
            sb.Append("        }}").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("    }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("}}");

            return string.Format(sb.ToString(), path, logicName, physycalName);

        }

        public static string CreTmlFileViewModelC(string logicName, string physycalName, string path)
        {
            logicName = logicName.Replace(CONST.STRING_JP_VIEW_MODEL, string.Empty);
            physycalName = physycalName.Replace(CONST.STRING_VIEW_MODEL, string.Empty);
            path = path.Replace(CONST.STRING_LIB, string.Empty).Replace(CONST.STRING_SLASH, CONST.STRING_DOT);

            if (path.First() == CONST.CHAR_DOT) path = path.Substring(1);
            if (path.Last() == CONST.CHAR_DOT) path = path.Remove(path.Length - 1);

            StringBuilder sb = new StringBuilder();
            sb.Append("using ITS.Usolia.Mvc.Data;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("namespace {0}").Append(CONST.STRING_ADD_LINE);
            sb.Append("{{").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// {1}画面のビューモデルです。").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    [AutoMappable(typeof())]").Append(CONST.STRING_ADD_LINE);
            sb.Append("    public class {2}ViewModel : ViewModel").Append(CONST.STRING_ADD_LINE);
            sb.Append("    {{").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("    }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("}}");

            return string.Format(sb.ToString(), path, logicName, physycalName);
        }

        public static string CreTmlFileEntityC(string logicName, string physycalName, string path)
        {
            path = path.Replace(CONST.STRING_LIB, string.Empty).Replace(CONST.STRING_SLASH, CONST.STRING_DOT);

            if (path.Contains(CONST.STRING_ENTITIES)) path = path.Remove(path.LastIndexOf(CONST.STRING_ENTITIES)) + CONST.STRING_ENTITIES;

            if (path.First() == CONST.CHAR_DOT) path = path.Substring(1);
            if (path.Last() == CONST.CHAR_DOT) path = path.Remove(path.Length - 1);

            if (string.IsNullOrEmpty(logicName)) logicName = physycalName;

            StringBuilder sb = new StringBuilder();
            sb.Append("namespace {0}").Append(CONST.STRING_ADD_LINE);
            sb.Append("{{").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// データを保存する主体【{1}】。").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    public class {2}").Append(CONST.STRING_ADD_LINE);
            sb.Append("    {{").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("    }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("}}").Append(CONST.STRING_ADD_LINE);

            return string.Format(sb.ToString(), path, logicName, physycalName);
        }

        public static string CreTmlFileParameters(string logicName, string physycalName, string path)
        {
            path = path.Replace(CONST.STRING_LIB, string.Empty).Replace(CONST.STRING_SLASH, CONST.STRING_DOT);

            if (path.First() == CONST.CHAR_DOT) path = path.Substring(1);
            if (path.Last() == CONST.CHAR_DOT) path = path.Remove(path.Length - 1);

            if (string.IsNullOrEmpty(logicName)) logicName = physycalName;

            StringBuilder sb = new StringBuilder();
            sb.Append("using Dapper;").Append(CONST.STRING_ADD_LINE);
            sb.Append("using ITS.Usolia.Mvc;").Append(CONST.STRING_ADD_LINE);
            sb.Append("using System.Data;").Append(CONST.STRING_ADD_LINE);
            sb.Append("using System.Data.SqlClient;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("namespace {0}").Append(CONST.STRING_ADD_LINE);
            sb.Append("{{").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// クラスビルディングデータ【{1}】。").Append(CONST.STRING_ADD_LINE);
            sb.Append("    /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("    internal class {2} : SqlMapper.IDynamicParameters").Append(CONST.STRING_ADD_LINE);
            sb.Append("    {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("        // ").Append(CONST.STRING_ADD_LINE);
            sb.Append("        private readonly IEnumerable<> _entity;").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// 新しいインスタンスを初期化します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"entity\"></param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <returns></returns>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        public {2}(IEnumerable<> entity)").Append(CONST.STRING_ADD_LINE);
            sb.Append("        {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("            _entity = entity;").Append(CONST.STRING_ADD_LINE);
            sb.Append("        }}").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// パラメーターを追加します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"command\">IDbCommand</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"identity\">SqlMapper.Identity</param>  ").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <returns></returns>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        internal void AddParameters(IDbCommand command, SqlMapper.Identity identity)").Append(CONST.STRING_ADD_LINE);
            sb.Append("        {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("            command.Parameters.Add(new SqlParameter()").Append(CONST.STRING_ADD_LINE);
            sb.Append("            {{").Append(CONST.STRING_ADD_LINE);
            sb.Append("                ParameterName = \"@\",").Append(CONST.STRING_ADD_LINE);
            sb.Append("                Value = _entity.ToDataTable(),").Append(CONST.STRING_ADD_LINE);
            sb.Append("                TypeName = \"\",").Append(CONST.STRING_ADD_LINE);
            sb.Append("                SqlDbType = SqlDbType.Structured").Append(CONST.STRING_ADD_LINE);
            sb.Append("            }});").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("            // DBNull.Value 対応").Append(CONST.STRING_ADD_LINE);
            sb.Append("            var nullParameters = command.Parameters.Cast<SqlParameter>().").Append(CONST.STRING_ADD_LINE);
            sb.Append("                    Where(x => x.SqlDbType != SqlDbType.Structured).").Append(CONST.STRING_ADD_LINE);
            sb.Append("                    Where(x => x.Value is null);").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("            foreach (SqlParameter parameter in nullParameters)").Append(CONST.STRING_ADD_LINE);
            sb.Append("                parameter.Value = DBNull.Value;").Append(CONST.STRING_ADD_LINE);
            sb.Append("        }}").Append(CONST.STRING_ADD_LINE);
            sb.Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// パラメーターを追加します。").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// </summary>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"command\">IDbCommand</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <param name=\"identity\">SqlMapper.Identity</param>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        /// <returns></returns>").Append(CONST.STRING_ADD_LINE);
            sb.Append("        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity) => AddParameters(command, identity);").Append(CONST.STRING_ADD_LINE);
            sb.Append("    }}").Append(CONST.STRING_ADD_LINE);
            sb.Append("}}").Append(CONST.STRING_ADD_LINE);

            return string.Format(sb.ToString(), path, logicName, physycalName);
        }

        public static string CreTmlModelC(int mode)
        {
            StringBuilder sb = new StringBuilder();
            if (mode == 0)
            {
                sb.Append("/// <summary>\r\n");
                sb.Append("/// {0}\r\n");
                sb.Append("/// </summary>\r\n");
            }
            else if (mode == 1)
            {
                sb.Append("// {0}\r\n");
            }
            else if (mode == 2)
            {
                sb.Append("/* {0} */\r\n");
            }
            sb.Append("public {1} {2} {{ get; set; }}");

            return sb.ToString();
        }

        public static string CreTmlCheckValueC()
        {
            return "{0}.HasValue ? col.{0}.Value : {1}.Null";
        }

        public static string CreHTMLRowSpan(string num)
        {
            return string.Format(" [attr.rowspan]=\"{0}\"", num);
        }

        public static string CreHTMLColSpan(string num)
        {
            return string.Format(" [attr.colspan]=\"{0}\"", num);
        }
        #endregion

        #region Method
        public static string FormatCode(int mode, string input, int maxLengthRow, bool isBlankLine = false)
        {
            string result = string.Empty;
            string[] lstInput = input.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            string charComment = "/**";
            if (mode == 1) charComment = "//";
            if (mode == 2) charComment = "<!--";

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

        public static string FormatTab(string text)
        {
            string strRegex = @"[\t]+";
            Regex myRegex = new Regex(strRegex, RegexOptions.None);
            return myRegex.Replace(text, CONST.STRING_TAB);
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

        public static string GetRangeNumber(string input)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(input)) return result;

            int length;
            if (int.TryParse(input, out length))
            {
                while (result.Length < length)
                {
                    result += "9";
                }
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

        public static string RemoveLastLineBlank(string str)
        {
            int lastIndex = str.LastIndexOf("\r\n");
            if (lastIndex != -1 && lastIndex == str.Length - 2)
            {
                str = str.Substring(0, lastIndex);
                str = RemoveLastLineBlank(str);
            }
            return str;
        }

        public static string RemoveLastCommaSpace(string str)
        {
            int lastIndex = str.LastIndexOf(CONST.STRING_COMMA + CONST.STRING_SPACE);
            if (lastIndex != -1 && lastIndex == str.Length - 2)
            {
                str = str.Substring(0, lastIndex);
                str = RemoveLastLineBlank(str);
            }
            return str;
        }

        public static double CountTotal(List<string> lstData)
        {
            double total = 0;
            bool isFristRow = false;
            foreach (string row in lstData)
            {
                if (string.IsNullOrEmpty(row) || row.Equals(CONST.STRING_SETTING_HTML_ADD_ROW)) continue;

                if (row.Contains(CONST.STRING_SETTING_HTML_ADD_ROW))
                {
                    if (!isFristRow)
                    {
                        isFristRow = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                string[] arrColumn = row.Replace(CONST.STRING_SETTING_HTML_ADD_ROW, string.Empty).Split(CONST.CHAR_COMMA);
                if (arrColumn.Length > 2)
                {
                    total += Convert.ToDouble(arrColumn[0]);
                }
                else
                {
                    total += Convert.ToDouble(row);
                }
            }

            return total;
        }
        #endregion
    }
}