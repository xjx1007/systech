using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
/// <summary>
/// Class1 的摘要说明
/// </summary>
public class WebDownload : WebClient
{
    private int _timeout;
    /// <summary>
    /// 超时时间(毫秒)
    /// </summary>
    public int Timeout
    {
        get
        {
            return _timeout;
        }
        set
        {
            _timeout = value;
        }
    }

    public WebDownload()
    {
        this._timeout = 3000;
    }

    public WebDownload(int timeout)
    {
        this._timeout = timeout;
    }

    protected override WebRequest GetWebRequest(Uri address)
    {
        var result = base.GetWebRequest(address);
        result.Timeout = this._timeout;
        return result;
    }
}
