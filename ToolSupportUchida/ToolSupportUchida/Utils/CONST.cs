using System;

namespace ToolSupportCoding.Utils
{
    public static class CONST
    {
        public static string FILE_PATH = AppContext.BaseDirectory + @"\ToolSupportData.bin";
        public static string FILE_PATH_IMPORT = AppContext.BaseDirectory + @"\sekkei.cldb";
        public static string[] STRING_SEPARATORS = new string[] { STRING_NEW_LINE };
        public static string[] STRING_SEPARATORS_TABLE = new string[] { STRING_C_SQU_BRACKETS_SPACE };

        #region Item
        public static string ITEM_CHAR_FORMAT_EQUALS = "Split: = || End: \\r\\n";
        public static string ITEM_CHAR_FORMAT_TAB = "Split: [--] || End: <br>";

        public static string ITEM_HTML = "HTML";
        public static string ITEM_SETTING = "Setting";

        public static string ITEM_KEY = "key";
        public static string ITEM_VALUE = "value";
        #endregion

        #region Char
        public const char CHAR_NEW_LINE = '\n';
        public const char CHAR_CARRIAGE_RETUR = '\r';
        public const char CHAR_TAB = '\t';
        public const char CHAR_DOT = '.';
        public const char CHAR_SPACE = ' ';
        public const char CHAR_AMPERSAND = '&';
        public const char CHAR_QUOTATION = '"';
        public const char CHAR_COMMA = ',';
        public const char CHAR_O_BRACKETS = '(';
        public const char CHAR_C_BRACKETS = ')';
        public const char CHAR_O_CUR_BRACKETS = '{';
        public const char CHAR_C_CUR_BRACKETS = '}';
        public const char CHAR_O_SQU_BRACKETS = '[';
        public const char CHAR_C_SQU_BRACKETS = ']';
        public const char CHAR_EQUALS = '=';
        public const char CHAR_O_TAG = '<';
        public const char CHAR_SLASH = '/';
        public const char CHAR_TILDE = '~';
        public const char CHAR_COLON = ':';
        #endregion

        #region String
        public const string STRING_NEW_LINE = "\n";
        public const string STRING_CARRIAGE_RETUR = "\r";
        public const string STRING_DOUBLE_LINE = "\n\n";
        public const string STRING_ADD_LINE = "\r\n";
        public const string STRING_SPACE = " ";
        public const string STRING_DOUBLE_APOSTROPHE = "''";
        public const string STRING_TAB = "\t";
        public const string STRING_COMMA = ",";
        public const string STRING_TILDE = "~";
        public const string STRING_QUOTATION_MARKS = "\"";
        public const string STRING_DOT = ".";
        public const string STRING_DOT_2B = "。";
        public const string STRING_APOSTROPHE = "'";
        public const string STRING_HYPHEN = "-";
        public const string STRING_UNDERSCORE = "_";
        public const string STRING_QUESTION = "?";
        public const string STRING_BR = "<br>";
        public const string STRING_BR_REPLACE = "&lt;br&gt;";
        public const string STRING_OPEN_TAG = "<";
        public const string STRING_END_TAG = "/>";
        public const string STRING_C_SIGN = ">";
        public const string STRING_SLASH = "/";
        public const string STRING_O_BRACKETS = "(";
        public const string STRING_O_BRACKETS_2B = "（";
        public const string STRING_C_BRACKETS = ")";
        public const string STRING_C_BRACKETS_2B = "）";
        public const string STRING_O_CUR_BRACKETS = "{";
        public const string STRING_C_CUR_BRACKETS = "}";
        public const string STRING_O_SQU_BRACKETS = "[";
        public const string STRING_C_SQU_BRACKETS = "]";
        public const string STRING_C_SQU_BRACKETS_SPACE = "] ";
        public const string STRING_C_O_SQU_BRACKETS_SPACE = "] [";
        public const string STRING_DC_CUR_BRACKETS = "}}";
        public const string STRING_NOTE = "〇";
        public const string STRING_BACKUP_NAME = ".bk";
        public const string STRING_CONTROLLER = "Controller";
        public const string STRING_SERVICE = "Service";
        public const string STRING_REPOSITORY = "Repository";
        public const string STRING_VIEW_MODEL = "ViewModel";
        public const string STRING_PATH_VIEW_MODEL = "view-models";
        public const string STRING_PARAMETERS = "Parameters";
        public const string STRING_DATA_SOURCE = "DataSource";
        public const string STRING_MODEL = "Model";
        public const string STRING_ENTITY = "Entity";
        public const string STRING_ENTITIES = "Entities";
        public const string STRING_COMPONENT = ".component";
        public const string STRING_LIB = ".Lib";
        public const string STRING_REPORT = "Report";
        public const string STRING_LABEL_REPORT = "LabelReport";
        public const string STRING_FIELD_REPORT = "FieldReport";
        public const string STRING_CHECKBOX_REPORT = "CheckBoxReport";
        public const string STRING_IMAGE_REPORT = "ImageReport";
        public const string STRING_SUB_REPORT = "SubreportReport";
        public const string STRING_REPORT_CLASS_NAME = "ClassName=\"Title\"";
        public const string STRING_REPORT_ALIGN_CENTER = "text-align: center; ";
        public const string STRING_REPORT_ALIGN_RIGHT = "text-align: right; ";
        public const string STRING_REPORT_NAME = ".rpx";

