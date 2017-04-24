/*!
** Unobtrusive Ajax support library for jQuery
** Copyright (C) Microsoft Corporation. All rights reserved.
*/

/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, newcap: true, immed: true, strict: false */
/*global window: false, jQuery: false */

(function ($) {
    $.extend($, {
        procAjaxData: function (data,funcSuc,funcErr) {
            if (!data.Statu) {
                return;
            }

            switch (data.Statu)
            {
                case "ok":
                    alert("OK:" + data.Msg);
                    if (funcSuc) funcSuc(data);
                    break;
                case "err":
                    alert("ERR:" + data.Msg);
                    if (funcErr) funcErr(data);
                    break;
                case "nologin":
                    alert(data.Msg);
                    window.location = data.BackUrl;
                    break;
            }
        }
    });
}(jQuery));