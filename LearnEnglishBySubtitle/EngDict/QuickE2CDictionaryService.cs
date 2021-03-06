﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Studyzy.LearnEnglishBySubtitle.Helpers;

namespace Studyzy.LearnEnglishBySubtitle.EngDict
{
    public class QuickE2CDictionaryService : DictionaryService
    {
        public override string DictionaryName
        {
            get { return "英汉速查词典"; }
        }

        public override string Ld2FilePath
        {
            get { return "Quick E-C Dictionary.ld2"; }
        }
        public override Encoding MeanEncoding
        {
            get { return Encoding.Unicode; }
        }
        public override IList<WordMean> GetCoreMeans(string xml)
        {
            var result = new List<WordMean>();
           

            foreach (Match match in regex.Matches(xml))
            {
                var val = match.Groups[1].Value;
                var property = "";
                if (propertyRegex.IsMatch(val))
                {
                    property = propertyRegex.Match(val).Groups[1].Value;
                }
                result.Add(new WordMean(){Mean = detailRegex.Replace(val, ""),Property = property});
            }
            return result;
        }
        private static Regex detailRegex = new Regex("<.*?/.*?>");
        private static Regex propertyRegex = new Regex("<U>(.*?)</U>");
        private static Regex regex = new Regex("<N>(.*?)</N>");
    }
}
