using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ToolCommon.Models;

namespace ToolCommon.Service
{
    public class CreateFileService
    {

        private AppSettingModel _appSetting;

        private string screeenSampleVal = "";

        private string screeenNewVal = "";

        public string resultData = "";

        public string message = "";

        List<string> newPathFile;

        public CreateFileService(AppSettingModel appSettingModel)
        {
            _appSetting = appSettingModel;
            newPathFile = new List<string>();
        }

        public void Generate(string oldVal, string newVal)
        {
            newPathFile = new List<string>();
            this.screeenSampleVal = oldVal;
            this.screeenNewVal = newVal;
            this.resultData = "";
            this.message = "";

            if (screeenSampleVal == "" || screeenNewVal == "")
            {
                throw new Exception("Screen ID is empty");
            }
            else if (screeenSampleVal.ToLower().Equals(screeenNewVal.ToLower()))
            {
                throw new Exception("The ID of the two screens are the same");
            }
            List<string> fileSampleList = this.getFileSampleList();
            if (fileSampleList.Count == 0)
            {
                throw new Exception("File not found");
            }
            this.resultData = this.generateNewFileList(fileSampleList);
            this.message = "Source code is clone successfully";
        }

        private List<string> getFileSampleList()
        {
            List<string> fileArray = Directory.GetFiles(_appSetting.sourcePath, $"*{this.screeenSampleVal}*", SearchOption.AllDirectories).ToList();
            if (_appSetting.generateSource.ignoreFile.Length != 0)
            {
                foreach (string ign in _appSetting.generateSource.ignoreFile)
                {
                    fileArray = fileArray.Where(t => !t.Contains(ign)).ToList();
                }
            }
            return fileArray;
        }

        private string generateNewFileList(List<string> fileSampleList)
        {
            string rtn = "Files created: \r\n";
            foreach (string file in fileSampleList)
            {
                string newPathFile = this.createNewPathFile(file);
                System.IO.File.Copy(file, newPathFile, true);
                this.newPathFile.Add(newPathFile);
                rtn += newPathFile + "\r\n";
            }
            return rtn;
        }

        private string createNewPathFile(string file)
        {
            string[] fileArrOld = file.Split('\\');
            string[] fileArrNew = file.Split('\\');
            Array.Reverse(fileArrOld);
            Array.Reverse(fileArrNew);
            fileArrNew[0] = this.createFileName(fileArrOld[0]);
            for (int i = 1; i < fileArrOld.Length; i++)
            {
                if (this.screeenSampleVal.ToLower().Contains(fileArrOld[i].ToLower()))
                {
                    fileArrNew[i] = this.createPathFileString(fileArrOld[i]);
                }
            }
            Array.Reverse(fileArrNew);
            string rtn = string.Join("\\", fileArrNew);
            string newPath = rtn.Substring(0, rtn.LastIndexOf('\\'));
            this.createFolder(newPath);
            return rtn;
        }

        private string createFileName(string name)
        {
            int index = name.ToLower().IndexOf(this.screeenSampleVal.ToLower());
            string check = name.Substring(index, this.screeenSampleVal.Length);
            char[] oldName = check.ToCharArray();
            char[] newName = this.screeenNewVal.ToCharArray();

            if (newName.Length == oldName.Length)
            {
                for (int i = 0; i < oldName.Length; i++)
                {
                    if (Char.IsUpper(oldName[i]))
                    {
                        newName[i] = Char.ToUpper(newName[i]);
                    }
                    else
                    {
                        newName[i] = Char.ToLower(newName[i]);
                    }
                }
            } else {
                if (Char.IsUpper(oldName[0]) && Char.IsUpper(oldName[1]))
                {
                    newName = newName.Select(c => Char.ToUpper(c)).ToArray();
                } else if (Char.IsLower(oldName[0]) && Char.IsLower(oldName[1]))
                {
                    newName = newName.Select(c => Char.ToLower(c)).ToArray();
                } else {
                    newName = newName.Select(c => Char.ToLower(c)).ToArray();
                    newName[0] = Char.ToUpper(newName[0]);
                }
            }

            return name.Replace(check, new string(newName));
        }

        private string createPathFileString(string name)
        {
            char[] newName = null;
            if (this.screeenNewVal.Length == this.screeenSampleVal.Length)
            {
                int index = this.screeenSampleVal.ToLower().IndexOf(name.ToLower());
                char[] oldName = name.ToCharArray();
                newName = this.screeenNewVal.Substring(index, name.Length).ToCharArray();

                for (int i = 0; i < oldName.Length; i++)
                {
                    if (Char.IsUpper(oldName[i]))
                    {
                        newName[i] = Char.ToUpper(newName[i]);
                    }
                    else
                    {
                        newName[i] = Char.ToLower(newName[i]);
                    }
                }
            }
            else
            {
                char[] oldName = name.ToCharArray();
                if (name.ToLower().EndsWith(this.screeenSampleVal))
                {
                    newName = this.screeenNewVal.ToCharArray();
                } else
                {
                    string findDelimiter = this.screeenSampleVal.ToLower().Substring(name.Length, 2);
                    int index = this.screeenNewVal.ToLower().IndexOf(findDelimiter);
                    newName = this.screeenNewVal.Substring(0, index).ToCharArray();
                }

                if (Char.IsUpper(oldName[0]) && Char.IsUpper(oldName[1]))
                {
                    newName = newName.Select(c => Char.ToUpper(c)).ToArray();
                }
                else if (Char.IsLower(oldName[0]) && Char.IsLower(oldName[1]))
                {
                    newName = newName.Select(c => Char.ToLower(c)).ToArray();
                }
                else
                {
                    newName = newName.Select(c => Char.ToLower(c)).ToArray();
                    newName[0] = Char.ToUpper(newName[0]);
                }
            }
            return new string(newName);
        }

