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
    public class SingleUserNameTests
    {
        string[] testList = new string[] {
            "あいうえお",
            "あいう　えお",
            "あいう　えお",
            "あ　い　う　え　お" };

        string[] testListBlank = new string[] {
            "　  あいうえお ",
            "あいう　えお  ",
            "　あいう　えお　",
            "　 あ　い　う　え　お  " };


        [TestMethod()]
        public void 入出力テスト() {
            var xml = new XmlSerializer(typeof(SingleUserName));
            
            var ans = testList.Select(v => new SingleUserName(v)).ToList();

            var list = ans.Select(v => {
                var stream = new StringWriter();
                xml.Serialize(stream, v);
                var str = stream.ToString();
                Console.WriteLine(str);
                return str;
            }).Select(v =>
                (SingleUserName)xml.Deserialize(new StringReader(v))
            ).ToList();

            CollectionAssert.AreEqual(list, ans);
        }

        [TestMethod()]
        public void 多態性入出力テスト() {
            var xml = new XmlSerializer(typeof(UserName));

            var ans = testList.Select(v => new SingleUserName(v)).Cast<UserName>().ToList();

            var list = ans.Select(v => {
                var stream = new StringWriter();
                xml.Serialize(stream, v);
                var str = stream.ToString();
                Console.WriteLine(str);
                return str;
            }).Select(v =>
                (UserName)xml.Deserialize(new StringReader(v))
            ).ToList();

            CollectionAssert.AreEqual(list, ans);
        }

        [TestMethod()]
        public void 両端空白除去() {
            var list = testListBlank.Select(v => new SingleUserName(v)).ToList();
            var ans = testList.Select(v => new SingleUserName(v)).ToList();

            CollectionAssert.AreEqual(list, ans);
        }
    }
}