        // Const string JP
        public const string STRING_JP_CONTROLLER = "コントローラ";
        public const string STRING_JP_SERVICE = "サービス";
        public const string STRING_JP_REPOSITORY = "リポジトリ";
        public const string STRING_JP_VIEW_MODEL = "情報ViewModel";
        public const string STRING_JP_CODE = "コード";
        public const string STRING_JP_ITEM = "項目";
        public const string STRING_JP_FONT_SIZE = "大";
        public const string STRING_JP_ALIGN_CENTER = "中央寄せ";
        public const string STRING_JP_ALIGN_RIGHT = "右寄せ";

        // Const string VN
        public const string STRING_VN_FONT_SIZE = "LỚN";
        public const string STRING_VN_ALIGN_CENTER = "CĂN GIỮA";
        public const string STRING_VN_ALIGN_RIGHT = "CĂN PHẢI";

        public const string STRING_RESOURCES = "Resources";
        public const string STRING_VALUE = "Value";
        public const string STRING_COMMENT = "Comment";

        // Const using create Item
        public const string STRING_FORM_VALUE = "{-}";
        public const string STRING_NAME_ID = "ID";
        public const string STRING_TAG_FH = "${F:H(";
        public const string STRING_TAG_TEST = "TEST";
        public const string STRING_TEST = "${";
        public const string STRING_TABLE = "TABLE";
        public const string STRING_LABEL = "LABEL";
        public const string STRING_BUTTON = "BUTTON";
        public const string STRING_FORMAT = "FORMAT";
        public const string STRING_MESSAGE = "message";
        public const string STRING_INPUT_TEXT = "INPUT TEXT";
        public const string STRING_FOCUS = "AutoFocus";
        public const string STRING_SIZE = "Size";
        public const string STRING_READONLY = "Readonly";
        public const string STRING_TITLE = "Title";
        public const string STRING_SPAN = "Span";

        public const string STRING_IS_SELECT_CASE = " IsSelectCase: ";
        public const string STRING_AND = "And";
        public const string STRING_AND_ALSO = "AndAlso";
        public const string STRING_OR = "Or";
        public const string STRING_OR_ELSE = "OrElse";
        public const string STRING_UPPER_AND = "AND";
        public const string STRING_UPPER_AND_ALSO = "ANDALSO";
        public const string STRING_UPPER_OR = "OR";
        public const string STRING_UPPER_OR_ELSE = "ORELSE";
        public const string STRING_KEY_LIST_DIC = "Key_{0}: ";
        public const string STRING_FALSE = "False";
        public const string STRING_TRUE = "True";
        public const string STRING_WHERE = "WHERE";
        public const string STRING_EQUAL = "=";
        public const string STRING_IS = "IS";
        public const string STRING_NULL = "NULL";
        public const string STRING_LIKE = "LIKE";
        public const string STRING_VBCRLF = "& vbCrLf";
        public const string STRING_PRIVATEM = "PRIVATE M";

