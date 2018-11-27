using Microsoft.VisualStudio.TestTools.UnitTesting;
using MahjongTournament.model.User.UserName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace MahjongTournament.model.User.UserName.Tests
{
    [TestClass()]
    public class DoubleUserNameTests
    {
        string[] firstList = new string[] { "あいう", "あいう  　", "  　あいう", "　あいう　  ", " 　あ　い　う　  " };
        string[] lastList = new string[] { "えお", "　えお", "えお　", "　えお　", "　え　お　" };
        string[] nameList = new string[] { "あいう　えお", "　 あいう えお", "あいう   　えお　", "　あいう　えお　", "　  あいう　　かきく　   えお" };
        DoubleUserName answer = new DoubleUserName("あいう", "えお");

        [TestMethod()]
        public void 姓名入力テスト() {
            var list = firstList.Zip(lastList, (f, l) => new DoubleUserName(f, l));

            Assert.IsTrue(list.All(v => v.Equals(answer)));
        }

        [TestMethod()]
        public void Name入力テスト() {
            var list = nameList.Select(v => new DoubleUserName(v));

            Assert.IsTrue(list.All(v => v.Equals(answer)));
        }

        [TestMethod()]
        public void 入出力テスト() {
            var ans = nameList.Select(v => new DoubleUserName(v)).ToList();

            var xml = new XmlSerializer(typeof(DoubleUserName));
            var list = ans.Select(v => {
                var stream = new StringWriter();

                xml.Serialize(stream, v);

                var str = stream.ToString();
                Console.WriteLine(str);
                return str;
            }).Select(v => xml.Deserialize(new StringReader(v))).ToList();

            CollectionAssert.AreEqual(list, ans);
        }

        [TestMethod()]
        public void 多態性入出力テスト() {
            var ans = nameList.Select(v => new DoubleUserName(v)).ToList();

            var xml = new XmlSerializer(typeof(UserName));
            var list = ans.Select(v => {
                var stream = new StringWriter();

                xml.Serialize(stream, v);

                var str = stream.ToString();
                Console.WriteLine(str);
                return str;
            }).Select(v => xml.Deserialize(new StringReader(v))).ToList();

            CollectionAssert.AreEqual(list, ans);
        }
    }
}