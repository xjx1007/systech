

/// <summary>
/// KNetworkcn 
/// asp.net, c#, 简繁转换
///       protected void Page_Load(object sender, EventArgs e)
///            {
///                // 1、默认为简体转繁体，编码为utf-8
///                Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
///               // 2、繁体简体转，编码为utf-8
///               // Response.Filter = new ChineseConvertor(Response.Filter, ChineseConvertor.CCDirection.T2S);
///               // 3、简体转繁体，默认编码
///               // Response.Filter = new ChineseConvertor(Response.Filter, ChineseConvertor.CCDirection.S2T, Encoding.Default);
///               // 4、静态方法
///               // Response.Write(ChineseConvertor.Convert("大家好！我是简体字，请把我转为繁体！",  ChineseConvertor.CCDirection.S2T));
///           }
/// </summary>
namespace LU.Web
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using Microsoft.VisualBasic; //先添加引用

    public class ChineseConvertor : Stream
    {
        public enum CCDirection : byte { S2T, T2S };

        private Stream _filter;
        private CCDirection _direction;
        private Encoding _encd;

        public ChineseConvertor(Stream filter)
        {
            _filter = filter;
            _direction = CCDirection.S2T;
            _encd = Encoding.GetEncoding("UTF-8");
        }

        public ChineseConvertor(Stream filter, CCDirection direction)
        {
            _filter = filter;
            _direction = direction;
            _encd = Encoding.GetEncoding("UTF-8");
        }

        public ChineseConvertor(Stream filter, Encoding encd)
        {
            _filter = filter;
            _direction = CCDirection.S2T;
            _encd = encd;
        }

        public ChineseConvertor(Stream filter, CCDirection direction, Encoding encd)
        {
            _filter = filter;
            _direction = direction;
            _encd = encd;
        }

        public static string Convert(string str, CCDirection direction)
        {
            if (direction == CCDirection.S2T)
                return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
            else
                return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            string content = _encd.GetString(buffer, offset, count);

            content = ChineseConvertor.Convert(content, this._direction);
            _filter.Write(_encd.GetBytes(content), 0, _encd.GetByteCount(content));
        }

        public override void SetLength(long value)
        {
            _filter.SetLength(value);
        }

        public override long Position
        {
            get { return _filter.Position; }
            set { }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _filter.Read(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return _filter.CanRead; }
        }

        public override bool CanWrite
        {
            get { return _filter.CanWrite; }
        }

        public override bool CanSeek
        {
            get { return _filter.CanSeek; }
        }

        public override void Flush()
        {
            _filter.Flush();
        }

        public override long Length
        {
            get { return _filter.Length; }
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            return _filter.Seek(offset, origin);
        }

    }
}
