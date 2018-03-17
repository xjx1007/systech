<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Demo</title>

    <link rel="stylesheet" href="../css/reset-min.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="../css/ihwy-2012.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="../cssjquery.listnav-2.1.css" type="text/css" media="screen" charset="utf-8" />
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/jquery.cookie.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/jquery.idTabs.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/jquery.listnav-2.1.js" charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            if (top.location.href.toLowerCase() == self.location.href.toLowerCase()) $('#docLink').show();
            $("#tabNav ul").idTabs("tab1");
        });
    </script>

</head>
<body>
    <form>

        <div class="demoWrapper">

            <div id="tabNav">
                <ul>
                    <li><a href="#tab1">Demo 1</a></li>
                    <li><a href="#tab2">Demo 2</a></li>
                </ul>
                <div class="clr"></div>
            </div>

            <div id="tabs">
                <div id="tab1" class="tab">
                    1
                </div>


                <div id="tab2" class="tab">
                    2
                </div>
            </div>

        </div>

    </form>
</body>
</html>