        public const string STRING_EMPTY = "String.Empty";
        public const string STRING_NONE = "none";
        public const string STRING_LIST_EN = "List";
        public const string STRING_LIST_JP = "リスト";
        public const string STRING_CREATE_BUILDER = "StringBuilder b = new StringBuilder();\r\n";
        public const string STRING_APPEND = ".Append";
        public const string STRING_IS_TABLE = "hd";

        public const string STRING_CREATE = "0";
        public const string STRING_END_LINE = "1";
        public const string STRING_END = "2";
        public const string STRING_CREATE_JOIN = "3";
        public const string STRING_JOIN_LIST = "4";
        public const string STRING_JOIN_END = "5";
        public const string STRING_CREATE_JOIN_END = "6";
        public const string STRING_JOIN_LIST_END = "7";
        public const string STRING_CREATE_SPLIT = "1";
        public const string STRING_SPLIT_LIST = "1";
        public const string STRING_CREATE_LIST = "2";
        public const string STRING_SPLIT_ADD_LIST = "3";
        public const string STRING_ADD_LIST = "0";
        public const string STRING_ADD_LIST_SPLIT = "1";
        public const string STRING_CREATE_MESS = "0";
        public const string STRING_CREATE_MESS_EQ = "1";

        public const string STRING_FRS = "FRS";
        public const string STRING_FRM = "FRM";
        public const string STRING_CALL = "CALL";
        public const string STRING_HLP = "HLP";
        public const string STRING_MSGBOX = "MSGBOX";

        public const string STRING_GET = "Get";
        public const string STRING_SET = "Set";
        public const string STRING_RETURN = "return";
        public const string STRING_EDIT = "Edit";
        public const string STRING_DEL = "Delete";
        public const string STRING_REPLACE = "Replace";
        public const string STRING_CREATE_TABLE = "CREATE TABLE";

        public const string STRING_FUNCTION = "(Function(x)";
        public const string STRING_ITEM_RES_Z = "@ItemResources.";
        public const string STRING_ITEM_RES_A = "{{ItemResources.";
        public const string STRING_DATA_BIND = ".data_bind";
        public const string STRING_TD = "<td>";
        public const string STRING_TD_CLASS = "<td class=\"";
        public const string STRING_DIV_CLASS = "<div class=\"";
        public const string STRING_DIV_END = "</div>";
        public const string STRING_CLASS = ".class=\"";
        public const string STRING_CLASS_SP = ".class = \"";
        public const string STRING_OFFSET = "offset";

        public const string STRING_COMMENT_O_ZAZOR = "@*";
        public const string STRING_COMMENT_C_ZAZOR = "*@";
        public const string STRING_COMMENT_O_HTML = "<!--";
        public const string STRING_COMMENT_C_HTML = "-->";

        // Const SQL Type
        public const string SQL_TYPE_VARCHAR = "varchar";
        public const string SQL_TYPE_NVARCHAR = "nvarchar";
        public const string SQL_TYPE_DATE = "date";
        public const string SQL_TYPE_DATE_TIME = "datetime";
        public const string SQL_TYPE_BIGINT = "bigint";
        public const string SQL_TYPE_SMALLINT = "smallint";
        public const string SQL_TYPE_MONEY = "money";
        public const string SQL_TYPE_NUMERIC = "numeric";
        public const string SQL_TYPE_DECIMAL = "decimal";

        // SQL Meta Data
        public const string SQL_META_DATA_NTEXT = "NText";
        public const string SQL_META_DATA_BIT = "Bit";
        public const string SQL_META_DATA_SMALL_INT = "SmallInt";
        public const string SQL_META_DATA_INT = "Int";
        public const string SQL_META_DATA_BIG_INT = "BigInt";
        public const string SQL_META_DATA_MONEY = "Money";
        public const string SQL_META_DATA_FLOAT = "Float";

        // SQL Data Record
        public const string SQL_DATA_RECORD_STRING = "SetSqlString";
        public const string SQL_DATA_RECORD_BOOLEAN = "SetSqlBoolean";
        public const string SQL_DATA_RECORD_DATE_TIME = "SetSqlDateTime";
        public const string SQL_DATA_RECORD_INT16 = "SetSqlInt16";
        public const string SQL_DATA_RECORD_INT32 = "SetSqlInt32";
        public const string SQL_DATA_RECORD_INT64 = "SetSqlInt64";
        public const string SQL_DATA_RECORD_MONEY = "SetSqlMoney";
        public const string SQL_DATA_RECORD_DOUBLE = "SetSqlDouble";

