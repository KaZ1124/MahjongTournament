using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MahjongTournament.model.User.UserName
{
    [XmlInclude(typeof(SingleUserName))]
    [XmlInclude(typeof(DoubleUserName))]
    public abstract class UserName
    {
        protected const string spliter = " ";
        private static readonly IEnumerable<Char> splitChars = " /,　／\t\n\r";
        private static readonly IEnumerable<Char> deleteChars = " /,　／\t\n\r";

        /// <summary>
        /// 名前を表示
        /// </summary>
        [XmlIgnore]
        public abstract string Name { get; set; }

        /// <summary>
        /// 削除文字を両サイドから削除した文字列を返す
        /// </summary>
        /// <param name="str">整形対象文字列</param>
        /// <returns>整形された文字列</returns>
        protected static string DeleteCharSide(string str) {
            if (str == null) return null;

            return str.Trim(deleteChars.ToArray());
        }

        /// <summary>
        /// 削除文字を削除した文字列を返す
        /// </summary>
        /// <param name="str">整形対象文字列</param>
        /// <returns>整形された文字列</returns>
        protected static string DeleteChar(string str) {
            if (str == null) return null;

            return str
                .Where(v => !splitChars.Contains(v))
                .Aggregate("", (v, a) => v + a);
        }

        /// <summary>
        /// 区切り文字で文字列を区切って列挙する
        /// </summary>
        /// <param name="str">対象文字列</param>
        /// <returns>区切り文字で区切られた文字列のIEnumerable</returns>
        protected static IEnumerable<string> SplitString(string str) {
            if (str == null) return null;

            return str.Split(splitChars.ToArray());
        }

        public override string ToString() {
            return Name;
        }

        public override bool Equals(object obj) {
            if (obj is UserName o)
                return o.Name == Name;
            else
                throw new ArgumentException();
        }
    }
}
