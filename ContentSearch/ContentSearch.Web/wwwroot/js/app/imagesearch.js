var chartData;

function isValidURL(str) {

    if (isNullOrEmpty(str)) {
        return false;
    }

    var regexp = /^(?:(?:https?|ftp):\/\/)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/\S*)?$/;
    if (regexp.test(str)) {
        return true;
    } else {
        return false;
    }
}

function appendHttpProtoIfMissing(str) {

    if (isNullOrEmpty(str)) {
        return false;
    }

    if (!str.match(/^[a-zA-Z]+:\/\//)) {
        str = 'http://' + str;
    }

    return str;
}

function isNullOrEmpty(str) {
    if (str === undefined || str === null || str === '') {
        return true;
    }
}

function displayErrorMessage() {
    $('#webImages').html('');
    $('#totalWordCount').text('');
    chartData = null;
    pagedestroy();
}

function renderChart(chartData) {
    try {
        pagefunction(chartData);
    } catch (e) {
        console.warn('Chart resize');
    }
}

$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    if (e.target.name === "chartTab") {
        renderChart(chartData);
    }
});

$("#websiteUrl").keyup(function (event) {
    var input = $("#websiteUrl").val();
    if (isValidURL(input)) {
        $("#searchContent").removeAttr('disabled');
    } else {
        $('#searchContent').attr('disabled', 'true');
        return;
    }

    if (event.keyCode === 13) {
        $("#searchContent").click();
    }
});

$("#searchContent").click(function () {

    var requestWebUrl = appendHttpProtoIfMissing($('#websiteUrl').val());
    var dataObject = {
        'url': requestWebUrl
    };

    $.ajax({
        type: "POST",
        url: "/api/content/search",
        dataType: 'json',
        data: dataObject,
        success: function (response) {
            if (response.keyWords !== null && response.keyWords !== undefined &&
                response.keyWords.items !== null && response.keyWords.items.length > 0) {
                chartData = response;
            }

            var htmlString = "";
            $.each(response.images, function (i, item) {
                if (!isValidURL(item)) {
                    item = requestWebUrl + item;
                }
                imageUrl = item
                htmlString += "<a href='" + item + "' data-gallery=''><img style='margin: 5px;' src='" + item + "' height='100px' width='100px'></a>";
            });

            $('#webImages').html(htmlString + "");
            renderChart(response);
        },
        error: function (error) {
            displayErrorMessage();
        },
        fail: function (error) {
            displayErrorMessage();
        }
    });
});