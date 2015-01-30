

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-34648935-2']);
        _gaq.push(['_trackPageview']);

        (function() {
         var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
         ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
         var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
         })();



    $(document).ready(function() {
        $('#navlinks ul li').hover(
        function() {
            $(this).css('border-right-color', 'white');
        },
        function() {
            $(this).css('border-right-color', '#BEBEBE');
        });
        $('#external-links li').hover(
        function() {
            $(this).css('background', '#333');
        },
        function() {
            $(this).css('background', '#222');
        });
    });

    $(function() {
        $('.element').each(function (idx, raw_elem){
            var elem = $(raw_elem);
            var desc = $('.desc', elem),
                cover = $('.cover', elem),
                block = $('.block', elem);
            var details_showing = false,
                video_inside = $('iframe', block).length != 0;

            block.css({top:elem.height()});
            cover.css({top:0});

            elem.click(function() {
                if (!details_showing) {
                    block.stop().show().animate({top:0}, 100);
                    cover.stop().animate({ top: -elem.height() }, 200);
                    desc.stop().animate({ bottom : -desc.height() }, 200);

                    details_showing = true;
                } else {
                    block.stop().animate({ top: elem.height()}, 100);
                    cover.stop().animate({ top: 0 }, 200);
                    desc.stop().show().animate({ bottom : 0 }, 200);

                    details_showing = false;
                }
            });

            var timeout_id;

            elem.hover(function() {
                elem.css({"border-color": "#78a", "box-shadow": "#567 0px 0px 16px", "-webkit-animation" : "handon 1s"});
                if (!details_showing) desc.stop().show().animate({ bottom : 0 }, 200);
                else { clearTimeout(timeout_id); }
            }, function() {
                elem.css({"border-color": "#111", "box-shadow": "black 0px 0px 16px", "-webkit-animation" : "handoff 1s"});
                desc.stop().animate({ bottom : -desc.height() }, 200);
                if (!video_inside && details_showing) {
                    timeout_id = setTimeout(function() {
                        block.stop().animate({ top: elem.height()}, 100);
                        cover.stop().animate({ top: 0 }, 200);

                        details_showing = false;
                    }, 500);
                }
            })

        })
        $('#rpanel').height($(document).height() + 50);

    });
   


 
    $(function() {
        $('#lpanel').height($(document).height());
    });
    window.onload = function() {
        $('#lpanel').height($(document).height());
    }
    $(window).resize(function () {
        $('#lpanel').height($(document).height()); 
    })
    