        private void createFolder(string folder)
        {
            Directory.CreateDirectory(folder);
        }

        public void editFileWithFunctionAndProcess()
        {
            string ptn = this.createRegexPattern();
            string pattern = @ptn;
            Regex rg = new Regex(pattern);
            foreach (string file in this.newPathFile)
            {
                string[] text = File.ReadAllLines(file, System.Text.Encoding.UTF8);
                for(int i=0; i<text.Length; i++)
                {
                    text[i] = rg.Replace(text[i], m => this.createNewStringByRegex(m.Value));
                }
                File.WriteAllLines(file, text, System.Text.Encoding.UTF8);
            }
        }

        private string createRegexPattern()
        {
            string rtn = "";
            char[] cArr = this.screeenSampleVal.ToCharArray();
            foreach(char c in cArr)
            {
                if (Char.IsNumber(c)) {
                    rtn += c.ToString();
                } else
                {
                    rtn += "[" + c.ToString().ToUpper() + "|" + c.ToString().ToLower() + "]";
                }
            }
            return rtn;
        }

        private string createNewStringByRegex(string name)
        {
            char[] oldName = name.ToCharArray();
            char[] newName = this.screeenNewVal.ToCharArray();
            if (newName.Length == oldName.Length)
            {
                for (int i = 0; i < oldName.Length; i++)
                {
                    if (Char.IsUpper(oldName[i]))
                    {
                        newName[i] = Char.ToUpper(newName[i]);
                    }
                    else
                    {
                        newName[i] = Char.ToLower(newName[i]);
                    }
                }
            }
            else
            {
                if (Char.IsUpper(oldName[0]) && Char.IsUpper(oldName[1]))
                {
                    newName = newName.Select(c => Char.ToUpper(c)).ToArray();
                }
                else if (Char.IsLower(oldName[0]) && Char.IsLower(oldName[1]))
                {
                    newName = newName.Select(c => Char.ToLower(c)).ToArray();
                }
                else
                {
                    newName = newName.Select(c => Char.ToLower(c)).ToArray();
                    newName[0] = Char.ToUpper(newName[0]);
                }
            }
            return String.Join("", newName);
        }

        public void editFileWithoutFunction()
        {
            foreach(string file in this.newPathFile)
            {
                foreach(EditSource e in _appSetting.editSource)
                {
                    if (file.Contains(e.fileType))
                    {
                        if (!(e.functionPattern == ""))
                        {
                            string text = File.ReadAllText(file, System.Text.Encoding.UTF8);
                            string pattern = @e.functionPattern;
                            Regex rg = new Regex(pattern);
                            string result = rg.Replace(text, "");
                            File.WriteAllText(file, result, System.Text.Encoding.UTF8);
                        }
                        else if (!(e.functionKeyword == ""))
                        {
                            string[] text = File.ReadAllLines(file, System.Text.Encoding.UTF8);
                            string functionKeyword = e.functionKeyword;
                            List<string> lineRemove = new List<string>();
                            int lineStart = -1;
                            int space = -1;
                            for (int i=0; i<text.Length; i++)
                            {
                                if (text[i].Contains(functionKeyword))
                                {
                                    lineStart = i;
                                    char[] c = text[i].ToCharArray();
                                    for (int j = 0; j< c.Length; j++)
                                    {
                                        if (!c[j].Equals(' '))
                                        {
                                            space = j;
                                            break;
                                        }
                                    }
                                }
                                if(lineStart != -1)
                                {
                                    char[] c = text[i].ToCharArray();
                                    for (int j = 0; j < c.Length; j++)
                                    {
                                        if (!(c[j].Equals(' ')) && (space == j))
                                        {
                                            break;
                                        } else if (j > space)
                                        {
                                            lineRemove.Add(text[i]);
                                            break;
                                        }
                                    }
                                }
                            }
                            var newText = text.ToList();
                            foreach(string line in lineRemove)
                            {
                                newText = newText.Where(x => x != line).ToList();
                            }
                            text = newText.ToArray();
                            File.WriteAllLines(file, text, System.Text.Encoding.UTF8);
                        }
                        this.removeSpaceLine(file);
                    }
                }
            }
        }

        public void removeSpaceLine(string file)
        {
            List<string> text = File.ReadAllLines(file, System.Text.Encoding.UTF8).ToList();
            for(int i=0; i < text.Count - 1; i++)
            {
                if (text[i] == "" && text[i+1] == "")
                {
                    text.RemoveAt(i + 1);
                    i--;
                }
            }
            File.WriteAllLines(file, text, System.Text.Encoding.UTF8);
        }

        public string deleteFileCreated()
        {
            string rtn = "Files deleted: \r\n";
            foreach (string file in this.newPathFile)
            {
                File.Delete(file);
                rtn += file + "\r\n";
            }
            this.message = "Files is deleted";
            return rtn;
        }
    }
}
