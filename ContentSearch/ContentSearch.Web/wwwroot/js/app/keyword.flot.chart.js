var plot_1;

pageSetUp();

function createArray(length) {
    var arr = new Array(length || 0),
        i = length;

    if (arguments.length > 1) {
        var args = Array.prototype.slice.call(arguments, 1);
        while (i--) arr[length - 1 - i] = createArray.apply(this, args);
    }

    return arr;
}

var pagefunction = function (result) {

    /* chart colors default */
    var $chrt_border_color = "#efefef";
    var $chrt_grid_color = "#DDD";
    var $chrt_main = "#E24913"; /* red       */
    var $chrt_second = "#6595b4"; /* blue      */
    var $chrt_third = "#FF9F01"; /* orange    */
    var $chrt_fourth = "#7e9d3a"; /* green     */
    var $chrt_fifth = "#BD362F"; /* dark red  */
    var $chrt_mono = "#000";

    /* sales chart */

    if ($("#saleschart").length && result !== undefined &&
        result.keyWords !== undefined) {
        var data = createArray(result.keyWords.items.length, 2);
        for (var pr = 0; pr < result.keyWords.items.length; pr++) {
            data[pr][0] = result.keyWords.items[pr].key;
            data[pr][1] = parseInt(result.keyWords.items[pr].value);
        }

        plot_1 = $.plot("#saleschart", [data], {
            series: {
                bars: {
                    show: true,
                    barWidth: 0.6,
                    align: "center"
                }
            },
            grid: {
                color: '#999',
                borderColor: '#fff',
                borderWidth: 1,
                hoverable: true,
                clickable: true,
            },
            xaxis: {
                mode: "categories",
                tickColor: '#fff'
            },
            tooltip: {
                show: true
            },
            tooltipOpts: {
                content: "Total Count : <span>%y</span>",
                dateFormat: "%y-%0m-%0d",
                defaultTheme: false
            },
            colors: ['#E91E63']
        });
        $('#saleschart').removeAttr("style");
        $('#saleschart').attr("style", "padding:12px;");
        $('#totalWordCount').text('Total Keywords Count:' + result.keyWords.totalCount);
    };

    /* end sales chart */
};

var pagedestroy = function () {
    if (plot_1 !== undefined && plot_1 !== null) {
        //destroy flots
        plot_1.shutdown();
        plot_1 = null;
    }

    $('#saleschart').text('');
};

// load all flot plugins
loadScript("/js/plugin/flot/jquery.flot.cust.min.js",
    function () {
        loadScript("/js/plugin/flot/jquery.flot.fillbetween.min.js",
            function () {
                loadScript("/js/plugin/flot/jquery.flot.orderBar.min.js",
                    function () {
                        loadScript("/js/plugin/flot/jquery.flot.categories.min.js",
                            function () {
                                loadScript("/js/plugin/flot/jquery.flot.time.min.js",
                                    function () {
                                        loadScript("/js/plugin/flot/jquery.flot.tooltip.min.js");
                                    });
                            });
                    });
            });
    });