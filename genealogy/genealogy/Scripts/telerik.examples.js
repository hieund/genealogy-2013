﻿$(function () {
    var $t = $.telerik;
    var fx = $t.fx.slide.defaults();
    var themeRegex = /[\?&]theme=([^&#]*)/;
    var availableSkins = 'Black,Default,Forest,Hay,Metro,Office2007,Office2010Black,Office2010Blue,Office2010Silver,Outlook,Simple,Sitefinity,Sunset,Telerik,Transparent,Vista,Web20,WebBlue,Windows7'.split(',');

    function onThemeChange(e) {
        if ($(e.target).is('.simple-link'))
            return;

        e.preventDefault();

        var theme = this.className.replace('theme-preview-', '');

        var url = window.location.href;
        var newUrl = new $t.stringBuilder();

        if (url.indexOf('theme=') > 0) {
            var matches = themeRegex.exec(url);
            var oldThemeIndex = url.indexOf('theme=') + 6;

            newUrl
                .cat(url.substring(0, oldThemeIndex))
                .cat(theme)
                .cat(url.substring(oldThemeIndex + matches[1].length));
        } else {
            // won't work with hashes in url
            newUrl
                .cat(url)
                .cat((url.indexOf('?') > 0) ? '&' : '?')
                .cat('theme=')
                .cat(theme);
        }

        window.location.href = newUrl.string();
    }

    function getThemeGalleryHtml() {
        var themeGalleryHtml = new $t.stringBuilder();

        themeGalleryHtml.cat('<div id="theme-gallery"><h2>Choose Skin</h2><ul>');

        var url = window.location.href;
        var currentTheme = themeRegex.test(url) ? themeRegex.exec(url)[1] : 'vista';

        $.each(availableSkins, function () {
            themeGalleryHtml
                .cat('<li')
                .cat((this.toLowerCase() == currentTheme) ? ' class="selected"' : '')
                .cat('><a href="#" class="theme-preview-')
                .cat(this.toLowerCase())
                .cat('"><img src="')
                .cat(themePreviewsLocation).cat('/').cat(currentComponent).cat('/')
                .cat(this)
                .cat('.png" alt="" width="90" height="90" />')
                .cat('<span>')
                .cat(this)
                .cat('</span>')
                .cat('</a></li>');
        });
        
        themeGalleryHtml.cat('</ul>')
            .catIf('<h2>Want more?</h2><a class="simple-link" href="http://stylebuilder.telerik.com/New.aspx?Suite=aspnet-mvc">&raquo; Create your own with the Visual Style Builder</a>', currentComponent.toLowerCase() != "chart")
            .cat('</div>');

        return themeGalleryHtml.string();
    }

    var themeGalleryOpened = false;

    $('#theming .t-drop-down')
        .click(function (e) {
            e.preventDefault();

            if (!themeGalleryOpened)
                e.stopPropagation();

            var $themeGallery = $('#theme-gallery');

            if ($themeGallery.length == 0) {
                $themeGallery = $(getThemeGalleryHtml()).appendTo(this.parentNode)

                $themeGallery.find('a').click(onThemeChange);

                $(document).click(function (e, element) {
                    if (e.which == 3)
                        return;

                    if ($(e.target).parents('#theme-gallery').length > 0)
                        return;

                    $('#theming .t-drop-down').removeClass('state-active');
                    $t.fx.rewind(fx, $themeGallery, { direction: 'bottom' });
                    themeGalleryOpened = false;
                });
            }

            $(this).addClass('state-active');
            $t.fx.play(fx, $themeGallery, { direction: 'bottom' });
            themeGalleryOpened = true;
        });

    var searchBox = $('#examples-search'),
        searchBoxHovered = false,
        searchBoxFocused = false;

    searchBox
        .bind('mouseenter', function() {
            searchBoxHovered = true;
            searchBox.addClass("t-search-box-hover");
        })
        .bind('mouseleave', function() {
            searchBoxHovered = false;

            if (!searchBoxHovered && !searchBoxFocused)
                searchBox.removeClass("t-search-box-hover");
        })
        .find('.t-input')
            .focus(function () {
                searchBoxFocused = true;
                searchBox.find('label').hide();
            })
            .blur(function () {
                searchBoxFocused = false;

                if (!searchBoxHovered && !searchBoxFocused)
                    searchBox.removeClass("t-search-box-hover");

                if (this.value == '')
                    searchBox.find('label').show();
            })
        .end()
        .find('label')
            .ready(function() {
                searchBox.find('label').text('Search examples');
            })
            .mousedown(function () {
                searchBox.find('.t-input').focus();
            });
            
    window.searchBoxLoad = function(e) {
        $(this).bind('valueChange', function(e) {
                if (e.value.split('/').length == 2)
                    window.location.href = examplesBaseUrl + e.value;
            });
    };

    $('#navigation-product-examples')
        .bind('collapse', function (e) {
            if (e.item.parentNode.id == "navigation-product-examples")
                e.preventDefault();
        });

    /* exports */

    window.productMenuLoad = function (e) {
        $(this)
            .die('mouseenter').die('mouseleave').die('click');
        $('.t-link', this)
            .live('mouseenter', $t.hover).live('mouseleave', $t.leave);
        $('#all-products > .t-link')
            .live('click', function (e) {
                var $target = $(e.target);

                e.preventDefault();

                var closeProductMenu = function (e) {
                    if (e && $(e.target).parents('#all-products').length > 0)
                        return;

                    $target.removeClass('t-state-active');
                    $t.fx.rewind(fx, $target.parent().find('.t-group'), { direction: 'bottom' });
                    $(document).unbind('click', closeProductMenu);
                };

                if ($target.hasClass('t-state-active'))
                    closeProductMenu();
                else {
                    $target.addClass('t-state-active');
                    $t.fx.play(fx, $target.parent().find('.t-group'), { direction: 'bottom' });
                    $(document).bind('click', closeProductMenu);
                }
            });
    }

    window.codeTabLoad = function () {
        var tabStrip = $('#code-viewer-tabs')
                            .bind('select', function (e) { $('.prettyprint').removeClass('prettyprint').addClass('prettified'); })
                        .data('tTabStrip');
        var ajaxRequest = tabStrip.ajaxRequest;
        tabStrip.ajaxRequest = function ($item, contentElement, complete) {
            ajaxRequest($item, contentElement, $.proxy(function () {
                contentElement.find('pre:not(.prettified)').addClass('prettyprint');

                prettyPrint();

                if (complete)
                    complete.call(this, contentElement);
            }, this));
        };
    }
});

/*
 * jQuery Color Animations
 * Copyright 2007 John Resig
 * Released under the MIT and GPL licenses.
 */

(function(jQuery) {

    // We override the animation for all of these color styles
    jQuery.each(['backgroundColor', 'borderBottomColor', 'borderLeftColor', 'borderRightColor', 'borderTopColor', 'color', 'outlineColor'], function(i, attr) {
        jQuery.fx.step[attr] = function(fx) {
            if (fx.state == 0 || typeof fx.end == typeof "") {
                fx.start = getColor(fx.elem, attr);
                fx.end = getRGB(fx.end);
            }

            fx.elem.style[attr] = ["rgb(", [
                Math.max(Math.min(parseInt((fx.pos * (fx.end[0] - fx.start[0])) + fx.start[0]), 255), 0),
                Math.max(Math.min(parseInt((fx.pos * (fx.end[1] - fx.start[1])) + fx.start[1]), 255), 0),
                Math.max(Math.min(parseInt((fx.pos * (fx.end[2] - fx.start[2])) + fx.start[2]), 255), 0)
            ].join(","), ")"].join('');
        }
    });

    // Color Conversion functions from highlightFade
    // By Blair Mitchelmore
    // http://jquery.offput.ca/highlightFade/

    // Parse strings looking for color tuples [255,255,255]
    function getRGB(color) {
        var result;

        // Check if we're already dealing with an array of colors
        if (color && color.constructor == Array && color.length == 3)
            return color;

        // Look for rgb(num,num,num)
        if (result = /rgb\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*\)/.exec(color))
            return [parseInt(result[1]), parseInt(result[2]), parseInt(result[3])];

        // Look for #a0b1c2
        if (result = /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/.exec(color))
            return [parseInt(result[1], 16), parseInt(result[2], 16), parseInt(result[3], 16)];

        // Otherwise, we're most likely dealing with a named color
        return colors[jQuery.trim(color).toLowerCase()];
    }

    function getColor(elem, attr) {
        var color;

        do {
            color = jQuery.curCSS(elem, attr);

            // Keep going until we find an element that has color, or we hit the body
            if (color != '' && color != 'transparent' || jQuery.nodeName(elem, "body"))
                break;

            attr = "backgroundColor";
        } while (elem = elem.parentNode);

        return getRGB(color);
    };

    var href = window.location.href;
    if (href.indexOf('culture') > -1) {
        $('#culture').val(href.replace(/(.*)culture=([^&]*)/, '$2'));
    }

    $('#culture').change(onlocalizationchange);

    function onlocalizationchange() {
        var value = $(this).val();
        var href = window.location.href;
        if (href.indexOf('culture') > -1) {
            href = href.replace(/culture=([^&]*)/, 'culture=' + value);
        } else {
            href += href.indexOf('?') > -1 ? '&culture=' + value : '?culture=' + value;
        }
        window.location.href = href;
    }
})(jQuery);

// google code prettify (http://code.google.com/p/google-code-prettify/)
(function(){
var o=true,r=null,z=false;window.PR_SHOULD_USE_CONTINUATION=o;window.PR_TAB_WIDTH=8;window.PR_normalizedHtml=window.PR=window.prettyPrintOne=window.prettyPrint=void 0;window._pr_isIE6=function(){var N=navigator&&navigator.userAgent&&/\bMSIE 6\./.test(navigator.userAgent);window._pr_isIE6=function(){return N};return N};
var aa="!",ba="!=",ca="!==",F="#",da="%",ea="%=",G="&",fa="&&",ja="&&=",ka="&=",H="(",la="*",ma="*=",na="+=",oa=",",pa="-=",qa="->",ra="/",sa="/=",ta=":",ua="::",va=";",I="<",wa="<<",xa="<<=",ya="<=",za="=",Aa="==",Ba="===",J=">",Ca=">=",Da=">>",Ea=">>=",Fa=">>>",Ga=">>>=",Ha="?",Ia="@",L="[",M="^",Ta="^=",Ua="^^",Va="^^=",Wa="{",O="|",Xa="|=",Ya="||",Za="||=",$a="~",ab="break",bb="case",cb="continue",db="delete",eb="do",fb="else",gb="finally",hb="instanceof",ib="return",jb="throw",kb="try",lb="typeof",
mb="(?:^^|[+-]",nb="\\$1",ob=")\\s*",pb="&amp;",qb="&lt;",rb="&gt;",sb="&quot;",tb="&#",ub="x",vb="'",wb='"',xb=" ",yb="XMP",zb="</",Ab='="',P="",Q="\\",Bb="b",Cb="t",Db="n",Eb="v",Fb="f",Gb="r",Hb="u",Ib="0",Jb="1",Kb="2",Lb="3",Mb="4",Nb="5",Ob="6",Pb="7",Qb="\\x0",Rb="\\x",Sb="-",Tb="]",Ub="\\\\u[0-9A-Fa-f]{4}|\\\\x[0-9A-Fa-f]{2}|\\\\[0-3][0-7]{0,2}|\\\\[0-7]{1,2}|\\\\[\\s\\S]|-|[^-\\\\]",R="g",Vb="\\B",Wb="\\b",Xb="\\D",Yb="\\d",Zb="\\S",$b="\\s",ac="\\W",bc="\\w",cc="(?:\\[(?:[^\\x5C\\x5D]|\\\\[\\s\\S])*\\]|\\\\u[A-Fa-f0-9]{4}|\\\\x[A-Fa-f0-9]{2}|\\\\[0-9]+|\\\\[^ux0-9]|\\(\\?[:!=]|[\\(\\)\\^]|[^\\x5B\\x5C\\(\\)\\^]+)",
dc="(?:",ec=")",fc="gi",gc="PRE",hc='<!DOCTYPE foo PUBLIC "foo bar">\n<foo />',ic="\t",jc="\n",kc="[^<]+|<!--[\\s\\S]*?--\>|<!\\[CDATA\\[[\\s\\S]*?\\]\\]>|</?[a-zA-Z][^>]*>|<",lc="nocode",mc=' $1="$2$3$4"',S="pln",nc="string",T="lang-",oc="src",U="str",pc="'\"",qc="'\"`",rc="\"'",V="com",sc="lang-regex",tc="(/(?=[^/*])(?:[^/\\x5B\\x5C]|\\x5C[\\s\\S]|\\x5B(?:[^\\x5C\\x5D]|\\x5C[\\s\\S])*(?:\\x5D|$))+/)",uc="kwd",vc="^(?:",wc=")\\b",xc=" \r\n\t\u00a0",yc="lit",zc="typ",Ac="0123456789",Y="pun",Bc="break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try alignof align_union asm axiom bool concept concept_map const_cast constexpr decltype dynamic_cast explicit export friend inline late_check mutable namespace nullptr reinterpret_cast static_assert static_cast template typeid typename typeof using virtual wchar_t where break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try boolean byte extends final finally implements import instanceof null native package strictfp super synchronized throws transient as base by checked decimal delegate descending event fixed foreach from group implicit in interface internal into is lock object out override orderby params partial readonly ref sbyte sealed stackalloc string select uint ulong unchecked unsafe ushort var break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try debugger eval export function get null set undefined var with Infinity NaN caller delete die do dump elsif eval exit foreach for goto if import last local my next no our print package redo require sub undef unless until use wantarray while BEGIN END break continue do else for if return while and as assert class def del elif except exec finally from global import in is lambda nonlocal not or pass print raise try with yield False True None break continue do else for if return while alias and begin case class def defined elsif end ensure false in module next nil not or redo rescue retry self super then true undef unless until when yield BEGIN END break continue do else for if return while case done elif esac eval fi function in local set then until ",
Cc="</span>",Dc='<span class="',Ec='">',Fc="$1&nbsp;",Gc="&nbsp;<br />",Hc="<br />",Ic="console",Jc="cannot override language handler %s",Kc="default-markup",Lc="default-code",Mc="dec",Z="lang-js",$="lang-css",Nc="lang-in.tag",Oc="htm",Pc="html",Qc="mxml",Rc="xhtml",Sc="xml",Tc="xsl",Uc=" \t\r\n",Vc="atv",Wc="tag",Xc="atn",Yc="lang-uq.val",Zc="in.tag",$c="uq.val",ad="break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try alignof align_union asm axiom bool concept concept_map const_cast constexpr decltype dynamic_cast explicit export friend inline late_check mutable namespace nullptr reinterpret_cast static_assert static_cast template typeid typename typeof using virtual wchar_t where ",
bd="c",cd="cc",dd="cpp",ed="cxx",fd="cyc",gd="m",hd="null true false",id="json",jd="break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try boolean byte extends final finally implements import instanceof null native package strictfp super synchronized throws transient as base by checked decimal delegate descending event fixed foreach from group implicit in interface internal into is lock object out override orderby params partial readonly ref sbyte sealed stackalloc string select uint ulong unchecked unsafe ushort var ",
kd="cs",ld="break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try boolean byte extends final finally implements import instanceof null native package strictfp super synchronized throws transient ",md="java",nd="break continue do else for if return while case done elif esac eval fi function in local set then until ",
od="bsh",pd="csh",qd="sh",rd="break continue do else for if return while and as assert class def del elif except exec finally from global import in is lambda nonlocal not or pass print raise try with yield False True None ",sd="cv",td="py",ud="caller delete die do dump elsif eval exit foreach for goto if import last local my next no our print package redo require sub undef unless until use wantarray while BEGIN END ",vd="perl",wd="pl",xd="pm",yd="break continue do else for if return while alias and begin case class def defined elsif end ensure false in module next nil not or redo rescue retry self super then true undef unless until when yield BEGIN END ",
zd="rb",Ad="break continue do else for if return while auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile catch class delete false import new operator private protected public this throw true try debugger eval export function get null set undefined var with Infinity NaN ",Bd="js",Cd="regex",Dd="pre",Ed="code",Fd="xmp",Gd="prettyprint",Hd="class",Id="br",Jd="\r";
(function(){var N=function(){for(var a=[aa,ba,ca,F,da,ea,G,fa,ja,ka,H,la,ma,na,oa,pa,qa,ra,sa,ta,ua,va,I,wa,xa,ya,za,Aa,Ba,J,Ca,Da,Ea,Fa,Ga,Ha,Ia,L,M,Ta,Ua,Va,Wa,O,Xa,Ya,Za,$a,ab,bb,cb,db,eb,fb,gb,hb,ib,jb,kb,lb],b=mb,c=0;c<a.length;++c)b+=O+a[c].replace(/([^=<>:&a-z])/g,nb);b+=ob;return b}(),Ja=/&/g,Ka=/</g,La=/>/g,Kd=/\"/g;function Ld(a){return a.replace(Ja,pb).replace(Ka,qb).replace(La,rb).replace(Kd,sb)}function ga(a){return a.replace(Ja,pb).replace(Ka,qb).replace(La,rb)}var Md=/&lt;/g,Nd=/&gt;/g,
Od=/&apos;/g,Pd=/&quot;/g,Qd=/&amp;/g,Rd=/&nbsp;/g;function Sd(a){var b=a.indexOf(G);if(b<0)return a;for(--b;(b=a.indexOf(tb,b+1))>=0;){var c=a.indexOf(va,b);if(c>=0){var d=a.substring(b+3,c),g=10;if(d&&d.charAt(0)===ub){d=d.substring(1);g=16}var i=parseInt(d,g);isNaN(i)||(a=a.substring(0,b)+String.fromCharCode(i)+a.substring(c+1))}}return a.replace(Md,I).replace(Nd,J).replace(Od,vb).replace(Pd,wb).replace(Qd,G).replace(Rd,xb)}function Ma(a){return yb===a.tagName}function W(a,b){switch(a.nodeType){case 1:var c=
a.tagName.toLowerCase();b.push(I,c);for(var d=0;d<a.attributes.length;++d){var g=a.attributes[d];if(g.specified){b.push(xb);W(g,b)}}b.push(J);for(var i=a.firstChild;i;i=i.nextSibling)W(i,b);if(a.firstChild||!/^(?:br|link|img)$/.test(c))b.push(zb,c,J);break;case 2:b.push(a.name.toLowerCase(),Ab,Ld(a.value),wb);break;case 3:case 4:b.push(ga(a.nodeValue));break}}function Na(a){for(var b=0,c=z,d=z,g=0,i=a.length;g<i;++g){var m=a[g];if(m.ignoreCase)d=o;else if(/[a-z]/i.test(m.source.replace(/\\u[0-9a-f]{4}|\\x[0-9a-f]{2}|\\[^ux]/gi,
P))){c=o;d=z;break}}function l(j){if(j.charAt(0)!==Q)return j.charCodeAt(0);switch(j.charAt(1)){case Bb:return 8;case Cb:return 9;case Db:return 10;case Eb:return 11;case Fb:return 12;case Gb:return 13;case Hb:case ub:return parseInt(j.substring(2),16)||j.charCodeAt(1);case Ib:case Jb:case Kb:case Lb:case Mb:case Nb:case Ob:case Pb:return parseInt(j.substring(1),8);default:return j.charCodeAt(1)}}function n(j){if(j<32)return(j<16?Qb:Rb)+j.toString(16);var f=String.fromCharCode(j);if(f===Q||f===Sb||
f===L||f===Tb)f=Q+f;return f}function q(j){for(var f=j.substring(1,j.length-1).match(new RegExp(Ub,R)),s=[],k=[],h=f[0]===M,e=h?1:0,p=f.length;e<p;++e){var t=f[e];switch(t){case Vb:case Wb:case Xb:case Yb:case Zb:case $b:case ac:case bc:s.push(t);continue}var u=l(t),x;if(e+2<p&&Sb===f[e+1]){x=l(f[e+2]);e+=2}else x=u;k.push([u,x]);if(!(x<65||u>122)){x<65||u>90||k.push([Math.max(65,u)|32,Math.min(x,90)|32]);x<97||u>122||k.push([Math.max(97,u)&-33,Math.min(x,122)&-33])}}k.sort(function(Oa,Pa){return Oa[0]-
Pa[0]||Pa[1]-Oa[1]});var B=[],E=[NaN,NaN];for(e=0;e<k.length;++e){var A=k[e];if(A[0]<=E[1]+1)E[1]=Math.max(E[1],A[1]);else B.push(E=A)}var D=[L];h&&D.push(M);D.push.apply(D,s);for(e=0;e<B.length;++e){A=B[e];D.push(n(A[0]));if(A[1]>A[0]){A[1]+1>A[0]&&D.push(Sb);D.push(n(A[1]))}}D.push(Tb);return D.join(P)}function v(j){var f=j.source.match(new RegExp(cc,R)),s=f.length,k=[],h,e=0;for(h=0;e<s;++e){var p=f[e];if(p===H)++h;else if(Q===p.charAt(0)){var t=+p.substring(1);if(t&&t<=h)k[t]=-1}}for(e=1;e<k.length;++e)if(-1===
k[e])k[e]=++b;for(h=e=0;e<s;++e){p=f[e];if(p===H){++h;if(k[h]===undefined)f[e]=dc}else if(Q===p.charAt(0))if((t=+p.substring(1))&&t<=h)f[e]=Q+k[h]}for(h=e=0;e<s;++e)if(M===f[e]&&M!==f[e+1])f[e]=P;if(j.ignoreCase&&c)for(e=0;e<s;++e){p=f[e];var u=p.charAt(0);if(p.length>=2&&u===L)f[e]=q(p);else if(u!==Q)f[e]=p.replace(/[a-zA-Z]/g,function(x){var B=x.charCodeAt(0);return L+String.fromCharCode(B&-33,B|32)+Tb})}return f.join(P)}var w=[];g=0;for(i=a.length;g<i;++g){m=a[g];if(m.global||m.multiline)throw new Error(P+
m);w.push(dc+v(m)+ec)}return new RegExp(w.join(O),d?fc:R)}var ha=r;function Td(a){if(r===ha){var b=document.createElement(gc);b.appendChild(document.createTextNode(hc));ha=!/</.test(b.innerHTML)}if(ha){var c=a.innerHTML;if(Ma(a))c=ga(c);return c}for(var d=[],g=a.firstChild;g;g=g.nextSibling)W(g,d);return d.join(P)}function Ud(a){var b=0;return function(c){for(var d=r,g=0,i=0,m=c.length;i<m;++i){var l=c.charAt(i);switch(l){case ic:d||(d=[]);d.push(c.substring(g,i));var n=a-b%a;for(b+=n;n>=0;n-="                ".length)d.push("                ".substring(0,
n));g=i+1;break;case jc:b=0;break;default:++b}}if(!d)return c;d.push(c.substring(g));return d.join(P)}}var Vd=new RegExp(kc,R),Wd=/^<\!--/,Xd=/^<\[CDATA\[/,Yd=/^<br\b/i,Qa=/^<(\/?)([a-zA-Z]+)/;function Zd(a){var b=a.match(Vd),c=[],d=0,g=[];if(b)for(var i=0,m=b.length;i<m;++i){var l=b[i];if(l.length>1&&l.charAt(0)===I){if(!Wd.test(l))if(Xd.test(l)){c.push(l.substring(9,l.length-3));d+=l.length-12}else if(Yd.test(l)){c.push(jc);++d}else if(l.indexOf(lc)>=0&&$d(l)){var n=l.match(Qa)[2],q=1,v;v=i+1;a:for(;v<
m;++v){var w=b[v].match(Qa);if(w&&w[2]===n)if(w[1]===ra){if(--q===0)break a}else++q}if(v<m){g.push(d,b.slice(i,v+1).join(P));i=v}else g.push(d,l)}else g.push(d,l)}else{var j=Sd(l);c.push(j);d+=j.length}}return{source:c.join(P),tags:g}}function $d(a){return!!a.replace(/\s(\w+)\s*=\s*(?:\"([^\"]*)\"|'([^\']*)'|(\S+))/g,mc).match(/[cC][lL][aA][sS][sS]=\"[^\"]*\bnocode\b/)}function ia(a,b,c,d){if(b){var g={source:b,b:a};c(g);d.push.apply(d,g.c)}}function K(a,b){var c={},d;(function(){for(var m=a.concat(b),
l=[],n={},q=0,v=m.length;q<v;++q){var w=m[q],j=w[3];if(j)for(var f=j.length;--f>=0;)c[j.charAt(f)]=w;var s=w[1],k=P+s;if(!n.hasOwnProperty(k)){l.push(s);n[k]=r}}l.push(/[\0-\uffff]/);d=Na(l)})();var g=b.length,i=function(m){for(var l=m.source,n=m.b,q=[n,S],v=0,w=l.match(d)||[],j={},f=0,s=w.length;f<s;++f){var k=w[f],h=j[k],e,p;if(typeof h===nc)p=z;else{var t=c[k.charAt(0)];if(t){e=k.match(t[1]);h=t[0]}else{for(var u=0;u<g;++u){t=b[u];if(e=k.match(t[1])){h=t[0];break}}e||(h=S)}if((p=h.length>=5&&T===
h.substring(0,5))&&!(e&&e[1])){p=z;h=oc}p||(j[k]=h)}var x=v;v+=k.length;if(p){var B=e[1],E=k.indexOf(B),A=E+B.length,D=h.substring(5);ia(n+x,k.substring(0,E),i,q);ia(n+x+E,B,Ra(D,B),q);ia(n+x+A,k.substring(A),i,q)}else q.push(n+x,h)}m.c=q};return i}function C(a){var b=[],c=[];if(a.tripleQuotedStrings)b.push([U,/^(?:\'\'\'(?:[^\'\\]|\\[\s\S]|\'{1,2}(?=[^\']))*(?:\'\'\'|$)|\"\"\"(?:[^\"\\]|\\[\s\S]|\"{1,2}(?=[^\"]))*(?:\"\"\"|$)|\'(?:[^\\\']|\\[\s\S])*(?:\'|$)|\"(?:[^\\\"]|\\[\s\S])*(?:\"|$))/,r,pc]);
else a.multiLineStrings?b.push([U,/^(?:\'(?:[^\\\']|\\[\s\S])*(?:\'|$)|\"(?:[^\\\"]|\\[\s\S])*(?:\"|$)|\`(?:[^\\\`]|\\[\s\S])*(?:\`|$))/,r,qc]):b.push([U,/^(?:\'(?:[^\\\'\r\n]|\\.)*(?:\'|$)|\"(?:[^\\\"\r\n]|\\.)*(?:\"|$))/,r,rc]);if(a.hashComments)a.cStyleComments?b.push([V,/^#(?:[^\r\n\/]|\/(?!\*)|\/\*[^\r\n]*?\*\/)*/,r,F]):b.push([V,/^#[^\r\n]*/,r,F]);if(a.cStyleComments){c.push([V,/^\/\/[^\r\n]*/,r]);c.push([V,/^\/\*[\s\S]*?(?:\*\/|$)/,r])}a.regexLiterals&&c.push([sc,new RegExp(M+N+tc)]);var d=
a.keywords.replace(/^\s+|\s+$/g,P);d.length&&c.push([uc,new RegExp(vc+d.replace(/\s+/g,O)+wc),r]);b.push([S,/^\s+/,r,xc]);c.push([yc,/^@[a-z_$][a-z_$@0-9]*/i,r,Ia],[zc,/^@?[A-Z]+[a-z][A-Za-z_$@0-9]*/,r],[S,/^[a-z_$][a-z_$@0-9]*/i,r],[yc,/^(?:0x[a-f0-9]+|(?:\d(?:_\d+)*\d*(?:\.\d*)?|\.\d\+)(?:e[+\-]?\d+)?)[a-z]*/i,r,Ac],[Y,/^.[^\s\w\.$@\'\"\`\/\#]*/,r]);return K(b,c)}var ae=C({keywords:Bc,hashComments:o,cStyleComments:o,multiLineStrings:o,regexLiterals:o});function be(a){var b=a.source,c=a.f,d=a.c,
g=[],i=0,m=r,l=r,n=0,q=0,v=Ud(window.PR_TAB_WIDTH),w=/([\r\n ]) /g,j=/(^| ) /gm,f=/\r\n?|\n/g,s=/[ \r\n]$/,k=o;function h(p){if(p>i){if(m&&m!==l){g.push(Cc);m=r}if(!m&&l){m=l;g.push(Dc,m,Ec)}var t=ga(v(b.substring(i,p))).replace(k?j:w,Fc);k=s.test(t);var u=window._pr_isIE6()?Gc:Hc;g.push(t.replace(f,u));i=p}}for(;1;){var e;if(e=n<c.length?q<d.length?c[n]<=d[q]:o:z){h(c[n]);if(m){g.push(Cc);m=r}g.push(c[n+1]);n+=2}else if(q<d.length){h(d[q]);l=d[q+1];q+=2}else break}h(b.length);m&&g.push(Cc);a.a=g.join(P)}
var X={};function y(a,b){for(var c=b.length;--c>=0;){var d=b[c];if(X.hasOwnProperty(d))Ic in window&&console.i(Jc,d);else X[d]=a}}function Ra(a,b){a&&X.hasOwnProperty(a)||(a=/^\s*</.test(b)?Kc:Lc);return X[a]}y(ae,[Lc]);y(K([],[[S,/^[^<?]+/],[Mc,/^<!\w[^>]*(?:>|$)/],[V,/^<\!--[\s\S]*?(?:-\->|$)/],[T,/^<\?([\s\S]+?)(?:\?>|$)/],[T,/^<%([\s\S]+?)(?:%>|$)/],[Y,/^(?:<[%?]|[%?]>)/],[T,/^<xmp\b[^>]*>([\s\S]+?)<\/xmp\b[^>]*>/i],[Z,/^<script\b[^>]*>([\s\S]+?)<\/script\b[^>]*>/i],[$,/^<style\b[^>]*>([\s\S]+?)<\/style\b[^>]*>/i],
[Nc,/^(<\/?[a-z][^<>]*>)/i]]),[Kc,Oc,Pc,Qc,Rc,Sc,Tc]);y(K([[S,/^[\s]+/,r,Uc],[Vc,/^(?:\"[^\"]*\"?|\'[^\']*\'?)/,r,rc]],[[Wc,/^^<\/?[a-z](?:[\w:-]*\w)?|\/?>$/],[Xc,/^(?!style\b|on)[a-z](?:[\w:-]*\w)?/],[Yc,/^=\s*([^>\'\"\s]*(?:[^>\'\"\s\/]|\/(?=\s)))/],[Y,/^[=<>\/]+/],[Z,/^on\w+\s*=\s*\"([^\"]+)\"/i],[Z,/^on\w+\s*=\s*\'([^\']+)\'/i],[Z,/^on\w+\s*=\s*([^\"\'>\s]+)/i],[$,/^sty\w+\s*=\s*\"([^\"]+)\"/i],[$,/^sty\w+\s*=\s*\'([^\']+)\'/i],[$,/^sty\w+\s*=\s*([^\"\'>\s]+)/i]]),[Zc]);y(K([],[[Vc,/^[\s\S]+/]]),
[$c]);y(C({keywords:ad,hashComments:o,cStyleComments:o}),[bd,cd,dd,ed,fd,gd]);y(C({keywords:hd}),[id]);y(C({keywords:jd,hashComments:o,cStyleComments:o}),[kd]);y(C({keywords:ld,cStyleComments:o}),[md]);y(C({keywords:nd,hashComments:o,multiLineStrings:o}),[od,pd,qd]);y(C({keywords:rd,hashComments:o,multiLineStrings:o,tripleQuotedStrings:o}),[sd,td]);y(C({keywords:ud,hashComments:o,multiLineStrings:o,regexLiterals:o}),[vd,wd,xd]);y(C({keywords:yd,hashComments:o,multiLineStrings:o,regexLiterals:o}),
[zd]);y(C({keywords:Ad,cStyleComments:o,regexLiterals:o}),[Bd]);y(K([],[[U,/^[\s\S]+/]]),[Cd]);function Sa(a){var b=a.e,c=a.d;a.a=b;try{var d=Zd(b),g=d.source;a.source=g;a.b=0;a.f=d.tags;Ra(c,g)(a);be(a)}catch(i){if(Ic in window){console.log(i);console.h()}}}function ce(a,b){var c={e:a,d:b};Sa(c);return c.a}function de(a){for(var b=window._pr_isIE6(),c=[document.getElementsByTagName(Dd),document.getElementsByTagName(Ed),document.getElementsByTagName(Fd)],d=[],g=0;g<c.length;++g)for(var i=0,m=c[g].length;i<
m;++i)d.push(c[g][i]);c=r;var l=Date;l.now||(l={now:function(){return(new Date).getTime()}});var n=0,q;function v(){for(var j=window.PR_SHOULD_USE_CONTINUATION?l.now()+250:Infinity;n<d.length&&l.now()<j;n++){var f=d[n];if(f.className&&f.className.indexOf(Gd)>=0){var s=f.className.match(/\blang-(\w+)\b/);if(s)s=s[1];for(var k=z,h=f.parentNode;h;h=h.parentNode)if((h.tagName===Dd||h.tagName===Ed||h.tagName===Fd)&&h.className&&h.className.indexOf(Gd)>=0){k=o;break}if(!k){var e=Td(f);e=e.replace(/(?:\r\n?|\n)$/,
P);q={e:e,d:s,g:f};Sa(q);w()}}}if(n<d.length)setTimeout(v,250);else a&&a()}function w(){var j=q.a;if(j){var f=q.g;if(Ma(f)){for(var s=document.createElement(gc),k=0;k<f.attributes.length;++k){var h=f.attributes[k];if(h.specified){var e=h.name.toLowerCase();if(e===Hd)s.className=h.value;else s.setAttribute(h.name,h.value)}}s.innerHTML=j;f.parentNode.replaceChild(s,f);f=s}else f.innerHTML=j;if(b&&f.tagName===gc)for(var p=f.getElementsByTagName(Id),t=p.length;--t>=0;){var u=p[t];u.parentNode.replaceChild(document.createTextNode(Jd),
u)}}}v()}window.PR_normalizedHtml=W;window.prettyPrintOne=ce;window.prettyPrint=de;window.PR={combinePrefixPatterns:Na,createSimpleLexer:K,registerLangHandler:y,sourceDecorator:C,PR_ATTRIB_NAME:Xc,PR_ATTRIB_VALUE:Vc,PR_COMMENT:V,PR_DECLARATION:Mc,PR_KEYWORD:uc,PR_LITERAL:yc,PR_NOCODE:lc,PR_PLAIN:S,PR_PUNCTUATION:Y,PR_SOURCE:oc,PR_STRING:U,PR_TAG:Wc,PR_TYPE:zc}})();
})()
//lang:css
PR.registerLangHandler(PR.createSimpleLexer([["pln",/^[ \t\r\n\f]+/,null," \t\r\n\u000c"]],[["str",/^\"(?:[^\n\r\f\\\"]|\\(?:\r\n?|\n|\f)|\\[\s\S])*\"/,null],["str",/^\'(?:[^\n\r\f\\\']|\\(?:\r\n?|\n|\f)|\\[\s\S])*\'/,null],["lang-css-str",/^url\(([^\)\"\']*)\)/i],["kwd",/^(?:url|rgb|\!important|@import|@page|@media|@charset|inherit)(?=[^\-\w]|$)/i,null],["lang-css-kw",/^(-?(?:[_a-z]|(?:\\[0-9a-f]+ ?))(?:[_a-z0-9\-]|\\(?:\\[0-9a-f]+ ?))*)\s*:/i],["com",/^\/\*[^*]*\*+(?:[^\/*][^*]*\*+)*\//],["com",
/^(?:<!--|--\>)/],["lit",/^(?:\d+|\d*\.\d+)(?:%|[a-z]+)?/i],["lit",/^#(?:[0-9a-f]{3}){1,2}/i],["pln",/^-?(?:[_a-z]|(?:\\[\da-f]+ ?))(?:[_a-z\d\-]|\\(?:\\[\da-f]+ ?))*/i],["pun",/^[^\s\w\'\"]+/]]),["css"]);PR.registerLangHandler(PR.createSimpleLexer([],[["kwd",/^-?(?:[_a-z]|(?:\\[\da-f]+ ?))(?:[_a-z\d\-]|\\(?:\\[\da-f]+ ?))*/i]]),["css-kw"]);PR.registerLangHandler(PR.createSimpleLexer([],[["str",/^[^\)\"\']+/]]),["css-str"]);