        // Const C# Type
        public const string C_TYPE_PUBLIC = "public";
        public const string C_TYPE_STRING = "string";
        public const string C_TYPE_BOOL = "bool";
        public const string C_TYPE_BOOLEAN = "boolean";
        public const string C_TYPE_DATE_TIME = "DateTime";
        public const string C_TYPE_SHORT = "short";
        public const string C_TYPE_INT = "int";
        public const string C_TYPE_LONG = "long";
        public const string C_TYPE_DECIMAL = "decimal";
        public const string C_TYPE_DOUBLE = "double";

        // Const Typescript Type
        public const string TS_TYPE_NUMBER = "number";
        public const string TS_TYPE_DATE = "Date";
        public const string TS_TYPE_BOOLEAN = "boolean";
        public const string TS_TYPE_ANY = "any";

        // Const File Type 
        public const string C_TYPE_FILE = ".cs";

        // Angualar File Type
        public const string HTML_TYPE_FILE = ".html";
        public const string TS_TYPE_FILE = ".ts";
        public const string TS_QUERY_FILE = ".query.ts";
        public const string TS_SERVICE_FILE = ".service.ts";

        // Const string setting
        public const string STRING_SETTING_C_VIEW_MODEL = "SettingCViewModel";

        public const string STRING_SETTING_TS_VIEW_MODEL = "SettingTSViewModel";
        public const string STRING_SETTING_TS_PROPERTY = "TSProperty";
        public const string STRING_SETTING_TS_FORM = "TSForm";
        public const string STRING_SETTING_TS_MODEL = "TSModel";

        public const string STRING_SETTING_COMMON_ENTITY = "SettingCommonEntity";
        public const string STRING_SETTING_COMMON_ENTITY_MAPPER = "Mapper";
        public const string STRING_SETTING_COMMON_ENTITY_SQL_META = "CreateTargetSqlMeta";
        public const string STRING_SETTING_COMMON_ENTITY_RECORD = "CreateTargetRecord";
        public const string STRING_SETTING_COMMON_ENTITY_TARGET = "CreateTargetTmp";

        public const string STRING_SETTING_COMMON_REPORT = "SettingCreateReport";
        public const string STRING_SETTING_COMMON_FORMAT_REPORT = "FormatReport";
        public const string STRING_SETTING_COMMON_REPORT_INDEX = "IndexArr";

        public const string STRING_SETTING_HTML = "SettingHTML";
        public const string STRING_SETTING_HTML_ROW = "ucd-row";
        public const string STRING_SETTING_HTML_ADD_ROW = "--";
        public const string STRING_SETTING_HTML_COL = "ucd-col";
        public const string STRING_SETTING_HTML_TABLE = "ucd-table";
        public const string STRING_SETTING_HTML_MAT_TABLE = "mat-table";
        public const string STRING_SETTING_HTML_MAT_TABLE_MULTI = " multiTemplateDataRows";
        public const string STRING_SETTING_HTML_TABLE_COLGROUP = "ucd-table-colgroup";
        public const string STRING_SETTING_HTML_TABLE_COLUMNS = "ucd-table-columns";
        public const string STRING_SETTING_HTML_TABLE_CONTAINER = "ucd-table-container";
        public const string STRING_SETTING_HTML_TABLE_BUTTON = "ucd-table-button";
        public const string STRING_SETTING_HTML_TABLE_HEADER_ROW = "ucd-table-header-row";
        public const string STRING_SETTING_HTML_TABLE_ROW = "ucd-table-row";
        public const string STRING_SETTING_HTML_CLASS_STICKY = " [ngClass]=\"['mat-header-table-sticky']\"";

