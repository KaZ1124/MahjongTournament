using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MahjongTournament.model.User.UserName {
    /// <summary>
    /// 単一の名前（入力されたまま氏名を表示する）
    /// </summary>
    public class SingleUserName : UserName {
        private string single = null;

        /// <summary>
        /// 氏名
        /// </summary>
        public string Single {
            get => single ?? string.Empty;
            set => single = DeleteCharSide(value) ?? string.Empty;
        }

        [XmlIgnore()]
        public override string Name {
            get => Single;
            set => Single = value;
        }

        public SingleUserName() { }

        public SingleUserName(string name) {
            Name = name;
        }
    }
}
