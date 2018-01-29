//CZNN统计
var cnzz_protocol = (("https:" == document.location.protocol) ? " https://" : " http://");
document.write(unescape("%3Cspan style='display: none;' id='cnzz_stat_icon_1262999256'%3E%3C/span%3E%3Cscript src='" + cnzz_protocol + "s13.cnzz.com/z_stat.php%3Fid%3D1262999256%26show%3Dpic' type='text/javascript'%3E%3C/script%3E"));

//百度推送
(function () {
    var bp = document.createElement('script');
    var curProtocol = window.location.protocol.split(':')[0];
    if (curProtocol === 'https') {
        bp.src = 'https://zz.bdstatic.com/linksubmit/push.js'
    } else {
        bp.src = 'http://push.zhanzhang.baidu.com/push.js'
    }
    var s = document.getElementsByTagName("script")[0];
    s.parentNode.insertBefore(bp, s)
})();