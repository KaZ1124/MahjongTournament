using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MahjongTournament.model.User.UserName
{
    /// <summary>
    /// 姓名で分けられた名前
    /// </summary>
    public class DoubleUserName : UserName {
        private string first = string.Empty;
        private string last = string.Empty;

        public string First
        {
            get => first ?? string.Empty;
            set => first = DeleteChar(value) ?? string.Empty;
        }

        public string Last
        {
            get => last ?? string.Empty;
            set => last = DeleteChar(value) ?? string.Empty;
        }

        [XmlIgnore]
        public override string Name {
            get {
                return First + spliter + Last;
            } set {
                first = string.Empty;
                last = string.Empty;

                var ans = SplitString(value);
                if(ans != null) {
                    ans = ans.Where(v => (v != null && v.Length > 0));

                    int count = ans.Count();
                    if(count == 1) {
                        First = ans.First();
                    } else if(count >= 2) {
                        First = ans.First();
                        Last = ans.Last();
                    }
                }
            }
        }

        public DoubleUserName() { }

        public DoubleUserName(string name) {
            Name = name;
        }

        public DoubleUserName(string first, string last) {
            First = first;
            Last = last;
        }
    }
}
