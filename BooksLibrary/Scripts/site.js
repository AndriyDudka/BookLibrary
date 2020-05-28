$(function () {
    var n = 600000; //синхронізація з сервером кожні 10 хв
        setInterval(function() {
            $.ajax({
                url: '/Home/Index',
                type: 'GET'
            });
        }, n);

    $("#displayBook").val(selectedType);

    $(".removeBook").click(function () {
        var id = this.parentNode.id;   
        $.ajax({
            url: '/Home/RemoveBook',
            data: { "id": id },
            type: 'POST',
            success: function(data) {
                window.location.href = data.Url;
            }
        });
    });

    $(".changeState").click(function () {
        $('body').css('overflow', 'hidden');
        var visible = $(".book-type-popup").css("visibility");
        if (visible !== "visible") {
            var id = this.parentNode.id;
            $(".book-type-popup").css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) +
                $(window).scrollTop()) + "px");
            $(".book-type-popup").css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) +
                $(window).scrollLeft()) + "px");
            $(".book-type-popup").css("visibility", "visible");
            
            $(".book-type").on('click', function () {
                var value = $(this).text();
                $.ajax({
                    url: '/Home/ChangeState',
                    data: { id: id, state: value },
                    type: 'POST',
                    success: function (data) {
                        window.location.href = data.Url;
                    }
                });
            });
        }
    });

    $('#displayBook').on('change', function () {
        $.ajax({
            url: '/Home/ChangeType',
            data: { "type": this.value },
            type: 'POST',
            success: function (data) {
                window.location.href = data.Url;
            }
        });
    });
});