        public const string STRING_SETTING_VIEW_MODEL = "SettingViewModel";
        public const string STRING_SETTING_INDEX_ARR = "IndexArr";
        public const string STRING_SETTING_CHECK_TYPE = "CheckType";
        public const string STRING_SETTING_DEFAULT = "default";
        public const string STRING_SETTING_DISPLAY = "Display";
        public const string STRING_SETTING_FORMAT = "Format";
        public const string STRING_SETTING_DISPLAY_FORMAT = "DisplayFormat";
        public const string STRING_SETTING_UCD_LABEL = "ucd-label";
        public const string STRING_SETTING_LABEL = "label";

        public const string STRING_SETTING_LOGIC_REPLACE = "--logic-replace--";
        public const string STRING_SETTING_REQUIRED = "Required";
        public const string STRING_SETTING_LENGTH = "Length";
        public const string STRING_SETTING_RANGE = "Range";
        public const string STRING_SETTING_HISTORY = "HistoryText";
        public const string STRING_SETTING_LESS_THAN = "LessThan";
        public const string STRING_SETTING_GREATER_THAN = "GreaterThan";
        public const string STRING_SETTING_LESS_OR_EQUAL = "LessOrEqual";
        public const string STRING_SETTING_GREATER_OR_EQUAL = "GreaterOrEqual";
        #endregion

        #region Text
        public const string TEXT_SETTING = "Setting";
        public const string TEXT_CAPTION_ERROR = "Error";
        public const string TEXT_CAPTION_WARNING = "Warning";
        public const string TEXT_LINE_NUM = "Line number: ";
        #endregion

        #region Message
        public const string MESS_OPEN_FILE = "File import failed, please try again.";
        public const string MESS_ADD_NEW_LOGIC_BLANK = "A new add has caused an error. \nLogical name value is blank.";
        public const string MESS_ADD_NEW_PHYSI_BLANK = "A new add has caused an error. \nPhysical name value is blank.";
        public const string MESS_ADD_NEW_EXIST = "A new add has caused an error. \nNew added value already exists.";
        public const string MESS_DELETE_ROW = "Do you want to continue deleting this row.";
        public const string MESS_NO_RESULT = "No results found.";

        public const string MESS_FORMAT_VALUE_EMPTY = "Format Value is required, please input and Create Result again.";

        public const string MESS_ADD_NEW_JOIN_KEY_BLANK = "A new add has caused an error. \nItem Join key value is blank.";
        public const string MESS_ADD_NEW_JOIN_VALUE_BLANK = "A new add has caused an error. \nItem Join value value is blank.";

        public const string MESS_COMMON_COLUMN_SELECT_FORMAT = "Please select the type \"Format\".";
        public const string MESS_COMMON_COLUMN_INPUT_VALUE = "Please enter value.";

        public const string MESS_COMMON_CREATE_COMMENT = "Please enter value \"Input Comment\" and \"Input Code\"";

        public const string MESS_ERROR_EXCEPTION = "An abnormal error occurs in the function: {0}\nError content: ";
        #endregion

        #region Grid View
        public const string NAME_COL_LOGIC = "colLogic";
        public const string NAME_COL_PHYSI = "colPhysi";

        public const string NAME_COL_SEKKEI_EDIT = "colSekkeiEdit";
        public const string NAME_COL_SEKKEI_DELETE = "colSekkeiDelete";
        public const string NAME_COL_ADAPTER_EDIT = "colAdapterEdit";
        public const string NAME_COL_ADAPTER_DELETE = "colAdapterDelete";

        public const string NAME_COL_PARAM = "colParam";
        public const string NAME_COL_VALUE = "colValue";
        #endregion

        #region Tab Name
        public const string TAB_GET_NAME = "Get Name Column";
        public const string TAB_GET_VIEW_MODEL = "Get View Model";
        public const string TAB_GET_GET_ITEM_RESOURCE = "Get Item Resource";
        public const string TAB_CR_JSON = "Create JSON";
        public const string TAB_CR_ENTITY = "Create Entity";
        public const string TAB_CR_FILE_SRC = "Create File Source";
        public const string TAB_CR_REPORTS = "Create Report";
        public const string TAB_CR_MESS = "Create Message";
        public const string TAB_CR_COMMENT = "Create Comment";
        public const string TAB_CR_RESOURCES = "Create Resources";
        public const string TAB_FORMAT_COMMENT = "Format Coment";

        #endregion

