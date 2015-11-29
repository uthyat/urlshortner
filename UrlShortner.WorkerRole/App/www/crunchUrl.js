(function (global, $, Q) {
    var hostUrl = global.location.href + 'api/url',
        setShortUrl = function (shorturl) {            
            $('#shorturl').text(shorturl);
            $('#shorturl').attr('href', shorturl);
            $('#shorturl').attr('target', '_blank');
            $('#shorturl').show();
        },
        crunchUrl = function (url) {
            Q($.ajax({
                type: 'POST',
                url: hostUrl,
                contentType: 'application/json', // the request type
                dataType: 'json', // the repsonse type
                data: JSON.stringify(url)
            })).then(function (response) {
                setShortUrl(response);
            });
        };

    // hide the short url hyperlink on load
    $('#shorturl').hide();

    // hanlde url text box input
    $('#urltextbox').blur(function () {
        // get text box value and call the service
        // only when the length is > 0
        var url = $('#urltextbox').val();

        $('#shorturl').hide();
        if(url.length){
            crunchUrl(url);
        }
    });

})(window, window.$, Q);