        #region String Check
        public const string STRING_CHECK_SQL_TABLE = "].[";
        public const string STRING_CHECK_SQL_TABLE_NOT = "].";
        public const string STRING_CHECK_SQL_AS = " AS ";

        public const string STRING_CHECK_APOSTROPHE = " '";
        public const string STRING_CHECK_COMMENT = "'//";
        public const string STRING_CHECK_ADD_END = "ADD END";
        public const string STRING_CHECK_HYPHEN = "---";
        public const string STRING_CHECK_HASH = "#";
        public const string STRING_CHECK_REP_START = "REP-START";
        public const string STRING_CHECK_REP_END = "REP-END";
        public const string STRING_CHECK_APOSTROPHE_VALUE = "'' {0}";
        public const string STRING_CHECK_SPLIT = " = Split(";

        public const string STRING_CHECK_EMPTY = "\"\"";
        public const string STRING_CHECK_IF = "If";
        public const string STRING_CHECK_ELSE_IF = "ElseIf";
        public const string STRING_CHECK_THEN = "Then";
        public const string STRING_CHECK_ELSE = "Else";
        public const string STRING_CHECK_END = "End";
        public const string STRING_CHECK_END_IF = "End If";
        public const string STRING_CHECK_CASE = "Case";
        public const string STRING_CHECK_AND = "&";
        public const string STRING_CHECK_OPEN_BRACKETS = " (";
        public const string STRING_CHECK_CLOSE_BRACKETS = ") ";
        public const string STRING_CHECK_DIFFERENCE = "<>";
        public const string STRING_CHECK_SUBSTRING = ".Substring";
        public const string STRING_CHECK_AS = "AS";
        public const string STRING_CHECK_PARAM_OPEN = "\" & ";
        public const string STRING_CHECK_PARAM_CLOSE = "& \"";
        public const string STRING_CHECK_STRING_EMPTY = "'String.Empty'";

        public const string STRING_CHECK_CONTAINS_01 = "{0} = \"";
        public const string STRING_CHECK_CONTAINS_02 = "{0} = {0} & \"";
        public const string STRING_CHECK_CONTAINS_03 = "{0} &= \"";
        public const string STRING_CHECK_CONTAINS_04 = ", ";
        #endregion

        #region String Format
        public const string STRING_FORMAT_01 = "{0}=";
        public const string STRING_FORMAT_02 = "=\"";
        public const string STRING_FORMAT_03 = "'\"&";
        public const string STRING_FORMAT_04 = "&[a-zA-Z0-9\"]";
        public const string STRING_FORMAT_05 = @"\s+";
        public const string STRING_FORMAT_06 = "&";
        public const string STRING_FORMAT_07 = "'\n";
        public const string STRING_FORMAT_08 = ".";
        public const string STRING_FORMAT_09 = "='";
        public const string STRING_FORMAT_10 = "= '";
        public const string STRING_FORMAT_11 = " ({0} ";
        public const string STRING_FORMAT_12 = " {0}) ";
        public const string STRING_FORMAT_13 = "\'\" & ";
        public const string STRING_FORMAT_14 = " & \"\'";
        public const string STRING_FORMAT_15 = "\" & ";
        public const string STRING_FORMAT_16 = " & \"";
        public const string STRING_FORMAT_17 = " {0} ";
        public const string STRING_FORMAT_18 = "\'\" & \"";

        public const string STRING_REPLACE_01 = "{0} =";
        public const string STRING_REPLACE_02 = "= \"";
        public const string STRING_REPLACE_03 = "'\" & ";
        public const string STRING_REPLACE_04 = " & \"";
        public const string STRING_REPLACE_05 = " ";
        public const string STRING_REPLACE_06 = "\'";
        #endregion

        #region String Regex
        public const string REGEX_WORD_CHARACTER = "'[a-zA-Z0-9]";
        public const string REGEX_CASE_ELSE_ERROR = @"Case Else[a-zA-Z0-9\s_=]+ERROR";
        public const string REGEX_KEY_LIST_DIC = "Key_[0-9]+:\\s";
        public const string REGEX_REMOVE_LINE = @"^\s*$(\n|\r|\r\n)";
        #endregion
    }
}
